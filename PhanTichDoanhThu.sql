USE hotel_management;
GO

CREATE FUNCTION fn_AdvancedRevenueAnalysisService (
    @startDate DATE = NULL,
    @endDate DATE = NULL
)
RETURNS @Result TABLE (
    AnalysisType NVARCHAR(50),
    Content NVARCHAR(50),
    TotalRevenue DECIMAL(18, 2)
)
AS
BEGIN
    -- Gán giá trị mặc định cho @startDate là ngày 1 của tháng hiện tại và @endDate là ngày hiện tại nếu không truyền vào
    IF @startDate IS NULL
    BEGIN
        SET @startDate = DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1);
    END
    
    IF @endDate IS NULL
    BEGIN
        SET @endDate = GETDATE();
    END

    -- Chèn dữ liệu vào bảng trả về
    INSERT INTO @Result (AnalysisType, Content, TotalRevenue)
    SELECT
        N'Dịch vụ' AS AnalysisType,
        s.[service_name] AS Content,
        ISNULL(SUM(s.price * sur.quantity), 0) AS TotalRevenue
    FROM service s
    LEFT JOIN service_usage_record sur ON s.service_id = sur.service_id
    LEFT JOIN booking_record br ON br.booking_record_id = sur.booking_id
    LEFT JOIN bill b ON b.customer_id = br.customer_id AND b.created_at BETWEEN @startDate AND @endDate
    GROUP BY s.[service_name];

    RETURN;
END
go

CREATE FUNCTION fn_AdvancedRevenueAnalysisRoomType (
    @startDate DATE = NULL,
    @endDate DATE = NULL
)
RETURNS @Result TABLE (
    AnalysisType NVARCHAR(50),
    Content NVARCHAR(50),
    TotalRevenue DECIMAL(18, 2)
)
AS
BEGIN
    -- Gán giá trị mặc định cho @startDate là ngày 1 của tháng hiện tại và @endDate là ngày hiện tại nếu không truyền vào
    IF @startDate IS NULL
    BEGIN
        SET @startDate = DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1);
    END
    
    IF @endDate IS NULL
    BEGIN
        SET @endDate = GETDATE();
    END

    -- Chèn dữ liệu vào bảng trả về
    INSERT INTO @Result (AnalysisType, Content, TotalRevenue)
    SELECT
        N'Loại phòng' AS AnalysisType,
        rt.room_type_name AS Content,
        ISNULL(SUM(b.total), 0) AS TotalRevenue
    FROM room_type rt
    LEFT JOIN room r ON rt.room_type_id = r.room_type_id
    LEFT JOIN booking_record br ON r.room_id = br.room_id
    LEFT JOIN bill b ON b.customer_id = br.customer_id AND b.created_at BETWEEN @startDate AND @endDate
    GROUP BY rt.room_type_name;

    RETURN;
END
GO

CREATE OR ALTER PROCEDURE sp_AdvancedRevenueAnalysis
    @startDate DATE = NULL,
    @endDate DATE = NULL
AS
BEGIN
    -- Gán giá trị mặc định cho @startDate và @endDate nếu không truyền vào
    IF @startDate IS NULL
    BEGIN
        -- Ngày bắt đầu là ngày 1 của tháng thứ 3 trước
        SET @startDate = DATEFROMPARTS(YEAR(DATEADD(MONTH, -3, GETDATE())), MONTH(DATEADD(MONTH, -3, GETDATE())), 1); 
    END
    
    IF @endDate IS NULL
    BEGIN
        SET @endDate = GETDATE(); -- Ngày hiện tại
    END

    -- Phân tích tất cả các lần sử dụng dịch vụ trong khoảng thời gian
    SELECT s.service_name as 'Tất cả các lần sử dụng dịch vụ trong 3 tháng qua:'
    FROM service s
    LEFT JOIN service_usage_record sur ON s.service_id = sur.service_id
    LEFT JOIN booking_record br ON br.booking_record_id = sur.booking_id
    LEFT JOIN bill b ON b.customer_id = br.customer_id AND b.created_at BETWEEN @startDate AND @endDate -- Điều kiện ngày của hóa đơn
    GROUP BY s.service_name
    HAVING COUNT(sur.service_id) = 0;

    -- Phân tích tất cả các loại phòng không được đặt trong khoảng thời gian
    SELECT rt.room_type_name as 'Tất cả các loại phòng không được đặt trong 3 tháng qua:'
    FROM room_type rt
    LEFT JOIN room r ON rt.room_type_id = r.room_type_id
    LEFT JOIN booking_record br ON r.room_id = br.room_id 
    LEFT JOIN bill b ON b.customer_id = br.customer_id AND b.created_at BETWEEN @startDate AND @endDate -- Điều kiện ngày của hóa đơn
    WHERE br.booking_record_id IS NULL -- Điều kiện lọc các loại phòng không có booking_record
    GROUP BY rt.room_type_name;
	
