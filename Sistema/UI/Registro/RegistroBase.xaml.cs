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
    public partial class RegistroBase : Window
    {
        public RegistroBase()
        {
            InitializeComponent();
        }

        private void CloseWinBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
