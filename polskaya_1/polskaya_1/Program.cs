
using MYStack;
using System.Data;

Console.WriteLine("Введите математическое выражение");
string ? expression = Console.ReadLine();
if (expression == "" || expression == " ") Console.WriteLine("Значение пустого выражения по умолчанию = 0");
else if (expression != null)
{
    expression = DefineArguments(expression);
    Console.WriteLine(expression);
    Console.WriteLine(Calculate(expression));
}


static string DefineArguments (string expression)
{
    string parametrs = ""; 
    foreach (char p in expression)
    {
        if ( p >= 'A' && p <= 'Z' || p >= 'a' && p <= 'z') parametrs += p + " ";
    }
    if (parametrs.Length > 0 )
    {
        Console.WriteLine($"Введите значения этих переменных через Enter: {parametrs}");

        int[] mas = new int[parametrs.Length / 2];
        for (int i = 0; i < mas.Length; i++) int.TryParse(Console.ReadLine(), out mas[i]);

        string newexp = "";

        for (int i = 0; i < expression.Length; i++)
        {
            bool flag = false;
            for (int j = 0; j < parametrs.Length && !flag; j+=2)
                if (expression[i] == parametrs[j]) { newexp += Convert.ToString(mas[j/2]); flag = true; }

            if (!flag) newexp += expression[i]; 

        }

        return newexp;

    }

    return expression;
    

}

static bool IsOperator(char с)
{
    if (("+-/*^()%".IndexOf(с) != -1))
        return true;
    return false;
}


static byte GetPriority(char s)
{
    switch (s)
    {
        case '(': return 0;
        case ')': return 1;
        case '+': return 2;
        case '-': return 3;
        case '*': 
        case '%':
        case '/': return 4;
        case '^': return 5;
        default: return 6;
    }
}



static bool IsDelimeter(char c)
{
    if ((" =".IndexOf(c) != -1))
        return true;
    return false;
}


double Calculate(string input)
{
    string output = GetExpression(input); //Преобразовываем выражение в постфиксную запись
    double result = Counting(output); //Решаем полученное выражение
    return result; //Возвращаем результат
}



string GetExpression(string input)
{
    string output = string.Empty; //Строка для хранения выражения
    Stack<char> operStack = new Stack<char>(); //Стек для хранения операторов

    for (int i = 0; i < input.Length; i++) //Для каждого символа в входной строке
    {
        //Разделители пропускаем
        if (IsDelimeter(input[i]))
            continue; //Переходим к следующему символу

        //Если символ - цифра, то считываем все число
        if (Char.IsDigit(input[i])) //Если цифра
        {
            //Читаем до разделителя или оператора, что бы получить число
            while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
            {
                output += input[i]; //Добавляем каждую цифру числа к нашей строке
                i++; //Переходим к следующему символу

                if (i == input.Length) break; //Если символ - последний, то выходим из цикла
            }

            output += " "; //Дописываем после числа пробел в строку с выражением
            i--; //Возвращаемся на один символ назад, к символу перед разделителем
        }

        //Если символ - оператор
        if (IsOperator(input[i])) //Если оператор
        {
            if (input[i] == '(') //Если символ - открывающая скобка
                operStack.Push(input[i]); //Записываем её в стек
            else if (input[i] == ')') //Если символ - закрывающая скобка
            {
                //Выписываем все операторы до открывающей скобки в строку
                char s = operStack.Pop();

                while (s != '(')
                {
                    output += s.ToString() + ' ';
                    s = operStack.Pop();
                }
            }
            else //Если любой другой оператор
            {
                if (operStack.Count > 0) //Если в стеке есть элементы
                    if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                        output += operStack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением

                operStack.Push(char.Parse(input[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека

            }
        }
    }

    //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
    while (operStack.Count > 0)
        output += operStack.Pop() + " ";

    return output; //Возвращаем выражение в постфиксной записи
}




static double Counting(string input)
{
    double result = 0; //Результат
    Stack<double> temp = new Stack<double>(); //Dhtvtyysq стек для решения

    for (int i = 0; i < input.Length; i++) //Для каждого символа в строке
    {
        //Если символ - цифра, то читаем все число и записываем на вершину стека
        if (Char.IsDigit(input[i]))
        {
            string a = string.Empty;

            while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Пока не разделитель
            {
                a += input[i]; //Добавляем
                i++;
                if (i == input.Length) break;
            }
            temp.Push(double.Parse(a)); //Записываем в стек
            i--;
        }
        else if (IsOperator(input[i])) //Если символ - оператор
        {
            //Берем два последних значения из стека
            double a = temp.Pop();
            double b = temp.Pop();

            switch (input[i]) //И производим над ними действие, согласно оператору
            {
                case '+': result = b + a; break;
                case '-': result = b - a; break;
                case '*': result = b * a; break;
                case '/': result = b / a; break;
                case '%': result = b % a; break;
                case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
            }
            temp.Push(result); //Результат вычисления записываем обратно в стек
        }
    }
    return temp.Peek(); //Забираем результат всех вычислений из стека и возвращаем его
}








//void DefineParametrs (string expression) { };

//bool IsDigit (char x) => x >= '0' && x <= '9';

//bool IsOperation (char x)
//{
//    switch (x)
//    {
//        case '+':
//        case '-':
//        case '*':
//        case '/':
//        case '(':
//        case ')':
//        case '^':
//        case '|': return true;

//        default: return false;
//    }
//}
//MYStack<char> PushWithPriority(char exp, MYStack<char> operations)
//{
//    if (exp == '(') //Если символ - открывающая скобка
//        operations.Push(exp); //Записываем её в стек
//    else if (exp == ')') //Если символ - закрывающая скобка
//    {
//        //Выписываем все операторы до открывающей скобки в строку
//        char s = operations.Pop();

//        while (s != '(')
//        {
//            output += s.ToString() + ' ';
//            s = operStack.Pop();
//        }

//    }

//}


//MYStack<int> Generate_Polskaya (string expression) 
//{
//    MYStack<int> num = new MYStack<int>(); MYStack<char> operations = new MYStack<char>();
//    for (int i = 0; i < expression.Length; i++)
//    {
//        //if (expression[i] == ')' && operations.IndexOf('(') == -1) throw new Exception("Запись выражения неверна");

//        if (IsDigit(expression[i])) num.Push(expression[i]); //  сделать так, чтобы числа, а не только цифры
//        if (ISOperaion(expression[i]))
//        {
//            PushWithPriority(expression[i], operations);
//        }

//    }


//};