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

namespace FlowerShopManagementSystem.Suppliers
{
    /// <summary>
    /// Interaction logic for EditSupplierForm.xaml
    /// </summary>
    public partial class EditSupplierForm : Window
    {
        Supplier supplierNewInfo;
        public EditSupplierForm()
        {
            InitializeComponent();
            notify.Visibility = Visibility.Hidden;
        }

        private void btnEditSaveSuppier_Click(object sender, RoutedEventArgs e)
        {
            if (tbxEditSupplierID.Text == "" || tbxEditSupplierName.Text == ""
                || tbxEditSupplierPhoneNumber.Text == "" || tbxEditSupplierStreet.Text == ""
                || cbbEditSupplierWard.Text == "" || cbbEditSupplierDistrict.Text == "" || cbbEditSuppierCity.Text == "")
            {
                notify.Visibility = Visibility.Visible;
            }
            else
            {
                UpdateSupplier();
            }
        }

        private void btnEditBackSupplier_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbbEditSupplierWard_DropDownOpened(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbEditSupplierWard_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void cbbEditSupplierDistrict_DropDownOpened(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbEditSupplierDistrict_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void cbbEditSuppierCity_DropDownOpened(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbEditSuppierCity_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void tbxEditSupplierPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbxEditSupplierName_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxEditSupplierPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxEditSupplierStreet_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void UpdateSupplier()
        {
            try
            {
                supplierNewInfo = new Supplier();
                supplierNewInfo.maNCC = tbxEditSupplierID.Text.ToString();
                supplierNewInfo.tenNCC = tbxEditSupplierName.Text.ToString();
                ComboBoxItem newWardCBI = (ComboBoxItem)cbbEditSupplierWard.SelectedItem,
                            newDistrictCBI = (ComboBoxItem)cbbEditSupplierDistrict.SelectedItem,
                            newCityCBI = (ComboBoxItem)cbbEditSuppierCity.SelectedItem;
                string newWard = newWardCBI.Content.ToString(),
                        newDistrict = newDistrictCBI.Content.ToString(),
                        newCity = newCityCBI.Content.ToString();
                supplierNewInfo.diaChiNCC = tbxEditSupplierStreet.Text.ToString() + ", " + newWard + ", " + newDistrict + ", " + newCity;
                supplierNewInfo.soDTNCC = tbxEditSupplierPhoneNumber.Text.ToString();
                using (var sqlConnection = new SqlConnection(Database.connection))
                using (var cmd = new SqlDataAdapter())
                using (var insertCommand = new SqlCommand(
                    "update NHA_CUNG_CAP " +
                    "set TENNCC = '" + supplierNewInfo.tenNCC + "', DIACHI = '" + supplierNewInfo.diaChiNCC + "', SODT = '" + supplierNewInfo.soDTNCC + "' " +
                    "where MANCC = '" + supplierNewInfo.maNCC + "'"))
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
