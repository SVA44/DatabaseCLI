using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Reprise_
{
    public class Table: IndexedObj<string>
    {
        private List<DataRow> _rows;
        private List<string> _columns;
        private IndexedObjManager _manager;
        public Table(List<string> cols, string[] ids): base(ids) 
        {
            _rows = new List<DataRow>();
            _columns = cols;
            _manager = new IndexedObjManager();
        }
        public List<string> Columns { get { return _columns; } }
        public List<DataRow> Rows { get { return _rows; } }
        public void AddRow(DataRow row)
        {
            _rows.Add(row);
            _manager.IndexedObjs.Add(row);
        }
        public void RemoveRow(DataRow row)
        {
            _rows.Remove(row);
            _manager.IndexedObjs.Remove(row);
        }
        public void InsertRow(List<string> values)
        {
            DataRow dataRow = new DataRow(new int[] { _manager.NextID },values,_columns);
            AddRow(dataRow);
        }
        public DataRow GetDataRow(int id)
        {
            foreach(DataRow row in _rows)
            {
                if (row.IsMatched(id))
                {
                    return row;
                }
            }
            return null;
        }
    }
}
