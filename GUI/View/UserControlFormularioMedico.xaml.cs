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
        ServiceRol serviceRol = new ServiceRol();
        ServiceMedico serviceMedico = new ServiceMedico();
        public UserControlFormularioMedico()
        {
            InitializeComponent();
            serviceRol = new ServiceRol();
            serviceMedico = new ServiceMedico();
            serviceUser = new ServiceUser();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            Usuario usuario = new Usuario();
            usuario.IdUsuario = "4";
            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.contrasenha = txtContraseña.Text;
            Medico medico = new Medico();
            medico.Identificacion = txtId.Text;
            medico.PrimerNombre = txtPNombre.Text;
            medico.SegundoNombre = txtSNombre.Text;
            medico.PrimerApellido = txtPApellido.Text;
            medico.SegundoApellido = txtSApellido.Text; 
            medico.FechaNacmiento = DateOnly.Parse(txtFechaNacimiento.Text);
            medico.Sexo = char.Parse(txtsexo.Text);
            var message = serviceMedico.Guardar(medico,usuario);
            MessageBox.Show(message);

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ServiceRol serviceRol = new ServiceRol();   

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //serviceRol.CargarComboBox(cboRol_2);
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
            var message = serviceMedico.Eliminar(id);
            MessageBox.Show(message);
        }
    }
}
