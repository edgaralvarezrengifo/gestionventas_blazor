using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGestionVentas.Shared.DTOs
{
   
        public class ProductSelected
        {
            public int Id { get; set; }
            public string productname{ get; set; }
            public int count { get; set; }
            public decimal totalprice { get; set; }
    }
    
}
