using System;
using System.Collections.Generic;

namespace Sistema.Entidades
{
    public partial class Articulos
    {
        public int ArticuloId { get; set; }
        public int UsuarioId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public double? Impuesto { get; set; }
        public decimal Precio { get; set; }
        public int Contidad { get; set; }

        public virtual Usuarios Usuario { get; set; }
    }
}
