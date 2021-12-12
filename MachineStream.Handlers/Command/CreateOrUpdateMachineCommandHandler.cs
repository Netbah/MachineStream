namespace MachineStream.Handlers.Command
{
    using AutoMapper;
    using Data.Repository;
    using Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateOrUpdateMachineCommandHandler : IRequestHandler<CreateOrUpdateMachineCommand, Unit>
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IEventDataRepository _eventDataRepository;
        private readonly IMapper _mapper;

        public CreateOrUpdateMachineCommandHandler(IMachineRepository machineRepository, IEventDataRepository eventDataRepository, IMapper mapper)
        {
            _machineRepository = machineRepository;
            _eventDataRepository = eventDataRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateOrUpdateMachineCommand request, CancellationToken cancellationToken)
        {
            var eventDataModel = request.MachineEventModel.Payload;

            var eventEntity = _mapper.Map<EventEntity>(eventDataModel);
            await _eventDataRepository.AddAsync(eventEntity);
            
            var machine = await _machineRepository.GetMachineByIdAsync(eventDataModel.MachineId, cancellationToken);
            if (machine != null)
            {
                machine.Status = eventDataModel.Status;  
                await _machineRepository.UpdateAsync(machine);
            }
            else
            {
                machine = new MachineEntity
                {
                    Id = eventDataModel.MachineId,
                    Status = eventDataModel.Status
                };
                await _machineRepository.AddAsync(machine);
                
            }
            
            return Unit.Value;
        }
    }
}