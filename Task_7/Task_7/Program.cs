using MYVector;
using System.Numerics;
using System.Threading.Tasks.Dataflow;
namespace Task7
{
   public class Program
   {
       static string path = "input.txt";
       static string pathOut = "output.txt";
       static StreamReader in_ = new StreamReader(path);
       static StreamWriter out_ = new StreamWriter(pathOut);

       public static int Selector(string x)
       {
           if (int.TryParse(x, out int num_)) return num_;
           else return -1;
       }

       static MYVector<string> GetIP()
       {
           string line = in_.ReadLine();
           //if (line == null) { Console.WriteLine("Строчка пуста"); }
           MYVector<string> ip = new MYVector<string>(10);
           while (line != null)
           {
               string[] ipArray = line.Split(' ');
               foreach (string adress in ipArray)
               {
                   bool isIp = true;
                   if (adress.Length!=0 && adress[0] == '0') isIp = false;
                    
                   int[] ipGroup = adress.Split(".").Select(x => Selector(x)).ToArray();
                  
                   foreach (int item in ipGroup)
                   {
                       if (item > 255 || item < 0)
                           isIp = false;
                   }
                   if (isIp && ipGroup.Length == 4)
                       ip.Add(adress);
               }
               line = in_.ReadLine();
           }
           in_.Close();
           return ip;
       }
       static void WriteIpToFile(MYVector<string> ip)
       {
           for (int i = 0; i < ip.Size(); i++)
           {
               string address = ip.Get(i);
               out_.WriteLine(address);
           }
           out_.Close();
       }
       static void Main(string[] args)
       {
           MYVector<string> ip = new MYVector<string>(10);
           ip = GetIP();
           WriteIpToFile(ip);
       }
   }
}
