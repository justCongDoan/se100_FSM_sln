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

namespace FlowerShopManagementSystem.Products
{
    /// <summary>
    /// Interaction logic for EditProductForm.xaml
    /// </summary>
    public partial class EditProductForm : Window
    {
        string imageToEdit;
        Product newProductInfo;
        public EditProductForm()
        {
            InitializeComponent();
            notify.Visibility = Visibility.Hidden;
        }


        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (tbxProductID.Text == "" || tbxEditProductName.Text == ""
                || tbxEditProductType.Text == "" || cbbEditSuppier.Text == ""
                || tbxEditEvent.Text == "" || tbxEditProductPrice.Text == "")
            {
                notify.Visibility = Visibility.Visible;
            }
            else
            {
                UpdateProduct();
            }
        }

        private void btnBackEditProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbxEditProductPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void editProductImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "(*.png)|*.png|(*.jpg)|*.jpg|(*.*)|*.*";
            openFile.FileName = "hoa_cuc.jpg";

            if (openFile.ShowDialog() == true)
            {
                imageToEdit = openFile.FileName;
                editProductImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void cbbEditSuppier_DropDownOpened(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbEditSuppier_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void tbxEditProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxEditProductType_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxEditEvent_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxEditProductPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void UpdateProduct()
        {
            try
            {
                newProductInfo = new Product();
                newProductInfo.productCode = tbxProductID.Text.ToString();
                newProductInfo.productName = tbxEditProductName.Text.ToString();
                newProductInfo.productType = tbxEditProductType.Text.ToString();
                newProductInfo.productOccasion = tbxEditEvent.Text.ToString();
                ComboBoxItem productSupplierCBI = (ComboBoxItem)cbbEditSuppier.SelectedItem;
                string supplierName = productSupplierCBI.Content.ToString();
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database result = new Database("RESULT", "select MANCC from NHA_CUNG_CAP where TENNCC = '" + supplierName + "'");
                newProductInfo.productSupplier = result.Rows[0][0].ToString();
                newProductInfo.productPrice = double.Parse(tbxEditProductPrice.Text.ToString());
                if (imageToEdit != "")
                {
                    string imageName = System.IO.Path.GetFileName(imageToEdit);
                    newProductInfo.productImage = imageName;
                    if (!System.IO.File.Exists("../../Products/Product Image/" + imageName))
                    {
                        System.IO.File.Copy(imageToEdit, "../../Products/Product Image/" + imageName);
                    }
                }
                if (newProductInfo.productImage != ProductsView.selectedProduct.productImage)
                {
                    using (var sqlConnection = new SqlConnection(Database.connection))
                    using (var cmd = new SqlDataAdapter())
                    using (var insertCommand = new SqlCommand(
                        "update SAN_PHAM " +
                        "set TENSP = '" + newProductInfo.productName + "', LOAISP = '" + newProductInfo.productType + "', SU_KIEN = '" + newProductInfo.productOccasion.ToLower() + "', MANCC = '" + newProductInfo.productSupplier + "', GIA = '" + newProductInfo.productPrice + "', HINH_ANH = '" + newProductInfo.productImage + "' " +
                        "where MASP = '" + newProductInfo.productCode + "'"))
                    {
                        insertCommand.Connection = sqlConnection;
                        cmd.InsertCommand = insertCommand;
                        sqlConnection.Open();
                        cmd.InsertCommand.ExecuteNonQuery();
                    }
                    MessageBox.Show("Done!", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    using (var sqlConnection = new SqlConnection(Database.connection))
                    using (var cmd = new SqlDataAdapter())
                    using (var insertCommand = new SqlCommand(
                        "update SAN_PHAM " +
                        "set TENSP = '" + newProductInfo.productName + "', LOAISP = '" + newProductInfo.productType + "', SU_KIEN = '" + newProductInfo.productOccasion.ToLower() + "', MANCC = '" + newProductInfo.productSupplier + "', GIA = '" + newProductInfo.productPrice + "' " +
                        "where MASP = '" + newProductInfo.productCode + "'"))
                    {
                        insertCommand.Connection = sqlConnection;
                        cmd.InsertCommand = insertCommand;
                        sqlConnection.Open();
                        cmd.InsertCommand.ExecuteNonQuery();
                    }
                    MessageBox.Show("Done!", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
