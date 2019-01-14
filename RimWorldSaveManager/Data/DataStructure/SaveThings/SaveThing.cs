using RimWorldSaveManager.Data.DataStructure.Defs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RimWorldSaveManager.Data.DataStructure.SaveThings
{
    public class SaveThing
    {
        private XElement _XElement;
        private ThingDef _BaseThing = null;
        private ThingDef _StuffBaseThing = null;
        private SaveThing _MinifiedThing = null;

        public SaveThing(XElement xElement)
        {
            _XElement = xElement;
            if(DataLoader.ThingDefsByDefName.TryGetValue(Def, out var baseThingDef))
            {
                BaseThing = baseThingDef;
            }
            if (Stuff != null && DataLoader.ThingDefsByDefName.TryGetValue(Stuff, out var stuffThingDef))
            {
                StuffBaseThing = stuffThingDef;
            }
            if(Class == "MinifiedThing")
            {
                if(_XElement.XPathSelectElement("innerContainer/innerList/li") != null)
                {
                    _MinifiedThing = new SaveThing(_XElement.XPathSelectElement("innerContainer/innerList/li"));
                }
            }
        }

        public void Delete()
        {
            _XElement.Remove();
        }

        public string Class
        {
            get { return _XElement.Attribute("Class").GetValue(); }
            set { _XElement.Attribute("Class").SetValue(value); }
        }

        public string Def
        {
            get { return _XElement.Element("def").GetValue(); }
            set { _XElement.Element("def").SetValue(value); }
        }

        public string Id
        {
            get { return _XElement.Element("id").GetValue(); }
            set { _XElement.Element("id").SetValue(value); }
        }

        public string Pos
        {
            get { return _XElement.Element("pos").GetValue(); }
            set { _XElement.Element("pos").SetValue(value); }
        }
        public string Map
        {
            get { return _XElement.Element("map").GetValue(); }
            set { _XElement.Element("map").SetValue(value); }
        }

        public string Faction
        {
            get {
                if(_XElement.Element("faction") != null)
                {
                    return _XElement.Element("faction").GetValue();
                }
                return null;
            }
            set {
                if (_XElement.Element("faction") != null)
                {
                    _XElement.Element("faction").SetValue(value);
                }
            }
        }

        public string Stuff
        {
            get
            {
                if (_XElement.Element("stuff") != null)
                {
                    return _XElement.Element("stuff").GetValue();
                }
                return null;
            }
            set
            {
                if (_XElement.Element("stuff") != null)
                {
                    _XElement.Element("stuff").SetValue(value);
                }
            }
        }

        public string Quality
        {
            get
            {
                if (_XElement.Element("quality") != null)
                {
                    return _XElement.Element("quality").GetValue();
                }if(BaseThing != null && BaseThing.UseQuality)
                {
                    return "Awful";
                }
                return null;
            }
            set
            {
                if (_XElement.Element("quality") != null)
                {
                    _XElement.Element("quality").SetValue(value);
                }
                if (BaseThing != null && BaseThing.UseQuality)
                {
                    _XElement.Add(new XElement("quality", value));
                }
            }
        }

        public int? Health
        {
            get
            {
                if (_XElement.Element("health") != null && int.TryParse(_XElement.Element("health").GetValue(), out var result))
                {
                    return result;
                }
                return null;
            }
            set
            {
                if (_XElement.Element("health") != null)
                {
                    _XElement.Element("health").SetValue(value);
                }
            }
        }

        public int? StackCount
        {
            get
            {
                if (_XElement.Element("stackCount") != null && int.TryParse(_XElement.Element("stackCount").GetValue(), out var result))
                {
                    return result;
                }
                return null;
            }
            set
            {
                if (_XElement.Element("stackCount") != null)
                {
                    _XElement.Element("stackCount").SetValue(value);
                }
            }
        }

        public decimal? Growth
        {
            get
            {

                if (_XElement.Element("growth") != null)
                {
                    if (decimal.TryParse(_XElement.Element("growth").GetValue(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal tmp))
                    {
                        return tmp;
                    }
                }
                return null;
            }
            set
            {
                if (_XElement.Element("growth") != null)
                {
                    _XElement.Element("growth").SetValue(value);
                }
            }
        }

        public decimal? WorkLeft
        {
            get
            {

                if (_XElement.Element("workLeft") != null)
                {
                    if (decimal.TryParse(_XElement.Element("workLeft").GetValue(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal tmp))
                    {
                        return tmp;
                    }
                }
                return null;
            }
            set
            {
                if (_XElement.Element("workLeft") != null)
                {
                    _XElement.Element("workLeft").SetValue(value);
                }
            }
        }

        public int? MaxHealth
        {
            get
            {
                if (BaseThing != null && BaseThing.MaxHitPoints != null)
                {
                    if (StuffBaseThing != null && StuffBaseThing.MaxHitPointFactor != null)
                    {
                        return (int)Math.Round((decimal)BaseThing.MaxHitPoints * (decimal)StuffBaseThing.MaxHitPointFactor, 0);
                    }
                    return BaseThing.MaxHitPoints;
                }
                if(Health != null)
                {
                    if (Def.ToLower().Contains("meat"))
                    {
                        return (int)(60 * DataLoader.MaxHitPointsMultiplikator);
                    }
                    return Health;
                }
                return 1;
            }
        }

        public bool WornByCorpse
        {
            get
            {
                if (_XElement.Element("wornByCorpse") != null)
                {
                    return bool.Parse(_XElement.Element("wornByCorpse").GetValue());
                }
                return false;
            }
            set
            {
                if(Class == "Apparel" || Class == "")
                {
                    if (_XElement.Element("wornByCorpse") != null && !value)
                    {
                        _XElement.Element("wornByCorpse").Remove();
                    }
                    if (_XElement.Element("wornByCorpse") == null && value)
                    {
                        _XElement.Add(new XElement("wornByCorpse", "true"));
                    }
                }
            }
        }

        public int? StackLimit
        {
            get
            {
                if (BaseThing != null && BaseThing.StackLimit > 1)
                {
                    return (int)(BaseThing.StackLimit * DataLoader.MaxStackCountMultiplikator);
                }
                if(BaseThing == null && Def.ToLower().Contains("meat"))
                {
                    return (int)(75 * DataLoader.MaxStackCountMultiplikator);
                }
                return 1;
            }
        }

        public ThingDef StuffBaseThing { get => _StuffBaseThing; set => _StuffBaseThing = value; }
        public ThingDef BaseThing { get => _BaseThing; set => _BaseThing = value; }
        public SaveThing MinifiedThing { get => _MinifiedThing; set => _MinifiedThing = value; }
        public ThingDef BaseThing1 { get => _BaseThing; set => _BaseThing = value; }



        public override string ToString()
        {
            String ofTheJedi;
            if (BaseThing != null)
            {
                ofTheJedi= BaseThing.Label;
            }
            else {
                ofTheJedi = Def;
            }
            if(MinifiedThing != null)
            {
                ofTheJedi = ofTheJedi + " - " + MinifiedThing.ToString();
            }
            return ofTheJedi + (WornByCorpse ? " - T" : "");
        }
    }
}