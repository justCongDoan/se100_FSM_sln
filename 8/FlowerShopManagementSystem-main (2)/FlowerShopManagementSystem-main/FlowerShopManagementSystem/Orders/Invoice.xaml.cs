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

namespace FlowerShopManagementSystem.Orders
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {
        List<CTHD> cthds;
        HOA_DON hd1;
        public Invoice(HOA_DON hd)
        {
            InitializeComponent();
            cthds = new List<CTHD>();
            hd1 = new HOA_DON(hd);
            LoadInvoiceDetails(cthds, hd1);
        }

        private void wdBillTemplate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void invoiceDetails_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnPrint.Visibility = Visibility.Hidden;
                PrintDialog printDialog = new PrintDialog();

                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(grdPrint, "Invoice");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadInvoiceDetails(List<CTHD> cthds, HOA_DON hd)
        {
            try
            {
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database results = new Database("RESULT", "select * from CTHD where MAHD = '" + hd.MAHD + "'"),
                    result1;
                for (int i = 0; i < results.Rows.Count; i++)
                {
                    result1 = new Database("RESULT1", "select * from SAN_PHAM where MASP = '" + results.Rows[i][1].ToString() + "'");
                    cthds.Add(new CTHD
                    {
                        sttSanPham = (i + 1).ToString(),
                        productID = results.Rows[i][1].ToString(),
                        productName = result1.Rows[0][1].ToString(),
                        productPrice = double.Parse(result1.Rows[0][5].ToString()),
                        productQuantity = int.Parse(results.Rows[i][2].ToString()),
                        productTotalMoney = double.Parse(results.Rows[i][3].ToString()),
                    });
                }
                invoiceDetails.ItemsSource = cthds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
