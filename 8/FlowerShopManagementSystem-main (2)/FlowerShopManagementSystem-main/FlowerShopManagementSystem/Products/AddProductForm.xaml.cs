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
    /// Interaction logic for AddProductForm.xaml
    /// </summary>
    public partial class AddProductForm : Window
    {
        string image;
        ProductsView productsView;
        public AddProductForm()
        {
            InitializeComponent();
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxProductPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (tbxProductID.Text == "" || tbxProductName.Text == ""
                || tbxProductType.Text == "" || cbbSuppier.Text == ""
                || tbxEvent.Text == "" || tbxProductPrice.Text == "")
            {
                notify.Visibility = Visibility.Visible;
            }
            else
            {
                AddProduct();
            }
        }

        private void btnBackAddProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void uploadProductImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "(*.png)|*.png|(*.jpg)|*.jpg|(*.*)|*.*";
            openFile.FileName = "hoa_cuc.jpg";

            if (openFile.ShowDialog() == true)
            {
                image = openFile.FileName;
                productImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void cbbSuppier_DropDownOpened(object sender, EventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void cbbSuppier_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void tbxProductID_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxProductType_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxEvent_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxProductPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void AddProduct()
        {
            try
            {
                productsView = new ProductsView();
                Product product = new Product();
                product.productCode = tbxProductID.Text.ToString();
                product.productName = tbxProductName.Text.ToString();
                product.productType = tbxProductType.Text.ToString();
                product.productOccasion = tbxEvent.Text.ToString();
                ComboBoxItem productSupplierCBI = (ComboBoxItem)cbbSuppier.SelectedItem;
                string supplierName = productSupplierCBI.Content.ToString();
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database result = new Database("RESULT", "select MANCC from NHA_CUNG_CAP where TENNCC = '" + supplierName + "'");
                product.productSupplier = result.Rows[0][0].ToString();
                product.productPrice = double.Parse(tbxProductPrice.Text.ToString());
                if (image != "")
                {
                    string imageName = System.IO.Path.GetFileName(image);
                    product.productImage = imageName;
                    if (!System.IO.File.Exists("../../Products/Product Image/" + imageName))
                    {
                        System.IO.File.Copy(image, "../../Products/Product Image/" + imageName);
                    }
                }
                using (var sqlConnection = new SqlConnection(Database.connection))
                using (var cmd = new SqlDataAdapter())
                using (var insertCommand = new SqlCommand("insert into SAN_PHAM(MASP, TENSP, LOAISP, SU_KIEN, MANCC, GIA, HINH_ANH) " +
                    "values ('" + product.productCode + "','" + product.productName + "','" + product.productType + "','" + product.productOccasion.ToLower() + "','" + product.productSupplier + "','" + product.productPrice + "','" + product.productImage + "')"))
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
