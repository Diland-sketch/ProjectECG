using Entidades;
using GUI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace GUI.ViewDashBoard
{
    /// <summary>
    /// Lógica de interacción para PatientHistoryView.xaml
    /// </summary>
    public partial class PatientHistoryView : UserControl
    {
        public PatientHistoryView()
        {
            InitializeComponent();
            cargar();
        }

        private void cargar()
        {
            var pacientes = new List<Paciente>{
                new Paciente { Identificacion = "1", PrimerNombre = "Juan" , Sexo = 'M'},
                new Paciente { Identificacion = "2", PrimerNombre = "Ana" , Sexo = 'M'},
                new Paciente { Identificacion = "3", PrimerNombre = "Carlos" , Sexo = 'M'}
            };
            pacientes = pacientes.Where(p => !string.IsNullOrEmpty(p.Identificacion) && !string.IsNullOrEmpty(p.PrimerNombre)).ToList();
            dataGridPacientes.ItemsSource = pacientes;
        }

        private void dataGridPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridPacientes.SelectedItem is Paciente pacienteSeleccionado)
            {
                CargarDetalles(pacienteSeleccionado);
            }
        }
        public void CargarDetalles(Paciente paciente)
        {

        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            var datosActuales = dataGridPacientes.ItemsSource as IEnumerable<Paciente>;

            if (datosActuales == null)
            {
                MessageBox.Show("No hay datos en el DataGrid para buscar.");
                return;
            }

            var listaMedicos = datosActuales.ToList();
            dataGridPacientes.ItemsSource = null;
            string idTexto = txtId1.Text;

            if (!string.IsNullOrEmpty(idTexto))
            {
                var medicoEncontrado = listaMedicos.Where(m => m.Identificacion.Equals(idTexto, StringComparison.OrdinalIgnoreCase)).ToList();

                if (medicoEncontrado.Any())
                {
                    dataGridPacientes.ItemsSource = medicoEncontrado;
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
                dataGridPacientes.ItemsSource = listaMedicos;
            }
            if (idTexto == null)
            {
                dataGridPacientes.ItemsSource = null;
                cargar();
            }
        }
    }
}
