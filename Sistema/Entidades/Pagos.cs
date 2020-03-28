using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades
{
    public partial class Pagos
    {
        [Key]
        public int PagoId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoPago { get; set; }
        public decimal TotalPago { get; set; }
        
        [ForeignKey("PagoId")]
        public virtual List<PagosDetalle> PagosDetalles { get; set; }
        public virtual Clientes Cliente { get; set; }
        public virtual Usuarios Usuario { get; set; }
    }
}
