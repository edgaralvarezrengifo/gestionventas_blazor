using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaGestionVentas.Shared.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public decimal unitprice { get; set; }
        public DateTime creationDate { get; set; }
        public int quantity { get; set; }
    }
}
