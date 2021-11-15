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

namespace Application.Features.Recaudos.Commands.DeleteCommand
{
    public class DeleteRecaudoCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteRecaudoCommandHandler : IRequestHandler<DeleteRecaudoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Recaudo> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteRecaudoCommandHandler(IRepositoryAsync<Recaudo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteRecaudoCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);

            if (record == null)
            {
                throw new KeyNotFoundException($"Recaudo no encontrado con el id {request.Id}");
            }
            else
            {
               await _repositoryAsync.DeleteAsync(record);
            }

            return new Response<int>(record.Id);

        }
    }
}
