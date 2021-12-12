namespace MachineStream.Data.Repository
{
    using Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IMachineRepository : IRepository<MachineEntity>
    {
        Task<MachineEntity> GetMachineByIdAsync(Guid id, CancellationToken cancellationToken);
        
        IEnumerable<MachineEntity> Get(string status, string machineType, int count);
    }
}