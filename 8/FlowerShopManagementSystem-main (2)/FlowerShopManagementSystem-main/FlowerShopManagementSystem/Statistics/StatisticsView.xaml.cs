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
            shopSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<double> { 4000, 6000, 5000, 7000}
                },
            };

            employeeTurnoverChart.Visibility = Visibility.Hidden;

            shopLabels = new[] { "9", "10", "11", "12" };
            shopYFormatter = value => value.ToString("C");
            shopRevenueChart.Series = shopSeriesCollection;

        }



        private void cbbChooseYear_DropDownClosed(object sender, EventArgs e)
        {
            switch (cbbChooseYear.SelectedIndex)
            {
                case 0:
                    {
                        shopSeriesCollection = new SeriesCollection
                        {
                            new LineSeries
                            {
                                Title = "Revenue",
                                Values = new ChartValues<double> { 4000, 6000, 5000, 7000}
                            },
                        };

                        shopLabels = new[] { "9", "10", "11", "12" };
                        shopYFormatter = value => value.ToString("C");
                        shopRevenueChart.Series = shopSeriesCollection;

                        break;
                    }
                case 1:
                    {
                        shopSeriesCollection = new SeriesCollection
                        {
                            new LineSeries
                            {
                                Title = "Revenue",
                                Values = new ChartValues<double> { 5000, 6000, 3000, 8000}
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
            

            switch (cbbChooseEmployee.SelectedIndex)
            {
                case 0:
                    {
                        employeeTurnoverChart.Visibility = Visibility.Visible;

                        employeeSeriesCollection = new SeriesCollection
                        {
                            new ColumnSeries
                            {
                                Title = "Turnover",
                                Values = new ChartValues<double> {500, 200, 300 ,700}
                            }
                        };

                        employeeLabels = new[] { "1", "2", "3", "4" };
                        employeeYFormatter = value => value.ToString("C");
                        employeeTurnoverChart.Series = employeeSeriesCollection;

                        break;
                    }
                case 1:
                    {
                        employeeTurnoverChart.Visibility = Visibility.Visible;

                        employeeSeriesCollection = new SeriesCollection
                        {
                            new ColumnSeries
                            {
                                Title = "Turnover",
                                Values = new ChartValues<double> {100, 200, 500 ,1000}
                            }
                        };

                        employeeLabels = new[] { "9", "10", "11", "12" };
                        employeeYFormatter = value => value.ToString("C");
                        employeeTurnoverChart.Series = employeeSeriesCollection;

                        break;
                    }
            }
        }
    }
}
