using System.Net;
using System.Net.Sockets;
using BlazeNet.Http;
using Microsoft.Extensions.Logging;

namespace BlazeNet.Networking.Implementations;

public class PacketListener
{
    private ILogger? _logger;
    private TcpListener tcpListener;
    private CancellationToken _cancellationToken;
    private Func<Socket, Task> CallBackTask { get; set; }

    public PacketListener(int port, ILogger? logger, CancellationToken cancellationToken, Func<Socket, Task> callBackTask)
    {
        _logger = logger;
        _cancellationToken = cancellationToken;
        try
        {
            tcpListener = TcpListener.Create(port);
        }
        catch (SocketException e)
        {
            Console.WriteLine($"Port {port} is invalid: {e.Message}");
            throw;
        }
        
        CallBackTask = callBackTask;
    }
    public async Task Listen()
    {
        tcpListener.Start();
        _logger?.LogInformation($"Starting listening for connections on port {(tcpListener.LocalEndpoint as IPEndPoint)?.Port}");
        try
        {
            while (_cancellationToken.IsCancellationRequested == false) 
            {
                var socket = await tcpListener.AcceptSocketAsync(_cancellationToken);
                Task.Run(() => CallBackTask(socket));
            }
        }
        catch (Exception e)
        {
            _logger?.LogError(e.ToString());
            await Listen();
        }
    }

    
}