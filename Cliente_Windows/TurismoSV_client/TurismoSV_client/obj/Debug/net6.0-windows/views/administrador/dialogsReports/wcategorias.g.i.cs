﻿#pragma checksum "..\..\..\..\..\..\views\administrador\dialogsReports\wcategorias.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60D7CE5CF96CFEA0D4EB738567883E33AF5CB548"
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
using TurismoSV_client.views.administrador.dialogsReports;


namespace TurismoSV_client.views.administrador.dialogsReports {
    
    
    /// <summary>
    /// wcategorias
    /// </summary>
    public partial class wcategorias : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\..\views\administrador\dialogsReports\wcategorias.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border workPanel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\..\views\administrador\dialogsReports\wcategorias.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbx_listadoCategorias;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\..\views\administrador\dialogsReports\wcategorias.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_numElements;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\..\views\administrador\dialogsReports\wcategorias.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cancel;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\..\views\administrador\dialogsReports\wcategorias.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_generaReport;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TurismoSV_client;V1.0.0.0;component/views/administrador/dialogsreports/wcategori" +
                    "as.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\views\administrador\dialogsReports\wcategorias.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.workPanel = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.cmbx_listadoCategorias = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\..\..\..\..\views\administrador\dialogsReports\wcategorias.xaml"
            this.cmbx_listadoCategorias.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbx_listadoCategorias_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_numElements = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\..\..\..\views\administrador\dialogsReports\wcategorias.xaml"
            this.txt_numElements.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewTextInputHandler);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_cancel = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\..\..\views\administrador\dialogsReports\wcategorias.xaml"
            this.btn_cancel.Click += new System.Windows.RoutedEventHandler(this.btn_cancel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_generaReport = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\..\..\views\administrador\dialogsReports\wcategorias.xaml"
            this.btn_generaReport.Click += new System.Windows.RoutedEventHandler(this.btn_generaReport_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

