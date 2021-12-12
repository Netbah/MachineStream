namespace MachineStream.Data.Database
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public class MachineContext : DbContext
    {
        public MachineContext()
        {
        }

        public MachineContext(DbContextOptions<MachineContext> options) : base(options)
        {
            var machines = new List<MachineEntity>
            {
                new()
                {
                    MachineType = "microscope",
                    Longitude = 48.09582590168821,
                    Latitude = 11.523934612394468,
                    LastMaintenance = DateTime.Parse("2017-04-01T16:00:00Z"),
                    InstallDate = "2015-04-17",
                    Id = new Guid("45958000-f702-41be-93a8-9a7e3edd4121"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "microscope",
                    Longitude = 48.09610228912977,
                    Latitude = 11.52376716586951,
                    LastMaintenance = DateTime.Parse("2017-04-01T17:00:00Z"),
                    InstallDate = "2015-04-15",
                    Id = new Guid("00eee2c7-ef69-4df9-94f9-c504ba2ce8a4"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "microscope",
                    Longitude = 48.09540056785246,
                    Latitude = 11.523880271993598,
                    LastMaintenance = DateTime.Parse("2017-04-01T15:00:00Z"),
                    InstallDate = "2015-04-18",
                    Id = new Guid("68015cc1-3119-42d2-9d4e-3e824723fe03"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.096143207084715,
                    Latitude = 11.523922346247339,
                    LastMaintenance = DateTime.Parse("2017-04-01T10:00:00Z"),
                    InstallDate = "2015-04-12",
                    Id = new Guid("cf0959dd-39ba-4c56-90a4-582c2d7a9482"),
                    Floor = 4
                },
                new()
                {
                    MachineType = "microscope",
                    Longitude = 48.09609724783261,
                    Latitude = 11.52391849701985,
                    LastMaintenance = DateTime.Parse("2017-04-01T11:00:00Z"),
                    InstallDate = "2015-04-18",
                    Id = new Guid("265a2ba3-4609-4974-ba07-e5eed81839ea"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.095699442469936,
                    Latitude = 11.523815319943127,
                    LastMaintenance = DateTime.Parse("2017-04-01T16:00:00Z"),
                    InstallDate = "2015-04-12",
                    Id = new Guid("c72dfc43-9ab6-4a8a-b8ce-bb8f607794ec"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.0957067957825,
                    Latitude = 11.523736091579735,
                    LastMaintenance = DateTime.Parse("2017-04-01T18:00:00Z"),
                    InstallDate = "2015-04-12",
                    Id = new Guid("799819f8-6c19-47cc-9e3f-b9438b3bed4f"),
                    Floor = 4
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.0956452197725,
                    Latitude = 11.523728887406294,
                    LastMaintenance = DateTime.Parse("2017-04-01T13:00:00Z"),
                    InstallDate = "2015-04-16",
                    Id = new Guid("3c9e61cd-616e-4765-823a-6af652720ef7"),
                    Floor = 4
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.095570309077104,
                    Latitude = 11.524328414285511,
                    LastMaintenance = DateTime.Parse("2017-04-01T11:00:00Z"),
                    InstallDate = "2015-04-14",
                    Id = new Guid("d29675bc-f3a4-424f-a9a1-68eb257bf30f"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.09541315955922,
                    Latitude = 11.523818055989912,
                    LastMaintenance = DateTime.Parse("2017 - 04 - 01T11:00:00Z"),
                    InstallDate = "2015-04-10",
                    Id = new Guid("840c6335-c0b9-49f8-9eba-e52ef9e23c43"),
                    Floor = 4
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.09561704181971,
                    Latitude = 11.524372591863866,
                    LastMaintenance = DateTime.Parse("2017-04-01T15:00:00Z"),
                    InstallDate = "2015-04-13",
                    Id = new Guid("5b3ec85c-d2ff-404f-aa6b-0a5e82537caa"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.095966783945975,
                    Latitude = 11.524419045043443,
                    LastMaintenance = DateTime.Parse("2017-04-01T18:00:00Z"),
                    InstallDate = "2015-04-10",
                    Id = new Guid("15c14416-caa2-46da-a435-1c6a01e7e47f"),
                    Floor = 4
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.09582682128459,
                    Latitude = 11.523892768669045,
                    LastMaintenance = DateTime.Parse("2017-04-01T12:00:00Z"),
                    InstallDate = "2015-04-11",
                    Id = new Guid("211bd1c5-9230-4ca3-8cc8-9c3226646b99"),
                    Floor = 4
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.095357097775626,
                    Latitude = 11.523815310642274,
                    LastMaintenance = DateTime.Parse("2017 - 04 - 01T10:00:00Z"),
                    InstallDate = "2015-04-11",
                    Id = new Guid("759c98a4-b66f-4799-b278-bab8aec881a0"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "microscope",
                    Longitude = 48.09585756330223,
                    Latitude = 11.523898463055515,
                    LastMaintenance = DateTime.Parse("2017 - 04 - 01T11:00:00Z"),
                    InstallDate = "2015-04-10",
                    Id = new Guid("e447857c-3b4e-4d35-bf1d-77303eda7947"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.09610414000667,
                    Latitude = 11.523848502761822,
                    LastMaintenance = DateTime.Parse("2017-04-01T15:00:00Z"),
                    InstallDate = "2015-04-18",
                    Id = new Guid("e0776fcc-b8e7-4927-943b-10235df7678c"),
                    Floor = 4
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.095640761511035,
                    Latitude = 11.523804068586893,
                    LastMaintenance = DateTime.Parse("2017 - 04 - 01T14:00:00Z"),
                    InstallDate = "2015-04-15",
                    Id = new Guid("cad031e6-e4ed-4d9a-b10d-ff9920d32b4e"),
                    Floor = 4
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.09605679650394,
                    Latitude = 11.523761466503995,
                    LastMaintenance = DateTime.Parse("2017 - 04 - 01T17:00:00Z"),
                    InstallDate = "2015-04-14",
                    Id = new Guid("63f9d31e-18cf-4def-8887-164366d70c46"),
                    Floor = 4
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.09600659378794,
                    Latitude = 11.523755811180713,
                    LastMaintenance = DateTime.Parse("2017 - 04 - 01T10:00:00Z"),
                    InstallDate = "2015-04-14",
                    Id = new Guid("653cab7e-03e7-47ce-b73f-4694e7093729"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.095612723293506,
                    Latitude = 11.524313736313678,
                    LastMaintenance = DateTime.Parse("2017-04-01T13:00:00Z"),
                    InstallDate = "2015-04-14",
                    Id = new Guid("877a6017-9fcc-4338-b74c-681bf76a77f3"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "microscope",
                    Longitude = 48.09535029616455,
                    Latitude = 11.523869432452495,
                    LastMaintenance = DateTime.Parse("2017-04-01T14:00:00Z"),
                    InstallDate = "2015-04-11",
                    Id = new Guid("59d9f4b4-018f-43d8-92d0-c51de7d987e5"),
                    Floor = 4
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.09595993829082,
                    Latitude = 11.524347498644103,
                    LastMaintenance = DateTime.Parse("2017-04-01T15:00:00Z"),
                    InstallDate = "2015-04-12",
                    Id = new Guid("555277c8-7b91-4275-9fb2-04735e8a88c6"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.09614254162977,
                    Latitude = 11.523855178716987,
                    LastMaintenance = DateTime.Parse("2017-04-01T17:00:00Z"),
                    InstallDate = "2015-04-13",
                    Id = new Guid("ce0753da-1b8e-4ffc-b346-3158eec5b9d8"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.0958563678207,
                    Latitude = 11.523952859930345,
                    LastMaintenance = DateTime.Parse("2017-04-01T10:00:00Z"),
                    InstallDate = "2015-04-10",
                    Id = new Guid("95d9b02f-3347-4c0c-a8a0-6e6e525121d5"),
                    Floor = 5
                },
                new()
                {
                    MachineType = "microscope",
                    Longitude = 48.09551415534282,
                    Latitude = 11.52432985271383,
                    LastMaintenance = DateTime.Parse("2017-04-01T14:00:00Z"),
                    InstallDate = "2015-04-18",
                    Id = new Guid("d00b151e-d488-4ffd-b1fc-a84587e9fb28"),
                    Floor = 4
                },
                new()
                {
                    MachineType = "measurement",
                    Longitude = 48.095952816670994,
                    Latitude = 11.524288505406927,
                    LastMaintenance = DateTime.Parse("2017-04-01T16:00:00Z"),
                    InstallDate = "2015-04-15",
                    Id = new Guid("db9eb448-214b-481f-96fe-d1b883ec11a7"),
                    Floor = 5
                }
            };

            Machine.AddRange(machines);
            SaveChanges();
        }

        private DbSet<MachineEntity> Machine { get; set; }
        private DbSet<EventEntity> EventData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MachineEntity>()
                .Property(b => b.Id)
                .IsRequired();
        }
    }
}