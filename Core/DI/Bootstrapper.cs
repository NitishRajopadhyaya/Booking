using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.DI
{
    public class Bootstrapper : IBootstrapper
    {
        private readonly IServiceCollection _serviceCollection;
        //  private readonly IConfiguration _configuration;
        public Bootstrapper(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
            Init();
        }
        public void Init()
        {
            Build();
        }
        public bool Build()
        {
            FindThenBuild();
            return true;
        }
        private void FindThenBuild()
        {
            var serviceInstances = new List<IServiceRegistrar>();

            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);

            var instances = runtimeAssemblyNames
                .Select(Assembly.Load)
                .SelectMany(a => a.ExportedTypes)
                .Where(t => TypeExtensions.GetInterfaces(t).Contains(typeof(IServiceRegistrar)) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(y => (IServiceRegistrar)Activator.CreateInstance(y));
            serviceInstances.AddRange(instances);


            foreach (var instance in serviceInstances)
            {
                instance.Register(_serviceCollection);
            }
        }
    }
}
