public class Meter
{
    public int meterId { get; set; }

    public double voltage { get; set; }

    public string serialNumber { get; set; }

    public bool isConnected { get; set; }

    public string SimCardNumber { get; set; }

    public double CurrentReading { get; set; }


    public Meter(int meterId,
                 double voltage,
                 string serialNumber,
                 bool isConnected,
                 string simCardNumber,
                 double currentReading)
    {
        this.meterId = meterId;
        this.voltage = voltage;
        this.serialNumber = serialNumber;
        this.isConnected = isConnected;
        SimCardNumber = simCardNumber;
        CurrentReading = currentReading;
    }

    public override string ToString()
    {
        return $"Meter ID: {meterId}, Voltage: {voltage}, Serial Number: {serialNumber}, Connected: {isConnected}, SIM: {SimCardNumber}, Reading: {CurrentReading} kWh";
    }
}