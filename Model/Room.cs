namespace HotelManagementSystem.Model {
    public class Room {
        private int _roomId;
        private string _status;
        private string _managerId;
        private string _roomTypeId;
        private string _roomName;
        public Room() {
        }
        public Room(int roomId, string status, string managerId, string roomTypeId, string roomName) {
            RoomId = roomId;
            Status = status;
            ManagerId = managerId;
            RoomTypeId = roomTypeId;
            RoomName = roomName;
        }
        public int RoomId { get => _roomId; set => _roomId = value; }
        public string Status { get => _status; set => _status = value; }
        public string ManagerId { get => _managerId; set => _managerId = value; }
        public string RoomTypeId { get => _roomTypeId; set => _roomTypeId = value; }
        public string RoomName { get => _roomName; set => _roomName = value; }
    }
}
