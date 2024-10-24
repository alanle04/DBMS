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
       RAISERROR('Thêm loại phòng thất bại !', 16, 1);
    END CATCH
END;
GO

--3.2.1.2. Bảng service
CREATE PROCEDURE sp_AddService
    @service_id VARCHAR(20),
    @service_name NVARCHAR(255),
    @price INT,
    @description NVARCHAR(MAX),
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
       RAISERROR('Thêm dịch vụ thất bại !', 16, 1);
    END CATCH
END;
GO

-- 3.2.1.3. Bảng room
CREATE PROCEDURE sp_AddRoom
    @room_id VARCHAR(20),
    @manager_id VARCHAR(20),
    @room_type_id VARCHAR(20),
   	@room_name VARCHAR(100)
AS
BEGIN
    BEGIN TRANSACTION;
 
    BEGIN TRY
       INSERT INTO room (room_id, manager_id, room_type_id,room_name)
       VALUES (@room_id, @manager_id, @room_type_id,@room_name);
      
       COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
       ROLLBACK TRANSACTION;
       RAISERROR('Thêm phòng thất bại !', 16, 1);
    END CATCH
END;
GO
	
--3.2.1.4. Bảng customer
CREATE PROCEDURE sp_AddCustomer
    @customer_id VARCHAR(20),
    @full_name NVARCHAR(255),
    @gender VARCHAR(10),
    @identification_number VARCHAR(20),
    @phone_number VARCHAR(20),
    @nationality NVARCHAR(50),
    @address NVARCHAR(MAX)
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
       RAISERROR('Thêm khách hàng thất bại', 16, 1);
    END CATCH
END;
GO

-- 3.2.1.5. Bảng service_usage_record
CREATE PROCEDURE sp_AddServiceUsageRecord
    @service_usage_id VARCHAR(20),
    @usage_time DATETIME,
    @quantity INT,
    @booking_record_id VARCHAR(20),
    @staff_id VARCHAR(20),
    @service_id VARCHAR(20)
AS
BEGIN
   	BEGIN TRANSACTION;  
    BEGIN TRY
       INSERT INTO service_usage_record
       VALUES (@service_usage_id, @usage_time, @quantity, @booking_record_id, @staff_id, @service_id);
          	COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
          	ROLLBACK TRANSACTION;
       RAISERROR ('Thêm ghi nhận sử dụng dịch vụ thất bại !', 16, 1);
    END CATCH
END;
GO

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
       RAISERROR('Đặt phòng thất bại !', 16, 1);
    END CATCH
END;
GO

--3.2.2. Thủ cập nhật dữ liệu các bảng
-- 3.2.2.1. Bảng room_type
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
       RAISERROR('Cập nhật loại phòng thất bại !', 16, 1);
    END CATCH
END;
GO

--3.2.2.2. Bảng room 
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
       RAISERROR('Cập nhật phòng thất bại !', 16, 1);
    END CATCH
END;
GO

--3.2.2.3. Bảng service
CREATE PROCEDURE sp_UpdateService
    @service_id VARCHAR(20),
    @service_name NVARCHAR(255),
    @price INT,
    @description NVARCHAR(MAX),
    @manager_id VARCHAR(20)
AS
BEGIN
    BEGIN TRY
       BEGIN TRANSACTION;
       UPDATE service
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
       RAISERROR('Cập nhật dịch vụ thất bại !', 16, 1);
    END CATCH
END;
GO
--3.2.2.4. Bảng booking_record
CREATE PROCEDURE sp_UpdateBookingRecord(@booking_record_id VARCHAR(20))
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
       RAISERROR ('Cập nhật phiếu đặt phòng thất bại !', 16, 1);
   	END CATCH
END;
GO
	
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
 
       RAISERROR('Xóa loại phòng thất bại !', 16, 1);
    END CATCH
END;
GO

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
       RAISERROR('Xóa phòng thất bại !', 16, 1);
    END CATCH
END;
GO

--3.2.3.3. Bảng service
CREATE PROCEDURE sp_DeleteServiceById
    @service_id VARCHAR(20)
AS
BEGIN
       DELETE FROM service
       WHERE service_id = @service_id;
END;
GO

--3.2.3.4 Bảng service_usage_record
CREATE PROCEDURE sp_UpdatePaymentMethod
    @bill_id VARCHAR(20),      	
    @payMethod VARCHAR(50) 
AS
BEGIN
 
    BEGIN TRANSACTION;
    BEGIN TRY
    	UPDATE bill
    	SET payment_method = @payMethod
    	WHERE bill_id = @bill_id;
    	COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
    	    	ROLLBACK TRANSACTION;
        RAISERROR('Cập nhật thất bại !', 16, 1);
    	THROW;
    END CATCH
END;
GO

-- 3.2.3.5. Thêm thời gian check out vào booking record khi trả phòng
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

-- 3.2.3.6. Sau khi thanh toán xong, cập nhật lại phiếu đặt đã thanh toán, cập nhật lại trạng thái phòng.
CREATE OR ALTER PROCEDURE sp_AfterPay 
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
        
        -- Lấy room_id của phiếu đặt
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
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
	RAISERROR('Cập nhật trạng thái phòng thất bại !', 16, 1);
        THROW;
    END CATCH
END;
GO
