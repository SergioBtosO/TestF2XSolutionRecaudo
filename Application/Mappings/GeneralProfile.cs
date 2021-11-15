using Application.DTOs;
using Application.Features.Recaudos.Commands.CreateCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Recaudo, RecaudoDTO>();
            #endregion

            #region Commands
            CreateMap<CreateRecaudoCommand, Recaudo>();
            #endregion
        }
    }
}

