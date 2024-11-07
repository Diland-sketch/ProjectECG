using Entidades;
using Logica;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRUEBA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceRol serviceRol = new ServiceRol();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Rol rol = new Rol();
            rol.IdRol = int.Parse(txt1.Text);
            rol.NombreRol = txt2.Text;
            var message = serviceRol.Guardar(rol);
            MessageBox.Show(message);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string idRol = txtEliminar.Text;
            var message = serviceRol.Eliminar(idRol);
            MessageBox.Show(message);
        }
    }
}