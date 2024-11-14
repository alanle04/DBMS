use hotel_management;
go
-- 3.2.4. Hàm tìm kiếm dữ liệu
-- 3.2.4.1. Bảng room
--Tìm kiếm theo mã phòng

--3.2.4.2.Tìm kiếm theo tên phòng
CREATE FUNCTION fn_SearchRoomByName
(
	@room_name NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
	SELECT
    	room_id,
    	room_name,
    	[status],
    	room_type_id,
    	manager_id
	FROM room
	WHERE room_name = @room_name
);
GO

--3.2.4.3. Bảng customer
--3.2.4.3 Tìm customer theo tên
CREATE FUNCTION fn_FindCustomerByName (
	@full_name VARCHAR(255)
)
RETURNS TABLE
AS
RETURN
(
	SELECT *
	FROM customer
	WHERE full_name LIKE '%' + @full_name + '%'
);
GO

--3.2.4.4 Tìm customer theo id
CREATE FUNCTION fn_FindCustomer (
 	@id_number VARCHAR(20)
)
RETURNS TABLE
AS
RETURN
(
 	SELECT *
 	FROM dbo.customer
 	WHERE customer_id = @id_number
);
GO


--3.2.4.5. Bảng staff 
--3.2.4.5 Tìm kiếm id của staff theo username
CREATE FUNCTION fn_GetStaffIdByUsername(@username VARCHAR(20))
RETURNS VARCHAR(20)
AS
BEGIN
   	DECLARE @staff_id VARCHAR(20);
 
   	SELECT @staff_id = staff_id
   	FROM staff
   	WHERE username = @username
 
   	return @staff_id;
END;
GO


--3.2.4.6 Tìm kiếm full_name của nhân viên theo username
CREATE FUNCTION fn_GetStaffFullNameByUsername(@username VARCHAR(20))
RETURNS NVARCHAR(255)
AS
BEGIN
   	DECLARE @full_name NVARCHAR(255)
 
   	SELECT @full_name = full_name
   	FROM staff
   	WHERE username = @username
 
   	return @full_name;
END;
GO

-- 3.2.4.7. Tính tổng doanh thu theo ngày 
CREATE FUNCTION fn_CalculateTotalRevenueByDate
(
 	@day INT,
 	@month INT,
 	@year INT
)
RETURNS INT
AS
BEGIN
 	DECLARE @totalRevenue INT;
 
 	SELECT @totalRevenue = SUM(CAST(total AS INT)) -- Chuyển 'total' về kiểu INT
 	FROM bill
 	WHERE DAY(created_at) = @day
 	AND MONTH(created_at) = @month
 	AND YEAR(created_at) = @year;
 
 	-- Trả về giá trị tổng doanh thu, nếu không có giá trị thì trả về 0
 	RETURN ISNULL(@totalRevenue, 0);
END;
GO

-- 3.2.4.8. Tính tổng doanh thu theo tháng 
CREATE FUNCTION fn_GetMonthlyRevenue
(
   	@month INT,
   	@year INT
)
RETURNS @DailyRevenueTable TABLE
(
   	[day] INT,
   	total INT
)
AS
BEGIN
   	-- Chèn dữ liệu vào bảng trả về
   	INSERT INTO @DailyRevenueTable([day], total)
   	SELECT
       DAY(created_at) AS [day],
       SUM(total) AS total
   	FROM Bill
   	WHERE MONTH(created_at) = @month AND YEAR(created_at) = @year
   	GROUP BY DAY(created_at)
   	ORDER BY [day];
 
   	RETURN;
END;
GO

-- 3.2.4.9. Tính tổng doanh thu theo quý
CREATE FUNCTION fn_TotalRevenueByQuarter
(
	@quarter INT,
	@year INT
)
RETURNS TABLE
AS
RETURN
(
	SELECT
    	MONTH(created_at) AS month,
    	SUM(total) AS total_revenue
	FROM bill
	WHERE YEAR(created_at) = @year
	AND
	(
    	(MONTH(created_at) BETWEEN 1 AND 3 AND @quarter = 1) OR
    	(MONTH(created_at) BETWEEN 4 AND 6 AND @quarter = 2) OR
    	(MONTH(created_at) BETWEEN 7 AND 9 AND @quarter = 3) OR
    	(MONTH(created_at) BETWEEN 10 AND 12 AND @quarter = 4)
	)
	GROUP BY MONTH(created_at) -- Nhóm theo tháng để tính tổng doanh thu theo từng tháng
);
GO

-- 3.2.4.10. Tính tổng doanh thu theo năm (ví dụ nhập vào 1 năm và tính tổng các hóa đơn trong năm đó)
CREATE FUNCTION fn_TotalRevenueByYear
(
   	@year INT
)
RETURNS TABLE
AS
RETURN
(
   	SELECT
       MONTH(created_at) AS [Month],
       SUM(total) AS TotalRevenue
   	FROM
       bill
   	WHERE
       YEAR(created_at) = @year
   	GROUP BY
       MONTH(created_at)
);
GO


