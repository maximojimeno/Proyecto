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
using Sistema.UI.Registro;
using Sistema.UI.Consulta;

namespace Sistema.UI
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();

            
        }

        private void CloseWinBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        private void ColorZone_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }

        
        private void RegistroUsuarios_Click(object sender, RoutedEventArgs e)
        {
            RegistroUsuarios registroUsuario = new RegistroUsuarios();
            registroUsuario.Show();
        }

        private void RegistroClientes_Click(object sender, RoutedEventArgs e)
        {
            RegistroClientes registroCliente = new RegistroClientes();
            registroCliente.Show();
        }

        private void RegistroArticulos_Click(object sender, RoutedEventArgs e)
        {
            RegistroArticulos registroArticulo = new RegistroArticulos();
            registroArticulo.Show();
        }

        private void ConsultaUsuarios_Click(object sender, RoutedEventArgs e)
        {
            ConsultaUsuarios consultaUsuario = new ConsultaUsuarios();
            consultaUsuario.Show();
        }

        private void ConsultasClientes_Click(object sender, RoutedEventArgs e)
        {
            ConsultaClientes consultaClientes = new ConsultaClientes();
            consultaClientes.Show();
        }

        private void ConsultasArticulos_Click(object sender, RoutedEventArgs e)
        {
            ConsultaArticulos consultaArticulo = new ConsultaArticulos();
            consultaArticulo.Show();
        }

        private void ConsultasFacturas_Click(object sender, RoutedEventArgs e)
        {
            ConsultaFacturas consultaFactura = new ConsultaFacturas();
            consultaFactura.Show();
        }

        private void ConsultasCotizaciones_Click(object sender, RoutedEventArgs e)
        {
            ConsultaCotizaciones consultaCotizacione = new ConsultaCotizaciones();
            consultaCotizacione.Show();
        }

        private void RegistroFacturas_Click(object sender, RoutedEventArgs e)
        {
            RegistroFactura registroFactura = new RegistroFactura();
            registroFactura.Show();
        }

        private void RegistroCotizaciones_Click(object sender, RoutedEventArgs e)
        {
            RegistroCotizaciones registroCotizacion = new RegistroCotizaciones();
            registroCotizacion.Show();
        }
    }
}
