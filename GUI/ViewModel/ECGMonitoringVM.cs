using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GUI.Model;
using LiveCharts;
using LiveCharts.Wpf;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
using Entidades;
using GUI.Utilities;
using System.Windows.Media;

namespace GUI.ViewModel
{
    public class ECGMonitoringVM : Utilities.ViewModelBase
    {
        // Propiedades para enlazar con la vista
        public Paciente Paciente { get; set; }
        public string FechaHoraECG { get; set; }
        public double FrecuenciaCardiaca { get; set; }
        public double AmplitudOnda { get; set; }
        public double VoltajeActual { get; set; }

        // Gráfica en tiempo real
        public SeriesCollection ECGSignalSeries { get; set; }
        public ObservableCollection<string> SignalTimeLabels { get; set; }

        // Comando para guardar en PDF
        public ICommand GuardarEnPDFCommand { get; set; }

        // Temporizador para simular datos en tiempo real
        private Random random;
        private int timeStep;

        public ECGMonitoringVM()
        {
            // Inicialización de datos
            Paciente = new Paciente { PrimerNombre = "Juan", PrimerApellido = "Pérez", Documento = "123456789" };
            FechaHoraECG = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            FrecuenciaCardiaca = 75.0; // Valor inicial (BPM)
            AmplitudOnda = 1.2;       // Valor inicial (mV)
            VoltajeActual = 0.0;      // Voltaje actual

            // Configuración de la gráfica
            ECGSignalSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "ECG Signal",
                    Values = new ChartValues<double>(),
                    PointGeometry = null, // Oculta puntos
                    StrokeThickness = 2
                }
            };
            SignalTimeLabels = new ObservableCollection<string>();

            // Inicialización de temporizador para datos simulados
            random = new Random();
            timeStep = 0;

            // Comando para guardar en PDF
            GuardarEnPDFCommand = new RelayCommand(GuardarEnPDF);

            // Simulación de datos en tiempo real
            IniciarSimulacion();
        }

        private void IniciarSimulacion()
        {
            // Usa un temporizador para actualizar datos simulados
            System.Timers.Timer timer = new System.Timers.Timer(500); // Cada 500 ms
            timer.Elapsed += (sender, e) =>
            {
                // Genera valores aleatorios para la señal
                double nuevoVoltaje = Math.Sin(timeStep * 0.1) * AmplitudOnda + random.NextDouble() * 0.1;
                VoltajeActual = nuevoVoltaje;

                // Actualiza gráfica
                App.Current.Dispatcher.Invoke(() =>
                {
                    ECGSignalSeries[0].Values.Add(nuevoVoltaje);
                    SignalTimeLabels.Add((timeStep * 0.5).ToString("0.0"));

                    // Limita la cantidad de puntos en la gráfica
                    if (ECGSignalSeries[0].Values.Count > 100)
                    {
                        ECGSignalSeries[0].Values.RemoveAt(0);
                        SignalTimeLabels.RemoveAt(0);
                    }
                });

                timeStep++;
            };
            timer.Start();
        }

        private void GuardarEnPDF(object parameter)
        {
            try
            {
                string filename = $"ECG_Report_{Paciente.Documento}.pdf";

                // Crea un nuevo documento PDF
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Reporte de ECG";

                // Página
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Texto
                gfx.DrawString("Reporte de ECG", new XFont("Arial", 20, XFontStyle.Bold), XBrushes.Black, new XPoint(40, 40));
                gfx.DrawString($"Paciente: {Paciente.PrimerNombre} {Paciente.PrimerApellido}", new XFont("Arial", 14), XBrushes.Black, new XPoint(40, 80));
                gfx.DrawString($"Documento: {Paciente.Documento}", new XFont("Arial", 14), XBrushes.Black, new XPoint(40, 100));
                gfx.DrawString($"Fecha: {FechaHoraECG}", new XFont("Arial", 14), XBrushes.Black, new XPoint(40, 120));
                gfx.DrawString($"Frecuencia Cardíaca (BPM): {FrecuenciaCardiaca}", new XFont("Arial", 14), XBrushes.Black, new XPoint(40, 140));
                gfx.DrawString($"Amplitud de Onda (mV): {AmplitudOnda}", new XFont("Arial", 14), XBrushes.Black, new XPoint(40, 160));

                // Gráfica (simulada como rectángulo aquí)
                gfx.DrawRectangle(XPens.Black, XBrushes.LightGray, new XRect(40, 200, 500, 200));

                // Guarda el archivo
                document.Save(filename);

                // Notifica al usuario
                System.Windows.MessageBox.Show($"Reporte guardado como {filename}", "Éxito", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error al guardar PDF: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
    }
}
