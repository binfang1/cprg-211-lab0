using System.IO;

class Program
{
    static public void Main(String[] args)
    {
        double low = GetLowNumber();
        double high = GetHighNumber(low);

        double difference = high - low;

        List<double> between = GetNumbersBetween(low, high);

        between.Reverse();

        WriteNumbersToFile(between);

        ReadFileAndPrintSum();

        PrintPrimeNumbersInList(between);
    }

    static void PrintPrimeNumbersInList(List<double> between)
    {
        foreach (double num in between)
        {
            if (IsPrime(num))
            {
                Console.WriteLine($"Prime Number Found: {num}");
            }
        }
    }

    static void ReadFileAndPrintSum()
    {
        double sum = 0;
        string line;
        using (StreamReader sr = new StreamReader("numbers.txt"))
        {
            while ((line = sr.ReadLine()) != null)
            {
                sum += Convert.ToDouble(line);
            }
        }
        Console.WriteLine($"Sum: {sum.ToString()}");
    }

    static void WriteNumbersToFile(List<double> between)
    {
        FileStream fs = File.Create("numbers.txt");

        using (StreamWriter sw = new StreamWriter(fs))
        {
            foreach (double i in between)
            {
                sw.WriteLine(i.ToString());
            }
        }
    }

    static List<double> GetNumbersBetween(double low, double high)
    {
        List<double> between = new List<double>();
        for (double i = low; i < high - 1; i++)
        {
            between.Add(i + 1);
        }
        return between;
    }

    static double GetLowNumber()
    {
        double low;
        do
        {
            Console.Write("Enter Low Number: ");
            low = Convert.ToDouble(Console.ReadLine());

        } while (low < 1);

        return low;
    }

    static double GetHighNumber(double low)
    {
        double high;
        do
        {
            Console.Write("Enter High Number: ");
            high = Convert.ToDouble(Console.ReadLine());
        } while (low >= high);

        return high;

    }

    static bool IsPrime(double num)
    {
        for (double i = num - 1; i > 1; i--)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}
