﻿#pragma checksum "..\..\..\NotificationBox\LogoutConfirmationBox.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "57C5242873BC6CFADC36DD79F9D67E3C791A0A6F13B4529F52196FB725ABC4B5"
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
    /// LogoutConfirmationBox
    /// </summary>
    public partial class LogoutConfirmationBox : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\NotificationBox\LogoutConfirmationBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitLogoutBoxBtn;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\NotificationBox\LogoutConfirmationBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelLogoutBox;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\NotificationBox\LogoutConfirmationBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogoutBox;
        
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
            System.Uri resourceLocater = new System.Uri("/FlowerShopManagementSystem;component/notificationbox/logoutconfirmationbox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\NotificationBox\LogoutConfirmationBox.xaml"
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
            
            #line 7 "..\..\..\NotificationBox\LogoutConfirmationBox.xaml"
            ((FlowerShopManagementSystem.NotificationBox.LogoutConfirmationBox)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.exitLogoutBoxBtn = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\NotificationBox\LogoutConfirmationBox.xaml"
            this.exitLogoutBoxBtn.Click += new System.Windows.RoutedEventHandler(this.exitLogoutBoxBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnCancelLogoutBox = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\NotificationBox\LogoutConfirmationBox.xaml"
            this.btnCancelLogoutBox.Click += new System.Windows.RoutedEventHandler(this.btnCancelLogoutBox_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnLogoutBox = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\NotificationBox\LogoutConfirmationBox.xaml"
            this.btnLogoutBox.Click += new System.Windows.RoutedEventHandler(this.btnLogoutBox_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

