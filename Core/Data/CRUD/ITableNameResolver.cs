using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.CRUD
{
    public interface ITableNameResolver
    {
        string ResolveTableName(Type type);
    }
}
