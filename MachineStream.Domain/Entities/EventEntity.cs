namespace MachineStream.Domain.Entities
{
    using System;

    public class EventEntity
    {
        public DateTime Timestamp { get; set; }
        public string Status { get; set; }
        public Guid MachineId { get; set; }
        public Guid Id { get; set; }
        
    }
}