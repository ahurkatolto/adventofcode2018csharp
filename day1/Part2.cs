using System;
using System.IO;
using System.Collections.Generic;

namespace aoc2018day1 {
    class Program {
        static void Main(string[] args) {
            bool freqFound = false;
            List<int> freqs = new List<int>();
            int freq = 0;
            while(!freqFound) {
                foreach(string change in File.ReadAllLines("input.txt")) {
                    freqs.Add(freq);
                    freq += int.Parse(change);
                    if(freqs.Contains(freq)) {
                        Console.WriteLine(freq);
                        freqFound = true;
                        break;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
