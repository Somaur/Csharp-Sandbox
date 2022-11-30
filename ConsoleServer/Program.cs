using System.Net.Sockets;
using System.Net;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string ipAddress = "127.0.0.1";

IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), 12121);

using Socket listener = new(
    ipEndPoint.AddressFamily,
    SocketType.Stream,
    ProtocolType.Tcp
);

listener.Bind(ipEndPoint);
listener.Listen(100);

int cnt = 10;

var handler = await listener.AcceptAsync();
while (true)
{
    // Receive message.
    var buffer = new byte[1_024];
    var received = await handler.ReceiveAsync(buffer, SocketFlags.None);
    var response = Encoding.UTF8.GetString(buffer, 0, received);

    var eom = "<|EOM|>";
    if (response.IndexOf(eom) > -1 /* is end of message */)
    {
        Console.WriteLine(
            $"Socket server received message: \"{response.Replace(eom, "")}\"");

        var ackMessage = (cnt == 0) ? "<|ACK|>" : "Send again !";
        var echoBytes = Encoding.UTF8.GetBytes(ackMessage);
        await handler.SendAsync(echoBytes, 0);
        Console.WriteLine(
            $"Socket server sent acknowledgment: \"{ackMessage}\"");

        if(cnt == 0) break;
        --cnt;
    }
    // Sample output:
    //    Socket server received message: "Hi friends 👋!"
    //    Socket server sent acknowledgment: "<|ACK|>"
}