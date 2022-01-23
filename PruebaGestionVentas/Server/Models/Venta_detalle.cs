using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaGestionVentas.Server.Models
{
    public class Venta_detalle
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
        public int VentaId { get; set; }

        public int Cantidad { get; set; }
        public decimal Valor_total { get; set; }
        public Producto Producto { get; set; }
        public Cliente Cliente { get; set; }
        public Venta Venta { get; set; }
    }
}
