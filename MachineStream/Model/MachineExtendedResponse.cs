namespace MachineStream.Model
{
    using System;
    using System.Collections.Generic;

    public class MachineExtendedResponse : MachineResponse
    {
        public List<EventResponse> Events { get; set; }
    }
}