-- 3.2.4.12. Hàm lấy thông tin bill của phòng đang tìm.
CREATE FUNCTION fn_GetBillInfoByRoomId
(
    @room_id  VARCHAR(20)
)
RETURNS TABLE
AS
RETURN
(
    SELECT bill.*
    FROM bill
    INNER JOIN booking_record b ON b.customer_id = bill.customer_id
    WHERE b.room_id = @room_id
  	AND b.actual_check_out_time IS NULL
  	AND bill.created_at IS NULL
);
GO

-- 3.2.4.13. Hàm lấy thông tin phiếu đặt phòng
CREATE FUNCTION fn_GetBookingRecordByRoomIdToCheckOut
(
    @room_id  VARCHAR(20)
)
RETURNS TABLE
AS
RETURN
(
    SELECT
    	br.booking_record_id,
    	br.booking_time,
    	br.status,
    	br.expected_check_in_time,
    	br.expected_check_out_time,
    	br.actual_check_in_time,
    	br.actual_check_out_time,
    	br.receptionist_id,
    	s.full_name AS receptionist_name,
    	br.customer_id,
    	c.full_name AS customer_name,
    	br.room_id,
    	r.room_name
    FROM
    	booking_record br
    LEFT JOIN
    	staff s ON br.receptionist_id = s.staff_id
    LEFT JOIN
    	customer c ON br.customer_id = c.customer_id
    LEFT JOIN
    	room r ON br.room_id = r.room_id
    WHERE
    	br.room_id = @room_id
       	AND br.status = 'staying'
);
GO

-- 3.2.4.14. Hàm lấy thông tin phiếu dịch vụ thông qua mã phòng
CREATE OR ALTER FUNCTION fn_GetServiceUsageInfoByRoomId
(
    @roomId  VARCHAR(20)
)
RETURNS TABLE
AS
RETURN
(
    SELECT s.*
    FROM service_usage_record s
 	JOIN booking_record b ON s.booking_id = b.booking_record_id
    WHERE b.room_id = @roomId AND b.status = 'staying'
);
GO


-- 3.2.4.15. Hàm tìm các phòng đã đặt của 1 khách hàng qua mã định danh
CREATE FUNCTION fn_GetDepositedRoomsByIdNumber(@id_number VARCHAR(20))
RETURNS TABLE
AS
RETURN
(
 	SELECT
       	br.booking_record_id,
       	r.room_name,
       	rt.room_type_name,
       	r.status,
       	c.full_name,
       	c.identification_number,
       	br.expected_check_in_time,
       	br.expected_check_out_time,
       	rt.capacity,
       	rt.cost_per_day
 	FROM
       	room r
       	JOIN room_type rt ON r.room_type_id = rt.room_type_id
       	JOIN booking_record br ON r.room_id = br.room_id
       	JOIN customer c ON br.customer_id = c.customer_id
 	WHERE
       	c.identification_number = @id_number AND br.status = 'deposited');
GO

-- 3.2.4.16. Hàm lấy thông tin mã phiếu đặt phòng đang được áp dụng qua mã phòng
CREATE OR ALTER FUNCTION fn_GetBookingRecordIdByRoomIdCustomerId(
    @room_id VARCHAR(20)
)
RETURNS VARCHAR(20)
AS
BEGIN
    DECLARE @booking_record_id VARCHAR(20);
 
    -- Lấy booking_record_id với điều kiện theo room_id, customer_id, và status
    SELECT @booking_record_id = booking_record_id
    FROM booking_record
    WHERE room_id = @room_id and status = 'staying'
 
    -- Trả về booking_record_id nếu tìm thấy
    RETURN @booking_record_id;
END;
GO

-- 3.2.4.17. Hàm lấy thông tin hóa đơn dịch vụ đã dùng bằng mã phiếu đặt phòng
CREATE FUNCTION fn_GetServiceUsageByBookingId(@booking_record_id VARCHAR(20))
RETURNS TABLE
AS
RETURN
(
    SELECT
    	s.service_id,
    	s.service_name,
    	s.price,
    	SUM(sur.quantity) AS quantity,
    	SUM(sur.quantity * s.price) AS total
    FROM
    	service s
    LEFT JOIN
    	service_usage_record sur ON s.service_id = sur.service_id
    WHERE
    	sur.booking_id = @booking_record_id
    GROUP BY
    	s.service_id, s.service_name, s.price
);
GO 


-- 3.2.4.18. Hàm lấy hóa đơn phòng theo mã phiếu đặt phòng.
CREATE OR ALTER FUNCTION fn_GetRoomBillByBookingRecordId
(
    @booking_record_id VARCHAR(20)
)
RETURNS TABLE
AS
RETURN
(
    SELECT
    	r.room_name,
    	rt.cost_per_day,
    	br.expected_check_in_time,
    	br.expected_check_out_time,
		b.total
    FROM
    	booking_record br
    JOIN
    	room r ON br.room_id = r.room_id
    JOIN
    	room_type rt ON r.room_type_id = rt.room_type_id
	JOIN 
		bill b ON br.customer_id = b.customer_id
    WHERE
    	br.booking_record_id = @booking_record_id
)
GO

