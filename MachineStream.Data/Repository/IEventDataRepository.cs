namespace MachineStream.Data.Repository
{
    using Domain.Entities;
    using Domain.Model;
    using System.Collections.Generic;

    public interface IEventDataRepository : IRepository<EventEntity>
    {
        IEnumerable<EventEntity> Get(string status, string machineId, int count = 100);
    }
}