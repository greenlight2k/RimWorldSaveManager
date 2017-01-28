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

        public static void Load()
        {
            Console.WriteLine("[DEBUG] Loading backstory database.");
            Backstories.Clear();
            ChildhoodStories = null;
            AdulthoodStories = null;

            var resources = Properties.Resources.ResourceManager
                            .GetResourceSet(CultureInfo.InvariantCulture, true, true);

            List<Backstory> childhodStories = new List<Backstory>();
            List<Backstory> adultStories = new List<Backstory>();

            foreach (DictionaryEntry file in resources) {
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes((string)file.Value))) {

                    var root = XDocument.Load(stream).Root;
                    var stories = new List<Backstory>();

                    if (root.Name.LocalName == "BackstoryTranslations") {
                        foreach (var story in root.Elements()) {
                            var backstory = Backstory.Extract(story);
                            backstory.Slot = "Both";
                            backstory.Id = story.Name.LocalName;
                            backstory.DisplayTitle = backstory.Title;

                            if (Backstories.ContainsKey(backstory.Id))
                            {
                                Console.WriteLine($"[WARN] Backstory database already contains entry with key:{backstory.Id}");
                                continue;
                            }

                            Backstories[backstory.Id] = backstory;
                            childhodStories.Add(backstory);
                            adultStories.Add(backstory);
                        }
                        stream.Close();
                        stream.Dispose();
                        continue;
                    }

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
                        if (backstory.Title == "") continue;

                        var fileKey = ((string)file.Key);
                        if (fileKey == "rimworld_creations" ||
                            fileKey == "TynanCustom")
                            backstory.DisplayTitle = "(Special) " + backstory.Title;
                        else if (fileKey.Contains("Tribal"))
                            backstory.DisplayTitle = "(Tribal) " + backstory.Title;
                        else
                            backstory.DisplayTitle = backstory.Title;

                        if (Backstories.ContainsKey(backstory.Id)) {
                            Console.WriteLine($"[WARN] Backstory database already contains entry with key:{backstory.Id}");
                            continue;
                        }

                        Backstories[backstory.Id] = backstory;

                        if (backstory.Slot == "Childhood") {
                            childhodStories.Add(backstory);
                        } else {
                            adultStories.Add(backstory);
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

            ChildhoodStories = childhodStories.OrderBy(x => x.DisplayTitle).ToArray();
            AdulthoodStories = adultStories.OrderBy(x => x.DisplayTitle).ToArray();
        }
    }
}
