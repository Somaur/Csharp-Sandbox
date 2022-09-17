internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int number = 1719820;
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
    }
}