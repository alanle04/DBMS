use hotel_management;
go
--2.6.1. Trigger thêm vào trạng thái phòng (status) 'occupied' khi phiếu đặt phòng (booking) có thời gian check in thực tế (actual_check_in_time)
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
CREATE TRIGGER trg_UpdateRoomStatusDeposited
ON booking_record
AFTER INSERT, UPDATE
AS
BEGIN
      UPDATE room
	SET room.status = 'deposited'
	FROM room r
	JOIN inserted i ON r.room_id = i.room_id
	WHERE i.actual_check_in_time IS NULL;
END
GO

-- 2.6.3. Trigger kiểm tra khách hàng thuê phòng trùng với thời gian phòng được đặt trước thì không được thuê
CREATE OR ALTER TRIGGER trg_PreventDoubleBooking
ON booking_record
INSTEAD OF INSERT
AS
BEGIN
   -- Kiểm tra xem có bản ghi trùng lặp không
    IF NOT EXISTS(
        SELECT 1
        FROM booking_record br
        INNER JOIN inserted i ON br.room_id = i.room_id
		join room r on r.room_id= br.room_id
        WHERE 

            ((CAST(i.expected_check_in_time AS DATE) BETWEEN CAST(br.expected_check_in_time AS DATE) AND CAST(br.expected_check_out_time AS DATE))
            OR
            (CAST(i.expected_check_out_time AS DATE) BETWEEN CAST(br.expected_check_in_time AS DATE) AND CAST(br.expected_check_out_time AS DATE))
            
            OR
            (CAST(br.expected_check_in_time AS DATE) BETWEEN CAST(i.expected_check_in_time AS DATE) AND CAST(i.expected_check_out_time AS DATE))
            OR
            (CAST(br.expected_check_out_time AS DATE) BETWEEN CAST(i.expected_check_in_time AS DATE) AND CAST(i.expected_check_out_time AS DATE)))
			and (r.[status] != 'available'  )

    )
    BEGIN
        -- Nếu không có bản ghi trùng, cho phép thêm vào bảng booking_record
        INSERT INTO booking_record (booking_record_id, booking_time, [status], expected_check_in_time, expected_check_out_time, actual_check_in_time, actual_check_out_time,receptionist_id, customer_id,room_id)
        SELECT  booking_record_id, booking_time, [status], expected_check_in_time, expected_check_out_time, actual_check_in_time, actual_check_out_time,receptionist_id, customer_id,room_id
        FROM inserted;
    END
    ELSE
    BEGIN
        -- Nếu có bản ghi trùng, báo lỗi
        RAISERROR ('Phòng đã được đặt trước trong khoảng thời gian này!', 16, 1);
    END
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


--2.6.7. Trigger tạo hóa đơn khi phiếu đặt phòng (booking_record) được tạo
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
		@billId VARCHAR(20)
		
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
	IF @check_in = @check_out
BEGIN
    SET @days_stayed = 1;
END
	SELECT
    	@room_fee = rt.cost_per_day
	FROM
    	room_type rt
	WHERE
    	rt.room_type_id = @room_type;
	SET @billId = @staff+@cus;
	declare @total int;
	set @total = @room_fee * @days_stayed;
	INSERT INTO Bill (bill_id,customer_id, receptionist_id, created_at,  room_fee, service_fee, additional_fee, total)
	VALUES (@billId,@cus, @staff, NULL, @room_fee, 0, 0, @total);
END;
GO

--2.6.8. Trigger kiểm tra phòng đang được đặt bởi khách hàng thì không thể xóa.
CREATE TRIGGER [dbo].[trg_PreventRoomDeletion]
ON [dbo].[room]
INSTEAD OF DELETE
AS
BEGIN
    DECLARE @room_id VARCHAR(20);
    DECLARE @room_count INT;

    -- Lấy room_id từ bảng deleted
    SELECT @room_id = room_id FROM deleted;

    -- Đếm số lượng bản ghi booking_record với trạng thái không phải 'available'
    SELECT @room_count = COUNT(*)
    FROM booking_record b join room on b.room_id = room.room_id
    WHERE b.room_id = @room_id AND room.[status] != 'available';
	
    -- Kiểm tra nếu có bản ghi nào không thỏa mãn điều kiện xóa
    IF @room_count > 0
    BEGIN
       RAISERROR('Không thể xóa phòng này vì trạng thái không phải là available!', 16, 1);
    END
    ELSE
    BEGIN
       -- Xóa phòng nếu không có ràng buộc nào
       DELETE FROM room WHERE room_id = @room_id;
    END
