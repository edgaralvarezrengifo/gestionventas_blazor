using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaGestionVentas.Server.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public decimal cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Int64 telefono { get; set; }
        public DateTime fecha_creacion { get; set; }

    }
}
