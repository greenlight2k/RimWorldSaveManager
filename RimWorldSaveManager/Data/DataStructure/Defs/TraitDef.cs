using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimWorldSaveManager.Data.DataStructure
{
    public class TraitDef
    {
        public string Def;
        public string Degree;
        public string Label;
        public string Description;

        public override string ToString()
        {
            return Label;
        }
    }
}
