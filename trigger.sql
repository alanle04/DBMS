use hotel_management;

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
CREATE TRIGGER trg_PreventDoubleBooking
ON booking_record
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
          	SELECT 1
          	FROM booking_record br
          	INNER JOIN inserted i ON br.room_id = i.room_id
          	WHERE
          	br.booking_record_id <> i.booking_record_id
          	AND
                 	((i.expected_check_in_time BETWEEN br.expected_check_in_time AND br.expected_check_out_time)
                 	OR
                 	(i.expected_check_out_time BETWEEN br.expected_check_in_time AND br.expected_check_out_time)
        	OR
                 	(i.expected_check_in_time <= br.expected_check_in_time AND i.expected_check_out_time >= br.expected_check_out_time))
    )
   	BEGIN
   	RAISERROR ('Phòng đang có người ở !', 16, 1);
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
        	WHEN CAST(i.actual_check_in_time AS TIME) < 
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

-- 2.6.6. Trigger cập nhật chi phí khách hàng check out trễ vào hóa đơn
CREATE TRIGGER trg_OverCheckOut
ON bill
AFTER INSERT, UPDATE
AS
BEGIN
    -- Chỉ thực thi nếu tồn tại bản ghi trong Inserted
    IF EXISTS (SELECT 1 FROM Inserted)
    BEGIN
    	-- Cập nhật hóa đơn với phí bổ sung dựa trên thời gian checkout
    	UPDATE b
    	SET
        	b.additional_fee = CASE
            	-- 30% phụ phí nếu checkout giữa 12:00 và 15:00
            	WHEN CAST(i.created_at AS TIME) BETWEEN '12:00' AND '15:00' THEN i.room_fee * 0.30
            	-- 50% phụ phí nếu checkout giữa 15:00 và 18:00
            	WHEN CAST(i.created_at AS TIME) BETWEEN '15:00' AND '18:00' THEN i.room_fee * 0.50
            	-- 100% phụ phí nếu checkout sau 18:00
            	WHEN CAST(i.created_at AS TIME) > '18:00' THEN i.room_fee * 1.00
            	ELSE 0 -- Không có phụ phí nếu checkout trước 12:00
        	END,
        	-- Cập nhật tổng phí bao gồm phụ phí
        	b.total = i.room_fee + i.service_fee + CASE
            	WHEN CAST(i.created_at AS TIME) BETWEEN '12:00' AND '15:00' THEN i.room_fee * 0.30
            	WHEN CAST(i.created_at AS TIME) BETWEEN '15:00' AND '18:00' THEN i.room_fee * 0.50
            	WHEN CAST(i.created_at AS TIME) > '18:00' THEN i.room_fee * 1.00
            	ELSE 0
        	END
    	FROM bill b
    	INNER JOIN Inserted i ON b.bill_id = i.bill_id;
    END
END;
GO

--2.6.7. Trigger tạo hóa đơn khi phiếu đặt phòng (booking_record) được tạo
CREATE TRIGGER trg_CreateBill
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
    	@days_stayed INT;
 
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
   	
 
   	INSERT INTO bill (customer_id, receptionist_id,created_at,  room_fee, service_fee, additional_fee, total)
   	VALUES (@cus, @staff, NULL, @room_fee, NULL, NULL, @room_fee * @days_stayed);
END;
GO

--2.6.8. Trigger kiểm tra phòng đang được đặt bởi khách hàng thì không thể xóa.
CREATE TRIGGER trg_PreventRoomDeletion
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
       RAISERROR('Không thể xóa phòng nay !', 16, 1);
    END
    ELSE
    BEGIN
       DELETE FROM room WHERE room_id = @room_id;
    END
END;
GO

--2.6.9. Trigger kiểm tra khi thêm loại phòng, mã loại phòng, tên loại phòng không được trùng.
CREATE TRIGGER trg_CheckRoomType
ON room_type
INSTEAD OF INSERT
AS
BEGIN
     IF EXISTS (SELECT 1 FROM room_type WHERE room_type_id IN (SELECT room_type_id FROM inserted))
    BEGIN
       RAISERROR('Mã loại phòng đã tồn tại', 16, 1);
       RETURN;
    END

    IF EXISTS (SELECT 1 FROM room_type WHERE room_type_name IN (SELECT room_type_name FROM inserted))
    BEGIN
       RAISERROR('Tên loại phòng đã tồn tại', 16, 1);
       RETURN;
    END
  
    INSERT INTO room_type (room_type_id, room_type_name, number_of_bed, capacity, cost_per_day, manager_id)
 SELECT room_type_id, room_type_name, number_of_bed, capacity, cost_per_day, manager_id
    FROM inserted;
END;
GO

---2.6.10. Trigger kiểm tra khi thêm dịch vụ, mã dịch vụ, tên dịch vụ không được trùng.
CREATE TRIGGER trg_CheckService
ON service
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
    	SELECT 1
    	FROM service s
    	JOIN inserted i ON s.service_id = i.service_id
    )
    BEGIN
    	RAISERROR('Mã dịch vụ này đã tồn tại', 16, 1);
    	RETURN;
    END
	
    IF EXISTS (
    	SELECT 1
    	FROM service s
    	JOIN inserted i ON s.service_name = i.service_name
    )
    BEGIN
    	RAISERROR('Tên dịch vụ này đã tồn tại', 16, 1);
    	RETURN;
    END
 
    INSERT INTO service (service_id, service_name, price, description, manager_id)
    SELECT service_id, service_name, price, description, manager_id
    FROM inserted;
END;
GO

--2.6.11. Trigger khi bấm xuất hóa đơn thì lấy thời gian xuất hóa đơn thiết lập giá trị actual_check_out_time bên bảng booking_record.
CREATE TRIGGER trg_UpdateCheckOutTime
ON bill
AFTER INSERT
AS
BEGIN
   	UPDATE booking_record
   	SET actual_check_out_time = created_at
   	FROM booking_record b
   	INNER JOIN inserted i ON b.customer_id = i.customer_id
   	WHERE b.customer_id = i.customer_id;
END;
