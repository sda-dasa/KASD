using ClassMyArrayList;

// строка - набор символов без пробелов - любой пробел - сигнал переходить на новую строку

var input = new StreamReader("input.txt");

MyArrayList_<string> tegs = new MyArrayList_<string>();

string dop;

while (!input.EndOfStream)
{
    var line = input.ReadLine();
    dop = "";
    for (int i = 0; i < line.Length && line[i] != ' '; i++) // читает до первого пробела в строке - если пробелов нет - читает до конца строки
    {
        if (line[i] == '<') 
        {
            dop = line[i] + ""; continue;
        }
        if (dop.Length > 0)
        {
            if (dop.Length == 1)
            {
                if (line[i] == '/') continue; // Символ '/' в начале тега не влияет на тег - не добавляем его в тег
                // регистр букв тоже не важен - добавляем все буквы, преобразовывая их в нижний регистр 
                if ((int)line[i] >= 65 && (int)line[i] <= 90 
                    || (int)line[i] >= 97 && (int)line[i] <= 122) { dop += Char.ToLower(line[i]); continue; } 
                else { dop = ""; continue; } // если первый символ - не буква - заново считаем новый тег
            }
            if (line[i] == '>' && dop.Length >= 2) { dop += line[i]; tegs.Add(dop); dop = ""; continue; }

            if ((int)line[i] >= 48 && (int)line[i] <= 57
                || (int)line[i] >= 65 && (int)line[i] <= 90
                    || (int)line[i] >= 97 && (int)line[i] <= 122) { dop += Char.ToLower(line[i]); }
            else dop = "";

        }
        

    }
        
}

if (!tegs.IsEmpty())tegs.ShowEl(tegs.Size());


// удаление повторов:

for (int i = 0; i < tegs.Size() - 1; i++)
{
    for (int j = i + 1; j < tegs.Size(); j++)
        if (tegs.Get(i).Equals(tegs.Get(j))) { tegs.Remove(j); j--; }

}
Console.WriteLine("\n\n");
tegs.ShowEl(tegs.Size());


