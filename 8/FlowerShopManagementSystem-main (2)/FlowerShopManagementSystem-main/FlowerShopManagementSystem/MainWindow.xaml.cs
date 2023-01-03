using System.Collections.ObjectModel;
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

namespace FlowerShopManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isLogout = false;

        private bool isMaximized = false;

        private int Dashboard = 0,
                    Products = 1,
                    Suppliers = 2,
                    Orders = 3,
                    Customers = 4,
                    Accounts = 5,
                    statistics = 6;

        private int isSelected = -1;

        public MainWindow()
        {
            InitializeComponent();
            Dashboard.DashboardView dashboard = new Dashboard.DashboardView();
            frame.Content = dashboard;
            isSelected = Dashboard;
            //avatar.ImageSource = new BitmapImage(new System.Uri("pack://application:,,,/Images/Person.jpg"));
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ChangedButton == MouseButton.Left)
            //{
            //    this.DragMove();
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            //Login login = new Login();
            //login.Show();
            //this.Close();

            NotificationBox.LogoutConfirmationBox logoutConfirmationBox = new NotificationBox.LogoutConfirmationBox();
            logoutConfirmationBox.ShowDialog();

            if (isLogout)
            {
                this.Close();
            }
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            if (isSelected != Dashboard)
            {
                Dashboard.DashboardView dashboardView = new Dashboard.DashboardView();
                frame.Content = dashboardView;

                ChangeButtonStyle();

                isSelected = Dashboard;

                BrushConverter bc = new BrushConverter();
                btnDashboard.Foreground = (Brush)bc.ConvertFrom("#008851");
                btnDashboard.Background = Brushes.White;
            }
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            if (isSelected != Products)
            {
                Products.ProductsView productsView = new Products.ProductsView();
                frame.Content = productsView;

                ChangeButtonStyle();

                isSelected = Products;

                BrushConverter bc = new BrushConverter();
                btnProducts.Foreground = (Brush)bc.ConvertFrom("#008851");
                btnProducts.Background = Brushes.White;
            }
        }

        private void btnDashboard_MouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            btnDashboard.Foreground = (Brush)bc.ConvertFrom("#008851");
            btnDashboard.Background = Brushes.White;
        }

        private void btnDashboard_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isSelected != Dashboard)
            {
                BrushConverter bc = new BrushConverter();
                btnDashboard.Background = (Brush)bc.ConvertFrom("#008851");
                btnDashboard.Foreground = Brushes.White;
            }
        }

        private void btnProducts_MouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            btnProducts.Foreground = (Brush)bc.ConvertFrom("#008851");
            btnProducts.Background = Brushes.White;
        }

        private void btnProducts_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isSelected != Products)
            {
                BrushConverter bc = new BrushConverter();
                btnProducts.Background = (Brush)bc.ConvertFrom("#008851");
                btnProducts.Foreground = Brushes.White;
            }
        }

        private void btnSuppliers_MouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            btnSuppliers.Foreground = (Brush)bc.ConvertFrom("#008851");
            btnSuppliers.Background = Brushes.White;
        }

        private void btnSuppliers_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isSelected != Suppliers)
            {
                BrushConverter bc = new BrushConverter();
                btnSuppliers.Background = (Brush)bc.ConvertFrom("#008851");
                btnSuppliers.Foreground = Brushes.White;
            }
        }

        private void btnOrders_MouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            btnOrders.Foreground = (Brush)bc.ConvertFrom("#008851");
            btnOrders.Background = Brushes.White;
        }

        private void btnOrders_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isSelected != Orders)
            {
                BrushConverter bc = new BrushConverter();
                btnOrders.Background = (Brush)bc.ConvertFrom("#008851");
                btnOrders.Foreground = Brushes.White;
            }
        }

        private void btnCustomers_MouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            btnCustomers.Foreground = (Brush)bc.ConvertFrom("#008851");
            btnCustomers.Background = Brushes.White;
        }

        private void btnCustomers_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isSelected != Customers)
            {
                BrushConverter bc = new BrushConverter();
                btnCustomers.Background = (Brush)bc.ConvertFrom("#008851");
                btnCustomers.Foreground = Brushes.White;
            }
        }

        private void btnAccounts_MouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            btnAccounts.Foreground = (Brush)bc.ConvertFrom("#008851");
            btnAccounts.Background = Brushes.White;
        }

        private void btnAccounts_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isSelected != Accounts)
            {
                BrushConverter bc = new BrushConverter();
                btnAccounts.Background = (Brush)bc.ConvertFrom("#008851");
                btnAccounts.Foreground = Brushes.White;
            }
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (isMaximized)
            {
                this.WindowState = WindowState.Normal;
                this.Width = 1080;
                this.Height = 720;

                isMaximized = false;
            }
            else
            {
                this.WindowState = WindowState.Maximized;

                isMaximized = true;
            }
        }

        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            if (isSelected != statistics)
            {
                Statistics.StatisticsView statisticsView = new Statistics.StatisticsView();
                frame.Content = statisticsView;

                ChangeButtonStyle();

                isSelected = statistics;

                BrushConverter bc = new BrushConverter();
                btnStatistics.Foreground = (Brush)bc.ConvertFrom("#008851");
                btnStatistics.Background = Brushes.White;
            }
        }

        private void btnStatistics_MouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            btnStatistics.Foreground = (Brush)bc.ConvertFrom("#008851");
            btnStatistics.Background = Brushes.White;
        }

        private void btnStatistics_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isSelected != statistics)
            {
                BrushConverter bc = new BrushConverter();
                btnStatistics.Background = (Brush)bc.ConvertFrom("#008851");
                btnStatistics.Foreground = Brushes.White;
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            if (isSelected != Suppliers)
            {
                Suppliers.SuppliersView suppliersView = new Suppliers.SuppliersView();
                frame.Content = suppliersView;

                ChangeButtonStyle();

                isSelected = Suppliers;

                BrushConverter bc = new BrushConverter();
                btnSuppliers.Foreground = (Brush)bc.ConvertFrom("#008851");
                btnSuppliers.Background = Brushes.White;
            }
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            if (isSelected != Orders)
            {
                Orders.OrdersView ordersView = new Orders.OrdersView();
                frame.Content = ordersView;

                ChangeButtonStyle();

                isSelected = Orders;

                BrushConverter bc = new BrushConverter();
                btnOrders.Foreground = (Brush)bc.ConvertFrom("#008851");
                btnOrders.Background = Brushes.White;
            }
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            if (isSelected != Customers)
            {
                Customers.CustomersView customersView = new Customers.CustomersView();
                frame.Content = customersView;

                ChangeButtonStyle();

                isSelected = Customers;

                BrushConverter bc = new BrushConverter();
                btnCustomers.Foreground = (Brush)bc.ConvertFrom("#008851");
                btnCustomers.Background = Brushes.White;
            }
        }

        private void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            if (isSelected != Accounts)
            {
                Accounts.AccountsView accountsView = new Accounts.AccountsView();
                frame.Content = accountsView;

                ChangeButtonStyle();

                isSelected = Accounts;

                BrushConverter bc = new BrushConverter();
                btnAccounts.Foreground = (Brush)bc.ConvertFrom("#008851");
                btnAccounts.Background = Brushes.White;
            }
        }

        private void ChangeButtonStyle()
        {
            switch (isSelected)
            {
                case 0:
                    {
                        BrushConverter bc = new BrushConverter();
                        btnDashboard.Background = (Brush)bc.ConvertFrom("#008851");
                        btnDashboard.Foreground = Brushes.White;

                        break;
                    }
                case 1:
                    {
                        BrushConverter bc = new BrushConverter();
                        btnProducts.Background = (Brush)bc.ConvertFrom("#008851");
                        btnProducts.Foreground = Brushes.White;

                        break;
                    }
                case 2:
                    {
                        BrushConverter bc = new BrushConverter();
                        btnSuppliers.Background = (Brush)bc.ConvertFrom("#008851");
                        btnSuppliers.Foreground = Brushes.White;

                        break;
                    }
                case 3:
                    {
                        BrushConverter bc = new BrushConverter();
                        btnOrders.Background = (Brush)bc.ConvertFrom("#008851");
                        btnOrders.Foreground = Brushes.White;

                        break;
                    }
                case 4:
                    {
                        BrushConverter bc = new BrushConverter();
                        btnCustomers.Background = (Brush)bc.ConvertFrom("#008851");
                        btnCustomers.Foreground = Brushes.White;

                        break;
                    }
                case 5:
                    {
                        BrushConverter bc = new BrushConverter();
                        btnAccounts.Background = (Brush)bc.ConvertFrom("#008851");
                        btnAccounts.Foreground = Brushes.White;

                        break;
                    }
                case 6:
                    {
                        BrushConverter bc = new BrushConverter();
                        btnStatistics.Background = (Brush)bc.ConvertFrom("#008851");
                        btnStatistics.Foreground = Brushes.White;

                        break;
                    }
            }
        }
    }
}       
