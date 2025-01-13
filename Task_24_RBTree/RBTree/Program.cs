using RBTree;

public class Program
{
    public static void Main(string[] args)
    {
        Random random = new Random();
        MyTreeSet<int> treeSet = new MyTreeSet<int>();

        Console.WriteLine("Adding 20 random elements to the set:");
        for (int i = 0; i < 20; i++)
        {
            int number = random.Next(1, 50);
            Console.WriteLine(treeSet.Add(number) ? $"Added {number}" : $"{number} already exists");
        }

        Console.WriteLine("\nVisualizing tree with colors:");
        treeSet.m.PrintTree();

        Console.WriteLine("\nSet contains the following elements:");
        foreach (var item in treeSet.ToArray())
        {
            Console.Write(item); Console.Write(" ");
        }
        Console.WriteLine();

        Console.WriteLine($"\nSet size: {treeSet.Size()}");

        Console.WriteLine("\nChecking if set contains specific elements:");
        for (int i = 0; i < 5; i++)
        {
            int number = random.Next(1, 50);
            Console.WriteLine(treeSet.Contains(number) ? $"Set contains {number}" : $"Set does not contain {number}");
        }

        Console.WriteLine("\nRemoving 5 random elements from the set:");
        for (int i = 0; i < 5; i++)
        {
            int number = random.Next(1, 50);
            Console.WriteLine(treeSet.Remove(number) ? $"Removed {number}" : $"{number} not found");
        }

        Console.WriteLine($"\nSet size after removal: {treeSet.Size()}");

        Console.WriteLine("\nVisualizing tree with colors:");
        treeSet.m.PrintTree();

        Console.WriteLine("\nFirst and last elements:");
        if (!treeSet.IsEmpty())
        {
            Console.WriteLine($"First: {treeSet.First()}");
            Console.WriteLine($"Last: {treeSet.Last()}");
        }
        else
        {
            Console.WriteLine("Set is empty.");
        }

        Console.WriteLine("\nClearing the set...");
        treeSet.Clear();
        Console.WriteLine(treeSet.IsEmpty() ? "Set is now empty." : "Set is not empty.");

        Console.ReadLine();
    }
}