using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Globalization;
using System.Resources;
using System.Text;

namespace RimWorldSaveManager
{
	public class DataLoader
	{
		public DataLoader()
		{
			try
			{
				var resources = Properties
					.Resources
					.ResourceManager
					.GetResourceSet(CultureInfo.InvariantCulture, true, true);

				foreach (DictionaryEntry file in resources)
				{
					var stream = new MemoryStream(Encoding.UTF8.GetBytes((string)file.Value));

					var root = XDocument.Load(stream).Root;

					var backstories = (from backstory in root.Elements("Backstory")
									   select new PawnBackstory
									   {
										   Title = backstory.Element("Title").GetValue().ToTitleCase(),
										   TitleShort = backstory.Element("TitleShort").GetValue(),
										   Description = backstory.Element("BaseDesc").GetValue().Replace("\\n", "\n"),
										   Slot = backstory.Element("Slot").GetValue(),
									   }).Union((from pawn in root.Elements("PawnBio")
												 select new PawnBackstory
												 {
													 Title = pawn.XPathSelectElement("Childhood/Title").GetValue().ToTitleCase(),
													 TitleShort = pawn.XPathSelectElement("Childhood/TitleShort").GetValue(),
													 Description = pawn.XPathSelectElement("Childhood/BaseDesc").GetValue().Replace("\\n", "\n"),
													 Slot = "Childhood",
												 })).Union((from pawn in root.Elements("PawnBio")
															select new PawnBackstory
															{
																Title = pawn.XPathSelectElement("Adulthood/Title").GetValue().ToTitleCase(),
																TitleShort = pawn.XPathSelectElement("Adulthood/TitleShort").GetValue(),
																Description = pawn.XPathSelectElement("Adulthood/BaseDesc").GetValue().Replace("\\n", "\n"),
																Slot = "Adulthood",
															}));

					foreach (var backstory in backstories)
					{
						if (backstory.Title == "") continue;

						var backstoryKey = backstory.Title.Replace(" ", "") + backstory.Description.StableStringHash();
						var fileKey = ((string)file.Key);

						if (fileKey == "rimworld_creations" ||
							fileKey == "TynanCustom")
							backstory.DisplayTitle = "(Special) " + backstory.Title;
						else if (fileKey.Contains("Tribal"))
							backstory.DisplayTitle = "(Tribal) " + backstory.Title;
						else
							backstory.DisplayTitle = backstory.Title;

						Backstories.Add(backstoryKey, backstory);
					}
				}

				foreach (var directory in Directory.GetDirectories("Mods"))
				{
					Func<string, string, string> CreateFullPath = (s1, s2)
						=> string.Join(Path.DirectorySeparatorChar.ToString(), directory, s1, s2);

					if (Directory.Exists(CreateFullPath("Defs", "TraitDefs")))
						foreach (var file in Directory.GetFiles(CreateFullPath("Defs", "TraitDefs"), "*.xml"))
						{
							foreach (var traitDef in XDocument.Load(file).Root.Elements())
							{
								var traits = (from trait in traitDef.XPathSelectElements("degreeDatas/li")
											  select new PawnTrait
											  {
												  Def = traitDef.Element("defName").Value,
												  Label = textInfo.ToTitleCase(trait.Element("label").Value),
												  Degree = trait.Element("degree") != null ? trait.Element("degree").Value : null
											  });

								foreach (var trait in traits)
									if (!Traits.ContainsKey(trait.Def + trait.Degree))
										Traits.Add(trait.Def + trait.Degree, trait);
							}
						}

					if (Directory.Exists(CreateFullPath("Defs", "HediffDefs")))
						foreach (var file in Directory.GetFiles(CreateFullPath("Defs", "HediffDefs"), "*.xml"))
						{
							var docRoot = XDocument.Load(file).Root;

							var hediffRoots = docRoot.XPathSelectElements("HediffDef/hediffClass/..");

							if (hediffRoots.Count() == 0) continue;

							foreach (var hediffRoot in hediffRoots)
							{

								var parentClass = hediffRoot.Element("hediffClass").Value;
								var parentName = hediffRoot.Attribute("Name") != null ? hediffRoot.Attribute("Name").Value : "None";

								Hediff coreHediff;

								if (!Hediffs.TryGetValue(parentClass, out coreHediff))
									Hediffs.Add(parentClass, coreHediff = new Hediff(parentClass, parentName));

								var hediffs = (from hediff in docRoot.XPathSelectElements("//HediffDef[boolean(@ParentName) and not(@Abstract)]")
											   .Where(x => x.Attribute("ParentName").Value == parentName)
											   select new PawnHealth
											   {
												   ParentClass = parentClass,
												   ParentName = hediff.Attribute("ParentName").Value,
												   Def = hediff.Element("defName").Value,
												   Label = textInfo.ToTitleCase(hediff.Element("label").Value),
											   });

								foreach (var hediff in hediffs)
									coreHediff.SubDiffs[hediff.Def] = hediff;
							}
						}

					if (Directory.Exists(CreateFullPath("Defs", "WorkTypeDefs")))
						foreach (var file in Directory.GetFiles(CreateFullPath("Defs", "WorkTypeDefs"), "*.xml"))
						{
							var docRoot = XDocument.Load(file).Root;

							var workTypeDefsRoot = docRoot.XPathSelectElements("WorkTypeDef/workTags/..");

							if (workTypeDefsRoot.Count() == 0) continue;

							var workTypeDefs = from workTypeDef in workTypeDefsRoot
											select new WorkType
											{
												DefName = workTypeDef.Element("defName").GetValue(),
												FullName = workTypeDef.Element("gerundLabel").GetValue(),
												WorkTags = workTypeDef.Element("workTags")
													.Elements("li")
													.Select(element => element.GetValue()).ToArray()
											};

							WorkTypes = workTypeDefs.ToList();
						}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Failed loading defintion files\nReason: " + e.Message, @"RimWorld load error");
				Application.Exit();
			}

		}

		public bool LoadData(string path, TabControl tabControl)
		{
			tabControl.TabPages.Clear();
			Pawns.Clear();

			try
			{
				SaveDocument = XDocument.Load(path);

				var playerFaction = EvaluateSingle<XElement>("scenario/playerFaction/factionDef").Value;

				var colonyFaction = "Faction_" +
					EvaluateList<XElement>("world/factionManager/allFactions/li")
					.Where(x => Evaluate<bool>(x, "def/text()='" + playerFaction + "'"))
					.First().Element("loadID").Value;

				var pawns = (from pawn in EvaluateList<XElement>("map/things/thing[@Class='Pawn']")
							 .Where(x => Evaluate<bool>(x, "def/text()='Human'")
								&& x.Element("faction") != null
								&& x.Element("faction").Value == colonyFaction)
							 select new Pawn
							 {
								 def = pawn.Element("def").GetValue(),
								 id = pawn.Element("id").GetValue(),
								 pos = pawn.Element("pos").GetValue(),
								 faction = pawn.Element("faction").GetValue(),
								 kindDef = pawn.Element("kindDef").GetValue(),
								 first = pawn.XPathSelectElement("name/first").GetValue(),
								 nick = pawn.XPathSelectElement("name/nick").GetValue(),
								 last = pawn.XPathSelectElement("name/last").GetValue(),
								 childhood = pawn.XPathSelectElement("story/childhood").GetValue(),
								 adulthood = pawn.XPathSelectElement("story/adulthood").GetValue(),
								 ageBiologicalTicks = pawn.XPathSelectElement("ageTracker/ageBiologicalTicks").GetValue(0L),
								 skills = (from skill in pawn.XPathSelectElements("skills/skills/li")
										   select new PawnSkill
										   {
											   Name = skill.Element("def").GetValue(),
											   Level = skill.Element("level").GetValue(-1),
											   Experience = skill.Element("xpSinceLastLevel").GetValue(-1f),
											   Passion = skill.Element("passion").GetValue(),
										   }).ToList(),
								 traits = (from trait in pawn.XPathSelectElements("story/traits/allTraits/li")
										   select new PawnTrait
										   {
											   Def = trait.Element("def").GetValue(),
											   Degree = trait.Element("degree").GetValue(),
											   Label = null
										   }).ToList(),
								 hediffs = (from hediff in pawn.XPathSelectElements("healthTracker/hediffSet/hediffs/li")
											select new PawnHealth
											{
												ParentClass = hediff.Attribute("Class").GetValue(),
												Def = hediff.Element("def").GetValue(),
												Element = hediff
											}).ToList(),
							 }).ToList();

				if (pawns.Count == 0)
					throw new Exception("No characters found!\nTry playing the game a little more.");

				foreach (var pawn in pawns)
				{
					pawn.Text = pawn.first + (pawn.nick == pawn.last ? " " : (" \"" + pawn.nick + "\" ")) + pawn.last;
					pawn.Controls.Add(new PawnPage(pawn));
					Pawns.Add(pawn);
				}

				tabControl.TabPages.AddRange(Pawns.ToArray());
			}
			catch (Exception e)
			{
				MessageBox.Show("Failed loading RimWorld Save File\nReason: " + e.Message, @"RimWorld load error");
				tabControl.TabPages.Clear();
				Pawns.Clear();
				return false;
			}
			return true;
		}

		public bool SaveData(string path)
		{
			try
			{
				foreach (var pawn in Pawns)
				{
					var pawnPage = pawn.Controls[0] as PawnPage;

					var pawnElement = EvaluateList<XElement>("map/things/thing[@Class='Pawn']")
							.Where(x => x.Element("id").Value == pawn.id)
							.Single();

					pawnElement
						.XPathSelectElement("story/childhood").Value = pawn.childhood;

					pawnElement
						.XPathSelectElement("story/adulthood").Value = pawn.adulthood;

					foreach (var skill in pawn.skills)
					{
						var skillElement = pawnElement.XPathSelectElements("skills/skills/li")
							.Where(s => s.Element("def").Value == skill.Name)
							.Single();

						var skillLevel = pawnPage.Skills[skill.Name].Text;
						skill.Passion = pawnPage.Passions[skill.Name].Text == "None" ? null : pawnPage.Passions[skill.Name].Text;

						if (skillLevel != "-"
							&& skillElement.Element("level") != null)
						{
							skillElement.Element("level").Value = skillLevel;
							if (skillElement.Element("passion") != null)
								if (skill.Passion != null)
									skillElement.Element("passion").Value = skill.Passion;
								else
									skillElement.Element("passion").Remove();
							else if (skill.Passion != null)
								skillElement.Add(new XElement("passion", skill.Passion));
						}
					}

					var traitElement = pawnElement.XPathSelectElement("story/traits/allTraits");
					traitElement.RemoveAll();

					foreach (var item in pawnPage.listBox1.Items)
					{
						var newTraitElement = new XElement("li");
						var trait = Traits.Where(x => x.Value.Label == (string)item).Single().Value;

						newTraitElement.Add(new XElement("def", trait.Def));

						if (trait.Degree != null)
							newTraitElement.Add(new XElement("degree", trait.Degree));

						traitElement.Add(newTraitElement);
					}

					var hediffElement = pawnElement.XPathSelectElement("healthTracker/hediffSet/hediffs");
					hediffElement.RemoveAll();

					foreach (var hediff in pawn.hediffs)
					{
						hediffElement.Add(hediff.Element);
					}

					pawnElement.XPathSelectElement("ageTracker/ageBiologicalTicks")
						.Value = ((long)(pawnPage.BiologicalAgeBox.Value * 3600000L)).ToString();
				}

				SaveDocument.Save(path);

				MessageBox.Show("Successfully saved changes!");
			}
			catch (Exception e)
			{
				MessageBox.Show("Failed saving RimWorld Save File\nReason: " + e.Message, @"RimWorld save error");
				return false;
			}
			return true;
		}

		private IEnumerable<T> EvaluateList<T>(string eval)
		{
			return (SaveDocument.Root.Element("game").XPathEvaluate(eval) as IEnumerable).Cast<T>();
		}

		private T EvaluateSingle<T>(string eval)
		{
			return (SaveDocument.Root.Element("game").XPathEvaluate(eval) as IEnumerable).Cast<T>().First();
		}

		private T Evaluate<T>(string eval)
		{
			return (T)SaveDocument.Root.Element("game").XPathEvaluate(eval);
		}

		private IEnumerable<T> EvaluateList<T>(XNode node, string eval)
		{
			return (node.XPathEvaluate(eval) as IEnumerable).Cast<T>();
		}

		private T EvaluateSingle<T>(XNode node, string eval)
		{
			return (node.XPathEvaluate(eval) as IEnumerable).Cast<T>().First();
		}

		private T Evaluate<T>(XNode node, string eval)
		{
			return (T)node.XPathEvaluate(eval);
		}

		private XDocument SaveDocument;
		private List<Pawn> Pawns = new List<Pawn>();
		private TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;

		public static Dictionary<string, PawnTrait> Traits = new Dictionary<string, PawnTrait>();
		public static Dictionary<string, Hediff> Hediffs = new Dictionary<string, Hediff>();
		public static Dictionary<string, PawnBackstory> Backstories = new Dictionary<string, PawnBackstory>();
		public static List<WorkType> WorkTypes = new List<WorkType>();
	}
}
