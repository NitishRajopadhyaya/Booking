using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DI
{
    public interface IServiceRegistrar
    {
        void Register(IServiceCollection serviceCollection);
    }
}
