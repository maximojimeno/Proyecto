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
using Sistema.Models;

namespace Sistema.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Inicio();
        }


        public void Inicio()
        {
            Usuarios usuarios = new Usuarios();
            //obtener datos de la interfaz
            usuarios.UserName = "maximojimeno";
            usuarios.Password = "1234";


            bool paso = Auth.Validar(usuarios.UserName, usuarios.Password);
            if(paso)
            {
                
            } else
            {
                MessageBox.Show("Error de autenticacion!", "Error!");
            }
        }
    }
}
