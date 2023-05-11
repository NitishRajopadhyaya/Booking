using Core.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.MSSQL
{
    public sealed class MySqlQueryBuilder : QueryBuilder
    {
        public MySqlQueryBuilder(ISQLTemplate template, ITableNameResolver tblresolver, IColumnNameResolver colresolver)
          : base(template, tblresolver, colresolver)
        {
        }
        public MySqlQueryBuilder(ISQLTemplate template)
         : base(template)
        {
        }
    }
}
