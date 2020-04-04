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

namespace Sistema.UI.Consulta
{
    /// <summary>
    /// Interaction logic for ConsultaClientes.xaml
    /// </summary>
    public partial class ConsultaClientes : Window
    {
        public ConsultaClientes()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Clientes>();
            if(CriterioTextBox.Text.Trim().Length>0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //TODO
                        lista = ClientesBLL.GetList(x => true);
                        break;

                    case 1: //Id
                        int id = int.Parse(CriterioTextBox.Text);
                        lista = ClientesBLL.GetList(x => x.ClienteId == id);
                        break;

                    case 2: //NOMBRES
                        lista = ClientesBLL.GetList(x => x.Nombres.Contains(CriterioTextBox.Text));
                        break;

                    case 3: //APELLIDOS
                        lista = ClientesBLL.GetList(x => x.Apellidos.Contains(CriterioTextBox.Text));
                        break;

                    case 4: //CELULAR
                        lista = ClientesBLL.GetList(x => x.Celular.Contains(CriterioTextBox.Text));
                        break;
                    case 5: //TELEFONO
                        lista = ClientesBLL.GetList(x => x.Telefono.Contains(CriterioTextBox.Text));
                        break;
                    case 6: //CEDULA
                        lista = ClientesBLL.GetList(x => x.Cedula.Contains(CriterioTextBox.Text));
                        break;
                    case 7: //DIRECCION
                        lista = ClientesBLL.GetList(x => x.Direccion.Contains(CriterioTextBox.Text));
                        break;
                        
                }

            }
            else
            {
                lista = ClientesBLL.GetList(x => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = lista;
        }
    }
}
