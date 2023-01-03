using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlowerShopManagementSystem.Accounts
{
    /// <summary>
    /// Interaction logic for AddAccountForm.xaml
    /// </summary>
    public partial class AddAccountForm : Window
    {
        string image;
        AccountsView accountsView;
        public AddAccountForm()
        {
            InitializeComponent();
            notify.Visibility = Visibility.Hidden;
        }

        private void btnBackEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (tbxEmployeeID.Text == "" || tbxEmployeeName.Text == ""
                || tbxEmployeePhoneNumber.Text == "" || dpkWorkingDate.Text == ""
                || tbxUsername.Text == "" || tbxPassword.Text == "")
            {
                notify.Visibility = Visibility.Visible;
            }
            else
            {
                AddAccount();
            }
        }

        private void uploadAvatarBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "(*.png)|*.png|(*.jpg)|*.jpg|(*.*)|*.*";
            openFile.FileName = "avatar1.jpg";

            if (openFile.ShowDialog() == true)
            {
                image = openFile.FileName;
                avatar.ImageSource = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void tbxEmployeePhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void cbbAccountPriority_DropDownOpened(object sender, EventArgs e)
        {
            //cbbAccountPriority.Background = Brushes.LightGray;
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbAccountPriority_DropDownClosed(object sender, EventArgs e)
        {
            //cbbAccountPriority.Background = Brushes.Transparent;
        }

        private void tbxEmployeeID_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxEmployeeName_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxEmployeePhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void dpkWorkingDate_CalendarOpened(object sender, RoutedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void AddAccount()
        {
            try
            {
                accountsView = new AccountsView();
                Account account = new Account();
                account.employeeCode = tbxEmployeeID.Text.ToString();
                account.employeeName = tbxEmployeeName.Text.ToString();
                account.employeePhone = tbxEmployeePhoneNumber.Text.ToString();
                account.workingDate = dpkWorkingDate.Text.ToString();
                account.username = tbxUsername.Text.ToString();
                account.password = tbxPassword.Text.ToString();
                if (image != "")
                {
                    string imageName = System.IO.Path.GetFileName(image);
                    account.avatarTK = imageName;
                    if (!System.IO.File.Exists("../../Accounts/AccountAvatar/" + imageName))
                    {
                        System.IO.File.Copy(image, "../../Accounts/AccountAvatar/" + imageName);
                    }
                }
                if (cbbAccountPriority.Text.ToString() == "Manager")
                {
                    account.priority = "1";
                }
                else
                {
                    account.priority = "0";
                }
                using (var sqlConnection = new SqlConnection(Database.connection))
                using (var cmd = new SqlDataAdapter())
                using (var insertCommand = new SqlCommand("insert into NHAN_VIEN(MANV, HOTEN, SODT, NGVL, USERNAME, USER_PASSWORD, USER_PRIORITY, AVATAR) " +
                    "values ('" + account.employeeCode + "','" + account.employeeName + "','" + account.employeePhone + "','" + account.workingDate + "','" + account.username + "','" + account.password + "','" + account.priority + "','" + account.avatarTK + "')"))
                {
                    insertCommand.Connection = sqlConnection;
                    cmd.InsertCommand = insertCommand;
                    sqlConnection.Open();
                    cmd.InsertCommand.ExecuteNonQuery();
                }
                MessageBox.Show("Done!", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
