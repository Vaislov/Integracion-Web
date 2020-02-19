using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.Models
{
    public class LibroData
    {

        [Required]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int Año { get; set; }
        public string Autor { get; set; }
        public int Cantidad { get; set; }
        public FacturaData factura { get; set; }
    }
}
