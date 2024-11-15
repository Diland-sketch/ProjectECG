using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GUI.Model;
using LiveCharts;
using LiveCharts.Wpf;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using Entidades;
using GUI.Utilities;

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
            Paciente = new Paciente("123456789", "Juan", "SegundoNombre", "Pérez", "SegundoApellido", DateOnly.Parse("1990-01-01"), 'M');
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
                //App.Current.Dispatcher.Invoke(() =>
                //{
                //    ECGSignalSeries[0].Values.Add(nuevoVoltaje);
                //    SignalTimeLabels.Add((timeStep * 0.5).ToString("0.0"));

                //    // Limita la cantidad de puntos en la gráfica
                //    if (ECGSignalSeries[0].Values.Count > 100)
                //    {
                //        ECGSignalSeries[0].Values.RemoveAt(0);
                //        SignalTimeLabels.RemoveAt(0);
                //    }
                //});

                timeStep++;
            };
            timer.Start();
        }

        private void GuardarEnPDF(object parameter)
        {
            try
            {
                string filename = $"ECG_Report_{Paciente.Documento}.pdf";

                // Crea un nuevo documento PDF con iTextSharp
                using (PdfWriter writer = new PdfWriter(filename))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document document = new Document(pdf);

                        //// Título
                        //document.Add(new Paragraph("Reporte de ECG")
                        //    .SetFont(iText.Kernel.Props.PdfFontFactory.CreateFont(iText.Kernel.Props.PdfFontFactory.HELVETICA_BOLD))
                        //    .SetFontSize(20));

                        //// Información del paciente
                        //document.Add(new Paragraph($"Paciente: {Paciente.PrimerNombre} {Paciente.PrimerApellido}")
                        //    .SetFont(iText.Kernel.Props.PdfFontFactory.CreateFont(iText.Kernel.Props.PdfFontFactory.HELVETICA))
                        //    .SetFontSize(14));
                        //document.Add(new Paragraph($"Documento: {Paciente.Documento}")
                        //    .SetFont(iText.Kernel.Props.PdfFontFactory.CreateFont(iText.Kernel.Props.PdfFontFactory.HELVETICA))
                        //    .SetFontSize(14));
                        //document.Add(new Paragraph($"Fecha: {FechaHoraECG}")
                        //    .SetFont(iText.Kernel.Props.PdfFontFactory.CreateFont(iText.Kernel.Props.PdfFontFactory.HELVETICA))
                        //    .SetFontSize(14));
                        //document.Add(new Paragraph($"Frecuencia Cardíaca (BPM): {FrecuenciaCardiaca}")
                        //    .SetFont(iText.Kernel.Props.PdfFontFactory.CreateFont(iText.Kernel.Props.PdfFontFactory.HELVETICA))
                        //    .SetFontSize(14));
                        //document.Add(new Paragraph($"Amplitud de Onda (mV): {AmplitudOnda}")
                        //    .SetFont(iText.Kernel.Props.PdfFontFactory.CreateFont(iText.Kernel.Props.PdfFontFactory.HELVETICA))
                        //    .SetFontSize(14));

                        //// Agregar la simulación de la gráfica (se puede reemplazar con una imagen real de la gráfica si es necesario)
                        //document.Add(new Paragraph("Gráfica simulada: (Esto es solo un rectángulo para la demo)")
                        //    .SetFont(iText.Kernel.Props.PdfFontFactory.CreateFont(iText.Kernel.Props.PdfFontFactory.HELVETICA))
                        //    .SetFontSize(12));

                        // Guarda el archivo
                        document.Close();
                    }
                }

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
