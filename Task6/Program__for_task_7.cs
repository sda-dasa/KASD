using MYVector;

var input = new StreamReader("input.txt");
MYVector<string?> iPv4 = new MYVector<string?> ();

while (!input.EndOfStream) iPv4.Add (input.ReadLine ());
string? val; bool flag;
iPv4.ShowEl(iPv4.Size());
for (int i = 0; i < iPv4.Size(); i++)
{
    
    val = ""; flag = true;
    for (int index = 0; index < iPv4.Get(i).Length - 2; index++)
    {
        // 023.14.30.29.8 - true - отбрасываем ноль
        // 090.009.82.8.99 - true - отбрасываем 090 ( 90.ХХХХХХ - норм, но после него идет .009. - 
        // это нивелируем всю последовательность, которая начинается с 090. - начинаем с 9 - 00 отбрасываем
        // получаем 9.82.8.99 - нормальный IP адрес

        if ( (int)iPv4.Get(i)[index] >= 48 && (int)iPv4.Get(i)[index] <= 57 )
        {
            if ((int)iPv4.Get(i)[index + 1] >= 48 && (int)iPv4.Get(i)[index + 1] <= 57)
            {
                if (iPv4.Get(i)[index] == '0')
                {
                    val = ""; index++;
                    if ((int)iPv4.Get(i)[index + 2] >= 48 && (int)iPv4.Get(i)[index + 2] <= 57)
                        index++;
                    continue;
                } // все ужасно, обнуляем последовательность
                else if ((int)iPv4.Get(i)[index + 2] >= 48 && (int)iPv4.Get(i)[index + 2] <= 57)
                {
                    if ((int)iPv4.Get(i)[index] >= 51) { val = ""; index += 2; continue; }// все ужасно, обнуляем последовательность
                    else if (iPv4.Get(i)[index] == '2' && (int)iPv4.Get(i)[index + 1] >= 54)
                    {
                        val = ""; index += 2; continue;
                    }// все ужасно, обнуляем последовательность
                    else if (iPv4.Get(i)[index] == '2' && iPv4.Get(i)[index + 1] == '5'
                                                                   && (int)iPv4.Get(i)[index + 2] >= 54)
                    {
                        val = ""; index += 2; continue;
                    } // все ужасно

                    else
                    {
                        Console.WriteLine($"{iPv4.Get(i)[index]}{iPv4.Get(i)[index + 1]}{iPv4.Get(i)[index + 2]}");
                        index += 2;
                    }
                }
                else
                {
                    Console.WriteLine($"{iPv4.Get(i)[index]}{iPv4.Get(i)[index + 1]}"); index++;
                }
            }
            else Console.WriteLine($"{iPv4.Get(i)[index]}");


        }



    }    



}
