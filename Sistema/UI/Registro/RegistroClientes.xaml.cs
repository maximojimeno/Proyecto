using Sistema.BLL;
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

namespace Sistema.UI.Registro
{
    /// <summary>
    /// Interaction logic for RegistroBase.xaml
    /// </summary>
    public partial class RegistroClientes : Window
    {
        Usuarios usuarios = new Usuarios();
        
        Clientes clientes = new Clientes();
       
       
        public RegistroClientes()
        {
            InitializeComponent();
            this.DataContext = clientes;
            ClienteIdTextBox.Text = "0";
            
        }
        private void Limpiar()
        {
            
            ClienteIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            CorreoTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
        }

        private void CloseWinBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteBD()
        {
            clientes = ClientesBLL.Buscar(Convert.ToInt32(ClienteIdTextBox.Text));
            return (clientes != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = clientes;
        }

        
        
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
           

            Actualizar();
            if (string.IsNullOrWhiteSpace(ClienteIdTextBox.Text) || ClienteIdTextBox.Text == "0")
                paso = ClientesBLL.Guardar(clientes);
            else
            {
                if(!ExisteBD())
                {
                    MessageBox.Show("No se puede modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ClientesBLL.Modificar(clientes);
            }
            if(paso)
            {
                Limpiar();
                MessageBox.Show("Guardado","Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible Guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(ClienteIdTextBox.Text);

            Limpiar();
            if (ClientesBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                MessageBox.Show(ClienteIdTextBox.Text,"No se pudo eliminar porque no existe");
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes anterior = ClientesBLL.Buscar(Convert.ToInt32(ClienteIdTextBox.Text));

            if(anterior !=null)
            {
                clientes = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No encontrado");
            }
        }
    }
}
