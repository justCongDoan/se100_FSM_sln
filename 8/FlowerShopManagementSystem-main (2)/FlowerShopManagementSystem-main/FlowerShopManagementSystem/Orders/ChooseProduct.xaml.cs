using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace FlowerShopManagementSystem.Orders
{
    /// <summary>
    /// Interaction logic for ChooseProduct.xaml
    /// </summary>
    public partial class ChooseProduct : Window
    {
        List<Product> products;
        public static Product selectedItem;
        public static CTHD selectedCTHD;
        public static List<CTHD> cthdList;
        public static int stt = 0;
        public static bool isListEmpty;
        //public static double total;
        public ChooseProduct()
        {
            InitializeComponent();

            isListEmpty = false;

            products = new List<Product>();

            cthdList = new List<CTHD>();

            //products.Add(new Product { productImage = "/Products/Product Image/Hoa mai.jpg", productName = "Hoa mai", productPrice = 100, productSupplier = "123456788989867" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa đào.jpg", productName = "Hoa đào", productPrice = 100, productSupplier = "UIT" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa hồng.jpg", productName = "Hoa hồng", productPrice = 100, productSupplier = "UIT" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa lan.jpg", productName = "Hoa lan", productPrice = 100, productSupplier = "UIT" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa ly.jpg", productName = "Hoa ly", productPrice = 100, productSupplier = "UIT" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa cúc.jpg", productName = "Hoa cúc", productPrice = 100, productSupplier = "UIT" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa vạn thọ.png", productName = "Hoa vạn thọ", productPrice = 100, productSupplier = "UIT" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa mai.jpg", productName = "Hoa mai", productPrice = 100, productSupplier = "123456788989867" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa đào.jpg", productName = "Hoa đào", productPrice = 100, productSupplier = "UIT" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa hồng.jpg", productName = "Hoa hồng", productPrice = 100, productSupplier = "UIT" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa lan.jpg", productName = "Hoa lan", productPrice = 100, productSupplier = "UIT" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa ly.jpg", productName = "Hoa ly", productPrice = 100, productSupplier = "UIT" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa cúc.jpg", productName = "Hoa cúc", productPrice = 100, productSupplier = "UIT" });
            //products.Add(new Product { productImage = "/Products/Product Image/Hoa vạn thọ.png", productName = "Hoa vạn thọ", productPrice = 100, productSupplier = "UIT" });

            //ListProductsChoose.ItemsSource = products;
            LoadData(products);
        }

        private void btnFindProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExitChooseProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnProductIn4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (cthdList == null)
            {
                isListEmpty = true;
            }
            Close();
        }

        private void LoadData(List<Product> products)
        {
            //total = 0;
            //cthdList = new List<CTHD>();
            //stt = 0;
            try
            {
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database results = new Database("RESULT", "select * from SAN_PHAM");
                for (int i = 0; i < results.Rows.Count; i++)
                {
                    products.Add(new Product
                    {
                        productID = results.Rows[i][0].ToString(),
                        productName = results.Rows[i][1].ToString(),
                        productSupplier = results.Rows[i][4].ToString(),
                        productPrice = double.Parse(results.Rows[i][5].ToString()),
                        //productPrice = double.Parse(results.Rows[i][4].ToString()),
                        productImage = "/Products/Product Image/" + results.Rows[i][6].ToString()
                    });
                }
                ListProductsChoose.ItemsSource = products;
                txtProductsOneOf.Text = "1 of " + products.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void itemChB_Checked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Checked!", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
            CheckBox checkBox = sender as CheckBox;
            selectedItem = checkBox.DataContext as Product;
            AddTempProduct();
            //total += long.Parse(selectedItem.productPrice.ToString());
        }

        private void itemChB_Unchecked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Unchecked!", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
            CheckBox checkBox = sender as CheckBox;
            selectedItem = checkBox.DataContext as Product;
            RemoveTempProduct();
            //total -= long.Parse(selectedItem.productPrice.ToString());
        }

        protected void AddTempProduct()
        {
            try
            {
                //using (var sqlConnection = new SqlConnection(Database.connection))
                //using (var cmd = new SqlDataAdapter())
                //using (var insertCommand = new SqlCommand("insert into TEMPDATA_CTHD (MASP, TENSP, SL, TRIGIA, TONGTRIGIA) " +
                //    "values ('" + selectedItem.productID + "', '" + selectedItem.productName + "', '1', '" + selectedItem.productPrice + "', '" + selectedItem.productPrice + "')"))
                //{
                //    insertCommand.Connection = sqlConnection;
                //    cmd.InsertCommand = insertCommand;
                //    sqlConnection.Open();
                //    cmd.InsertCommand.ExecuteNonQuery();
                //}
                //total += long.Parse(selectedItem.productPrice.ToString());
                //Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                //Database results = new Database("RESULT", "select * from SAN_PHAM");
                cthdList.Add(new CTHD
                {
                    sttSanPham = (stt + 1).ToString(),
                    productID = selectedItem.productID,
                    productName = selectedItem.productName,
                    productPrice = selectedItem.productPrice,
                    productQuantity = 1,
                    productTotalMoney = selectedItem.productPrice
                });
            }
            catch
            {
                MessageBox.Show("Error:\nYou cannot choose the same product!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                selectedItem.IsChecked = false;
            }
            //GetSumOfMoney();
        }

        protected void RemoveTempProduct()
        {
            try
            {
                //using (var sqlConnection = new SqlConnection(Database.connection))
                //using (var cmd = new SqlDataAdapter())
                //using (var insertCommand = new SqlCommand("delete from TEMPDATA_CTHD where MASP = '" + selectedItem.productID + "'"))
                //{
                //    insertCommand.Connection = sqlConnection;
                //    cmd.InsertCommand = insertCommand;
                //    sqlConnection.Open();
                //    cmd.InsertCommand.ExecuteNonQuery();
                //}
                //total -= long.Parse(selectedItem.productPrice.ToString());
                var index = cthdList.FindIndex(a => a.productID == selectedItem.productID);
                cthdList.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //GetSumOfMoney();
        }

        private void GetSumOfMoney()
        {
            try
            {
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database results = new Database("RESULT", "select sum(TRIGIA) from TEMPDATA_CTHD");
                string strTotal = results.Rows[0][0].ToString();
                if (results.Rows.Count > 0)
                {
                    //total = double.Parse(strTotal);
                }
                else
                {
                    //total = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }

    public class Product : INotifyPropertyChanged
    {
        public string productID { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
        public string productImage { get; set; }
        public string productSupplier { get; set; }

        //public Product(string name, double price, string image)
        //{
        //    productName = name;
        //    productPrice = price;
        //    productImage = image;
        //}

        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
