use master;

DROP DATABASE IF EXISTS hotel_management;

CREATE DATABASE hotel_management;
GO

USE hotel_management;
GO

-- Tạo bảng account
CREATE TABLE account (
    username VARCHAR(20) CONSTRAINT PK_account PRIMARY KEY,
    password VARCHAR(100) NOT NULL,
    role VARCHAR(50) CHECK (role IN ('receptionist', 'manager'))
);
GO

-- Tạo bảng staff
CREATE TABLE staff (
    staff_id VARCHAR(20) CONSTRAINT PK_staff PRIMARY KEY,
    full_name NVARCHAR(255) NOT NULL,
    gender VARCHAR(10) CHECK (gender IN ('male', 'female', 'other')),
    phone_number VARCHAR(20) NOT NULL,
    address NVARCHAR(MAX) NOT NULL,
    role VARCHAR(50) NOT NULL,
    username VARCHAR(20),
    CONSTRAINT FK_staff_account FOREIGN KEY (username) REFERENCES account(username)
);
GO

-- Tạo bảng room_type
CREATE TABLE room_type (
    room_type_id VARCHAR(20) CONSTRAINT PK_room_type PRIMARY KEY,
    room_type_name NVARCHAR(50) NOT NULL,
    number_of_bed INT CHECK (number_of_bed > 0),
    capacity INT CHECK (capacity > 0),
    cost_per_day INT CHECK (cost_per_day >= 0),
    manager_id VARCHAR(20),
    CONSTRAINT FK_room_type_staff FOREIGN KEY (manager_id) REFERENCES staff(staff_id)
);
GO

-- Tạo bảng room
CREATE TABLE room (
    room_id VARCHAR(20) CONSTRAINT PK_room PRIMARY KEY,
    room_name VARCHAR(100) NOT NULL,
    status VARCHAR(50) NOT NULL CHECK (status IN ('available', 'occupied', 'deposited')),
    room_type_id VARCHAR(20),
    manager_id VARCHAR(20),
    CONSTRAINT FK_room_room_type_id FOREIGN KEY (room_type_id) REFERENCES room_type(room_type_id),
    CONSTRAINT FK_room_staff FOREIGN KEY (manager_id) REFERENCES staff(staff_id)
);
GO

-- Tạo bảng service
CREATE TABLE service (
    service_id VARCHAR(20) CONSTRAINT PK_service PRIMARY KEY,
    service_name NVARCHAR(255) NOT NULL,
    price INT CHECK (price >= 0),
    description NVARCHAR(MAX),
    manager_id VARCHAR(20),
    CONSTRAINT FK_service_staff FOREIGN KEY (manager_id) REFERENCES staff(staff_id)
);
GO

-- Tạo bảng customer
CREATE TABLE customer (
    customer_id VARCHAR(20) CONSTRAINT PK_customer PRIMARY KEY,
    full_name NVARCHAR(255) NOT NULL,
    gender VARCHAR(10) CHECK (gender IN ('male', 'female', 'other')),
    phone_number VARCHAR(20) NOT NULL,
    identification_number VARCHAR(20) NOT NULL,
    nationality VARCHAR(50) NOT NULL,
    address NVARCHAR(MAX) NOT NULL
);
GO

-- Tạo bảng booking_record
CREATE TABLE booking_record (
    booking_record_id VARCHAR(20) CONSTRAINT PK_booking_record PRIMARY KEY,
    booking_time DATETIME NOT NULL,
    status VARCHAR(50) CHECK (status IN('paid', 'staying', 'deposited')),
    expected_check_in_time DATETIME NOT NULL,
    expected_check_out_time DATETIME NOT NULL,
    actual_check_in_time DATETIME NULL,
    actual_check_out_time DATETIME NULL,
    receptionist_id VARCHAR(20),
    customer_id VARCHAR(20),
    room_id VARCHAR(20),
    CONSTRAINT FK_booking_record_staff_id FOREIGN KEY (receptionist_id) REFERENCES staff(staff_id),
    CONSTRAINT FK_booking_record_customer_id FOREIGN KEY (customer_id) REFERENCES customer(customer_id),
    CONSTRAINT FK_booking_record_room_id FOREIGN KEY (room_id) REFERENCES room(room_id)
);
GO

-- Tạo bảng service_usage_record
CREATE TABLE service_usage_record (
    service_usage_id VARCHAR(20),
    usage_time DATETIME NOT NULL,
    quantity INT CHECK (quantity > 0),
    booking_id VARCHAR(20),
    receptionist_id VARCHAR(20),
    service_id VARCHAR(20),
	CONSTRAINT PK_service_usage_record PRIMARY KEY (service_usage_id, usage_time),
    CONSTRAINT FK_service_usage_record_booking_id FOREIGN KEY (booking_id) REFERENCES booking_record(booking_record_id),
    CONSTRAINT FK_service_usage_record_staff_id FOREIGN KEY (receptionist_id) REFERENCES staff(staff_id),
    CONSTRAINT FK_service_usage_record_service_id FOREIGN KEY (service_id) REFERENCES service(service_id)
);
GO

