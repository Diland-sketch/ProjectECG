using Entidades;
using LiveCharts;
using LiveCharts.Wpf;
using Logica;
using System;
using System.Windows;
using System.Windows.Media;

namespace GUI.View
{
    public partial class ViewGraficaECG : Window
    {
        private ServiceECG _serviceEcg;
        private ChartValues<double> _ecgValues;
        public SeriesCollection EcgSeries { get; set; }

        public ViewGraficaECG()
        {
            InitializeComponent();

            _ecgValues = new ChartValues<double>();
            _serviceEcg = new ServiceECG("COM4", 9600);
            _serviceEcg.DatoRecibido += OnDatoRecibido;

            EcgSeries = new SeriesCollection
        {
            new LineSeries
            {
                Values = _ecgValues,
                PointGeometry = null,
                StrokeThickness = 1,
                LineSmoothness = 0, // Picos definidos
                Fill = Brushes.Transparent
            }
        };

            ecgChart.Series = EcgSeries;
            ecgChart.AxisY.Add(new Axis { MinValue = -30, MaxValue = 30 }); // Escala del eje Y
            DataContext = this;
        }

        private DateTime ultimoTiempoActualizacion = DateTime.MinValue;

        private void OnDatoRecibido(DatoECG dato)
        {
            if ((DateTime.Now - ultimoTiempoActualizacion).TotalMilliseconds >= 50) // Aumenta a 10 ms o más
            {
                Application.Current.Dispatcher.Invoke(() => ActualizarGrafica(dato));
                ultimoTiempoActualizacion = DateTime.Now;
            }
        }

        private void Iniciar_Click(object sender, RoutedEventArgs e)
        {
            _serviceEcg.DatoRecibido += OnDatoRecibido;
            _serviceEcg.IniciarLectura();
        }

        private void Detener_Click(object sender, RoutedEventArgs e)
        {
            _serviceEcg.DetenerLectura();
            _serviceEcg.DatoRecibido -= OnDatoRecibido;
        }

        private void ActualizarGrafica(DatoECG dato)
        {
            double valorEscalado = dato.Valor / 2; // Ajusta el factor si es necesario
            _ecgValues.Add(valorEscalado);

            if (_ecgValues.Count > 300)
            {
                _ecgValues.RemoveAt(0);
            }
            ecgChart.Update();
        }
    }

}
