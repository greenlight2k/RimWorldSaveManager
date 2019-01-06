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
using RimWorldSaveManager.Data.DataStructure.Defs;
using RimWorldSaveManager.Data.DataStructure.SaveThings;

namespace RimWorldSaveManager
{
    public class DataLoader
    {

        private XDocument SaveDocument;
        public static string CurrentDocumentPath = null;

        private List<Pawn> Animals = new List<Pawn>();
        private TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;

        public static SortedDictionary<string, TraitDef> Traits = new SortedDictionary<string, TraitDef>();
        public static Dictionary<string, Hediff> Hediffs = new Dictionary<string, Hediff>();
        public static List<WorkType> WorkTypes = new List<WorkType>();
        public static List<string> Genders = new List<string>();
        public static Dictionary<string, Faction> Factions = new Dictionary<string, Faction>();
        public static Faction PlayerFaction;
        public static Dictionary<Faction, List<Pawn>> PawnsByFactions = new Dictionary<Faction, List<Pawn>>();
        public static Dictionary<string, Pawn> PawnsById = new Dictionary<string, Pawn>();
        public static List<string> Quality = new List<string>();

        public static Dictionary<string, Race> RaceDictionary = new Dictionary<string, Race>();
        public static SortedDictionary<string, PawnRelationDef> PawnRelationDefs = new SortedDictionary<string, PawnRelationDef>();
        public static GameData GameData;
        public static bool IgnoreMaxHitPoints = false;

        private Dictionary<string, List<string>> pathsForLaodingData = new Dictionary<string, List<string>>();

        private Dictionary<string, ThingDef> ThingDefs = new Dictionary<string, ThingDef>();
        public static Dictionary<string, ThingDef> ThingDefsByDefName = new Dictionary<string, ThingDef>();
        public static Dictionary<string, List<ThingDef>> ThingDefsByStuffCategory = new Dictionary<string, List<ThingDef>>();

        public static Dictionary<string, BodyDef> BodyDefsByDef = new Dictionary<string, BodyDef>();
        public static Dictionary<string, List<SaveThing>> SaveThingsByClass = new Dictionary<string, List<SaveThing>>();

        public static UniqueIDsManager uniqueIdsManager = null;

        public static AnimalPage animalPage;
        public static ColonistPage colonistPage;
        public static GeneralPage generalPage;
        public static ItemsPage itemsPage;
        public static RelationPage relationsPage;

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
            Quality.Add("Awful");
            Quality.Add("Poor");
            Quality.Add("Normal");
            Quality.Add("Good");
            Quality.Add("Excellent");
            Quality.Add("Masterwork");
            Quality.Add("Legendary");

            RaceDictionary[human.DefName] = human;

            ResourceLoader.Load();

            var allXmlFiles = Directory.GetFiles("Mods", "*.xml", SearchOption.AllDirectories);

            List<Hair> allHairs = new List<Hair>();

