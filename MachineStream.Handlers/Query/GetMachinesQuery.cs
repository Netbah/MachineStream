namespace MachineStream.Handlers.Query
{
    using Domain.Entities;
    using MediatR;
    using System.Collections.Generic;

    public class GetMachinesQuery : IRequest<List<MachineEntity>>
    {
        public string Status { get; set; }
        public string MachineType { get; set; }
        public int Count { get; set; }
    }
}