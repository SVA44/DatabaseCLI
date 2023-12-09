using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Database_Reprise_
{
    public class DisplayTable
    {
        private Table _table;
        private List<List<string>> _lines;
        public DisplayTable(Table table) 
        {
            _table = table;
            _lines = new List<List<string>>();
            List<string> headers = new List<string>(table.Columns);
            headers.Insert(0, "ID");
            _lines.Add(headers);
            foreach (DataRow row in table.Rows)
            {
                List<string> entry = new List<string>(row.Item.Values);
                entry.Insert(0, row.FirstID.ToString());
                _lines.Add(entry);
            }
        }
        public DisplayTable(Table table, string[] rule)
        {
            _table = table;
            _lines = new List<List<string>>();
            List<string> headers = new List<string>(table.Columns);
            headers.Insert(0, "ID");
            _lines.Add(headers);
            List<DataRow> visibleRows = FilterRows(table, rule);
            foreach (DataRow row in visibleRows)
            {
                List<string> entry = new List<string>(row.Item.Values);
                entry.Insert(0, row.FirstID.ToString());
                _lines.Add(entry);
            }
        }

        public List<DataRow> FilterRows(Table tb, string[] rule)
        {
            List<DataRow> filteredRows = new List<DataRow>();
            foreach (DataRow row in tb.Rows)
            {
                if (row.Item[rule[0]] == rule[2])
                {
                    filteredRows.Add(row);
                }
            }
            return filteredRows;
        }
        public string FormatedTable
        {
            get
            {
                string formatedTable = "";
                List<int> scaleWeights = Scaling();
                foreach (List<string> line in _lines)
                {
                    DisplayLine displayLine = new DisplayLine(line, scaleWeights);
                    string newLine = displayLine.FormatLine;
                    formatedTable += newLine + "\n" + "".PadRight(newLine.Length, '-') + "\n";
                }
                return formatedTable;
            }
        }
        public List<int> Scaling()
        {
            List<int> scales = new List<int>();
            for (int i = 0; i < _lines[0].Count; i++)
            {
                List<int> field_lengths = new List<int>();
                foreach (List<string> line in _lines)
                {
                    field_lengths.Add(line[i].Length);
                }
                scales.Add(field_lengths.Max());
            }
            return scales;
        }
    }
}
