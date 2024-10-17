using System;

namespace HotelManagementSystem.Model {
    public class Bill {
        private string _billId;
        private int _roomFee;
        private int _serviceFee;
        private int _additionalFee;
        private string _additionalFeeContent;
        private DateTime _createdAt;
        private int _total;
        private string _paymentMethod;
        private string _customerId;
        private string _receptionistId;

        public Bill() {
        }

        public Bill(string billId, int roomFee, int serviceFee, int additionalFee, string additionalFeeContent, DateTime createdAt, int total, string paymentMethod, string customerId, string receptionistId) {
            BillId = billId;
            RoomFee = roomFee;
            ServiceFee = serviceFee;
            AdditionalFee = additionalFee;
            AdditionalFeeContent = additionalFeeContent;
            CreatedAt = createdAt;
            Total = total;
            PaymentMethod = paymentMethod;
            CustomerId = customerId;
            ReceptionistId = receptionistId;
        }

        public string BillId { get => _billId; set => _billId = value; }
        public int RoomFee { get => _roomFee; set => _roomFee = value; }
        public int ServiceFee { get => _serviceFee; set => _serviceFee = value; }
        public int AdditionalFee { get => _additionalFee; set => _additionalFee = value; }
        public string AdditionalFeeContent { get => _additionalFeeContent; set => _additionalFeeContent = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }
        public int Total { get => _total; set => _total = value; }
        public string PaymentMethod { get => _paymentMethod; set => _paymentMethod = value; }
        public string CustomerId { get => _customerId; set => _customerId = value; }
        public string ReceptionistId { get => _receptionistId; set => _receptionistId = value; }
    }
}
