namespace HotelManagementSystem.Model {
    public class Room {
        private string _roomId;
        private string _roomName;
        private string _status;
        private string _roomTypeId;
        private string _managerId;
        public Room() {
        }

        public Room(string roomId, string roomName, string status, string roomTypeId, string managerId) {
            RoomId = roomId;
            RoomName = roomName;
            Status = status;
            RoomTypeId = roomTypeId;
            ManagerId = managerId;
        }

        public string RoomId { get => _roomId; set => _roomId = value; }
        public string RoomName { get => _roomName; set => _roomName = value; }
        public string Status { get => _status; set => _status = value; }
        public string RoomTypeId { get => _roomTypeId; set => _roomTypeId = value; }
        public string ManagerId { get => _managerId; set => _managerId = value; }
    }
}
