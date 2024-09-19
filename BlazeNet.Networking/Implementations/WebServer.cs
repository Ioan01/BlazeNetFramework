using System.Net;
using System.Net.Sockets;
using System.Text;
using BlazeNet.Networking.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace BlazeNet.Networking.Implementations;

public class WebServer : IWebServer
{
    private PacketListener _listener;
    private readonly NullLoggerFactory loggerFactory;

    public WebServer()
    {
        this.loggerFactory = new NullLoggerFactory();
    }

    public async Task Start(Action<ServerOptions> serverOptions)
    {
        var options = ServerOptions.Default;
        serverOptions(options);
        
        _listener = new PacketListener(options.Port, loggerFactory.CreateLogger<PacketListener>(), CancellationToken.None,
            async socket =>
            {
                byte[] response = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\nContent-Length: 13\r\n\r\nHello, world!");
                await socket.SendAsync(response, SocketFlags.None);
                await socket.DisconnectAsync(true);
            });
        await _listener.Listen();
    }
}