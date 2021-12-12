namespace MachineStream.Controllers.v1
{
    using AutoMapper;
    using Handlers.Query;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<MachinesController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EventsController(IMapper mapper, IMediator mediator, ILogger<MachinesController> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Action to see existing event.
        /// </summary>
        /// <param name="status">Filter by status. The status can be either idle, running, finished, errored or repaired</param>
        /// <param name="machineId">Filter by machine id</param>
        /// <param name="count">Count of results</param>
        /// <returns>Returns a list of all machines</returns>
        /// <response code="200">Returned if the machines were loaded</response>
        /// <response code="400">Returned if the machines couldn't be loaded</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<EventExtendedResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EventExtendedResponse>>> GetEvents([FromQuery] string status, string machineId, int count = 100)
        {
            try
            {
                var query = new GetEventsQuery
                {
                    Status = status,
                    MachineId = machineId,
                    Count = count
                };
                var events = await _mediator.Send(query);
                return _mapper.Map<List<EventExtendedResponse>>(events);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}