﻿#pragma checksum "..\..\..\Control\SignUpControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4E61C951AB8CFACDD6D7B2437E50DCD0179E8DAC2FF13EDA5F8E50B0D87A157E"
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
    /// SignUpControl
    /// </summary>
    public partial class SignUpControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Control\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid suc;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Control\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock login_txt;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Control\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox login_tb;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Control\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock password_txt;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Control\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password_tb;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Control\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock passwordConfirm_txt;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Control\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordConfirm_tb;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Control\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock signin;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Control\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ik;
        
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
            System.Uri resourceLocater = new System.Uri("/Otchetnost;component/control/signupcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Control\SignUpControl.xaml"
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
            this.suc = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.login_txt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.login_tb = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\..\Control\SignUpControl.xaml"
            this.login_tb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.login_tb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.password_txt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.password_tb = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.passwordConfirm_txt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.passwordConfirm_tb = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.signin = ((System.Windows.Controls.TextBlock)(target));
            
            #line 21 "..\..\..\Control\SignUpControl.xaml"
            this.signin.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.SignInCheck);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ik = ((System.Windows.Controls.TextBlock)(target));
            
            #line 22 "..\..\..\Control\SignUpControl.xaml"
            this.ik.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ik_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

