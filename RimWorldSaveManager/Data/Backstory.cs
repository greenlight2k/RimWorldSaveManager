using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RimWorldSaveManager
{
    public class Backstory
    {
        private static readonly Regex DecriptionCutterRegex = new Regex("(.{50}\\s)");

        public string Slot;
        public string Title;
        public string TitleShort;
        public string Description;
        public string DisplayTitle;
        public string[] WorkDisables;
        public Dictionary<string, int> SkillGains;
        public string Id;

        public override string ToString()
        {
            return DisplayTitle;
        }

        public static Backstory Extract(XElement xml)
        {
            if (xml == null) {
                Logger.Err("Trying to extract backstory from null XElement.");
                return null;
            }

            if (string.IsNullOrEmpty((string)xml.Element("Title"))) {
                Logger.Err("Found backstory with empty Title.");
                return null;
            }

            var backstory = new Backstory {
                Title = (string)xml.Element("Title"),
                TitleShort = (string)xml.Element("TitleShort"),
                Description = (string)xml.Element("BaseDesc"),
                Slot = (string)xml.Element("Slot")
            };
            if (string.IsNullOrEmpty(backstory.Description)) {
                backstory.Description = (string)xml.Element("baseDesc");
            }
            backstory.Description = backstory.Description.Replace("\\n", "\n");

            backstory.DisplayTitle = backstory.Title;

            backstory.WorkDisables = ExtractWorkDisables(xml.Element("WorkDisables"));
            backstory.SkillGains = ExtractSkillGains(xml.Element("SkillGains"));

            backstory.Id = RemoveNonAlphanumeric(CapitalizedNoSpaces(backstory.Title.Replace('-', ' '))) + Math.Abs(StableStringHash(backstory.Description) % 100);

            //backstory.Id = backstory.Title.Replace(" ", "") + backstory.Description.StableStringHash();

            if (!string.IsNullOrEmpty(backstory.Description)) {
                //backstory.Description = DecriptionCutterRegex.Replace(backstory.Description, "$1\n");
            }

            return backstory;
        }

        private static int StableStringHash(string str)
        {
            if (str == null) {
                return 0;
            }
            int num = 23;
            int length = str.Length;
            for (int index = 0; index < length; ++index) {
                num = num * 31 + (int)str[index];
            }
            return num;
        }

        private static string RemoveNonAlphanumeric(string s)
        {
            var sb = new StringBuilder();

            for (int index = 0; index < s.Length; ++index) {
                if (char.IsLetterOrDigit(s[index]))
                    sb.Append(s[index]);
            }

            return sb.ToString();
        }

        public static string CapitalizedNoSpaces(string s)
        {
            string[] strArray = s.Split(' ');
            StringBuilder sb = new StringBuilder();
            foreach (string str in strArray) {
                if (str.Length > 0)
                    sb.Append(char.ToUpper(str[0]));
                if (str.Length > 1)
                    sb.Append(str.Substring(1));
            }
            return sb.ToString();
        }

        private static string[] ExtractWorkDisables(XElement xml)
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

        private static Dictionary<string, int> ExtractSkillGains(XElement xml)
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
    }
}
