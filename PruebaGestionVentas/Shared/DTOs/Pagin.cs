using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaGestionVentas.Shared.DTOs
{
    public class Pagin
    {

        public int page { get; set; } = 1;
        public int NRecords { get; set; } = 5;
    }
}
