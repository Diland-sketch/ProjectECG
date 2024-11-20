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
    /// Lógica de interacción para UserControlConsultaRol.xaml
    /// </summary>
    public partial class UserControlConsultaRol : UserControl
    {
        ServiceRol serviceRol;
        public List<Rol> roles { get; set; }
        public UserControlConsultaRol()
        {
            InitializeComponent();
            serviceRol = new ServiceRol();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation();
            fadeInAnimation.From = 0;
            fadeInAnimation.To = 1;
            fadeInAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            this.BeginAnimation(UserControl.OpacityProperty, fadeInAnimation);
            CargarRoles();
        }
        private void CargarRoles()
        {
            RolesDataGrid.ItemsSource = serviceRol.ConsultarTodo();
        }
        

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            var datosActuales = RolesDataGrid.ItemsSource as IEnumerable<Rol>;

            if (datosActuales == null)
            {
                MessageBox.Show("No hay datos en el DataGrid para buscar.");
                return;
            }

            var listaMedicos = datosActuales.ToList();
            RolesDataGrid.ItemsSource = null;
            string idTexto = txtNombre.Text;

            if (!string.IsNullOrEmpty(idTexto))
            {
                var medicoEncontrado = listaMedicos.Where(m => m.NombreRol.Equals(idTexto, StringComparison.OrdinalIgnoreCase)).ToList();

                if (medicoEncontrado.Any())
                {
                    RolesDataGrid.ItemsSource = medicoEncontrado;
                }
                else
                {
                    MessageBox.Show("No se encontró ningún médico con el ID proporcionado.");
                    CargarRoles();
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID para buscar.");
                RolesDataGrid.ItemsSource = listaMedicos;
            }
            if (txtNombre.Text == null)
            {
                RolesDataGrid.ItemsSource = null;
                CargarRoles();
            }
        }

        

        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[a-zA-Z]+$");
        }
    }
}
