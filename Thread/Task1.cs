using Microsoft.VisualBasic;

namespace Threads.Threads;

public static class Task1
{
    public static void Run()
    {
        var threadA = new Thread(() =>
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Thread A: {i}");
                Thread.Sleep(300); 
            }
        });

        var threadB = new Thread(() =>
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Thread B: {i}");
                Thread.Sleep(300);
            }
        });

        var threadC = new Thread(() =>
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Thread C: {i}");
                Thread.Sleep(300);
            }
        });

        threadA.Start();
        threadB.Start();
        threadC.Start();

        threadA.Join();
        threadB.Join();
        threadC.Join();
    }
}