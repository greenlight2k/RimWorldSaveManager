using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class PawnRelationDef
    {

        private string _DefName;
        private string _Label;



        public PawnRelationDef(XElement xElement)
        {
            _DefName = xElement.Element("defName").GetValue();
            _Label = xElement.Element("label").GetValue();
        }

        public string DefName { get => _DefName; }
        public string Label { get => _Label;  }

        public override string ToString()
        {
            return DefName;
        }
    }
}
