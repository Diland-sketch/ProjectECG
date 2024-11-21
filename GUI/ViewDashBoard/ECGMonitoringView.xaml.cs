using Entidades;
using Logica;
using Persitencia;
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
using System.Windows.Threading;



namespace GUI.ViewDashBoard
{
    /// <summary>
    /// Lógica de interacción para ECGMonitoringView.xaml
    /// </summary>
    public partial class ECGMonitoringView : UserControl
    {
        public ServicePaciente servicePaciente;
        public ServiceIncidente service;
        public ServiceMedico serviceMedico;
        public ServiceIncidente ServiceIncidente;
        public ServiceSesionECG serviceSesion;
        private DispatcherTimer fechaHoraTimer;
        private DispatcherTimer fechaHoraTimer2;

        public static class global
        {
            public static int id;
        }
        public ECGMonitoringView()
        {
            InitializeComponent();
            graphView.BpmActualizado += ActualizarFrecuenciaVista;
            servicePaciente = new ServicePaciente();
            service = new ServiceIncidente();
            serviceMedico = new ServiceMedico();
            serviceSesion = new ServiceSesionECG();
            ServiceIncidente = new ServiceIncidente();
            fechaHoraTimer = new DispatcherTimer();
            fechaHoraTimer.Interval = TimeSpan.FromSeconds(1);
            fechaHoraTimer.Tick += ActualizarFechaHora;
            fechaHoraTimer.Start();
            fechaHoraTimer2 = new DispatcherTimer();
            fechaHoraTimer2.Interval = TimeSpan.FromSeconds(1);
            fechaHoraTimer2.Tick += ActualizarFechaHora2;
            fechaHoraTimer2.Start();
        }

        private void ActualizarFrecuenciaVista(double bpm)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                txtFrecuencia.Text = bpm.ToString("F0");
            });

            if(bpm < 40)
            {
                Incidentes incidentes = new Incidentes();
                incidentes.IdSesionECG = global.id;
                incidentes.FechaHoraIncidente = DateTime.Now;
                incidentes.Descripcion = "Pico bajo detectado";
                ServiceIncidente.Guardar(incidentes);
              
            }
            else
            {
                if(bpm > 100)
                {
                    Incidentes incidentes = new Incidentes();
                    incidentes.IdSesionECG = global.id;
                    incidentes.FechaHoraIncidente = DateTime.Now;
                    incidentes.Descripcion = "Pico alto detectado";
                    ServiceIncidente.Guardar(incidentes);
                    //SesionECG sesion = new SesionECG();
                    //sesion.Estado = "Frecuencia Alta";
                    //sesion.IdSesion = global.id;
                    //serviceSesion.ActualizarEstado(sesion.Estado, sesion.IdSesion);
                }
                //else
                //{
                //    //SesionECG sesion = new SesionECG();
                //    //sesion.Estado = "Frecuencia Normalizada";
                //    //sesion.IdSesion = global.id;
                //    //serviceSesion.ActualizarEstado(sesion.Estado, sesion.IdSesion);
                //}
            }
        }

        private void ActualizarFechaHora(object sender, EventArgs e)
        {
            fechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void ActualizarFechaHora2(object sender, EventArgs e)
        {
            fechaHoraFinal.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            fechaHoraTimer.Stop();
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDocumento.Text) || string.IsNullOrEmpty(txtIdMedico.Text))
                {
                    MessageBox.Show("Por favor, complete los datos del paciente y del médico.");
                    return;
                }

                graphView.Iniciar_Click(sender, e);
                fechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                fechaHoraTimer.Stop();

                var sesion = new SesionECG
                {
                    IdPaciente = txtDocumento.Text,
                    IdMedico = txtIdMedico.Text,
                    InicioSesionECG = DateTime.Parse(fechaHora.Text),
                    FinSesionECG = null,
                    Descripcion = null
                };

                var message = serviceSesion.Guardar(sesion);
                global.id = serviceSesion.Mostrarid();           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
            }
        }
        private void btnDetener_Click(object sender, RoutedEventArgs e)
        {
            graphView.Detener_Click(sender, e);
            fechaHoraFinal.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            fechaHoraTimer2.Stop();

            string num = ServiceIncidente.MostrarNumeroIncidente(global.id);
            int valor = int.Parse(num[0].ToString());

            if (valor <5)
            {
                SesionECG sesion = new SesionECG();
                sesion.Estado = "frecuencia buena";
                sesion.IdSesion = global.id;
                serviceSesion.ActualizarEstado(sesion.Estado, sesion.IdSesion);
            }
            else
            {
                if (valor <10)
                {
                    SesionECG sesion = new SesionECG();
                    sesion.Estado = "frecuencia regular";
                    sesion.IdSesion = global.id;
                    serviceSesion.ActualizarEstado(sesion.Estado, sesion.IdSesion);
                }
                else
                {
                    SesionECG sesion = new SesionECG();
                    sesion.Estado = "frecuencia a revision";
                    sesion.IdSesion = global.id;
                    serviceSesion.ActualizarEstado(sesion.Estado, sesion.IdSesion);
                }
            }
            MessageBox.Show("\"La sesión ha finalizado. Por favor, complete la descripción y guarde.");
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
            SesionECG sesion = new SesionECG()
            {
                IdPaciente = txtDocumento.Text,
                IdMedico = txtIdMedico.Text,
                FinSesionECG = DateTime.Parse(fechaHoraFinal.Text),
                Descripcion = TextArea.Text,
            };
            var message = serviceSesion.Actualizar(sesion);
            MessageBox.Show(message);
        }
        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            int u = servicePaciente.RetornarIdMedico();
            txtIdMedico.Text = serviceMedico.MostrarId(u);

        }
        private void txtId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Permitir solo números
            e.Handled = !Regex.IsMatch(e.Text, @"^\d+$");
        }
    }
}
