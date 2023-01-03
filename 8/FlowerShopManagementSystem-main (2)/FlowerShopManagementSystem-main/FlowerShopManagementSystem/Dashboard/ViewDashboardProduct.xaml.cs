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
using System.Windows.Shapes;

namespace FlowerShopManagementSystem.Dashboard
{
    /// <summary>
    /// Interaction logic for ViewDashboardProduct.xaml
    /// </summary>
    public partial class ViewDashboardProduct : Window
    {
        public ViewDashboardProduct()
        {
            InitializeComponent();
        }

        private void btnBackViewDashboardProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBackCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            Orders.CreateNewOrder createNewOrder = new Orders.CreateNewOrder();
            createNewOrder.ShowDialog();

            this.Close();
        }
    }
}
