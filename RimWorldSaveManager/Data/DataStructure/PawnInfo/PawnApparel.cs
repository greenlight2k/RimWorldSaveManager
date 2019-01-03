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

        public PawnApparel(XElement xml, Dictionary<string, ThingDef> ThingDefs)
        {
            _xml = xml;
            if(ThingDefs.TryGetValue(Def, out var value))
            {
                thingDef = value;
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

        public int Health
        {
            get
            {
                return int.Parse(_xml.Element("health").GetValue());
            }
            set
            {
                _xml.Element("health").SetValue(value);
            }
        }

        public string Quality
        {
            get
            {
                return _xml.Element("quality").GetValue();
            }
            set
            {
                _xml.Element("quality").SetValue(value);
            }
        }

        public int? MaxHealth
        {
            get
            {
                if(Thing != null)
                {
                    return Thing.MaxHitPoints;
                }
                return 1;
            }
        }

        public ThingDef Thing { get => thingDef; set => thingDef = value; }

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
