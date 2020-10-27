using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2018day1 {
    class Program {
        static void Main(string[] args) {
            int[,] fabric = new int[1000,1000];
            int id = 0;
            for (byte c=0; c<2; c++) {
                foreach (string inputline in File.ReadAllLines("input.txt")) {
                    string[] input = inputline.Replace(":",string.Empty).Split(' ');
                    int row = int.Parse(input[2].Split(',')[1]);
                    int col = int.Parse(input[2].Split(',')[0]);
                    int width = int.Parse(input[3].Split('x')[0]);
                    int height = int.Parse(input[3].Split('x')[1]);
                    switch(c) {
                        case 0:
                            for (int a=row; a<row+height; a++) {
                                for (int b=col; b<col+width; b++) {
                                    fabric[a,b]++;
                                }
                            }
                            break;
                        case 1:
                            bool overlap = false;
                            for (int a=row; a<row+height; a++) {
                                for (int b=col; b<col+width; b++) {
                                    overlap = fabric[a,b]>1 || overlap;
                                }
                            }
                            id = !overlap ? int.Parse(input[0].Replace("#",string.Empty)) : id;
                            break;
                    }
                }
            }
            Console.WriteLine(id);
            Console.ReadKey();
        }
    }
}
