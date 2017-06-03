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
            get { return (string)_xml.Element("partIndex"); }
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
            String description;
            switch (_PawnDef)
            {
                case "Human":
                    description = PartIndex != null ? DataLoader.HumanBodyPartDescription[PartIndex] : null;
                    break;
                default:
                    description = null;
                    break;
            }

            return (Label ?? (string)_xml.Element("def"))  + (description != null ? (" - " + description) : "");
        }
    }
}
