namespace MachineStream.Data.Repository
{
    using Database;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EventDataRepository : Repository<EventEntity>, IEventDataRepository
    {
        public EventDataRepository(MachineContext context) : base(context)
        {
        }

        public IEnumerable<EventEntity> Get(string status, string machineId, int count = 100)
        {
            IQueryable<EventEntity> query = _dbSet;
            if (status != null)
            {
                query = query.Where(m => m.Status == status);
            }

            if (machineId != null)
            {
                query = query.Where(m => m.MachineId == new Guid(machineId));
            }

            return query.AsNoTracking().Take(count).ToList();
        }
    }
}