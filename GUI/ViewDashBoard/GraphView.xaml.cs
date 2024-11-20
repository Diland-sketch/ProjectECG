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
        private List<double> datosGraficados =  new List<double>();
        public SeriesCollection EcgSeries { get; set; }

        private readonly Queue<double> _buffer = new Queue<double>();
        private const int BufferSize = 5;
        private System.Timers.Timer _graficaTimer;

        public GraphView()
        {
            InitializeComponent();
            
            _graficaTimer = new System.Timers.Timer(200);
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

            DetectarPicos(valorEscalado, DateTime.Now);
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
            _graficaTimer.Stop();
            _serviceEcg.DetenerLectura();
            _serviceEcg.DatoRecibido -= OnDatoRecibido;

            lock (_datosBuffer)
            {
                _datosBuffer.Clear();
            }
            _ecgValues.Clear();
            ecgChart.Update();
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

        public event Action<double> BpmActualizado;

        private void NotificarBpmActualizado()
        {
            BpmActualizado?.Invoke(bpmActual);
        }

        private List<DateTime> tiemposPicos = new List<DateTime>();

        public void DetectarPicos(double nuevoValor, DateTime tiempoActual)
        {
            double umbralDinamico = _ecgValues.Max() * 0.6;

            if(nuevoValor > umbralDinamico)
            {
                if(tiemposPicos.Count == 0 || (tiempoActual - tiemposPicos.Last()).TotalMilliseconds > 300)
                {
                    tiemposPicos.Add(tiempoActual);
                }
            }
            if (tiemposPicos.Count > 100) tiemposPicos.RemoveAt(0);

            CalcularBpm();
            NotificarBpmActualizado();
        }

        public double bpmActual = 0;
        public double CalcularBpm()
        {
            if (tiemposPicos.Count > 1)
            {
                var intervalosRR = new List<double>();
                for (int i = 1; i < tiemposPicos.Count; i++)
                {
                    intervalosRR.Add((tiemposPicos[i] - tiemposPicos[i - 1]).TotalSeconds);
                }

                if (intervalosRR.Count > 0)
                {
                    intervalosRR = intervalosRR.Where(rr => rr > 0.3 && rr < 2.0).ToList();
                    if (intervalosRR.Any())
                    {
                        double promedioRR = intervalosRR.Average();
                        bpmActual = promedioRR > 0 ? 60 / promedioRR : 0;
                    }
                }
            }
            return bpmActual;
        }
    }
}
