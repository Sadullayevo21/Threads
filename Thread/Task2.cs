namespace Threads.Threads;

public static class Task2
{
    public static void RunSum()
    {
        double sumA = 0;
        double sumB = 0;
        double sumC = 0;
        double sumD = 0;

        var thread1 = new Thread(() =>
        {
            for (int i = 1; i <= 250_000; i++)
            {
                sumA += i;
            }
        });

        var thread2 = new Thread(() =>
        {
            for (int i = 250_000; i <= 500_000; i++)
            {
                sumB += i;
            }
        });

        var thread3 = new Thread(() =>
        {
            for (int i = 500_000; i <= 750_000; i++)
            {
                sumC += i;
            }
        });

        var thread4 = new Thread(() =>
        {
            for (int i = 750_000; i <= 1_000_000; i++)
            {
                sumD += i;
            }
        });

        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();
        thread4.Join();

        Console.WriteLine($"Result: {sumA + sumB + sumC + sumD}");
    }
}