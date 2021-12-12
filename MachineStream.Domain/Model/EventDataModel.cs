namespace MachineStream.Domain.Model
{
    using Entities;
    using Newtonsoft.Json;
    using System;

    public class EventDataModel
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("machine_id")]
        public Guid MachineId { get; set; }
        
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}