using Entidades;
using LiveCharts.Wpf;
using LiveCharts;
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

namespace GUI.ViewDashBoard
{
    /// <summary>
    /// Lógica de interacción para GraphView.xaml
    /// </summary>
    public partial class GraphView : UserControl
    {
        private ServiceECG _serviceEcg;
        private ChartValues<double> _ecgValues;
        public SeriesCollection EcgSeries { get; set; }

        private readonly Queue<double> _buffer = new Queue<double>();
        private const int BufferSize = 5;
        private System.Timers.Timer _graficaTimer;

        public GraphView()
        {
            InitializeComponent();
            
            _graficaTimer = new System.Timers.Timer(100);
            _graficaTimer.Elapsed += (s, e) => ActualizarGraficaDesdeBuffer();
            _graficaTimer.Start();

            _ecgValues = new ChartValues<double>();
            _serviceEcg = new ServiceECG("COM4", 9600);
            _serviceEcg.DatoRecibido += OnDatoRecibido;

            EcgSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Values = _ecgValues,
                    Stroke = System.Windows.Media.Brushes.Red,
                    PointGeometry = null,
                    StrokeThickness = 1,
                    LineSmoothness = 0,
                    Fill = Brushes.Transparent
                }
            };

            ecgChart.Series = EcgSeries;
            ecgChart.AxisY.Add(new Axis { MinValue = -1, MaxValue = 1 });
        }

        private readonly List<double> _datosBuffer = new List<double>();
        private void OnDatoRecibido(DatoECG dato)
        {
            double valorEscalado = (dato.Valor - 300);
            lock (_datosBuffer)
            {
                _datosBuffer.Add(valorEscalado);
            }
        }

        private void ActualizarGraficaDesdeBuffer()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                lock (_datosBuffer)
                {
                    foreach (var dato in _datosBuffer)
                    {
                        double datoFiltrado = FiltrarDato(dato);
                        _ecgValues.Add(datoFiltrado);
                        if (_ecgValues.Count > 300)
                        {
                            _ecgValues.RemoveAt(0);
                        }
                    }
                    _datosBuffer.Clear();
                }
                ecgChart.Update();
            });
        }
    

        public void Iniciar_Click(object sender, RoutedEventArgs e)
        {
            _serviceEcg.IniciarLectura();
        }

        public void Detener_Click(object sender, RoutedEventArgs e)
        {
            _serviceEcg.DetenerLectura();
        }

        private double FiltrarDato(double nuevoDato)
        {
            if (_buffer.Count > BufferSize)
            {
                _buffer.Dequeue();
            }
            _buffer.Enqueue(nuevoDato);

            return _buffer.Average();
        }
    }
}
