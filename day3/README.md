# Day #1
The `input.txt` looks like this:
```
#1 @ 509,796: 18x15
#2 @ 724,606: 23x15
#3 @ 797,105: 10x13
#4 @ 925,483: 18x19
...
```
#claim ID @ starting column, starting row: width x height
## Part 1:
Calculating the size of the overlapping fabric piece claims from a list of claims (it varies per user from here: [input](https://adventofcode.com/2018/day/3/input)).
### Code:
First, it creates a table representing the fabric. Each value means one square inch of fabric. Then it extracts the data from every input line the way it is shown above. After that, it adds 1 to every square inch of fabric that data claims. So at the end, if a square inch of fabric has a value bigger than 1, it has more than 1 claims, which means it is overlapping. Add these together in a seperate cycle, and we'll have the total overlapping square inches of fabric. 
```csharp
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

```
Result: `121259`
## Part 2:
Get the ID of the claim which doesn't overlap with any other claim.
### Code:
Repeats the cycle from Part 1 twice. The switch just starts the right set of operations from the two. The first one does the same thing as before, filling up the fabric's square inches with the claims, but the second one tests every claim with the already claimed fabric. If the square inches that claim wants each has a value of 1, it didn't overlap with any other claim, so return the id.
```csharp
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
```
Result: `239`
