using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Recaudos.Queries.GetAllRecaudos
{
    public class GetAllRecaudosQuery : IRequest<PagedResponse<List<RecaudoDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime fechaRecaudo { get; set; }
        public string estacion { get; set; }
        public string sentido { get; set; }
        public string categoria { get; set; }
        public int hora { get; set; }
        public int valorTabulado { get; set; }



        public class GetAllRecaudosQueryHandler : IRequestHandler<GetAllRecaudosQuery, PagedResponse<List<RecaudoDTO>>>
        {
            private readonly IRepositoryAsync<Recaudo> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllRecaudosQueryHandler(IRepositoryAsync<Recaudo> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<PagedResponse<List<RecaudoDTO>>> Handle(GetAllRecaudosQuery request, CancellationToken cancellationToken)
            {
                var Recaudos = await _repositoryAsync.ListAsync(new PagedRecaudosSpecification(request.PageNumber,request.PageSize,request.fechaRecaudo,request.estacion,request.sentido,request.categoria,request.hora,request.valorTabulado));

                var RecaudosDto = _mapper.Map<List<RecaudoDTO>>(Recaudos);

                return new PagedResponse<List<RecaudoDTO>>(RecaudosDto,request.PageNumber,request.PageSize);
            }
        }
    }
}
