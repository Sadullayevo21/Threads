namespace Threads.Threads;

public static class Task5
{
    private static Thread[] threads = new Thread[10];
    private static object locker = new object();

    public static void Run()
    {
        for (int i = 0; i < 10; i++)
        {
            int threadNum = i; 
            
            threads[i] = new Thread(() =>
            {
                for (int i = 1; i < 100; i++)
                {
                    lock (locker)
                    {
                        File.AppendAllText("log.txt", $"Thread {threadNum}: {i}\n"); 
                    }
                }
            });
        }

        for (int i = 0; i < 10; i++)
        {
            threads[i].Start();
            threads[i].Join();
        }

        
        Console.WriteLine("Successfully"); 
    }
}