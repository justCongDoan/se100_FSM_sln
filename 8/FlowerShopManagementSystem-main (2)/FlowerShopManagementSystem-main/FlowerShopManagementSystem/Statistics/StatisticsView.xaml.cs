using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace FlowerShopManagementSystem.Statistics
{
    /// <summary>
    /// Interaction logic for StatisticsView.xaml
    /// </summary>
    public partial class StatisticsView : Page
    {
        public SeriesCollection shopSeriesCollection { get; set; }
        public SeriesCollection employeeSeriesCollection { get; set; }
        public string[] shopLabels { get; set; }
        public string[] employeeLabels { get; set; }
        public Func<double, string> shopYFormatter { get; set; }
        public Func<double, string> employeeYFormatter { get; set; }


        public StatisticsView()
        {
            InitializeComponent();

            DataContext = this;

            initializeChart();
        }

        private void initializeChart()
        {
            Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
            Database results = new Database("RESULT", "select sum(TRIGIA) from HOA_DON where DatePart(MONTH, NGHD) = 10 and DatePart(YEAR, NGHD) = 2022"),
                    results1 = new Database("RESULT", "select sum(TRIGIA) from HOA_DON where DatePart(MONTH, NGHD) = 11 and DatePart(YEAR, NGHD) = 2022"),
                    results2 = new Database("RESULT", "select sum(TRIGIA) from HOA_DON where DatePart(MONTH, NGHD) = 12 and DatePart(YEAR, NGHD) = 2022"),
                    results3 = new Database("RESULT", "select sum(TRIGIA) from HOA_DON where DatePart(MONTH, NGHD) = 1 and DatePart(YEAR, NGHD) = 2023"),
                    results4 = new Database("RESULT", "select MAHD from HOA_DON where DatePart(MONTH, NGHD) = 1");
            double revenue1 = double.Parse(results.Rows[0][0].ToString()),
                    revenue2 = double.Parse(results1.Rows[0][0].ToString()),
                    revenue3 = double.Parse(results2.Rows[0][0].ToString()),
                    revenue4 = double.Parse(results3.Rows[0][0].ToString());
            double inscrease = ((revenue4 - revenue3) / revenue3) * 100;
            double percentage = Math.Round(inscrease, 2);
            int numOfOrders = results4.Rows.Count;

            shopSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<double> { revenue1, revenue2, revenue3, revenue4}
                },
            };

            employeeTurnoverChart.Visibility = Visibility.Hidden;

            shopLabels = new[] { "10", "11", "12", "1" };
            shopYFormatter = value => value.ToString("C");
            shopRevenueChart.Series = shopSeriesCollection;

            txbRevenueThisMonth.Text = revenue4.ToString();
            txbIncreasing.Text = percentage.ToString() + "%";
            txbNumberofOrders.Text = numOfOrders.ToString();

        }



        private void cbbChooseYear_DropDownClosed(object sender, EventArgs e)
        {
            switch (cbbChooseYear.SelectedIndex)
            {
                case 0:
                    {
                        Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                        Database results = new Database("RESULT", "select sum(TRIGIA) from HOA_DON where DatePart(MONTH, NGHD) = 1 and DatePart(YEAR, NGHD) = 2023");
                        double revenue1 = double.Parse(results.Rows[0][0].ToString());
                        shopSeriesCollection = new SeriesCollection
                        {
                            new LineSeries
                            {
                                Title = "Revenue",
                                Values = new ChartValues<double> { revenue1, 0, 0, 0 }
                            },
                        };

                        shopLabels = new[] { "1", "2", "3", "4" };
                        shopYFormatter = value => value.ToString("C");
                        shopRevenueChart.Series = shopSeriesCollection;

                        break;
                    }
                case 1:
                    {
                        Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                        Database results = new Database("RESULT", "select sum(TRIGIA) from HOA_DON where DatePart(MONTH, NGHD) = 10 and DatePart(YEAR, NGHD) = 2022"),
                                results1 = new Database("RESULT", "select sum(TRIGIA) from HOA_DON where DatePart(MONTH, NGHD) = 11 and DatePart(YEAR, NGHD) = 2022"),
                                results2 = new Database("RESULT", "select sum(TRIGIA) from HOA_DON where DatePart(MONTH, NGHD) = 12 and DatePart(YEAR, NGHD) = 2022");
                        double revenue1 = double.Parse(results.Rows[0][0].ToString()),
                                revenue2 = double.Parse(results1.Rows[0][0].ToString()),
                                revenue3 = double.Parse(results2.Rows[0][0].ToString());
                        shopSeriesCollection = new SeriesCollection
                        {
                            new LineSeries
                            {
                                Title = "Revenue",
                                Values = new ChartValues<double> { 0, revenue1, revenue2, revenue3 }
                            },
                        };

                        shopLabels = new[] { "9", "10", "11", "12" };
                        shopYFormatter = value => value.ToString("C");
                        shopRevenueChart.Series = shopSeriesCollection;

                        break;
                    }
            }
        }

        private void cbbChooseEmployee_DropDownClosed(object sender, EventArgs e)
        {


            try
            {
                ComboBoxItem employeeCBI = (ComboBoxItem)cbbChooseEmployee.SelectedItem;
                string name = employeeCBI.Content.ToString();
                Database.connection = "Server=" + Database.connectionName + ";Database=FlowerShopManagement;Integrated Security=true";
                // these are not the correct sql queries, if correct, it causes the below exception.
                Database results = new Database("RESULT", "select sum(TRIGIA) from HOA_DON where DatePart(MONTH, NGHD) = 10"),
                        results1 = new Database("RESULT", "select sum(TRIGIA) from HOA_DON where DatePart(MONTH, NGHD) = 11"),
                        results2 = new Database("RESULT", "select sum(TRIGIA) from HOA_DON where DatePart(MONTH, NGHD) = 12"),
                        results3 = new Database("RESULT", "select sum(TRIGIA) from HOA_DON where DatePart(MONTH, NGHD) = 1");

                string strR1 = results.Rows.Count < 1 ? "0" : results.Rows[0][0].ToString(),
                        strR2 = results1.Rows.Count < 1 ? "0" : results1.Rows[0][0].ToString(),
                        strR3 = results2.Rows.Count < 1 ? "0" : results2.Rows[0][0].ToString(),
                        strR4 = results3.Rows.Count < 1 ? "0" : results3.Rows[0][0].ToString();
                double revenue1 = double.Parse(strR1), // exception from here.
                        revenue2 = double.Parse(strR2),
                        revenue3 = double.Parse(strR3),
                        revenue4 = double.Parse(strR4);// to here.


                employeeTurnoverChart.Visibility = Visibility.Visible;

                employeeSeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Turnover",
                    Values = new ChartValues<double> {revenue1, revenue2, revenue3 , revenue4}
                }
            };

                employeeLabels = new[] { "1", "2", "3", "4" };
                employeeYFormatter = value => value.ToString("C");
                employeeTurnoverChart.Series = employeeSeriesCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error alert!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
