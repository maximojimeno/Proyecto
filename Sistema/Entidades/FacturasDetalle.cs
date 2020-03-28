﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades
{
    public partial class FacturasDetalle
    {
        [Key]
        public int FacturasDetalleId { get; set; }
        public int FacturaId { get; set; }
        public int ArticuloId { get; set; }

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public double? Impuesto { get; set; }
        public decimal Precio { get; set; }
        public int Contidad { get; set; }

        public virtual Articulos Articulo { get; set; }
        public virtual Facturas Factura { get; set; }
    }
}
