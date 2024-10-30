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
            panelMedico.Children.Clear();
            UserControlFormularioMedico userControlFormularioMedico = new UserControlFormularioMedico();
            panelMedico.Children.Add(userControlFormularioMedico);
        }
        
        
    }
}
