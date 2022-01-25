using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGestionVentas.Shared.DTOs
{
    public class newSaleDTO
    {
  
        [Required]
        public string ClientId;
        public List<ProductSelected> Products { get; set; }
       
    }
}
