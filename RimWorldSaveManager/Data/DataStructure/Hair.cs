using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class Hair
    {

        private string _Gender;
        private string _Title;
        private string _Def;

        public Hair(string gender, string title, string def)
        {
            _Gender = gender;
            _Title = title;
            _Def = def;
        }

        public string Gender
        {
            get { return _Gender; }
        }

        public string Title
        {
            get { return _Title; }
        }

        public string Def
        {
            get { return _Def; }
        }

        public override string ToString()
        {
            return _Def;
        }
    }
}
