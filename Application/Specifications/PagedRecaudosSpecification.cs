using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications
{
    public class PagedRecaudosSpecification : Specification<Recaudo>
    {
        public PagedRecaudosSpecification(int pageNumber, int pageSize, DateTime fechaRecaudo, string estacion, string sentido, string categoria, int hora, int valorTabulado)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            /*if (!string.IsNullOrEmpty(fechaRecaudo.ToString("yyyy-MM-dd")))
            {
                Query.Search(x => x.fechaRecaudo.ToString("yyyy-MM-dd"), fechaRecaudo.ToString("yyyy-MM-dd"));
            }*/

            if (!string.IsNullOrEmpty(estacion))
            {
                Query.Search(x => x.estacion, "%" + estacion + "%");
            }

            if (!string.IsNullOrEmpty(sentido))
            {
                Query.Search(x => x.sentido, "%" + sentido + "%");
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                Query.Search(x => x.categoria, "%" + categoria + "%");
            }

            if (hora < 0)
            {
                Query.Search(x => x.hora.ToString(), hora.ToString());
            }

            if (hora < 0)
            {
                Query.Search(x => x.valorTabulado.ToString(), valorTabulado.ToString());
            }
        }
    }
}
