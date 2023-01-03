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

namespace FlowerShopManagementSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static int priority;
        public static string username, role;
        public static string imageName;
        public Login()
        {
            InitializeComponent();
            tbxUsername.Focus();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tbxUsername.Text == "")
            {
                if (tbxPassword.Password.ToString() == "")
                {
                    loginNotification("Please input full information!");
                    tbxUsername.BorderBrush = new SolidColorBrush(Colors.Red);
                    tbxPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    loginNotification("Please input full information!");
                    tbxUsername.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                if (tbxPassword.Password.ToString() == "")
                {
                    loginNotification("Please input full information!");
                    tbxPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    if (tbxUsername.Text == "admin" || tbxPassword.Password.ToString() == "admin")
                    {
                        loginNotification("Username is the same as password!");
                        tbxUsername.BorderBrush = new SolidColorBrush(Colors.Red);
                        tbxPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        //MainWindow mainWindow = new MainWindow();
                        //mainWindow.Show();
                        //this.Close();
                        CheckValidAccount();
                    }
                }
            }
        }

        private void CheckValidAccount()
        {
            try
            {
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database TableRight = new Database("RESULT", "select * from NHAN_VIEN where USERNAME = '" + tbxUsername.Text
                    + "' and USER_PASSWORD = '" + tbxPassword.Password + "'");
                if (TableRight.Rows.Count > 0)
                {
                    if (TableRight.Rows[0][6].ToString() == "1")
                    {

                        priority = 1;
                        username = TableRight.Rows[0][1].ToString();
                        role = "Manager";
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.txbUsername.Text = username;
                        mainWindow.txbRole.Text = role;
                        mainWindow.avatar.ImageSource = new BitmapImage(new Uri(@"../../Accounts/AccountAvatar/" + TableRight.Rows[0][7].ToString(), UriKind.Relative));
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        priority = 0;
                        username = TableRight.Rows[0][1].ToString();
                        role = "Employee";
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.txbUsername.Text = username;
                        mainWindow.txbRole.Text = role;
                        mainWindow.btnAccounts.Visibility = Visibility.Collapsed;
                        mainWindow.btnSuppliers.Visibility = Visibility.Collapsed;
                        mainWindow.btnProducts.Visibility = Visibility.Collapsed;
                        mainWindow.avatar.ImageSource = new BitmapImage(new Uri(@"../../Accounts/AccountAvatar/" + TableRight.Rows[0][7].ToString(), UriKind.Relative));
                        mainWindow.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        private void loginNotification(String notify)
        {
            loginNotify.Text = notify;
            loginNotify.Visibility = Visibility.Visible;
        }

        private void tbxUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            loginNotify.Visibility = Visibility.Hidden;
            tbxUsername.BorderBrush = new SolidColorBrush(Colors.Black);
            tbxPassword.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        private void tbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            loginNotify.Visibility = Visibility.Hidden;
            tbxUsername.BorderBrush = new SolidColorBrush(Colors.Black);
            tbxPassword.BorderBrush = new SolidColorBrush(Colors.Black);
        }
    }
}
