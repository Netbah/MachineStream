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


    public class GetMachinesQueryHandler : IRequestHandler<GetMachinesQuery, List<MachineEntity>>
    {
        private readonly ILogger<GetMachinesQueryHandler> _logger;
        private readonly IMachineRepository _machineRepository;


        public GetMachinesQueryHandler(ILogger<GetMachinesQueryHandler> logger, IMachineRepository machineRepository)
        {
            _logger = logger;
            _machineRepository = machineRepository;
        }

        public async Task<List<MachineEntity>> Handle(GetMachinesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogTrace("Get all machines from db");
            return _machineRepository.Get(request.Status, request.MachineType, request.Count).ToList();
        }
    }
}