namespace Threads.Threads;

public static class Task7
{
    private static List<int> firstRangePrimes = new List<int>();
    private static List<int> secondRangePrimes = new List<int>();
    private static List<int> thirdRangePrimes = new List<int>();
    private static List<int> fourthRangePrimes = new List<int>();
    private static List<int> allPrimes = new List<int>();

    public static void RunPrimeNumbers()
    {
        Thread thread1 = new Thread(() => FindPrimes(1, 25_000, firstRangePrimes));
        Thread thread2 = new Thread(() => FindPrimes(25_001, 50_000, secondRangePrimes));
        Thread thread3 = new Thread(() => FindPrimes(50_001, 75_000, thirdRangePrimes));
        Thread thread4 = new Thread(() => FindPrimes(75_001, 100_000, fourthRangePrimes));

        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();


        thread1.Join();
        thread2.Join();
        thread3.Join();
        thread4.Join();

        allPrimes.AddRange(firstRangePrimes);
        allPrimes.AddRange(secondRangePrimes);
        allPrimes.AddRange(thirdRangePrimes);
        allPrimes.AddRange(fourthRangePrimes);

        Console.WriteLine($"\nTotal prime numbers found: {allPrimes.Count}");
        Console.WriteLine("Prime numbers found: ");
        
        foreach (int prime in allPrimes)
        {
            Console.Write(prime + " ");
        }
        Console.WriteLine(); 
    }

    private static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var border = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= border; i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }

    private static void FindPrimes(int start, int end, List<int> resultList)
    {
        for (int i = start; i <= end; i++)
        {
            if (IsPrime(i))
            {
                resultList.Add(i);
            }
        }
    }
}