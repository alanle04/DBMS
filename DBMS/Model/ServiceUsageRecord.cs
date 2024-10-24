using System;

namespace HotelManagementSystem.Model {
    public class ServiceUsageRecord {
        private string _serviceUsesageId;
        private DateTime _usageTime;
        private int _quantity;
        private string _bookingId;
        private string _receptionistId;
        private string _serviceId;
        public ServiceUsageRecord() {
        }
        public ServiceUsageRecord(string serviceUsesageId, DateTime usageTime, int quantity, string bookingId, string receptionistId, string serviceId) {
            ServiceUsesageId = serviceUsesageId;
            UsageTime = usageTime;
            Quantity = quantity;
            BookingId = bookingId;
            ReceptionistId = receptionistId;
            ServiceId = serviceId;
        }
        public string ServiceUsesageId { get => _serviceUsesageId; set => _serviceUsesageId = value; }
        public DateTime UsageTime { get => _usageTime; set => _usageTime = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public string BookingId { get => _bookingId; set => _bookingId = value; }
        public string ReceptionistId { get => _receptionistId; set => _receptionistId = value; }
        public string ServiceId { get => _serviceId; set => _serviceId = value; }
    }
}
