using FlowerShopManagementSystem.Orders;
using FlowerShopManagementSystem.Products;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowerShopManagementSystem.Dashboard
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Page
    {
        public static bool isOneProdOnly;
        List<Product> products = new List<Product>();
        static int stt = 1;
        Resources.PagingCollectionView view;
        public DashboardView()
        {
            InitializeComponent();
            isOneProdOnly = false;

            //List<filterButton> filters = new List<filterButton>();

            //filters.Add(new filterButton { buttonContent = "Tất cả" });
            //filters.Add(new filterButton { buttonContent = "Tình yêu" });
            //filters.Add(new filterButton { buttonContent = "Đám tang" });
            //filters.Add(new filterButton { buttonContent = "Đám cưới" });
            //filters.Add(new filterButton { buttonContent = "Tất cả" });
            //filters.Add(new filterButton { buttonContent = "Tình yêu" });
            //filters.Add(new filterButton { buttonContent = "Đám tang" });
            //filters.Add(new filterButton { buttonContent = "Đám cưới" });
            //filters.Add(new filterButton { buttonContent = "Tất cả" });
            //filters.Add(new filterButton { buttonContent = "Tình yêu" });
            //filters.Add(new filterButton { buttonContent = "Đám tang" });
            //filters.Add(new filterButton { buttonContent = "Đám cưới" });

            //listButton.ItemsSource = filters;

            //for (int i = 0; i < 10; i++)
            //{
            //    RadioButton button = new RadioButton();

            //    if (i == 0)
            //    {
            //        button.IsChecked = true;
            //        button.Content = "All";
            //    }
            //    else
            //    {
            //        button.Content = "Button" + i.ToString();
            //    }

            //    button.Click += Button_Click;

            //    var style = Application.Current.TryFindResource("buttonFilter") as Style;
            //    button.Style = style;

            //    stkpnl.Children.Add(button);
            //}
            RadioButton[] buttons = new RadioButton[7]
            {
                new RadioButton(),
                new RadioButton(),
                new RadioButton(),
                new RadioButton(),
                new RadioButton(),
                new RadioButton(),
                new RadioButton()
            };
            buttons[0].IsChecked = true;
            buttons[0].Content = "ALL";
            buttons[1].Content = "LOVE";
            buttons[2].Content = "BIRTHDAY";
            buttons[3].Content = "NEW";
            buttons[4].Content = "OFFICE";
            buttons[5].Content = "CONGRATS";
            buttons[6].Content = "CONDOLENCE";

            foreach(var button in buttons)
            {
                button.Click += Button_Click;
                var style = Application.Current.TryFindResource("buttonFilter") as Style;
                button.Style = style;
                stkpnl.Children.Add(button);
            }

            //products.Add(new Product { productImage = "/Products/Product Image/hoa_mai.jpg", productName = "Hoa mai", productPrice = 100 });
            //products.Add(new Product { productImage = "/Products/Product Image/hoa_dao.jpg", productName = "Hoa đào", productPrice = 100 });
            //products.Add(new Product { productImage = "/Products/Product Image/hoa_hong.jpg", productName = "Hoa hồng", productPrice = 100 });
            //products.Add(new Product { productImage = "/Products/Product Image/hoa_lan.jpg", productName = "Hoa lan", productPrice = 100 });
            //products.Add(new Product { productImage = "/Products/Product Image/hoa_ly.jpg", productName = "Hoa ly", productPrice = 100 });
            //products.Add(new Product { productImage = "/Products/Product Image/hoa_cuc.jpg", productName = "Hoa cúc", productPrice = 100 });
            //products.Add(new Product { productImage = "/Products/Product Image/hoa_van_tho.png", productName = "Hoa vạn thọ", productPrice = 100 });

            //DashboardProductsList.ItemsSource = products;
            LoadData(products);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            string filter = button.Content.ToString();
            LoadDataViaFilter(products, filter);
            //if (button.Content.ToString() == "ALL")
            //{
            //    products = new List<Product>();

            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_mai.jpg", productName = "Hoa mai", productPrice = 100 });
            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_dao.jpg", productName = "Hoa đào", productPrice = 100 });
            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_hong.jpg", productName = "Hoa hồng", productPrice = 100 });
            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_lan.jpg", productName = "Hoa lan", productPrice = 100 });
            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_ly.jpg", productName = "Hoa ly", productPrice = 100 });
            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_cuc.jpg", productName = "Hoa cúc", productPrice = 100 });
            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_van_tho.png", productName = "Hoa vạn thọ", productPrice = 100 });

            //    DashboardProductsList.ItemsSource = products;
            //}
            //else if (button.Content.ToString() == "LOVE")
            //{
            //    products = new List<Product>();

            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_mai.jpg", productName = "Hoa mai", productPrice = 100 });


            //    DashboardProductsList.ItemsSource = products;

            //}
            //else if (button.Content.ToString() == "BIRTHDAY")
            //{
            //    products = new List<Product>();

            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_dao.jpg", productName = "Hoa đào", productPrice = 100 });


            //    DashboardProductsList.ItemsSource = products;

            //}
            //else if (button.Content.ToString() == "NEW")
            //{
            //    products = new List<Product>();

            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_hong.jpg", productName = "Hoa hồng", productPrice = 100 });

            //    DashboardProductsList.ItemsSource = products;

            //}
            //else if (button.Content.ToString() == "OFFICE")
            //{
            //    products = new List<Product>();

            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_lan.jpg", productName = "Hoa lan", productPrice = 100 });

            //    DashboardProductsList.ItemsSource = products;

            //}
            //else if (button.Content.ToString() == "CONGRATS")
            //{
            //    products = new List<Product>();

            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_ly.jpg", productName = "Hoa ly", productPrice = 100 });


            //    DashboardProductsList.ItemsSource = products;

            //}
            //else if (button.Content.ToString() == "CONDOLENCE")
            //{
            //    products = new List<Product>();

            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_cuc.jpg", productName = "Hoa cúc", productPrice = 100 });

            //    DashboardProductsList.ItemsSource = products;

            //}
            //else if (button.Content.ToString() == "Button7")
            //{
            //    products = new List<Product>();

            //    products.Add(new Product { productImage = "/Products/Product Image/hoa_van_tho.png", productName = "Hoa vạn thọ", productPrice = 100 });

            //    DashboardProductsList.ItemsSource = products;

            //}

        }

        private void shiftLeft_Click(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset - 200);
        }

        private void shiftRight_Click(object sender, RoutedEventArgs e)
        {
            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset + 200);
        }

        private void btnDashboardProductIn4_Click(object sender, RoutedEventArgs e)
        {
            ViewDashboardProduct viewDashboardProduct = new ViewDashboardProduct();
            Button btn = sender as Button;
            Product selectedProduct = btn.DataContext as Product;
            viewDashboardProduct.txtblckProductID.Text = selectedProduct.productCode;
            viewDashboardProduct.txtblckProductName.Text = selectedProduct.productName;
            viewDashboardProduct.txtblckProductType.Text = selectedProduct.productType;
            viewDashboardProduct.txtblckEvent.Text = selectedProduct.productOccasion.ToUpper();
            Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
            Database TableRight = new Database("RESULT", "select * from NHA_CUNG_CAP where MANCC = '" + selectedProduct.productSupplier + "'");
            //viewProductDetails.txtblckProductSupplier.Text = selectedProduct.productSupplier;
            viewDashboardProduct.txtblckProductSupplier.Text = TableRight.Rows[0][1].ToString();
            viewDashboardProduct.txtblckProductPrice.Text = selectedProduct.productPrice.ToString();
            string productImage = selectedProduct.productImage.Trim();
            string[] imageParts = productImage.Split('/');
            viewDashboardProduct.viewProductImage.Source = new BitmapImage(new Uri(@"../../Products/Product Image/" + imageParts[imageParts.Length - 1], UriKind.Relative));
            viewDashboardProduct.ShowDialog();
        }


        private void btnShopping_Click(object sender, RoutedEventArgs e)
        {
            isOneProdOnly = true;
            Orders.CreateNewOrder newOrder = new Orders.CreateNewOrder();
            Button btn = sender as Button;
            Product ct = btn.DataContext as Product;
            newOrder.cTHDs.Add(new CTHD
            {
                sttSanPham = stt.ToString(),
                productID = ct.productCode,
                productName = ct.productName,
                productPrice = ct.productPrice,
                productQuantity = 1,
                productTotalMoney = ct.productPrice,
            });
            newOrder.txtblckTotalMoney.Text = ct.productPrice.ToString();
            newOrder.ShowDialog();
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
                        //productName = results.Rows[i][1].ToString(),
                        //productPrice = double.Parse(results.Rows[i][5].ToString()),
                        //productImage = "/Products/Product Image/" + results.Rows[i][6].ToString()
                        productCode = results.Rows[i][0].ToString(),
                        productName = results.Rows[i][1].ToString(),
                        productType = results.Rows[i][2].ToString(),
                        productOccasion = results.Rows[i][3].ToString(),
                        productSupplier = results.Rows[i][4].ToString(),
                        productPrice = double.Parse(results.Rows[i][5].ToString()),
                        productImage = "/Products/Product Image/" + results.Rows[i][6].ToString()
                    });
                }
                //DashboardProductsList.ItemsSource = products;
                view = new Resources.PagingCollectionView(products, 2);

                this.DataContext = view;
                DashboardProductsList.ItemsSource = view;
                //txtDashboardOneOf.Text = "1 of " + products.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadDataViaFilter(List<Product> products, string filter)
        {
            try
            {
                products = new List<Product>();
                string additionalQuery = filter == "ALL"? "" : " where SU_KIEN = '" + filter.ToLower() + "'";
                //if (filter == "ALL")
                //{
                //    Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                //    Database results = new Database("RESULT", "select * from SAN_PHAM");
                //    for(int i = 0; i < results.Rows.Count; i++)
                //    {
                //        products.Add(new Product
                //        {
                //            productName = results.Rows[i][1].ToString(),
                //            productPrice = double.Parse(results.Rows[i][5].ToString()),
                //            productImage = "/Products/Product Image/" + results.Rows[i][6].ToString()
                //        });
                //    }
                //    DashboardProductsList.ItemsSource = products;
                //}
                //else
                //{
                //    Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                //    Database results = new Database("RESULT", "select * from SAN_PHAM where SU_KIEN = '" + filter.ToLower() + "'");
                //    for (int i = 0; i < results.Rows.Count; i++)
                //    {
                //        products.Add(new Product
                //        {
                //            productName = results.Rows[i][1].ToString(),
                //            productPrice = double.Parse(results.Rows[i][5].ToString()),
                //            productImage = "/Products/Product Image/" + results.Rows[i][6].ToString()
                //        });
                //    }
                //    DashboardProductsList.ItemsSource = products;
                //}
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database results = new Database("RESULT", "select * from SAN_PHAM" + additionalQuery);
                for (int i = 0; i < results.Rows.Count; i++)
                {
                    products.Add(new Product
                    {
                        //productName = results.Rows[i][1].ToString(),
                        //productPrice = double.Parse(results.Rows[i][5].ToString()),
                        //productImage = "/Products/Product Image/" + results.Rows[i][6].ToString()
                        productCode = results.Rows[i][0].ToString(),
                        productName = results.Rows[i][1].ToString(),
                        productType = results.Rows[i][2].ToString(),
                        productOccasion = results.Rows[i][3].ToString(),
                        productSupplier = results.Rows[i][4].ToString(),
                        productPrice = double.Parse(results.Rows[i][5].ToString()),
                        productImage = "/Products/Product Image/" + results.Rows[i][6].ToString()
                    });
                }
                //DashboardProductsList.ItemsSource = products;
                view = new Resources.PagingCollectionView(products, 2);

                this.DataContext = view;
                DashboardProductsList.ItemsSource = view;
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

    public class filterButton
    {
        public string buttonContent { get; set; }
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

        /*
         * public string productCode { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
        public string productImage { get; set; }
        public string productOccasion { get; set; }
        public string productType { get; set; }
        public string productSupplier { get; set; }
         */
    }
}
