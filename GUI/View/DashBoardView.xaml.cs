using GUI.View;
using GUI.ViewDashBoard;
using GUI.ViewModel;
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

namespace GUI
{
    /// <summary>
    /// Lógica de interacción para DashBoardView.xaml
    /// </summary>
    public partial class DashBoardView : Window
    {
        private Stack<object> vistaAnterior;
        public DashBoardView()
        {
            InitializeComponent();
            vistaAnterior = new Stack<object>();
        }
            private void CloseApp_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
        public void CambiarVista(UserControl nuevaVista)
        {
            if (Pages.Content != null)
            {
                vistaAnterior.Push(Pages.Content);
            }
            Pages.Content = nuevaVista;
        }
        //private void btnPanelPaciente_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    btnPanelPaciente.Visibility = Visibility.Visible;
        //}

        //private void btnPanelPaciente_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    btnPanelPaciente.Visibility = Visibility.Collapsed;
        //}
        public void VolverVistaAnterior()
        {
            if (vistaAnterior.Count > 0)
            {
                Pages.Content = vistaAnterior.Pop();
            }
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            // Cambia la vista actual a HomeView
            NavigationVM navigationVM = DataContext as NavigationVM;
            if (navigationVM != null)
            {
                navigationVM.CurrentView = new HomeView();  // Establece HomeView como la vista actual
            }
        }
        private void Label_mouse(object sender, MouseButtonEventArgs e)
        {
            LoginView mainWindow = new LoginView();
            mainWindow.Show();
            this.Close();
        }
    }
}