-- Tạo bảng bill
CREATE TABLE bill (
    bill_id VARCHAR(20) CONSTRAINT PK_bill PRIMARY KEY,
    room_fee INT CHECK (room_fee >= 0),
    service_fee INT CHECK (service_fee >= 0),
    additional_fee INT CHECK (additional_fee >= 0),
    additional_fee_content NVARCHAR(MAX),
    total INT CHECK (total >= 0),
    created_at DATETIME NULL,
    payment_method VARCHAR(50)NULL,
    receptionist_id VARCHAR(20),
    customer_id VARCHAR(20),
    CONSTRAINT FK_bill_staff_id FOREIGN KEY (receptionist_id) REFERENCES staff(staff_id),
    CONSTRAINT FK_bill_customer_id FOREIGN KEY (customer_id) REFERENCES customer(customer_id)
);
GO


insert into account values('alan','123','manager')
insert into account values('dopamine','123','receptionist')
insert into staff values('1','Le Nhut Anh','male','0123654987','HCM','manager','alan')
insert into staff values('2','Le Tan Tru','male','0123654974','HCM','receptionist','dopamine')
insert into room_type values('STD-S','Standard-Single',1,2,900,'1')
insert into room_type values('STD-D','Standard-Double',2,2,1000,'1')
insert into room_type values('SUP-S','Superior-Single',1,2,1200,'1')
insert into room_type values('SUP-D','Superior-Double',2,3,1300,'1')
insert into room_type values('DLX-S','Deluxe-Single',1,2,1350,'1')
insert into room_type values('DLX-D','Deluxe-Double',2,4,1500,'1')
insert into room_type values('SUT-S','Suite-Single',1,3,1450,'1')
insert into room_type values('SUT-D','Suite-Double',2,6,1600,'1')
insert into room values('101','1X1','available','STD-S','1')
insert into room values('102','2X1','available','STD-S','1')
insert into room values('103','3X1','available','STD-S','1')
insert into room values('104','4X1','available','STD-S','1')
insert into room values('201','1X2','available','STD-D','1')
insert into room values('202','2X2','available','STD-D','1')
insert into room values('203','3X2','available','STD-D','1')
insert into room values('301','1X3','available','SUP-S','1')
insert into room values('302','2X3','available','SUP-D','1')
insert into room values('401','1X4','available','DLX-S','1')
insert into room values('402','2X4','available','DLX-D','1')
insert into room values('501','1X5','available','SUT-S','1')
insert into room values('502','1X5','available','SUT-D','1')
insert into service values('Bar', N'Quầy Bar', 100, N'Bia, rượu','1')
insert into service values('GL', N'Giặt là', 50, N'1 lần giặt','1')
insert into service values('SB', N'Đưa đón sân bay', 200, N'1 chuyến','1')
insert into service values('AU', N'Ăn uống tại phòng', 100, N'compo nước + thức ăn','1')
insert into service values('DP', N'Dọn dẹp phòng', 0, '','1')
insert into service values('GYM', N'Dịch vụ phòng tập gym', 0, '','1')
insert into service values('HB', N'Hồ bơi', 0, '','1')
insert into service values('WF', N'Wifi', 0, '','1')
insert into service values('TE', N'Sân tennis', 0, '','1')
insert into service values('GO', N'Sân golf', 0, '','1')
insert into customer values('1', 'Pham Minh Trung','male','0321654','0123456897','VN','HCM')
insert into customer values('2', 'Lien Hue Tien','female','0789854','0123454561','VN','HCM')
go

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
    WHERE room_type_name LIKE '%' + @ten + '%'
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

-- lay thong tin bill phong dang duoc tim
CREATE OR ALTER FUNCTION fn_getBillInfoByRoomId
(
    @roomId  VARCHAR(20)
)
RETURNS TABLE
AS
RETURN 
(
    SELECT bill.*
    FROM bill
    INNER JOIN booking_record b ON b.customer_id = bill.customer_id
    WHERE b.room_id = @roomId 
      AND b.actual_check_out_time IS NULL
      AND bill.created_at IS NULL
);
GO

-- lấy thông tin booking record của phòng đang tìm

CREATE OR ALTER FUNCTION fn_getBookingRecordByRoomIdToCheckOut
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

-- lay thong tin dich vu da dung cua phong dang tim
CREATE OR ALTER FUNCTION fn_getServiceUsageInfoByRoomId
(
    @roomId  VARCHAR(20)
)
RETURNS TABLE
AS
RETURN 
(
    SELECT s.*
    FROM service_usage_record s
	JOIN	booking_record b ON s.booking_id = b.booking_record_id
    WHERE b.room_id = @roomId AND b.actual_check_out_time IS NULL
);
GO
--3.2.4.3. Bảng room 
--Tìm kiếm theo mã phòng
CREATE PROCEDURE sp_SearchRoomById (@room_id VARCHAR(20))
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
CREATE PROCEDURE sp_SearchRoomByName (@room_name NVARCHAR(50))
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

--Tìm kiếm các phòng đã đặt của 1 khách hàng bằng CMND/CCCD
CREATE OR ALTER FUNCTION fn_GetDepositedRoomsByIdNumber(@id_number VARCHAR(20))
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
		c.identification_number = @id_number AND r.status = 'deposited'
);
GO

--3.2.4.4. Bảng customer 
-- Tìm kiếm theo tên khách hàng
CREATE FUNCTION fn_FindtoCustomer (@full_name VARCHAR(255))
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

CREATE FUNCTION fn_FindCustomerByIDNumber (
	@idNumber VARCHAR(20)
)
RETURNS TABLE
AS
RETURN
(
	SELECT *
	FROM dbo.customer
	WHERE identification_number = @idNumber
);
GO

--3.2.4.5. Bảng service 
CREATE FUNCTION fn_FindServiceById (@service_id VARCHAR(20))
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM dbo.service
    WHERE service_id = @service_id
);
GO
-- 

