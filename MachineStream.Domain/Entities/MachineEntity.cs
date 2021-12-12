namespace MachineStream.Domain.Entities
{
    using Model;
    using System;
    using System.Collections.Generic;

    public class MachineEntity
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string MachineType { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime LastMaintenance { get; set; }
        public string InstallDate { get; set; }
        public int Floor { get; set; }

    }
}