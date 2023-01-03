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

namespace FlowerShopManagementSystem.Customers
{
    /// <summary>
    /// Interaction logic for EditCustomerForm.xaml
    /// </summary>
    public partial class EditCustomerForm : Window
    {
        Customer customerNewInfo;
        public EditCustomerForm()
        {
            InitializeComponent();
            notify.Visibility = Visibility.Hidden;
        }

        private void btnEditBackCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditSaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (tbxEditCustomerName.Text == "" || tbxEditCustomerPhone.Text == ""
                || tbxEditCustomerHouseNumber.Text == "" || tbxEditCustomerStreet.Text == ""
                || cbbEditDistrict.Text == "" || cbbEditCity.Text == "" || cbbEditProvince.Text == ""
                || tbxEditCustomerSales.Text == "" || dpkEditRegistrationDate.Text == "")
            {
                notify.Visibility = Visibility.Visible;

            }
            else
            {
                UpdateCustomer();
            }
        }

        private void tbxEditCustomerSales_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbxEditCustomerPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void cbbEditDistrict_DropDownOpened(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbEditDistrict_DropDownClosed(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbEditCity_DropDownOpened(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbEditCity_DropDownClosed(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbEditProvince_DropDownOpened(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbEditProvince_DropDownClosed(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbEditDistrict_DropDownOpened_1(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxEditCustomerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxEditCustomerHouseNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxEditCustomerStreet_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxEditCustomerSales_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void dpkEditRegistrationDate_CalendarOpened(object sender, RoutedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void UpdateCustomer()
        {
            try
            {
                customerNewInfo = new Customer();
                customerNewInfo.name = tbxEditCustomerName.Text;
                ComboBoxItem newDistrictCBI = (ComboBoxItem)cbbEditDistrict.SelectedItem,
                            newCityCBI = (ComboBoxItem)cbbEditCity.SelectedItem,
                            newProvinceCBI = (ComboBoxItem)cbbEditProvince.SelectedItem;
                string newDistrict = newDistrictCBI.Content.ToString(),
                        newCity = newCityCBI.Content.ToString(),
                        newProvince = newProvinceCBI.Content.ToString();
                if (newProvince == "(Empty)")
                {
                    customerNewInfo.address = tbxEditCustomerHouseNumber.Text.ToString() + ", " + tbxEditCustomerStreet.Text.ToString() + ", " + newDistrict + ", " + newCity;
                }
                else
                {
                    customerNewInfo.address = tbxEditCustomerHouseNumber.Text.ToString() + ", " + tbxEditCustomerStreet.Text.ToString() + ", " + newDistrict + ", " + newCity + ", " + newProvince;
                }
                customerNewInfo.phone = tbxEditCustomerPhone.Text.ToString();
                customerNewInfo.doanhSo = double.Parse(tbxEditCustomerSales.Text.ToString());
                customerNewInfo.ngayDK = dpkEditRegistrationDate.Text.ToString();
                using (var sqlConnection = new SqlConnection(Database.connection))
                using (var cmd = new SqlDataAdapter())
                using (var insertCommand = new SqlCommand(
                    "update KHACH_HANG " +
                    "set HOTEN = '" + customerNewInfo.name + "', DIACHI = '" + customerNewInfo.address + "', DOANHSO = '" + customerNewInfo.doanhSo + "', NGDK = '" + customerNewInfo.ngayDK + "' " +
                    "where SODT_KH = '" + customerNewInfo.phone + "'"))
                {
                    insertCommand.Connection = sqlConnection;
                    cmd.InsertCommand = insertCommand;
                    sqlConnection.Open();
                    cmd.InsertCommand.ExecuteNonQuery();
                }
                MessageBox.Show("Done!", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
