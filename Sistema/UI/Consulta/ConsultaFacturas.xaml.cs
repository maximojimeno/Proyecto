﻿using Sistema.BLL;
using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sistema.UI.Consulta
{
    /// <summary>
    /// Interaction logic for ConsultaFacturas.xaml
    /// </summary>
    public partial class ConsultaFacturas : Window
    {
        public ConsultaFacturas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Facturas>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //TODO
                        lista = FacturasBLL.GetList(x => true);
                        break;

                    case 1: //ID
                        int id = int.Parse(CriterioTextBox.Text);
                        lista = FacturasBLL.GetList(x => x.FacturaId == id);
                        break;

                    case 2: //Fecha
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        lista = FacturasBLL.GetList(x => x.Fecha == fecha);
                        break;

                    case 3: //FECHAVENCIMIENTO
                        DateTime fechav = Convert.ToDateTime(CriterioTextBox.Text);
                        lista = FacturasBLL.GetList(x => x.FechaVencimiento == fechav);
                        break;
                }

            }
            else
            {
                lista = FacturasBLL.GetList(x => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = lista;
        }
    }
}
