
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
using Entidades;
using Logica;

namespace GUI.View
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        ServiceUser serviceUser = new ServiceUser();

        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) 
            {
                DragMove();
            }
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario()
            {
                NombreUsuario = txtUser.Text,
                Contrasenha = txtPassword.Password
            };


            int loginExitoso = serviceUser.Login(usuario);

            if (loginExitoso == 1)
            {
                MessageBox.Show("Bienvenido de nuevo Admin");
                DashBoardView viewAdmin = new DashBoardView();
                viewAdmin.Show();
                this.Close();
            }
            else
            {
                if (loginExitoso == 2)
                {
                    MessageBox.Show("Bienvenido, Medico");
                    DashBoardView viewDash = new DashBoardView();
                    viewDash.Show();
                    this.Close();
                }
                else
                {
                    if(loginExitoso == -1)
                    {
                        MessageBox.Show("Credenciales erroneas");
                        LoginView viewLogin = new LoginView();
                        viewLogin.Show();
                    }
                }
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ViewPaciente viewPaciente = new ViewPaciente();
            viewPaciente.Show();
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                txtPassword.Focus();
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUser.Focus();
        }
    }
}
