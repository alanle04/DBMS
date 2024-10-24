using System.ComponentModel;

namespace HotelManagementSystem.Enums {
    public enum EnumBookingStatus {
        [Description("Đã thanh toán")]
        PAID,

        [Description("Đang ở")]
        STAYING,

        [Description("Đã cọc")]
        DEPOSITED
    }
}
