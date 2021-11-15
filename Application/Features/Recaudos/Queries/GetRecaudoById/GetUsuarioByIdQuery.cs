using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Recaudos.Queries.GetRecaudoByID
{
    public class GetRecaudoByIdQuery : IRequest<Response<RecaudoDTO>>
    {
        public int Id { get; set; }
        
        public class GetRecaudoByIdQueryHancler : IRequestHandler<GetRecaudoByIdQuery, Response<RecaudoDTO>>
        {
            private readonly IRepositoryAsync<Recaudo> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetRecaudoByIdQueryHancler(IRepositoryAsync<Recaudo> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<RecaudoDTO>> Handle(GetRecaudoByIdQuery request, CancellationToken cancellationToken)
            {
                var Recaudo = await _repositoryAsync.GetByIdAsync(request.Id);

                if (Recaudo == null)
                {
                    throw new KeyNotFoundException($"Recaudo no encontrado con el id {request.Id}");
                }
                else
                {

                    var dto = _mapper.Map<RecaudoDTO>(Recaudo);

                    return new Response<RecaudoDTO>(dto);
                }
            }
        }
    }
}
