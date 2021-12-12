namespace MachineStream.Model
{
    using System;

    public class MachineResponse
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string MachineType { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime LastMaintenance { get; set; }
        public string InstallDate { get; set; }
        public int Floor { get; set; }
    }
}