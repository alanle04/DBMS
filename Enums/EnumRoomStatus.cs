using System.ComponentModel;

namespace HotelManagementSystem.Enums {
    public enum EnumRoomStatus {
        [Description("Trống")]
        Available,

        [Description("Đang ở")]
        Occupied,

        [Description("Đã cọc")]
        Deposited
        
    }
}
