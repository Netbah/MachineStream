namespace MachineStream.Model
{
    using System;

    public class EventExtendedResponse : EventResponse
    {
        public Guid MachineId { get; set; }
        public Guid Id { get; set; }
    }
}