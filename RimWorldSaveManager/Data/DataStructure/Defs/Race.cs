using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager.Data.DataStructure
{
   public class Race
    {
        private string _defName;
        private string _label;
        private bool _useGenderedHeads = true;
        private Dictionary<string, string> _graphicPaths = new Dictionary<string, string>();
        private List<string> _bodyType = new List<string>();
        private List<CrownType> _headType = new List<CrownType>();
        private Dictionary<string, List<Hair>> _hairsByGender = new Dictionary<string, List<Hair>>();

        public string DefName { get => _defName; set => _defName = value; }
        public string Label { get => _label; set => _label = value; }
        public bool UseGenderedHeads { get => _useGenderedHeads; set => _useGenderedHeads = value; }
        public Dictionary<string, string> GraphicPaths { get => _graphicPaths; }

        public List<string> BodyType { get => _bodyType; }
        public List<CrownType> HeadType { get => _headType;  }
        public Dictionary<string, List<Hair>> HairsByGender { get => _hairsByGender; set => _hairsByGender = value; }
    }
}
