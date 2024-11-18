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



namespace GUI.ViewDashBoard
{
    /// <summary>
    /// Lógica de interacción para ECGMonitoringView.xaml
    /// </summary>
    public partial class ECGMonitoringView : UserControl 
    {
        public ECGMonitoringView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            graphView.Iniciar_Click(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            graphView.Detener_Click(sender, e);
        }
        private void IdentificacionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool tieneIdentificacion = !string.IsNullOrWhiteSpace(txtDocumento.Text);
            txtNombre.IsEnabled = tieneIdentificacion;
            txtApellido.IsEnabled = tieneIdentificacion;
            txtFecha.IsEnabled = tieneIdentificacion;
            txtAmplitud.IsEnabled = tieneIdentificacion;
            txtFrecuencia.IsEnabled = tieneIdentificacion;
        }
    }
}