            foreach (var xmlFile in allXmlFiles)
            {
                string[] pathComponents = xmlFile.Split('\\');
                if (!pathComponents[2].Equals("Defs"))
                {
                    continue;
                }

                using (var fileStream = File.OpenRead(xmlFile))
                {
                    var docRoot = XDocument.Load(fileStream).Root;
                    CurrentDocumentPath = xmlFile;
                    var workTypeDefsRoot = docRoot.XPathSelectElements("WorkTypeDef/workTags/..");

                    if (workTypeDefsRoot.Count() != 0)
                    {
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

                    foreach (var hairVars in docRoot.Descendants("HairDef"))
                    {
                        Hair hair = new Hair(
                            hairVars.Element("hairGender").GetValue(),
                            hairVars.Element("label").GetValue(),
                            hairVars.Element("defName").GetValue(),
                            hairVars.XPathSelectElements("hairTags/li"));
                        allHairs.Add(hair);
                    }

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

                    foreach (var hediffRoot in docRoot.XPathSelectElements("HediffDef/hediffClass/.."))
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

                    foreach (var relationDef in docRoot.XPathSelectElements("PawnRelationDef"))
                    {
                        var pawnRelation = new PawnRelationDef(relationDef);
                        PawnRelationDefs.Add(pawnRelation.DefName, pawnRelation);
                    }

                    foreach (var thingDef in docRoot.XPathSelectElements("ThingDef"))
                    {
                        ThingDef def = new ThingDef(thingDef);
                        if(ThingDefs.TryGetValue(def.Name, out ThingDef value))
                        {
                            value.updateDef(thingDef);
                        }
                        else
                        {
                            ThingDefs.Add(def.Name, def);
                        }
                    }

                    foreach (var bodyDefElement in docRoot.XPathSelectElements("BodyDef"))
                    {
                        BodyDef bodyDef = new BodyDef(bodyDefElement);
                        if(bodyDef.DefName != null)
                        {
                            BodyDefsByDef.Add(bodyDef.DefName, bodyDef);
                        }
                    }

                    fileStream.Close();
                }

            }

            Dictionary<string, Race> tempRaceDic = RaceDictionary.Values.ToDictionary(x => x.Label.ToLower(), x => x);
            foreach(Hair hair in allHairs)
            {
                List<Race> races = new List<Race>();
                foreach (var hairTags in hair.HairTags)
                {
                    Race race;
                    if (tempRaceDic.TryGetValue(hairTags, out race))
                    {
                        races.Add(race);
                    }
                }
                if (races.Count == 0)
                {
                    races.Add(RaceDictionary["Human"]);
                    if(RaceDictionary.TryGetValue("Alien_Orassan", out var race))
                    {
                        races.Add(race);
                    }
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

            foreach(ThingDef thingDef in ThingDefs.Values)
            {
                if(thingDef.ParentName != null && ThingDefs.TryGetValue(thingDef.ParentName, out ThingDef value))
                {
                    thingDef.Parent = value;
                }
                if (thingDef.DefName != null && !ThingDefsByDefName.ContainsKey(thingDef.DefName))
                {
                    ThingDefsByDefName.Add(thingDef.DefName, thingDef);
                }
                foreach(string stuffPropCat in thingDef.StuffPropsCategories)
                {
                    if(ThingDefsByStuffCategory.TryGetValue(stuffPropCat, out var list))
                    {
                        list.Add(thingDef);
                    }
                    else
                    {
                        List<ThingDef> thingDefs = new List<ThingDef>();
                        thingDefs.Add(thingDef);
                        ThingDefsByStuffCategory.Add(stuffPropCat, thingDefs);
                    }
                }
            }

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

            uniqueIdsManager = new UniqueIDsManager(SaveDocument.Root.XPathSelectElement("game/uniqueIDsManager"));

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
            SaveThingsByClass = new Dictionary<string, List<SaveThing>>();
            foreach (var thing in SaveDocument.Descendants("thing"))
            {
                if ((string)thing.Attribute("Class") == "Pawn")
                {


                    Pawn p = new Pawn(thing);
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
                else
                {
                    SaveThing SaveThing = new SaveThing(thing);
                    if(SaveThingsByClass.TryGetValue(SaveThing.Class, out List<SaveThing> list))
                    {
                        list.Add(SaveThing);
                    }
                    else
                    {
                        List<SaveThing> newList = new List<SaveThing>();
                        newList.Add(SaveThing);
                        SaveThingsByClass.Add(SaveThing.Class, newList);
                    }
                    
                }
            }

            if (PawnsByFactions[PlayerFaction].Count == 0)
            {
                throw new Exception("No characters found!\nTry playing the game a little more.");
            }

            colonistPage = new ColonistPage();
            colonistPage.Dock = DockStyle.Fill;
            animalPage = new AnimalPage();
            animalPage.Dock = DockStyle.Fill;
            itemsPage = new ItemsPage();
            itemsPage.Dock = DockStyle.Fill;

            relationsPage = new RelationPage();
            generalPage = new GeneralPage();

            TabPage colonisTabPage = new TabPage("Colonists");
            TabPage animalsTabPage = new TabPage("Animals");
            TabPage relationsTabPage = new TabPage("Relations");
            TabPage gameDataTabPage = new TabPage("General");
            TabPage itemsTabPage = new TabPage("Items");
            colonisTabPage.Controls.Add(colonistPage);
            animalsTabPage.Controls.Add(animalPage);
            itemsTabPage.Controls.Add(itemsPage);
            relationsTabPage.Controls.Add(relationsPage);
            gameDataTabPage.Controls.Add(generalPage);


            tabControl.TabPages.Add(gameDataTabPage);
            tabControl.TabPages.Add(colonisTabPage);
            tabControl.TabPages.Add(animalsTabPage);
            tabControl.TabPages.Add(relationsTabPage);
            tabControl.TabPages.Add(itemsTabPage);


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
