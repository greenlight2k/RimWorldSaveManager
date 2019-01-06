using RimWorldSaveManager.Data.DataStructure.Defs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure.SaveThings
{
    public class SaveThing
    {
        private XElement _XElement;
        private ThingDef _BaseThing = null;
        private ThingDef _StuffBaseThing = null;

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
                }
                return null;
            }
            set
            {
                if (_XElement.Element("quality") != null)
                {
                    _XElement.Element("quality").SetValue(value);
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
                if (BaseThing != null)
                {
                    if(BaseThing.MaxHitPoints > 1 && DataLoader.IgnoreMaxHitPoints)
                    {
                        return int.MaxValue;
                    }
                    if (StuffBaseThing != null && StuffBaseThing.MaxHitPointFactor != null)
                    {
                        return (int)(BaseThing.MaxHitPoints * StuffBaseThing.MaxHitPointFactor);
                    }
                    return BaseThing.MaxHitPoints;
                }
                if(Health != null)
                {
                    return Health;
                }
                return 1;
            }
        }

        public int? StackLimit
        {
            get
            {
                if (BaseThing != null)
                {
                    return BaseThing.StackLimit;
                }
                return 1;
            }
        }

        public ThingDef StuffBaseThing { get => _StuffBaseThing; set => _StuffBaseThing = value; }
        public ThingDef BaseThing { get => _BaseThing; set => _BaseThing = value; }

        public override string ToString()
        {
            if (BaseThing != null)
            {
                return BaseThing.Label;
            }
            return Def;
        }
    }
}