using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Recaudos.Commands.UpdateCommand
{
    public class UpdateRecaudoCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public DateTime fechaRecaudo { get; set; }
        public string estacion { get; set; }
        public string sentido { get; set; }
        public string categoria { get; set; }
        public int hora { get; set; }
        public int valorTabulado { get; set; }
    }

    public class UpdateRecaudoCommandHandler : IRequestHandler<UpdateRecaudoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Recaudo> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateRecaudoCommandHandler(IRepositoryAsync<Recaudo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateRecaudoCommand request, CancellationToken cancellationToken)
        {
            var record =  await _repositoryAsync.GetByIdAsync(request.Id);

            if(record == null)
            {
                throw new KeyNotFoundException($"Recaudo no encontrado con el id {request.Id}");
            }
            else
            {
                record.fechaRecaudo = request.fechaRecaudo;
                record.estacion = request.estacion;
                record.sentido = request.sentido;
                record.categoria = request.categoria;
                record.hora = request.hora;
                record.valorTabulado = request.valorTabulado;

                await _repositoryAsync.UpdateAsync(record);
            }

            return new Response<int>(record.Id);

        }
    }
}
