namespace HotelManagementSystem.Model {
    public class RoomType {
        private string _roomTypeId;
        private string _roomTypeName;
        private int _numberOfBed;
        private int _capacity;
        private int _costPerDay;
        private string _managerId;
        public RoomType() { }

        public RoomType(string roomTypeId, string roomTypeName, int numberOfBed, int capacity, int costPerDay, string managerId) {
            RoomTypeId = roomTypeId;
            RoomTypeName = roomTypeName;
            NumberOfBed = numberOfBed;
            Capacity = capacity;
            CostPerDay = costPerDay;
            ManagerId = managerId;
        }
        public string RoomTypeId { get => _roomTypeId; set => _roomTypeId = value; }
        public string RoomTypeName { get => _roomTypeName; set => _roomTypeName = value; }
        public int NumberOfBed { get => _numberOfBed; set => _numberOfBed = value; }
        public int Capacity { get => _capacity; set => _capacity = value; }
        public int CostPerDay { get => _costPerDay; set => _costPerDay = value; }
        public string ManagerId { get => _managerId; set => _managerId = value; }
    }
}
