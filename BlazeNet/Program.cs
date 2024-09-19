// See https://aka.ms/new-console-template for more information

using BlazeNet.Networking.Implementations;

var webServer = new WebServer();
await webServer.Start(options =>
{
    options.Port = 8080;
});

await Task.Delay(1000000000);