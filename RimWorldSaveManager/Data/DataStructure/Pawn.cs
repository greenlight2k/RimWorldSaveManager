using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class Pawn
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

        public String PawnId
        {
            get
            {
                return "Thing_" + _pawnId.GetValue();
            }

        }

        public String Firstname
        {
            get { return _name.First; }
            set { _name.First = value;
                foreach(var pawnData in _pawnDatas)
                {
                    pawnData.Name.First = value;
                }
            }
        }

        public String Nickname
        {
            get { return _name.Nick; }
            set
            {
                _name.Nick = value;
                foreach (var pawnData in _pawnDatas)
                {
                    pawnData.Name.Nick = value;
                }
            }
        }

        public String Lastname
        {
            get { return _name.Last; }
            set
            {
                _name.Last = value;
                foreach (var pawnData in _pawnDatas)
                {
                    pawnData.Name.Last = value;
                }
            }
        }


        public string He
        {
            get
            {
                if ((string)_xml.Element("gender") == "Female")
                {
                    return "she";
                }
                return "he";
            }
        }

        public string His
        {
            get
            {
                if ((string)_xml.Element("gender") == "Female")
                {
                    return "her";
                }
                return "his";
            }
        }

        public string HeCap
        {
            get
            {
                if ((string)_xml.Element("gender") == "Female")
                {
                    return "She";
                }
                return "He";
            }
        }

        public string HisCap
        {
            get
            {
                if ((string)_xml.Element("gender") == "Female")
                {
                    return "Her";
                }
                return "His";
            }
        }

        public string Childhood
        {
            get
            {
                var val = (string)_story.Element("childhood");
                Logger.Debug(string.IsNullOrEmpty(val)
                    ? $"{_name.Nick} childhood backstory get:NULL"
                    : $"{_name.Nick} childhood backstory get:{val}");
                return val;
            }
            set
            {
                var elem = _story.Element("childhood");

                if (value == null)
                {
                    if (elem != null)
                    {
                        elem.Remove();
                    }
                    Logger.Debug($"{_name.Nick} childhood backstory set:NULL");
                    return;
                }

                if (elem == null)
                {
                    elem = new XElement("childhood");
                    _story.Add(elem);
                }
                elem.SetValue(value);
                Logger.Debug($"{_name.Nick} childhood backstory set:{value}");
            }
        }

        public string Adulthood
        {
            get
            {
                var val = (string)_story.Element("adulthood");
                Logger.Debug(string.IsNullOrEmpty(val)
                    ? $"{_name.Nick} adulthood backstory get:NULL"
                    : $"{_name.Nick} adulthood backstory get:{val}");
                return val;
            }
            set
            {
                var elem = _story.Element("adulthood");
                if (value == null)
                {
                    if (elem != null)
                    {
                        elem.Remove();
                    }
                    Logger.Debug($"{_name.Nick} adulthood backstory set:NULL");
                    return;
                }

                if (elem == null)
                {
                    elem = new XElement("adulthood");
                    _story.Add(elem);
                }
                elem.SetValue(value);
                Logger.Debug($"{_name.Nick} adulthood backstory set:{value}");
            }
        }

        public long AgeBiologicalTicks
        {
            get { return (long)_age.Element("ageBiologicalTicks"); }
            set { _age.Element("ageBiologicalTicks").SetValue(value); }
        }

        public long AgeChronoligicalTicks
        {
            get { return (long)_age.Element("birthAbsTicks"); }
            set { _age.Element("birthAbsTicks").SetValue(value); }
        }

        public Training Training
        {
            get
            {
                return training;
            }
        }

        public String FullName
        {
            get
            {
                return _name.FullName();
            }
        }

        public String PawnDef
        {
            get
            {
                return (String)_pawnDef.GetValue();
            }
        }

        public List<PawnSkill> Skills;
        public List<PawnTrait> Traits;
        public List<PawnHealth> Hediffs;
        private Training training;

        private readonly XElement _xml;
        private readonly Name _name;
        private readonly XElement _pawnId;
        private readonly XElement _pawnDef;
        private readonly XElement _story;
        private readonly XElement _age;
        private readonly XElement _traits;

        private readonly List<PawnData> _pawnDatas;

        public Pawn(XElement xml)
        {
            _xml = xml;
            _name = new Name(_xml.Element("name"));
            _pawnId = _xml.Element("id");
            _pawnDef = _xml.Element("def");
            _story = _xml.Element("story");
            _age = _xml.Element("ageTracker");

            IEnumerable<XElement> skills = _xml.XPathSelectElements("skills/skills/li");
            if (skills != null)
            {
                Skills = (from skill in skills
                          select new PawnSkill(skill)).ToList();
            }

            _traits = _xml.XPathSelectElement("story/traits/allTraits");
            if (_traits != null && _traits.HasElements)
            {
                Traits = (from trait in _traits.Elements("li")
                          select new PawnTrait(trait)).ToList();
            }
          
            IEnumerable<XElement> hediffs = _xml.XPathSelectElements("healthTracker/hediffSet/hediffs/li");
            Hediffs = (from hediff in hediffs
                       select new PawnHealth(hediff, PawnDef)).ToList();

            XElement trainingElemnt = _xml.Element("training");
            if(trainingElemnt != null)
            {
                training = new Training(trainingElemnt, PawnDef);
            }
            else
            {
                training = null;
            }

            _pawnDatas = new List<PawnData>();
        }

        public void addPawnData(List<PawnData> pawnData)
        {
            _pawnDatas.AddRange(pawnData);
        }

        public PawnTrait AddTrait(TraitDef def)
        {
            var trait = PawnTrait.Create(def);
            _traits.Add(trait.Element);
            Traits.Add(trait);
            return trait;
        }

        public void RemoveTrait(int index)
        {
            var trait = Traits[index];
            Traits.RemoveAt(index);
            trait.Element.Remove();
        }

 
        public override string ToString()
        {
            return _name.ToString();
        }
    }
}
