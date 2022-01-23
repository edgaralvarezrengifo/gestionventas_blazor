using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaGestionVentas.Shared.DTOs
{
    public class ClientDTO
    {
        public int Id  {get;set;}
        [Required]
        public decimal DocumentId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public Int64 phone { get; set; }
    
        public DateTime creation_date { get; set; }


    }
}
