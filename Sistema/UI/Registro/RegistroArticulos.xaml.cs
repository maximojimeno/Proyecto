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
    public partial class RegistroArticulos : Window
    {
        Articulos articulos = new Articulos();

        public RegistroArticulos()
        {
            InitializeComponent();
            this.DataContext = articulos;
            articuloIdTextBox.Text = "0";
        }

        private void CloseWinBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Limpiar()
        {
            articuloIdTextBox.Text = "0";
            descripcionTextBox.Text = string.Empty;
            costoTextBox.Text = "0";
            impuestoTextBox.Text = "0";
            precioTextBox.Text = "0";
            canditadTextBox.Text = "0";
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = articulos;
        }


        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(articuloIdTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo ID no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                articuloIdTextBox.Focus();

            }

            if (string.IsNullOrEmpty(descripcionTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Descripcion no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                descripcionTextBox.Focus();

            }
            if (string.IsNullOrEmpty(costoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Costo no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                costoTextBox.Focus();
            }

            if (string.IsNullOrEmpty(impuestoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Impuesto no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                impuestoTextBox.Focus();
            }
            if (string.IsNullOrEmpty(precioTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Telefono no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                precioTextBox.Focus();
            }

            if (string.IsNullOrEmpty(canditadTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Celular no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                canditadTextBox.Focus();
            }
            return paso;
        }

        private bool Existe()
        {
            Articulos articulos = ArticuloBLL.Buscar(int.Parse(articuloIdTextBox.Text));
            return (articulos != null);
        }

        private void GuardarBtn(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (String.IsNullOrEmpty(articuloIdTextBox.Text) || articuloIdTextBox.Text == "0")
                paso = ArticuloBLL.Guardar(articulos);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No existe en la Base de datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                paso = ArticuloBLL.Modificar(articulos);
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
            Articulos anterior = ArticuloBLL.Buscar(int.Parse(articuloIdTextBox.Text));

            if (anterior != null)
            {
                articulos = anterior;
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
            int.TryParse(articuloIdTextBox.Text, out id);

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
