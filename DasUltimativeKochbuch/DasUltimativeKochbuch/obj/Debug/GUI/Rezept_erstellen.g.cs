﻿#pragma checksum "..\..\..\GUI\Rezept_erstellen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0B0179DFB6FA4B81E9F929156695C630"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.34014
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


namespace DasUltimativeKochbuch.GUI {
    
    
    /// <summary>
    /// Rezept_erstellen
    /// </summary>
    public partial class Rezept_erstellen : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 10 "..\..\..\GUI\Rezept_erstellen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Rezept_erstellen_Grid;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\GUI\Rezept_erstellen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Rezeptname;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\GUI\Rezept_erstellen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Zubereitung;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\GUI\Rezept_erstellen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Zutat;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\GUI\Rezept_erstellen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Menge;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\GUI\Rezept_erstellen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Einheit;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\GUI\Rezept_erstellen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddZutat;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\GUI\Rezept_erstellen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save_Rezept;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\GUI\Rezept_erstellen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar PB_Save;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\GUI\Rezept_erstellen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LV_Zutaten;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\GUI\Rezept_erstellen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Personenanzahl;
        
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
            System.Uri resourceLocater = new System.Uri("/DasUltimativeKochbuch;component/gui/rezept_erstellen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\Rezept_erstellen.xaml"
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
            this.Rezept_erstellen_Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.TB_Rezeptname = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\GUI\Rezept_erstellen.xaml"
            this.TB_Rezeptname.GotFocus += new System.Windows.RoutedEventHandler(this.TB_GotFocus);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\GUI\Rezept_erstellen.xaml"
            this.TB_Rezeptname.LostFocus += new System.Windows.RoutedEventHandler(this.TB_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TB_Zubereitung = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\..\GUI\Rezept_erstellen.xaml"
            this.TB_Zubereitung.GotFocus += new System.Windows.RoutedEventHandler(this.TB_GotFocus);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\GUI\Rezept_erstellen.xaml"
            this.TB_Zubereitung.LostFocus += new System.Windows.RoutedEventHandler(this.TB_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TB_Zutat = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\GUI\Rezept_erstellen.xaml"
            this.TB_Zutat.GotFocus += new System.Windows.RoutedEventHandler(this.TB_GotFocus);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\GUI\Rezept_erstellen.xaml"
            this.TB_Zutat.LostFocus += new System.Windows.RoutedEventHandler(this.TB_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TB_Menge = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\GUI\Rezept_erstellen.xaml"
            this.TB_Menge.GotFocus += new System.Windows.RoutedEventHandler(this.TB_GotFocus);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\GUI\Rezept_erstellen.xaml"
            this.TB_Menge.LostFocus += new System.Windows.RoutedEventHandler(this.TB_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Einheit = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.AddZutat = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\GUI\Rezept_erstellen.xaml"
            this.AddZutat.Click += new System.Windows.RoutedEventHandler(this.AddZutat_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Save_Rezept = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\GUI\Rezept_erstellen.xaml"
            this.Save_Rezept.Click += new System.Windows.RoutedEventHandler(this.Save_Rezept_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.PB_Save = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 10:
            this.LV_Zutaten = ((System.Windows.Controls.ListView)(target));
            return;
            case 12:
            this.TB_Personenanzahl = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\GUI\Rezept_erstellen.xaml"
            this.TB_Personenanzahl.GotFocus += new System.Windows.RoutedEventHandler(this.TB_GotFocus);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\GUI\Rezept_erstellen.xaml"
            this.TB_Personenanzahl.LostFocus += new System.Windows.RoutedEventHandler(this.TB_LostFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 11:
            
            #line 32 "..\..\..\GUI\Rezept_erstellen.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Zutat_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
