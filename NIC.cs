public enum NICType
{
    Ethernet,
    TokenRing
}

public class NIC
{
    private static NIC _instance;
    public string Manufacture { get; private set; }
    public string MACAddress { get; private set; }
    public NICType Type { get; private set; }

    // Private constructor to prevent instantiation
    private NIC(string manufacture, string macAddress, NICType type)
    {
        Manufacture = manufacture;
        MACAddress = macAddress;
        Type = type;
    }

    // Public method to provide the single instance
    public static NIC GetInstance(string manufacture, string macAddress, NICType type)
    {
        if (_instance == null)
        {
            _instance = new NIC(manufacture, macAddress, type);
        }
        return _instance;
    }

    public override string ToString()
    {
        return $"NIC [Manufacture: {Manufacture}, MAC Address: {MACAddress}, Type: {Type}]";
    }
}

class Program
{
    static void Main()
    {
        NIC nic = NIC.GetInstance("Intel", "00:1A:2B:3C:4D:5E", NICType.Ethernet);
        Console.WriteLine(nic);
    }
}
