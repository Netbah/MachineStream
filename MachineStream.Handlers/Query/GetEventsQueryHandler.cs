namespace MachineStream.Handlers.Query
{
    using Data.Repository;
    using Domain.Entities;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;


    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, List<EventEntity>>
    {
        private readonly ILogger<GetEventsQueryHandler> _logger;
        private readonly IEventDataRepository _eventRepository;


        public GetEventsQueryHandler(ILogger<GetEventsQueryHandler> logger, IEventDataRepository eventRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
        }

        public async Task<List<EventEntity>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogTrace("Get events from db");
            return _eventRepository.Get(request.Status, request.MachineId, request.Count).ToList();
        }
    }
}