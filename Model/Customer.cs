namespace HotelManagementSystem.Model {
    public class Customer {
        private string _customerId;
        private string _fullName;
        private string _gender;
        private string _identificationNumber;
        private string _phoneNumber;
        private string _nationality;
        private string _address;

        public Customer() {
        }

        public Customer(string customerId, string fullName, string gender, string identificationNumber, string phoneNumber, string nationality, string address) {
            CustomerId = customerId;
            FullName = fullName;
            Gender = gender;
            IdentificationNumber = identificationNumber;
            PhoneNumber = phoneNumber;
            Nationality = nationality;
            Address = address;
        }

        public string CustomerId { get => _customerId; set => _customerId = value; }
        public string FullName { get => _fullName; set => _fullName = value; }
        public string Gender { get => _gender; set => _gender = value; }
        public string IdentificationNumber { get => _identificationNumber; set => _identificationNumber = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Nationality { get => _nationality; set => _nationality = value; }
        public string Address { get => _address; set => _address = value; }
    }
}
