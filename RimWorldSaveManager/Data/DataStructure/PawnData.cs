using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class PawnData
    {
        private readonly XElement _xElement;

        private Name _name;

        public PawnData(XElement xElement)
        {
            _xElement = xElement;
            _name = new Name(_xElement.Element("name"));
        }

        public Name Name
        {
            get { return _name;  }
        }

    }
}
