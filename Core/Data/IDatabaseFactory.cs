using Core.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface IDatabaseFactory : IDisposable
    {
        IDbConnection Db { get; }
        IDbConnection GetConnection();
        Dialect Dialect { get; }

        QueryBuilder QueryBuilder { get; }
    }
}