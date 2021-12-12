namespace MachineStream.Handlers.Query
{
    using Domain.Model;
    using MediatR;
    using System;

    public class GetMachineByIdQuery : IRequest<MachineExtendedModel>
    {
        public Guid Id { get; set; }

        public int CountEvents { get; set; }
    }
}