namespace Api;
public struct IpAddressModel
{
    public IpAddressModel() { }

    public string Host { get; set; } = "127.0.0.1";
    public int Port { get; set; } = 8888;
}