--3.2.4.6. Tính tổng doanh thu theo ngày (ví dụ nhập vào 1 ngày và tính tổng các hóa đơn hôm đó)
CREATE FUNCTION fn_CalculateTotalRevenueByDate(@date DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT SUM(total) AS total_revenue
    FROM bill
    WHERE CAST(created_at AS DATE) = @date
);
GO

--3.2.4.7. Tính tổng doanh thu theo tháng (ví dụ nhập vào 1 tháng và tính tổng các hóa đơn trong tháng đó)
CREATE PROCEDURE sp_CalculateMonthlyRevenue(@month INT, @year INT)
    
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
       DECLARE @totalRevenue INT;
 
       SELECT @totalRevenue = SUM(total)
       FROM Bill
       WHERE MONTH(created_at) = @month AND YEAR(created_at) = @year;
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

--3.2.4.8. Tính tổng doanh thu theo quý (ví dụ nhập vào 1 quý và tính tổng các hóa đơn trong quý đó)
CREATE FUNCTION fn_TotalRevenueByQuarter(@quarter INT, @year INT)
RETURNS TABLE
AS
RETURN
(
	SELECT SUM(total) AS total_revenue
	FROM bill
	WHERE YEAR(created_at) = @year
	AND
	(
    	(MONTH(created_at) BETWEEN 1 AND 3 AND @quarter = 1) OR
    	(MONTH(created_at) BETWEEN 4 AND 6 AND @quarter = 2) OR
    	(MONTH(created_at) BETWEEN 7 AND 9 AND @quarter = 3) OR
    	(MONTH(created_at) BETWEEN 10 AND 12 AND @quarter = 4)
	)
);
GO

