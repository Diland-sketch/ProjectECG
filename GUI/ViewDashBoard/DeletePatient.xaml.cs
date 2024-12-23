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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.ViewDashBoard
{
    /// <summary>
    /// Lógica de interacción para DeletePatient.xaml
    /// </summary>
    public partial class DeletePatient : UserControl
    {
        ServicePaciente servicePaciente;
        public DeletePatient()
        {
            InitializeComponent();
            servicePaciente = new ServicePaciente();
        }

        private void txtDocumentoEliminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnEliminar_Click(sender, e);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var mesagge = servicePaciente.Eliminar(txtDocumentoEliminar.Text);
            MessageBox.Show(mesagge);
        }
        private void txtId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^\d+$");
        }
    }
}
