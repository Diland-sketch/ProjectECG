﻿using Entidades;
using Logica;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.View
{
    /// <summary>
    /// Lógica de interacción para UserControlConsultaRol.xaml
    /// </summary>
    public partial class UserControlConsultaRol : UserControl
    {
        ServiceRol serviceRol;
        public List<Rol> roles { get; set; }
        public UserControlConsultaRol()
        {
            InitializeComponent();
            serviceRol = new ServiceRol();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as viewAdmin;

            if (mainWindow != null)
            {
                mainWindow.panelMedico.Children.Clear();
                UserControlCrudRol userControlCrudRol = new UserControlCrudRol();
                mainWindow.panelMedico.Children.Add(userControlCrudRol);
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation();
            fadeInAnimation.From = 0;
            fadeInAnimation.To = 1;
            fadeInAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            this.BeginAnimation(UserControl.OpacityProperty, fadeInAnimation);
            CargarRoles();
        }
        private void CargarRoles()
        {
            RolesDataGrid.ItemsSource = serviceRol.ConsultarTodo();
        }
        private void MedicosListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
