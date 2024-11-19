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
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Lógica de interacción para viewAdmin.xaml
    /// </summary>
    public partial class viewAdmin : Window
    {
        
        public viewAdmin()
        {
            InitializeComponent();
        }
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //panelMedico.Children.Clear();
            //UserControlCrudMedico userControlCrudMedico = new UserControlCrudMedico();
            //panelMedico.Children.Add(userControlCrudMedico);

        }
        private void Label_mouse(object sender, MouseButtonEventArgs e)
        {
            //panelMedico.Children.Clear();
            //UserControlCrudRol userControlCrudRol = new UserControlCrudRol();
            //panelMedico.Children.Add(userControlCrudRol);
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Back(object sender, RoutedEventArgs e)
        {
            LoginView mainWindow = new LoginView();
            mainWindow.Show();
            this.Close();
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
        private void btnAgregarRol_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
                UserControlFormularioRol agregarMedico = new UserControlFormularioRol();
                mainWindow.panelMedico.Children.Add(agregarMedico);
            }
        }

        private void btnEliminarRol_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
                UserControlEliminarRol eliminarRol = new UserControlEliminarRol();
                mainWindow.panelMedico.Children.Add(eliminarRol);
            }
        }
        private void btnConsultaRol_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
                UserControlConsultaRol consultaRol = new UserControlConsultaRol();
                mainWindow.panelMedico.Children.Add(consultaRol);
            }
        }


        private void lblMedico_MouseEnter(object sender, MouseEventArgs e)
        {
            // Iniciar la animación para que el panel aparezca desde la izquierda
            var storyboard = (Storyboard)FindResource("SlideInAnimation");
            btnPanelMedico.Visibility = Visibility.Visible; // Asegurarse de que sea visible
            storyboard.Begin(btnPanelMedico);
        }

        private void lblMedico_MouseLeave(object sender, MouseEventArgs e)
        {
            // No hacer nada; manejarlo con el MouseLeave del StackPanel
        }

        private void btnPanelMedico_MouseEnter(object sender, MouseEventArgs e)
        {
            // Mantener el panel visible mientras el mouse esté sobre él
            var storyboard = (Storyboard)FindResource("SlideInAnimation");
            storyboard.Begin(btnPanelMedico);
        }

        private void btnPanelMedico_MouseLeave(object sender, MouseEventArgs e)
        {
            // Animación para ocultar el panel hacia la izquierda
            var storyboard = (Storyboard)FindResource("SlideOutAnimation");
            storyboard.Completed += (s, ev) => btnPanelMedico.Visibility = Visibility.Collapsed; // Ocultar después de la animación
            storyboard.Begin(btnPanelMedico);
        }


        private void lblRol_MouseEnter(object sender, MouseEventArgs e)
        {
            // Iniciar la animación para que el panel aparezca desde la izquierda
            var storyboard = (Storyboard)FindResource("SlideInAnimation");
            btnPanelRol.Visibility = Visibility.Visible; // Asegurarse de que sea visible
            storyboard.Begin(btnPanelRol);
        }

        private void lblRol_MouseLeave(object sender, MouseEventArgs e)
        {
            // No hacer nada; manejarlo con el MouseLeave del StackPanel
        }

        private void btnPanelRol_MouseEnter(object sender, MouseEventArgs e)
        {
            // Mantener el panel visible mientras el mouse esté sobre él
            var storyboard = (Storyboard)FindResource("SlideInAnimation");
            storyboard.Begin(btnPanelRol);
        }

        private void btnPanelRol_MouseLeave(object sender, MouseEventArgs e)
        {
            // Animación para ocultar el panel hacia la izquierda
            var storyboard = (Storyboard)FindResource("SlideOutAnimation");
            storyboard.Completed += (s, ev) => btnPanelRol.Visibility = Visibility.Collapsed; // Ocultar después de la animación
            storyboard.Begin(btnPanelRol);
        }
    }
}
