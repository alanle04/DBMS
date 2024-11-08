use hotel_management
-- Tạo login cho nhân viên lễ tân và người quản lý
CREATE LOGIN dopamine WITH PASSWORD = '123';
CREATE LOGIN alan WITH PASSWORD = '123';
-- Tạo user cho nhân viên lễ tân và người quản lý
CREATE USER Receptionist FOR LOGIN dopamine;
CREATE USER Manager FOR LOGIN alan;
-- Tạo role staff chung cho tất cả nhân viên
CREATE ROLE StaffRole;
-- Cấp quyền toàn diện cho role staff
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.room TO StaffRole;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.room_type TO StaffRole;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.service TO StaffRole;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.booking_record TO StaffRole;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.service_usage_record TO StaffRole;
GRANT SELECT ON dbo.customer TO StaffRole;
GRANT SELECT ON dbo.bill TO StaffRole;
-- Cấp quyền thực thi tất cả các stored procedures cho role staff
GRANT EXECUTE TO StaffRole;
-- Tạo role cho receptionist và phân quyền
CREATE ROLE ReceptionistRole;
GRANT SELECT, INSERT ON dbo.booking_record TO ReceptionistRole;
GRANT SELECT, INSERT ON dbo.service_usage_record TO ReceptionistRole;
GRANT SELECT ON dbo.customer TO ReceptionistRole;
GRANT SELECT ON dbo.bill TO ReceptionistRole;

-- Từ chối quyền thực thi các stored procedures liên quan đến phòng, loại phòng và dịch vụ
DENY EXECUTE ON sp_AddRoom TO ReceptionistRole;
DENY EXECUTE ON sp_UpdateRoomById TO ReceptionistRole;
DENY EXECUTE ON sp_DeleteRoomById TO ReceptionistRole;
DENY EXECUTE ON sp_AddRoomType TO ReceptionistRole;
DENY EXECUTE ON sp_UpdateRoomType TO ReceptionistRole;
DENY EXECUTE ON sp_DeleteRoomTypeById TO ReceptionistRole;
DENY EXECUTE ON sp_AddService TO ReceptionistRole;
DENY EXECUTE ON sp_UpdateServiceById TO ReceptionistRole;
DENY EXECUTE ON sp_DeleteServiceById TO ReceptionistRole;
-- Tạo role cho manager và phân quyền
CREATE ROLE ManagerRole;
-- Cấp quyền cho manager
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.room TO ManagerRole;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.room_type TO ManagerRole;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.service TO ManagerRole;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.booking_record TO ManagerRole;
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.service_usage_record TO ManagerRole;
GRANT SELECT ON dbo.customer TO ManagerRole;
GRANT SELECT ON dbo.bill TO ManagerRole;
-- Cấp quyền thực thi tất cả các stored procedures cho manager
GRANT EXECUTE TO ManagerRole;
-- Gán user vào các role
ALTER ROLE StaffRole ADD MEMBER Receptionist;
ALTER ROLE StaffRole ADD MEMBER Manager;
ALTER ROLE ReceptionistRole ADD MEMBER Receptionist;
ALTER ROLE ManagerRole ADD MEMBER Manager;

-- Thủ tục Thêm Nhân Viên
CREATE PROCEDURE sp_ThemNhanVien
    @staff_id VARCHAR(20),
    @full_name NVARCHAR(255),
    @gender VARCHAR(10),
    @phone_number VARCHAR(20),
    @address NVARCHAR(MAX),
    @role VARCHAR(50),
    @username VARCHAR(20)
AS
BEGIN
    -- Kiểm tra nếu giới tính hợp lệ
    IF @gender NOT IN ('male', 'female', 'other')
    BEGIN
        RAISERROR(N'Giới tính không hợp lệ. Chỉ chấp nhận các giá trị: male, female, other.', 16, 1);
        RETURN;
    END
    
    -- Thêm nhân viên mới vào bảng
    INSERT INTO [hotel_management].[dbo].[staff] (staff_id, full_name, gender, phone_number, address, role, username)
    VALUES (@staff_id, @full_name, @gender, @phone_number, @address, @role, @username);
END;
GO

-- Thủ tục Sửa Thông Tin Nhân Viên
CREATE PROCEDURE sp_SuaNhanVien
    @staff_id VARCHAR(20),
    @full_name NVARCHAR(255) = NULL,
    @gender VARCHAR(10) = NULL,
    @phone_number VARCHAR(20) = NULL,
    @address NVARCHAR(MAX) = NULL,
    @role VARCHAR(50) = NULL,
    @username VARCHAR(20) = NULL
AS
BEGIN
    -- Kiểm tra nếu giới tính hợp lệ
    IF @gender IS NOT NULL AND @gender NOT IN ('male', 'female', 'other')
    BEGIN
        RAISERROR(N'Giới tính không hợp lệ. Chỉ chấp nhận các giá trị: male, female, other.', 16, 1);
        RETURN;
    END

    -- Cập nhật thông tin nhân viên
    UPDATE [hotel_management].[dbo].[staff]
    SET 
        full_name = COALESCE(@full_name, full_name),
        gender = COALESCE(@gender, gender),
        phone_number = COALESCE(@phone_number, phone_number),
        address = COALESCE(@address, address),
        role = COALESCE(@role, role),
        username = COALESCE(@username, username)
    WHERE staff_id = @staff_id;
END;
GO

-- Thủ tục Xóa Nhân Viên
CREATE PROCEDURE sp_XoaNhanVien
    @staff_id VARCHAR(20)
AS
BEGIN
    -- Xóa nhân viên
    DELETE FROM [hotel_management].[dbo].[staff]
    WHERE staff_id = @staff_id;
END;
GO
