using System;
using System.IO;

namespace aoc2018day1 {
    class Program {
        static void Main(string[] args) {
            int freq = 0;
            foreach(string line in File.ReadAllLines("input.txt")) {
                freq += int.Parse(line);
            }
            Console.WriteLine(freq);
            Console.ReadKey();
        }
    }
}
