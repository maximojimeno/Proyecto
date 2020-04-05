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
using System.Linq;

namespace Sistema.UI.Registro
{
    /// <summary>
    /// Interaction logic for RegistroBase.xaml
    /// </summary>
    public partial class RegistroFactura : Window
    {


        Facturas facturas = new Facturas();

        public List<FacturasDetalle> facturasDetalles { get; set; }

        public RegistroFactura()
        {
            InitializeComponent();
            this.facturasDetalles = new List<FacturasDetalle>();
            this.DataContext = facturas;
            facturaIdTextBox.Text = "0";
            facturas.UsuarioId = Sesion.usuarioActual.UsuarioId;
            Lista();
            Limpiar();
        }

        private void Lista()
        {
            List<Clientes> dataSource = new List<Clientes>();
            if (facturas.ClienteId > 0)
            {
                dataSource = ClientesBLL.GetList(x=>x.ClienteId == facturas.ClienteId);
                this.clienteComboBox.IsEnabled = false;

            } else
            {
                List<Clientes> listaCliente = ClientesBLL.GetList(c => true);
                dataSource = listaCliente;
            }

            clienteComboBox.SelectedValue = "ClienteId";
            clienteComboBox.DisplayMemberPath = "Nombres";
            clienteComboBox.ItemsSource = dataSource;
            if(dataSource.Count > 0)
            {
                clienteComboBox.SelectedIndex = 0;
                clienteComboBox.UpdateLayout();
            }

            articuloComboBox.SelectedValue = "ArticuloId";
            articuloComboBox.DisplayMemberPath = "Descripcion";
            List<Articulos> listaArticulo = ArticuloBLL.GetList(c => true);
            articuloComboBox.ItemsSource = listaArticulo;
            
        }

        
       

        private void CloseWinBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Limpiar()
        {
            facturaIdTextBox.Text = "0";
            fechaDataPicker.SelectedDate = DateTime.Now;
            fechaVencimientoDatePicker.SelectedDate = DateTime.Now.AddDays(30);
            clienteComboBox.Text = string.Empty;
            articuloComboBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            totalLabel.Content = 0;
            impuestoLabel.Content = 0;
            subTotalLabel.Content = 0;
            this.clienteComboBox.IsEnabled = true;
            this.facturasDetalles = new List<FacturasDetalle>();
            this.facturas = new Facturas();
            this.Actualizar();

        }

        private void Actualizar()
        {
            this.articuloDataGrid.ItemsSource = null;
            articuloDataGrid.ItemsSource = this.facturasDetalles;
            this.DataContext = facturas;
        }


        private bool Validar()
       {
            bool paso = true;

            if (string.IsNullOrEmpty(facturaIdTextBox.Text))
             {
                paso = false;
                MessageBox.Show("El campo ID no puede estar vacio Favor colocar 0", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                facturaIdTextBox.Focus();

             }
            if (fechaDataPicker.SelectedDate == null)
            {
                paso = false;
                MessageBox.Show("El campo Fecha no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                fechaDataPicker.Focus();
                
            }
            if (fechaVencimientoDatePicker.SelectedDate == null)
            {
                paso = false;
                MessageBox.Show("El campo Fecha Vencimiento no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                fechaVencimientoDatePicker.Focus();
            }

            if (clienteComboBox.SelectedItem == null)
                    {
                        paso = false;
                        MessageBox.Show("El campo Cliente no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                        clienteComboBox.Focus();
                    }
           
             return paso;
            }

        private bool Existe()
        {
            Facturas facturas = FacturasBLL.Buscar(Convert.ToInt32(facturaIdTextBox.Text));
            return (facturas != null);
        }

        private void GuardarBtn(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            Clientes cliente = (Clientes)clienteComboBox.SelectedValue;
            
            facturas.ClienteId = cliente.ClienteId;

            if (!Validar())
                return;

            this.facturas.FacturasDetalles = this.facturasDetalles;


            foreach(var detalle in this.facturas.FacturasDetalles)
            {
                Articulos articulo = ArticuloBLL.Buscar(detalle.ArticuloId);
                articulo.UsuarioId = facturas.UsuarioId;
                if (articulo.Cantidad > 0)
                {
                    articulo.Cantidad -= detalle.Cantidad;
                }
                ArticuloBLL.Modificar(articulo);
                
            }

            if (String.IsNullOrEmpty(facturaIdTextBox.Text) || facturaIdTextBox.Text == "0")
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



            Facturas anterior = FacturasBLL.Buscar(int.Parse(facturaIdTextBox.Text));

            if (anterior != null)
            {               
                facturas = anterior;
                this.facturasDetalles = anterior.FacturasDetalles;                
                Actualizar();
                Lista();
                Calcular();
                
                
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
            int.TryParse(facturaIdTextBox.Text, out id);

            if (FacturasBLL.Eliminar(id))
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
            if (articuloComboBox.SelectedItem == null)
            {
                
                      
                    MessageBox.Show("El campo Producto no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    articuloComboBox.Focus();
                return;
                
            }
            Articulos articulo = (Articulos)articuloComboBox.SelectedValue;

            if (articuloDataGrid.ItemsSource != null)
            {
                this.facturasDetalles = (List<FacturasDetalle>)articuloDataGrid.ItemsSource;
            }

            this.facturasDetalles.Add(new FacturasDetalle
            {
                FacturaId = Convert.ToInt32(facturaIdTextBox.Text),
                ArticuloId  = articulo.ArticuloId,
                Precio = articulo.Precio,
                Cantidad = Convert.ToInt32(CantidadTextBox.Text)
            });

            Actualizar();
            Calcular();
        }

        private void Calcular()
        {
            decimal subTotal = this.facturasDetalles.Select(x => x.Cantidad * x.Precio).Sum();
            decimal impuestoTotal = (Decimal)this.facturasDetalles.Sum(x => x.Impuesto);
            decimal total = subTotal + impuestoTotal;

            subTotalLabel.Content = subTotal.ToString();
            impuestoLabel.Content = impuestoTotal.ToString();
            totalLabel.Content = total.ToString();
            

        }

        private void RemoverBtn(object sender, RoutedEventArgs e)
        {

            if (articuloDataGrid.Items.Count > 1 && articuloDataGrid.SelectedIndex < articuloDataGrid.Items.Count - 1)
            {
                facturas.FacturasDetalles.RemoveAt(articuloDataGrid.SelectedIndex);
                Actualizar();
            }
        }
    }
}
