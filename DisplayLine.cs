using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Reprise_
{
    public class DisplayLine
    {
        private List<string> _line;
        private Dictionary<string,int> _lineScales;
        public DisplayLine(List<string> line, List<int> scales) 
        {
            _line = line;
            _lineScales = new Dictionary<string,int>();
            for (int i = 0;i < line.Count; ++i)
            {
                _lineScales[line[i]] = scales[i];
            }
        }
        public string FormatLine
        {
            get
            {
                string formatedLine = "";
                formatedLine += "|";
                foreach (string field in _line)
                {
                    string formatedField = " " + field.PadRight(_lineScales[field]) + " |";
                    formatedLine += formatedField;
                }
                return formatedLine;
            }
        }
    }
}
