USE hotel_management;
GO

CREATE FUNCTION fn_AdvancedRevenueAnalysisService (
    @startDate DATE = NULL,
    @endDate DATE = NULL
)
RETURNS @Result TABLE (
    [Dịch vụ] NVARCHAR(50),
    [Tổng doanh thu của từng loại dịch vụ] DECIMAL(18, 2)
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
    INSERT INTO @Result ([Dịch vụ],[Tổng doanh thu của từng loại dịch vụ] )
    SELECT
        s.[service_name] AS [Dịch vụ],
        ISNULL(SUM(s.price * sur.quantity), 0) AS [Tổng doanh thu của từng loại dịch vụ]
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
    [Loại phòng] NVARCHAR(50),
    [Tổng doanh thu của từng loại phòng] DECIMAL(18, 2)
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
    INSERT INTO @Result ([Loại phòng], [Tổng doanh thu của từng loại phòng])
    SELECT
        rt.room_type_name AS [Loại phòng],
        ISNULL(SUM(b.total), 0) AS [Tổng doanh thu của từng loại phòng]
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

    -- Kết hợp kết quả dịch vụ và loại phòng trong một bảng duy nhất
    SELECT N'Dịch vụ không được sử dụng' AS [Loại phòng và dịch vụ không được đặt trong 3 tháng qua], 
           s.service_name AS [Tên]
    FROM service s
    LEFT JOIN service_usage_record sur ON s.service_id = sur.service_id
    LEFT JOIN booking_record br ON br.booking_record_id = sur.booking_id
    LEFT JOIN bill b ON b.customer_id = br.customer_id AND b.created_at BETWEEN @startDate AND @endDate
    GROUP BY s.service_name
    HAVING COUNT(sur.service_id) = 0

    UNION ALL

    SELECT N'Loại phòng không được đặt' AS [Loại phòng và dịch vụ không được đặt trong 3 tháng qua],
           rt.room_type_name AS [Tên]
    FROM room_type rt
    LEFT JOIN room r ON rt.room_type_id = r.room_type_id
    LEFT JOIN booking_record br ON r.room_id = br.room_id
    LEFT JOIN bill b ON b.customer_id = br.customer_id AND b.created_at BETWEEN @startDate AND @endDate
    WHERE br.booking_record_id IS NULL
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
    CREATE TABLE #Result ([Phân tích] NVARCHAR(100), [Nội dung] NVARCHAR(500),[Tổng doanh thu] DECIMAL(18, 2));

    -- Tổng doanh thu tháng hiện tại
    INSERT INTO #Result ([Phân tích], [Nội dung], [Tổng doanh thu])
    SELECT
        N'Tổng doanh thu tháng này' AS [Phân tích],
        N'Từ ngày ' + CONVERT(NVARCHAR, @startDate, 103) + N' đến ' + CONVERT(NVARCHAR, @endDate, 103) AS [Nội dung],
        @totalRevenueCurrentMonth AS [Tổng doanh thu];
    
    -- Tổng doanh thu tháng trước
    INSERT INTO #Result ([Phân tích], [Nội dung], [Tổng doanh thu])
    SELECT
        N'Tổng doanh thu tháng trước' AS [Phân tích],
        N'Từ ngày ' + CONVERT(NVARCHAR, @lastMonthStartDate, 103) + N' đến ' + CONVERT(NVARCHAR, @lastMonthEndDate, 103) AS [Nội dung],
        @totalRevenueLastMonth AS [Tổng doanh thu];

    -- Tỷ lệ tăng trưởng doanh thu
    INSERT INTO #Result ([Phân tích], [Nội dung], [Tổng doanh thu])
    SELECT
        N'Tỷ lệ tăng trưởng doanh thu' AS [Phân tích],
    N'Công thức: growthRate = (CurrentMonth - LastMonth) / LastMonth * 100 (%)' AS [Nội dung],
    @growthRate  AS [Tổng doanh thu];

    -- Dự đoán doanh thu tháng sau
    INSERT INTO #Result ([Phân tích], [Nội dung], [Tổng doanh thu])
    SELECT
         N'Dự đoán doanh thu tháng sau' AS [Phân tích],
	 N'Công thức: NextMonth = CurrentMonth * (1 + growthRate / 100)' AS [Nội dung],
    @predictedRevenueNextMonth AS [Tổng doanh thu];
    -- Hiển thị kết quả
    SELECT * FROM #Result;

    -- Xóa bảng tạm
    DROP TABLE #Result;
END
GO

   


