using BLL;
using ENTITY;
using LiveCharts;
using LiveCharts.Definitions.Charts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
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
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Lógica de interacción para ViewGraficaECG.xaml
    /// </summary>
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
            //_serviceEcg.IniciarLectura();

            EcgSeries = new SeriesCollection()
{
                new LineSeries
                {
                    Values = _ecgValues,
                    PointGeometry = null,
                    StrokeThickness = 2
                }   
            };

            if (ecgChart.Series.Count == 0)
            {
                var lineaSerie = new LineSeries
                {
                    Values = _ecgValues,
                    PointGeometry = null,
                    StrokeThickness = 2
                };

                ecgChart.Series.Add(lineaSerie);
            }

            /*ecgChart.Series = EcgSeries;

            ecgChart.Series.Add(new LineSeries
            {
                Values = new ChartValues<double>()
            });*/

            DataContext = this;

        }
        private void OnDatoRecibido(DatoECG dato)
        {
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Verificamos si ecgChart tiene alguna serie añadida
                    if (ecgChart.Series.Count > 0)
                    {
                        // Si la serie existe, añadimos el dato
                        var serie = (LineSeries)ecgChart.Series[0];
                        serie.Values.Add(dato.Valor);

                        // Mantenemos el límite de 100 puntos
                        if (serie.Values.Count > 100)
                        {
                            serie.Values.RemoveAt(0);
                        }

                        ecgChart.Update();
                    }
                    else
                    {
                        // Si no hay ninguna serie, muestra un mensaje o maneja la situación
                        MessageBox.Show("No hay series disponibles para agregar datos.");
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar dato: {ex.Message}");
            }

        }

        private void Iniciar_Click(object sender, RoutedEventArgs e)
        {
            _serviceEcg.IniciarLectura();
            _serviceEcg.DatoRecibido += ActualizarGrafica;
        }

        private void Detener_Click(object sender, RoutedEventArgs e) 
        {
            _serviceEcg.DetenerLectura();
            _serviceEcg.DatoRecibido -= ActualizarGrafica;
        }

        private void ActualizarGrafica(DatoECG dato)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                // Verificar si la serie está disponible y si hay valores.
                if (ecgChart.Series.Count > 0 && _ecgValues != null)
                {
                    _ecgValues.Add(dato.Valor);

                    // Mantener solo los últimos 100 valores para evitar saturar la gráfica.
                    if (_ecgValues.Count > 100)
                    {
                        _ecgValues.RemoveAt(0);
                    }

                    ecgChart.Update();
                }
                else
                {
                    MessageBox.Show("No hay series disponibles para actualizar.");
                }
            });
        }
    }
}
