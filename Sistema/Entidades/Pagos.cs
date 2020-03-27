using System;
using System.Collections.Generic;

namespace Sistema.Entidades
{
    public partial class Pagos
    {
        public int PagoId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual Usuarios Usuario { get; set; }
    }
}
