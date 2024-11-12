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
    /// Lógica de interacción para UserControlCrudRol.xaml
    /// </summary>
    public partial class UserControlCrudRol : UserControl
    {
        public UserControlCrudRol()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation();
            fadeInAnimation.From = 0;
            fadeInAnimation.To = 1;
            fadeInAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            this.BeginAnimation(UserControl.OpacityProperty, fadeInAnimation);
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
                UserControlFormularioRol agregarMedico = new UserControlFormularioRol();
                mainWindow.panelMedico.Children.Add(agregarMedico);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
                UserControlEliminarRol eliminarRol = new UserControlEliminarRol();
                mainWindow.panelMedico.Children.Add(eliminarRol);
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
                UserControlModificarRol modificarRol = new UserControlModificarRol();
                mainWindow.panelMedico.Children.Add(modificarRol);
            }
        }

        private void btnConsulta_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
                UserControlConsultaRol consultaRol = new UserControlConsultaRol();
                mainWindow.panelMedico.Children.Add(consultaRol);
            }
        }
    }
}
