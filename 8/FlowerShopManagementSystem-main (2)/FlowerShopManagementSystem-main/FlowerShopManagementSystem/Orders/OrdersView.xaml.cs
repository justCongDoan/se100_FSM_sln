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

namespace FlowerShopManagementSystem.Orders
{
    /// <summary>
    /// Interaction logic for OrdersView.xaml
    /// </summary>
    public partial class OrdersView : Page
    {
        List<HOA_DON> hoadons;
        private Resources.PagingCollectionView view;
        public OrdersView()
        {
            InitializeComponent();

            hoadons = new List<HOA_DON>();

            //hoadons.Add(new HOA_DON { MAHD = "HD01", NGHD = DateTime.Now.ToString(), SODT_KH = "0123456789", MANV = "NV01", TRIGIA = 1000000, sttHD = 1, TINHTRANG = "Paid"});
            //hoadons.Add(new HOA_DON { MAHD = "HD02", NGHD = DateTime.Now.ToString(), SODT_KH = "0123456789", MANV = "NV02", TRIGIA = 1000000, sttHD = 2, TINHTRANG = "Unpaid" });
            //hoadons.Add(new HOA_DON { MAHD = "HD03", NGHD = DateTime.Now.ToString(), SODT_KH = "0123456789", MANV = "NV03", TRIGIA = 1000000, sttHD = 3, TINHTRANG = "Paid" });
            //hoadons.Add(new HOA_DON { MAHD = "HD04", NGHD = DateTime.Now.ToString(), SODT_KH = "0123456789", MANV = "NV04", TRIGIA = 1000000, sttHD = 4, TINHTRANG = "Unpaid" });
            //hoadons.Add(new HOA_DON { MAHD = "HD05", NGHD = DateTime.Now.ToString(), SODT_KH = "0123456789", MANV = "NV05", TRIGIA = 1000000, sttHD = 5, TINHTRANG = "Paid" });
            //hoadons.Add(new HOA_DON { MAHD = "HD06", NGHD = DateTime.Now.ToString(), SODT_KH = "0123456789", MANV = "NV06", TRIGIA = 1000000, sttHD = 6, TINHTRANG = "Unpaid" });
            //hoadons.Add(new HOA_DON { MAHD = "HD07", NGHD = DateTime.Now.ToString(), SODT_KH = "0123456789", MANV = "NV07", TRIGIA = 1000000, sttHD = 7, TINHTRANG = "Paid" });
            //hoadons.Add(new HOA_DON { MAHD = "HD08", NGHD = DateTime.Now.ToString(), SODT_KH = "0123456789", MANV = "NV08", TRIGIA = 1000000, sttHD = 8, TINHTRANG = "Unpaid" });

            //ordersDataGrid.ItemsSource = hoadons;
            LoadData(hoadons);

        }

        private void btnAddNewOrder_Click(object sender, RoutedEventArgs e)
        {
            CreateNewOrder createNewOrder = new CreateNewOrder();
            createNewOrder.ShowDialog();
            ReloadData(hoadons);
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HOA_DON hd = (HOA_DON)ordersDataGrid.SelectedItem as HOA_DON;
            LoadViewInvoiceScreen(hd);
        }

