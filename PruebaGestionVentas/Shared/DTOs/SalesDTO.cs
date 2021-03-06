using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGestionVentas.Shared.DTOs
{
    public class SalesDTO
    {
        public int Id { get; set; }
        public int Productsquantity { get; set; }
        public decimal Totalprice { get; set; }
        public ClientDTO Client { get; set; }
        public List<ProductDTO> Products { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
