

use hotel_management

-- Bảng room_type
INSERT INTO room_type (room_type_id, room_type_name, number_of_bed, capacity, cost_per_day, manager_id) VALUES
('RT001', 'Single Room', 1, 1, 100, '1'),
('RT002', 'Double Room', 2, 2, 200, '1');

-- Bảng room
INSERT INTO room (room_id, room_name, status, room_type_id, manager_id) VALUES
('R001', 'Room 101', 'available', 'RT001', '1'),
('R002', 'Room 102', 'occupied', 'RT002', '1');



-- Bảng customer
INSERT INTO customer (customer_id, full_name, gender, phone_number, identification_number, nationality, address) VALUES
('C001', 'Alice Brown', 'female', '123456789', 'ID12345', 'USA', '789 Boulevard'),
('C002', 'Bob White', 'male', '987654321', 'ID67890', 'Canada', '101 Circle');

-- Bảng booking_record
INSERT INTO booking_record (booking_record_id, booking_time, status, expected_check_in_time, expected_check_out_time, receptionist_id, customer_id, room_id) VALUES
('BR001', GETDATE(), 'paid', '2024-11-08 14:00:00', '2024-11-10 12:00:00', '2', 'C001', 'R001');



-- Bảng room
INSERT INTO room (room_id, room_name, status, room_type_id, manager_id) VALUES
('R003', 'Room 201', 'available', 'RT003', '1'),
('R004', 'Room 202', 'occupied', 'RT004', '1');

-- Bảng service
INSERT INTO service (service_id, service_name, price, description, manager_id) VALUES
('SV003', 'Spa', 150, 'Spa services', '1'),
('SV004', 'Minibar', 80, 'In-room minibar', '1');

-- Bảng customer
INSERT INTO customer (customer_id, full_name, gender, phone_number, identification_number, nationality, address) VALUES
('C003', 'Chris Green', 'male', '456123789', 'ID54321', 'UK', '999 North Ave'),
('C004', 'Natalie Blue', 'female', '789123456', 'ID67891', 'France', '555 Elm St');

-- Bảng booking_record
INSERT INTO booking_record (booking_record_id, booking_time, status, expected_check_in_time, expected_check_out_time, receptionist_id, customer_id, room_id) VALUES
('BR003', '2024-10-25 10:00:00', 'deposited', '2024-10-25 15:00:00', '2024-10-28 12:00:00', '2', 'C003', 'R003'),
('BR004', '2024-10-20 11:00:00', 'paid', '2024-10-20 13:00:00', '2024-10-22 12:00:00', '2', 'C004', 'R004');

-- Bảng service_usage_record
INSERT INTO service_usage_record (service_usage_id, usage_time, quantity, booking_id, receptionist_id, service_id) VALUES
('SU003', '2024-10-25 16:00:00', 1, 'BR003', '2', 'SV003'),
('SU004', '2024-10-21 14:00:00', 2, 'BR004', '2', 'SV004');


-- Bảng room_type
INSERT INTO room_type (room_type_id, room_type_name, number_of_bed, capacity, cost_per_day, manager_id) VALUES
('RT005', 'Presidential Suite', 4, 6, 1000, '1'),
('RT006', 'Single Room', 1, 1, 150, '1');

-- Bảng room
INSERT INTO room (room_id, room_name, status, room_type_id, manager_id) VALUES
('R005', 'Room 301', 'available', 'RT005', '1');


-- Bảng service
INSERT INTO service (service_id, service_name, price, description, manager_id) VALUES
('SV005', 'Room Service', 50, '24-hour room service', '1'),
('SV006', 'Gym Access', 30, 'Full gym access', '1');

-- Bảng customer
INSERT INTO customer (customer_id, full_name, gender, phone_number, identification_number, nationality, address) VALUES
('C005', 'Lucy White', 'female', '852963741', 'ID33333', 'Canada', '666 Maple Dr'),
('C006', 'James Black', 'male', '456789123', 'ID44444', 'Australia', '777 Cherry St');

-- Bảng booking_record
INSERT INTO booking_record (booking_record_id, booking_time, status, expected_check_in_time, expected_check_out_time, receptionist_id, customer_id, room_id) VALUES
('BR005', '2024-10-28 14:00:00', 'staying', '2024-10-28 15:00:00', '2024-11-01 12:00:00', '2', 'C005', 'R005'),
('BR006', '2024-10-29 12:30:00', 'deposited', '2024-10-29 13:00:00', '2024-11-02 12:00:00', '2', 'C006', 'R006');

-- Bảng service_usage_record
INSERT INTO service_usage_record (service_usage_id, usage_time, quantity, booking_id, receptionist_id, service_id) VALUES
('SU005', '2024-10-29 15:30:00', 2, 'BR005', '2', 'SV005'),
('SU006', '2024-10-30 10:00:00', 1, 'BR006', '2', 'SV006');


-- Bảng bill với các giá trị created_at khác nhau
INSERT INTO bill (bill_id, room_fee, service_fee, additional_fee, additional_fee_content, total, created_at, payment_method, receptionist_id, customer_id) VALUES
('B004', 300, 80, 0, NULL, 380, '2024-10-22 09:00:00', 'Cash', 'S003', 'C004'),
('B005', 500, 100, 50, 'Trả phòng muộn', 650, '2024-10-30 11:30:00', 'Debit Card', '2', 'C001'),
('B006', 200, 50, 20, 'Món đồ hư hỏng', 270, '2024-11-02 08:45:00', 'Credit Card', '2', 'C002'),
('B007', 400, 120, 0, NULL, 520, '2024-11-05 13:15:00', 'Cash', '2', 'C004');

-- Bảng bill với các giá trị created_at khác nhau
INSERT INTO bill (bill_id, room_fee, service_fee, additional_fee, additional_fee_content, total, created_at, payment_method, receptionist_id, customer_id) VALUES
('B009', 1000, 100, 50, 'Yêu cầu đặc biệt', 1150, '2024-11-01 16:45:00', 'Cash', '2', 'C006'),
('B010', 150, 50, 10, 'Phí đêm muộn', 210, '2024-11-02 20:10:00', 'Debit Card', '2', 'C005'),
('B011', 300, 70, 0, NULL, 370, '2024-11-03 12:00:00', 'Credit Card', '2', 'C004'),
('B012', 600, 90, 25, 'Dọn dẹp đặc biệt', 715, '2024-11-04 10:30:00', 'Cash', 'S006', 'C003');

-- Bảng bill với các giá trị created_at khác nhau
INSERT INTO bill (bill_id, room_fee, service_fee, additional_fee, additional_fee_content, total, created_at, payment_method, receptionist_id, customer_id) VALUES

('B014', 400, 120, 20, 'Nhận phòng sớm', 540, '2024-11-06 09:30:00', 'Cash', '2', 'C001'),
('B015', 500, 150, 50, 'Dịch vụ VIP', 700, '2024-11-07 17:45:00', 'Debit Card', '2', 'C006'),
('B016', 350, 90, 25, 'Mùa cao điểm', 465, '2024-11-08 13:15:00', 'Credit Card', '2', 'C005'),
('B017', 450, 110, 0, NULL, 560, '2024-11-09 11:00:00', 'Cash', '2', 'C004'),
('B018', 300, 80, 30, 'Món đồ hư hỏng', 410, '2024-11-10 10:20:00', 'Credit Card', '2', 'C003'),
('B019', 550, 160, 0, NULL, 710, '2024-11-11 12:45:00', 'Debit Card', '2', 'C001'),
('B020', 600, 140, 25, 'Trả phòng muộn', 765, '2024-11-12 16:50:00', 'Cash', '2', 'C006');

