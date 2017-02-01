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


        public DataLoader()
        {
            BackstoryDatabase.Load();

            //try {
            foreach (var directory in Directory.GetDirectories("Mods")) {
                Func<string, string, string> CreateFullPath = (s1, s2)
                    => string.Join(Path.DirectorySeparatorChar.ToString(), directory, s1, s2);

                if (Directory.Exists(CreateFullPath("Defs", "TraitDefs"))) {
                    foreach (var file in Directory.GetFiles(CreateFullPath("Defs", "TraitDefs"), "*.xml")) {
                        using (var fileStream = File.OpenRead(file)) {
                            foreach (var traitDef in XDocument.Load(fileStream).Root.Elements()) {
                                var traits = (from trait in traitDef.XPathSelectElements("degreeDatas/li")
                                              select new TraitDef {
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
                                               select new HediffDef {
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

            foreach (var pawn in SaveDocument.Descendants("thing")) {
                if ((string)pawn.Attribute("Class") == "Pawn"
                    && (string)pawn.Element("def") == "Human"
                    && (string)pawn.Element("faction") == colonyFaction) {
                    var p = new Pawn(pawn);
                    p.Controls.Add(new PawnPage(p));
                    Pawns.Add(p);
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
            /*
            foreach (var pawn in Pawns) {
                var pawnPage = pawn.Controls[0] as PawnPage;

                var pawnElement = SaveDocument
                        .Descendants("thing")
                        .Single(x => (string)x.Element("id") == pawn.Id);

                var story = pawnElement.Element("story");

                var node = story.Element("childhood");
                if (!string.IsNullOrEmpty(pawn.Childhood)) {
                    if (node == null) {
                        node = new XElement("childhood");
                        story.Add(node);
                    }
                    node.Value = pawn.Childhood;
                } else {
                    node.Remove();
                }

                node = story.Element("adulthood");
                if (!string.IsNullOrEmpty(pawn.Adulthood)) {
                    if (node == null) {
                        node = new XElement("adulthood");
                        story.Add(node);
                    }
                    node.Value = pawn.Adulthood;
                } else {
                    node.Remove();
                }

                foreach (var skill in pawn.Skills) {
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

                foreach (var item in pawnPage.listBoxTraits.Items) {
                    var newTraitElement = new XElement("li");
                    var trait = Traits.Where(x => x.Value.Label == (string)item).Single().Value;

                    newTraitElement.Add(new XElement("def", trait.Def));

                    if (trait.Degree != null)
                        newTraitElement.Add(new XElement("degree", trait.Degree));

                    traitElement.Add(newTraitElement);
                }

                var hediffElement = pawnElement.XPathSelectElement("healthTracker/hediffSet/hediffs");
                hediffElement.RemoveAll();

                foreach (var hediff in pawn.Hediffs) {
                    hediffElement.Add(hediff.Element);
                }

                pawnElement.XPathSelectElement("ageTracker/ageBiologicalTicks")
                    .Value = ((long)(pawnPage.BiologicalAgeBox.Value * 3600000L)).ToString();
            }
            */

            SaveDocument.Save(path);

            MessageBox.Show("Successfully saved changes!");
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

        public static Dictionary<string, TraitDef> Traits = new Dictionary<string, TraitDef>();
        public static Dictionary<string, Hediff> Hediffs = new Dictionary<string, Hediff>();
        public static List<WorkType> WorkTypes = new List<WorkType>();
    }
}
