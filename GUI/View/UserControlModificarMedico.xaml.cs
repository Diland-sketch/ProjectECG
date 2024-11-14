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
        ServiceMedico serviceMedico;
        public UserControlModificarMedico()
        {
            InitializeComponent();
            serviceMedico = new ServiceMedico();
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
            Usuario usuario = new Usuario();
            Medico medico = new Medico();
            medico.Identificacion = txtId.Text;
            medico.PrimerNombre = txtPNombre.Text;
            medico.SegundoNombre = txtSNombre.Text;
            medico.PrimerApellido = txtPApellido.Text;
            medico.SegundoApellido = txtSApellido.Text;
            if (fechaNacimientoPicker.SelectedDate.HasValue)
            {
                string fechaSeleccionada = DateOnly.FromDateTime(fechaNacimientoPicker.SelectedDate.Value).ToString();
                medico.FechaNacmiento = DateOnly.Parse(fechaSeleccionada);
            }

            var message = serviceMedico.Actualizar(medico, usuario);
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
        private void IdentificacionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool tieneIdentificacion = !string.IsNullOrWhiteSpace(txtId.Text);
            txtPNombre.IsEnabled = tieneIdentificacion;
            txtPApellido.IsEnabled = tieneIdentificacion;
            fechaNacimientoPicker.IsEnabled = tieneIdentificacion;
            txtSNombre.IsEnabled = tieneIdentificacion;
            txtSApellido.IsEnabled = tieneIdentificacion;
        }
    }
}
