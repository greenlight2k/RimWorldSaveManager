using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class Faction
    {

        private readonly XElement _XElement;


        private string Id
        {
            get {
                XElement id = _XElement.Element("loadID");
                if(id == null)
                {
                    return "0";
                }
                return id.GetValue();
            }
        }

        public string FactionIDString
        {
            get { return "Faction_" + Id; }
        }

        public string Name
        {
            get { return _XElement.Element("name").GetValue(); }
        }

        public string Def
        {
            get { return _XElement.Element("def").GetValue(); }
        }

        public Faction(XElement xElement)
        {
            _XElement = xElement;
        }

        public override string ToString()
        {
            if(Name == null || Name.Length == 0)
            {
                return FactionIDString;
            }
            return Name;
        }
    }
}
