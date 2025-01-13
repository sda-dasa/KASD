using System.Text.RegularExpressions;
using Class_18;


string example = string.Empty;
string path = "input.txt";
var input = new StreamReader(path);

while (!input.EndOfStream)
{
    var line = input.ReadLine();
    if (line != null) foreach (char h in line) { if (h == ' ') break; else example += h; }

}
input.Close();

string pattern = @"</?[A-Za-z][A-Za-z0-9]*>";
Regex check = new Regex(pattern);

MatchCollection matches = check.Matches(example);

MYHashMap<int, string> container = new MYHashMap<int, string>(matches.Count);

int i = 0;

foreach (Match item in matches)
{
    string rstr = item.Value.ToString().ToLower();
    if (rstr[1] is '/') rstr = rstr.Replace("/", "");

    if (!container.ContainsValue(rstr)) container.Put(i++, rstr);

}

for (int k = 0; k < container.Size; k++) Console.WriteLine(container.GetEntire(k));

