namespace MachineStream.Controllers.v1
{
    using AutoMapper;
    using Domain.Entities;
    using Handlers.Query;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/v1/[controller]")]
    public class MachinesController : ControllerBase
    {
        private readonly ILogger<MachinesController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public MachinesController(IMapper mapper, IMediator mediator, ILogger<MachinesController> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Action to see all existing machines.
        /// </summary>
        /// <param name="status">Filter by current machine status. The status can be either idle, running, finished, errored or repaired</param>
        /// <param name="machineType">Filter by machine type</param>
        /// <param name="count">Count of results</param>
        /// <returns>Returns a list of all machines</returns>
        /// <response code="200">Returned if the machines were loaded</response>
        /// <response code="400">Returned if the machines couldn't be loaded</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<MachineResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MachineResponse>>> GetMachines([FromQuery] string status, string machineType, int count = 100)
        {
            try
            {
                var query = new GetMachinesQuery
                {
                    Status = status,
                    MachineType = machineType,
                    Count = count
                };
                var machines = await _mediator.Send(query);
                return _mapper.Map<List<MachineResponse>>(machines);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Action to see machine by Id with related events.
        /// </summary>
        /// <param name="id">The id of machine</param>
        /// <param name="countEvents">The amount of events </param>
        /// <returns>Returns a list of all machines</returns>
        /// <response code="200">Returned if the machine with last events were loaded</response>
        /// <response code="400">Returned if the machine couldn't be loaded couldn't be loaded</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<ActionResult<MachineExtendedResponse>> GetMachineById([Required] string id, [FromQuery] int countEvents = 100)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var query = new GetMachineByIdQuery()
                {
                    Id = new Guid(id),
                    CountEvents = countEvents
                };
                var machineExtended = await _mediator.Send(query);
                return _mapper.Map<MachineExtendedResponse>(machineExtended);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}