using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class Relation
    {

        private readonly XElement xElement;
        private XElement _otherPawn;
        private XElement _Def;
        private XElement _StartTicks;

        public string OtherPawn
        {
            get
            {
                return _otherPawn.GetValue();
            }
            set
            {
                _otherPawn.SetValue(value);
            }
        }

        public string Def
        {
            get
            {
                return _Def.GetValue();
            }
            set
            {
                _Def.SetValue(value);
            }
        }

        public long StartTicks
        {
            get
            {
                if (_StartTicks != null && _StartTicks.GetValue().Length > 0)
                {
                    return long.Parse(_StartTicks.GetValue());
                }
                return 0;
            }
            set
            {
                if (_StartTicks != null)
                {
                    _StartTicks.SetValue(value);
                }
                else
                {
                    XElement.Add(new XElement("startTicks", value));
                    _StartTicks = xElement.Element("startTicks");
                }
            }
        }

        public XElement XElement => xElement;

        public Relation(XElement element)
        {
            xElement = element;
            _Def = xElement.Element("def");
            _otherPawn = xElement.Element("otherPawn");
            _StartTicks = xElement.Element("startTicks");
        }

        public static Relation create(XElement xElement, PawnRelationDef pawnRelationDef)
        {
            XElement relationListElement = new XElement("li", new XElement("def", pawnRelationDef.DefName), new XElement("otherPawn"), new XElement("startTicks", 0));
            xElement.Add(relationListElement);
            return new Relation(relationListElement);
        }

        public override string ToString()
        {
            return Def;
        }
    }
}
