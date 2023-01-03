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
    /// Interaction logic for CannotDeleteBox.xaml
    /// </summary>
    public partial class CannotDeleteBox : Window
    {
        public CannotDeleteBox()
        {
            InitializeComponent();
        }

        private void exitCannotDeleteBoxBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCloseBox_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