--3.2.4.9. Tính tổng doanh thu theo năm (ví dụ nhập vào 1 năm và tính tổng các hóa đơn trong năm đó)
CREATE FUNCTION fn_TotalRevenueByYear(@year INT)
RETURNS TABLE
AS
RETURN
(
   	SELECT SUM(total) AS total_revenue
   	FROM bill
   	WHERE YEAR(created_at) = @year
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
Go

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
Go

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
go
--- lấy booking record id theo mã phòng
CREATE FUNCTION fn_getBookingRecordIdByRoomIdCustomerId(
    @room_id VARCHAR(20)
)
RETURNS VARCHAR(20)
AS
BEGIN
    DECLARE @booking_record_id VARCHAR(20);

    -- Lấy booking_record_id với điều kiện theo room_id, customer_id, và status
    SELECT @booking_record_id = booking_record_id
    FROM booking_record
    WHERE room_id = @room_id 

    -- Trả về booking_record_id nếu tìm thấy
    RETURN @booking_record_id;
END;
go
-- 3.2.1. Thủ tục thêm dữ liệu các bảng
-- 3.2.1.1. Bảng room_type
CREATE PROCEDURE sp_AddRoomType(
    @room_type_id VARCHAR(20),
    @room_type_name NVARCHAR(50),
    @number_of_bed INT,
    @capacity INT,
    @cost_per_day INT,
    @manager_id VARCHAR(20)
)
AS
BEGIN
    BEGIN TRANSACTION;
 
    BEGIN TRY
    	INSERT INTO room_type (room_type_id, room_type_name, number_of_bed, capacity, cost_per_day, manager_id)
    	VALUES (@room_type_id, @room_type_name, @number_of_bed, @capacity, @cost_per_day, @manager_id);
    	COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
    	ROLLBACK TRANSACTION;
    	DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
    	SELECT
        	@ErrorMessage = ERROR_MESSAGE(),
        	@ErrorSeverity = ERROR_SEVERITY(),
        	@ErrorState = ERROR_STATE();
    	RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

--3.2.1.2. Bảng service
CREATE PROCEDURE sp_AddService(
    @service_id VARCHAR(20),
    @service_name NVARCHAR(255),
    @price INT,
    @description NVARCHAR(MAX),
    @manager_id VARCHAR(20)
)
AS
BEGIN
    BEGIN TRANSACTION;
 
    BEGIN TRY

    	INSERT INTO service (service_id, service_name, price, description, manager_id)
    	VALUES (@service_id, @service_name, @price, @description, @manager_id);
 
    	COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
    	ROLLBACK TRANSACTION;
    	DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
    	SELECT
        	@ErrorMessage = ERROR_MESSAGE(),
        	@ErrorSeverity = ERROR_SEVERITY(),
        	@ErrorState = ERROR_STATE();
    	RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

--3.2.1.3. Bảng room
CREATE OR ALTER PROCEDURE sp_AddRoom(
    @roomId VARCHAR(20),
    @manager_id VARCHAR(20),
    @room_type_id VARCHAR(20),
	@room_name VARCHAR(100)
)
AS
BEGIN
    BEGIN TRANSACTION;
 
    BEGIN TRY
    	INSERT INTO room (room_id, manager_id, room_type_id,room_name,[status])
    	VALUES (@roomId, @manager_id, @room_type_id,@room_name,'available');
    	
    	COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
    	ROLLBACK TRANSACTION;
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


--3.2.1.4. Bảng customer
CREATE PROCEDURE sp_AddtoCustomer(
    @customer_id VARCHAR(20),
    @full_name NVARCHAR(255),
    @gender VARCHAR(10),
    @identification_number VARCHAR(20),
    @phone_number VARCHAR(20),
    @nationality NVARCHAR(50),
    @address NVARCHAR(50)
)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
    	INSERT INTO customer (customer_id, full_name, gender, identification_number, phone_number, nationality, address)
    	VALUES (@customer_id, @full_name, @gender, @identification_number, @phone_number, @nationality, @address);
    	COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
    	ROLLBACK TRANSACTION;
    	DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
    	SELECT
        	@ErrorMessage = ERROR_MESSAGE(),
        	@ErrorSeverity = ERROR_SEVERITY(),
        	@ErrorState = ERROR_STATE();
    	RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

--3.2.1.5. Bảng service_usage_record
CREATE PROCEDURE sp_AddServiceUsageRecord(
    @service_usage_id VARCHAR(20),
    @usage_time DATETIME,
    @quantity INT,
    @booking_record_id VARCHAR(20),
    @staff_id VARCHAR(20),
    @service_id VARCHAR(20)
)
AS
BEGIN
    BEGIN TRY
    	INSERT INTO service_usage_record
    	VALUES (@service_usage_id, @usage_time, @quantity, @booking_record_id, @staff_id, @service_id);
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

--3.2.1.6 Bảng booking _record
CREATE PROCEDURE sp_AddBookingRecord(
    @booking_record_id VARCHAR(20),
    @booking_time DATETIME,
    @status NVARCHAR(255),
    @expected_check_in_time DATETIME,
    @expected_check_out_time DATETIME,
    @actual_check_in_time DATETIME,
    @actual_check_out_time DATETIME,
    @staff_id VARCHAR(20),
    @customer_id VARCHAR(20),
    @room_id VARCHAR(20)
)
AS
BEGIN
    BEGIN TRY
    	BEGIN TRANSACTION;
    	INSERT INTO booking_record
    	VALUES (@booking_record_id, @booking_time, @status, @expected_check_in_time, @expected_check_out_time, @actual_check_in_time, @actual_check_out_time, @staff_id, @customer_id,@room_id);
    	COMMIT TRANSACTION;  
    END TRY
    BEGIN CATCH
    	ROLLBACK TRANSACTION; 
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

--3.2.2. Thủ cập nhật dữ liệu các bảng
-- 3.2.2.1. Bảng room _type
CREATE PROCEDURE sp_UpdateRoomType(
    @type_id VARCHAR(20),
    @type_name NVARCHAR(50),
    @num_bed INT,
    @capac INT,
    @cost INT,
    @manager VARCHAR(20)
)
AS
BEGIN

    BEGIN TRY
    	BEGIN TRANSACTION;
    	UPDATE room_type
    	SET room_type_name = @type_name,
        	cost_per_day = @cost,
        	manager_id = @manager,
        	number_of_bed = @num_bed,
        	capacity = @capac
   	WHERE room_type_id = @type_id;    
    	COMMIT TRANSACTION;  
    END TRY
    BEGIN CATCH
    	ROLLBACK TRANSACTION;  
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

--3.2.2.2. Bảng bill
CREATE PROCEDURE sp_UpdateBill(
    @cust_id VARCHAR(20)
)
AS
BEGIN
    BEGIN TRY
    	BEGIN TRANSACTION; 
    	DECLARE @date_gen DATETIME;
    	SET @date_gen = GETDATE();
    	UPDATE bill
    	SET created_at = @date_gen
    	WHERE customer_id = @cust_id;
    	COMMIT TRANSACTION;      END TRY
    BEGIN CATCH
    	ROLLBACK TRANSACTION;  
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

--3.2.2.3. Bảng room 
CREATE OR ALTER PROCEDURE sp_UpdateRoomById(
    @roomId VARCHAR(20),
    @roomName VARCHAR(50),
    @roomTypeId VARCHAR(20),
    @managerId VARCHAR(20)
)
AS
BEGIN
    BEGIN TRY
    	BEGIN TRANSACTION;
    	IF EXISTS (SELECT 1 FROM room WHERE room_id = @roomId)
    	BEGIN
        	UPDATE room
        	SET
            	room_name = @roomName,
            	room_type_id = @roomTypeId,
            	manager_id = @managerId
        	WHERE room_id = @roomId;
        	COMMIT TRANSACTION;
    	END
    	ELSE
    	BEGIN
        	ROLLBACK TRANSACTION;
    	END
    END TRY
    BEGIN CATCH
    	ROLLBACK TRANSACTION;
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

--3.2.2.4. Bảng service
CREATE PROCEDURE sp_UpdateService(
    @service_id VARCHAR(20),
    @service_name NVARCHAR(255),
    @price INT,
    @description NVARCHAR(50),
    @manager_id VARCHAR(20)
)
AS
BEGIN
    BEGIN TRY
    	BEGIN TRANSACTION; 
    	UPDATE dbo.[service]
    	SET
        	service_name = @service_name,
        	price = @price,
        	description = @description,
            manager_id = @manager_id
    	WHERE service_id = @service_id;
     	COMMIT TRANSACTION; 
    END TRY
    BEGIN CATCH
    	ROLLBACK TRANSACTION;  
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
use hotel_management;
go
CREATE OR ALTER PROCEDURE sp_UpdateBookingRecord(@booking_record_id VARCHAR(20))
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

		UPDATE booking_record
		SET 
			booking_record.status = 'staying',
			actual_check_in_time = GETDATE()
		WHERE booking_record.booking_record_id = @booking_record_id;

		DECLARE @room_id VARCHAR(20);
		SELECT @room_id = b.room_id
		FROM booking_record b
		WHERE b.booking_record_id = @booking_record_id;

		UPDATE room
		SET status = 'occupied'
		WHERE room_id = @room_id;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
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

--3.2.3. Thủ tục xóa dữ liệu trong các bảng
-- 3.2.3.1. Bảng room_type
CREATE PROCEDURE sp_DeleteRoomType(@type_id VARCHAR(20))
AS
BEGIN
    BEGIN TRY
    	BEGIN TRANSACTION; 
 
    	DELETE FROM room_type WHERE room_type_id = @type_id;
 
    	COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
    	ROLLBACK TRANSACTION; 

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

--3.2.3.2 Bảng room 
CREATE PROCEDURE sp_DeleteRoomById(@roomId VARCHAR(20))
AS
BEGIN

    BEGIN TRY
    	BEGIN TRANSACTION;
    	IF EXISTS (SELECT 1 FROM Room WHERE room_id = @roomId)
    	BEGIN
        	DELETE FROM booking_record WHERE room_id = @roomId;
        	DELETE FROM Room WHERE room_id = @roomId;
        	COMMIT TRANSACTION;
    	END
    	ELSE
    	BEGIN
        	ROLLBACK TRANSACTION;
    	END
    END TRY
    BEGIN CATCH
    	ROLLBACK TRANSACTION;
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

--3.2.3.3. Bảng service
CREATE PROCEDURE sp_DeleteService(@service_id VARCHAR(20))
AS
BEGIN
    BEGIN TRY
    	BEGIN TRANSACTION; 
    	DELETE FROM dbo.[service]
    	WHERE service_id = @service_id;
     	COMMIT TRANSACTION; 
    END TRY
    BEGIN CATCH
    	ROLLBACK TRANSACTION;
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

--3.2.3.4 Bảng service_usage_record
CREATE PROCEDURE sp_DeleteServiceUsageRecord(@service_usage_id VARCHAR(20), @usage_time DATETIME)
AS
BEGIN
    BEGIN TRY
    	BEGIN TRANSACTION;
    	DELETE FROM dbo.service_usage_record
    	WHERE service_usage_id = @service_usage_id
        	AND usage_time = @usage_time
    	COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
    	ROLLBACK TRANSACTION;
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

USE hotel_management;
GO

--2.6.1. Trigger thêm vào trạng thái phòng (status) 'occupied' khi phiếu đặt phòng (booking) có thời gian check in thực tế (actual_check_in_time)
/* CREATE TRIGGER trg_UpdateRoomStatusOccupied
ON booking_record
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE room
    SET room.status = 'occupied'
    FROM room r
    INNER JOIN inserted i ON r.room_id = i.room_id
    WHERE i.actual_check_in_time IS NOT NULL;
END; */
CREATE TRIGGER trg_UpdateRoomStatusOccupied
ON booking_record
AFTER UPDATE
AS
BEGIN
    -- Chỉ cập nhật trạng thái phòng khi có actual_check_in_time và trạng thái của booking là 'staying'
    IF EXISTS (
        SELECT 1 
        FROM inserted 
        WHERE actual_check_in_time IS NOT NULL AND status = 'staying'
    )
    BEGIN
        UPDATE room
        SET room.status = 'occupied'
        FROM room r
        INNER JOIN inserted i ON r.room_id = i.room_id
        WHERE i.actual_check_in_time IS NOT NULL AND i.status = 'staying';
    END
END;
GO


--2.6.2. Trigger thêm vào trạng thái phòng status 'deposited' khi phiếu đặt phòng (booking_record) chưa có thời gian check in thực tế actual_check_in_time)
CREATE OR ALTER TRIGGER trg_UpdateRoomStatusDeposited
ON booking_record
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE room
	SET room.status = 'deposited'
	FROM room r
	JOIN inserted i ON r.room_id = i.room_id
