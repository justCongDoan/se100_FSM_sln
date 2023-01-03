using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlowerShopManagementSystem
{
    internal class Database : DataTable
    {
        public static SqlConnection sqlConnection;
        SqlDataAdapter dataAdapter;
        public static SqlCommand sqlCommand;
        string tablename;
        string command;
        public static string connection;

        public static string connectionName = "DESKTOP-G8ANP0F\\SQLEXPRESS";

        //Tạo hàm kết nối đến CSDL thông qua chuỗi kết nối
        private void CreateConnection()
        {
            if (sqlConnection == null)
                sqlConnection = new SqlConnection(connection);
        }
        public Database() : base()
        {

        }
        public Database(string tablename, string command) : base(tablename, command)
        {
            this.tablename = tablename;
            this.command = command;
            ReadTable();
        }
        public void ReadTable()
        {
            try
            {
                CreateConnection();
                if (command == null || command == "")
                    command = "select * from " + tablename;
                dataAdapter = new SqlDataAdapter(command, connection);
                dataAdapter.FillSchema(this, SchemaType.Mapped);
                dataAdapter.Fill(this);
                dataAdapter.SelectCommand.CommandText = "select * from " + tablename;
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public bool WriteTable()
        {
            try
            {
                dataAdapter.Update(this);
                this.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
                this.RejectChanges();
                return false;
            }
        }
        public void Rejecting()
        {
            this.RejectChanges();
        }
    }
}
