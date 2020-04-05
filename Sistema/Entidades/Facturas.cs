using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades
{
    public partial class Facturas
    {
        public Facturas()
        {
            FacturaId = 0;
            UsuarioId = 0;
            ClienteId = 0;
            Fecha = DateTime.Now;
            FechaVencimiento = Fecha.AddDays(30);
            Impuesto = 0;
            Total = 0;
            Balance = 0;
            FacturasDetalles = new List<FacturasDetalle>();
            PagosDetalles = new List<PagosDetalle>();
        }

        [Key]
        public int FacturaId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public double? Impuesto { get; set; }
        public decimal Total { get; set; }
        public decimal Balance {get;set;}


        [ForeignKey("FacturaId")]
        public virtual List<FacturasDetalle> FacturasDetalles { get; set; }
        [ForeignKey("FacturaId")]
        public virtual List<PagosDetalle> PagosDetalles { get; set; }
        public virtual Clientes Cliente { get; set; }
        public virtual Usuarios Usuario { get; set; }
    }
}
