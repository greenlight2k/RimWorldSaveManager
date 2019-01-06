using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure.Defs
{
    public class BodyPartDef
    {
        private string _Def;
        private string _CustomLabel;
        private int _PartIndex;

        public BodyPartDef(XElement xElement, int partIndex)
        {
            Def = xElement.Element("def").GetValue();
            PartIndex = partIndex;
            if(xElement.Element("customLabel") != null)
            {
                CustomLabel = xElement.Element("customLabel").GetValue();
            }
        }

        public string getLabel()
        {
            if(CustomLabel != null)
            {
                return CustomLabel;
            }
            return Def;
        }

        public string Def { get => _Def; set => _Def = value; }
        public string CustomLabel { get => _CustomLabel; set => _CustomLabel = value; }
        public int PartIndex { get => _PartIndex; set => _PartIndex = value; }
    }
}
