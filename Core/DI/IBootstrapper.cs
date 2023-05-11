using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DI
{
    public interface IBootstrapper
    {
        void Init();
        bool Build();
    }
}
