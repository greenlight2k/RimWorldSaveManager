using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure.Defs
{
    public class ThingDef
    {
        private String _Name;
        private String _ParentName;
        private String _DefName;
        private String _Label;

        private String _Description;
        private int? _MaxHitPoints;
        private int? _StackLimit;
        private bool _UseHitPoints;

        private List<String> _ThingCategories = new List<string>();
        private List<String> _BodyPartGroups = new List<string>();

        private ThingDef _Parent;


        public ThingDef(XElement thing)
        {
            updateDef(thing);
        }

        public void updateDef(XElement thing)
        {
            if (thing.Attribute("ParentName") != null)
            {
                ParentName = thing.Attribute("ParentName").GetValue();
            }
            if (thing.Attribute("Name") != null)
            {
                Name = thing.Attribute("Name").GetValue();
            }
            if (thing.Element("defName") != null)
            {
                DefName = thing.Element("defName").GetValue();
            }
            if (thing.Element("label") != null)
            {
                Label = thing.Element("label").GetValue();
            }
            if (thing.Element("description") != null)
            {
                Description = thing.Element("description").GetValue();
            }

            if (thing.Element("statBases") != null && thing.Element("statBases").Element("MaxHitPoints") != null)
            {
                MaxHitPoints = Int32.Parse(thing.Element("statBases").Element("MaxHitPoints").GetValue());
            }
            if (thing.Element("stackLimit") != null)
            {
                StackLimit = Int32.Parse(thing.Element("stackLimit").GetValue());
            }
            if (thing.Element("useHitPoints") != null)
            {
                UseHitPoints = thing.Element("useHitPoints").GetValue().Equals("true");
            }
            if (thing.Element("thingCategories") != null)
            {
                foreach (var categorie in thing.Element("thingCategories").Elements("li"))
                {
                    ThingCategories.Add(categorie.GetValue());
                }
            }
            if (thing.Element("apparel") != null && thing.Element("apparel").Element("bodyPartGroups") != null)
            {
                foreach (var bodyPartGroup in thing.Element("apparel").Element("bodyPartGroups").Elements("li"))
                {
                    BodyPartGroups.Add(bodyPartGroup.GetValue());
                }
            }
        }

        public string Name {
            get{
                if (_Name != null)
                {
                    return _Name;
                }
                return _DefName;
            }
            set { _Name = value; } }
        public string ParentName { get => _ParentName; set => _ParentName = value; }
        public string DefName { get => _DefName; set => _DefName = value; }
        public string Label { get => _Label; set => _Label = value; }
        public string Description { get => _Description; set => _Description = value; }
        public int? MaxHitPoints {
            get {
                if(_MaxHitPoints == null && _Parent != null)
                {
                   return _Parent.MaxHitPoints;
                }
                return _MaxHitPoints;
            }
            set {
                _MaxHitPoints = value;
            }
        }
        public int? StackLimit { get => _StackLimit; set => _StackLimit = value; }
        public bool UseHitPoints { get => _UseHitPoints; set => _UseHitPoints = value; }
        public List<string> ThingCategories { get => _ThingCategories; set => _ThingCategories = value; }
        public List<string> BodyPartGroups { get => _BodyPartGroups; set => _BodyPartGroups = value; }
        internal ThingDef Parent { get => _Parent; set => _Parent = value; }
    }
}
