﻿#pragma checksum "..\..\..\Control\SignInControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B2A0736F6CD5E17E326E3B6AF349A93B4B9B9C72782652B1D0E6F01A806031AA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Otchetnost;
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


namespace Otchetnost {
    
    
    /// <summary>
    /// SignInControl
    /// </summary>
    public partial class SignInControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Control\SignInControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock login_txt;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Control\SignInControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox login_tb;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Control\SignInControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock password_txt;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Control\SignInControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox password_tb;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Control\SignInControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock signin;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Control\SignInControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock idk;
        
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
            System.Uri resourceLocater = new System.Uri("/Otchetnost;component/control/signincontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Control\SignInControl.xaml"
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
            this.login_txt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.login_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\..\Control\SignInControl.xaml"
            this.login_tb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.login_tb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.password_txt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.password_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.signin = ((System.Windows.Controls.TextBlock)(target));
            
            #line 18 "..\..\..\Control\SignInControl.xaml"
            this.signin.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.SignInCheck);
            
            #line default
            #line hidden
            return;
            case 6:
            this.idk = ((System.Windows.Controls.TextBlock)(target));
            
            #line 19 "..\..\..\Control\SignInControl.xaml"
            this.idk.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.idk_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

