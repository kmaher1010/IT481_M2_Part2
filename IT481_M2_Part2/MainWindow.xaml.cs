using IT481_M2.AppFiles;
using IT481_M2.BusinessLayer;
using IT481_M2.DataLayer;
using Microsoft.Extensions.Options;
using System.Windows;

namespace IT481_M2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppSettings _appSettings;
        private NorthwindService _northwindService;
        public MainWindow(IOptionsMonitor<AppSettings> appSettings)
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            var login = new Login();
            if (login.ShowDialog() == true) {

                var northwindService = new NorthwindService();
                if (northwindService.Login(login.tbUser.Text, login.tbPassword.Password, login.tbServer.Text, login.tbDatabase.Text)) {
                    _northwindService = northwindService;
                } else {
                    _northwindService = null;
                    MessageBox.Show("login failed");
                }
                RefreshData();

            } else {
                ClearData();
                _northwindService = null;
                MessageBox.Show("login failed");
            }
        }

        private void ClearData() {
            _northwindService = null;
            tbCount.Text = "No Access";
            CustomerGrid.ItemsSource = null;

            tbEmployeeCount.Text = "No Access";
            EmployeeGrid.ItemsSource = null;

            tbOrderCount.Text = "No Access";
            OrderGrid.ItemsSource = null;
        }

        private void RefreshData() {
            if (_northwindService == null) {
                MessageBox.Show("Please login first");
                return;
            }
            
            tbCount.Text = _northwindService.GetCustomerCount().ToString();
            CustomerGrid.AutoGenerateColumns = false;
            CustomerGrid.ItemsSource = _northwindService.GetCustomerNames();

            tbEmployeeCount.Text = _northwindService.GetEmployeeCount().ToString();
            EmployeeGrid.AutoGenerateColumns = false;
            EmployeeGrid.ItemsSource = _northwindService.GetEmployeeNames();

            tbOrderCount.Text = _northwindService.GetOrderCount().ToString();
            OrderGrid.AutoGenerateColumns = false;
            OrderGrid.ItemsSource = _northwindService.GetOrderNames();
        }
    }
}
