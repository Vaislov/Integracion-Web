using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.Models
{
    public class FacturaData
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public ClienteData Cliente { get; set; }
        [Required]
        public SedeData Sede { get; set; }
        public List<LibroData> libros { get; set; }
    }
}
