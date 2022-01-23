using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaGestionVentas.Server.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int cantidad { get; set; }
        public decimal valor_total { get; set; }
        public DateTime fecha_venta { get; set; }
    }
}
