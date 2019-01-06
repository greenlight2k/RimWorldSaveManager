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
        private XElement _Gender;

        public PawnData(XElement xElement)
        {
            _xElement = xElement;
            if (_xElement.Element("name") == null)
            {
                _xElement.Add(new XElement("name"));
            }
            _name = new Name(_xElement.Element("name"));

            if (_xElement.Element("gender") == null)
            {
                _xElement.Add(new XElement("gender", "Male"));
            }
            _Gender = _xElement.Element("gender");

        }

        public Name Name
        {
            get { return _name; }
        }

        public string Gender
        {
            get
            {
                return _Gender.GetValue();
            }
            set
            {
                _Gender.SetValue(value);
            }
        }

    }
}
