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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Lógica de interacción para UserControlFormularioMedico.xaml
    /// </summary>
    public partial class UserControlFormularioMedico : UserControl
    {
        ServiceUser serviceUser;
        ServiceRol serviceRol;
        ServiceMedico serviceMedico;
        public UserControlFormularioMedico()
        {
            InitializeComponent();
            serviceRol = new ServiceRol();
            serviceMedico = new ServiceMedico();
            serviceUser = new ServiceUser();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos())
            {
                Usuario usuario = new Usuario();
                usuario.NombreUsuario = txtNombreUsuario.Text;
                usuario.Contrasenha = txtContraseña.Password;
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
                if (radioMasculino.IsChecked == true)
                {
                    medico.Sexo = 'M';
                }
                else if (radioFemenino.IsChecked == true)
                {
                    medico.Sexo = 'F';
                }
                if (medico.Sexo == ' ')
                {
                    MessageBox.Show("Por favor, selecciona un sexo.");
                    return;
                }

                var message = serviceMedico.Guardar(medico, usuario);
                MessageBox.Show(message);
                LimpiarCampos();
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            
        //    Usuario usuario = new Usuario();
        //    usuario.IdUsuario = "4";
        //    usuario.NombreUsuario = txtNombreUsuario.Text;
        //    usuario.Contrasenha = txtContraseña.Text;
        //    Medico medico = new Medico();
        //    medico.Identificacion = txtId.Text;
        //    medico.PrimerNombre = txtPNombre.Text;
        //    medico.SegundoNombre = txtSNombre.Text;
        //    medico.PrimerApellido = txtPApellido.Text;
        //    medico.SegundoApellido = txtSApellido.Text;
        //    medico.FechaNacmiento = DateOnly.Parse(txtFechaNacimiento.Text);
        //    medico.Sexo = char.Parse(txtsexo.Text);
        //    var message = serviceMedic.Guardar(medico,usuario);
        //    MessageBox.Show(message);


        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ServiceRol serviceRol = new ServiceRol();   

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Usuario usuario = new Usuario();
            //usuario.NombreUsuario = txtNombreUsuario.Text;
            //usuario.Contrasenha = txtContraseña.Text;
            //Medico medico = new Medico();
            //medico.Identificacion = txtId.Text;
            //medico.PrimerNombre = txtPNombre.Text;
            //medico.SegundoNombre = txtSNombre.Text;
            //medico.PrimerApellido = txtPApellido.Text;
            //medico.SegundoApellido = txtSApellido.Text;
            //medico.FechaNacmiento = DateOnly.Parse(txtFechaNacimiento.Text);
            //medico.Sexo = char.Parse(txtsexo.Text);
            //var message = serviceMedic.Actualizar(medico, usuario);
            //MessageBox.Show(message);
            //LimpiarCampos();

            //string id = txtId.Text;
            //var message = serviceMedic.Eliminar(id);
            //MessageBox.Show(message);
            Medico medico = new Medico();
            medico = serviceMedico.ConsultarId(txtId.Text);
            //txtFechaNacimiento.Text = medico.FechaNacmiento.ToString("dd-MM-yyyy");
            
        }
        public void LimpiarCampos()
        {
            txtId.Text = "";
            txtPNombre.Text = "";
            txtSNombre.Text = "";
            txtPApellido.Text = "";
            txtSApellido.Text = "";
            fechaNacimientoPicker.Text = "";
            txtNombreUsuario.Text = "";
            txtContraseña.Password = "";
        }

        public bool ValidarCampos()
        {
            if(txtId.Text != "")
            {
                if (txtPNombre.Text != "")
                {
                    if (txtPApellido.Text != "")
                    {
                        if (txtSApellido.Text != "")
                        {
                            if (fechaNacimientoPicker.Text != "")
                            {
                                if (txtNombreUsuario.Text != "")
                                {
                                    if (txtContraseña.Password != "")
                                    {
                                       return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("TE FALTAN CAMPOS POR COMPLETAR");
                                        txtContraseña.Focus();
                                        return false;
                                    }
                                }
                                else
                                {
                                     MessageBox.Show("TE FALTAN CAMPOS POR COMPLETAR");
                                     txtNombreUsuario.Focus();
                                     return false;
                                }
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
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation();
            fadeInAnimation.From = 0;
            fadeInAnimation.To = 1;
            fadeInAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            this.BeginAnimation(UserControl.OpacityProperty, fadeInAnimation);
        }
        private void txtId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^\d+$");
        }
        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[a-zA-Z]+$");
        }
    }
}
