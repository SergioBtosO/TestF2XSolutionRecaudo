using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Recaudos.Commands.CreateCommand
{
    public class CreateRecaudoCommand: IRequest<Response<int>>
    {
        public DateTime fechaRecaudo { get; set; }
        public string estacion { get; set; }
        public string sentido { get; set; }
        public string categoria { get; set; }
        public int hora { get; set; }
        public int valorTabulado { get; set; }
    }

    public class CreateRecaudoCommandHandler : IRequestHandler<CreateRecaudoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Recaudo> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateRecaudoCommandHandler(IRepositoryAsync<Recaudo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRecaudoCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Recaudo>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);

            return new Response<int>(data.Id);

        }
    }

}
