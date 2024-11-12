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
        ServiceUser serviceUser = new ServiceUser();
        ServiceMedic serviceMedic = new ServiceMedic();
        public UserControlFormularioMedico()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.IdUsuario = "4";
            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.contrasenha = txtContraseña.Password;
            Medico medico = new Medico();
            medico.Identificacion = txtId.Text;
            medico.PrimerNombre = txtPNombre.Text;
            medico.SegundoNombre = txtSNombre.Text;
            medico.PrimerApellido = txtPApellido.Text;
            medico.SegundoApellido = txtSApellido.Text;
            if (fechaNacimientoPicker.SelectedDate.HasValue)
            {
                DateTime fechaSeleccionada = fechaNacimientoPicker.SelectedDate.Value;
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

            var message = serviceMedic.Guardar(medico, usuario);
            MessageBox.Show(message);
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            
        //    Usuario usuario = new Usuario();
        //    usuario.IdUsuario = "4";
        //    usuario.NombreUsuario = txtNombreUsuario.Text;
        //    usuario.contrasenha = txtContraseña.Text;
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
            //usuario.contrasenha = txtContraseña.Text;
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
            string id = txtId.Text;
            var message = serviceMedic.Eliminar(id);
            MessageBox.Show(message);
        }
    }
}
