using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Api;

public class ServerService
{
    private TcpListener tcpListener = new TcpListener(IPAddress.Any, 8888);

    public void StartServer(Action callback)
    {
        tcpListener.Start();
        callback();
    }

    public async IAsyncEnumerable<string> ReadSreamAsync(byte delimeter)
    {
        while (true)
        {
            using var tcpClient = await tcpListener.AcceptTcpClientAsync();

            var stream = tcpClient.GetStream();

            var buffer = new List<byte>();
            int bytes = 10;

            while (true)
            {
                while ((bytes = stream.ReadByte()) != delimeter)
                {
                    buffer.Add((byte)bytes);
                }

                var message = Encoding.UTF8.GetString(buffer.ToArray());

                buffer.Clear();

                if (message == "FLUGGAENKDECHIOEBOLSEN") 
                    yield break;

                yield return message;
            }
        }
    }

    public void StopServer(Action callback)
    {
        tcpListener.Stop();
        callback();
    }
}
