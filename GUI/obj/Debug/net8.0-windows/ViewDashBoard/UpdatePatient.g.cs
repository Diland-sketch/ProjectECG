﻿#pragma checksum "..\..\..\..\ViewDashBoard\UpdatePatient.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CA18B9CA5295F9B1C60395DC488521C73ABD4E41"
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
    /// UpdatePatient
    /// </summary>
    public partial class UpdatePatient : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDocumentoBuscar;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrimerNombre;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSegundoNombre;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrimerApellido;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSegundoApellido;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpFechaNacimiento;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioMasculino;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioFemenino;
        
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
            System.Uri resourceLocater = new System.Uri("/GUI;component/viewdashboard/updatepatient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
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
            this.txtDocumentoBuscar = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
            this.txtDocumentoBuscar.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtId_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
            this.txtDocumentoBuscar.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtId_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 28 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnBuscar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtPrimerNombre = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
            this.txtPrimerNombre.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtPrimerNombre_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
            this.txtPrimerNombre.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtPrimerNombre_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtSegundoNombre = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
            this.txtSegundoNombre.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtPrimerNombre_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
            this.txtSegundoNombre.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtSegundoNombre_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtPrimerApellido = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
            this.txtPrimerApellido.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtPrimerNombre_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
            this.txtPrimerApellido.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtPrimerApellido_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtSegundoApellido = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\..\..\ViewDashBoard\UpdatePatient.xaml"
            this.txtSegundoApellido.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtPrimerNombre_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dpFechaNacimiento = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.radioMasculino = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.radioFemenino = ((System.Windows.Controls.RadioButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

