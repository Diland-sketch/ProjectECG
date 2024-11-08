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
            public DashBoardView() => InitializeComponent();
            // Método que se llama cuando el usuario hace clic en el botón para cerrar la aplicación
            private void CloseApp_Click(object sender, RoutedEventArgs e)
            {
                // Cierra la aplicación
                this.Close();
            }
        
    }
}
