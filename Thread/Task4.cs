namespace Threads.Threads;

public static class Task4
{
    private static List<int> numbers = new List<int>();
    private static object key = new object();

    public static Thread producer = new Thread(() =>
    {
        for (int i = 1; i <= 100; i++)
        {
            lock (key)
            {
                numbers.Add(i);
                Console.WriteLine($"Produced: {i}");
            }
            Thread.Sleep(50); 
        }
    });

    public static Thread consumer = new Thread(() =>
    {
        while (true)
        {
            int number = -1;
            bool hasItem = false;

            lock (key)
            {
                if (numbers.Count > 0)
                {
                    number = numbers[0];
                    numbers.RemoveAt(0);
                    Console.WriteLine($"Consumed: {number}");
                    hasItem = true;
                }
            }

            if (hasItem)
            {
                if (number == 100) return;
                Thread.Sleep(70);
            }
        }
    });

    public static void Start()
    {
        producer.Start();
        consumer.Start();
    }
}