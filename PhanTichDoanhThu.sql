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

CREATE OR ALTER PROCEDURE [dbo].[sp_GetMonthlyRevenueAnalysis]
    @startDate DATETIME = NULL,
    @endDate DATETIME = NULL
AS
BEGIN
    -- Gán giá trị mặc định cho @startDate và @endDate nếu không truyền vào
    IF @startDate IS NULL OR @endDate IS NULL
    BEGIN
        SET @startDate = DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1);
        SET @endDate = GETDATE();
    END
    
    DECLARE @totalRevenueCurrentMonth DECIMAL(18, 2);
    SELECT @totalRevenueCurrentMonth = SUM(b.total)
    FROM bill b
    WHERE b.created_at BETWEEN @startDate AND @endDate;
   
    DECLARE @totalRevenueLastMonth DECIMAL(18, 2);
    DECLARE @lastMonthStartDate DATE = DATEADD(MONTH, -1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1));
    DECLARE @lastMonthEndDate DATE = EOMONTH(@lastMonthStartDate);

    SELECT @totalRevenueLastMonth = SUM(b.total)
    FROM bill b
    WHERE b.created_at BETWEEN @lastMonthStartDate AND @lastMonthEndDate;
    
    DECLARE @growthRate DECIMAL(5, 2) = 0;
    IF @totalRevenueLastMonth > 0
    BEGIN
        SET @growthRate = (@totalRevenueCurrentMonth - @totalRevenueLastMonth) / @totalRevenueLastMonth * 100;
    END

    DECLARE @predictedRevenueNextMonth DECIMAL(18, 2);
    SET @predictedRevenueNextMonth = @totalRevenueCurrentMonth * (1 + @growthRate / 100);

    DECLARE @threeMonthRevenueLastYear DECIMAL(18, 2) = 0;
    DECLARE @threeMonthRevenueCurrentYear DECIMAL(18, 2) = 0;
    DECLARE @growth3Rate DECIMAL(5, 2) = 0;
    DECLARE @predictedRevenueNextYear DECIMAL(18, 2) = 0;

    SELECT @threeMonthRevenueLastYear = SUM(b.total)
    FROM bill b
    WHERE b.created_at BETWEEN DATEFROMPARTS(YEAR(GETDATE()) - 1, 1, 1) AND DATEFROMPARTS(YEAR(GETDATE()) - 1, 3, 31);

    SELECT @threeMonthRevenueCurrentYear = SUM(b.total)
    FROM bill b
    WHERE b.created_at BETWEEN DATEFROMPARTS(YEAR(GETDATE()), 1, 1) AND DATEFROMPARTS(YEAR(GETDATE()), 3, 31);

    IF @threeMonthRevenueLastYear > 0
    BEGIN
        SET @growth3Rate = (@threeMonthRevenueCurrentYear - @threeMonthRevenueLastYear) / @threeMonthRevenueLastYear * 100;
    END

    SET @predictedRevenueNextYear = @threeMonthRevenueCurrentYear * (1 + @growth3Rate / 100);

    CREATE TABLE #Result ([Phân tích] NVARCHAR(100), [Nội dung] NVARCHAR(500), [Tổng doanh thu] NUMERIC(18, 2));

    INSERT INTO #Result ([Phân tích], [Nội dung], [Tổng doanh thu])
    SELECT N'Tổng doanh thu tháng này', N'Từ ngày ' + CONVERT(NVARCHAR, @startDate, 103) + N' đến ' + CONVERT(NVARCHAR, @endDate, 103), @totalRevenueCurrentMonth;

    INSERT INTO #Result ([Phân tích], [Nội dung], [Tổng doanh thu])
    SELECT N'Tổng doanh thu tháng trước', N'Từ ngày ' + CONVERT(NVARCHAR, @lastMonthStartDate, 103) + N' đến ' + CONVERT(NVARCHAR, @lastMonthEndDate, 103), @totalRevenueLastMonth;

    INSERT INTO #Result ([Phân tích], [Nội dung], [Tổng doanh thu])
    SELECT N'Tỷ lệ tăng trưởng doanh thu', N'Công thức: growthRate = (CurrentMonth - LastMonth) / LastMonth * 100 (%)', @growthRate;

    INSERT INTO #Result ([Phân tích], [Nội dung], [Tổng doanh thu])
    SELECT N'Dự đoán doanh thu tháng sau', N'Công thức: NextMonth = CurrentMonth * (1 + growthRate / 100)', @predictedRevenueNextMonth;

    INSERT INTO #Result ([Phân tích], [Nội dung], [Tổng doanh thu])
    SELECT N'Tổng doanh thu 3 tháng đầu năm trước', N'Từ tháng 1 đến tháng 3 năm trước vào dịp tết', @threeMonthRevenueLastYear;

    INSERT INTO #Result ([Phân tích], [Nội dung], [Tổng doanh thu])
    SELECT N'Tổng doanh thu 3 tháng đầu năm nay vào dịp tết', N'Từ tháng 1 đến tháng 3 năm nay', @threeMonthRevenueCurrentYear;

    INSERT INTO #Result ([Phân tích], [Nội dung], [Tổng doanh thu])
    SELECT N'Tỷ lệ tăng trưởng doanh thu vào dịp tết', N'Công thức: growthRate = (Current3Month - Last3Month) / Last3Month * 100 (%)', @growth3Rate;

    INSERT INTO #Result ([Phân tích], [Nội dung], [Tổng doanh thu])
    SELECT N'Dự đoán doanh thu 3 tháng đầu năm sau vào dịp tết', N'Công thức: Next3Months = Current3Months * (1 + growth3Rate / 100)', @predictedRevenueNextYear;

    SELECT * FROM #Result;

    DROP TABLE #Result;
END


   


