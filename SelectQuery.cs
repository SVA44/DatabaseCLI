using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Reprise_
{
    public class SelectQuery: Query
    {// Select table [table id]  || Select row where [field] = [value]   
        private Dictionary<string, string> _structure;
        public SelectQuery(CurrentDir currentDir): base (currentDir)
        {
            _structure = new Dictionary<string, string>()
            {
                {"database", "Select table [table id]" },
                {"table", "Select row where [field] = [value]" },
                {"row", "" }
            };
        }
        public override string Structure
        {
            get
            {
                return _structure[Dir.Dirlvl];
            }
        }
        public override string Execute(Database db, string[] query)
        {
            if (Dir.Dirlvl == "database")
            {
                if ((query[1] != "table") || (query.Length != 3))
                {
                    return "Invalid Select Query";
                }
                else
                {
                    string id = query[2];
                    Table tb = db.GetTable(id);
                    if(tb == null)
                    {
                        return "No table is found!";
                    }
                    else
                    {
                        DisplayTable displayTable = new DisplayTable(tb);
                        return displayTable.FormatedTable;
                    }
                }
            }
            else if( Dir.Dirlvl == "table")
            {
                if ((query[1] == "row") && (query[2] == "where") && (query[4] == "=")&&(query.Length == 6))
                {
                    string[] rule = query.SubArray<string>(3, query.Length - 3);
                    DisplayTable displayTable = new DisplayTable((Table)Dir.CurrentObj, rule);
                    return displayTable.FormatedTable;
                }
                else
                {
                    return "Invalid Select Query!";
                }
            }
            else
            {
                return "Invalid Directory!";
            }
        }
    }
}
