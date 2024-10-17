namespace HotelManagementSystem.Model {
    public class Service {
        private string _serviceId;
        private string _serviceName;
        private int _price;
        private string _description;
        private string _managerId;

        public Service() {
        }

        public Service(string serviceId, string serviceName, int price, string description, string managerId) {
            ServiceId = serviceId;
            ServiceName = serviceName;
            Price = price;
            Description = description;
            ManagerId = managerId;
        }

        public string ServiceId { get => _serviceId; set => _serviceId = value; }
        public string ServiceName { get => _serviceName; set => _serviceName = value; }
        public int Price { get => _price; set => _price = value; }
        public string Description { get => _description; set => _description = value; }
        public string ManagerId { get => _managerId; set => _managerId = value; }
    }
}
