using Entidades;
using GUI.View;
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
    /// Lógica de interacción para UserControlDetallePacientes.xaml
    /// </summary>
    public partial class UserControlDetallePacientes : UserControl
    {
        public UserControlDetallePacientes()
        {
            InitializeComponent();
        }
        public void CargarDetalles(Medico medico)
        {
            txtId.Text = medico.Identificacion.ToString();
            txtNombre.Text = medico.PrimerNombre;
            txtSexo.Text = medico.Sexo.ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as DashBoardView;

            if (mainWindow != null)
            {
                mainWindow.VolverVistaAnterior();
            }
        }
    }
}
