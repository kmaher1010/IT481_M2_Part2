using IT481_M2.BusinessLayer;
using System.Windows;

namespace IT481_M2 {
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window {
        public Login() {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            if (LogIntoDB()) {
                DialogResult = true;
            } else {
                MessageBox.Show("login failed");
            }   

        }

        private bool LogIntoDB() {
            var northwindService = new NorthwindService();
            return northwindService.Login(tbUser.Text, tbPassword.Password, tbServer.Text, tbDatabase.Text);
        }
    }
}
