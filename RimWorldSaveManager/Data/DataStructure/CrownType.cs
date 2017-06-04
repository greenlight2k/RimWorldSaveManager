using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class CrownType
    {
        private string _crownFirstType;
        private string _crownSubType;

        public string CrownSubType { get => _crownSubType; set => _crownSubType = value; }
        public string CrownFirstType { get => _crownFirstType; set => _crownFirstType = value; }

        public string CombinedCrownLabel
        {
            get => _crownFirstType + " " + _crownSubType;
        }

        public string CombinedCrownDef
        {
            get => _crownFirstType + "_" + _crownSubType;
        }

        public override string ToString()
        {
            return CombinedCrownLabel;
        }
    }
}
