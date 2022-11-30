using System.Net.Sockets;
using System.Net;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

string ipAddress = "127.0.0.1";

IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), 12121);

//using Socket client = new(
//    ipEndPoint.AddressFamily,
//    SocketType.Stream,
//    ProtocolType.Tcp
//);

Socket client = new(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

await client.ConnectAsync(ipEndPoint);
int cnt = 0;
while (true)
{
    // Send message.
    var message = "Hi friends 👋!<|EOM|> [" + (cnt++) + "]";
    var messageBytes = Encoding.UTF8.GetBytes(message);
    _ = await client.SendAsync(messageBytes, SocketFlags.None);
    Console.WriteLine($"Socket client sent message: \"{message}\"");

    // Receive ack.
    //var buffer = new byte[1_024];
    //var received = await client.ReceiveAsync(buffer, SocketFlags.None);
    //var response = Encoding.UTF8.GetString(buffer, 0, received);
    //if (response != "<|ACK|>")
    //{
    //    Console.WriteLine(
    //        $"Socket client received acknowledgment: \"{response}\"");
    //    //break;
    //}
    if (cnt == 15) break;
    // Sample output:
    //     Socket client sent message: "Hi friends 👋!<|EOM|>"
    //     Socket client received acknowledgment: "<|ACK|>"
    Thread.Sleep(500);
}

client.Shutdown(SocketShutdown.Both);
client.Close();