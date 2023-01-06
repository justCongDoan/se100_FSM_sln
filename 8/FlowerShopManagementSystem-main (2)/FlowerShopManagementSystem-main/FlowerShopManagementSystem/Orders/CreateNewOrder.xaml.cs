using FlowerShopManagementSystem.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for CreateNewOrder.xaml
    /// </summary>
    public partial class CreateNewOrder : Window
    {
        internal List<CTHD> cTHDs;
        //public static List<CTHD> cTHDs1 = new List<CTHD>();
        public static CTHD selectedItem;
        public CreateNewOrder()
        {
            InitializeComponent();

            cTHDs = new List<CTHD>();
            //cTHDs = ChooseProduct.cthdList;

            //RemoveTempData();

            LoadData(cTHDs);

            notify.Visibility = Visibility.Hidden;
            findNotify.Visibility = Visibility.Hidden;
        }

        

        private void tbxCustomerPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void chooseProductBtn_Click(object sender, RoutedEventArgs e)
        {
            DashboardView.isOneProdOnly = false;
            ChooseProduct chooseProduct = new ChooseProduct();
            chooseProduct.ShowDialog();
            ReloadData(cTHDs);
        }

        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CTHD ct = (CTHD)orderDetailsDataGrid.SelectedItem;
                //ChooseProduct.total -= long.Parse(ct.productPrice.ToString());
                //Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                //using (var sqlConnection = new SqlConnection(Database.connection))
                //using (var cmd = new SqlDataAdapter())
                //using (var insertCommand = new SqlCommand("delete from TEMPDATA_CTHD where MASP = '" + ct.productID + "'"))
                //{
                //    insertCommand.Connection = sqlConnection;
                //    cmd.InsertCommand = insertCommand;
                //    sqlConnection.Open();
                //    cmd.InsertCommand.ExecuteNonQuery();
                //}
                //cTHDs.Remove(ct);
                ChooseProduct.cthdList.Remove(ct);
                ReloadData(cTHDs);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBackCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            if (tbxEmployeeID.Text == "" || tbxOrderID.Text == "" || tbxCustomerPhone.Text == ""
            || tbxCustomerName.Text == "")
            {
                notify.Visibility = Visibility.Visible;
            }
            else
            {
                if (DashboardView.isOneProdOnly)
                {
                    AddInvoice1();
                    //AddListOfInvoiceDetails();
                    //RemoveTempData();
                    AddListOfInvoiceDetails1();
                    MessageBox.Show("Done!", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                    notify.Visibility = Visibility.Hidden;
                }
                else
                {
                    AddInvoice2();
                    //AddListOfInvoiceDetails();
                    //RemoveTempData();
                    AddListOfInvoiceDetails2();
                    MessageBox.Show("Done!", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                    notify.Visibility = Visibility.Hidden;
                }
            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (tbxOrderID.Text == "" || tbxCustomerPhone.Text == ""
                //|| tbxCustomerName.Text == "" || cTHDs.Count == 0)
                //{
                //    notify.Visibility = Visibility.Visible;

                //}
                //else
                //{
                //    Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                //    Database results = new Database("RESULT", "select HOTEN from KHACH_HANG where SODT_KH = '" + tbxCustomerPhone.Text + "'");
                //    if(results.Rows.Count < 1)
                //    {
                //        MessageBox.Show("There's no customer that matches your search!", "Error alert!", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    }
                //    else
                //    {
                //        tbxCustomerName.Text = results.Rows[0][0].ToString();
                //    }
                //}
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database results = new Database("RESULT", "select HOTEN from KHACH_HANG where SODT_KH = '" + tbxCustomerPhone.Text + "'");
                if (results.Rows.Count < 1)
                {
                    MessageBox.Show("There's no customer that matches your search!", "Error alert!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    tbxCustomerName.Text = results.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void orderDetailsDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //long total = 0;

            //for (int i = 0; i < cTHDs.Count; i++)
            //{
            //    total += long.Parse(cTHDs[i].productTotalMoney.ToString());
            //}

            
            txtblckTotalMoney.Text = GetTotal().ToString();
        }

        private long GetTotal()
        {
            long total = 0;

            for (int i = 0; i < cTHDs.Count; i++)
            {
                total += long.Parse(cTHDs[i].productTotalMoney.ToString());
            }
            return total;
        }

        //private void quantityNumericUD_ValueChanged(object sender, EventArgs e)
        //{
        //    //CTHD ct = (CTHD)orderDetailsDataGrid.SelectedItem as CTHD;
        //    //double totalPrice = ct.productQuantity * ct.productPrice;
        //    //ct.productTotalMoney = totalPrice;
        //    //double total = 0;

        //    //for (int i = 0; i < cTHDs.Count; i++)
        //    //{
        //    //    total += cTHDs[i].productTotalMoney;
        //    //}
        //    ////ReloadData(cTHDs);

        //    //txtblckTotalMoney.Text = total.ToString();
            
        //}

        private void LoadData(List<CTHD> cTHDs)
        {
            //cTHDs.Add(new CTHD { sttSanPham = "1", productID = "SP01", productName = "Hoa hồng", productQuantity = 2, productPrice = 3000, productTotalMoney = 6000 });
            //cTHDs.Add(new CTHD { sttSanPham = "2", productID = "SP01", productName = "Hoa hồng", productQuantity = 2, productPrice = 3000, productTotalMoney = 6000 });
            //cTHDs.Add(new CTHD { sttSanPham = "3", productID = "SP01", productName = "Hoa hồng", productQuantity = 2, productPrice = 3000, productTotalMoney = 6000 });
            //cTHDs.Add(new CTHD { sttSanPham = "4", productID = "SP01", productName = "Hoa hồng", productQuantity = 2, productPrice = 3000, productTotalMoney = 6000 });
            //cTHDs.Add(new CTHD { sttSanPham = "5", productID = "SP01", productName = "Hoa hồng", productQuantity = 2, productPrice = 3000, productTotalMoney = 6000 });
            
            try
            {
                //Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                //Database results = new Database("RESULT", "select * from TEMPDATA_CTHD");
                //for(int i = 0; i < results.Rows.Count; i++)
                //{
                //    cTHDs.Add(new CTHD
                //    {
                //        sttSanPham = (i+1).ToString(),
                //        productID = results.Rows[i][0].ToString(),
                //        productName = results.Rows[i][1].ToString(),
                //        productQuantity = int.Parse(results.Rows[i][2].ToString()),
                //        productPrice = double.Parse(results.Rows[i][3].ToString()),
                //        productTotalMoney = double.Parse(results.Rows[i][4].ToString())
                //    });
                //}
                ////Database results1 = new Database("RESULT", "select sum(TRIGIA) as TOTALPRICE from TEMPDATA_CTHD");
                ////long total = long.Parse(results1.Rows[0][0].ToString());
                ////txtblckTotalMoney.Text = GetTotal().ToString();//total.ToString();
                //orderDetailsDataGrid.ItemsSource = cTHDs;
                //foreach(var item in ChooseProduct.cthdList)
                //{
                //    cTHDs.Add(item);
                //}
                orderDetailsDataGrid.ItemsSource = cTHDs;
                //txtblckTotalMoney.Text = GetSumOfPrice().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void ReloadData(List<CTHD> cTHDs)
        {
            try
            {
                //cTHDs = new List<CTHD>();
                if (ChooseProduct.isListEmpty)
                {
                    cTHDs = new List<CTHD>();
                }
                else
                {
                    cTHDs = ChooseProduct.cthdList;
                }
                LoadData(cTHDs);
                //Database results1 = new Database("RESULT", "select sum(TRIGIA) as TOTALPRICE from TEMPDATA_CTHD");
                //long total = long.Parse(results1.Rows[0][0].ToString());
                ////txtblckTotalMoney.Text = GetTotal().ToString();
                //txtblckTotalMoney.Text = total.ToString();
                //txtblckTotalMoney.Text = ChooseProduct.total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void tbxEmployeeID_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxOrderID_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
        }

        private void tbxCustomerPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            notify.Visibility = Visibility.Hidden;
            findNotify.Visibility = Visibility.Hidden;
        }

        //private void btnProductIn4_Click(object sender, RoutedEventArgs e)
        //{
        //    Products.ViewProductDetails viewProductDetails = new Products.ViewProductDetails();
        //    viewProductDetails.ShowDialog();
        //}

        private void btnEditProductIn4_Click(object sender, RoutedEventArgs e)
        {
            //cTHDs1 = cTHDs;
            ProductIn4 productIn4 = new ProductIn4();
            CTHD ct = (CTHD)orderDetailsDataGrid.SelectedItem;
            productIn4.txtblckProductID.Text = ct.productID;
            productIn4.txtblckProductName.Text = ct.productName;
            productIn4.txtblckProductPrice.Text = ct.productPrice.ToString();
            productIn4.tb_main.Text = "1";
            //productIn4.priceTB.Text = ct.productPrice.ToString();
            Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
            Database results = new Database("RESULT", "select HINH_ANH from SAN_PHAM where MASP = '" + ct.productID + "'");
            /*
             * string productImage = selectedProduct.productImage.Trim();
            string[] imageParts = productImage.Split('/');
             */
            productIn4.viewProductImage.Source = new BitmapImage(new Uri(@"../../Products/Product Image/" + results.Rows[0][0].ToString(), UriKind.Relative));
            productIn4.ShowDialog();
        }

        private void AddInvoice1()
        {
            if(ChooseProduct.cthdList == null && cTHDs == null)
            {
                MessageBox.Show("The order must not be empty!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (cTHDs != null)
                {
                    Add_cTHDs(cTHDs);
                }
                else if (ChooseProduct.cthdList != null)
                {
                    Add_cthdList(ChooseProduct.cthdList);
                }
            }
            
        }

        private void AddInvoice2()
        {
            //if(ChooseProduct.cthdList == null && cTHDs == null)
            //{
            //    MessageBox.Show("The order must not be empty!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            //else
            //{
            //    if (cTHDs != null)
            //    {
            //        Add_cTHDs(cTHDs);
            //    }
            //    else if (ChooseProduct.cthdList != null)
            //    {
            //        Add_cthdList(ChooseProduct.cthdList);
            //    }
            //}
            if (ChooseProduct.cthdList == null)
            {
                MessageBox.Show("The order must not be empty!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string order_id = tbxOrderID.Text.ToString(),
                customer_phone = tbxCustomerPhone.Text.ToString(),
                employee_id = tbxEmployeeID.Text.ToString();
                double totalMoney = 0;
                foreach (var item in ChooseProduct.cthdList)
                {
                    totalMoney += item.productTotalMoney;
                }
                string strTotalMoney = totalMoney.ToString();
                string order_status = "Unpaid";
                try
                {
                    using (var sqlConnection = new SqlConnection(Database.connection))
                    using (var cmd = new SqlDataAdapter())
                    using (var insertCommand = new SqlCommand("insert into HOA_DON(MAHD, NGHD, SODT_KH, MANV, TRIGIA, TINHTRANG) " +
                        "values ('" + order_id + "', '" + DateTime.Now.ToString() + "', '" + customer_phone + "', '" + employee_id + "', '" + strTotalMoney + "', '" + order_status + "')"))
                    {
                        insertCommand.Connection = sqlConnection;
                        cmd.InsertCommand = insertCommand;
                        sqlConnection.Open();
                        cmd.InsertCommand.ExecuteNonQuery();
                    }
                    //MessageBox.Show("Done!", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
                    //Close();
                    //AddListOfInvoiceDetails();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void Add_cthdList(List<CTHD> cthdList)
        {
            string order_id = tbxOrderID.Text.ToString(),
                customer_phone = tbxCustomerPhone.Text.ToString(),
                employee_id = tbxEmployeeID.Text.ToString();
            double totalMoney = 0;
            foreach (var item in ChooseProduct.cthdList)
            {
                totalMoney += item.productTotalMoney;
            }
            string strTotalMoney = totalMoney.ToString();
            string order_status = "Unpaid";
            try
            {
                using (var sqlConnection = new SqlConnection(Database.connection))
                using (var cmd = new SqlDataAdapter())
                using (var insertCommand = new SqlCommand("insert into HOA_DON(MAHD, NGHD, SODT_KH, MANV, TRIGIA, TINHTRANG) " +
                    "values ('" + order_id + "', '" + DateTime.Now.ToString() + "', '" + customer_phone + "', '" + employee_id + "', '" + strTotalMoney + "', '" + order_status + "')"))
                {
                    insertCommand.Connection = sqlConnection;
                    cmd.InsertCommand = insertCommand;
                    sqlConnection.Open();
                    cmd.InsertCommand.ExecuteNonQuery();
                }
                //MessageBox.Show("Done!", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
                //Close();
                //AddListOfInvoiceDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Add_cTHDs(List<CTHD> cTHDs)
        {
            string order_id = tbxOrderID.Text.ToString(),
                customer_phone = tbxCustomerPhone.Text.ToString(),
                employee_id = tbxEmployeeID.Text.ToString();
            double totalMoney = 0;
            foreach (var item in cTHDs)
            {
                totalMoney += item.productTotalMoney;
            }
            string strTotalMoney = totalMoney.ToString();
            string order_status = "Unpaid";
            try
            {
                using (var sqlConnection = new SqlConnection(Database.connection))
                using (var cmd = new SqlDataAdapter())
                using (var insertCommand = new SqlCommand("insert into HOA_DON(MAHD, NGHD, SODT_KH, MANV, TRIGIA, TINHTRANG) " +
                    "values ('" + order_id + "', '" + DateTime.Now.ToString() + "', '" + customer_phone + "', '" + employee_id + "', '" + strTotalMoney + "', '" + order_status + "')"))
                {
                    insertCommand.Connection = sqlConnection;
                    cmd.InsertCommand = insertCommand;
                    sqlConnection.Open();
                    cmd.InsertCommand.ExecuteNonQuery();
                }
                //MessageBox.Show("Done!", "Message:", MessageBoxButton.OK, MessageBoxImage.Information);
                //Close();
                //AddListOfInvoiceDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddListOfInvoiceDetails1()
        {
            if (ChooseProduct.cthdList == null && cTHDs == null)
            {
                MessageBox.Show("Cannot add an empty list!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if(cTHDs != null)
                {
                    foreach (var item in cTHDs)
                    {
                        AddInvoiceDetails(item);
                    }
                }
                else if (ChooseProduct.cthdList != null)
                {
                    foreach (var item in ChooseProduct.cthdList)
                    {
                        AddInvoiceDetails(item);
                    }
                }
            }
            
            //for (int i = 0; i < cTHDs.Count; i++)
            //{
            //    AddInvoiceDetails(cTHDs[i]);
            //}
        }

        private void AddListOfInvoiceDetails2()
        {
            //if (ChooseProduct.cthdList == null && cTHDs == null)
            //{
            //    MessageBox.Show("Cannot add an empty list!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            //else
            //{
            //    if(cTHDs != null)
            //    {
            //        foreach (var item in cTHDs)
            //        {
            //            AddInvoiceDetails(item);
            //        }
            //    }
            //    else if (ChooseProduct.cthdList != null)
            //    {
            //        foreach (var item in ChooseProduct.cthdList)
            //        {
            //            AddInvoiceDetails(item);
            //        }
            //    }
            //}

            if (ChooseProduct.cthdList == null)
            {
                MessageBox.Show("Cannot add an empty list!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                foreach (var item in ChooseProduct.cthdList)
                {
                    AddInvoiceDetails(item);
                }
            }

            //for (int i = 0; i < cTHDs.Count; i++)
            //{
            //    AddInvoiceDetails(cTHDs[i]);
            //}
        }

        private void AddInvoiceDetails(CTHD ct)
        {
            string order_id = tbxOrderID.Text.ToString(),
                product_id = ct.productID.ToString(),
                quantity = ct.productQuantity.ToString(),
                strTotalMoney = ct.productTotalMoney.ToString();
            try
            {
                using (var sqlConnection = new SqlConnection(Database.connection))
                using (var cmd = new SqlDataAdapter())
                using (var insertCommand = new SqlCommand("insert into CTHD(MAHD, MASP, SL, TONGTRIGIA) " +
                    "values ('" + order_id + "', '" + product_id + "', '" + quantity + "', '" + strTotalMoney + "')"))
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

        private double GetSumOfPrice()
        {
            double total = 0;
            try
            {
                //using (var sqlConnection = new SqlConnection(Database.connection))
                //using (var cmd = new SqlDataAdapter())
                //using (var insertCommand = new SqlCommand("delete from TEMPDATA_CTHD"))
                //{
                //    insertCommand.Connection = sqlConnection;
                //    cmd.InsertCommand = insertCommand;
                //    sqlConnection.Open();
                //    cmd.InsertCommand.ExecuteNonQuery();
                //}
                foreach (var item in cTHDs)
                {
                    total += double.Parse(item.productTotalMoney.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return total;
        }
    }

    public class CTHD
    {
        public string sttSanPham { get; set; }
        public string productID { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
        public int productQuantity { get; set; }
        public double productTotalMoney { get; set; }

        
    }
}
