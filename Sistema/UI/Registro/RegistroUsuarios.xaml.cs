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
            UsuarioIdTb.Text = "0";
        }

        private void CloseWinBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Limpiar()
        {
            UsuarioIdTb.Text = string.Empty;
            NombresTb.Text = string.Empty;
            ApellidosTb.Text = string.Empty;
            UserNameTb.Text = string.Empty;
            PassTb.Password = string.Empty;
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = usuarios;
        }


        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(UsuarioIdTb.Text))
            {
                paso = false;
                MessageBox.Show("El campo ID no puede estar vacio Favor colocar 0", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                UsuarioIdTb.Focus();

            }

            if (string.IsNullOrEmpty(NombresTb.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombres no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombresTb.Focus();

            }
            if (string.IsNullOrEmpty(UserNameTb.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombre de Usuario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                UserNameTb.Focus();
            }

            if (string.IsNullOrEmpty(PassTb.Password))
            {
                paso = false;
                MessageBox.Show("El campo Contraseña no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                PassTb.Focus();
            }
            return paso;
        }

        private bool Existe()
        {
            Usuarios usuarios = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTb.Text));
            return (usuarios != null);
        }

        private void GuardarBtn(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (String.IsNullOrEmpty(UsuarioIdTb.Text) || UsuarioIdTb.Text == "0")
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
            Usuarios anterior = UsuariosBLL.Buscar(int.Parse(UsuarioIdTb.Text));

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
            int.TryParse(UsuarioIdTb.Text, out id);

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
