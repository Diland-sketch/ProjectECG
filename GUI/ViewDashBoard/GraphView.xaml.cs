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

        public GraphView()
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
                    Stroke = System.Windows.Media.Brushes.Red,
                    PointGeometry = null,
                    StrokeThickness = 1,
                    LineSmoothness = 0,
                    Fill = Brushes.Transparent
                }
            };

            ecgChart.Series = EcgSeries;
            ecgChart.AxisY.Add(new Axis { MinValue = -1, MaxValue = 1 });
            DataContext = this;
        }

        private void OnDatoRecibido(DatoECG dato)
        {
            Application.Current.Dispatcher.Invoke(() => ActualizarGrafica(dato));
        }

        public void Iniciar_Click(object sender, RoutedEventArgs e)
        {
            _serviceEcg.DatoRecibido += OnDatoRecibido;
            _serviceEcg.IniciarLectura();
        }

        public void Detener_Click(object sender, RoutedEventArgs e)
        {
            _serviceEcg.DatoRecibido -= OnDatoRecibido;
            _serviceEcg.DetenerLectura();
        }

        private void ActualizarGrafica(DatoECG dato)
        {
            double valorEscalado = (dato.Valor - 300) / 5;
            _ecgValues.Add(valorEscalado);

            if (_ecgValues.Count > 300)
            {
                _ecgValues.RemoveAt(0);
            }
            ecgChart.Update();
        }
    }
}