END;
GO

-- 2.6.3. Trigger kiểm tra khách hàng thuê phòng trùng với thời gian phòng được đặt trước thì không được thuê
CREATE TRIGGER trg_PreventDoubleBooking
ON booking_record
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @errorMessage NVARCHAR(255);
    IF EXISTS (
 		SELECT 1
 		FROM booking_record br
 		INNER JOIN inserted i ON br.room_id = i.room_id
 		WHERE
      		br.booking_record_id <> i.booking_record_id 
			AND ((i.expected_check_in_time BETWEEN br.expected_check_in_time AND br.expected_check_out_time) 
				OR (i.expected_check_out_time BETWEEN br.expected_check_in_time AND br.expected_check_out_time) 
				OR (i.expected_check_in_time <= br.expected_check_in_time AND i.expected_check_out_time >= br.expected_check_out_time))
    )
	BEGIN
 	SET @errorMessage = 'Phòng đã có người ở.';
 	RAISERROR (@errorMessage, 16, 1);
 	ROLLBACK TRANSACTION;
    END;
END;
GO

--2.6.4. Trigger cập nhật chi phí khách hàng check in sớm vào hóa đơn (bill)
CREATE TRIGGER trg_UpdateEarlyCheckInFee
ON booking_record
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE b
    SET
    	additional_fee = COALESCE(b.additional_fee, 0) +
        	CASE
            WHEN CAST(i.actual_check_in_time AS TIME) < '07:00'
           	THEN rt.cost_per_day  -- 100% giá phòng
          	WHEN CAST(i.actual_check_in_time AS TIME) BETWEEN '07:00' AND '09:00'
                	THEN rt.cost_per_day * 0.50  -- 50% giá phòng
            WHEN CAST(i.actual_check_in_time AS TIME) BETWEEN '09:00' AND '11:59'
                	THEN rt.cost_per_day * 0.30  -- 30% giá phòng
          	ELSE 0  -- Không thêm phí nếu check-in sau 12:00
        	END,
    	additional_fee_content =
        	CASE
            	WHEN CAST(i.actual_check_in_time AS TIME) < '12:00'
                	THEN COALESCE(CAST(b.additional_fee_content AS VARCHAR(MAX)), '') + 'Phí check in sớm.' + CHAR(10)
            	ELSE b.additional_fee_content
        	END
    FROM inserted i
    JOIN room r ON r.room_id = i.room_id
    JOIN room_type rt ON r.room_type_id = rt.room_type_id 
    JOIN bill b ON b.customer_id = i.customer_id
    WHERE i.actual_check_in_time < i.expected_check_in_time;
