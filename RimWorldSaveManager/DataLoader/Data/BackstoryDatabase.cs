using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager
{
    public static class BackstoryDatabase
    {
        public static readonly Dictionary<string, Backstory> Backstories = new Dictionary<string, Backstory>();
        public static Backstory[] ChildhoodStories;
        public static Backstory[] AdulthoodStories;

        private static bool Debug = true;

        public static void Load()
        {
            Logger.Debug("Loading backstory database.");
            Backstories.Clear();
            ChildhoodStories = null;
            AdulthoodStories = null;

            List<Backstory> childhodStories = new List<Backstory>();
            List<Backstory> adultStories = new List<Backstory>();

            Backstories["None"] = new Backstory { DisplayTitle = "-- No Backstory --", Id = "None", Description = "", Title = "", Slot = "Both" };
            childhodStories.Add(Backstories["None"]);
            adultStories.Add(Backstories["None"]);

            var resources = Properties.Resources.ResourceManager
                            .GetResourceSet(CultureInfo.InvariantCulture, true, true);


            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes((string)resources.GetObject("Backstories")))) {
                var root = XDocument.Load(stream).Root;

                foreach (var story in root.Elements()) {
                    var backstory = Backstory.Extract(story);
                    //backstory.Slot = "Both";
                    backstory.Id = story.Name.LocalName;
                    backstory.DisplayTitle = backstory.Title;

                    if (Backstories.ContainsKey(backstory.Id)) {
                        Logger.Warn($"Backstory database already contains entry with key:{backstory.Id}");
                        continue;
                    }

                    //CheckStory(backstory);
                    Backstories[backstory.Id] = backstory;

                    //Logger.Debug($"[Builtin Backstory] {backstory.Id}: {backstory.DisplayTitle}");

                    if (string.IsNullOrEmpty(backstory.Slot)) {
                        childhodStories.Add(backstory);
                        adultStories.Add(backstory);
                    } else if (backstory.Slot == "Childhood") {
                        childhodStories.Add(backstory);
                    } else {
                        adultStories.Add(backstory);
                    }
                }

                stream.Close();
                stream.Dispose();
            }

            var resourceList = new[]
            {
                "AdulthoodsCivil", "AdulthoodsRaider", "Childhoods", "ExtraA", "ExtraB", "ExtraC", "ExtraD",
                "rimworld_creations", "Travelers", "TribalAdulthoodsA", "TribalB", "TribalChildhoodsA", "TynanCustom"
            };

            foreach (var resourceName in resourceList) {
                var stories = new List<Backstory>();
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes((string)resources.GetObject(resourceName)))) {
                    var root = XDocument.Load(stream).Root;

                    foreach (var story in root.Descendants("Backstory")) {
                        var backstory = Backstory.Extract(story);
                        if (backstory != null) {
                            stories.Add(backstory);
                        }
                    }

                    foreach (var story in root.Descendants("Childhood")) {
                        var backstory = Backstory.Extract(story);
                        if (backstory != null) {
                            backstory.Slot = "Childhood";
                            stories.Add(backstory);
                        }
                    }

                    foreach (var story in root.Descendants("Adulthood")) {
                        var backstory = Backstory.Extract(story);
                        if (backstory != null) {
                            backstory.Slot = "Adulthood";
                            stories.Add(backstory);
                        }
                    }

                    foreach (var backstory in stories) {
                        if (backstory.Title == "") {
                            Logger.Err($"Story with empty title:{backstory.Id}");
                            continue;
                        }

                        Backstory old;
                        if (!Backstories.TryGetValue(backstory.Id, out old)) {
                            Logger.Debug($"Possible ID missmatch: {backstory.Id}: Attempting to fix.");
                            old = FixStoryId(backstory);
                        }

                        if (old == null) {
                            Logger.Err("[FIX] Fix FAILED. No matching title found.");
                            continue;
                        }

                        childhodStories.Remove(old);
                        adultStories.Remove(old);

                        if (resourceName.StartsWith("Tribal")) {
                            backstory.DisplayTitle = "(Tribal) " + backstory.DisplayTitle;
                        } else if (resourceName == "rimworld_creations" || resourceName == "TynanCustom") {
                            backstory.DisplayTitle = "(Special) " + backstory.DisplayTitle;
                        }

                        //CheckStory(backstory);
                        Backstories[backstory.Id] = backstory;

                        if (string.IsNullOrEmpty(backstory.Slot)) {
                            childhodStories.Add(backstory);
                            adultStories.Add(backstory);
                        } else if (backstory.Slot == "Childhood") {
                            childhodStories.Add(backstory);
                        } else {
                            adultStories.Add(backstory);
                        }
                    }

                    stream.Close();
                    stream.Dispose();
                }
            }

            // Sanity checker
            foreach (var story in Backstories.Values) {
                if (string.IsNullOrEmpty(story.ToString())) {
                    Logger.Err($"Empty/null story:{story.Title}");
                }
            }

            ChildhoodStories = childhodStories.OrderBy(x => x.DisplayTitle).ToArray();
            AdulthoodStories = adultStories.OrderBy(x => x.DisplayTitle).ToArray();

            resources.Dispose();
        }

        private static Backstory FixStoryId(Backstory story)
        {
            var list = new List<Backstory>();
            foreach (var s in Backstories.Values) {
                if (s.Title == story.Title) {
                    list.Add(s);
                }
            }
            if (list.Count == 0) {
                return null;
            }
            if (list.Count == 1) {
                Logger.Debug($"  [FIX] Fix success. Found candidate story:{list[0].Id}");
                story.Id = list[0].Id;
                return list[0];
            }
            Logger.Debug("  [FIX] Found multiple story candidates.");

            var storyDesc = story.Description.Substring(0, 50);
            foreach (var s in list) {
                if (s.Description.Substring(0, 50) == storyDesc) {
                    Logger.Debug($"    [FIX]Fix success. Found candidate story:{s.Id}");
                    return s;
                }
            }

            return null;
        }

        private static void CheckStory(Backstory story)
        {
            if (!Debug) {
                return;
            }
            foreach (var s in Backstories.Values) {
                if (s.Title == story.Title && s.Id != story.Id) {
                    Logger.Warn($"Possible backstory collision between {s.Id} and {story.Id}");
                }
            }
        }
    }
}
