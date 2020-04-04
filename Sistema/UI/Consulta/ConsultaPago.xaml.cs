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
    /// Interaction logic for ConsultaPago.xaml
    /// </summary>
    public partial class ConsultaPago : Window
    {
        public ConsultaPago()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Pagos>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        lista = PagosBLL.GetList(x => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        lista = PagosBLL.GetList(x=> x.PagoId == id);
                        break;
                    case 2://Fecha
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        lista = PagosBLL.GetList(x => x.Fecha == fecha);
                        break;
                }
            }
            else
            {
                lista = PagosBLL.GetList(x => true);
            }

            ConsultarDataGrig.ItemsSource = null;
            ConsultarDataGrig.ItemsSource = lista;
        }
    }
}
