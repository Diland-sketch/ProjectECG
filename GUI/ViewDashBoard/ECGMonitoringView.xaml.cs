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
using System.Windows.Threading;



namespace GUI.ViewDashBoard
{
    /// <summary>
    /// Lógica de interacción para ECGMonitoringView.xaml
    /// </summary>
    public partial class ECGMonitoringView : UserControl
    {
        public ServicePaciente servicePaciente;
        public ServiceMedico serviceMedico;
        ServiceSesionECG ServiceSesion;
        private DispatcherTimer fechaHoraTimer;
        public ECGMonitoringView()
        {
            InitializeComponent();
            servicePaciente = new ServicePaciente();
            serviceMedico = new ServiceMedico();
            ServiceSesion = new ServiceSesionECG();
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
            FechaHoraSesion();

        }

        public DateTime FechaHoraSesion()
        {
            DateTime fecha = DateTime.Parse(fechaHora.Text);
            return fecha;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            graphView.Detener_Click(sender, e);
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Paciente paciente = new Paciente();
            paciente = servicePaciente.TraerPaciente(txtDocumento.Text);
           string nombre = paciente.PrimerNombre;
            string apellido = paciente.PrimerApellido;
            if ((nombre != null) && (apellido != null))
            {
                txtNombre.Text = nombre;
                txtApellido.Text = apellido;
                
            }
            else
            {
                MessageBox.Show("paciente no encontrado");
            }
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            int u = servicePaciente.RetornarIdMedico();
            txtIdMedico.Text = serviceMedico.MostrarId(u);
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            SesionECG sesion = new SesionECG();
            sesion.IdPaciente = txtDocumento.Text;
            sesion.IdMedico = txtIdMedico.Text;
            sesion.Descripcion = TextArea.Text;
            sesion.InicioSesionECG = FechaHoraSesion();
            sesion.FinSesionECG = FechaHoraSesion();
            var message = ServiceSesion.Guardar(sesion);
            MessageBox.Show(message);
        }
        private void txtId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Permitir solo números
            e.Handled = !Regex.IsMatch(e.Text, @"^\d+$");
        }
    }
}
