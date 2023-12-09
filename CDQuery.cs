using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Reprise_
{
    public class CDQuery:Query
    {
        // Query form: cd [object_id] or ..
        private Dictionary<string, string> _structure;
        public CDQuery(CurrentDir currentDir): base(currentDir)
        {
            _structure = new Dictionary<string, string>()
            {
                {"database", "cd [table_id]" },
                {"table", "cd [[row_id] | ..]" },
                {"row", "cd .." }
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
            if ((query[1] == "..") && (Dir.Dirlvl != "database"))
            {
                Dir.MoveOut();
                return null;
            }
            else if(query.Length > 2)
            {
                return "Cannot find directory!";
            }
            else
            {
                
                if (Dir.Dirlvl == "table")
                {   
                    int id = Int32.Parse(query[1]);
                    Table tb = (Table)Dir.CurrentObj;
                    DataRow rw = tb.GetDataRow(id);
                    if(rw == null)
                    {
                        return "No Directory found";
                    }
                    else
                    {
                        Dir.MoveIn(rw);
                        return null;
                    }
                }
                else if(Dir.Dirlvl == "database")
                {
                    string id = query[1];
                    Table tb = db.GetTable(id);
                    if(tb == null)
                    {
                        return "No Directory found";
                    }
                    else
                    {
                        Dir.MoveIn(tb);
                        return null;
                    }
                }
                else
                {
                    return "Invalid Directory!";
                }
            }
        }
    }
}
