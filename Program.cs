// See https://aka.ms/new-console-template for more information
Graphe Un = Graphe("D:\\IA\\Formes\\un.txt");
foreach (char[] line in Un.matrix)
{
    foreach (char c in line)
    {
        Console.Write(c);
    }
    Console.WriteLine();
}
