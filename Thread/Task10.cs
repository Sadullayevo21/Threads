namespace Threads.Threads;

public static class Task10
{
    private static int totalTickets = 100;

    private static object locker = new object();

    private static List<Thread> customers = new List<Thread>();

    public static void BookingManager()
    {
        for (int i = 1; i <= 20; i++)
        {
            int customerId = i; 

            Thread thread = new Thread(() => BuyTickets($"Customer {customerId}"));
            customers.Add(thread);

            thread.Start();
        }

        for (int i = 0; i < customers.Count; i++)
        {
            customers[i].Join(); 
        }
    }

    private static void BuyTickets(string customerName)
    {
        Random random = new Random();
        int tickets = random.Next(1, 11); 

        lock (locker)
        {
            if (totalTickets >= tickets)
            {
                totalTickets -= tickets;
                Console.WriteLine($"{customerName}: has bought {tickets} tickets  (Left: {totalTickets})");
            }
            else
            {
                Console.WriteLine($"{customerName}: Purchase unsuccessful! {tickets} asked for, but {totalTickets} left.");
            }
        }
    }
}