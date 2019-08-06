using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDAL
{
    public static class IdListExtension
    {
        public static DataTable AsTableOfInts(this List<int> ids)
        {
            var dataTable = new DataTable("dbo.ListOfInts");
            dataTable.Columns.Add("Id", typeof(int));
            ids.ForEach(intvalue => dataTable.Rows.Add(intvalue));
            return dataTable;
        }
    }
}
