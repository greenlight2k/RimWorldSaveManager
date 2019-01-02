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

        private XDocument SaveDocument;
        private List<Pawn> Animals = new List<Pawn>();
        private TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;

        public static SortedDictionary<string, TraitDef> Traits = new SortedDictionary<string, TraitDef>();
        public static Dictionary<string, Hediff> Hediffs = new Dictionary<string, Hediff>();
        public static Dictionary<string, string> HumanBodyPartDescription = new Dictionary<string, string>();
        public static List<WorkType> WorkTypes = new List<WorkType>();
        public static List<string> Genders = new List<string>();
        public static Dictionary<string, Faction> Factions = new Dictionary<string, Faction>();
        public static Faction PlayerFaction;
        public static Dictionary<Faction, List<Pawn>> PawnsByFactions = new Dictionary<Faction, List<Pawn>>();
        public static Dictionary<string, Pawn> PawnsById = new Dictionary<string, Pawn>();

        public static Dictionary<string, Race> RaceDictionary = new Dictionary<string, Race>();
        public static List<PawnRelationDef> PawnRelationDefs = new List<PawnRelationDef>();
        public static GameData GameData;

        private Dictionary<string, List<string>> pathsForLaodingData = new Dictionary<string, List<string>>();


        public DataLoader()
        {
            Race human = new Race();
            human.DefName = "Human";
            human.Label = "Human";
            Genders.Add("Female");
            Genders.Add("Male");
            human.BodyType.Add("Male");
            human.BodyType.Add("Female");
            human.BodyType.Add("Average");
            human.BodyType.Add("Thin");
            human.BodyType.Add("Hulk");
            human.BodyType.Add("Fat");
            human.HairsByGender["Female"] = new List<Hair>();
            human.HairsByGender["Male"] = new List<Hair>();
            foreach (var firstType in new string[] { "Average", "Narrow" })
            {
                foreach (var secondType in new string[] { "Normal", "Pointy", "Wide" })
                {
                    human.HeadType.Add(new CrownType
                    {
                        CrownFirstType = firstType,
                        CrownSubType = secondType
                    });
                }
            }
            RaceDictionary[human.DefName] = human;

            ResourceLoader.Load();

            var allXmlFiles = Directory.GetFiles("Mods", "*.xml", SearchOption.AllDirectories);

            foreach (var xmlFile in allXmlFiles)
            {
                string[] pathComponents = xmlFile.Split('\\');
                if (!pathComponents[2].Equals("Defs"))
                {
                    continue;
                }
                string fileName = pathComponents[pathComponents.Length - 1];

                if (fileName.ToLower().Contains("race"))
                {
                    List<string> pathList;
                    if (!pathsForLaodingData.TryGetValue("race", out pathList))
                    {
                        pathList = new List<string>();
                        pathsForLaodingData["race"] = pathList;
                    }
                    pathList.Add(xmlFile);
                }
                if (fileName.ToLower().Contains("trait"))
                {
                    List<string> pathList;
                    if (!pathsForLaodingData.TryGetValue("trait", out pathList))
                    {
                        pathList = new List<string>();
                        pathsForLaodingData["trait"] = pathList;
                    }
                    pathList.Add(xmlFile);
                }
                if (fileName.ToLower().Contains("hediff"))
                {
                    List<string> pathList;
                    if (!pathsForLaodingData.TryGetValue("hediff", out pathList))
                    {
                        pathList = new List<string>();
                        pathsForLaodingData["hediff"] = pathList;
                    }
                    pathList.Add(xmlFile);
                }
                if (fileName.ToLower().Contains("backstor")) //y, ies
                {
                    List<string> pathList;
                    if (!pathsForLaodingData.TryGetValue("backstory", out pathList))
                    {
                        pathList = new List<string>();
                        pathsForLaodingData["backstory"] = pathList;
                    }
                    pathList.Add(xmlFile);
                }

                if (fileName.ToLower().Contains("worktype"))
                {
                    List<string> pathList;
                    if (!pathsForLaodingData.TryGetValue("worktype", out pathList))
                    {
                        pathList = new List<string>();
                        pathsForLaodingData["worktype"] = pathList;
                    }
                    pathList.Add(xmlFile);
                }
                if (fileName.ToLower().Contains("hair") || fileName.ToLower().Contains("antennae"))
                {
                    List<string> pathList;
                    if (!pathsForLaodingData.TryGetValue("hair", out pathList))
                    {
                        pathList = new List<string>();
                        pathsForLaodingData["hair"] = pathList;
                    }
                    pathList.Add(xmlFile);
                }

                if (fileName.ToLower().Contains("pawnrelations"))
                {
                    List<string> pathList;
                    if (!pathsForLaodingData.TryGetValue("pawnrelations", out pathList))
                    {
                        pathList = new List<string>();
                        pathsForLaodingData["pawnrelations"] = pathList;
                    }
                    pathList.Add(xmlFile);
                }
            }

            List<string> filePaths;
            if (pathsForLaodingData.TryGetValue("worktype", out filePaths))
            {
                foreach (var filePath in filePaths)
                {
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        try
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
                        }
                        catch (Exception e)
                        {
                            // Dont care
                        }
                        fileStream.Close();
                        fileStream.Dispose();
                    }
                }
            }


            if (pathsForLaodingData.TryGetValue("race", out filePaths))
            {
                foreach (var filePath in filePaths)
                {
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        try
                        {
                            var docRoot = XDocument.Load(fileStream).Root;
                            foreach (var raceVars in docRoot.Descendants("AlienRace.ThingDef_AlienRace"))
                            {
                                Race race = new Race();
                                race.DefName = raceVars.Element("defName").GetValue();
                                race.Label = raceVars.Element("label").GetValue();
                                var alienraceElement = raceVars.Element("alienrace");
                                if (alienraceElement == null)
                                {
                                    alienraceElement = raceVars.Element("alienRace");
                                }
                                race.HairsByGender["Female"] = new List<Hair>();
                                race.HairsByGender["Male"] = new List<Hair>();
                                foreach (var bodyType in alienraceElement.XPathSelectElements("generalSettings/alienPartGenerator/alienbodytypes/li"))
                                {
                                    race.BodyType.Add(bodyType.GetValue());
                                }
                                foreach (var crownType in alienraceElement.XPathSelectElements("generalSettings/alienPartGenerator/aliencrowntypes/li"))
                                {
                                    string[] crownStrings = crownType.GetValue().Split('_');
                                    race.HeadType.Add(new CrownType
                                    {
                                        CrownFirstType = crownStrings[0],
                                        CrownSubType = crownStrings[1]
                                    });
                                }
                                if (race.HeadType.Count == 0)
                                {
                                    race.HeadType.Add(new CrownType
                                    {
                                        CrownFirstType = "Average",
                                        CrownSubType = "Normal"
                                    });
                                }
                                var useGenderedHeads = alienraceElement.XPathSelectElement("generalSettings/alienPartGenerator/UseGenderedHeads");
                                if (useGenderedHeads != null)
                                {
                                    race.UseGenderedHeads = Convert.ToBoolean(useGenderedHeads.GetValue());
                                }
                                foreach (var path in alienraceElement.XPathSelectElement("graphicPaths/li").Elements())
                                {
                                    race.GraphicPaths[path.Name.ToString().ToLower()] = path.GetValue();
                                }
                                RaceDictionary[race.DefName] = race;
                            }

                        }
                        catch (Exception e)
                        {
                            Logger.Err(e.Message);
                            // Dont care
                        }
                        fileStream.Close();
                    }
                }
            }



            if (pathsForLaodingData.TryGetValue("hair", out filePaths))
            {
                Dictionary<string, Race> tempRaceDic = RaceDictionary.Values.ToDictionary(x => x.Label.ToLower(), x => x);
                foreach (var filePath in filePaths)
                {
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        try
                        {
                            var docRoot = XDocument.Load(fileStream).Root;
                            foreach (var hairVars in docRoot.Descendants("HairDef"))
                            {

                                Hair hair = new Hair(hairVars.Element("hairGender").GetValue(), hairVars.Element("label").GetValue(), hairVars.Element("defName").GetValue());

                                List<Race> races = new List<Race>();
                                foreach (var hairTags in hairVars.XPathSelectElements("hairTags/li"))
                                {
                                    Race race;
                                    if (tempRaceDic.TryGetValue(hairTags.GetValue().ToLower(), out race))
                                    {
                                        races.Add(race);
                                    }
                                }
                                if (races.Count == 0)
                                {
                                    races.Add(RaceDictionary["Human"]);
                                }

                                foreach (var race in races)
                                {
                                    if (hair.Gender.Equals("Any") || hair.Gender.Contains("Usually"))
                                    {
                                        foreach (var list in race.HairsByGender.Values.ToList())
                                        {
                                            list.Add(hair);
                                        }
                                    }
                                    else
                                    {
                                        List<Hair> hairListForGender;
                                        if (race.HairsByGender.TryGetValue(hair.Gender, out hairListForGender))
                                        {
                                            hairListForGender.Add(hair);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Logger.Err(e.Message);
                        }
                        fileStream.Close();
                    }
                }
                foreach (var race in RaceDictionary.Values.ToList())
                {
                    foreach (var list in race.HairsByGender.Values.ToList())
                    {
                        list.Sort(delegate (Hair x, Hair y)
                        {
                            return x.Def.CompareTo(y.Def);
                        });
                    }
                }
            }




            if (pathsForLaodingData.TryGetValue("trait", out filePaths))
            {
                foreach (var filePath in filePaths)
                {
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        try
                        {
                            var docRoot = XDocument.Load(fileStream).Root;
                            foreach (var traitDef in docRoot.Descendants("TraitDef"))
                            {
                                var traits = (from trait in traitDef.XPathSelectElements("degreeDatas/li")
                                              select new TraitDef
                                              {
                                                  Def = traitDef.Element("defName").Value,
                                                  Label = textInfo.ToTitleCase(trait.Element("label").Value),
                                                  Degree = trait.Element("degree") != null ? trait.Element("degree").Value : "0",
                                                  Description = trait.Element("description").Value
                                              });

                                foreach (var trait in traits)
                                    if (!Traits.ContainsKey(trait.Def + trait.Degree))
                                        Traits.Add(trait.Def + trait.Degree, trait);
                            }
                        }
                        catch (Exception e)
                        {
                            // Dont care
                        }
                        fileStream.Close();

                    }
                }
            }


            if (pathsForLaodingData.TryGetValue("hediff", out filePaths))
            {
                foreach (var filePath in filePaths)
                {
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        try
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
                        }
                        catch (Exception e)
                        {
                            // Dont care
                        }
                        fileStream.Close();
                        fileStream.Dispose();

                    }
                }
            }

            if (pathsForLaodingData.TryGetValue("backstory", out filePaths))
            {
                foreach (var filePath in filePaths)
                {
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        try
                        {
                            var docRoot = XDocument.Load(fileStream).Root;
                            foreach (var def in docRoot.Descendants("AlienRace.BackstoryDef"))
                            {
                                Backstory backstory = new Backstory
                                {
                                    Id = (string)def.Element("defName"),
                                    Title = (string)def.Element("title"),
                                    DisplayTitle = "(AlienRace)" + (string)def.Element("title"),
                                    TitleShort = (string)def.Element("titleShort"),
                                    Description = (string)def.Element("baseDescription"),
                                    Slot = (string)def.Element("slot"),
                                    SkillGains = new Dictionary<string, int>(),
                                    WorkDisables = new List<string>()
                                };
                                foreach (var skillGain in def.XPathSelectElements("skillGains/li"))
                                {
                                    string defName = (string)skillGain.Element("defName");
                                    int amount = Convert.ToInt32(skillGain.Element("amount").GetValue());
                                    backstory.SkillGains.Add(defName, amount);
                                }
                                foreach (var workDisables in def.XPathSelectElements("workDisables/li"))
                                {
                                    backstory.WorkDisables.Add(workDisables.GetValue());
                                }
                                ResourceLoader.Backstories[backstory.Id] = backstory;

                                if (string.IsNullOrEmpty(backstory.Slot))
                                {
                                    ResourceLoader.ChildhoodStories.Add(backstory);
                                    ResourceLoader.AdulthoodStories.Add(backstory);
                                }
                                else if (backstory.Slot == "Childhood")
                                {
                                    ResourceLoader.ChildhoodStories.Add(backstory);
                                }
                                else
                                {
                                    ResourceLoader.AdulthoodStories.Add(backstory);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Logger.Err(e.Message);
                            // Dont care
                        }
                        fileStream.Close();
                        fileStream.Dispose();
                    }
                }
            }

            if (pathsForLaodingData.TryGetValue("pawnrelations", out filePaths))
            {
                foreach (var filePath in filePaths)
                {
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        try
                        {
                            var docRoot = XDocument.Load(fileStream).Root;
                            foreach (var relationDef in docRoot.XPathSelectElements("PawnRelationDef"))
                            {
                                PawnRelationDefs.Add(new PawnRelationDef(relationDef));
                            }
                        }
                        catch (Exception e)
                        {
                            Logger.Err(e.Message);
                            // Dont care
                        }
                        fileStream.Close();
                        fileStream.Dispose();
                    }
                }
            }


            PawnRelationDefs = PawnRelationDefs.OrderBy(x => x.DefName).ToList();
            ResourceLoader.ChildhoodStories = ResourceLoader.ChildhoodStories.OrderBy(x => x.DisplayTitle).ToList();
            ResourceLoader.AdulthoodStories = ResourceLoader.AdulthoodStories.OrderBy(x => x.DisplayTitle).ToList();
        }

        public bool LoadData(string path, TabControl tabControl)
        {
            tabControl.TabPages.Clear();
            Animals.Clear();

            //try {
            SaveDocument = XDocument.Load(path);

            GameData = new GameData(SaveDocument.Root.XPathSelectElement("game/tickManager"));

            var playerFactionDef = EvaluateSingle<XElement>("scenario/playerFaction/factionDef").Value;

            foreach (var element in SaveDocument.Root.XPathSelectElements("game/world/factionManager/allFactions/li"))
            {
                Faction faction = new Faction(element);
                if (faction.Def.Equals(playerFactionDef))
                {
                    PlayerFaction = faction;
                }
                Factions[faction.FactionIDString] = faction;
                PawnsByFactions[faction] = new List<Pawn>();
            }

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

            foreach (var pawn in SaveDocument.Root.XPathSelectElements("game/world/worldPawns/pawnsAlive/li"))
            {
                Pawn p = new Pawn(pawn);
                if (p.Faction != null)
                {
                    List<PawnData> pawnDataList;
                    if (!pawnDataDir.TryGetValue(p.PawnId, out pawnDataList))
                    {
                        pawnDataList = new List<PawnData>();
                    }
                    p.addPawnData(pawnDataList);

                    PawnsById[p.PawnId] = p;
                    Faction faction = Factions[p.Faction];
                    PawnsByFactions[faction].Add(p);
                }

            }

            foreach (var pawn in SaveDocument.Descendants("thing"))
            {
                if ((string)pawn.Attribute("Class") == "Pawn")
                {


                    Pawn p = new Pawn(pawn);
                    if(p.Faction != null)
                    {
                        List<PawnData> pawnDataList;
                        if (!pawnDataDir.TryGetValue(p.PawnId, out pawnDataList))
                        {
                            pawnDataList = new List<PawnData>();
                        }
                        p.addPawnData(pawnDataList);

                        PawnsById[p.PawnId] = p;
                        Faction faction = Factions[p.Faction];
                        PawnsByFactions[faction].Add(p);
                    }
                    
                }
            }

            if (PawnsByFactions[PlayerFaction].Count == 0)
            {
                throw new Exception("No characters found!\nTry playing the game a little more.");
            }

            var colonistPage = new ColonistPage(PawnsByFactions[PlayerFaction].Where(p => p.Skills.Count != 0).ToList());
            colonistPage.Dock = DockStyle.Fill;
            var animalPage = new AnimalPage(PawnsByFactions[PlayerFaction].Where(p => p.Skills.Count == 0).ToList());
            animalPage.Dock = DockStyle.Fill;

            TabPage colonisTabPage = new TabPage("Colonists");
            TabPage animalsTabPage = new TabPage("Animals");
            TabPage relationsTabPage = new TabPage("Relations");
            TabPage gameDataTabPage = new TabPage("Game Info");
            colonisTabPage.Controls.Add(colonistPage);
            animalsTabPage.Controls.Add(animalPage);
            relationsTabPage.Controls.Add(new RelationPage());
            gameDataTabPage.Controls.Add(new GameDataPage());


            tabControl.TabPages.Add(gameDataTabPage);
            tabControl.TabPages.Add(colonisTabPage);
            tabControl.TabPages.Add(animalsTabPage);
            tabControl.TabPages.Add(relationsTabPage);


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


    }
}
