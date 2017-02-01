using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RimWorldSaveManager
{
    public class TraitDef
    {
        public string Def;
        public string Degree;
        public string Label;

        public override string ToString()
        {
            return Label;
        }
    }

    public class Hediff
    {
        public string Class;
        public string Name;
        public Dictionary<string, HediffDef> SubDiffs;

        public Hediff(string parentClass, string parentName)
        {
            Class = parentClass;
            Name = parentName;
            SubDiffs = new Dictionary<string, HediffDef>();
        }
    }

    public class HediffDef
    {
        public string ParentClass;
        public string Def;
        public XElement Element;
        public string ParentName;
        public string Label;
    }

    public class WorkType
    {
        public string DefName;
        public string FullName;
        public string[] WorkTags;
    }

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
                if (value == null) {
                    if (elem != null) {
                        elem.Remove();
                    }
                } else {
                    if (elem == null) {
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
                if (value == "None") {
                    elem?.Remove();
                } else {
                    if (elem == null) {
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

    public class PawnHealth
    {
        public string ParentClass => (string)_xml.Attribute("Class");
        public string Def => (string)_xml.Element("def");
        public XElement Element => _xml;

        public string Label;
        /*
        public string ParentName;
        
        */

        private readonly XElement _xml;

        public PawnHealth(XElement xml)
        {
            _xml = xml;
            if ((string)_xml.Attribute("Class") == null) {
                Console.WriteLine("Pawn hediff with null class:");
                Console.WriteLine(_xml);
            }
        }

        public override string ToString()
        {
            return Label ?? (string)_xml.Element("def");
        }
    }

    public class Pawn : TabPage
    {
        public string Def
        {
            get { return (string)_xml.Element("def"); }
            set { _xml.Element("def").SetValue(value); }
        }

        public string Id
        {
            get { return (string)_xml.Element("id"); }
            set { _xml.Element("id").SetValue(value); }
        }

        public string Pos
        {
            get { return (string)_xml.Element("pos"); }
            set { _xml.Element("pos").SetValue(value); }
        }

        public string Faction
        {
            get { return (string)_xml.Element("faction"); }
            set { _xml.Element("faction").SetValue(value); }
        }

        public string KindDef
        {
            get { return (string)_xml.Element("kindDef"); }
            set { _xml.Element("kindDef").SetValue(value); }
        }

        public string First
        {
            get { return (string)_name.Element("first"); }
            set { _name.Element("first").SetValue(value); }
        }

        public string Nick
        {
            get { return (string)_name.Element("nick"); }
            set { _name.Element("nick").SetValue(value); }
        }

        public string Last
        {
            get { return (string)_name.Element("last"); }
            set { _name.Element("last").SetValue(value); }
        }

        public string Childhood
        {
            get
            {
                var val = (string)_story.Element("childhood");
                Console.WriteLine($"{Nick} childhood backstory get:{val}");
                return val;
            }
            set
            {
                var elem = _story.Element("childhood");
                if (elem == null) {
                    elem = new XElement("childhood");
                    _story.Add(elem);
                }
                elem.SetValue(value);
                Console.WriteLine($"{Nick} childhood backstory set:{value}");
            }
        }

        public string Adulthood
        {
            get
            {
                var val = (string)_story.Element("adulthood");
                Console.WriteLine($"{Nick} adulthood backstory get:{val}");
                return val;
            }
            set
            {
                var elem = _story.Element("adulthood");
                if (elem == null) {
                    elem = new XElement("adulthood");
                    _story.Add(elem);
                }
                elem.SetValue(value);
                Console.WriteLine($"{Nick} adulthood backstory set:{value}");
            }
        }

        public long AgeBiologicalTicks
        {
            get { return (long)_age.Element("ageBiologicalTicks"); }
            set { _age.Element("ageBiologicalTicks").SetValue(value); }
        }

        public List<PawnSkill> Skills;
        public List<PawnTrait> Traits;
        public List<PawnHealth> Hediffs;

        private readonly XElement _xml;
        private readonly XElement _name;
        private readonly XElement _story;
        private readonly XElement _age;
        private readonly XElement _traits;

        public Pawn(XElement xml)
        {
            _xml = xml;
            _name = _xml.Element("name");
            _story = _xml.Element("story");
            _age = _xml.Element("ageTracker");

            Skills = (from skill in _xml.XPathSelectElements("skills/skills/li")
                      select new PawnSkill(skill)).ToList();

            _traits = _xml.XPathSelectElement("story/traits/allTraits");
            Traits = (from trait in _traits.Elements("li")
                      select new PawnTrait(trait)).ToList();

            Hediffs = (from hediff in _xml.XPathSelectElements("healthTracker/hediffSet/hediffs/li")
                       select new PawnHealth(hediff)).ToList();

            Text = First + (Nick == Last || Nick == First ? " " : (" \"" + Nick + "\" ")) + Last;
        }

        public PawnTrait AddTrait(TraitDef def)
        {
            var trait = PawnTrait.Create(def);
            _traits.Add(trait.Element);
            return trait;
        }

        public void RemoveTrait(int index)
        {
            var trait = Traits[index];
            Traits.RemoveAt(index);
            trait.Element.Remove();
        }
    }
}