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
using Sistema.Entidades;
using Sistema.BLL;

namespace Sistema.UI.Registro
{
    /// <summary>
    /// Interaction logic for RegistroBase.xaml
    /// </summary>
    public partial class RegistroClientes : Window
    {
        Clientes clientes = new Clientes();
        public RegistroClientes()
        {
            InitializeComponent();
            this.DataContext = clientes;
            clienteIdtextBox.Text = "0";
        }

        private void CloseWinBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Limpiar()
        {
            clienteIdtextBox.Text = "0";
            nombresTextBox.Text = string.Empty;
            apellidosTextBox.Text = string.Empty;
            cedulaTextBox.Text = string.Empty;
            correoTextBox.Text = string.Empty;
            telefonoTextBox.Text = string.Empty;
            celularTextBox.Text = string.Empty;
            direccionTextBox.Text = string.Empty;
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = clientes;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(clienteIdtextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo ID no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                clienteIdtextBox.Focus();

            }

            if (string.IsNullOrEmpty(nombresTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombres no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                nombresTextBox.Focus();

            }
            if (string.IsNullOrEmpty(apellidosTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Apellidos no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                apellidosTextBox.Focus();
            }

            if (string.IsNullOrEmpty(cedulaTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Cedula no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                cedulaTextBox.Focus();
            }
            if (string.IsNullOrEmpty(telefonoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Telefono no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                telefonoTextBox.Focus();
            }

            if (string.IsNullOrEmpty(celularTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Celular no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                celularTextBox.Focus();
            }

            if (string.IsNullOrEmpty(cedulaTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Cedula no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                celularTextBox.Focus();
            }

            return paso;
        }

        private bool Existe()
        {
            Clientes clientes = ClientesBLL.Buscar(int.Parse(clienteIdtextBox.Text));
            return (clientes != null);
        }


        private void GuardarBtn(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (String.IsNullOrEmpty(clienteIdtextBox.Text) || clienteIdtextBox.Text == "0")
                paso = ClientesBLL.Guardar(clientes);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No existe en la Base de datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                paso = ClientesBLL.Modificar(clientes);
            }

            if (paso)
            {
                MessageBox.Show("Guardado!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No guardado!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BuscarBtn(object sender, RoutedEventArgs e)
        {
            Clientes anterior = ClientesBLL.Buscar(int.Parse(clienteIdtextBox.Text));

            if (anterior != null)
            {
                clientes = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No encontrado");
            }
        }

        private void LimpiarBtn(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void EliminarBtn(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(clienteIdtextBox.Text, out id);

            if (UsuariosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado con exito!!!", "ELiminado", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No eliminado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
