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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Lógica de interacción para UserControlCrudMedico.xaml
    /// </summary>
    public partial class UserControlCrudMedico : UserControl
    {
        public UserControlCrudMedico()
        {
            InitializeComponent();
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
                UserControlFormularioMedico agregarMedico = new UserControlFormularioMedico();
                mainWindow.panelMedico.Children.Add(agregarMedico);
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation();
            fadeInAnimation.From = 0;
            fadeInAnimation.To = 1;
            fadeInAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            this.BeginAnimation(UserControl.OpacityProperty, fadeInAnimation);
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
                UserControlEliminarMedico eliminarMedico = new UserControlEliminarMedico();
                mainWindow.panelMedico.Children.Add(eliminarMedico);
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
                UserControlModificarMedico modificarMedico = new UserControlModificarMedico();
                mainWindow.panelMedico.Children.Add(modificarMedico);
            }
        }

        private void btnConsulta_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
                UserControlConsultaMedico consultaMedico = new UserControlConsultaMedico();
                mainWindow.panelMedico.Children.Add(consultaMedico);
            }
        }
    }
}
