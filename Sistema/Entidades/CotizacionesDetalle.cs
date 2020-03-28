﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades
{
    public partial class CotizacionesDetalle
    {
        [Key]
        public int CotizaconesDetalleId { get; set; }
        public int CotizacionId { get; set; }
        public int ArticuloId { get; set; }

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public double? Impuesto { get; set; }
        public decimal Precio { get; set; }
        public int Contidad { get; set; }

        public virtual Articulos Articulo { get; set; }
        public virtual Cotizaciones Cotizacion { get; set; }
    }
}