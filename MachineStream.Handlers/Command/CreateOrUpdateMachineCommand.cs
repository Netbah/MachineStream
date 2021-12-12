namespace MachineStream.Handlers.Command
{
    using Domain.Entities;
    using Domain.Model;
    using MediatR;

    public class CreateOrUpdateMachineCommand : IRequest<Unit>
    {
        public MachineEventModel MachineEventModel { get; set; }
    }
}