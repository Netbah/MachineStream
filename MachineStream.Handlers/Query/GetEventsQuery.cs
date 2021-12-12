namespace MachineStream.Handlers.Query
{
    using Domain.Entities;
    using MediatR;
    using System.Collections.Generic;

    public class GetEventsQuery : IRequest<List<EventEntity>>
    {
        public string Status { get; set; }
        public string MachineId { get; set; }
        public int Count { get; set; }
    }
}