using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Reprise_
{
    public abstract class Query
    {
        private CurrentDir _currentDir;
        public Query(CurrentDir currentDir)
        {
            _currentDir = currentDir;
        }
        public CurrentDir Dir
        {
            get
            {
                return _currentDir;
            }
        }
        public abstract string Structure { get; }
        public abstract string Execute(Database db,string[] sql);
    }
}
