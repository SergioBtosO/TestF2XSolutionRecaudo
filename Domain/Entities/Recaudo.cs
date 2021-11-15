using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Recaudo : AuditableBaseEntity
    {
        public DateTime fechaRecaudo { get; set; }
        public string estacion { get; set; }
        public string sentido { get; set; }
        public string categoria { get; set; }
        public int hora { get; set; }
        public int valorTabulado { get; set; }

    }
}
