﻿#pragma checksum "..\..\..\Settings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8AAA20CAB6D2C349196D1AD336AC0871E27F7FF5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using VPLanViewer;


namespace VPLanViewer {
    
    
    /// <summary>
    /// Settings
    /// </summary>
    public partial class Settings : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ManulualReloadBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CustomFeedBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox OnlineFeed;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel customfeed;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DurchsuchenButton;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PathBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VPLanViewer;component/settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Settings.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\Settings.xaml"
            ((System.Windows.Controls.DockPanel)(target)).Loaded += new System.Windows.RoutedEventHandler(this.DockPanel_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.back = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Settings.xaml"
            this.back.Click += new System.Windows.RoutedEventHandler(this.back_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ManulualReloadBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 55 "..\..\..\Settings.xaml"
            this.ManulualReloadBox.Unchecked += new System.Windows.RoutedEventHandler(this.ManulualReloadBox_Check);
            
            #line default
            #line hidden
            
            #line 55 "..\..\..\Settings.xaml"
            this.ManulualReloadBox.Checked += new System.Windows.RoutedEventHandler(this.ManulualReloadBox_Check);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CustomFeedBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 56 "..\..\..\Settings.xaml"
            this.CustomFeedBox.Unchecked += new System.Windows.RoutedEventHandler(this.CustomFeedBox_Check);
            
            #line default
            #line hidden
            
            #line 56 "..\..\..\Settings.xaml"
            this.CustomFeedBox.Checked += new System.Windows.RoutedEventHandler(this.CustomFeedBox_Check);
            
            #line default
            #line hidden
            return;
            case 5:
            this.OnlineFeed = ((System.Windows.Controls.CheckBox)(target));
            
            #line 57 "..\..\..\Settings.xaml"
            this.OnlineFeed.Unchecked += new System.Windows.RoutedEventHandler(this.OnlineFeed_Check);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\Settings.xaml"
            this.OnlineFeed.Checked += new System.Windows.RoutedEventHandler(this.OnlineFeed_Check);
            
            #line default
            #line hidden
            return;
            case 6:
            this.customfeed = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 7:
            this.DurchsuchenButton = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\Settings.xaml"
            this.DurchsuchenButton.Click += new System.Windows.RoutedEventHandler(this.DurchsuchenButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PathBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 61 "..\..\..\Settings.xaml"
            this.PathBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PathBox_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

