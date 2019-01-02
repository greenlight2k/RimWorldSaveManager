using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class Name
    {
        enum NameClass { NameSingle, NameTriple, Null }

        private readonly XElement _name;

        private NameClass _nameClass;

        public Name(XElement name)
        {
            _name = name;
            XAttribute isNull = name.Attribute("IsNull");
            XAttribute nameClass = name.Attribute("Class");
            if (isNull == null && nameClass != null)
            {
                switch (nameClass.Value) { 
                case "NameSingle":
                    _nameClass = NameClass.NameSingle;
                    break;
                case "NameTriple":
                    _nameClass = NameClass.NameTriple;
                    break;
                }
            }
            else
            {
                _nameClass = NameClass.Null;
            }
        }

        public String First
        {
            get
            {
                if (_nameClass == NameClass.NameTriple)
                {
                    return (String)_name.Element("first");
                }
                return null;
            }
            set
            {
                if (_nameClass == NameClass.NameTriple)
                {
                    _name.Element("first").SetValue(value);
                }
            }
        }

        public String Nick
        {
            get
            {
                if (_nameClass == NameClass.NameTriple)
                {
                    return (String)_name.Element("nick");
                }
                if(_nameClass == NameClass.NameSingle){
                    return (String)_name.Element("name");
                }
                return null;
            }
            set
            {
                if (_nameClass == NameClass.NameTriple)
                {
                    _name.Element("nick").SetValue(value);
                }
                if (_nameClass == NameClass.NameSingle)
                {
                    _name.Element("name").SetValue(value);
                    XElement numerical = _name.Element("numerical");
                    if(numerical!= null)
                    {
                        numerical.Remove();
                    }
                }
            }
        }

        public String Last
        {
            get
            {
                if (_nameClass == NameClass.NameTriple)
                {
                    return (String)_name.Element("last");
                }
                return null;
            }
            set
            {
                if (_nameClass == NameClass.NameTriple)
                {
                    _name.Element("last").SetValue(value);
                }
            }
        }

        public string FullName()
        {
            if (_nameClass == NameClass.NameTriple)
            {
                return First + (Nick == Last || Nick == First ? " " : (" \"" + Nick + "\" ")) + Last; ;
            }
            if (_nameClass == NameClass.NameSingle)
            {
                return Nick;
            }
            return "undefined";
        }

        public override string ToString()
        {
            return FullName();
        }
    }
}
