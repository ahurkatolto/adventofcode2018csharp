using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2018day1 {
    class Program {
        static void Main(string[] args) {
            int[] counts = {0,0};
            foreach(string id in File.ReadAllLines("input.txt")) {
                bool[] contains = {false,false};
                foreach(char item in id.ToHashSet()) {
                    switch(id.Count(s => s.Equals(item))) {
                        case 2: contains[0]=true; break;
                        case 3: contains[1]=true; break;
                    }
                }
                counts[0] += contains[0] ? 1 : 0;
                counts[1] += contains[1] ? 1 : 0;
            }
            Console.WriteLine(counts[0]*counts[1]);
            Console.ReadKey();
        }
    }
}
