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
    /// Lógica de interacción para UserControlConsultaMedico.xaml
    /// </summary>
    public partial class UserControlConsultaMedico : UserControl
    {
        ServiceMedico serviceMedico;
        public UserControlConsultaMedico()
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
            CargarMedicos();
        }
        private void CargarMedicos(){
            MedicosDataGrid.ItemsSource = serviceMedico.ConsultarTodo(); 
        }

        private void MedicosListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            var datosActuales = MedicosDataGrid.ItemsSource as IEnumerable<Medico>;

            if (datosActuales == null)
            {
                MessageBox.Show("No hay datos en el DataGrid para buscar.");
                return;
            }

            var listaMedicos = datosActuales.ToList();
            MedicosDataGrid.ItemsSource = null;
            string idTexto = txtId.Text;

            if (!string.IsNullOrEmpty(idTexto))
            {
                var medicoEncontrado = listaMedicos.Where(m => m.Identificacion.Equals(idTexto, StringComparison.OrdinalIgnoreCase)).ToList();

                if (medicoEncontrado.Any())
                {
                    MedicosDataGrid.ItemsSource = medicoEncontrado;
                }
                else
                {
                    MessageBox.Show("No se encontró ningún médico con el ID proporcionado.");
                    cargar();
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID para buscar.");
                MedicosDataGrid.ItemsSource = listaMedicos;
            }
            if (txtId.Text == null)
            {
                MedicosDataGrid.ItemsSource = null;
                cargar();
            }
        }

        private void cargar()
        {
            MedicosDataGrid.ItemsSource = serviceMedico.ConsultarTodo();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cargar();
            
        }
        private void txtId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^\d+$");
        }
    }
}
