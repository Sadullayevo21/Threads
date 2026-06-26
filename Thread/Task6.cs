namespace Threads.Threads;

public static class Task6
{
    private static object lockKey = new object();

    public static void RunWithJoin()
    {
        var thread1 = new Thread(() =>
        {
            for (int i = 1; i <= 10; i++)
            {
                lock (lockKey)
                {
                    Console.WriteLine($"Thread 1: {i}");
                }
            }
        });

        var thread2 = new Thread(() =>
        {
            for (int i = 11; i <= 20; i++)
            {
                lock (lockKey)
                {
                    Console.WriteLine($"Thread 2: {i}");   
                }
            }
        });

        var thread3 = new Thread(() =>
        {
            for (int i = 21; i <= 30; i++)
            {
                lock (lockKey)
                {
                    Console.WriteLine($"Thread 3: {i}");   
                }
            }
        });

        thread1.Start();
        thread1.Join();

        thread2.Start();
        thread2.Join();

        thread3.Start();
        thread3.Join();
    }
}