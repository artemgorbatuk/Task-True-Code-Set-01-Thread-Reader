using System.Net.Sockets;
using System.Text;

namespace Api;
public class ClientService
{
    private TcpClient tcpClient = new TcpClient();

    public async Task StartClientAsync(IpAddressModel ip, Action callback)
    {
        await tcpClient.ConnectAsync(ip.Host, ip.Port);

        callback();
    }

    public async Task WriteStreamAsync(IEnumerable<string> messages, Action<string> callback, string? secret = null)
    {
        var stream = tcpClient.GetStream();

        foreach (var message in messages)
        {
            var bytes = Encoding.UTF8.GetBytes(message);

            await stream.WriteAsync(bytes);

            callback(message);
        }

        if (secret != null)
        {
            var bytes = Encoding.UTF8.GetBytes(secret);

            await stream.WriteAsync(bytes);
        }
    }

    public void CloseClient(Action callback)
    {
        tcpClient.Close();
        callback();
    }
}
