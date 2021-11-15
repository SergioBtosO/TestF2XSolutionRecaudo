using Application.Features.Recaudos.Commands.CreateCommand;
using Application.Features.Recaudos.Commands.DeleteCommand;
using Application.Features.Recaudos.Commands.UpdateCommand;
using Application.Features.Recaudos.Queries.GetAllRecaudos;
using Application.Features.Recaudos.Queries.GetRecaudoByID;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    
    [ApiVersion("1.0")]
    public class RecaudosController : BaseApiController
    {
        //GET api/<controller>/
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllRecaudosParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllRecaudosQuery { 
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                fechaRecaudo = filter.fechaRecaudo,
                estacion = filter.estacion,
                sentido = filter.sentido,
                categoria = filter.categoria,

            }));
        }

        //GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetRecaudoByIdQuery { Id = id }));
        }

        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateRecaudoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,UpdateRecaudoCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        //DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRecaudoCommand { Id = id}));
        }

    }
}
