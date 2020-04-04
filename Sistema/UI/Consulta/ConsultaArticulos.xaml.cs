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
    /// Interaction logic for ConsultaArticulos.xaml
    /// </summary>
    public partial class ConsultaArticulos : Window
    {
        public ConsultaArticulos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Articulos>();
            if(CriterioTextBox.Text.Trim().Length>0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //TODO
                        lista = ArticuloBLL.GetList(x => true);
                        break;

                    case 1: //ID
                        int id = int.Parse(CriterioTextBox.Text);
                        lista = ArticuloBLL.GetList(x => x.ArticuloId == id);
                        break;

                    case 2: //DESCRIPCION
                        string descripcion = Convert.ToString(CriterioTextBox.Text);
                        lista = ArticuloBLL.GetList(x => x.Descripcion == descripcion);
                        break;
                }

            }
            else
            {
                lista = ArticuloBLL.GetList(x => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = lista;
        }
    }
}
