using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace ElectricityMeter
{
    
        public class Meters
        {

            List<Meter> meters = new List<Meter>();


           public void PridejMeter(Meter m)
            {
                meters.Add(m);
            }

        
            public ReadOnlyCollection<Meter> VratVsechnyMetry()
            {
                return meters.AsReadOnly();
            }

          
            public List<Meter> NajdiMetry(int meterId, string serialNumber)
            {
                return meters.FindAll(m =>
                    m.meterId == meterId &&
                    m.serialNumber.Equals(serialNumber, StringComparison.OrdinalIgnoreCase));
            }

            public double? ReadMeter(int meterId)
            {
              Meter meter = meters.Find(m => m.meterId == meterId);

              if (meter != null && meter.isConnected)
                return meter.CurrentReading;

              return null;
            }

    }

}
