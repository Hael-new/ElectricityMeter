using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityMeter
{
    class CommunicationModule
    {
        public double GetRemoteReading(Meter meter)
        {
            Console.WriteLine("Connecting through GSM network...");

            Thread.Sleep(2000);

            return meter.CurrentReading;
        }
    }
}
