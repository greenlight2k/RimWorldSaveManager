using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace RimWorldSaveManager
{
    public class DataLoader
    {
        private Regex decriptionCutterRegex = new Regex("(.{50}\\s)");

        public DataLoader()
        {
            //try {
            var resources = Properties
                .Resources
                .ResourceManager
                .GetResourceSet(CultureInfo.InvariantCulture, true, true);

            foreach (DictionaryEntry file in resources) {
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes((string)file.Value))) {

                    var root = XDocument.Load(stream).Root;
                    var stories = new List<PawnBackstory>();

                    if (root.Name.LocalName == "BackstoryTranslations") {
                        foreach (var story in root.Elements()) {
                            var backstory = ExtractBackstory(story);
                            backstory.Slot = "Both";
                            backstory.DescriptionKey = story.Name.LocalName;
                            backstory.DisplayTitle = backstory.Title;

                            Backstories.Add(backstory.DescriptionKey, backstory);
                            ChildhodStory.Add(backstory);
                            AdultStory.Add(backstory);
                        }
                        stream.Close();
                        stream.Dispose();
                        continue;
                    }

                    foreach (var story in root.Descendants("Backstory")) {
                        var backstory = ExtractBackstory(story);
                        if (backstory != null) {
                            stories.Add(backstory);
                        }
                    }

                    foreach (var story in root.Descendants("Childhood")) {
                        var backstory = ExtractBackstory(story);
                        if (backstory != null) {
                            backstory.Slot = "Childhood";
                            stories.Add(backstory);
                        }
                    }

                    foreach (var story in root.Descendants("Adulthood")) {
                        var backstory = ExtractBackstory(story);
                        if (backstory != null) {
                            backstory.Slot = "Adulthood";
                            stories.Add(backstory);
                        }
                    }

                    foreach (var backstory in stories) {
                        if (backstory.Title == "") continue;

                        backstory.DescriptionKey = backstory.Title.Replace(" ", "") + backstory.Description.StableStringHash();

                        var fileKey = ((string)file.Key);
                        if (fileKey == "rimworld_creations" ||
                            fileKey == "TynanCustom")
                            backstory.DisplayTitle = "(Special) " + backstory.Title;
                        else if (fileKey.Contains("Tribal"))
                            backstory.DisplayTitle = "(Tribal) " + backstory.Title;
                        else
                            backstory.DisplayTitle = backstory.Title;

                        Backstories.Add(backstory.DescriptionKey, backstory);
                        if (backstory.Slot == "Childhood") {
                            ChildhodStory.Add(backstory);
                        } else {
                            AdultStory.Add(backstory);
                        }
                    }

                    stream.Close();
                    stream.Dispose();
                }
            }

            foreach (var story in Backstories.Values) {
                if (string.IsNullOrEmpty(story.ToString())) {
                    Console.WriteLine($"Empty/null story:{story.Title}");
                }
            }

            foreach (var directory in Directory.GetDirectories("Mods")) {
                Func<string, string, string> CreateFullPath = (s1, s2)
                    => string.Join(Path.DirectorySeparatorChar.ToString(), directory, s1, s2);

                if (Directory.Exists(CreateFullPath("Defs", "TraitDefs"))) {
                    foreach (var file in Directory.GetFiles(CreateFullPath("Defs", "TraitDefs"), "*.xml")) {
                        using (var fileStream = File.OpenRead(file)) {
                            foreach (var traitDef in XDocument.Load(fileStream).Root.Elements()) {
                                var traits = (from trait in traitDef.XPathSelectElements("degreeDatas/li")
                                              select new PawnTrait {
                                                  Def = traitDef.Element("defName").Value,
                                                  Label = textInfo.ToTitleCase(trait.Element("label").Value),
                                                  Degree = trait.Element("degree") != null ? trait.Element("degree").Value : null
                                              });

                                foreach (var trait in traits)
                                    if (!Traits.ContainsKey(trait.Def + trait.Degree))
                                        Traits.Add(trait.Def + trait.Degree, trait);
                            }
                            fileStream.Close();
                        }
                    }
                }

                if (Directory.Exists(CreateFullPath("Defs", "HediffDefs"))) {
                    foreach (var file in Directory.GetFiles(CreateFullPath("Defs", "HediffDefs"), "*.xml")) {
                        using (var fileStream = File.OpenRead(file)) {
                            var docRoot = XDocument.Load(fileStream).Root;

                            var hediffRoots = docRoot.XPathSelectElements("HediffDef/hediffClass/..");

                            if (hediffRoots.Count() == 0) {
                                fileStream.Close();
                                fileStream.Dispose();
                                continue;
                            }

                            foreach (var hediffRoot in hediffRoots) {

                                var parentClass = hediffRoot.Element("hediffClass").Value;
                                var parentName = hediffRoot.Attribute("Name") != null ? hediffRoot.Attribute("Name").Value : "None";

                                Hediff coreHediff;

                                if (!Hediffs.TryGetValue(parentClass, out coreHediff))
                                    Hediffs.Add(parentClass, coreHediff = new Hediff(parentClass, parentName));

                                var hediffs = (from hediff in docRoot.XPathSelectElements("//HediffDef[boolean(@ParentName) and not(@Abstract)]")
                                               .Where(x => x.Attribute("ParentName").Value == parentName)
                                               select new PawnHealth {
                                                   ParentClass = parentClass,
                                                   ParentName = hediff.Attribute("ParentName").Value,
                                                   Def = hediff.Element("defName").Value,
                                                   Label = textInfo.ToTitleCase(hediff.Element("label").Value),
                                               });

                                foreach (var hediff in hediffs)
                                    coreHediff.SubDiffs[hediff.Def] = hediff;
                            }

                            fileStream.Close();
                            fileStream.Dispose();
                        }
                    }
                }

                if (Directory.Exists(CreateFullPath("Defs", "WorkTypeDefs"))) {
                    foreach (var file in Directory.GetFiles(CreateFullPath("Defs", "WorkTypeDefs"), "*.xml")) {
                        using (var fileStream = File.OpenRead(file)) {
                            var docRoot = XDocument.Load(fileStream).Root;
                            var workTypeDefsRoot = docRoot.XPathSelectElements("WorkTypeDef/workTags/..");

                            if (workTypeDefsRoot.Count() == 0) {
                                fileStream.Close();
                                fileStream.Dispose();
                                continue;
                            }

                            var workTypeDefs = from workTypeDef in workTypeDefsRoot
                                               select new WorkType {
                                                   DefName = workTypeDef.Element("defName").GetValue(),
                                                   FullName = workTypeDef.Element("gerundLabel").GetValue(),
                                                   WorkTags = workTypeDef.Element("workTags")
                                                       .Elements("li")
                                                       .Select(element => element.GetValue()).ToArray()
                                               };

                            WorkTypes.AddRange(workTypeDefs);
                            fileStream.Close();
                            fileStream.Dispose();
                        }
                    }
                }
            }
            /*
            } catch (Exception e) {
                MessageBox.Show("Failed loading defintion files\nReason: " + e.Message, @"RimWorld load error");
                Application.Exit();
            }
            */
        }

        private PawnBackstory ExtractBackstory(XElement xml)
        {
            if (string.IsNullOrEmpty((string)xml.Element("Title"))) {
                Console.WriteLine("Found backstory with empty Title.");
                return null;
            }
            var backstory = new PawnBackstory {
                Title = (string)xml.Element("Title"),
                TitleShort = (string)xml.Element("TitleShort"),
                Description = (string)xml.Element("BaseDesc"),
                Slot = (string)xml.Element("Slot")
            };
            if (!string.IsNullOrEmpty(backstory.Description)) {
                backstory.Description = decriptionCutterRegex.Replace(backstory.Description, "$1\n");
            }

            backstory.WorkDisables = ExtractWorkDisables(xml.Element("WorkDisables"));
            backstory.SkillGains = ExtractSkillGains(xml.Element("SkillGains"));

            return backstory;
        }

        private string[] ExtractWorkDisables(XElement xml)
        {
            if (xml == null) {
                return new string[0];
            }

            var disables = new List<string>();
            foreach (var disable in xml.Elements("li")) {
                disables.Add((string)disable);
            }
            return disables.ToArray();
        }

        private Dictionary<string, int> ExtractSkillGains(XElement xml)
        {
            var gains = new Dictionary<string, int>();
            if (xml == null) {
                return gains;
            }

            foreach (var gain in xml.Elements("li")) {
                gains[(string)gain.Element("key")] = (int)gain.Element("value");
            }
            return gains;
        }

        public bool LoadData(string path, TabControl tabControl)
        {
            tabControl.TabPages.Clear();
            Pawns.Clear();

            //try {
            SaveDocument = XDocument.Load(path);

            var playerFaction = EvaluateSingle<XElement>("scenario/playerFaction/factionDef").Value;

            var colonyFaction = "Faction_" +
                EvaluateList<XElement>("world/factionManager/allFactions/li")
                .Where(x => Evaluate<bool>(x, "def/text()='" + playerFaction + "'"))
                .First().Element("loadID").Value;

            //Console.WriteLine($"playerFaction:{playerFaction}, colonyFaction:{colonyFaction}");

            //var pawns = new List<Pawn>();
            foreach (var pawn in SaveDocument.Descendants("thing")) {
                if ((string)pawn.Attribute("Class") == "Pawn"
                    && (string)pawn.Element("def") == "Human"
                    && (string)pawn.Element("faction") == colonyFaction) {

                    var p = new Pawn {
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
                                  select new PawnSkill {
                                      Name = skill.Element("def").GetValue(),
                                      Level = skill.Element("level").GetValue(-1),
                                      Experience = skill.Element("xpSinceLastLevel").GetValue(-1f),
                                      Passion = skill.Element("passion").GetValue(),
                                  }).ToList(),
                        traits = (from trait in pawn.XPathSelectElements("story/traits/allTraits/li")
                                  select new PawnTrait {
                                      Def = trait.Element("def").GetValue(),
                                      Degree = trait.Element("degree").GetValue(),
                                      Label = null
                                  }).ToList(),
                        hediffs = (from hediff in pawn.XPathSelectElements("healthTracker/hediffSet/hediffs/li")
                                   select new PawnHealth {
                                       ParentClass = hediff.Attribute("Class").GetValue(),
                                       Def = hediff.Element("def").GetValue(),
                                       Element = hediff
                                   }).ToList(),
                    };
                    p.Text = p.first + (p.nick == p.last ? " " : (" \"" + p.nick + "\" ")) + p.last;
                    p.Controls.Add(new PawnPage(p));
                    Pawns.Add(p);

                    //pawns.Add(p);
                }
            }

            if (Pawns.Count == 0) {
                throw new Exception("No characters found!\nTry playing the game a little more.");
            }

            /*
            foreach (var pawn in pawns) {
                pawn.Text = pawn.first + (pawn.nick == pawn.last ? " " : (" \"" + pawn.nick + "\" ")) + pawn.last;
                pawn.Controls.Add(new PawnPage(pawn));
                Pawns.Add(pawn);
            }
            */

            tabControl.TabPages.AddRange(Pawns.ToArray());
            /*
            } catch (Exception e) {
                MessageBox.Show($"Failed loading RimWorld Save File\nReason: {e.Message}", @"RimWorld load error");
                tabControl.TabPages.Clear();
                Pawns.Clear();
                return false;
            }
            */
            return true;
        }

        public bool SaveData(string path)
        {
            //try {
            foreach (var pawn in Pawns) {
                var pawnPage = pawn.Controls[0] as PawnPage;

                /*
                var pawnElement = EvaluateList<XElement>("map/things/thing[@Class='Pawn']")
                        .Where(x => x.Element("id").Value == pawn.id)
                        .Single();
                        */
                var pawnElement = SaveDocument
                        .Descendants("thing")
                        .Single(x => (string)x.Element("id") == pawn.id);

                var story = pawnElement.Element("story");

                var node = story.Element("childhood");
                if (!string.IsNullOrEmpty(pawn.childhood)) {
                    if (node == null) {
                        node = new XElement("childhood");
                        story.Add(node);
                    }
                    node.Value = pawn.childhood;
                } else {
                    node.Remove();
                }

                node = story.Element("adulthood");
                if (!string.IsNullOrEmpty(pawn.adulthood)) {
                    if (node == null) {
                        node = new XElement("adulthood");
                        story.Add(node);
                    }
                    node.Value = pawn.adulthood;
                } else {
                    node.Remove();
                }

                foreach (var skill in pawn.skills) {
                    /*
                    var skillElement = pawnElement.XPathSelectElements("skills/skills/li")
                        .Where(s => s.Element("def").Value == skill.Name)
                        .Single();
                        */
                    var skillElement = pawnElement.Element("skills")
                            .Element("skills").Elements("li")
                            .Single(x => (string)x.Element("def") == skill.Name);

                    var skillLevel = pawnPage.Skills[skill.Name].Text;
                    skill.Passion = pawnPage.Passions[skill.Name].Text == "None" ? null : pawnPage.Passions[skill.Name].Text;

                    var levelElement = skillElement.Element("level");
                    var passionElement = skillElement.Element("passion");

                    if (skillLevel == "-") {
                        if (levelElement != null) {
                            levelElement.Remove();
                        }
                    } else {
                        if (levelElement == null) {
                            levelElement = new XElement("level");
                            skillElement.Add(levelElement);
                        }
                        levelElement.Value = skillLevel;
                    }

                    if (skill.Passion == null) {
                        if (passionElement != null) {
                            passionElement.Remove();
                        }
                    } else {
                        if (passionElement == null) {
                            passionElement = new XElement("passion");
                            skillElement.Add(passionElement);
                        }
                        passionElement.Value = skill.Passion;
                    }
                }

                var traitElement = pawnElement.XPathSelectElement("story/traits/allTraits");
                traitElement.RemoveAll();

                foreach (var item in pawnPage.listBox1.Items) {
                    var newTraitElement = new XElement("li");
                    var trait = Traits.Where(x => x.Value.Label == (string)item).Single().Value;

                    newTraitElement.Add(new XElement("def", trait.Def));

                    if (trait.Degree != null)
                        newTraitElement.Add(new XElement("degree", trait.Degree));

                    traitElement.Add(newTraitElement);
                }

                var hediffElement = pawnElement.XPathSelectElement("healthTracker/hediffSet/hediffs");
                hediffElement.RemoveAll();

                foreach (var hediff in pawn.hediffs) {
                    hediffElement.Add(hediff.Element);
                }

                pawnElement.XPathSelectElement("ageTracker/ageBiologicalTicks")
                    .Value = ((long)(pawnPage.BiologicalAgeBox.Value * 3600000L)).ToString();
            }

            SaveDocument.Save(path);

            MessageBox.Show("Successfully saved changes!");
            /*
            } catch (Exception e) {
                MessageBox.Show("Failed saving RimWorld Save File\nReason: " + e.Message, @"RimWorld save error");
                return false;
            }
            */
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
        public static List<PawnBackstory> ChildhodStory = new List<PawnBackstory>();
        public static List<PawnBackstory> AdultStory = new List<PawnBackstory>();
    }
}
