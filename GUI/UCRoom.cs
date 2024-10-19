using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class UCRoom : UserControl {
        private string username;

        public UCRoom() {
            InitializeComponent();
        }

        public UCRoom(string username) {
            InitializeComponent();
            this.username = username;
        }
    }
}
