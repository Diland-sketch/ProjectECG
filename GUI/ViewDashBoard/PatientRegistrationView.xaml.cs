
﻿using GUI.ViewModel;
﻿using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.ViewDashBoard
{
    /// <summary>
    /// Lógica de interacción para PatientRegistrationView.xaml
    /// </summary>
    public partial class PatientRegistrationView : UserControl
    {
        public ServicePaciente servicePaciente;
        public PatientRegistrationView()
        {
            InitializeComponent();
            servicePaciente = new ServicePaciente();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Accede al DataContext de la ventana principal (DashboardView)
            var dashboardView = (Window.GetWindow(this) as DashBoardView);
            if (dashboardView != null)
            {
                var navigationVM = dashboardView.DataContext as NavigationVM;
                if (navigationVM != null)
                {
                    // Cambia la vista a HomeView
                    navigationVM.CurrentView = new HomeView();  // Cambia la vista a Home
                }
            }
        }

        /*private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos())
            {
                Paciente paciente = new Paciente
                {
                    Identificacion = txtDocumento.Text,
                    PrimerNombre = txtPrimerNombre.Text,
                    SegundoNombre = txtSegundoNombre.Text,
                    PrimerApellido = txtPrimerApellido.Text,
                    SegundoApellido = txtSegundoApellido.Text
                };
                    if (dpFechaNacimiento.SelectedDate.HasValue) 
                    {
                        string fechaSeleccionada = DateOnly.FromDateTime(dpFechaNacimiento.SelectedDate.Value).ToString();
                        paciente.FechaNacimiento = DateOnly.Parse(fechaSeleccionada);
                    }
                    if (radioMasculino.IsChecked == true)
                    {
                        paciente.Sexo = 'M';
                    }
                    else if (radioFemenino.IsChecked == true)
                    {
                        paciente.Sexo = 'F';
                    }
                    if (paciente.Sexo == ' ')
                    {
                        MessageBox.Show("Por favor, selecciona un sexo.");
                        return;
                    }
                var message = servicePaciente.Guardar(paciente);
                MessageBox.Show(message);
                LimpiarCampos();
            }
        }*/

        public void LimpiarCampos()
        {
            txtDocumento.Text = "";
            txtPrimerNombre.Text = "";
            txtSegundoNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            dpFechaNacimiento.Text = "";
        }

        public bool ValidarCampos()
        {
            if (txtDocumento.Text != "")
            {
                if (txtPrimerNombre.Text != "")
                {
                    if (txtPrimerApellido.Text != "")
                    {
                        if (txtSegundoApellido.Text != "")
                        {
                            if (dpFechaNacimiento.Text != "")
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("TE FALTAN CAMPOS POR COMPLETAR");
                                dpFechaNacimiento.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("TE FALTAN CAMPOS POR COMPLETAR");
                            txtSegundoApellido.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("TE FALTAN CAMPOS POR COMPLETAR");
                        txtPrimerApellido.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("TE FALTAN CAMPOS POR COMPLETAR");
                    txtPrimerNombre.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("TE FALTAN CAMPOS POR COMPLETAR");
                txtDocumento.Focus();
                return false;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos())
            {
                Paciente paciente = new Paciente
                {
                    Identificacion = txtDocumento.Text,
                    PrimerNombre = txtPrimerNombre.Text,
                    SegundoNombre = txtSegundoNombre.Text,
                    PrimerApellido = txtPrimerApellido.Text,
                    SegundoApellido = txtSegundoApellido.Text
                };
                if (dpFechaNacimiento.SelectedDate.HasValue)
                {
                    string fechaSeleccionada = DateOnly.FromDateTime(dpFechaNacimiento.SelectedDate.Value).ToString();
                    paciente.FechaNacimiento = DateOnly.Parse(fechaSeleccionada);
                }
                if (radioMasculino.IsChecked == true)
                {
                    paciente.Sexo = 'M';
                }
                else if (radioFemenino.IsChecked == true)
                {
                    paciente.Sexo = 'F';
                }
                if (paciente.Sexo == ' ')
                {
                    MessageBox.Show("Por favor, selecciona un sexo.");
                    return;
                }
                var message = servicePaciente.Guardar(paciente);
                MessageBox.Show(message);
                LimpiarCampos();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
