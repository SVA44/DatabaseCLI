using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Reprise_
{
    public class IndexedObjManager
    {
        private List<IndexedObj<int>> _indexedObjs;
        public IndexedObjManager() 
        {
            _indexedObjs = new List<IndexedObj<int>>() { };
        }
        public IndexedObjManager(List<IndexedObj<int>> indexedObjs)
        {
            _indexedObjs = indexedObjs;
        }

        public List<IndexedObj<int>> IndexedObjs
        {
            get { return _indexedObjs; }
        }
        public int NextID
        {
            get
            {
                return IndexedObjs.Count;
            }
        }
    }
}
