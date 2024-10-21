
-- 3.2.4. Hàm tìm kiếm dữ liệu
-- 3.2.4.1. Bảng room_type
--Tìm kiếm theo tên

CREATE FUNCTION fn_SearchNameRoomType(@ten NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM room_type
    WHERE room_type_name = @ten
);
GO
--Tìm kiếm theo mã loại phòng
CREATE FUNCTION fn_SearchIDRoomType(@id VARCHAR(20))
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM room_type
    WHERE room_type_id = @id
);
GO

--3.2.4.2. Bảng service_usage_record
CREATE FUNCTION fn_SearchServiceUsageRecord(@id VARCHAR(20))
RETURNS TABLE
AS
RETURN
(
 	SELECT *
 	FROM service_usage_record
 	WHERE service_usage_id = @id
);
GO
--3.2.4.3. Bảng room 
--Tìm kiếm theo mã phòng
CREATE PROCEDURE sp_SearchRoomById
    @room_id VARCHAR(20)
AS
BEGIN
 
    BEGIN TRY
       IF EXISTS (SELECT 1 FROM room WHERE room_id= @room_id)
       BEGIN
    	  	SELECT
        	  room_id,
             room_name,
        	   status,
        	  room_type_id,
        	  manager_id
    	  	FROM room
    	  	WHERE room_id = @room_id;
       END
    END TRY
    BEGIN CATCH
       DECLARE @ErrorMessage NVARCHAR(4000);
       DECLARE @ErrorSeverity INT;
       DECLARE @ErrorState INT;
       SELECT
    	  	@ErrorMessage = ERROR_MESSAGE(),
    	  	@ErrorSeverity = ERROR_SEVERITY(),
    	  	@ErrorState = ERROR_STATE();
       RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

--Tìm kiếm theo tên phòng
CREATE PROCEDURE sp_SearchRoomByName
    @room_name NVARCHAR(50)
AS
BEGIN
 
    BEGIN TRY
       IF EXISTS (SELECT 1 FROM room WHERE room_name= @room_name)
       BEGIN
    	  	SELECT
        	  room_id,
                room_name,
        	   [status],
        	  room_type_id,
        	  manager_id
    	  	FROM room
    	  	WHERE room_name = @room_name;
       END
    END TRY
    BEGIN CATCH
       DECLARE @ErrorMessage NVARCHAR(4000);
       DECLARE @ErrorSeverity INT;
       DECLARE @ErrorState INT;
       SELECT
    	  	@ErrorMessage = ERROR_MESSAGE(),
    	  	@ErrorSeverity = ERROR_SEVERITY(),
    	  	@ErrorState = ERROR_STATE();
       RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO


--3.2.4.4. Bảng customer 
-- Tìm kiếm theo tên khách hàng
CREATE FUNCTION fn_FindtoCustomer (
	@full_name VARCHAR(255)
)
RETURNS TABLE
AS
RETURN
(
	SELECT *
	FROM dbo.customer
	WHERE full_name LIKE '%' + @full_name + '%'
);
GO
--Tìm kiếm theo mã khách hàng
CREATE FUNCTION fn_FindCustomer (
	@customer_id VARCHAR(20)
)
RETURNS TABLE
AS
RETURN
(
	SELECT *
	FROM dbo.customer
	WHERE customer_id = @customer_id
);
GO

--3.2.4.5. Bảng service 

CREATE FUNCTION fn_FindServiceById (
    @service_id VARCHAR(20)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM dbo.service
    WHERE service_id = @service_id
);
GO

--3.2.4.6. Tính tổng doanh thu theo ngày (ví dụ nhập vào 1 ngày và tính tổng các hóa đơn hôm đó)
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


--3.2.4.7. Tính tổng doanh thu theo tháng (ví dụ nhập vào 1 tháng và tính tổng các hóa đơn trong tháng đó)

CREATE FUNCTION fn_GetDailyRevenue
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
--3.2.4.8. Tính tổng doanh thu theo quý (ví dụ nhập vào 1 quý và tính tổng các hóa đơn trong quý đó)
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
    	MONTH(created_at) AS [month],
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

--3.2.4.9. Tính tổng doanh thu theo năm (ví dụ nhập vào 1 năm và tính tổng các hóa đơn trong năm đó)
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

--3.2.4.10. Kiểm tra login
CREATE FUNCTION fn_CheckLogin(@username VARCHAR(50), @password VARCHAR(255))
RETURNS INT
AS
BEGIN
    DECLARE @result INT;
    DECLARE @role VARCHAR(20);

    -- Kiểm tra nếu tài khoản tồn tại và lấy vai trò
    SELECT @role = role
    FROM account
    WHERE username = @username AND [password] = @password;

    IF @role IS NOT NULL
    BEGIN
        IF @role = 'manager'
        BEGIN
            SET @result = 1;  -- Quản lý
        END
        ELSE IF @role = 'receptionist'
        BEGIN
            SET @result = 0;  -- Lễ tân
        END
    END
    ELSE
    BEGIN
        SET @result = -1;  -- Tài khoản không tồn tại
    END

    RETURN @result;
END;

--3.2.4.11. Lấy ra tên staff theo username
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


--3.2.4.12. Lấy ra tên staff theo username
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
