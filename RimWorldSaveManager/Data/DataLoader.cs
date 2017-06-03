using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Globalization;
using RimWorldSaveManager.Data.DataStructure;
using System.Text;
using RimWorldSaveManager.UserControls;

namespace RimWorldSaveManager
{
    public class DataLoader
    {


        public DataLoader()
        {
            BackstoryDatabase.Load();

            foreach (var directory in Directory.GetDirectories("Mods"))
            {
                Func<string, string, string> CreateFullPath = (s1, s2)
                    => string.Join(Path.DirectorySeparatorChar.ToString(), directory, s1, s2);

                if (Directory.Exists(CreateFullPath("Defs", "TraitDefs")))
                {
                    foreach (var file in Directory.GetFiles(CreateFullPath("Defs", "TraitDefs"), "*.xml"))
                    {
                        using (var fileStream = File.OpenRead(file))
                        {
                            foreach (var traitDef in XDocument.Load(fileStream).Root.Elements())
                            {
                                var traits = (from trait in traitDef.XPathSelectElements("degreeDatas/li")
                                              select new TraitDef
                                              {
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

                if (Directory.Exists(CreateFullPath("Defs", "HediffDefs")))
                {
                    foreach (var file in Directory.GetFiles(CreateFullPath("Defs", "HediffDefs"), "*.xml"))
                    {
                        using (var fileStream = File.OpenRead(file))
                        {
                            var docRoot = XDocument.Load(fileStream).Root;

                            var hediffRoots = docRoot.XPathSelectElements("HediffDef/hediffClass/..");

                            if (hediffRoots.Count() == 0)
                            {
                                fileStream.Close();
                                fileStream.Dispose();
                                continue;
                            }

                            foreach (var hediffRoot in hediffRoots)
                            {

                                var parentClass = hediffRoot.Element("hediffClass").Value;
                                var parentName = hediffRoot.Attribute("Name") != null ? hediffRoot.Attribute("Name").Value : "None";

                                Hediff coreHediff;

                                if (!Hediffs.TryGetValue(parentClass, out coreHediff))
                                    Hediffs.Add(parentClass, coreHediff = new Hediff(parentClass, parentName));

                                var hediffs = (from hediff in docRoot.XPathSelectElements("//HediffDef[boolean(@ParentName) and not(@Abstract)]")
                                               .Where(x => x.Attribute("ParentName").Value == parentName)
                                               select new HediffDef
                                               {
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

                if (Directory.Exists(CreateFullPath("Defs", "WorkTypeDefs")))
                {
                    foreach (var file in Directory.GetFiles(CreateFullPath("Defs", "WorkTypeDefs"), "*.xml"))
                    {
                        using (var fileStream = File.OpenRead(file))
                        {
                            var docRoot = XDocument.Load(fileStream).Root;
                            var workTypeDefsRoot = docRoot.XPathSelectElements("WorkTypeDef/workTags/..");

                            if (workTypeDefsRoot.Count() == 0)
                            {
                                fileStream.Close();
                                fileStream.Dispose();
                                continue;
                            }

                            var workTypeDefs = from workTypeDef in workTypeDefsRoot
                                               select new WorkType
                                               {
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
            Colonists.Clear();
            Animals.Clear();

            //try {
            SaveDocument = XDocument.Load(path);

            var playerFaction = EvaluateSingle<XElement>("scenario/playerFaction/factionDef").Value;

            var colonyFaction = "Faction_" +
                EvaluateList<XElement>("world/factionManager/allFactions/li")
                .Where(x => Evaluate<bool>(x, "def/text()='" + playerFaction + "'"))
                .First().Element("loadID").Value;

            //Console.WriteLine($"playerFaction:{playerFaction}, colonyFaction:{colonyFaction}");

            Dictionary<String, List<PawnData>> pawnDataDir = new Dictionary<string, List<PawnData>>();
            foreach (var pawnData in SaveDocument.Descendants("pawn"))
            {
                String key = pawnData.GetValue();

                List<PawnData> pawnDataList;
                if (!pawnDataDir.TryGetValue(key, out pawnDataList))
                {
                    pawnDataList = new List<PawnData>();
                    pawnDataDir[key] = pawnDataList;
                }

                pawnDataList.Add(new PawnData(pawnData.Parent));
            }

            foreach (var pawn in SaveDocument.Descendants("thing"))
            {
                if ((string)pawn.Attribute("Class") == "Pawn"
                    && (string)pawn.Element("faction") == colonyFaction)
                {


                    Pawn p = new Pawn(pawn);
                    p.addPawnData(pawnDataDir[p.PawnId]);
                    if((string)pawn.Element("def") == "Human")
                    {
                        Colonists.Add(p);
                    }
                    else
                    {
                        Animals.Add(p);
                    }
                }
            }

            if (Colonists.Count == 0)
            {
                throw new Exception("No characters found!\nTry playing the game a little more.");
            }

            var colonistPage = new ColonistPage(Colonists);
            colonistPage.Dock = DockStyle.Fill;
            var animalPage = new AnimalPage(Animals);
            animalPage.Dock = DockStyle.Fill;

            TabPage colonisTabPage = new TabPage("Colonists");
            TabPage animalsTabPage = new TabPage("Animals");
            colonisTabPage.Controls.Add(colonistPage);
            animalsTabPage.Controls.Add(animalPage);


            tabControl.TabPages.Add(colonisTabPage);
            tabControl.TabPages.Add(animalsTabPage);


            return true;
        }

        public bool SaveData(string path)
        {
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
        private List<Pawn> Colonists = new List<Pawn>();
        private List<Pawn> Animals = new List<Pawn>();
        private TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;

        public static Dictionary<string, TraitDef> Traits = new Dictionary<string, TraitDef>();
        public static Dictionary<string, Hediff> Hediffs = new Dictionary<string, Hediff>();
        public static Dictionary<string, string> HumanBodyPartDescription = new Dictionary<string, string>();
        public static List<WorkType> WorkTypes = new List<WorkType>();
    }
}
