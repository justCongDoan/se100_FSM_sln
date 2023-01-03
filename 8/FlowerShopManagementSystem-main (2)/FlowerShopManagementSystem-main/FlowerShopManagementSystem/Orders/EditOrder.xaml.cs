using FlowerShopManagementSystem.Suppliers;
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

namespace FlowerShopManagementSystem.Orders
{
    /// <summary>
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        List<CTHD> cthds;
        HOA_DON hd1;
        public EditOrder(HOA_DON hd)
        {
            InitializeComponent();

            cthds = new List<CTHD>();
            hd1 = new HOA_DON(hd);
            LoadData(cthds, hd1);
        }

        private void btnEditFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database results = new Database("RESULT", "select HOTEN from KHACH_HANG where SODT_KH = '" + tbxEditCustomerPhone.Text + "'");
                if (results.Rows.Count < 1)
                {
                    MessageBox.Show("There's no customer that matches your search!", "Error alert!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    tbxEditCustomerName.Text = results.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            UpdateOrder();
        }

        private void btnBackEditOrder_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void editChooseProductBtn_Click(object sender, RoutedEventArgs e)
        {
            ChooseProduct chooseProduct = new ChooseProduct();
            chooseProduct.ShowDialog();
        }

        private void tbxEditCustomerPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void editOrderDetailsDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }


        private void btnEditRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CTHD ct = (CTHD)editOrderDetailsDataGrid.SelectedItem;
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                using (var sqlConnection = new SqlConnection(Database.connection))
                using (var cmd = new SqlDataAdapter())
                using (var insertCommand = new SqlCommand("delete from CTHD where MAHD = '" + hd1.MAHD + "' and MASP = '" + ct.productID + "'"))
                {
                    insertCommand.Connection = sqlConnection;
                    cmd.InsertCommand = insertCommand;
                    sqlConnection.Open();
                    cmd.InsertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //btnBackEditOrder.Visibility = Visibility.Collapsed;
            ReloadData(cthds, hd1);
            txtblckTotalMoney.Text = RecalculateMoney().ToString();
            ReplacePrice();
        }

        private double RecalculateMoney()
        {
            double money = 0;
            try
            {
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database results = new Database("RESULT", "select sum(TONGTRIGIA) from CTHD where MAHD = '" + hd1.MAHD + "'");
                //txtblckTotalMoney.Text = results.Rows[0][0].ToString();
                money = double.Parse(results.Rows[0][0].ToString());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return money;
        }

        private void ReplacePrice()
        {
            try
            {
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                using (var sqlConnection = new SqlConnection(Database.connection))
                using (var cmd = new SqlDataAdapter())
                using (var insertCommand = new SqlCommand(
                    "update HOA_DON " +
                    "set TRIGIA = '" + RecalculateMoney().ToString() + "' " +
                    "where MAHD = '" + hd1.MAHD + "'"))
                {
                    insertCommand.Connection = sqlConnection;
                    cmd.InsertCommand = insertCommand;
                    sqlConnection.Open();
                    cmd.InsertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadData(List<CTHD> cthds, HOA_DON hd)
        {
            try
            {
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database results = new Database("RESULT", "select * from CTHD where MAHD = '" + hd.MAHD + "'"),
                    result1;
                for(int i = 0; i < results.Rows.Count; i++)
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
                editOrderDetailsDataGrid.ItemsSource = cthds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReloadData(List<CTHD> cthds, HOA_DON hd)
        {
            try
            {
                cthds = new List<CTHD>();
                LoadData(cthds, hd1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateOrder()
        {
            try
            {
                using (var sqlConnection = new SqlConnection(Database.connection))
                using (var cmd = new SqlDataAdapter())
                using (var insertCommand = new SqlCommand(
                    "update HOA_DON " +
                    "set NGHD = '" + DateTime.Now.ToString() + "', " +
                        "SODT_KH = '" + tbxEditCustomerPhone.Text.ToString() + "', " +
                        "MANV = '" + tbxEditEmployeeID.Text.ToString() + "', " +
                        "TRIGIA = '" + txtblckTotalMoney.Text.ToString() + "', " +
                        "TINHTRANG = 'Unpaid' " +
                        "where MAHD = '" + hd1.MAHD + "'"))
                {
                    insertCommand.Connection = sqlConnection;
                    cmd.InsertCommand = insertCommand;
                    sqlConnection.Open();
                    cmd.InsertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