END;
GO

--2.6.9. Trigger kiểm tra khi thêm loại phòng, mã loại phòng, tên loại phòng không được trùng.
CREATE or alter TRIGGER trg_CheckRoomType
ON room_type
INSTEAD OF INSERT
AS
BEGIN
     IF EXISTS (SELECT 1 FROM room_type WHERE room_type_id IN (SELECT room_type_id FROM inserted))
    BEGIN
       RAISERROR('Mã loại phòng đã tồn tại', 16, 1);
       
    END
	else
    IF EXISTS (SELECT 1 FROM room_type WHERE room_type_name IN (SELECT room_type_name FROM inserted))
    BEGIN
       RAISERROR('Tên loại phòng đã tồn tại', 16, 1);
       
    END
  else
    INSERT INTO room_type (room_type_id, room_type_name, number_of_bed, capacity, cost_per_day, manager_id)
 SELECT room_type_id, room_type_name, number_of_bed, capacity, cost_per_day, manager_id
    FROM inserted;
END;
GO

---2.6.10. Trigger kiểm tra khi thêm dịch vụ, mã dịch vụ, tên dịch vụ không được trùng.
CREATE OR ALTER TRIGGER trg_CheckServiceID
ON service
INSTEAD OF INSERT
AS
BEGIN
    -- Kiểm tra xem mã dịch vụ đã tồn tại
    IF EXISTS (
        SELECT 1
        FROM service s
        JOIN inserted i ON s.service_id = i.service_id
    )
    BEGIN
        RAISERROR('Mã dịch vụ này đã tồn tại', 16, 1);
        RETURN;  -- Dừng thực thi trigger
    END
	  -- Kiểm tra xem tên dịch vụ đã tồn tại
    IF EXISTS (
        SELECT 1
        FROM service s
        JOIN inserted i ON s.service_name = i.service_name
    )
    BEGIN
        RAISERROR('Tên dịch vụ này đã tồn tại', 16, 1);
        RETURN;  -- Dừng thực thi trigger
    END

    -- Chèn dữ liệu vào bảng service
    INSERT INTO service (service_id, service_name, price, description, manager_id)
    SELECT service_id, service_name, price, description, manager_id
    FROM inserted;
END;
GO
---2.6.11. Trigger kiểm tra khi thêm dịch vụ, mã dịch vụ, tên dịch vụ không được trùng.
CREATE OR ALTER TRIGGER trg_CheckServiceName
ON service
INSTEAD OF Update
AS
BEGIN
    
    -- Kiểm tra xem tên dịch vụ đã tồn tại
    IF EXISTS (
        SELECT 1
        FROM service s
        JOIN inserted i ON s.service_name = i.service_name
    )
    BEGIN
        RAISERROR('Tên dịch vụ này đã tồn tại', 16, 1);
        RETURN;  -- Dừng thực thi trigger
    END

    -- Chèn dữ liệu vào bảng service
    INSERT INTO service (service_id, service_name, price, description, manager_id)
    SELECT service_id, service_name, price, description, manager_id
    FROM inserted;
END;
GO


--2.6.12. Trigger khi bấm xuất hóa đơn thì lấy thời gian xuất hóa đơn thiết lập giá trị actual_check_out_time bên bảng booking_record.
CREATE OR ALTER TRIGGER trg_UpdateCheckOutTime
ON booking_record
AFTER INSERT,UPDATE
AS
BEGIN
   	UPDATE bill
   	SET created_at =  actual_check_out_time 
   	FROM bill b
   	INNER JOIN inserted i ON b.customer_id = i.customer_id
   	WHERE b.customer_id = i.customer_id;
END;