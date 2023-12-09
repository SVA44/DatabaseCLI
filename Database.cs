using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Reprise_
{
    public class Database: IndexedObj<string>
    {
        string[] _ids;
        List<Table> _tables;
        public Database(string[] ids): base(ids)       
        { 
            _tables = new List<Table>();
            _ids = ids;
        }
        public List<Table> Tables 
        { 
            get
            {
                return _tables;
            }
        }
        public Table GetTable(string id)
        {
            foreach(Table table in _tables)
            {
                if (table.IsMatched(id))
                {
                    return table;
                }
            }
            return null;
        }
    }
}
