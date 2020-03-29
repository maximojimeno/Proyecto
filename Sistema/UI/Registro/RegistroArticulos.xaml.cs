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
    public partial class RegistroCotizaciones : Window
    {
       
        Articulos articulos = new Articulos();
       
       
        public RegistroCotizaciones()
        {
            InitializeComponent();
            this.DataContext = articulos;
            ArticuloIdTextBox.Text = "0";
            
        }
        private void Limpiar()
        {
            
           ArticuloIdTextBox.Text = "0";
           CodigoTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            ImpuestoTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            
        }

        private void CloseWinBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteBDatos()
        {
           articulos = ArticuloBLL.Buscar(Convert.ToInt32(ArticuloIdTextBox.Text));
            return (articulos != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = articulos;
        }

        
        
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
           

            Actualizar();
            if (string.IsNullOrWhiteSpace(ArticuloIdTextBox.Text) || ArticuloIdTextBox.Text == "0")
                paso = ArticuloBLL.Guardar(articulos);
            else
            {
                if(!ExisteBDatos())
                {
                    MessageBox.Show("No se puede modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ArticuloBLL.Modificar(articulos);
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
            id = Convert.ToInt32(ArticuloIdTextBox.Text);

            Limpiar();
            if (ClientesBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                MessageBox.Show(ArticuloIdTextBox.Text,"No se pudo eliminar porque no existe");
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Articulos anterior = ArticuloBLL.Buscar(Convert.ToInt32(ArticuloIdTextBox.Text));

            if(anterior !=null)
            {
                articulos = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No encontrado");
            }
        }
    }
}
