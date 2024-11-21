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
    /// Lógica de interacción para ConsultPatient.xaml
    /// </summary>
    public partial class ConsultPatient : UserControl
    {
        ServicePaciente ServicePaciente;
        public ConsultPatient()
        {
            InitializeComponent();
            ServicePaciente = new ServicePaciente();
        }
        private void txtId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^\d+$");
        }

        private void txtDocumentoBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }
    

        private void cargar()
        {
            PacienteDataGrid.ItemsSource = ServicePaciente.ConsultarTodo();
        }

        private void Pages_Loaded(object sender, RoutedEventArgs e)
        {
            cargar();   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var datosActuales = PacienteDataGrid.ItemsSource as IEnumerable<Paciente>;

            if (datosActuales == null)
            {
                MessageBox.Show("No hay datos en el DataGrid para buscar.");
                return;
            }

            var listaMedicos = datosActuales.ToList();
            PacienteDataGrid.ItemsSource = null;
            string idTexto = txtDocumentoBuscar.Text;

            if (!string.IsNullOrEmpty(idTexto))
            {
                var medicoEncontrado = listaMedicos.Where(m => m.Identificacion.Equals(idTexto, StringComparison.OrdinalIgnoreCase)).ToList();

                if (medicoEncontrado.Any())
                {
                    PacienteDataGrid.ItemsSource = medicoEncontrado;
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
                PacienteDataGrid.ItemsSource = listaMedicos;
                cargar();
            }
            if (txtDocumentoBuscar.Text == null)
            {
                PacienteDataGrid.ItemsSource = null;
                cargar();
            }
        }
    }
}
