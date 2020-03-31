using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades
{
    public partial class Articulos
    {
        public Articulos()
        {
            ArticuloId = 0;
            UsuarioId = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Impuesto = 0;
            Precio = 0;
            Cantidad = 0;
        }
        [Key]


        public int ArticuloId { get; set; }
        public int UsuarioId { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public double? Impuesto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual List<FacturasDetalle> FacturasDetalles { get; set; }
        [ForeignKey("ArticuloId")]
        public virtual List<CotizacionesDetalle> CotizacionesDetalles { get; set; }
        public virtual Usuarios Usuario { get; set; }
    }
}
