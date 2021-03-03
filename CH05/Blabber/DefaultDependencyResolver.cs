using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blabber
{
    public class DefaultDependencyResolver : IDependencyResolver
    {
        public DefaultDependencyResolver(ServiceProvider provider)
        {
            Provider = provider;
        }

        public ServiceProvider Provider { get; }

        public object GetService(Type serviceType)
        {
            return Provider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Provider.GetServices(serviceType);
        }
    }
}