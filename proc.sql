use hotel_management;
go
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
	   THROW;
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
        -- Chèn dữ liệu vào bảng service
        INSERT INTO service (service_id, service_name, price, description, manager_id)
        VALUES (@service_id, @service_name, @price, @description, @manager_id);

        -- Nếu không có lỗi, commit giao dịch
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Nếu có lỗi xảy ra, rollback giao dịch
        ROLLBACK TRANSACTION;

        -- Ghi lại thông báo lỗi
        DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END;
GO


-- 3.2.1.3. Bảng room
CREATE OR ALTER PROCEDURE sp_AddRoom
    @room_id VARCHAR(20),
    @manager_id VARCHAR(20),
    @room_type_id VARCHAR(20),
    @room_name VARCHAR(100)
AS
BEGIN
    BEGIN TRANSACTION;
 
    BEGIN TRY
       INSERT INTO room (room_id, manager_id, room_type_id,room_name,[status])
       VALUES (@room_id, @manager_id, @room_type_id,@room_name,'available');
      
       COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
		Raiserror('Mã phòng bị trùng',16,1)
       ROLLBACK TRANSACTION;
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
    END CATCH
END;
GO

--3.2.1.6 Bảng booking _record
CREATE OR ALTER PROCEDURE sp_AddBookingRecord
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
	   THROW;
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
    END CATCH
END;
GO

--3.2.2.2. Bảng room 
CREATE OR ALTER PROCEDURE sp_UpdateRoomById
    @roomId VARCHAR(20),
    @roomName VARCHAR(50),
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
    END CATCH
END;
GO

--3.2.2.3. Bảng service
CREATE OR ALTER PROCEDURE sp_UpdateServiceById
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
	   DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END;
GO

--3.2.2.4. Bảng booking_record
CREATE OR ALTER PROCEDURE sp_UpdateBookingRecord(@booking_record_id VARCHAR(20))
AS
BEGIN
   	BEGIN TRY
          	BEGIN TRANSACTION;
          	UPDATE booking_record
          	SET
                 	[status] = 'staying',
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
   	END CATCH
END;
GO
-- 3.2.2.5. Thêm thời gian check out vào booking record khi trả phòng
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
        RETURN;
    END
    COMMIT TRANSACTION;
END;	
go
--3.2.2.6 Bảng bill
CREATE OR ALTER PROCEDURE sp_UpdatePaymentMethod
    @bill_id VARCHAR(20),      	
    @payMethod VARCHAR(50) 
AS
BEGIN
 
    BEGIN TRANSACTION;
    BEGIN TRY
	if @payMethod ='/' 
		Raiserror('Phương thức thanh toán chưa được điền',16,1);
	else
	begin
    	UPDATE bill
    	SET payment_method = @payMethod
    	WHERE bill_id = @bill_id;
    	COMMIT TRANSACTION;
	end
    END TRY
    BEGIN CATCH
	
    	ROLLBACK TRANSACTION;
    	THROW;
    END CATCH
END;
GO



-- 3.2.3.6. Sau khi thanh toán xong, cập nhật lại phiếu đặt đã thanh toán, cập nhật lại trạng thái phòng.
CREATE PROCEDURE sp_UpdateBookingRecord_RoomStatus
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

--3.2.3. Thủ tục xóa dữ liệu trong các bảng
-- 3.2.3.1. Bảng room_type
CREATE PROCEDURE sp_DeleteRoomTypeById
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
    END CATCH
END;
GO

--3.2.3.2 Bảng room 
CREATE OR ALTER PROCEDURE sp_DeleteRoomById
    @roomId VARCHAR(20)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM Room WHERE room_id = @roomId;

        COMMIT TRANSACTION; 
        
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO



--3.2.3.3. Bảng service
CREATE OR ALTER PROCEDURE sp_DeleteServiceById
    @service_id VARCHAR(20)
AS
BEGIN
       BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM service
        WHERE service_id = @service_id;

		DELETE FROM service_usage_record
        WHERE service_id = @service_id;
		
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW; 
    END CATCH
END;
GO
--3.2.4 login
CREATE OR ALTER PROCEDURE sp_CheckLogin (
    @username VARCHAR(50),
    @password VARCHAR(255),
    @result INT OUTPUT  -- Tham số đầu ra để trả kết quả
)
AS
BEGIN
    DECLARE @role VARCHAR(20);
    BEGIN TRY
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
    END TRY
    BEGIN CATCH
        -- Xử lý lỗi
        SET @result = -1;  -- Đặt giá trị lỗi
        RAISERROR('Đã xảy ra lỗi trong quá trình kiểm tra đăng nhập.', 16, 1);
    END CATCH
END;
GO

