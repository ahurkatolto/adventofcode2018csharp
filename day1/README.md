# Day #1
The `input.txt` looks like this:
```
+3
+8
-5
+15
...
```
## Part 1:
Calculating the final frequency from the list of operations included (it varies per user from here: [input](https://adventofcode.com/2018/day/1/input)).
### Code:
Read every line from the file, as an integer add all of them to `freq` (adding a negative value = subtracting, so it works), and the resulting value will be the answer.
```csharp
int freq = 0;
foreach(string line in File.ReadAllLines("input.txt")) {
    freq += int.Parse(line);
}
Console.WriteLine(freq);
```
Result: `533`
## Part 2:
Repeat Part 1's operations until a frequency appears twice. Adding the frequency to the list, then incrementing it with the new modifier. Checking the list for the that new frequency. If the list contains it, that means we already had that frequency before, and the task is completed. If not, repeat the cycle.
### Code:
```csharp
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
```
Result: `73272`
