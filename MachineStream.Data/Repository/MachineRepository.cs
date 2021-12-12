namespace MachineStream.Data.Repository
{
    using Database;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class MachineRepository : Repository<MachineEntity>, IMachineRepository
    {
        public MachineRepository(MachineContext context) : base(context)
        {
        }

        public async Task<MachineEntity> GetMachineByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var machine = _dbSet.FirstOrDefault(s => s.Id == id);
            return machine;
        }

        public IEnumerable<MachineEntity> Get(string status, string machineType, int count)
        {
            IQueryable<MachineEntity> query = _dbSet;
            if (status != null)
            {
                query = query.Where(m => m.Status == status);
            }

            if (machineType != null)
            {
                query = query.Where(m => m.MachineType == machineType);
            }

            return query.AsNoTracking().Take(count).ToList();
        }
    }
}