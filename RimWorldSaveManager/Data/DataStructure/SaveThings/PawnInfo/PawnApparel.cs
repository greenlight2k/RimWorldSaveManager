using RimWorldSaveManager.Data.DataStructure.Defs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure.PawnInfo
{
    public class PawnApparel
    {

        private XElement _xml;
        private ThingDef thingDef;
        private ThingDef stuffThingDef;

        public PawnApparel(XElement xml, Dictionary<string, ThingDef> ThingDefs)
        {
            _xml = xml;
            if(ThingDefs.TryGetValue(Def, out var value))
            {
                thingDef = value;
            }
            if(Stuff != null)
            {
                if (ThingDefs.TryGetValue(Stuff, out value))
                {
                    StuffThingDef = value;
                }
            }
        }
        public string Def
        {
            get
            {
                return _xml.Element("def").GetValue();
            }
            set
            {
               // _xml.Element("def").SetValue(value);
            }
        }

        public int? Health
        {
            get
            {
                if(_xml.Element("health") != null)
                {
                    return int.Parse(_xml.Element("health").GetValue());
                }
                return null;
            }
            set
            {
                if(_xml.Element("health") != null)
                {
                    _xml.Element("health").SetValue(value);
                }
            }
        }

        public string Quality
        {
            get
            {
                if(_xml.Element("quality") != null)
                {
                    return _xml.Element("quality").GetValue();
                }
                return null;
            }
            set
            {
                if (_xml.Element("quality") != null)
                {
                    _xml.Element("quality").SetValue(value);
                }
            }
        }

        public string Stuff
        {
            get
            {
                return _xml.Element("stuff").GetValue();
            }
            set
            {
                _xml.Element("stuff").SetValue(value);
            }
        }

        public string Id
        {
            get
            {
                return _xml.Element("id").GetValue();
            }
            set
            {
                _xml.Element("id").SetValue(value);
            }
        }

        public int? MaxHealth
        {
            get
            {
                if(Thing != null)
                {
                    if(StuffThingDef != null && StuffThingDef.MaxHitPointFactor != null)
                    {
                        return (int)(Thing.MaxHitPoints * StuffThingDef.MaxHitPointFactor);
                    }
                    return Thing.MaxHitPoints;
                }
                if (Health != null)
                {
                    return Health;
                }
                return 1;
            }
        }

        public ThingDef Thing { get => thingDef; set => thingDef = value; }
        public ThingDef StuffThingDef { get => stuffThingDef; set => stuffThingDef = value; }

        public override string ToString() { 
            if(Thing != null){
                if(Thing.Label != null)
                {
                    return Thing.Label;
                }
                return Thing.DefName;
            }
            return Def;
        }
    }
}
