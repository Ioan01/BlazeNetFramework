namespace BlazeNet.Networking.Interfaces;

public class ServerOptions
{
    public int Port { get; set; }
    
    public int MaxConnections { get; set; }

    public static ServerOptions Default { get; } = new ServerOptions()
    {
        Port = 8080,
        MaxConnections = 100
    };
}