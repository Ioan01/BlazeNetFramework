using BlazeNet.Http;

namespace BlazeNet.Middleware.Interfaces;

public interface IMiddlewareProvider
{
    Task InvokeChainAsync(RequestContext context);
    void AddMiddleware(IMiddleware middleware);
}