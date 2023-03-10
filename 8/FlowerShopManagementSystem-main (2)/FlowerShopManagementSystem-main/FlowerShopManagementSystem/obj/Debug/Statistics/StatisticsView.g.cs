#pragma checksum "..\..\..\Statistics\StatisticsView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E5888C34EC73B13BD048A083DD793F08CCE8492ACCAD5F5EA9C73C422625B6E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FlowerShopManagementSystem.Statistics;
using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace FlowerShopManagementSystem.Statistics {
    
    
    /// <summary>
    /// StatisticsView
    /// </summary>
    public partial class StatisticsView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\Statistics\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbRevenueThisMonth;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Statistics\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblckRevenueThisMonth;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\Statistics\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbIncreasing;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\Statistics\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbNumberofOrders;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\Statistics\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblckOrdersThisMonth;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\Statistics\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbChooseYear;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\Statistics\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart shopRevenueChart;
        
        #line default
        #line hidden
        
        
        #line 228 "..\..\..\Statistics\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbChooseEmployee;
        
        #line default
        #line hidden
        
        
        #line 241 "..\..\..\Statistics\StatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart employeeTurnoverChart;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FlowerShopManagementSystem;component/statistics/statisticsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Statistics\StatisticsView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txbRevenueThisMonth = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.tblckRevenueThisMonth = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txbIncreasing = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txbNumberofOrders = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.tblckOrdersThisMonth = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.cbbChooseYear = ((System.Windows.Controls.ComboBox)(target));
            
            #line 203 "..\..\..\Statistics\StatisticsView.xaml"
            this.cbbChooseYear.DropDownClosed += new System.EventHandler(this.cbbChooseYear_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 7:
            this.shopRevenueChart = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 8:
            this.cbbChooseEmployee = ((System.Windows.Controls.ComboBox)(target));
            
            #line 235 "..\..\..\Statistics\StatisticsView.xaml"
            this.cbbChooseEmployee.DropDownClosed += new System.EventHandler(this.cbbChooseEmployee_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 9:
            this.employeeTurnoverChart = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

