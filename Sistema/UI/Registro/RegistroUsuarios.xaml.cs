﻿using System;
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

namespace Sistema.UI.Registro
{
    /// <summary>
    /// Interaction logic for RegistroBase.xaml
    /// </summary>
    public partial class RegistroUsuarios : Window
    {
        Usuarios usuarios = new Usuarios();
        public RegistroUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuarios;
            usuarioIdTextBox.Text = "0";
        }

        private void CloseWinBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Limpiar()
        {
            usuarioIdTextBox.Text = "0";
            nombreTextBox.Text = string.Empty;
            apellidoTextBox.Text = string.Empty;
            usuarioIdTextBox.Text = string.Empty;
            passwordTextBox.Password = string.Empty;
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = usuarios;
        }


        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(usuarioIdTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo ID no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                usuarioIdTextBox.Focus();

            }

            if (string.IsNullOrEmpty(nombreTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombres no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                nombreTextBox.Focus();

            }

            if (string.IsNullOrEmpty(apellidoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombres no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                apellidoTextBox.Focus();

            }

            if (string.IsNullOrEmpty(usuarioIdTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombre de Usuario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                usuarioIdTextBox.Focus();
            }

            if (string.IsNullOrEmpty(passwordTextBox.Password))
            {
                paso = false;
                MessageBox.Show("El campo Contraseña no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                passwordTextBox.Focus();
            }
            return paso;
        }

        private bool Existe()
        {
            Usuarios usuarios = UsuariosBLL.Buscar(int.Parse(usuarioIdTextBox.Text));
            return (usuarios != null);
        }

        private void GuardarBtn(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (String.IsNullOrEmpty(usuarioIdTextBox.Text) || usuarioIdTextBox.Text == "0")
                paso = UsuariosBLL.Guardar(usuarios);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No existe el El en la Base de datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                paso = UsuariosBLL.Modificar(usuarios);
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
            Usuarios anterior = UsuariosBLL.Buscar(int.Parse(usuarioIdTextBox.Text));

            if (anterior != null)
            {
                usuarios = anterior;
                Actualizar();
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
            int.TryParse(usuarioIdTextBox.Text, out id);

            if (UsuariosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado con exito!!!", "ELiminado", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No eliminado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
