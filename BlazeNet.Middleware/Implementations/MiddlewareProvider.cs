using System.Data;
using BlazeNet.Http;
using BlazeNet.Middleware.Interfaces;

namespace BlazeNet.Middleware.Implementations;

public class MiddlewareProvider : IMiddlewareProvider
{
    private readonly List<IMiddleware> _middlewares = new List<IMiddleware>();
    private readonly IServiceProvider _serviceProvider;
    
    public async Task InvokeChainAsync(RequestContext context)
    {
        
    }

    public void AddMiddleware(IMiddleware middleware)
    {
        _middlewares.Add(middleware);
    }
}