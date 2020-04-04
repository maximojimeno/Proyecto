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
    }
}
