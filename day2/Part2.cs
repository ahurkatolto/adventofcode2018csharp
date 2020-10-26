using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2018day1 {
    class Program {
        static void Main(string[] args) {
            List<string> ids = File.ReadAllLines("input.txt").ToList();
            foreach(string baseId in ids) {
                foreach (string compareId in ids) {
                    string line = "";
                    for (byte c=0; c<baseId.Length; c++) {
                        line += baseId.Substring(c,1) == compareId.Substring(c,1) ? baseId.Substring(c,1) : "";
                    }
                    if (line.Length == baseId.Length-1) {
                        Console.WriteLine(line);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
