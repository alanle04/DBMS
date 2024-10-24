using System.ComponentModel;

namespace HotelManagementSystem.Enums {
    public enum EnumGender {
        [Description("Nam")]
        Male,

        [Description("Nữ")]
        Female,

        [Description("Khác")]
        Other,

        [Description("Không xác định")]
        Unknown
    }
}
