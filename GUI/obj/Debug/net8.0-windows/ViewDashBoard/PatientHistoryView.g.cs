﻿#pragma checksum "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A7EBF3A8BC8056EB4AB8E7E908ABF105366BEC31"
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
        
        
        #line 18 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridPacientes;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIdSesion;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtInicio;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFin;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIdMedico;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIdPaciente;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescripcion;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtId1;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Buscar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
            ((System.Windows.Controls.Border)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Border_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dataGridPacientes = ((System.Windows.Controls.DataGrid)(target));
            
            #line 20 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
            this.dataGridPacientes.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGridPacientes_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtIdSesion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtInicio = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtFin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtIdMedico = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtIdPaciente = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtDescripcion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.txtId1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.Buscar = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\..\..\ViewDashBoard\PatientHistoryView.xaml"
            this.Buscar.Click += new System.Windows.RoutedEventHandler(this.Buscar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

