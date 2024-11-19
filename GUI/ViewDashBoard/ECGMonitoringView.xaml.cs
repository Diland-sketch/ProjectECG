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
using System.Windows.Threading;



namespace GUI.ViewDashBoard
{
    /// <summary>
    /// Lógica de interacción para ECGMonitoringView.xaml
    /// </summary>
    public partial class ECGMonitoringView : UserControl 
    {
        ServicePaciente servicePaciente;
        private DispatcherTimer fechaHoraTimer;
        public ECGMonitoringView()
        {
            InitializeComponent();
            servicePaciente = new ServicePaciente();
            fechaHoraTimer = new DispatcherTimer();
            fechaHoraTimer.Interval = TimeSpan.FromSeconds(1);
            fechaHoraTimer.Tick += ActualizarFechaHora;
            fechaHoraTimer.Start();
        }

        private void ActualizarFechaHora(object sender, EventArgs e)
        {
            fechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            fechaHoraTimer.Stop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            graphView.Iniciar_Click(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            graphView.Detener_Click(sender, e);
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Paciente paciente = new Paciente();
            paciente = servicePaciente.TraerPaciente(txtDocumento.Text);
            txtNombre.Text = paciente.PrimerNombre;
            txtApellido.Text = paciente.PrimerApellido;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
