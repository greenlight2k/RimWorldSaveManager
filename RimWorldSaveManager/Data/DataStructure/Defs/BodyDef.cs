using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure.Defs
{
    public class BodyDef
    {

        private string _DefName;
        private string _Label;

        private Dictionary<int, BodyPartDef> _BodyPartDefDic = new Dictionary<int, BodyPartDef>();
        private int _BodyPartCount = 0;

        public BodyDef(XElement xElement)
        {
            DefName = xElement.Element("defName").GetValue();
            Label = xElement.Element("label").GetValue();

            XElement BodyPart = xElement.Element("corePart");

            addBodyPart(BodyPart);
        }

        public string DefName { get => _DefName; set => _DefName = value; }
        public string Label { get => _Label; set => _Label = value; }
        public Dictionary<int, BodyPartDef> BodyPartDefDic { get => _BodyPartDefDic; }

        private void addBodyPart(XElement BodyPart)
        {
            BodyPartDefDic.Add(_BodyPartCount, new BodyPartDef(BodyPart, _BodyPartCount++));
            XElement parts = BodyPart.Element("parts");
            if(parts != null)
            {
                IEnumerable<XElement> subParts = parts.Elements("li");
                foreach (var subPart in subParts)
                {
                    addBodyPart(subPart);
                }
            }
        }

    }
}
