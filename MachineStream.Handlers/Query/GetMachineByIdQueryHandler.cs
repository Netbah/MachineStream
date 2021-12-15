namespace MachineStream.Handlers.Query
{
    using AutoMapper;
    using Data.DomainExceptions;
    using Data.Repository;
    using Domain.Entities;
    using Domain.Model;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;


    public class GetMachineByIdQueryHandler : IRequestHandler<GetMachineByIdQuery, MachineExtendedModel>
    {
        private readonly ILogger<GetMachinesQueryHandler> _logger;
        private readonly IMachineRepository _machineRepository;
        private readonly IEventDataRepository _eventDataRepository;
        private readonly IMapper _mapper;


        public GetMachineByIdQueryHandler(ILogger<GetMachinesQueryHandler> logger,IMachineRepository machineRepository, IEventDataRepository eventDataRepository, IMapper mapper)
        {
            _logger = logger;
            _machineRepository = machineRepository;
            _eventDataRepository = eventDataRepository;
            _mapper = mapper;
        }

        public async Task<MachineExtendedModel> Handle(GetMachineByIdQuery request, CancellationToken cancellationToken)
        {
            var machine = await _machineRepository.GetMachineByIdAsync(request.Id, cancellationToken);
            if (machine == null)
            {
                throw new NotFoundException($"Machine with id: {request.Id} not found!");
            }
            var machineExtended = _mapper.Map<MachineExtendedModel>(machine);
           
            Expression<Func<EventEntity, bool>> filter = i => i.MachineId == request.Id;
           
            machineExtended.Events = _eventDataRepository.Get(filter, request.CountEvents).ToList();
            return machineExtended;
        }
    }
}