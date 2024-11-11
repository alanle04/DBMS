

use hotel_management

-- Bảng room_type
INSERT INTO room_type (room_type_id, room_type_name, number_of_bed, capacity, cost_per_day, manager_id) VALUES
('RT001', 'Single Room', 1, 1, 100, '1'),
('RT002', 'Double Room', 2, 2, 200, '1');

-- Bảng room
INSERT INTO room (room_id, room_name, status, room_type_id, manager_id) VALUES
('R001', 'Room 101', 'available', 'RT001', '1'),
('R002', 'Room 102', 'occupied', 'RT002', '1'),
('R003', 'Room 103', 'available', 'RT002', '1'),
('R004', 'Room 104', 'available', 'RT002', '1');

-- Bảng customer
INSERT INTO customer (customer_id, full_name, gender, phone_number, identification_number, nationality, address) VALUES
('C001', 'Alice Brown', 'female', '123456789', 'ID12345', 'USA', '789 Boulevard'),
('C002', 'Bob White', 'male', '987654321', 'ID67890', 'Canada', '101 Circle');

-- Bảng booking_record
INSERT INTO booking_record (booking_record_id, booking_time, status, expected_check_in_time, expected_check_out_time, receptionist_id, customer_id, room_id) VALUES
('BR001', '2024-11-08 14:00:00', 'paid', '2024-11-08 14:00:00', '2024-11-10 12:00:00', '2', 'C001', 'R001'),
('BR002','2024-10-08 14:00:00', 'paid', '2024-10-08 14:00:00', '2024-10-10 12:00:00', '2', 'C002', 'R002');

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
('RT006', 'Triple Room', 1, 1, 150, '1');

-- Bảng room
INSERT INTO room (room_id, room_name, status, room_type_id, manager_id) VALUES
('R005', 'Room 301', 'available', 'RT005', '1'),
('R006', 'Room 601', 'available', 'RT005', '1');

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
('B004', 300, 80, 0, NULL, 380, '2024-10-22 09:00:00', 'Cash', '2', 'C004'),
('B005', 500, 100, 50, N'Trả phòng muộn', 650, '2024-10-30 11:30:00', 'Debit Card', '2', 'C001'),
('B014', 400, 120, 20, N'Nhận phòng sớm', 540, '2024-11-06 09:30:00', 'Cash', '2', 'C001'),
('B015', 500, 150, 50, N'Dịch vụ VIP', 700, '2024-11-07 17:45:00', 'Debit Card', '2', 'C006'),
('B016', 350, 90, 25, N'Mùa cao điểm', 465, '2024-11-08 13:15:00', 'Credit Card', '2', 'C005'),
('B017', 450, 110, 0, NULL, 560, '2024-11-09 11:00:00', 'Cash', '2', 'C004'),
('B018', 300, 80, 30, N'Toilet hư', 410, '2024-11-10 10:20:00', 'Credit Card', '2', 'C003'),
('B019', 550, 160, 0, NULL, 710, '2024-11-11 12:45:00', 'Debit Card', '2', 'C001'),
('B020', 600, 140, 25, N'Trả phòng muộn', 765, '2023-11-12 16:50:00', 'Cash', '2', 'C006'),
('B021', 450, 90, 20, N'Dịch vụ giặt là', 560, '2023-11-13 08:00:00', N'Credit Card', '2', 'C002'),
('B022', 700, 120, 30, N'Phí đêm muộn', 850, '2023-11-14 10:15:00', N'Cash', '2', 'C003'),
('B023', 300, 75, 0, NULL, 375, '2023-11-15 12:30:00', N'Debit Card', '2', 'C001'),
('B024', 200, 60, 15, N'Yêu cầu đặc biệt', 275, '2024-10-16 14:45:00', N'Credit Card', '2', 'C004'),
('B025', 500, 110, 0, NULL, 610, '2024-9-17 09:00:00', N'Cash', '2', 'C006'),
('B026', 400, 85, 25, N'Dọn dẹp đặc biệt', 510, '2024-8-18 17:30:00', N'Credit Card', '2', 'C005'),
('B027', 650, 130, 10, N'Dịch vụ VIP', 790, '2024-9-19 13:20:00', N'Debit Card', '2', 'C003'),
('B028', 350, 70, 20, N'Phí đêm muộn', 440, '2024-7-20 15:40:00', N'Cash', '2', 'C001'),
('B029', 300, 80, 0, NULL, 380, '2024-10-21 11:30:00', N'Credit Card', '2', 'C002'),
('B030', 600, 140, 35, N'Dịch vụ spa', 775, '2024-10-22 18:25:00', N'Cash', '2', 'C006'),
('B031', 550, 120, 0, NULL, 670, '2024-9-23 16:15:00', N'Debit Card', '2', 'C004'),
('B032', 500, 100, 15, N'Dọn dẹp đặc biệt', 615, '2024-8-24 09:10:00', N'Credit Card', '2', 'C005'),
('B033', 700, 150, 0, NULL, 850, '2024-10-25 10:50:00', N'Cash', '2', 'C003'),
('B034', 450, 85, 10, N'Phí đêm muộn', 545, '2024-10-26 12:35:00', N'Debit Card', '2', 'C001'),
('B035', 350, 60, 25, N'Dịch vụ giặt là', 435, '2024-11-5 14:20:00', N'Credit Card', '2', 'C002'),
('B036', 600, 130, 40, N'Yêu cầu đặc biệt', 770, '2024-11-1 19:45:00', N'Cash', '2', 'C006'),
('B037', 300, 75, 0, NULL, 375, '2024-11-3 17:00:00', N'Debit Card', '2', 'C004'),
('B038', 650, 120, 20, N'Dịch vụ spa', 790, '2024-11-8 13:30:00', N'Credit Card', '2', 'C005'),
('B039', 400, 90, 10, N'Dịch vụ giặt là', 500, '2024-11-01 11:55:00', N'Cash', '2', 'C003'),
('B040', 700, 150, 0, NULL, 850, '2024-11-02 08:45:00', N'Debit Card', '2', 'C001'),
('B041', 500, 110, 25, N'Phí đêm muộn', 635, '2024-11-03 15:20:00', N'Credit Card', '2', 'C002'),
('B042', 450, 95, 0, NULL, 545, '2024-11-04 10:15:00', N'Cash', '2', 'C006'),
('B043', 550, 130, 20, N'Dịch vụ VIP', 700, '2024-11-05 12:30:00', N'Debit Card', '2', 'C004'),
('B044', 600, 120, 10, N'Dịch vụ giặt là', 730, '2024-11-06 14:05:00', N'Credit Card', '2', 'C005'),
('B045', 300, 70, 15, N'Phí đêm muộn', 385, '2024-11-07 09:50:00', N'Cash', '2', 'C003'),
('B046', 500, 115, 0, NULL, 615, '2024-11-08 16:45:00', N'Debit Card', '2', 'C001'),
('B047', 450, 90, 20, N'Yêu cầu đặc biệt', 560, '2024-10-09 13:10:00', N'Credit Card', '2', 'C002'),
('B048', 700, 140, 30, N'Dịch vụ spa', 870, '2024-11-10 18:30:00', N'Cash', '2', 'C006'),
('B049', 550, 125, 10, N'Phí đêm muộn', 685, '2024-11-11 11:00:00', N'Debit Card', '2', 'C004'),
('B050', 600, 130, 0, NULL, 730, '2024-10-12 08:20:00', N'Credit Card', '2', 'C005');
