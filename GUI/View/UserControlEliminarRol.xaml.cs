﻿using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Lógica de interacción para UserControlEliminarRol.xaml
    /// </summary>
    public partial class UserControlEliminarRol : UserControl
    {
        ServiceRol ServiceRol;
        public UserControlEliminarRol()
        {
            InitializeComponent();
            ServiceRol = new ServiceRol();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation();
            fadeInAnimation.From = 0;
            fadeInAnimation.To = 1;
            fadeInAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            this.BeginAnimation(UserControl.OpacityProperty, fadeInAnimation);
        }

        

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var message = ServiceRol.Eliminar(txtNombre.Text);
            MessageBox.Show(message);
            txtNombre.Text = "";
        }
        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[a-zA-Z]+$");
        }
        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnEliminar_Click(sender, e);
            }
        }
    }
}
