using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class PawnTrait
    {
        public string Def => (string)_xml.Element("def");
        public string Degree => (string)_xml.Element("degree");
        public XElement Element => _xml;

        //public string Label;
        private string _label;

        private readonly XElement _xml;

        public PawnTrait(XElement xml)
        {
            _xml = xml;

            var traitKey = Def + Degree;
            _label = DataLoader.Traits.ContainsKey(traitKey) ? DataLoader.Traits[traitKey].Label : Def;
        }

        public override string ToString()
        {
            return _label;
        }

        public static PawnTrait Create(TraitDef def)
        {
            return new PawnTrait(new XElement("li", new XElement("def", def.Def), new XElement("degree", def.Degree)));
        }


    }
}
