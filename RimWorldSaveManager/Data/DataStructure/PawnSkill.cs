using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class PawnSkill
    {
        public string Name
        {
            get { return (string)_xml.Element("def"); }
            set { _xml.Element("def").SetValue(value); }
        }

        public int? Level
        {
            get { return (int?)_xml.Element("level"); }
            set
            {
                var elem = _xml.Element("level");
                if (value == null)
                {
                    if (elem != null)
                    {
                        elem.Remove();
                    }
                }
                else
                {
                    if (elem == null)
                    {
                        elem = new XElement("level");
                        _xml.Add(elem);
                    }
                    elem.SetValue(value);
                }
            }
        }

        public float Experience
        {
            get { return (float)_xml.Element("xpSinceLastLevel"); }
            set { _xml.Element("xpSinceLastLevel").SetValue(value); }
        }

        public string Passion
        {
            get { return (string)_xml.Element("passion"); }
            set
            {
                var elem = _xml.Element("passion");
                if (value == "None")
                {
                    elem?.Remove();
                }
                else
                {
                    if (elem == null)
                    {
                        elem = new XElement("passion");
                        _xml.Add(elem);
                    }
                    elem.SetValue(value);
                }
            }
        }

        private readonly XElement _xml;

        public PawnSkill(XElement xml)
        {
            _xml = xml;
        }
    }
}
