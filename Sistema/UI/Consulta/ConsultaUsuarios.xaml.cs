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
    /// Interaction logic for ConsultaUsuarios.xaml
    /// </summary>
    public partial class ConsultaUsuarios : Window
    {
        public ConsultaUsuarios()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Usuarios>();

            if(CriterioTextBox.Text.Trim().Length>0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://TODO
                        lista = UsuariosBLL.GetList(x => true);
                        break;

                    case 1: //ID
                        int id = int.Parse(CriterioTextBox.Text);
                        lista = UsuariosBLL.GetList(x => x.UsuarioId == id);
                        break;

                    case 2: //NOMBRES
                        lista = UsuariosBLL.GetList(x => x.Nombres.Contains(CriterioTextBox.Text));
                        break;

                    case 3: //NOMBREUSUARIO
                        lista = UsuariosBLL.GetList(x => x.UserName.Contains(CriterioTextBox.Text));
                        break;
                }

            }
            else
            {
                lista = UsuariosBLL.GetList(x => true);
            }

            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = lista;
        }
    }
}
