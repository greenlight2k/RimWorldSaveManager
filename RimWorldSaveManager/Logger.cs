using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimWorldSaveManager
{
    public static class Logger
    {
        public static void Debug(string msg)
        {
            Console.WriteLine($"[DEBUG] {msg}");
        }

        public static void Warn(string msg)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARN] {msg}");
            Console.ForegroundColor = color;
        }

        public static void Err(string msg)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERR] {msg}");
            Console.ForegroundColor = color;
        }
    }
}