END;
GO

--2.6.5. Trigger cập nhật khi sử dụng dịch vụ tính thêm chi phí vào hóa đơn
CREATE TRIGGER trg_UpdateBillOnServiceUsage
ON service_usage_record
AFTER INSERT
AS
BEGIN
    DECLARE @booking_id VARCHAR(20);
    DECLARE @customer_id VARCHAR(20);
    DECLARE @bill_id VARCHAR(20);
    DECLARE @total_service_fee INT;
    SELECT @booking_id = inserted.booking_id
    FROM inserted;
    SELECT @customer_id = customer_id
    FROM booking_record
    WHERE booking_record_id = @booking_id;
 
    SELECT @bill_id = bill_id
    FROM bill
    WHERE customer_id = @customer_id;
 
    SELECT @total_service_fee = SUM(service_total)
    FROM (
    	SELECT sur.service_id, (sur.quantity * s.price) AS service_total 	
FROM service_usage_record sur
    	JOIN service s ON sur.service_id = s.service_id
    	WHERE sur.booking_id = @booking_id
    ) AS service_totals;
 
    IF @bill_id IS NOT NULL
    BEGIN
    	UPDATE bill
    	SET service_fee = @total_service_fee,
        	total = room_fee + @total_service_fee + additional_fee
    	WHERE bill_id = @bill_id;
    END
END;
GO


--2.6.7. Trigger cập nhật chi phí khách hàng check out trễ vào hóa đơn
CREATE OR ALTER TRIGGER trg_OverCheckOut
ON bill
AFTER  UPDATE
AS
BEGIN
	DECLARE @checkout_time TIME;  
	DECLARE @room_price INT;
	DECLARE @additional_fee INT;   
	SELECT @checkout_time = CAST(inserted.created_at AS TIME), @room_price = room_fee
	FROM Inserted WHERE inserted.created_at IS NOT NULL;
	SELECT @additional_fee = b.additional_fee
	FROM bill b, inserted WHERE b.bill_id = inserted.bill_id;
	IF @checkout_time BETWEEN '12:00' AND '15:00'
	BEGIN
    	SET @additional_fee = @additional_fee + @room_price * 0.30;
	END
	ELSE IF @checkout_time BETWEEN '15:00' AND '18:00'
	BEGIN
    	SET @additional_fee = @additional_fee + @room_price * 0.50; 
	END
	ELSE IF @checkout_time > '18:00'
	BEGIN
    	SET @additional_fee = @additional_fee + @room_price * 1.00; 
	END
	UPDATE bill
	SET  additional_fee = @additional_fee, total = room_fee + service_fee + @additional_fee	WHERE customer_id IN (SELECT customer_id FROM Inserted);
END;
GO

--2.6.8. Trigger tạo hóa đơn khi phiếu đặt phòng (booking_record) được tạo
CREATE OR ALTER TRIGGER trg_CreateBill
ON booking_record
AFTER INSERT
AS
BEGIN
	DECLARE
    	@cus VARCHAR(20),
    	@staff VARCHAR(20),
    	@room_type VARCHAR(20),
    	@room_fee INT,
		@check_in DATE,
        @check_out DATE,
        @days_stayed INT,
		@billId VARCHAR(20),
		@substr VARCHAR(20); 
		
	SELECT
    	@cus = i.customer_id,
    	@staff = i.receptionist_id,
    	@room_type = r.room_type_id,
		@check_in = i.expected_check_in_time,
        @check_out = i.expected_check_out_time
	FROM
    	inserted i
    	JOIN room r ON i.room_id = r.room_id;

	-- Tính số ngày ở
    SET @days_stayed = DATEDIFF(DAY, @check_in, @check_out);
		-- Lấy chi phí mỗi ngày cho loại phòng
	SELECT
    	@room_fee = rt.cost_per_day
	FROM
    	room_type rt
	WHERE
    	rt.room_type_id = @room_type;
	SET @substr = SUBSTRING(CONVERT(VARCHAR(36), NEWID()), 1, 3);
	SET @billId = @staff+@cus;
	declare @total int;
	set @total = @room_fee * @days_stayed;
	INSERT INTO Bill (bill_id,customer_id, receptionist_id, created_at,  room_fee, service_fee, additional_fee, total)
	VALUES (@billId,@cus, @staff, NULL, @room_fee, 0, 0, @total);
END;
GO


