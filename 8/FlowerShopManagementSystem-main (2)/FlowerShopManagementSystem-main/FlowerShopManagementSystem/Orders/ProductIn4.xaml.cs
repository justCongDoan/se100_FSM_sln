using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ProductIn4.xaml
    /// </summary>
    public partial class ProductIn4 : Window, INotifyPropertyChanged
    {
        #region Fields

        public event EventHandler propertyChanged;
        public event EventHandler ValueChanged;
        public event EventHandler TextChanged;
        #endregion

        public ProductIn4()
        {
            InitializeComponent();

            DataContext = this;

            DependencyPropertyDescriptor.FromProperty(ValueProperty, typeof(ProductIn4)).AddValueChanged(this, propertyChanged);
            DependencyPropertyDescriptor.FromProperty(ValueProperty, typeof(ProductIn4)).AddValueChanged(this, ValueChanged);
            DependencyPropertyDescriptor.FromProperty(DecimalsProperty, typeof(ProductIn4)).AddValueChanged(this, propertyChanged);
            DependencyPropertyDescriptor.FromProperty(MinValueProperty, typeof(ProductIn4)).AddValueChanged(this, propertyChanged);
            DependencyPropertyDescriptor.FromProperty(MaxValueProperty, typeof(ProductIn4)).AddValueChanged(this, propertyChanged);

            propertyChanged += (x, y) => validate();
        }

        #region ValueProperty

        public readonly static DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(decimal),
            typeof(ProductIn4),
            new PropertyMetadata(new decimal(1)));

        public decimal Value
        {
            get { return (decimal)GetValue(ValueProperty); }
            set
            {
                if (value < MinValue)
                {
                    value = MinValue;
                    this.brdBrush.BorderBrush = Brushes.Red;
                }
                else
                {
                    this.brdBrush.BorderBrush = Brushes.Gray;
                }
                if (value > MaxValue)
                {
                    value = MaxValue;
                    this.brdBrush.BorderBrush = Brushes.Red;
                }
                else
                {
                    this.brdBrush.BorderBrush = Brushes.Gray;
                }
                SetValue(ValueProperty, value);

                if (ValueChanged != null)
                {
                    ValueChanged(this, new EventArgs());
                }
            }
        }

        public decimal Text
        {
            get { return (decimal)GetValue(ValueProperty); }
            set
            {
                if (value < MinValue)
                    value = MinValue;
                if (value > MaxValue)
                    value = MaxValue;
                SetValue(ValueProperty, value);
                tb_main.Text = value.ToString();
            }
        }
        #endregion

        #region StepProperty

        public readonly static DependencyProperty StepProperty = DependencyProperty.Register(
            "Step",
            typeof(decimal),
            typeof(ProductIn4),
            new PropertyMetadata(new decimal(1)));

        public decimal Step
        {
            get { return (decimal)GetValue(StepProperty); }
            set
            {
                SetValue(StepProperty, value);
            }
        }

        #endregion

        #region DecimalsProperty

        public readonly static DependencyProperty DecimalsProperty = DependencyProperty.Register(
            "Decimals",
            typeof(int),
            typeof(ProductIn4),
            new PropertyMetadata(2));

        public int Decimals
        {
            get { return (int)GetValue(DecimalsProperty); }
            set
            {
                SetValue(DecimalsProperty, value);
            }
        }

        #endregion

        #region MinValueProperty

        public readonly static DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(decimal),
            typeof(ProductIn4),
            new PropertyMetadata(decimal.MinValue));

        public decimal MinValue
        {
            get { return (decimal)GetValue(MinValueProperty); }
            set
            {
                if (value > MaxValue)
                    value = MaxValue;
                SetValue(MinValueProperty, value);
            }
        }

        #endregion

        #region MaxValueProperty

        public readonly static DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(decimal),
            typeof(ProductIn4),
            new PropertyMetadata(decimal.MaxValue));

        public decimal MaxValue
        {
            get { return (decimal)GetValue(MaxValueProperty); }
            set
            {
                if (value < MinValue)
                    value = MinValue;
                SetValue(MaxValueProperty, value);
            }
        }
        #endregion

        /// <summary>
        /// Revalidate the object, whenever a value is changed...
        /// </summary>
        private void validate()
        {
            // Logically, This is not needed at all... as it's handled within other properties...
            if (MinValue > MaxValue) MinValue = MaxValue;
            if (MaxValue < MinValue) MaxValue = MinValue;
            if (Value < MinValue) Value = MinValue;
            if (Value > MaxValue) Value = MaxValue;

            Value = decimal.Round(Value, Decimals);
        }
        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            Value += Step;
            tb_main.Text = Value.ToString();
            RaisePropertyChanged(nameof(Calculate));
        }
        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            if (tb_main.Text != "1")
            {
                Value -= Step;
                tb_main.Text = Value.ToString();
                RaisePropertyChanged(nameof(Calculate));

            }
        }

        private void tb_main_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Text = decimal.Parse(this.tb_main.Text);
                RaisePropertyChanged(nameof(Calculate));
            }
            catch
            {

            }
        }

        public long Calculate
        {
            get
            {
                return long.Parse(tb_main.Text) * long.Parse(txtblckProductPrice.Text);
            }
        }

        private void tb_main_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnBackProductIn4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = "") =>
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    var ct = CreateNewOrder.cTHDs1.Where(x => x.productID == txtblckProductID.Text).FirstOrDefault();
            //    if (ct != null)
            //    {
            //        ct.productID = txtblckProductID.Text;
            //        ct.productName = txtblckProductName.Text;
            //        ct.productPrice = double.Parse(txtblckProductPrice.Text.ToString());
            //        ct.productQuantity = int.Parse(tb_main.Text.ToString());
            //    }
            //    Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }
    }
}
