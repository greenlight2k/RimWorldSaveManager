using RimWorldSaveManager.Data.DataStructure.Defs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class PawnHealth
    {
        public string ParentClass => (string)_xml.Attribute("Class");
        public string Def => (string)_xml.Element("def");

        public string PartIndex
        {
            get {
                XElement part = _xml.Element("part");
                if(part != null)
                {
                    return (string)part.Element("index");
                }
                return null;
            }
        }

        public string PartBody
        {
            get
            {
                XElement part = _xml.Element("part");
                if (part != null)
                {
                    return (string)part.Element("body");
                }
                return null;
            }
        }
        public XElement Element => _xml;

        public string Label;

        private string _PawnDef;

        private readonly XElement _xml;

        public PawnHealth(XElement xml, String pawnDef)
        {
            _xml = xml;
            _PawnDef = pawnDef;
            if ((string)_xml.Attribute("Class") == null)
            {
                Console.WriteLine("Pawn hediff with null class:");
                Console.WriteLine(_xml);
            }
        }

        public override string ToString()
        {
            String description = null;


            if(PartIndex != null && DataLoader.BodyDefsByDef.TryGetValue(PartBody, out BodyDef bodyDef)){
                int partIndexInt = int.Parse(PartIndex);
                if(bodyDef.BodyPartDefDic.TryGetValue(partIndexInt, out BodyPartDef value))
                {
                    description = bodyDef.BodyPartDefDic[partIndexInt].getLabel();
                }
            }
            
            return (Label ?? (string)_xml.Element("def"))  + (description != null ? (" - " + description) : "");
        }
    }
}
