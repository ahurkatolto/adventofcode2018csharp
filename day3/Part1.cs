using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2018day1 {
    class Program {
        static void Main(string[] args) {
            int[,] fabric = new int[1000,1000];
            foreach(string inputline in File.ReadAllLines("input.txt")) {
                string[] input = inputline.Replace(":",string.Empty).Split(' ');
                int row = int.Parse(input[2].Split(',')[1]);
                int col = int.Parse(input[2].Split(',')[0]);
                int width = int.Parse(input[3].Split('x')[0]);
                int height = int.Parse(input[3].Split('x')[1]);
                for (int a=row; a<row+height; a++) {
                    for (int b=col; b<col+width; b++) {
                        fabric[a,b]++;
                    }
                }
            }
            int overlap = 0;
            for (int a=0; a<=fabric.GetUpperBound(0); a++) {
                for (int b=0; b<=fabric.GetUpperBound(1); b++) {
                    overlap += fabric[a,b]>1 ? 1 : 0;
                }
            }
            Console.WriteLine(overlap);
            Console.ReadKey();
        }
    }
}
