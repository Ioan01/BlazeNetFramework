using System.Net.Sockets;

namespace BlazeNet.Http;

public class RequestContext
{
    public HttpRequest Request { get; set; }
    
    public HttpResponse Response { get; set; }
    
    public Socket Socket { get; set; }
}

public class HttpResponse
{
}

public class HttpRequest
{
}