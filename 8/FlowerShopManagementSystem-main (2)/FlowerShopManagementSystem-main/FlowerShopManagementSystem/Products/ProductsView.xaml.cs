using FlowerShopManagementSystem.NotificationBox;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowerShopManagementSystem.Products
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : Page
    {
        List<Product> products;
        public static Product selectedProduct;
        private Resources.PagingCollectionView view;
        public ProductsView()
        {
            InitializeComponent();

            products = new List<Product>();

            //products.Add(new Product{ productImage = "/Products/Product Image/Hoa mai.jpg", productName = "Hoa mai", productPrice = 100, productSupplier = "123456788989867"});
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa đào.jpg", productName = "Hoa đào", productPrice = 100, productSupplier = "UIT"});
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa hồng.jpg", productName = "Hoa hồng", productPrice = 100, productSupplier = "UIT" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa lan.jpg", productName = "Hoa lan", productPrice = 100, productSupplier = "UIT"});
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa ly.jpg", productName = "Hoa ly", productPrice = 100, productSupplier = "UIT" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa cúc.jpg", productName = "Hoa cúc", productPrice = 100, productSupplier = "UIT"});
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa vạn thọ.png", productName = "Hoa vạn thọ", productPrice = 100, productSupplier = "UIT"});

            //ListProducts.ItemsSource = products;
            LoadData(products);
            //tbxProductsOneOf.Text = "1 of " + products.Count.ToString();
        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            EditProductForm edit = new EditProductForm();
            Button btn = sender as Button;
            selectedProduct = btn.DataContext as Product;
            edit.tbxProductID.Text = selectedProduct.productCode;
            edit.tbxEditProductName.Text = selectedProduct.productName;
            edit.tbxEditProductType.Text = selectedProduct.productType;
            edit.tbxEditEvent.Text = selectedProduct.productOccasion.ToUpper();
            Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
            Database TableRight = new Database("RESULT", "select * from NHA_CUNG_CAP where MANCC = '" + selectedProduct.productSupplier + "'");
            //viewProductDetails.txtblckProductSupplier.Text = selectedProduct.productSupplier;
            edit.cbbEditSuppier.Text = TableRight.Rows[0][1].ToString();
            edit.tbxEditProductPrice.Text = selectedProduct.productPrice.ToString();
            string productImage = selectedProduct.productImage.Trim();
            string[] imageParts = productImage.Split('/');
            edit.editProductImage.Source = new BitmapImage(new Uri(@"../../Products/Product Image/" + imageParts[imageParts.Length - 1], UriKind.Relative));
            edit.ShowDialog();
            ReloadData(products);
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            NotificationBox.DeleteConfirmationBox deleteConfirmationBox = new NotificationBox.DeleteConfirmationBox();
            deleteConfirmationBox.ShowDialog();
            if (DeleteConfirmationBox.isDeleteBtnClicked)
            {
                try
                {
                    Button btn = sender as Button;
                    Product selectedProduct = btn.DataContext as Product;
                    Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                    using (var sqlConnection = new SqlConnection(Database.connection))
                    using (var cmd = new SqlDataAdapter())
                    using (var insertCommand = new SqlCommand("delete from SAN_PHAM where MASP = '" + selectedProduct.productCode + "'"))
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
            ReloadData(products);
        }

        private void addProductBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
            ReloadData(products);
        }

        private void btnProductIn4_Click(object sender, RoutedEventArgs e)
        {
            ViewProductDetails viewProductDetails = new ViewProductDetails();
            //Product selectedProduct = (Product)ListProducts.ItemContainerGenerator.ContainerFromIndex(ListProducts.TabIndex);
            Button btn = sender as Button;
            Product selectedProduct = btn.DataContext as Product;
            viewProductDetails.txtblckProductID.Text = selectedProduct.productCode;
            viewProductDetails.txtblckProductName.Text = selectedProduct.productName;
            viewProductDetails.txtblckProductType.Text = selectedProduct.productType;
            viewProductDetails.txtblckEvent.Text = selectedProduct.productOccasion.ToUpper();
            Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
            Database TableRight = new Database("RESULT", "select * from NHA_CUNG_CAP where MANCC = '" + selectedProduct.productSupplier + "'");
            //viewProductDetails.txtblckProductSupplier.Text = selectedProduct.productSupplier;
            viewProductDetails.txtblckProductSupplier.Text = TableRight.Rows[0][1].ToString();
            viewProductDetails.txtblckProductPrice.Text = selectedProduct.productPrice.ToString();
            string productImage = selectedProduct.productImage.Trim();
            string[] imageParts = productImage.Split('/');
            viewProductDetails.viewProductImage.Source = new BitmapImage(new Uri(@"../../Products/Product Image/" + imageParts[imageParts.Length - 1], UriKind.Relative));
            viewProductDetails.ShowDialog();
        }

        private void LoadData(List<Product> products)
        {
            try
            {
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database results = new Database("RESULT", "select * from SAN_PHAM");
                for (int i = 0; i < results.Rows.Count; i++)
                {
                    products.Add(new Product
                    {
                        productCode = results.Rows[i][0].ToString(),
                        productName = results.Rows[i][1].ToString(),
                        productType = results.Rows[i][2].ToString(),
                        productOccasion = results.Rows[i][3].ToString(),
                        productSupplier = results.Rows[i][4].ToString(),
                        productPrice = double.Parse(results.Rows[i][5].ToString()),
                        //productPrice = double.Parse(results.Rows[i][4].ToString()),
                        productImage = "/Products/Product Image/" + results.Rows[i][6].ToString()
                    });
                }
                //ListProducts.ItemsSource = products;
                view = new Resources.PagingCollectionView(products, 4);

                this.DataContext = view;
                ListProducts.ItemsSource = view;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReloadData(List<Product> products)
        {
            try
            {
                products = new List<Product>();
                LoadData(products);
                //tbxProductsOneOf.Text = "1 of " + products.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            view.MoveToFirstPage();
        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            view.MoveToPreviousPage();
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            view.MoveToNextPage();
        }

        private void btnLastPage_Click(object sender, RoutedEventArgs e)
        {
            view.MoveToLastPage();
        }
    }

    public class Product
    {
        public string productCode { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
        public string productImage { get; set; }
        public string productOccasion { get; set; }
        public string productType { get; set; }
        public string productSupplier { get; set; }

        //public Product(string name, double price, string image)
        //{
        //    productName = name;
        //    productPrice = price;
        //    productImage = image;
        //}
    } 
}
