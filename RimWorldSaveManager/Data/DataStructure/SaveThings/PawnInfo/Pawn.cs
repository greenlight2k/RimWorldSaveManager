using RimWorldSaveManager.Data.DataStructure.Defs;
using RimWorldSaveManager.Data.DataStructure.PawnInfo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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

        public string Gender
        {
            get
            {
                return _xml.Element("gender").GetValue();
            }
            set
            {
                _xml.Element("gender").SetValue(value);
                foreach (var pawnData in _pawnDatas)
                {
                    pawnData.Gender = value;
                }
                setHeadGraphicPath();
            }
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
            set
            {
                _name.First = value;
                foreach (var pawnData in _pawnDatas)
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


        public string Pronoun
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

        public string Possessive
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

        public string Objective
        {
            get
            {
                if ((string)_xml.Element("gender") == "Female")
                {
                    return "her";
                }
                return "him";
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

        public string BodyType
        {
            get { return _story.Element("bodyType").GetValue(); }
            set { _story.Element("bodyType").SetValue(value); }
        }

        public CrownType CrownType
        {
            get
            {
                return new CrownType
                {
                    CrownFirstType = _crownFirstType,
                    CrownSubType = _crownSubType
                };
            }
            set
            {
                _story.Element("crownType").SetValue(value.CrownFirstType);
                _crownFirstType = value.CrownFirstType;
                _crownSubType = value.CrownSubType;
                setHeadGraphicPath();
            }
        }

        public string HeadGraphicPath
        {
            get { return _story.Element("headGraphicPath").GetValue(); }
            set { _story.Element("headGraphicPath").SetValue(value); }
        }
        public string HairDef
        {
            get { return _story.Element("hairDef").GetValue(); }
            set { _story.Element("hairDef").SetValue(value); }
        }

        public decimal Melanin
        {
            get
            {
                XElement melanin = _story.Element("melanin");
                if (melanin == null)
                {
                    return 0;
                }
                return decimal.Parse(_story.Element("melanin").GetValue(), CultureInfo.InvariantCulture);
            }
            set
            {
                decimal m = Math.Truncate(value * 100000000) / 100000000;
                XElement melanin = _story.Element("melanin");
                if (melanin == null)
                {
                    _story.Element("hairColor").AddAfterSelf(new XElement("melanin", 0));
                }
                _story.Element("melanin").SetValue(m.ToString(CultureInfo.InvariantCulture));
            }
        }

        public Color HairColor
        {
            get
            {
                string colorString = _story.Element("hairColor").GetValue().Replace("RGBA(", "").Replace(")", "");
                if (colorString == null || colorString.Length == 0)
                {
                    return Color.White;
                }
                string[] RGBA = colorString.Split(',');
                int R = (int)(double.Parse(RGBA[0], CultureInfo.InvariantCulture) * 255);
                int G = (int)(double.Parse(RGBA[1], CultureInfo.InvariantCulture) * 255);
                int B = (int)(double.Parse(RGBA[2], CultureInfo.InvariantCulture) * 255);
                int A = (int)(double.Parse(RGBA[3], CultureInfo.InvariantCulture) * 255);
                return Color.FromArgb(A, R, G, B);
            }
            set
            {
                if (_story.Element("hairColor") != null)
                {
                    string R = getRGBAString(value.R);
                    string G = getRGBAString(value.G);
                    string B = getRGBAString(value.B);
                    string A = getRGBAString(value.A);
                    _story.Element("hairColor").SetValue("RGBA(" + R + ", " + G + ", " + B + ", " + A + ")");
                }

            }
        }

        private string getRGBAString(byte colorBytes)
        {
            decimal m = (decimal)colorBytes / 255;
            m = Math.Truncate(m * 1000) / 1000;
            return m.ToString("0.000", CultureInfo.InvariantCulture);
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

        public String FullNameAndDef
        {
            get
            {
                return _name.FullName() + " " + PawnDef;
            }
        }

        public String PawnDef
        {
            get
            {
                return (String)_pawnDef.GetValue();
            }
        }

        public Race Race { get => _race; set => _race = value; }

        public bool HealthStateDown
        {
            get
            {
                XElement healthState = _xml.XPathSelectElement("healthTracker/healthState");
                if (healthState != null && healthState.Value == "Down")
                {
                    return true;
                }
                return false;
            }
            set
            {
                if (value)
                {
                    XElement healthTracker = _xml.XPathSelectElement("healthTracker");
                    XElement healthState = new XElement("healthState", "Down");
                    healthTracker.AddFirst(healthState);
                }
                else
                {
                    XElement healthState = _xml.XPathSelectElement("healthTracker/healthState");
                    if (healthState != null && healthState.Value == "Down")
                    {
                        healthState.Remove();
                    }
                }
            }
        }


        public List<PawnSkill> Skills;
        public List<PawnTrait> Traits;
        public List<PawnHealth> Hediffs;
        public List<Relation> Relations;
        public List<PawnApparel> Apparel;
        private Training training;

        private readonly XElement _xml;
        private readonly Name _name;
        private readonly XElement _pawnId;
        private readonly XElement _pawnDef;
        private readonly XElement _story;
        private readonly XElement _age;
        private readonly XElement _traits;
        private readonly XElement _relations;

        private string _crownSubType;
        private string _crownFirstType;
        private Race _race;


        private readonly List<PawnData> _pawnDatas;

        public Pawn(XElement xml)
        {
            _xml = xml;
            if (_xml.Element("name") == null)
            {
                _xml.Add(new XElement("name"));
            }
            _name = new Name(_xml.Element("name"));
            _pawnId = _xml.Element("id");
            _pawnDef = _xml.Element("def");
            _story = _xml.Element("story");
            _age = _xml.Element("ageTracker");
            _relations = _xml.XPathSelectElement("social/directRelations");
            if (!DataLoader.RaceDictionary.TryGetValue(PawnDef, out _race))
            {
                _race = null;
            }

            if (_xml.Element("gender") == null)
            {
                XElement xElement = new XElement("gender", "Male");
                _xml.Element("name").AddBeforeSelf(xElement);
            }

            if (_story.Attribute("IsNull") == null)
            {
                string headGraphicPath = HeadGraphicPath;
                if (headGraphicPath != null && headGraphicPath.Length > 0)
                {
                    string[] crownTypeStringArray = headGraphicPath.Split('/');
                    string[] splitted = crownTypeStringArray[crownTypeStringArray.Length - 1].Split('_');
                    _crownSubType = splitted[splitted.Length - 1];
                    _crownFirstType = splitted[splitted.Length - 2];
                }
            }

            Relations = new List<Relation>();
            if (_relations != null)
            {
                foreach (var relation in _relations.Elements("li"))
                {
                    Relations.Add(new Relation(relation));
                }
            }


            IEnumerable<XElement> skills = _xml.XPathSelectElements("skills/skills/li");
            Skills = new List<PawnSkill>();
            if (skills != null)
            {
                Skills = (from skill in skills
                          select new PawnSkill(skill)).ToList();
            }

            _traits = _xml.XPathSelectElement("story/traits/allTraits");
            Traits = new List<PawnTrait>();
            if (_traits != null && _traits.HasElements)
            {
                Traits = (from trait in _traits.Elements("li")
                          select new PawnTrait(trait)).ToList();
            }

            IEnumerable<XElement> hediffs = _xml.XPathSelectElements("healthTracker/hediffSet/hediffs/li");
            Hediffs = (from hediff in hediffs
                       select new PawnHealth(hediff, PawnDef)).ToList();

            XElement trainingElemnt = _xml.Element("training");
            if (trainingElemnt != null)
            {
                training = new Training(trainingElemnt, PawnDef);
            }
            else
            {
                training = null;
            }



            IEnumerable<XElement> apparels = _xml.XPathSelectElements("apparel/wornApparel/innerList/li");
            Apparel = (from apparel in apparels
                       select new PawnApparel(apparel)).ToList();
            IEnumerable<XElement> equipments = _xml.XPathSelectElements("equipment/equipment/innerList/li");
            foreach (var equipment in equipments)
            {
                Apparel.Add(new PawnApparel(equipment));
            }


            _pawnDatas = new List<PawnData>();
        }

        public void addPawnData(List<PawnData> pawnData)
        {
            _pawnDatas.AddRange(pawnData);
        }

        private void setHeadGraphicPath()
        {
            if (Race.DefName.Equals("Human"))
            {
                HeadGraphicPath = "Things/Pawn/Humanlike/Heads/" + Gender + "/" + Gender + "_" + _crownFirstType + "_" + _crownSubType;
            }
            else
            {
                if (Race.UseGenderedHeads)
                {
                    HeadGraphicPath = Race.GraphicPaths["head"] + Gender + "_" + _crownFirstType + "_" + _crownSubType;
                }
                else
                {
                    HeadGraphicPath = Race.GraphicPaths["head"] + _crownFirstType + "_" + _crownSubType;
                }
            }
        }


        public Relation AddRelation(PawnRelationDef pawnRelationDef)
        {
            Relation relation = Relation.create(_relations, pawnRelationDef);
            Relations.Add(relation);
            return relation;
        }

        public void RemoveRelation(Relation relation)
        {
            Relations.Remove(relation);
            relation.XElement.Remove();
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


        public void copyPawn()
        {
            UniqueIDsManager idManager = DataLoader.uniqueIdsManager;
            XElement copy = new XElement(_xml);

            Dictionary<string, string> idsToReplace = new Dictionary<string, string>();
            string newID = copy.Element("def").GetValue() + idManager.getNextThingID();
            string oldID = copy.Element("id").GetValue();
            copy.Element("id").SetValue(newID);

            idsToReplace.Add(oldID, newID);

            IEnumerable<XElement> apparels = copy.XPathSelectElements("apparel/wornApparel/innerList/li");
            IEnumerable<XElement> equipments = copy.XPathSelectElements("equipment/equipment/innerList/li");
            IEnumerable<XElement> inventory = copy.XPathSelectElements("inventory/innerContainer/innerList/li");
            IEnumerable<XElement> carryTracker = copy.XPathSelectElements("carryTracker/innerContainer/innerList/li");
            IEnumerable<XElement> carriedFilth = copy.XPathSelectElements("filth/carriedFilth/li");
            // RT Magic
            IEnumerable<XElement> enchantingContainer = copy.XPathSelectElements("enchantingContainer/innerList/li");

            IEnumerable<XElement> allPawnThings = apparels.Union(equipments).Union(inventory).Union(carryTracker).Union(carriedFilth).Union(enchantingContainer);

            foreach (var thing in allPawnThings)
            {
                newID = thing.Element("def").GetValue() + idManager.getNextThingID();
                oldID = thing.Element("id").GetValue();
                thing.Element("id").SetValue(newID);
                idsToReplace.Add(oldID, newID);
            }
            IEnumerable<XElement> directRelations = copy.XPathSelectElements("social/directRelations/li");
            foreach(var directRelation in directRelations)
            {
                if (DataLoader.PawnRelationDefs.TryGetValue(directRelation.Element("def").GetValue(), out var relation))
                {
                    if (relation.Reflexive)
                    {
                        directRelation.Remove();
                    }
                }
            }



            IEnumerable<XElement> hediffs = copy.XPathSelectElements("healthTracker/hediffSet/hediffs/li");
            foreach (var hediff in hediffs)
            {
                newID = "" + idManager.getNextHediffID();
                oldID = hediff.Element("loadID").GetValue();

                idsToReplace.Add("Hediff_" + oldID, "Hediff_" + newID);
                hediff.Element("loadID").SetValue(newID);
            }

            XElement jobID = copy.XPathSelectElement("jobs/curJob/loadID");
            if (jobID != null)
            {
                jobID.SetValue(idManager.getNextJobID());
            }

            XElement ownedBed = copy.XPathSelectElement("ownership/ownedBed");
            if(ownedBed != null)
            {
                ownedBed.SetValue("null");
            }

            foreach (var descendant in copy.Descendants())
            {
                if (descendant.GetValue() != null)
                {
                    foreach (var mapping in idsToReplace)
                    {
                        if (!descendant.HasElements && descendant.GetValue().Contains(mapping.Key))
                        {
                            descendant.SetValue(descendant.GetValue().Replace(mapping.Key, mapping.Value));
                        }
                    }
                }
            }

            if (DataLoader.Factions.TryGetValue(copy.Element("faction").GetValue(), out var faction))
            {
                if (DataLoader.PawnsByFactions.TryGetValue(faction, out var value))
                {
                    value.Add(new Pawn(copy));
                }
            }

            _xml.AddAfterSelf(copy);
        }

        public override string ToString()
        {
            return _name.ToString();
        }
    }
}
