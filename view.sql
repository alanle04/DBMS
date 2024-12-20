﻿use hotel_management;
go
-- 2.7.1. View xem danh sách các phòng
CREATE VIEW vw_RoomList AS
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

--2.7.2. View xem danh sách các phòng còn trống
CREATE VIEW vw_AvailableRooms AS
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
--2.7.3. View xem chi tiết hóa đơn
CREATE VIEW vw_BillDetails AS
SELECT
	b.bill_id,
	b.room_fee,
	b.service_fee,
	b.additional_fee,
	b.additional_fee_content,
	b.total,
	b.payment_method,
	c.full_name AS customer_name,
	s.full_name AS staff_name,
	br.room_id,
	br.expected_check_in_time,
	br.expected_check_out_time,
	br.actual_check_in_time,
	br.actual_check_out_time
FROM
	bill b
LEFT JOIN
	staff s ON b.receptionist_id = s.staff_id
LEFT JOIN
   	customer c ON b.customer_id = c.customer_id
join
	booking_record br on br.customer_id= c.customer_id
GO

--2.7.4. View xem chi tiết các dịch vụ mà khách hàng đã dùng
CREATE VIEW vw_ServiceUsageDetails AS
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

--2.7.5. View xem danh sách các loại phòng
CREATE VIEW vw_RoomTypeList AS
SELECT
   	rt.room_type_id as ID,
   	rt.room_type_name Name,
   	rt.number_of_bed AS NumOfBed,
   	rt.capacity,
   	rt.cost_per_day as Cost,
   	COUNT(r.room_id) AS NumOfRoom,
   	s.staff_id as managerId,
   	s.full_name  as managerName
FROM
   	room_type rt
left join
   	room r ON r.room_type_id = rt.room_type_id
left JOIN
   	staff s ON s.staff_id = rt.manager_id
GROUP BY
   	rt.room_type_id,
   	rt.room_type_name,
   	rt.number_of_bed,
   	rt.capacity,
   	rt.cost_per_day,
   	s.staff_id,
   	s.full_name;
GO
	
----2.7.6 View xem danh sách customer---
CREATE VIEW vw_Customer as
SELECT *
FROM customer
GO

----2.7.7. View xem danh sách service
CREATE VIEW vw_Service AS
SELECT service_id, service_name, price, description, full_name as manager_name
FROM service
INNER JOIN staff
ON service.manager_id = staff.staff_id;
GO

----2.7.8. View xem danh sách service
CREATE VIEW vw_Room 
AS
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

---2.7.9. View xem thông tin check in
CREATE VIEW vw_CheckInRooms 
AS
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

---2.7.10. View xem thông tin tất cả quản lý
CREATE VIEW vw_AllManager
AS
SELECT *
FROM staff
WHERE role = 'manager';
GO