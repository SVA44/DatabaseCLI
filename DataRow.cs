using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Reprise_
{
    public class DataRow: IndexedObj<int>
    {
        private List<string> _cells;
        private List<string> _fields;
        public Dictionary<string, string> _keyValuePairs;
        public DataRow(int[]ids, List<string> cells, List<string> fields): base(ids)
        {
            _cells = cells;
            _fields = fields;
            _keyValuePairs = new Dictionary<string, string>() { };
            for (int i = 0; i < _fields.Count; i++)
            {
                try
                {
                    _keyValuePairs[_fields[i]] = _cells[i];
                }
                catch(Exception e)
                {
                    _keyValuePairs[_fields[i]] = null;
                }
            }
        }

        public Dictionary<string,string> Item
        {
            get { return _keyValuePairs; }
        }
        
    }
}
