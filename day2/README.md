# Day #2
The `input.txt` looks like this:
```
ymdrcyapvwfloiuktanxzjsieb
ymdrwhgznwfloiuktanxzjsqeb
ymdrchguvwfloiuktanxmjsleb
pmdrchgmvwfdoiuktanxzjsqeb
ymdrfegpvwfloiukjanxzjsqeb
...
```
## Part 1:
Calculating checksum from the list of box IDs included (it varies per user from here: [input](https://adventofcode.com/2018/day/2/input)).
### Code:
Read every line from the file (id), collect every unique character from the id, then test if the id contains any those characters 2 or 3 times.

The `counts` array builds up like this: counts[`number of IDs that contain the same char 2 times`,`number of IDs that contain the same char 3 times`]. If an ID contans 2 characters 3 times, like `aaabbb` for example, it counts only as one.

That's why there's the `contains` bool array, which builds up like this: contains[`contains the same char 2 times?`,`contains the same char 3 times?`].

And finally, the checksum is `counts[0]*counts[1]`.
```csharp
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
```
Result: `5000`
## Part 2:
Get an ID pair whith only 1 character difference, and the line of the matching characters of that pair is the result.
### Code:
First, it reads every ID into a list. Then tests every ID combination in the list to find a pair with 1 character difference, which is done by having an empty string, and adding the current pair's matching characters to it. Position matters, so it uses a for cycle to only add a character if it is equal at the same positions in both IDs. Then to get the result, check if the length of the output string is 1 character less then an ID. (It outputs the same string 2 times, because it finds every pair in 2 combinations, like [ABC-ABD] and [ABD-ABC].)
```csharp
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
```
Result: `ymdrchgpvwfloluktajxijsqb`
