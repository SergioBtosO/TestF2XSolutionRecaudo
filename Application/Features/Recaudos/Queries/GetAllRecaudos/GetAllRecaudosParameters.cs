using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Recaudos.Queries.GetAllRecaudos
{
    public class GetAllRecaudosParameters : RequestParameter
    {
        public DateTime fechaRecaudo { get; set; }
        public string estacion { get; set; }
        public string sentido { get; set; }
        public string categoria { get; set; }

    }
}
