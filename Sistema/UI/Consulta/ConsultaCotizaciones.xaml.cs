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
    /// Interaction logic for ConsultaCotizaciones.xaml
    /// </summary>
    public partial class ConsultaCotizaciones : Window
    {
        public ConsultaCotizaciones()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Cotizaciones>();

            if(CriterioTextBox.Text.Trim().Length>0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //TODO
                        lista = CotizacionesBLL.GetList(x => true);
                        break;
                    case 1: //ID
                        int id = int.Parse(CriterioTextBox.Text);
                        lista = CotizacionesBLL.GetList(x => x.CotizacionId == id);
                        break;
                    case 3: //FECHA
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        lista = CotizacionesBLL.GetList(x => x.Fecha == fecha);
                        break;
                }

            }
            else
            {
                lista = CotizacionesBLL.GetList(x => true);
            }

            ConsultarDataGrig.ItemsSource = null;
            ConsultarDataGrig.ItemsSource = lista;

        }
    }
}
