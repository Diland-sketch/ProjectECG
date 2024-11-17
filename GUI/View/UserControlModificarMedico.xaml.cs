using Entidades;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Lógica de interacción para UserControlModificarMedico.xaml
    /// </summary>
    public partial class UserControlModificarMedico : UserControl
    {
        ServiceMedic ServiceMedic;
        ServiceUser ServiceUser;
        public UserControlModificarMedico()
        {
            InitializeComponent();
            ServiceMedic = new ServiceMedic();
            ServiceUser = new ServiceUser();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation();
            fadeInAnimation.From = 0;
            fadeInAnimation.To = 1;
            fadeInAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            this.BeginAnimation(UserControl.OpacityProperty, fadeInAnimation);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            

            }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
                UserControlCrudMedico userControlCrudMedico = new UserControlCrudMedico();
                mainWindow.panelMedico.Children.Add(userControlCrudMedico);
            }
        }
        private void IdentificacionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool tieneIdentificacion = !string.IsNullOrWhiteSpace(txtId.Text);
            txtPNombre.IsEnabled = tieneIdentificacion;
            txtPApellido.IsEnabled = tieneIdentificacion;
            fechaNacimientoPicker.IsEnabled = tieneIdentificacion;
            txtSNombre.IsEnabled = tieneIdentificacion;
            txtSApellido.IsEnabled = tieneIdentificacion;
            RbtnMasculino.IsEnabled = tieneIdentificacion;
            RbtnFemenino.IsEnabled = tieneIdentificacion;
            txtNombreUsuario.IsEnabled = tieneIdentificacion;
            txtContraseña.IsEnabled = tieneIdentificacion;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            if (1 + 1 == 2)
            {
                btnActualizar.IsEnabled = true;
            }

            Medico medico = new Medico();
            medico = ServiceMedic.ConsultarId(txtId.Text);
            txtPNombre.Text = medico.PrimerNombre;
            txtSNombre.Text = medico.SegundoNombre;
            txtPApellido.Text = medico.PrimerApellido;
            txtSApellido.Text = medico.SegundoApellido;
            if ((medico.Sexo == 'M')||(medico.Sexo == 'm'))
            {
                RbtnMasculino.IsChecked = true;
            }
            else
            {
                RbtnFemenino.IsChecked = true;
            }

            fechaNacimientoPicker.Text = medico.FechaNacimiento.ToString();
            Usuario usuario = new Usuario();
            usuario = ServiceUser.ConsultarId(ServiceMedic.MostrarIdu(txtId.Text));
            txtNombreUsuario.Text = usuario.NombreUsuario;
            txtContraseña.Text = usuario.contrasenha;
        }

        private void ActualizarButton_Click(object sender, RoutedEventArgs e)
        {

            if (ValidarCampos())
            {

                Medico medico = new Medico();
                medico.Identificacion = txtId.Text;
                medico.PrimerNombre = txtPNombre.Text;
                medico.SegundoNombre = txtSNombre.Text;
                medico.PrimerApellido = txtPApellido.Text;
                medico.SegundoApellido = txtSApellido.Text;
                if (fechaNacimientoPicker.SelectedDate.HasValue)
                {
                    string fechaSeleccionada = DateOnly.FromDateTime(fechaNacimientoPicker.SelectedDate.Value).ToString();
                    medico.FechaNacimiento = DateOnly.Parse(fechaSeleccionada);
                }
                if (RbtnMasculino.IsChecked == true)
                {
                    medico.Sexo = 'M';
                }
                else if (RbtnFemenino.IsChecked == true)
                {
                    medico.Sexo = 'F';
                }
                if (medico.Sexo == ' ')
                {
                    MessageBox.Show("Por favor, selecciona un sexo.");
                    return;

                }
                Usuario usuario = new Usuario();
                usuario.NombreUsuario = txtNombreUsuario.Text;
                usuario.contrasenha = txtContraseña.Text;
                    var message = ServiceMedic.Actualizar(medico, usuario);
                    MessageBox.Show(message);
                    LimpiarCampos();
                
            }

        }
        public void LimpiarCampos()
        {
            txtId.Text = "";
            txtPNombre.Text = "";
            txtSNombre.Text = "";
            txtPApellido.Text = "";
            txtSApellido.Text = "";
            fechaNacimientoPicker.Text = "";
        }

        public bool ValidarCampos()
        {
            if (txtId.Text != "")
            {
                if (txtPNombre.Text != "")
                {
                    if (txtPApellido.Text != "")
                    {
                        if (txtSApellido.Text != "")
                        {
                            if (fechaNacimientoPicker.Text != "")
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("TE FALTAN CAMPOS POR COMPLETAR");
                                fechaNacimientoPicker.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("TE FALTAN CAMPOS POR COMPLETAR");
                            txtSApellido.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("TE FALTAN CAMPOS POR COMPLETAR");
                        txtPApellido.Focus();
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("TE FALTAN CAMPOS POR COMPLETAR");
                    txtPNombre.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("TE FALTAN CAMPOS POR COMPLETAR");
                txtId.Focus();
                return false;
            }
        }




    }
}