        private void LoadViewInvoiceScreen(HOA_DON hd)
        {
            ViewOrder view = new ViewOrder(hd);
            view.txtblckOrderEmployeeID.Text = hd.MANV.ToString();
            view.txtblckOrderID.Text = hd.MAHD.ToString();
            view.txtblckOrderCustomerPhone.Text = hd.SODT_KH.ToString();
            Database results = new Database("RESULT", "select * from KHACH_HANG where SODT_KH = '" + hd.SODT_KH + "'");
            view.txtblckOrderCustomerName.Text = results.Rows[0][1].ToString();
            view.txtblckTotalMoney.Text = hd.TRIGIA.ToString();
            view.ShowDialog();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HOA_DON hd = (HOA_DON)ordersDataGrid.SelectedItem as HOA_DON;
                if(hd.TINHTRANG == "Unpaid")
                {
                    MessageBox.Show("Please pay for the order (or edit it first),\nthen print the invoice!", "Message:", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Please wait...", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
                    Invoice invoice = new Invoice(hd);
                    LoadPrintInvoiceScreen(invoice, hd);
                }
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

        private void btnEditOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HOA_DON hd = (HOA_DON)ordersDataGrid.SelectedItem as HOA_DON;
                if (hd.TINHTRANG == "Paid")
                {
                    MessageBox.Show("You have already paid for the order!", "Message:", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    //MessageBox.Show("Please wait...", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
                    EditOrder edit = new EditOrder(hd);
                    LoadEditScreen(edit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadEditScreen(EditOrder edit)
        {
            HOA_DON hd = (HOA_DON)ordersDataGrid.SelectedItem;
            edit.tbxEditEmployeeID.Text = hd.MANV;
            edit.tbxEditOrderID.Text = hd.MAHD;
            edit.tbxEditCustomerPhone.Text = hd.SODT_KH;
            Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
            Database results = new Database("RESULT", "select HOTEN from KHACH_HANG where SODT_KH = '" + hd.SODT_KH + "'");
            edit.tbxEditCustomerName.Text = results.Rows[0][0].ToString();
            edit.txtblckTotalMoney.Text = hd.TRIGIA.ToString();
            edit.ShowDialog();
            ReloadData(hoadons);
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HOA_DON hd = (HOA_DON)ordersDataGrid.SelectedItem as HOA_DON;
                if (hd.TINHTRANG == "Paid")
                {
                    MessageBox.Show("You have already paid for the order!", "Message:", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    //MessageBox.Show("Please wait...", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
                    //NotificationBox.PaymentConfirmation confirmation = new NotificationBox.PaymentConfirmation();
                    //confirmation.ShowDialog();
                    //if(NotificationBox.PaymentConfirmation.isBtnConfirmClicked)
                    //{
                    //    //HOA_DON selectedHD = (HOA_DON)ordersDataGrid.SelectedItem;
                    //    Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                    //    using (var sqlConnection = new SqlConnection(Database.connection))
                    //    using (var cmd = new SqlDataAdapter())
                    //    using (var insertCommand = new SqlCommand(
                    //        "update HOA_DON " +
                    //        "set TINHTRANG = 'Paid' " +
                    //        "where MAHD = '" + hd.MAHD + "'"))
                    //    {
                    //        insertCommand.Connection = sqlConnection;
                    //        cmd.InsertCommand = insertCommand;
                    //        sqlConnection.Open();
                    //        cmd.InsertCommand.ExecuteNonQuery();
                    //    }
                    //    MessageBox.Show("Done!", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
                    //}
                    LoadViewInvoiceScreen(hd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadData(List<HOA_DON> hoadons)
        {
            try
            {
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database results = new Database("RESULT", "select * from HOA_DON");
                for (int i = 0; i < results.Rows.Count; i++)
                {
                    hoadons.Add(new HOA_DON
                    {
                        sttHD = i + 1,
                        MAHD = results.Rows[i][0].ToString(),
                        NGHD = results.Rows[i][1].ToString(),
                        SODT_KH = results.Rows[i][2].ToString(),
                        MANV = results.Rows[i][3].ToString(),
                        TRIGIA = double.Parse(results.Rows[i][4].ToString()),
                        TINHTRANG = results.Rows[i][5].ToString()
                    });
                    
                }
                //ordersDataGrid.ItemsSource = hoadons;
                //txtOrdersOneOf.Text = "1 of " + hoadons.Count.ToString();
                view = new Resources.PagingCollectionView(hoadons, 2);

                this.DataContext = view;
                ordersDataGrid.ItemsSource = view;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReloadData(List<HOA_DON> hoadons)
        {
            try
            {
                hoadons = new List<HOA_DON>();
                LoadData(hoadons);
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

    public class HOA_DON
    {
        public int sttHD { get; set; }
        public string MAHD { get; set; }
        public string NGHD { get; set; }
        public string SODT_KH { get; set; }
        public string MANV { get; set; }
        public double TRIGIA { get; set; }
        public string TINHTRANG { get; set; }

        public HOA_DON()
        {

        }

        public HOA_DON(HOA_DON hd)
        {
            sttHD = hd.sttHD;
            MAHD = hd.MAHD;
            NGHD = hd.NGHD;
            SODT_KH = hd.SODT_KH;
            MANV = hd.MANV;
            TRIGIA = hd.TRIGIA;
            TINHTRANG = hd.TINHTRANG;
        }
    }
}
