namespace HotelManagementSystem.Model {
    public class Staff {
        private string _staffId;
        private string _fullName;
        private string _gender;
        private string _phoneNumber;
        private string _address;
        private string _role;
        private string _username;
        public Staff() {
        }
        public Staff(string staffId, string fullName, string gender, string phoneNumber, string address, string role, string username) {
            StaffId = staffId;
            FullName = fullName;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Address = address;
            Role = role;
            Username = username;
        }

        public string StaffId { get => _staffId; set => _staffId = value; }
        public string FullName { get => _fullName; set => _fullName = value; }
        public string Gender { get => _gender; set => _gender = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Address { get => _address; set => _address = value; }
        public string Role { get => _role; set => _role = value; }
        public string Username { get => _username; set => _username = value; }
       
    }
}
