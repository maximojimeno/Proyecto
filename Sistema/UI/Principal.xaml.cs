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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistroUsuarios registroUsuarios = new RegistroUsuarios();
            registroUsuarios.Show();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            RegistroFactura registroFactura = new RegistroFactura();
            registroFactura.Show(); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistroClientes registroClientes = new RegistroClientes();
            registroClientes.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RegistroArticulos registroArticulos = new RegistroArticulos();
            registroArticulos.Show();
        }
    }
}
