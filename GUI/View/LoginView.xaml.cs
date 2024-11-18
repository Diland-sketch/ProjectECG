﻿
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

            bool loginExitoso = serviceUser.Login(usuario);

            if (loginExitoso) 
            {
                MessageBox.Show("Login exitoso");
                viewAdmin dashBoardView = new viewAdmin();
                dashBoardView.Show();
       
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
            txtUser.Text = "";
            txtPassword.Password = "";
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ViewPaciente viewPaciente = new ViewPaciente();
            viewPaciente.Show();
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
