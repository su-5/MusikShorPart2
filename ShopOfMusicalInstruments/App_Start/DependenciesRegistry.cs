using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using BLL.Core.BLL_Core.Interface;
using BLL.Core.BLL_Core.Repository;
using Unity;

namespace ShopOfMusicalInstruments.Core
{
    public class DependenciesRegistry
    {

        public static IUnityContainer RegisterComponents()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IBLLFactory, BLLFactory>(); // singleton

            return container;
        }

        public class UnityResolver : IDependencyResolver
        {
            protected IUnityContainer Container;

            public UnityResolver(IUnityContainer container)
            {
                if (container == null)
                {
                    throw new ArgumentNullException(nameof(container));
                }
                Container = container;
            }

            public object GetService(Type serviceType)
            {
                try
                {
                    return Container.Resolve(serviceType);
                }
                catch (ResolutionFailedException)
                {
                    return null;
                }
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                try
                {
                    return Container.ResolveAll(serviceType);
                }
                catch (ResolutionFailedException)
                {
                    return new List<object>();
                }
            }

            public IDependencyScope BeginScope()
            {
                var child = Container.CreateChildContainer();
                return new UnityResolver(child);
            }

            public void Dispose()
            {
                Container.Dispose();
            }
        }
    }
}