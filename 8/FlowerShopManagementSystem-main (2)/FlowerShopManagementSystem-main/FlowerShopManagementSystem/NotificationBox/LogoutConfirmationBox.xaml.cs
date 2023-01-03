using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlowerShopManagementSystem.NotificationBox
{
    /// <summary>
    /// Interaction logic for LogoutConfirmationBox.xaml
    /// </summary>
    public partial class LogoutConfirmationBox : Window
    {
        public LogoutConfirmationBox()
        {
            InitializeComponent();

            MainWindow.isLogout = true;
        }

        private void exitLogoutBoxBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.isLogout = false;

            this.Close();
        }

        private void btnCancelLogoutBox_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.isLogout = false;

            this.Close();
        }

        private void btnLogoutBox_Click(object sender, RoutedEventArgs e)
        {

            Login login = new Login();
            
            this.Close();

            login.Show();

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
