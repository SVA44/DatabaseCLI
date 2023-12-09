using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Reprise_
{
    public class CreateQuery: Query
    {
        // create [table/database] [object name] with [col1_name/col1_value] [col2_name/col2_value] ....
        private Dictionary<string, string> _structure;
        public CreateQuery(CurrentDir currentDir): base(currentDir)
        {
            _structure = new Dictionary<string, string>() 
            {
                {"database","Create table [name] with [col1_name] [col2_name] ..." },
                {"table", "Create row [id] with [field1_value] [field2_value] ..." },
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
            if(Dir.Dirlvl == "database")
            {
                if((query.Length < 5) || (query[1] != "table") || (query[3] != "with"))
                {
                    return "Invalid Create Query!";
                }
                else
                {
                    string name = query[2];
                    string[] cols = query.SubArray<string>(4, query.Length - 4);
                    Table tb = new Table(new List<string>(cols), new string[] { name });
                    db.Tables.Add(tb);
                    return "Table is added to the database!";
                }
            }
            else if (Dir.Dirlvl == "table")
            {
                if ((query.Length < 5) || (query[1] != "row") || (query[3] != "with"))
                {
                    return "Invalid Create Query!";
                }
                else
                {
                    string[] values = query.SubArray<string>(4,query.Length - 4);
                    Table currenttb = (Table)Dir.CurrentObj;
                    currenttb.InsertRow(new List<string>(values));
                    return "Row is added to table " + currenttb.FirstID;
                }
            }
            else
            {
                return "Cannot create object in this directory!";
            }
        }

    }
}
