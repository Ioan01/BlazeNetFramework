namespace BlazeNet.Networking.Interfaces;

public interface IWebServer
{
    Task Start(Action<ServerOptions> serverOptions);
}