--2.6.9. Trigger kiểm tra phòng đang được đặt bởi khách hàng thì không thể xóa.
CREATE OR ALTER TRIGGER trg_PreventRoomDeletion
ON room
INSTEAD OF DELETE
AS
BEGIN
    DECLARE @room_id VARCHAR(20);
    DECLARE @room_count INT;
 
    SELECT @room_id = room_id FROM deleted;
 
    SELECT @room_count = COUNT(*)
    FROM booking_record
    WHERE room_id = @room_id AND status !=  'available';
 
    IF @room_count > 0
    BEGIN
    	RAISERROR('Không thể xóa phòng này.', 16, 1);
    END
    ELSE
    BEGIN
    	DELETE FROM room WHERE room_id = @room_id;
    END
END;
GO

--2.6.10. Trigger kiểm tra khi thêm loại phòng, tên loại phòng không được trùng.
CREATE OR ALTER TRIGGER trg_CheckRoomTypeName
ON room_type
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM room_type WHERE room_type_name IN (SELECT room_type_name FROM inserted))
    BEGIN
    	RAISERROR('Tên loại phòng này đã tồn tại.', 16, 1);
    	RETURN;
    END
   
    INSERT INTO room_type (room_type_id, room_type_name, number_of_bed, capacity, cost_per_day, manager_id)
 SELECT room_type_id, room_type_name, number_of_bed, capacity, cost_per_day, manager_id
    FROM inserted;
END;
GO

--2.6.11. Trigger kiểm tra khi thêm dịch vụ, mã dịch vụ, tên dịch vụ không được trùng.
CREATE OR ALTER TRIGGER trg_CheckService
ON service
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM service s
        JOIN inserted i ON s.service_name = i.service_name
    )
    BEGIN
        RAISERROR('Tên dịch vụ này đã tồn tại', 16, 1);
        RETURN;
    END

    IF EXISTS (
        SELECT 1 
        FROM service s
        JOIN inserted i ON s.service_id = i.service_id
    )
    BEGIN
        RAISERROR('Mã dịch vụ này đã tồn tại', 16, 1);
        RETURN;
    END

    INSERT INTO service (service_id, service_name, price, description, manager_id)
    SELECT service_id, service_name, price, description, manager_id
    FROM inserted;
END;
GO

use hotel_management;
go
--2.6.13. Trigger khi bấm xuất hóa đơn thì lấy thời gian xuất hóa đơn thiết lập giá trị actual_check_out_time bên bảng booking_record.
CREATE OR ALTER TRIGGER trg_UpdateCheckOutTime
ON booking_record
AFTER UPDATE
AS
BEGIN
	DECLARE @cusid VARCHAR(20);
	DECLARE @TIME DATETIME;
	SELECT @cusid = customer_id,
				@TIME = actual_check_out_time
	FROM inserted;

	UPDATE bill
	SET created_at = @TIME
	WHERE customer_id =@cusid;
END;
GO

-- Các view
CREATE OR ALTER VIEW vw_Service AS
SELECT service_id, service_name, price, description, full_name as manager_name
FROM service
INNER JOIN staff
ON service.manager_id = staff.staff_id;
GO
CREATE OR ALTER VIEW vw_Room AS
SELECT
    r.room_id,
    r.room_name,
    r.status,
    rt.room_type_name,
    rt.number_of_bed,
    rt.capacity,
    rt.cost_per_day,
    s.full_name AS manager_name
FROM
    room r
JOIN
    room_type rt ON r.room_type_id = rt.room_type_id
LEFT JOIN
	staff s ON r.manager_id = s.staff_id;
GO

CREATE OR ALTER VIEW vw_RoomType AS
SELECT room_type_id, room_type_name, number_of_bed, capacity, cost_per_day, full_name as manager
FROM room_type
INNER JOIN staff
ON manager_id = staff.staff_id;
GO
CREATE OR ALTER VIEW vw_AvailableRooms AS
SELECT
    r.room_id,
    r.room_name,
    r.status,
    rt.room_type_name,
    rt.number_of_bed,
    rt.capacity,
    rt.cost_per_day,
    s.full_name AS manager_name
FROM
    room r
JOIN
    room_type rt ON r.room_type_id = rt.room_type_id
LEFT JOIN
    staff s ON r.manager_id = s.staff_id
WHERE
	r.status = 'available';
GO
CREATE OR ALTER VIEW vw_BillDetails AS
SELECT
    b.bill_id,
    b.room_fee,
    b.service_fee,
    b.additional_fee,
    b.additional_fee_content,
    b.total,
    b.created_at,
    b.payment_method,
    c.full_name AS customer_name,
    s.full_name AS staff_name
FROM
    bill b
LEFT JOIN
    staff s ON b.receptionist_id = s.staff_id
LEFT JOIN
	customer c ON b.customer_id = c.customer_id;
GO
CREATE OR ALTER VIEW vw_ServiceUsageDetails AS
SELECT
    sur.service_usage_id,
    sur.usage_time,
    sur.quantity,
    srv.service_name,
    srv.price AS service_price,
    srv.description AS service_description,
    c.full_name AS customer_name,
	c.phone_number AS customer_phone,
    s.full_name AS receptionist_name
FROM
    service_usage_record sur
LEFT JOIN
    booking_record br ON sur.booking_id = br.booking_record_id
LEFT JOIN
    staff s ON sur.receptionist_id = s.staff_id
LEFT JOIN
    service srv ON sur.service_id = srv.service_id
LEFT JOIN
	customer c ON br.customer_id = c.customer_id;
GO

