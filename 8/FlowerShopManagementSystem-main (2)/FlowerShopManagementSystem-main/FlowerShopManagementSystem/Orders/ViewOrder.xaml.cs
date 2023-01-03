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
using System.Windows.Shapes;

namespace FlowerShopManagementSystem.Orders
{
    /// <summary>
    /// Interaction logic for ViewOrder.xaml
    /// </summary>
    public partial class ViewOrder : Window
    {
        List<CTHD> cthds;
        HOA_DON hd1;
        public ViewOrder(HOA_DON hd)
        {
            InitializeComponent();
            cthds = new List<CTHD>();
            hd1 = new HOA_DON(hd);
            LoadData(cthds, hd1);
        }

        private void btnBackViewOrder_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void viewOrderDetailsDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void btnPrintInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Invoice invoice = new Invoice(hd1);
                LoadPrintInvoiceScreen(invoice, hd1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadPrintInvoiceScreen(Invoice invoice, HOA_DON hd)
        {
            invoice.txbBillId.Text = hd.MAHD;
            invoice.txbInvoiceDate.Text = hd.NGHD;
            Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
            Database results = new Database("RESULT", "select * from KHACH_HANG where SODT_KH = '" + hd.SODT_KH + "'"),
                results1 = new Database("RESULT", "select * from NHAN_VIEN where MANV = '" + hd.MANV + "'");
            invoice.txbCustomerName.Text = results.Rows[0][1].ToString();
            invoice.txbCustomerPhoneNumber.Text = hd.SODT_KH;
            invoice.txbTotal.Text = hd.TRIGIA.ToString();
            invoice.txbEmployeeName.Text = results1.Rows[0][1].ToString();
            invoice.ShowDialog();
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            //btnPayment.Visibility = Visibility.Hidden;
            //orderStatusPanel.Visibility = Visibility.Visible;

            //btnPrintInvoice.Opacity = 1;
            //btnPrintInvoice.IsEnabled = true;

            NotificationBox.PaymentConfirmation confirmation = new NotificationBox.PaymentConfirmation();
            confirmation.ShowDialog();
            if (NotificationBox.PaymentConfirmation.isBtnConfirmClicked)
            {
                //HOA_DON selectedHD = (HOA_DON)ordersDataGrid.SelectedItem;
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                using (var sqlConnection = new SqlConnection(Database.connection))
                using (var cmd = new SqlDataAdapter())
                using (var insertCommand = new SqlCommand(
                    "update HOA_DON " +
                    "set TINHTRANG = 'Paid' " +
                    "where MAHD = '" + hd1.MAHD + "'"))
                {
                    insertCommand.Connection = sqlConnection;
                    cmd.InsertCommand = insertCommand;
                    sqlConnection.Open();
                    cmd.InsertCommand.ExecuteNonQuery();
                }
                MessageBox.Show("Done!", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
                btnPayment.Visibility = Visibility.Hidden;
                orderStatusPanel.Visibility = Visibility.Visible;

                btnPrintInvoice.Opacity = 1;
                btnPrintInvoice.IsEnabled = true;
            }
        }

        private void LoadData(List<CTHD> cthds, HOA_DON hd)
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
                viewOrderDetailsDataGrid.ItemsSource = cthds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
