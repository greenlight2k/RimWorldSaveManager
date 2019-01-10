using System;
using System.Collections.Generic;
using System.Globalization;
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
        private decimal? _MaxHitPointFactor;
        private bool _UseHitPoints;

        private List<String> _StuffPropsCategories = new List<string>();
        private List<String> _ReciepStuffCategories = new List<string>();
        private List<String> _ThingCategories = new List<string>();
        private List<String> _BodyPartGroups = new List<string>();

        private ThingDef _Parent;

        private List<string> _FileNames = new List<string>();


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
                    _ThingCategories.Add(categorie.GetValue());
                }
            }
            if (thing.Element("stuffCategories") != null)
            {
                foreach (var categorie in thing.Element("stuffCategories").Elements("li"))
                {
                    _ReciepStuffCategories.Add(categorie.GetValue());
                }
            }
            if (thing.Element("stuffProps") != null)
            {
                XElement stuffProps = thing.Element("stuffProps");

                if (stuffProps.Element("statFactors") != null && stuffProps.Element("statFactors").Element("MaxHitPoints") != null)
                {
                    if (decimal.TryParse(thing.Element("stuffProps").Element("statFactors").Element("MaxHitPoints").GetValue(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal tmp))
                    {
                        _MaxHitPointFactor = tmp;
                    }
                }

                if (stuffProps.Element("categories") != null)
                {
                    foreach(var categorie in stuffProps.Element("categories").Elements("li"))
                    {
                        _StuffPropsCategories.Add(categorie.GetValue());
                    }
                }
            }

            if (thing.Element("apparel") != null && thing.Element("apparel").Element("bodyPartGroups") != null)
            {
                foreach (var bodyPartGroup in thing.Element("apparel").Element("bodyPartGroups").Elements("li"))
                {
                    BodyPartGroups.Add(bodyPartGroup.GetValue());
                }
            }
            _FileNames.Add(DataLoader.CurrentDocumentPath);
        }

        public string Name
        {
            get
            {
                if (_Name != null)
                {
                    return _Name;
                }
                return _DefName;
            }
            set { _Name = value; }
        }
        public string ParentName { get => _ParentName; set => _ParentName = value; }

        public string BaseName
        {
            get
            {
                if(Parent != null)
                {
                    return Parent.BaseName;
                }
                return Name;
            }
        }

        public string DefName { get => _DefName; set => _DefName = value; }
        public string Label { get => _Label; set => _Label = value; }
        public string Description { get => _Description; set => _Description = value; }
        public int? MaxHitPoints
        {
            get
            {
                if (_MaxHitPoints == null && _Parent != null)
                {
                    return _Parent.MaxHitPoints;
                }
                return _MaxHitPoints;
            }
            set
            {
                _MaxHitPoints = value;
            }
        }


        public int? StackLimit
        {
            get
            {
                if (_StackLimit == null )
                {
                    if(_Parent != null)
                    {
                        return _Parent.StackLimit;
                    }
                    else
                    {
                        return 1; // Items that have no StackLimit set are not stackable
                    }
                }
                return _StackLimit;
            }
            set
            {
                _StackLimit = value;
            }
        }

        public decimal? MaxHitPointFactor
        {
            get
            {
                if(_MaxHitPointFactor == null && Parent != null)
                {
                    return Parent.MaxHitPointFactor;
                }

                return _MaxHitPointFactor;
            }
            set
            {
                _MaxHitPointFactor = value;
            }
        }

        public bool UseHitPoints { get => _UseHitPoints; set => _UseHitPoints = value; }
        public List<string> BodyPartGroups { get => _BodyPartGroups; set => _BodyPartGroups = value; }

        public List<string> ThingCategories
        {
            get
            {
                if (_ThingCategories.Count == 0 && _Parent != null)
                {
                    return _Parent.ThingCategories;
                }
                return _ThingCategories;
            }
        }
        public List<string> StuffPropsCategories
        {
            get
            {
                if (_StuffPropsCategories.Count == 0 && _Parent != null)
                {
                    return _Parent.StuffPropsCategories;
                }
                return _StuffPropsCategories;
            }
        }

        public List<string> ReciepStuffCategories
        {
            get
            {
                if (_ReciepStuffCategories.Count == 0 && _Parent != null)
                {
                    return _Parent.ReciepStuffCategories;
                }
                return _ReciepStuffCategories;
            }
        }

        internal ThingDef Parent { get => _Parent; set => _Parent = value; }

        public override string ToString()
        {
            if (_Label != null)
            {
                return _Label;
            }
            if (_Name != null)
            {
                return _Name;
            }
            return _DefName;
        }
    }
}
