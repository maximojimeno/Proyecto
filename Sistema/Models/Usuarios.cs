using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistema.Models
{
   public class Usuarios
    {
        [Key]
        [Range(0,100,ErrorMessage ="el ID debe ser mayor a 0 y menor o igual a 100")]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage ="El Nombre es Requerido ej. 'Juan Alberto'")]
        public string Nombres { get; set; }
        [Required(ErrorMessage ="El Apellido es Requerido ej. 'Perez Polanco'")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage ="El Nombre de Usurio es Requerido ej. 'juanPerez, jperez'")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "La contraseña es Requerida")]
        public string Password { get; set; }
        [Required(ErrorMessage ="El Rol es requerido ej. 'Administrador, Vendedor, Operador'")]
        public string Role { get; set; }

        Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            Role = string.Empty;
        }
    }
}
