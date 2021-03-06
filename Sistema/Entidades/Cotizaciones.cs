﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades
{
    public partial class Cotizaciones
    {
        public Cotizaciones()
        {
            CotizacionId = 0;
            UsuarioId = 0;
            ClienteId = 0;
            Fecha = DateTime.Now;
            Impuesto = 0;
            Total = 0;
            CotizacionesDetalles = new List<CotizacionesDetalle>();
        }
        [Key]
        public int CotizacionId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public double? Impuesto { get; set; }
        public int Total { get; set; }

        [ForeignKey("CotizacionId")]
        public virtual List<CotizacionesDetalle> CotizacionesDetalles { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual Usuarios Usuario { get; set; }
    }
}
