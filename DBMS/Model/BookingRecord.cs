using System;

namespace HotelManagementSystem.Model {
    public class BookingRecord {
        private string _bookingRecordId;
        private DateTime _bookingTime;
        private string _status;
        private DateTime _expectedCheckInTime;
        private DateTime _expectedCheckOutTime;
        private DateTime? _actualCheckInTime;
        private DateTime? _actualCheckOutTime;
        private string _receptionistId;
        private string _customerId;
        private string _roomId;

        public BookingRecord() {
        }
        public BookingRecord(string bookingRecordId, DateTime bookingTime, string status, DateTime expectedCheckInTime, DateTime expectedCheckOutTime, DateTime actualCheckInTime, DateTime actualCheckOutTime, string receptionistId, string customerId, string roomId) {
            BookingRecordId = bookingRecordId;
            BookingTime = bookingTime;
            Status = status;
            ExpectedCheckInTime = expectedCheckInTime;
            ExpectedCheckOutTime = expectedCheckOutTime;
            ActualCheckInTime = actualCheckInTime;
            ActualCheckOutTime = actualCheckOutTime;
            ReceptionistId = receptionistId;
            CustomerId = customerId;
            RoomId = roomId;
        }
        public string BookingRecordId { get => _bookingRecordId; set => _bookingRecordId = value; }
        public DateTime BookingTime { get => _bookingTime; set => _bookingTime = value; }
        public string Status { get => _status; set => _status = value; }
        public DateTime ExpectedCheckInTime { get => _expectedCheckInTime; set => _expectedCheckInTime = value; }
        public DateTime ExpectedCheckOutTime { get => _expectedCheckOutTime; set => _expectedCheckOutTime = value; }
        public DateTime? ActualCheckInTime { get => _actualCheckInTime; set => _actualCheckInTime = value; }
        public DateTime? ActualCheckOutTime { get => _actualCheckOutTime; set => _actualCheckOutTime = value; }
        public string ReceptionistId { get => _receptionistId; set => _receptionistId = value; }
        public string CustomerId { get => _customerId; set => _customerId = value; }
        public string RoomId { get => _roomId; set => _roomId = value; }
    }
}
