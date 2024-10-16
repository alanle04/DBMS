-- 3.2.1. Thủ tục thêm dữ liệu các bảng
-- 3.2.1.1. Bảng room_type

CREATE PROC sp_AddRoomType
    @room_type_id VARCHAR(20),
    @room_type_name NVARCHAR(50),
    @number_of_bed INT,
    @capacity INT,
    @cost_per_day INT,
    @manager_id VARCHAR(20)
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
GO;

--3.2.1.2. Bảng service

CREATE PROCEDURE sp_AddService
    @service_id VARCHAR(20),
    @service_name NVARCHAR(255),
    @price INT,
    @description TEXT,
    @manager_id VARCHAR(20)
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
GO;

--3.2.1.3. Bảng room

CREATE PROCEDURE sp_AddRoom
    @roomId VARCHAR(20),
    @manager_id VARCHAR(20),
    @room_type_id VARCHAR(20),
	@room_name VARCHAR(100)
AS
BEGIN
    BEGIN TRANSACTION;
 
    BEGIN TRY
    	INSERT INTO room (room_id, manager_id, room_type_id,room_name)
    	VALUES (@roomId, @manager_id, @room_type_id,@room_name);
    	
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
GO;


--3.2.1.4. Bảng customer
CREATE PROCEDURE sp_AddtoCustomer
    @customer_id VARCHAR(20),
    @full_name NVARCHAR(255),
    @gender VARCHAR(10),
    @identification_number VARCHAR(20),
    @phone_number VARCHAR(20),
    @nationality NVARCHAR(50),
    @address TEXT
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
GO;

--3.2.1.5. Bảng service_usage_record

CREATE PROCEDURE sp_AddServiceUsageRecord
    @service_usage_id VARCHAR(20),
    @usage_time DATETIME,
    @quantity INT,
    @booking_record_id VARCHAR(20),
    @staff_id VARCHAR(20),
    @service_id VARCHAR(20)
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
GO;

--3.2.1.6 Bảng booking _record

CREATE PROCEDURE sp_AddBookingRecord
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
GO;

--3.2.2. Thủ cập nhật dữ liệu các bảng
-- 3.2.2.1. Bảng room _type

CREATE PROCEDURE sp_UpdateRoomType
    @type_id VARCHAR(20),
    @type_name NVARCHAR(50),
    @num_bed INT,
    @capac INT,
    @cost INT,
    @manager VARCHAR(20)
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
GO;

--3.2.2.2. Bảng bill
CREATE PROCEDURE sp_UpdateBill
    @cust_id VARCHAR(20)
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
GO;

--3.2.2.3. Bảng room 

CREATE PROCEDURE sp_UpdateRoomById
    @roomId VARCHAR(20),
    @status VARCHAR(50),
    @roomTypeId VARCHAR(20),
    @managerId VARCHAR(20)
AS
BEGIN
    BEGIN TRY
    	BEGIN TRANSACTION;
    	IF EXISTS (SELECT 1 FROM room WHERE room_id = @roomId)
    	BEGIN
        	UPDATE room
        	SET
            	status = @status,
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
GO;

--3.2.2.4. Bảng service
CREATE PROCEDURE sp_UpdateService
    @service_id VARCHAR(20),
    @service_name NVARCHAR(255),
    @price INT,
    @description TEXT,
    @manager_id VARCHAR(20)
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
GO;


--3.2.3. Thủ tục xóa dữ liệu trong các bảng
-- 3.2.3.1. Bảng room_type

CREATE PROCEDURE sp_DeleteRoomType
    @type_id VARCHAR(20)
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
GO;

--3.2.3.2 Bảng room 
CREATE PROCEDURE sp_DeleteRoomById
    @roomId VARCHAR(20)
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
GO;

--3.2.3.3. Bảng service

CREATE PROCEDURE sp_DeleteService
    @service_id VARCHAR(20)
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
GO;

--3.2.3.4 Bảng service_usage_record

CREATE PROCEDURE sp_DeleteServiceUsageRecord
    @service_usage_id VARCHAR(20),
    @usage_time DATETIME
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
GO;