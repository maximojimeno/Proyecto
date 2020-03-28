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
using Sistema.BLL;
using Sistema.Entidades;


namespace Sistema.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Usuarios usuarios = new Usuarios();
        Principal Principal = new Principal();
        public Login()
        {
            InitializeComponent();
            this.DataContext = usuarios;
        }

        public void Inicio()
        {
            
            bool paso = Auth.Validar(usuarios.UserName, usuarios.Password);
            if (paso)
            {
                Close();
                Principal.Show();
            }
            else
            {
                MessageBox.Show("Error de Autenticacion!", "Error!");
            }
        }

        private void DownBtn(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseWinBtn(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void IniciarBtn(object sender, RoutedEventArgs e)
        {
            Inicio();
        }
    }
}
