use master;

DROP DATABASE IF EXISTS hotel_management;

CREATE DATABASE hotel_management;
GO

USE hotel_management;

-- Tạo bảng account
CREATE TABLE account (
    username VARCHAR(20) CONSTRAINT PK_account PRIMARY KEY,
    password VARCHAR(100) NOT NULL,
    role VARCHAR(50) CHECK (role IN ('receptionist', 'manager'))
);

-- Tạo bảng staff
CREATE TABLE staff (
    staff_id VARCHAR(20) CONSTRAINT PK_staff PRIMARY KEY,
    full_name NVARCHAR(255) NOT NULL,
    gender VARCHAR(10) CHECK (gender IN ('male', 'female', 'other')),
    phone_number VARCHAR(20) NOT NULL,
    address TEXT NOT NULL,
    role VARCHAR(50) NOT NULL,
    username VARCHAR(20),
    CONSTRAINT FK_staff_account FOREIGN KEY (username) REFERENCES account(username)
);

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

-- Tạo bảng service
CREATE TABLE service (
    service_id VARCHAR(20) CONSTRAINT PK_service PRIMARY KEY,
    service_name NVARCHAR(255) NOT NULL,
    price INT CHECK (price >= 0),
    description TEXT,
    manager_id VARCHAR(20),
    CONSTRAINT FK_service_staff FOREIGN KEY (manager_id) REFERENCES staff(staff_id)
);

-- Tạo bảng customer
CREATE TABLE customer (
    customer_id VARCHAR(20) CONSTRAINT PK_customer PRIMARY KEY,
    full_name NVARCHAR(255) NOT NULL,
    gender VARCHAR(10) CHECK (gender IN ('male', 'female', 'other')),
    phone_number VARCHAR(20) NOT NULL,
    identification_number VARCHAR(20) NOT NULL,
    nationality VARCHAR(50) NOT NULL,
    address TEXT NOT NULL
);

-- Tạo bảng booking_record
CREATE TABLE booking_record (
    booking_record_id VARCHAR(20) CONSTRAINT PK_booking_record PRIMARY KEY,
    booking_time DATETIME NOT NULL,
    status VARCHAR(50) CHECK (status IN('paid', 'staying', 'deposited')),
    expected_check_in_time DATETIME NOT NULL,
    expected_check_out_time DATETIME NOT NULL,
    actual_check_in_time DATETIME,
    actual_check_out_time DATETIME,
    receptionist_id VARCHAR(20),
    customer_id VARCHAR(20),
    room_id VARCHAR(20),
    CONSTRAINT FK_booking_record_staff_id FOREIGN KEY (receptionist_id) REFERENCES staff(staff_id),
    CONSTRAINT FK_booking_record_customer_id FOREIGN KEY (customer_id) REFERENCES customer(customer_id),
    CONSTRAINT FK_booking_record_room_id FOREIGN KEY (room_id) REFERENCES room(room_id)
);

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

-- Tạo bảng bill
CREATE TABLE bill (
    bill_id VARCHAR(20) CONSTRAINT PK_bill PRIMARY KEY,
    room_fee INT CHECK (room_fee >= 0),
    service_fee INT CHECK (service_fee >= 0),
    additional_fee INT CHECK (additional_fee >= 0),
    additional_fee_content TEXT,
    total INT CHECK (total >= 0),
    created_at DATETIME NOT NULL,
    payment_method VARCHAR(50) NOT NULL,
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
insert into service values('Bar','Quầy Bar', 100, 'Bia, rượu','1')
insert into service values('GL','Giặt là', 50, '1 lần giặt','1')
insert into service values('SB','Đưa đón sân bay', 200, '1 chuyến','1')
insert into service values('AU','Ăn uống tại phòng', 100, 'compo nước + thức ăn','1')
insert into service values('DP','Dọn dẹp phòng', 0, '','1')
insert into service values('GYM','Dịch vụ phòng tập gym', 0, '','1')
insert into service values('HB','Hồ bơi', 0, '','1')
insert into service values('WF','Wifi', 0, '','1')
insert into service values('TE','Sân tennis', 0, '','1')
insert into service values('GO','Sân golf', 0, '','1')
insert into customer values('1', 'Pham Minh Trung','male','0321654','0123456897','VN','HCM')
insert into customer values('2', 'Lien Hue Tien','female','0789854','0123454561','VN','HCM')