using ENTITY;
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
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Lógica de interacción para ViewPaciente.xaml
    /// </summary>
    public partial class ViewPaciente : Window
    {
        Persona persona = new Persona();
        Paciente paciente;
        public ViewPaciente()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            paciente.IdPaciente = txtId.Text;
            
        }
        public void Cargar()
        {
            ListView listView = new ListView();
            listView.Items.Clear();
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
