using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Reprise_
{
    public class ProcessQuery: Query
    {
        private Dictionary<String,Query> _queries;
        public ProcessQuery(CurrentDir currentDir):base (currentDir) 
        {
            _queries = new Dictionary<string, Query>()
            {
                { "Select",new SelectQuery(currentDir) },
                { "cd", new CDQuery(currentDir) },
                { "Create", new CreateQuery(currentDir) }
            };
        }
        public override string Structure 
        {
            get
            {
                string structure = "";
                foreach (Query q in _queries.Values)
                {
                    structure += q.Structure + "\n";
                }
                return structure;
            }
        }
        public override string Execute(Database db, string[] query)
        {
            if((query.Length > 0) && (_queries.ContainsKey(query[0])))
            {
                return _queries[query[0]].Execute(db,query);
            }
            else if (query[0] == "?")
            {
                return Structure;
            }
            else
            {
                return "Unrecognized Query!";
            }
        }
    }
}
