using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades
{
    public partial class Pagos
    {
        public Pagos()
        {
            PagoId = 0;
            UsuarioId = 0;
            ClienteId = 0;
            Fecha = DateTime.Now;
            TipoPago = string.Empty;
            TotalPago = 0;
            PagosDetalles = new List<PagosDetalle>();
        }
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
