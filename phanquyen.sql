USE hotel_management;
-- Cấp quyền truy cập cơ sở dữ liệu cho các user
GRANT CONNECT TO Receptionist;
GRANT CONNECT TO Manager;

-- Tạo login cho nhân viên lễ tân và người quản lý
CREATE LOGIN dopamine WITH PASSWORD = '123';
CREATE LOGIN alan WITH PASSWORD = '123';

-- Tạo user cho nhân viên lễ tân và người quản lý
CREATE USER Receptionist FOR LOGIN dopamine;
CREATE USER Manager FOR LOGIN alan;

-- Tạo role cho receptionist và phân quyền
CREATE ROLE ReceptionistRole;
GRANT SELECT,INSERT, DELETE, REFERENCES ON dbo.customer TO ReceptionistRole;
GRANT SELECT, INSERT, DELETE, REFERENCES ON dbo.booking_record TO ReceptionistRole;
GRANT SELECT, INSERT, DELETE, REFERENCES ON dbo.service_usage_record TO ReceptionistRole;
GRANT SELECT, INSERT, REFERENCES ON dbo.bill TO ReceptionistRole;
GRANT SELECT, REFERENCES ON dbo.room TO ReceptionistRole;
GRANT SELECT, REFERENCES ON dbo.bill TO ReceptionistRole;

-- Từ chối quyền thực thi các stored procedures cho receptionist
DENY EXECUTE ON sp_AddRoom TO ReceptionistRole;
DENY EXECUTE ON sp_UpdateRoomById TO ReceptionistRole;
DENY EXECUTE ON sp_DeleteRoomById TO ReceptionistRole;
DENY EXECUTE ON sp_AddRoomType TO ReceptionistRole;
DENY EXECUTE ON sp_UpdateRoomType TO ReceptionistRole;
DENY EXECUTE ON sp_DeleteRoomTypeById TO ReceptionistRole;
DENY EXECUTE ON sp_AddService TO ReceptionistRole;
DENY EXECUTE ON sp_UpdateServiceById TO ReceptionistRole;
DENY EXECUTE ON sp_DeleteServiceById TO ReceptionistRole;
DENY EXECUTE ON sp_AdvancedRevenueAnalysis TO ReceptionistRole;
DENY EXECUTE ON sp_GetMonthlyRevenueAnalysis TO ReceptionistRole;
DENY EXECUTE ON fn_FindCustomerByName TO ReceptionistRole;
DENY EXECUTE ON fn_FindCustomer TO ReceptionistRole;
DENY EXECUTE ON fn_GetStaffIdByUsername TO ReceptionistRole;
DENY EXECUTE ON fn_GetStaffFullNameByUserName TO ReceptionistRole;
DENY EXECUTE ON fn_CalculateTotalRevenueByDate TO ReceptionistRole;
DENY EXECUTE ON fn_GetMonthlyRevenue TO ReceptionistRole;
DENY EXECUTE ON fn_TotalRevenueByQuarter TO ReceptionistRole;
DENY EXECUTE ON fn_TotalRevenueByYear TO ReceptionistRole;
DENY EXECUTE ON fn_AdvancedRevenueAnalysisService TO ReceptionistRole;
DENY EXECUTE ON fn_AdvancedRevenueAnalysisRoomType TO ReceptionistRole;
GRANT EXECUTE TO ReceptionistRole;
-- Tạo role cho manager và phân quyền
CREATE ROLE ManagerRole;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON dbo.room TO ManagerRole;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON dbo.room_type TO ManagerRole;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON dbo.service TO ManagerRole;
GRANT SELECT, REFERENCES ON dbo.customer TO ManagerRole;
GRANT SELECT, REFERENCES ON dbo.bill TO ManagerRole;

-- Từ chối quyền thực thi các stored procedures cho manager
DENY EXECUTE ON sp_AddCustomer TO ManagerRole;
DENY EXECUTE ON sp_AddServiceUsageRecord TO ManagerRole;
DENY EXECUTE ON sp_AddBookingRecord TO ManagerRole;
DENY EXECUTE ON sp_UpdateBookingRecord TO ManagerRole;
DENY EXECUTE ON sp_CheckOutRoom TO ManagerRole;
DENY EXECUTE ON sp_UpdateBookingRecord_RoomStatus TO ManagerRole;
DENY EXECUTE ON sp_UpdatePaymentMethod TO ManagerRole;
DENY EXECUTE ON fn_GetBookingRecordByRoomIdToCheckOut TO ManagerRole;
DENY EXECUTE ON fn_GetServiceUsageInfoByRoomId TO ManagerRole;
GRANT EXECUTE TO ManagerRole;
GRANT SELECT TO ManagerRole;
-- Gán user vào các role
ALTER ROLE ReceptionistRole ADD MEMBER Receptionist;
ALTER ROLE ManagerRole ADD MEMBER Manager;
