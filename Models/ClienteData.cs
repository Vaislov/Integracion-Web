using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.Models
{
    public class ClienteData
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public int DNI { get; set; }
        //public List<FacturaData> Facturas { get; set; }

        public int RUC { get; set; }
    }
}
