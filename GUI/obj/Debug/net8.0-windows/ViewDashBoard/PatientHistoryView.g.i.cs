﻿#pragma checksum "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55D472C24B7140D6009175171FB51A53AD5498B4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using GUI.ViewModel;
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


namespace GUI.ViewDashBoard {
    
    
    /// <summary>
    /// PatientHistoryView
    /// </summary>
    public partial class PatientHistoryView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridPacientes;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtId1;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Buscar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GUI;component/viewdashboard/patienthistoryview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 18 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
            ((System.Windows.Controls.Border)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Border_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dataGridPacientes = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.txtId1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 89 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
            this.txtId1.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtId_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 89 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
            this.txtId1.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtId_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Buscar = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
            this.Buscar.Click += new System.Windows.RoutedEventHandler(this.Buscar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

