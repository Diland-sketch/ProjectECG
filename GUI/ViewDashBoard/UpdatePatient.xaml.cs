using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para UpdatePatient.xaml
    /// </summary>
    public partial class UpdatePatient : UserControl
    {
        ServicePaciente servicePaciente;
        public UpdatePatient()
        {
            InitializeComponent();
            servicePaciente = new ServicePaciente();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Paciente paciente = new Paciente();
            paciente = servicePaciente.ConsultarId(txtDocumentoBuscar.Text);
            txtPrimerNombre.Text = paciente.PrimerNombre;
            txtSegundoNombre.Text = paciente.SegundoNombre;
            txtPrimerApellido.Text = paciente.PrimerApellido;
            txtSegundoApellido.Text = paciente.SegundoApellido;
            if((paciente.Sexo == 'M') || (paciente.Sexo == 'm'))
            {
                radioMasculino.IsChecked = true;
            }
            else
            {
                radioFemenino.IsChecked = true;
            }
            dpFechaNacimiento.Text = paciente.FechaNacimiento.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos())
            {
                Paciente paciente = new Paciente();
                paciente.Identificacion = txtDocumentoBuscar.Text;
                paciente.PrimerNombre = txtPrimerNombre.Text;
                paciente.SegundoNombre = txtSegundoNombre.Text;
                paciente.PrimerApellido = txtPrimerApellido.Text;
                paciente.SegundoApellido = txtSegundoApellido.Text;
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
                var message = servicePaciente.Actualizar(paciente);
                MessageBox.Show(message);
                LimpiarCampos();
            }
        }

        public bool ValidarCampos()
        {
            if (txtDocumentoBuscar.Text != "")
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
                txtDocumentoBuscar.Focus();
                return false;
            }
        }
        public void LimpiarCampos()
        {
            txtDocumentoBuscar.Text = "";
            txtPrimerNombre.Text = "";
            txtSegundoNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            dpFechaNacimiento.Text = "";
        }
        private void txtId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^\d+$");
        }
        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[a-zA-Z]+$");
        }
        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtPrimerNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[a-zA-Z]+$");
        }

        private void txtPrimerNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                txtSegundoNombre.Focus();
            }
        }

        private void txtSegundoNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Enter)
            {
                txtPrimerApellido.Focus();
            }
        }

        private void txtPrimerApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                txtSegundoApellido.Focus();
            }
        }
    }
}
