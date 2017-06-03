using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class Hediff
    {
        public string Class;
        public string Name;
        public Dictionary<string, HediffDef> SubDiffs;

        public Hediff(string parentClass, string parentName)
        {
            Class = parentClass;
            Name = parentName;
            SubDiffs = new Dictionary<string, HediffDef>();
        }
    }
}
