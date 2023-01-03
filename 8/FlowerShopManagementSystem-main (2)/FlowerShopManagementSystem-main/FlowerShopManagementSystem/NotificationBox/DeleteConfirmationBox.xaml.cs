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

namespace FlowerShopManagementSystem.NotificationBox
{
    /// <summary>
    /// Interaction logic for DeleteConfirmationBox.xaml
    /// </summary>
    public partial class DeleteConfirmationBox : Window
    {
        public static bool isDeleteBtnClicked = false;
        public DeleteConfirmationBox()
        {
            InitializeComponent();
            isDeleteBtnClicked = true;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void exitBoxBtn_Click(object sender, RoutedEventArgs e)
        {
            isDeleteBtnClicked = false;
            this.Close();
        }

        private void btnCancelBox_Click(object sender, RoutedEventArgs e)
        {
            isDeleteBtnClicked = false;
            this.Close();
        }

        private void btnDeleteBox_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
