namespace MachineStream.Domain.Model
{
    using Newtonsoft.Json;

    public class MachineEventModel
    {
        [JsonProperty("topic")]
        public string Topic { get; set; }
        
        [JsonProperty("payload")]
        public EventDataModel Payload { get; set; }
        
        [JsonProperty("join_ref")]
        public object Ref { get; set; }
        
        [JsonProperty("@event")]
        public string Event { get; set; }
    }
}