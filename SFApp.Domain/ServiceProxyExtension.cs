using System;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using SFApp.Domain.Services;

namespace SFApp.Domain
{
    public static class ServiceProxyExtension
    {
        public static IMyStatelessService GetMyStatelessService(this IServiceProxyFactory proxyFactory)
        {
            var uri = new Uri("fabric:/" + "SFAppWithSwagger" + "/" + "MyStatelessService");
            var svc = proxyFactory.CreateServiceProxy<IMyStatelessService>(uri, listenerName: "StatelessFabricTransportServiceRemotingListener");
            return svc;

        }
    }
}