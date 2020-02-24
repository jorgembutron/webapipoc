﻿using Company.Biz.WebApi.Application.Commands;
using Company.Biz.WebApi.Application.Queries;
using Company.Biz.WebApi.Middleware;
using Company.Biz.WebApi.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Company.Responses;

namespace Company.Biz.WebApi.Controllers
{
    [Route("api/ping")]
    public class PingController : Controller
    {
        private readonly IMediator _mediator;

        public PingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(PingResponseVm), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Create([FromBody] CreatePingCommand command)
        {
            Response<PingResponseVm> response = await _mediator.Send(command).ConfigureAwait(false);

            return CreatedAtRoute("Details", new { id = response.Data.Id }, response.Data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Edit(int id, [FromBody] EditPingCommand command)
        {
            command.Id = id;
            Response response = await _mediator.Send(command).ConfigureAwait(false);

            if (response.Result == Result.NotFound)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            Response response = await _mediator.Send(new DeletePingCommand(id)).ConfigureAwait(false);

            if (response.Result == Result.NotFound)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<PingResponseVm>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(RestException), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> List() => Ok((await _mediator.Send(new ListPingQuery()).ConfigureAwait(false)).Data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Details")]
        [ProducesResponseType(typeof(PingResponseVm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Details(int id)
        {
            Response<PingResponseVm> response = await _mediator.Send(new DetailsPingQuery(id)).ConfigureAwait(false);

            if (response.Result == Result.NotFound)
                return NotFound();

            return Ok(response.Data);
        }
    }
}
