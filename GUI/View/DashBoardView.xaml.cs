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
        public void VolverVistaAnterior()
        {
            if (vistaAnterior.Count > 0)
            {
                Pages.Content = vistaAnterior.Pop();
            }
        }

    }
}
