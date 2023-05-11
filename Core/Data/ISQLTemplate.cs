using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface ISQLTemplate
    {
        string Select { get; }
        string IdentitySql { get; }
        string PaginatedSql { get; }
        string Encapsulation { get; }
    }
}
