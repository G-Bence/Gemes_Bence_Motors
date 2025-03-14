namespace Motors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Statistics statistics = new Statistics();
            string fileName = @"motors.txt";

            statistics.ReadFromFiles(fileName);

            Console.WriteLine("All motors:");
            foreach (Motor motor in statistics.Motors)
            {
                Console.WriteLine($"{motor.Brand} {motor.Name}");
            }
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Summarized Value:");
            Console.WriteLine(statistics.SumPrices() + " Eur");

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Does the file contain Yamaha motor?:");
            Console.WriteLine(statistics.Contains("Yamaha") ? "Yes" : "No");

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("The oldest motor:");
            Motor oldest = statistics.Oldest();
            Console.WriteLine($"{oldest.Brand} {oldest.Name}");

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Royal Enfield motors' summarized price:");
            Console.WriteLine(statistics.SumPricesBasedOnBrand("Royal Enfield"));

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Motors sorted by their performance:\n");
            statistics.Sort();
            foreach (Motor motor in statistics.Motors)
            {
                Console.WriteLine($"{motor.Brand} {motor.Name}\nwith {motor.Performance} Hp\n");
            }

            Console.ReadKey();
        }
    }
}