CREATE OR ALTER VIEW vw_RoomTypeList AS
SELECT 
		rt.room_type_id AS ID,
		rt.room_type_name AS Name,
		rt.number_of_bed AS NumOfBed,
		rt.capacity,
		rt.cost_per_day AS Cost,
		COUNT(r.room_id) AS NumOfRoom,
		st.staff_id AS managerId,
		st.full_name AS managerName
FROM room_type rt
LEFT JOIN room  r ON rt.room_type_id = r.room_type_id
LEFT JOIN staff st ON rt.manager_id = st.staff_id
GROUP BY
		rt.room_type_id,
		rt.room_type_name ,
		rt.number_of_bed ,
		rt.capacity,
		rt.cost_per_day ,
		st.staff_id ,
		st.full_name
GO
		-- 2.7.1. View xem danh sách các phòng
CREATE OR ALTER VIEW vw_RoomList AS
SELECT
    r.room_id,
    r.room_name,
    r.status,
    rt.room_type_name,
    rt.number_of_bed,
    rt.capacity,
    rt.cost_per_day,
    s.full_name AS manager_name
FROM
    room r
JOIN
    room_type rt ON r.room_type_id = rt.room_type_id
LEFT JOIN
	staff s ON r.manager_id = s.staff_id;
GO

--2.7.2. View xem danh sách các phòng checkin
CREATE OR ALTER VIEW vw_CheckInRooms AS
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
    r.status = 'deposited';
GO
----2.7.6 View xem danh sách customer---
CREATE OR ALTER VIEW vw_Customer as
Select
customer_id,
full_name,
gender,
phone_number,
identification_number,
nationality,
[address]
FROM
customer

GO

-- View xem hóa đơn phòng


-- Tìm hóa đơn phòng bằng tên phòng
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

-- Hiện hóa đơn dịch vụ đã dùng bằng bookig record id
CREATE FUNCTION fn_GetServiceUsageByBookingId(@bookingRecordId VARCHAR(20))
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
        sur.booking_id = @bookingRecordId
    GROUP BY 
        s.service_id, s.service_name, s.price
);
GO
-- Hiện hóa đơn phòng theo id br

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
        DATEDIFF(DAY, br.expected_check_in_time, br.expected_check_out_time) * rt.cost_per_day AS total
    FROM 
        booking_record br
    JOIN 
        room r ON br.room_id = r.room_id
    JOIN 
        room_type rt ON r.room_type_id = rt.room_type_id
    WHERE 
        br.booking_record_id = @booking_record_id
);
GO
-- Tính tổng tiền dịch vụ
CREATE OR ALTER FUNCTION fn_GetTotalServiceCost
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
-- Thêm thời gian check out vào booking record khi trả phòng
CREATE PROCEDURE sp_CheckOutRoom
    @booking_record_id VARCHAR(20)
AS
BEGIN
    BEGIN TRANSACTION;
    UPDATE booking_record
    SET actual_check_out_time = GETDATE()
    WHERE booking_record_id = @booking_record_id;

    IF @@ROWCOUNT = 0
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR('Không tìm thấy bản ghi đặt phòng với ID đã cho.', 16, 1);
        RETURN;
    END

    COMMIT TRANSACTION;

    PRINT 'Cập nhật thời gian trả phòng thành công.';
END;
GO

-- sau khi thanh toán xong, cập nhật lại phiếu đặt đã thanh toán, cập nhật lại trạng thái phòng.
CREATE OR ALTER PROCEDURE sp_afterPay 
    @booking_record_id VARCHAR(20)
AS
BEGIN
    -- Bắt đầu một transaction
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Cập nhật trạng thái đã thanh toán cho phiếu đặt
        UPDATE booking_record
        SET status = 'paid'  -- Đã thanh toán
        WHERE booking_record_id = @booking_record_id;
        
        -- Lấy RoomID của phiếu đặt
        DECLARE @room_id VARCHAR(20);

        -- Kiểm tra nếu phiếu đặt tồn tại và có room_id
        SELECT @room_id = b.room_id
        FROM booking_record b
        WHERE b.booking_record_id = @booking_record_id;
        
        -- Kiểm tra nếu tìm được room_id
        IF @room_id IS NOT NULL
        BEGIN
            -- Cập nhật trạng thái phòng thành "Available"
            UPDATE room
            SET status = 'available'
            WHERE room_id = @room_id;
        END
        
        -- Commit transaction nếu không có lỗi
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback nếu có lỗi
        ROLLBACK TRANSACTION;
        -- In ra lỗi
        THROW;
    END CATCH
END;
GO
use hotel_management;
go
--THÊM PHƯƠNG THỨC THANH TOÁN
CREATE OR ALTER PROCEDURE sp_updatePaymentMethod
    @bill_id VARCHAR(20),          
    @payMethod VARCHAR(50)  
AS
BEGIN

    BEGIN TRANSACTION;
    
    BEGIN TRY

        UPDATE bill
        SET payment_method = @payMethod
        WHERE bill_id = @bill_id;
        
        -- Commit transaction nếu không có lỗi
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback nếu có lỗi
        ROLLBACK TRANSACTION;
        -- In ra lỗi
        THROW;
    END CATCH
END;
GO

use hotel_management;
go
-- HAM LAY MÃ BILL BẰNG MÃ KHÁCH
 CREATE OR ALTER FUNCTION fn_getBillIDByCustomerID
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


-- VIEW LAY DANH SACH MANAGER
CREATE VIEW vw_allManager
AS
SELECT * 
FROM staff
WHERE role = 'manager'
