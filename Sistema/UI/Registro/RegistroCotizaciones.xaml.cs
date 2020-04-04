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
    public partial class RegistroCotizaciones : Window
    {


        Cotizaciones cotizaciones = new Cotizaciones();

        public List<CotizacionesDetalle> cotizacionesDetalles { get; set; }

        public RegistroCotizaciones()
        {
            InitializeComponent();
            this.cotizacionesDetalles = new List<CotizacionesDetalle>();
            this.DataContext = cotizaciones;
            cotizacionIdTextBox.Text = "0";
            cotizaciones.UsuarioId = Sesion.usuarioActual.UsuarioId;
            Lista();
            Limpiar();
        }

        private void Lista()
        {
            List<Clientes> dataSource = new List<Clientes>();
            if (cotizaciones.ClienteId > 0)
            {
                dataSource = ClientesBLL.GetList(x=>x.ClienteId == cotizaciones.ClienteId);
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
            cotizacionIdTextBox.Text = "0";
            fechaDataPicker.SelectedDate = DateTime.Now;
            clienteComboBox.Text = string.Empty;
            articuloComboBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            totalLabel.Content = 0;
            impuestoLabel.Content = 0;
            subTotalLabel.Content = 0;
            this.clienteComboBox.IsEnabled = true;
            this.cotizacionesDetalles = new List<CotizacionesDetalle>();
            this.cotizaciones = new Cotizaciones();
            this.Actualizar();

        }

        private void Actualizar()
        {
            this.articuloDataGrid.ItemsSource = null;
            articuloDataGrid.ItemsSource = this.cotizacionesDetalles;
            this.DataContext = cotizaciones;
        }


        private bool Validar()
       {
            bool paso = true;

            if (string.IsNullOrEmpty(cotizacionIdTextBox.Text))
             {
                paso = false;
                MessageBox.Show("El campo ID no puede estar vacio Favor colocar 0", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                cotizacionIdTextBox.Focus();

             }
            if (fechaDataPicker.SelectedDate == null)
            {
                paso = false;
                MessageBox.Show("El campo Fecha no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                cotizacionIdTextBox.Focus();
                cotizacionIdTextBox.Focus();
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
            Cotizaciones cotizaciones = CotizacionesBLL.Buscar(Convert.ToInt32(cotizacionIdTextBox.Text));
            return (cotizaciones != null);
        }

        private void GuardarBtn(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            Clientes cliente = (Clientes)clienteComboBox.SelectedValue;
            
            cotizaciones.ClienteId = cliente.ClienteId;

            if (!Validar())
                return;

            this.cotizaciones.CotizacionesDetalles = this.cotizacionesDetalles;


            foreach(var detalle in this.cotizaciones.CotizacionesDetalles)
            {
                Articulos articulo = ArticuloBLL.Buscar(detalle.ArticuloId);
                articulo.UsuarioId = cotizaciones.UsuarioId;
                if (articulo.Cantidad > 0)
                {
                    articulo.Cantidad -= detalle.Cantidad;
                }
                ArticuloBLL.Modificar(articulo);
                
            }

            if (String.IsNullOrEmpty(cotizacionIdTextBox.Text) || cotizacionIdTextBox.Text == "0")
                paso = CotizacionesBLL.Guardar(cotizaciones);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No existe el en la Base de datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                paso = CotizacionesBLL.Modificar(cotizaciones);
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



            Cotizaciones anterior = CotizacionesBLL.Buscar(int.Parse(cotizacionIdTextBox.Text));

            if (anterior != null)
            {               
                cotizaciones = anterior;
                this.cotizacionesDetalles = anterior.CotizacionesDetalles;                
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
            int.TryParse(cotizacionIdTextBox.Text, out id);

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
                this.cotizacionesDetalles = (List<CotizacionesDetalle>)articuloDataGrid.ItemsSource;
            }

            this.cotizacionesDetalles.Add(new CotizacionesDetalle
            {
                CotizacionId = Convert.ToInt32(cotizacionIdTextBox.Text),
                ArticuloId  = articulo.ArticuloId,
                Precio = articulo.Precio,
                Cantidad = Convert.ToInt32(CantidadTextBox.Text)
            });

            Actualizar();
            Calcular();
        }

        private void Calcular()
        {
            decimal subTotal = this.cotizacionesDetalles.Select(x => x.Cantidad * x.Precio).Sum();
            decimal impuestoTotal = (Decimal)this.cotizacionesDetalles.Sum(x => x.Impuesto);
            decimal total = subTotal + impuestoTotal;

            subTotalLabel.Content = subTotal.ToString();
            impuestoLabel.Content = impuestoTotal.ToString();
            totalLabel.Content = total.ToString();
            

        }

        private void RemoverBtn(object sender, RoutedEventArgs e)
        {

        }
    }
}
