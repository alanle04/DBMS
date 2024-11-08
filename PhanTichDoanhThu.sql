
USE hotel_management;
GO

CREATE OR ALTER PROCEDURE sp_AdvancedRevenueAnalysis (
    @startDate DATETIME = NULL,  -- Thêm tham số cho ngày bắt đầu
    @endDate DATETIME = NULL     -- Thêm tham số cho ngày kết thúc
)
AS
BEGIN
    -- Kiểm tra các tham số
    IF @startDate > @endDate
    BEGIN
        THROW 50000, 'Ngày bắt đầu không được lớn hơn ngày kết thúc', 1;
    END

    -- Bảng tạm để lưu trữ kết quả
    CREATE TABLE #Result (
        AnalysisType NVARCHAR(50),
        Content NVARCHAR(50),
        TotalRevenue DECIMAL(18, 2)
    );

    -- Doanh thu Service
    INSERT INTO #Result (AnalysisType, Content, TotalRevenue)
    SELECT
        N'Dịch vụ' AS AnalysisType,
        s.[service_name] AS Content,
        SUM(s.price * sur.quantity) AS TotalRevenue
    FROM bill b
    JOIN booking_record br ON b.customer_id = br.customer_id
    JOIN service_usage_record sur ON br.booking_record_id = sur.booking_id
    JOIN service s ON s.service_id = sur.service_id
    WHERE b.created_at BETWEEN @startDate AND @endDate
    GROUP BY s.[service_name];

    -- Doanh thu theo giới tính khách hàng
    INSERT INTO #Result (AnalysisType, Content, TotalRevenue)
    SELECT
        N'Giới tính khách hàng' AS AnalysisType,
        c.gender AS Content,
        SUM(bill.total) AS TotalRevenue
    FROM bill
    JOIN customer c ON bill.customer_id = c.customer_id
    WHERE bill.created_at BETWEEN @startDate AND @endDate
    GROUP BY c.gender;

    -- Doanh thu theo khu vực địa lý của khách
    INSERT INTO #Result (AnalysisType, Content, TotalRevenue)
    SELECT
        N'Khu vực địa lí của khách' AS AnalysisType,
        c.address AS Content,
        SUM(bill.total) AS TotalRevenue
    FROM bill
    JOIN customer c ON bill.customer_id = c.customer_id
    WHERE bill.created_at BETWEEN @startDate AND @endDate
    GROUP BY c.address;

    -- Doanh thu theo quốc tịch khách hàng
    INSERT INTO #Result (AnalysisType, Content, TotalRevenue)
    SELECT
        N'Quốc tịch của khách' AS AnalysisType,
        c.nationality AS Content,
        SUM(bill.total) AS TotalRevenue
    FROM bill
    JOIN customer c ON bill.customer_id = c.customer_id
    WHERE bill.created_at BETWEEN @startDate AND @endDate
    GROUP BY c.nationality;

    -- Doanh thu theo phương thức thanh toán
    INSERT INTO #Result (AnalysisType, Content, TotalRevenue)
    SELECT
        N'Phương thức thanh toán' AS AnalysisType,
        payment_method AS Content,
        SUM(bill.total) AS TotalRevenue
    FROM bill
    WHERE bill.created_at BETWEEN @startDate AND @endDate
    GROUP BY payment_method;

    -- Doanh thu theo mức giá phòng
    INSERT INTO #Result (AnalysisType, Content, TotalRevenue)
    SELECT
        N'Loại phòng được ưu chuộng' AS AnalysisType,
        room_type.room_type_name AS Content,
        SUM(bill.total) AS TotalRevenue
    FROM bill
    JOIN booking_record ON bill.customer_id = booking_record.customer_id
    JOIN room ON room.room_id = booking_record.room_id
    JOIN room_type ON room_type.room_type_id = room.room_type_id
    WHERE bill.created_at BETWEEN @startDate AND @endDate
    GROUP BY room_type.room_type_name;

    -- Tổng doanh thu
    INSERT INTO #Result (AnalysisType, Content, TotalRevenue)
    SELECT
        N'Tổng doanh thu' AS AnalysisType,
        N'Từ ngày ' + CONVERT(NVARCHAR, @startDate, 103) + N' đến ' + CONVERT(NVARCHAR, @endDate, 103) AS Content,
        SUM(bill.total) AS TotalRevenue
    FROM bill
    WHERE bill.created_at BETWEEN @startDate AND @endDate;

    -- Tỷ lệ tăng trưởng doanh thu 
DECLARE @currentMonthRevenue DECIMAL(18, 2) = 0, 
        @previousMonthRevenue DECIMAL(18, 2) = 0, 
        @growthRate DECIMAL(18, 2) = 0;

-- Doanh thu tháng hiện tại
SELECT @currentMonthRevenue = ISNULL(SUM(bill.total), 0)
FROM bill
WHERE YEAR(bill.created_at) = YEAR(GETDATE()) 
  AND MONTH(bill.created_at) = MONTH(GETDATE());

-- Doanh thu tháng trước
SELECT @previousMonthRevenue = ISNULL(SUM(bill.total), 0)
FROM bill
WHERE YEAR(bill.created_at) = YEAR(DATEADD(MONTH, -1, GETDATE())) 
  AND MONTH(bill.created_at) = MONTH(DATEADD(MONTH, -1, GETDATE()));

-- Tính tỷ lệ tăng trưởng so với tháng trước (chỉ thực hiện nếu @previousMonthRevenue khác 0)
IF @previousMonthRevenue > 0
BEGIN
    SET @growthRate = (@currentMonthRevenue - @previousMonthRevenue) / @previousMonthRevenue * 100;
END
ELSE
BEGIN
    SET @growthRate = 0;
END

-- Dự đoán doanh thu tháng hiện tại so với tháng trước
INSERT INTO #Result (AnalysisType, Content, TotalRevenue)
SELECT
    N'Doanh thu tháng hiện tại so với tháng trước' AS AnalysisType,
    N'Tỷ lệ tăng trưởng: ' + CONVERT(NVARCHAR, @growthRate, 2) + N'%' as Content,
    @currentMonthRevenue AS TotalRevenue;


    -- Trả về kết quả
    SELECT * FROM #Result;
END
GO

exec sp_AdvancedRevenueAnalysis @startDate='1-1-1990',@endDate= '1-1-2030'