END
GO




EXEC sp_AdvancedRevenueAnalysis;
EXEC sp_GetMonthlyRevenueAnalysis;

-- Thực thi thủ tục
SELECT * FROM fn_AdvancedRevenueAnalysisService(null,null);


SELECT * FROM fn_AdvancedRevenueAnalysisRoomType(null,null);

CREATE OR ALTER PROCEDURE sp_GetMonthlyRevenueAnalysis
    @startDate DATETIME = NULL,  -- Ngày bắt đầu của tháng hiện tại
    @endDate DATETIME = NULL     -- Ngày kết thúc của tháng hiện tại
AS
BEGIN
    -- Gán giá trị mặc định cho @startDate và @endDate nếu không truyền vào
    IF @startDate IS NULL OR @endDate IS NULL
    BEGIN
        -- Ngày bắt đầu của tháng hiện tại
        SET @startDate = DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1);
        -- Ngày kết thúc của tháng hiện tại
        SET @endDate = GETDATE();
    END
    
    -- Tổng doanh thu của tháng hiện tại
    DECLARE @totalRevenueCurrentMonth DECIMAL(18, 2);

    SELECT @totalRevenueCurrentMonth = SUM(b.total)
    FROM bill b
    WHERE b.created_at BETWEEN @startDate AND @endDate;
   
    -- Tổng doanh thu của tháng trước
    DECLARE @totalRevenueLastMonth DECIMAL(18, 2);

    -- Tính khoảng thời gian của tháng trước
    DECLARE @lastMonthStartDate DATE = DATEADD(MONTH, -1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1));
    DECLARE @lastMonthEndDate DATE = EOMONTH(@lastMonthStartDate);

    SELECT @totalRevenueLastMonth = SUM(b.total)
    FROM bill b
    WHERE b.created_at BETWEEN @lastMonthStartDate AND @lastMonthEndDate;
    
    -- Kiểm tra nếu doanh thu tháng trước > 0 để tính tỷ lệ tăng trưởng
    DECLARE @growthRate DECIMAL(5, 2) = 0; -- Nếu doanh thu tháng trước = 0, tỷ lệ tăng trưởng sẽ là 0%

    IF @totalRevenueLastMonth > 0
    BEGIN
        -- Tính tỷ lệ tăng trưởng doanh thu từ tháng trước đến tháng hiện tại
        SET @growthRate = (@totalRevenueCurrentMonth - @totalRevenueLastMonth) / @totalRevenueLastMonth * 100;
    END

    -- Dự đoán doanh thu tháng sau
    DECLARE @predictedRevenueNextMonth DECIMAL(18, 2);
    
    -- Dự đoán doanh thu tháng sau theo tỷ lệ tăng trưởng
    SET @predictedRevenueNextMonth = @totalRevenueCurrentMonth * (1 + @growthRate / 100);

    -- Chèn kết quả vào bảng tạm #Result
    CREATE TABLE #Result (AnalysisType NVARCHAR(100), Content NVARCHAR(500), TotalRevenue DECIMAL(18, 2));

    -- Tổng doanh thu tháng hiện tại
    INSERT INTO #Result (AnalysisType, Content, TotalRevenue)
    SELECT
        N'Tổng doanh thu tháng này' AS AnalysisType,
        N'Từ ngày ' + CONVERT(NVARCHAR, @startDate, 103) + N' đến ' + CONVERT(NVARCHAR, @endDate, 103) AS Content,
        @totalRevenueCurrentMonth AS TotalRevenue;
    
    -- Tổng doanh thu tháng trước
    INSERT INTO #Result (AnalysisType, Content, TotalRevenue)
    SELECT
        N'Tổng doanh thu tháng trước' AS AnalysisType,
        N'Từ ngày ' + CONVERT(NVARCHAR, @lastMonthStartDate, 103) + N' đến ' + CONVERT(NVARCHAR, @lastMonthEndDate, 103) AS Content,
        @totalRevenueLastMonth AS TotalRevenue;

    -- Tỷ lệ tăng trưởng doanh thu
    INSERT INTO #Result (AnalysisType, Content, TotalRevenue)
    SELECT
        N'Tỷ lệ tăng trưởng doanh thu' AS AnalysisType,
    N'Công thức: growthRate = (CurrentMonth - LastMonth) / LastMonth * 100' AS Content,
    @growthRate AS TotalRevenue;

    -- Dự đoán doanh thu tháng sau
    INSERT INTO #Result (AnalysisType, Content, TotalRevenue)
    SELECT
         N'Dự đoán doanh thu tháng sau' AS AnalysisType,
	 N'Công thức: NextMonth = CurrentMonth * (1 + growthRate / 100)' AS Content,
    @predictedRevenueNextMonth AS TotalRevenue;
    -- Hiển thị kết quả
    SELECT * FROM #Result;

    -- Xóa bảng tạm
    DROP TABLE #Result;
END
GO

   


