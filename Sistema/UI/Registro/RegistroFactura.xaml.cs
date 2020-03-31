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
    public partial class RegistroFactura : Window
    {


        Facturas facturas = new Facturas();
        Articulos articulos = new Articulos();
        public RegistroFactura()
        {
            InitializeComponent();
            this.DataContext = facturas;
            facturaIdTB.Text = "0";
            Lista();
            Limpiar();
        }

        private void Lista()
        {
            List<Articulos> listaArticulo = ArticuloBLL.GetList(a => true);
            this.DataContext = listaArticulo;
            List<Clientes> listaCliente = ClientesBLL.GetList(c => true);
            this.DataContext = listaArticulo;
        }

       

        private void CloseWinBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Limpiar()
        {
            facturaIdTB.Text = "0";
            fechaDataPicker.SelectedDate = DateTime.Now;
            fechaVencimientoDatePicker.SelectedDate = DateTime.Now.AddDays(30);
            clienteIdComboBox.Text = string.Empty;
            ArticuloIdComboBox.Text = string.Empty;


        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = facturas;
            this.DataContext = articulos;
        }


        private bool Validar()
       {
            bool paso = true;

            if (string.IsNullOrEmpty(facturaIdTB.Text))
             {
                paso = false;
                MessageBox.Show("El campo ID no puede estar vacio Favor colocar 0", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                facturaIdTB.Focus();

             }
            if (fechaDataPicker.SelectedDate == null)
            {
                paso = false;
                MessageBox.Show("El campo Fecha no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                facturaIdTB.Focus();
            }
            if (fechaVencimientoDatePicker.SelectedDate == null)
            {
                paso = false;
                MessageBox.Show("El campo Fecha Vencimiento no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                facturaIdTB.Focus();
            }

            if (clienteIdComboBox.SelectedItem == null)
                    {
                        paso = false;
                        MessageBox.Show("El campo Cliente no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                        clienteIdComboBox.Focus();
                    }
            if (ArticuloIdComboBox.SelectedItem == null)
            {
                {
                    paso = false;
                    MessageBox.Show("El campo Producto no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    clienteIdComboBox.Focus();
                }
            }
             return paso;
            }

        private bool Existe()
        {
            Facturas facturas = FacturasBLL.Buscar(Convert.ToInt32(facturaIdTB.Text));
            return (facturas != null);
        }

        private void GuardarBtn(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (String.IsNullOrEmpty(facturaIdTB.Text) || facturaIdTB.Text == "0")
                paso = FacturasBLL.Guardar(facturas);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No existe el en la Base de datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                paso = FacturasBLL.Modificar(facturas);
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



            Facturas anterior = FacturasBLL.Buscar(int.Parse(ArticuloIdComboBox.Text));

            if (anterior != null)
            {
                facturas = anterior;
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
            int.TryParse(ArticuloIdComboBox.Text, out id);

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

        private void AgregarBtn(object sender, RoutedEventArgs e)
        {

        }

        private void RemoverBtn(object sender, RoutedEventArgs e)
        {

        }
    }
}