--- proc tính phụ thu khi khách check in sớm.
CREATE OR ALTER PROC sp_UpdateEarlyCheckInFee
(
	@booking_record_id VARCHAR(20)
)
AS
BEGIN
		BEGIN TRY
				BEGIN TRANSACTION;

				DECLARE @actual_check_in_time DATETIME;
				DECLARE @expected_check_in DATETIME;
				DECLARE @additional_fee INT = 0;
				DECLARE @additional_fee_content NVARCHAR(MAX);
				DECLARE @customer_id VARCHAR(20);
				DECLARE @room_id VARCHAR(20);

				SELECT @actual_check_in_time = actual_check_in_time,
				@expected_check_in = expected_check_in_time,
				@customer_id = customer_id,
				@room_id = room_id
				FROM booking_record
				WHERE booking_record.booking_record_id = @booking_record_id;

				IF @actual_check_in_time IS NOT NULL
				BEGIN
					DECLARE @cost_per_day INT;
					SELECT @cost_per_day = rt.cost_per_day
					FROM room r
					JOIN room_type rt ON r.room_type_id = rt.room_type_id
					WHERE r.room_id = @room_id;

					IF CONVERT(DATE, @actual_check_in_time) < CONVERT(DATE, @expected_check_in)
							
							SET @additional_fee = @cost_per_day;
					
					ELSE IF CAST(@actual_check_in_time AS time) < '7:00'

							SET @additional_fee = @cost_per_day * 0.70;

					ELSE IF CAST(@actual_check_in_time AS time) BETWEEN '7:00' AND '9:00'

							SET @additional_fee = @cost_per_day * 0.5;

					ELSE IF CAST(@actual_check_in_time AS TIME) BETWEEN '09:00' AND '11:59'
           
							SET @additional_fee = @cost_per_day * 0.30;
				END

				IF @additional_fee > 0
						BEGIN
								SET @additional_fee_content = 'Phí check in sớm.';
								UPDATE bill 
								SET 	additional_fee = COALESCE(additional_fee, 0) + @additional_fee,
										additional_fee_content = COALESCE(additional_fee_content, '') + @additional_fee_content,
										total = total + @additional_fee
								WHERE customer_id = @customer_id;
						END
				COMMIT TRANSACTION;
				END TRY
				BEGIN CATCH 
						ROLLBACK TRANSACTION;
				END CATCH
END
GO

--- proc tính phụ thu khi khách check out trễ.
CREATE OR ALTER PROC sp_UpdateOverCheckOut
(
	@booking_record_id VARCHAR(20)
)
AS
BEGIN
		BEGIN TRY
				BEGIN TRANSACTION;

				DECLARE @actual_check_out_time DATETIME;
				DECLARE @expected_check_out DATETIME;
				DECLARE @additional_fee INT = 0;
				DECLARE @additional_fee_content NVARCHAR(MAX);
				DECLARE @customer_id VARCHAR(20);
				DECLARE @room_id VARCHAR(20);

				SELECT @actual_check_out_time = actual_check_out_time,
				@expected_check_out = expected_check_out_time,
				@customer_id = customer_id,
				@room_id = room_id
				FROM booking_record
				WHERE booking_record.booking_record_id = @booking_record_id;

				IF @actual_check_out_time IS NOT NULL
				BEGIN
					DECLARE @cost_per_day INT;
					SELECT @cost_per_day = rt.cost_per_day
					FROM room r
					JOIN room_type rt ON r.room_type_id = rt.room_type_id
					WHERE r.room_id = @room_id;

					IF CONVERT(DATE, @actual_check_out_time) > CONVERT(DATE, @expected_check_out)
							
							SET @additional_fee = @cost_per_day;
					
					ELSE IF CAST(@actual_check_out_time AS time) > '16:00'

							SET @additional_fee = @cost_per_day * 0.70;

					ELSE IF CAST(@actual_check_out_time AS time) BETWEEN '14:00' AND '16:00'

							SET @additional_fee = @cost_per_day * 0.5;

					ELSE IF CAST(@actual_check_out_time AS TIME) BETWEEN '12:00' AND '13:59'
           
							SET @additional_fee = @cost_per_day * 0.30;
				END

				IF @additional_fee > 0
						BEGIN
								SET @additional_fee_content = 'Phí check out tre.';
								UPDATE bill 
								SET 	additional_fee = COALESCE(additional_fee, 0) + @additional_fee,
										additional_fee_content = COALESCE(additional_fee_content, '') + @additional_fee_content,
										total = total + @additional_fee
								WHERE customer_id = @customer_id;
						END
				COMMIT TRANSACTION;
				END TRY
				BEGIN CATCH 
						ROLLBACK TRANSACTION;
				END CATCH
END
