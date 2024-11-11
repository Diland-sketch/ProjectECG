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
            UserControlCrudMedico userControlCrudMedico = new UserControlCrudMedico();
            panelMedico.Children.Add(userControlCrudMedico);
        }
        private void Label_mouse(object sender, MouseButtonEventArgs e)
        {
            panelMedico.Children.Clear();
            UserControlCrudRol userControlCrudRol = new UserControlCrudRol();
            panelMedico.Children.Add(userControlCrudRol);
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
    }
}
