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
    /// Interaction logic for AddCustomerForm.xaml
    /// </summary>
    public partial class AddCustomerForm : Window
    {
        CustomersView customersView;
        public AddCustomerForm()
        {
            InitializeComponent();
            notify.Visibility = Visibility.Hidden;
        }

        private void btnBackCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (tbxCustomerName.Text == "" || tbxCustomerPhone.Text == ""
                || tbxCustomerHouseNumber.Text == "" || tbxCustomerStreet.Text == ""
                || cbbDistrict.Text == "" || cbbCity.Text == "" || cbbProvince.Text == ""
                || tbxCustomerSales.Text == "" || dpkRegistrationDate.Text == "")
            {
                notify.Visibility = Visibility.Visible;

            }
            else
            {
                notify.Visibility = Visibility.Collapsed;
                AddCustomer();
            }
        }

        private void tbxCustomerSales_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbxCustomerPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void cbbDistrict_DropDownOpened(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbDistrict_DropDownClosed(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbCity_DropDownOpened(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbCity_DropDownClosed(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbProvince_DropDownOpened(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbProvince_DropDownClosed(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxCustomerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxCustomerPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxCustomerHouseNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxCustomerStreet_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxCustomerSales_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void dpkRegistrationDate_CalendarOpened(object sender, RoutedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void AddCustomer()
        {
            try
            {
                customersView = new CustomersView();
                Customer customer = new Customer();
                customer.name = tbxCustomerName.Text.ToString();
                ComboBoxItem districtCBI = (ComboBoxItem)cbbDistrict.SelectedItem,
                            cityCBI = (ComboBoxItem)cbbCity.SelectedItem,
                            provinceCBI = (ComboBoxItem)cbbProvince.SelectedItem;
                string district = districtCBI.Content.ToString(),
                        city = cityCBI.Content.ToString(),
                        province = provinceCBI.Content.ToString();
                if (province == "(Empty)")
                {
                    customer.address = tbxCustomerHouseNumber.Text.ToString() + ", " + tbxCustomerStreet.Text.ToString() + ", " + district + ", " + city;
                }
                else
                {
                    customer.address = tbxCustomerHouseNumber.Text.ToString() + ", " + tbxCustomerStreet.Text.ToString() + ", " + district + ", " + city + ", " + province;
                }
                customer.phone = tbxCustomerPhone.Text.ToString();
                customer.doanhSo = double.Parse(tbxCustomerSales.Text.ToString());
                customer.ngayDK = dpkRegistrationDate.Text.ToString();
                using (var sqlConnection = new SqlConnection(Database.connection))
                using (var cmd = new SqlDataAdapter())
                using (var insertCommand = new SqlCommand("insert into KHACH_HANG (SODT_KH, HOTEN, DIACHI, DOANHSO, NGDK) " +
                    "values ('" + customer.phone + "', '" + customer.name + "', '" + customer.address + "', '" + customer.doanhSo + "', '" + DateTime.Parse(customer.ngayDK) + "')"))
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
