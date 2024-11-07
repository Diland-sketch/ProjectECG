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
        ServiceRol serviceRol;
        ServiceMedico serviceMedico;
        ServiceUser serviceUser;

        public UserControlFormularioMedico()
        {
            InitializeComponent();
            serviceRol = new ServiceRol();
            serviceMedico = new ServiceMedico();
            serviceUser = new ServiceUser();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var id = txtId.Text;
            var nombre1 = txtPNombre.Text;
            var nombre2 = txtSNombre.Text;
            var apellido1 = txtPApellido.Text;
            var apellido2 = txtSApellido.Text;
            var sexo = Char.Parse(txtSexo.Text);
            var username = txtNombreUsuario.Text;
            var password = txtContraseña.Text;
            var fecha = DateTime.Parse(txtFechaNacimiento.Text);

            Rol rol = new Rol();
            rol.NombreRol = "medico";
            rol.IdRol = 1;


            Usuario user = new Usuario(1, username, password, rol);
            var message2 = serviceUser.Guardar(user);

            Medico medico = new Medico(id, nombre1, nombre2, apellido1, apellido2, fecha, sexo, user);

            var message = serviceMedico.Guardar(medico);
            MessageBox.Show(message, message2);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            serviceRol.CargarComboBox(cboRol_2);
        }
    }
}
