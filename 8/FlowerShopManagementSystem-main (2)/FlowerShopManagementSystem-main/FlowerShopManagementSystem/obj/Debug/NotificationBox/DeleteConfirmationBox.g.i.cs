#pragma checksum "..\..\..\NotificationBox\DeleteConfirmationBox.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "29A46BFC8F1958181920294530A3B620B3C35C7D63B83A4A1706DFCAC5CBACC9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace FlowerShopManagementSystem.NotificationBox {
    
    
    /// <summary>
    /// DeleteConfirmationBox
    /// </summary>
    public partial class DeleteConfirmationBox : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\NotificationBox\DeleteConfirmationBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitBoxBtn;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\NotificationBox\DeleteConfirmationBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelBox;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\NotificationBox\DeleteConfirmationBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteBox;
        
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
            System.Uri resourceLocater = new System.Uri("/FlowerShopManagementSystem;component/notificationbox/deleteconfirmationbox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\NotificationBox\DeleteConfirmationBox.xaml"
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
            
            #line 7 "..\..\..\NotificationBox\DeleteConfirmationBox.xaml"
            ((FlowerShopManagementSystem.NotificationBox.DeleteConfirmationBox)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.exitBoxBtn = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\NotificationBox\DeleteConfirmationBox.xaml"
            this.exitBoxBtn.Click += new System.Windows.RoutedEventHandler(this.exitBoxBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnCancelBox = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\NotificationBox\DeleteConfirmationBox.xaml"
            this.btnCancelBox.Click += new System.Windows.RoutedEventHandler(this.btnCancelBox_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDeleteBox = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\NotificationBox\DeleteConfirmationBox.xaml"
            this.btnDeleteBox.Click += new System.Windows.RoutedEventHandler(this.btnDeleteBox_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

