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
        public ConsultPatient()
        {
            InitializeComponent();
        }
        private void txtId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^\d+$");
        }

        private void txtDocumentoBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnBusar_Click(sender, e);
            }
        }
        private void btnBusar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
