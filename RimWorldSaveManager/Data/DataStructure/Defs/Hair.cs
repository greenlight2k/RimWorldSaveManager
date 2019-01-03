using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class Hair
    {

        private string _Gender;
        private string _Title;
        private string _Def;
        private List<String> _HairTags = new List<string>();

        public Hair(string gender, string title, string def, IEnumerable<XElement> numerable)
        {
            _Gender = gender;
            _Title = title;
            _Def = def;
            foreach(var hairTag in numerable)
            {
                _HairTags.Add(hairTag.GetValue());
            }
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

        public List<String> HairTags
        {
            get { return _HairTags; }
        }

        public override string ToString()
        {
            return _Def;
        }
    }
}