-- 3.2.4.19. Hàm lấy mã hóa đơn thông qua mã khách.	
CREATE FUNCTION fn_GetBillIDByCustomerID
(
    @customer_id VARCHAR(20)
)
RETURNS table
AS
return (
    SELECT *
    FROM bill b
    WHERE b.customer_id = @customer_id
);
GO

-- 3.2.4.20. Tìm hóa đơn phòng bằng tên phòng
CREATE FUNCTION fn_GetRoomBillByRoomId
(
    @room_id VARCHAR(20)
)
RETURNS TABLE 
AS
RETURN
(
    SELECT 
        r.room_name,
        rt.cost_per_day,
        br.expected_check_in_time,
        br.expected_check_out_time,
        DATEDIFF(DAY, br.expected_check_in_time, br.expected_check_out_time) * rt.cost_per_day AS total
    FROM 
        booking_record br
    JOIN 
        room r ON br.room_id = r.room_id
    JOIN 
        room_type rt ON r.room_type_id = rt.room_type_id
    WHERE 
        r.room_id = @room_id
);
GO

-- 3.2.4.21. Hiện hóa đơn dịch vụ đã dùng bằng booking record id
CREATE FUNCTION fn_GetServiceUsageByBookingId(@booking_record_id VARCHAR(20))
RETURNS TABLE
AS
RETURN
(
    SELECT 
        s.service_id,
        s.service_name,
        s.price,
        SUM(sur.quantity) AS quantity,
        SUM(sur.quantity * s.price) AS total
    FROM 
        service s
    LEFT JOIN 
        service_usage_record sur ON s.service_id = sur.service_id
    WHERE 
        sur.booking_id = @booking_record_id
    GROUP BY 
        s.service_id, s.service_name, s.price
);
GO

-- 3.2.4.22. Hiện hóa đơn phòng theo booking_record_id
CREATE FUNCTION fn_GetRoomBillByBookingRecordId
(
    @booking_record_id VARCHAR(20)
)
RETURNS TABLE 
AS
RETURN
(
    SELECT 
        r.room_name,
        rt.cost_per_day,
        br.expected_check_in_time,
        br.expected_check_out_time,
        CASE 
            WHEN DATEDIFF(DAY, br.expected_check_in_time, br.expected_check_out_time) = 0 
            THEN 1 * rt.cost_per_day 
            ELSE DATEDIFF(DAY, br.expected_check_in_time, br.expected_check_out_time) * rt.cost_per_day 
        END AS totalPriceRoom, 
        (CASE 
            WHEN DATEDIFF(DAY, br.expected_check_in_time, br.expected_check_out_time) = 0 
            THEN 1 * rt.cost_per_day 
            ELSE DATEDIFF(DAY, br.expected_check_in_time, br.expected_check_out_time) * rt.cost_per_day 
        END + ISNULL(SUM(sur.quantity * s.price), 0)) AS total
    FROM 
        booking_record br
    JOIN 
        room r ON br.room_id = r.room_id
    JOIN 
        room_type rt ON r.room_type_id = rt.room_type_id
    LEFT JOIN 
        service_usage_record sur ON br.booking_record_id = sur.booking_id
    LEFT JOIN 
        service s ON sur.service_id = s.service_id
    WHERE 
        br.booking_record_id = @booking_record_id
    GROUP BY
        r.room_name,
        rt.cost_per_day,
        br.expected_check_in_time,
        br.expected_check_out_time
);
GO
-- 3.2.4.23. Tính tổng tiền dịch vụ
CREATE FUNCTION fn_GetTotalServiceCost
(
    @booking_id VARCHAR(20)
)
RETURNS INT 
AS
BEGIN
    DECLARE @totalCost INT;

    SELECT @totalCost = SUM(quantity * price) 
    FROM fn_GetServiceUsageByBookingId(@booking_id);

    RETURN ISNULL(@totalCost, 0);
END;
GO

-- 3.2.4.24. Kiểm tra khách hàng đã đủ điều kiện để giảm giá
CREATE OR ALTER FUNCTION fn_CheckLoyaltyDiscount(@identification_number VARCHAR(20))
RETURNS BIT
AS
BEGIN
    DECLARE @is_eligible BIT = 0;
    
    IF EXISTS (SELECT 1 
               FROM vw_LoyalCustomerHistory 
               WHERE identification_number = @identification_number AND 
                     (total_stays >= 10 AND total_spent >= 20000))
    BEGIN
        SET @is_eligible = 1;
    END
    
    RETURN @is_eligible;
END;
GO