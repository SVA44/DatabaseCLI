using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Reprise_
{
    public class CurrentDir
    {

        string[] _dirLvls;
        int _lvl;
        Stack<Object> _objs;
        List<string> _dirObjNames;
        public CurrentDir() 
        {
            _dirLvls = new string[3] { "database", "table", "row" };
            _objs = new Stack<Object>();
            _lvl = 0;
            _dirObjNames = new List<string>();
        }
        public string Dirlvl
        {
            get
            {
                return _dirLvls[_lvl];
            }
        }
        public string DirName
        {
            get
            {
                string dirName = _dirObjNames[0];
                if (_dirObjNames.Count > 1 )
                {
                    for (int i =1; i< _dirObjNames.Count; i++)
                    {
                        dirName += "/" + _dirObjNames[i];
                    }
                }
                return dirName + ">";
            }
            set 
            {
                _dirObjNames.Add(value); 
            }
        }
        public Object CurrentObj
        {
            get
            {
                return _objs.Peek();
            }
        }
        public void MoveIn(Object obj)
        {
            _objs.Push(obj);
            _lvl++;
            if(Dirlvl == "table")
            {
                _dirObjNames.Add(((Table)obj).FirstID);
            }
            else
            {
                _dirObjNames.Add(((DataRow)obj).FirstID.ToString());
            }
        }
        public void MoveOut()
        {
            _objs.Pop();
            _lvl--;
            _dirObjNames.RemoveAt(_dirObjNames.Count - 1);
        }
    }
}
