using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RecaudoDTO
    {
        public int Id { get; set; }
        public DateTime fechaRecaudo { get; set; }
        public string estacion { get; set; }
        public string sentido { get; set; }
        public string categoria { get; set; }
        public int hora { get; set; }
        public int valorTabulado { get; set; }
    }
}
