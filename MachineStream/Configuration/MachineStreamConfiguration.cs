namespace MachineStream.Configuration
{
    public class MachineStreamConfiguration
    {
        public string ConnectionString { get; set; }
        public int ReconnectTimeoutSeconds { get; set; }
        public int KeepAliveInterval { get; set; }
    }
}