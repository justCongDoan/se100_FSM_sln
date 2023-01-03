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
using System.Collections.ObjectModel;
using FlowerShopManagementSystem.NotificationBox;
using System.Data.SqlClient;

namespace FlowerShopManagementSystem.Customers
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : Page
    {
        List<Customer> customers;
        DeleteConfirmationBox deleteConfirmationBox;
        private Resources.PagingCollectionView view;
        public CustomersView()
        {
            InitializeComponent();

            customers = new List<Customer>();
            LoadData(customers);
            //tbxCustomersOneOf.Text = "1 of " + customers.Count.ToString();

        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customers.AddCustomerForm addCustomerForm = new Customers.AddCustomerForm();
            addCustomerForm.ShowDialog();
            ReloadData(customers);

            //Customers.ViewCustomerDetails addCustomerForm = new Customers.ViewCustomerDetails();
            //addCustomerForm.ShowDialog();
        }

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customers.EditCustomerForm editCustomerForm = new Customers.EditCustomerForm();
            Customer oldInfo = (Customer)customersDataGrid.SelectedItem;
            string name = oldInfo.name.Trim();
            string phoneNumber = oldInfo.phone.Trim();
            string addressInfo = oldInfo.address.ToString();
            string[] addressParts = addressInfo.Split(',');
            string homeNumber = addressParts[0].Trim(),
                street = addressParts[1].Trim(),
                disrict = addressParts[2].Trim(),
                city = addressParts[3].Trim(),
                province = "(Empty)";
            string sales = oldInfo.doanhSo.ToString();
            string regDate = String.Format("{0:d}", oldInfo.ngayDK);
            editCustomerForm.tbxEditCustomerName.Text = name;
            editCustomerForm.tbxEditCustomerPhone.Text = phoneNumber;
            editCustomerForm.dpkEditRegistrationDate.Text = regDate;
            editCustomerForm.tbxEditCustomerSales.Text = sales;
            editCustomerForm.tbxEditCustomerHouseNumber.Text = homeNumber;
            editCustomerForm.tbxEditCustomerStreet.Text = street;
            editCustomerForm.cbbEditDistrict.Text = disrict;
            editCustomerForm.cbbEditCity.Text = city;
            editCustomerForm.cbbEditProvince.Text = province;
            editCustomerForm.ShowDialog();
            ReloadData(customers);
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            deleteConfirmationBox = new DeleteConfirmationBox();
            deleteConfirmationBox.ShowDialog();
            if (DeleteConfirmationBox.isDeleteBtnClicked)
            {
                try
                {
                    Customer customer = (Customer)customersDataGrid.SelectedItem as Customer;
                    Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                    using (var sqlConnection = new SqlConnection(Database.connection))
                    using (var cmd = new SqlDataAdapter())
                    using (var insertCommand = new SqlCommand("delete from KHACH_HANG where HOTEN = '" + customer.name + "'"))
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
            ReloadData(customers);
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewCustomerDetails viewCustomer = new ViewCustomerDetails();
            Customer selectedCustomer = (Customer)customersDataGrid.SelectedItem as Customer;
            viewCustomer.txtblckCustomerName.Text = selectedCustomer.name.Trim();
            viewCustomer.txtblckPhoneNumber.Text = selectedCustomer.phone.Trim();
            viewCustomer.txtblckRegistrationDate.Text = selectedCustomer.ngayDK.ToString();
            viewCustomer.txtblckCustomerSales.Text = selectedCustomer.doanhSo.ToString();
            string addressFV = selectedCustomer.address.ToString();
            string[] addressParts = addressFV.Split(',');
            string homeNumber = addressParts[0].Trim(),
                street = addressParts[1].Trim(),
                disrict = addressParts[2].Trim(),
                city = addressParts[3].Trim(),
                province = "(Empty)";
            viewCustomer.txtblckHouseNumber.Text = addressParts[0].Trim();
            viewCustomer.txtblckStreet.Text = addressParts[1].Trim();
            viewCustomer.txtblckDistrict.Text = addressParts[2].Trim();
            viewCustomer.txtblckCity.Text = addressParts[3].Trim();
            viewCustomer.txtblckProvince.Text = province;
            viewCustomer.ShowDialog();
        }

        public void LoadData(List<Customer> customers)
        {
            string dateToFormat;
            try
            {
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database results = new Database("RESULT", "select * from KHACH_HANG");
                for (int i = 0; i < results.Rows.Count; i++)
                {
                    dateToFormat = String.Format("{0:d}", DateTime.Parse(results.Rows[i][4].ToString()));
                    customers.Add(new Customer
                    {
                        sttKH = (i + 1).ToString(),
                        name = results.Rows[i][1].ToString(),
                        address = results.Rows[i][2].ToString(),
                        phone = results.Rows[i][0].ToString(),
                        ngayDK = results.Rows[i][4].ToString().Substring(0, 10),
                        doanhSo = double.Parse(results.Rows[i][3].ToString())
                    });
                }

                //customersDataGrid.ItemsSource = customers;
                view = new Resources.PagingCollectionView(customers, 2);

                this.DataContext = view;
                customersDataGrid.ItemsSource = view;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ReloadData(List<Customer> customers)
        {
            try
            {
                customers = new List<Customer>();
                LoadData(customers);
                //tbxCustomersOneOf.Text = "1 of " + customers.Count.ToString();
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

    public class Customer
    {
        public string sttKH { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public string ngayDK { get; set; }

        public double doanhSo { get; set; }
    }
}
