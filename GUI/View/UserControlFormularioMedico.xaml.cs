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
        public UserControlFormularioMedico()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            DateTime? fechaNacimiento = fechaNacimientoPicker.SelectedDate;
            char sexo = ' ';
            if (radioMasculino.IsChecked == true)
            {
                sexo = 'M';
            }
            else if (radioFemenino.IsChecked == true)
            {
                sexo = 'F';
            }
            if (sexo == ' ')
            {
                MessageBox.Show("Por favor, selecciona un sexo.");
                return;
            }
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

        }
    }
}
