using FlowerShopManagementSystem.NotificationBox;
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

namespace FlowerShopManagementSystem.Suppliers
{
    /// <summary>
    /// Interaction logic for SuppliersView.xaml
    /// </summary>
    public partial class SuppliersView : Page
    {
        internal List<Supplier> suppliers;
        private Resources.PagingCollectionView view;
        public SuppliersView()
        {
            InitializeComponent();

            suppliers = new List<Supplier>();



            LoadData(suppliers);
            //tbxSuppliersOneOf.Text = "1 of " + suppliers.Count.ToString();



        }

        private void btnEditSupplier_Click(object sender, RoutedEventArgs e)
        {
            Suppliers.EditSupplierForm editSupplierForm = new Suppliers.EditSupplierForm();
            Supplier supplierOldInfo = (Supplier)suppliersDataGrid.SelectedItem;
            string supplierID = supplierOldInfo.maNCC.Trim(),
                supplierName = supplierOldInfo.tenNCC.Trim(),
                supplierAddress = supplierOldInfo.diaChiNCC.ToString();
            string[] addressParts = supplierAddress.Split(',');
            string street = addressParts[0].Trim(),
                ward = addressParts[1].Trim(),
                district = addressParts[2].Trim(),
                city = addressParts[3].Trim();
            string phoneNumber = supplierOldInfo.soDTNCC.Trim();
            editSupplierForm.tbxEditSupplierID.Text = supplierID;
            editSupplierForm.tbxEditSupplierName.Text = supplierName;
            editSupplierForm.tbxEditSupplierPhoneNumber.Text = phoneNumber;
            editSupplierForm.tbxEditSupplierStreet.Text = street;
            editSupplierForm.cbbEditSupplierWard.Text = ward;
            editSupplierForm.cbbEditSupplierDistrict.Text = district;
            editSupplierForm.cbbEditSuppierCity.Text = city;
            editSupplierForm.ShowDialog();
            ReloadData(suppliers);
        }

        private void btnDeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            NotificationBox.DeleteConfirmationBox deleteConfirmationBox = new NotificationBox.DeleteConfirmationBox();
            deleteConfirmationBox.ShowDialog();
            if (DeleteConfirmationBox.isDeleteBtnClicked)
            {
                try
                {
                    Supplier supplier = (Supplier)suppliersDataGrid.SelectedItem as Supplier;
                    Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                    using (var sqlConnection = new SqlConnection(Database.connection))
                    using (var cmd = new SqlDataAdapter())
                    using (var insertCommand = new SqlCommand("delete from NHA_CUNG_CAP where TENNCC = '" + supplier.tenNCC + "'"))
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
            ReloadData(suppliers);
        }

        private void btnAddNewSupplier_Click(object sender, RoutedEventArgs e)
        {
            Suppliers.AddSupplierForm supplierForm = new Suppliers.AddSupplierForm();
            supplierForm.ShowDialog();
            ReloadData(suppliers);
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ViewSupplierDetails viewSupplierDetails = new ViewSupplierDetails();
                Supplier selectedSupplier = (Supplier)suppliersDataGrid.SelectedItem as Supplier;
                string supplierID = selectedSupplier.maNCC.Trim(),
                    supplierName = selectedSupplier.tenNCC.Trim(),
                    supplierAddress = selectedSupplier.diaChiNCC.ToString();
                string[] addressParts = supplierAddress.Split(',');
                string street = addressParts[0].Trim(),
                    ward = addressParts[1].Trim(),
                    district = addressParts[2].Trim(),
                    city = addressParts[3].Trim();
                string phoneNumber = selectedSupplier.soDTNCC.Trim();
                viewSupplierDetails.txtblckSupplierID.Text = supplierID;
                viewSupplierDetails.txtblckSupplierName.Text = supplierName;
                viewSupplierDetails.txtblckSupplierPhoneNumber.Text = phoneNumber;
                viewSupplierDetails.txtblckSupplierStreet.Text = street;
                viewSupplierDetails.txtblckSupplierWard.Text = ward;
                viewSupplierDetails.txtblckSupplierDistrict.Text = district;
                viewSupplierDetails.txtblckSupplierCity.Text = city;
                viewSupplierDetails.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LoadData(List<Supplier> suppliers)
        {
            try
            {
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                Database results = new Database("RESULT", "select * from NHA_CUNG_CAP");
                for (int i = 0; i < results.Rows.Count; i++)
                {
                    suppliers.Add(new Supplier
                    {
                        sttNCC = (i + 1).ToString(),
                        maNCC = results.Rows[i][0].ToString(),
                        tenNCC = results.Rows[i][1].ToString(),
                        diaChiNCC = results.Rows[i][2].ToString(),
                        soDTNCC = results.Rows[i][3].ToString()
                    });
                }
                view = new Resources.PagingCollectionView(suppliers, 2);

                this.DataContext = view;
                suppliersDataGrid.ItemsSource = view;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ReloadData(List<Supplier> suppliers)
        {
            try
            {
                suppliers = new List<Supplier>();
                LoadData(suppliers);
                //tbxSuppliersOneOf.Text = "1 of " + suppliers.Count.ToString();
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

    public class Supplier
    {
        public string sttNCC { get; set; }
        public string maNCC { get; set; }
        public string tenNCC { get; set; }
        public string diaChiNCC { get; set; }
        public string soDTNCC { get; set; }
    }
}
