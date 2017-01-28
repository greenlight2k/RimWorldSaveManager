using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RimWorldSaveManager
{
	public class PawnHealth
	{
		public string ParentClass;
		public string ParentName;
		public string Def;
		public string Label;
		public XElement Element;
	}

	public class Hediff
	{
		public string Class;
		public string Name;
		public Dictionary<string, PawnHealth> SubDiffs;

		public Hediff(string parentClass, string parentName)
		{
			Class = parentClass;
			Name = parentName;
			SubDiffs = new Dictionary<string, PawnHealth>();
		}
	}

	public class WorkType
	{
		public string DefName;
		public string FullName;
		public string[] WorkTags;
	}

	public class PawnSkill
	{
		public string Name;
		public int Level;
		public float Experience;
		public string Passion;
	}

	public class PawnTrait
	{
		public string Def;
		public string Degree;
		public string Label;
	}

	public class Pawn : TabPage
	{
		public string def;
		public string id;
		public string pos;
		public string faction;
		public string kindDef;
		public string first;
		public string nick;
		public string last;
		public string childhood;
		public string adulthood;
		public long ageBiologicalTicks;
		public List<PawnSkill> skills;
		public List<PawnTrait> traits;
		public List<PawnHealth> hediffs;
	}
}