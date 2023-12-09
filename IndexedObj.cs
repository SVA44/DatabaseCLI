using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Reprise_
{
    public class IndexedObj<T>
    {
        private T[] _ids;
        public IndexedObj(T[] ids) 
        {
            _ids = ids;
        }
        public T FirstID 
        { 
            get { return _ids[0]; }
        }
        public bool IsMatched(T id)
        {
            return _ids.Contains(id);  
        }
    }
}
