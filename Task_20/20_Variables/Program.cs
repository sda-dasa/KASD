using System;
using System.Text.RegularExpressions;
using Class_18;


internal partial class Program
{

    static void Main(string[] args)
    {

        StreamReader sR = new StreamReader("source.txt");
        string example = sR.ReadToEnd();


        string rule = @"[A-Za-z0-9]+\s+[a-z]+[A-Z_a-z0-9]*\s*=\s*[0-9]+\s*;";

        //string rule = @"^\s*[A-Za-z0-9]+\s+[a-z]+[A-Z_a-z0-9]*\s*=\s*[0-9]+;";

        Regex cheker = new Regex(rule, RegexOptions.Multiline);

        MatchCollection variants = cheker.Matches(example);

        MYHashMap<string, VariableType> varDefiner = new MYHashMap<string, VariableType>();
        int i = 0;


        string filepath = "result.txt";
        StreamWriter sWrt = new StreamWriter(filepath);


        foreach (Match variant in variants)
        {
            if (variant.Length > 6)
            {
                VariableType curType = RightType(variant.Value);
                if (!(curType is VariableType.NotStated))
                {
                    string varName = GetVarName(variant.Value);

                    if (!varDefiner.IsEmpty() && varDefiner.ContainsKey(varName))
                        // записываем переопределение в файл
                        sWrt.WriteLine($"{ToString(curType)} => " +
                            $"{varName}");
                    else
                        varDefiner.Put(varName, curType);
                }
                else Console.WriteLine("некорректное определение - " +
                    $"не соответствующий тип переменной (строка файла - {i})");
                 
            }
            i++;

        }

        sWrt.Close();



    }


    static string GetVarName(string wholestr)
    {
        if (wholestr.Length == 0) throw new ArgumentException(nameof(wholestr));

        string varName = string.Empty; int i = wholestr.IndexOf(" ");
        while (wholestr[i] == ' ') i++;

        while (wholestr[i] != '=' && wholestr[i]!= ' ') { varName += wholestr[i]; i++; }

        while (wholestr[i] == ' ') i++;
        if (wholestr[i] != '=') return string.Empty;


        string rule = @"[a-z]+[A-Za-z0-9]*";

        Regex cheker = new Regex(rule);

        MatchCollection res = cheker.Matches(varName);

        if (res.Count > 0) return varName;

        return string.Empty;


    }

    static string ToString (VariableType type)
    {
        switch (type)
        {
            case VariableType.Int: return "int";
            case VariableType.Double: return "double";
            case VariableType.Float: return "float";
            default: return string.Empty;
        }
    }


    static VariableType RightType(string v)
    {
        if (string.Format($"{v[0]}{v[1]}{v[2]}").Equals("int")) return VariableType.Int;

        if (string.Format($"{v[0]}{v[1]}{v[2]}{v[3]}{v[4]}").Equals("float")) return VariableType.Float;

        if (string.Format($"{v[0]}{v[1]}{v[2]}{v[3]}{v[4]}{v[5]}").Equals("double")) return VariableType.Double;

        return VariableType.NotStated;

    }



    enum VariableType : int
    {
        Int,
        Double,
        Float,
        NotStated = -1

    };






}
