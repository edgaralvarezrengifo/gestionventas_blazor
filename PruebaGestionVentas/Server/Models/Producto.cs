using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaGestionVentas.Server.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string nombre_producto { get; set; }
        public decimal valor_unitario { get; set; }
        public DateTime fecha_creacion { get; set; }


    }
}
