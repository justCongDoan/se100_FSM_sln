﻿#pragma checksum "..\..\..\Products\ViewProductDetails.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "79A7375B9F77C6DC7469DEBFC6A56AE8A95A5E991BB9B07E59AFEA4BDFA44548"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FlowerShopManagementSystem;
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


namespace FlowerShopManagementSystem.Products {
    
    
    /// <summary>
    /// ViewProductDetails
    /// </summary>
    public partial class ViewProductDetails : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\..\Products\ViewProductDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtblckProductID;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Products\ViewProductDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtblckProductType;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Products\ViewProductDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtblckEvent;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\Products\ViewProductDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtblckProductName;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\Products\ViewProductDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtblckProductSupplier;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Products\ViewProductDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtblckProductPrice;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\Products\ViewProductDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image viewProductImage;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\Products\ViewProductDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBackViewProduct;
        
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
            System.Uri resourceLocater = new System.Uri("/FlowerShopManagementSystem;component/products/viewproductdetails.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Products\ViewProductDetails.xaml"
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
            this.txtblckProductID = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txtblckProductType = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txtblckEvent = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txtblckProductName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txtblckProductSupplier = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtblckProductPrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.viewProductImage = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.btnBackViewProduct = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\..\Products\ViewProductDetails.xaml"
            this.btnBackViewProduct.Click += new System.Windows.RoutedEventHandler(this.btnBackViewProduct_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

