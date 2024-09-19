using BlazeNet.Http;

namespace BlazeNet.Middleware.Interfaces;

public interface IMiddleware
{
    public Task InvokeAsync(RequestContext context);
}