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

            Thread thread = new Thread(() => BuyTickets($"Mijoz {customerId}"));
            customers.Add(thread);
        }

        for (int i = 0; i < customers.Count; i++)
        {
            customers[i].Start(); 
        }

        for (int i = 0; i < customers.Count; i++)
        {
            customers[i].Join(); 
        }
    }

    private static void BuyTickets(string customerName)
    {
        Random random = new Random();
        int ticketsToBuy = random.Next(1, 11); 

        lock (locker)
        {
            if (totalTickets >= ticketsToBuy)
            {
                totalTickets -= ticketsToBuy;
                Console.WriteLine($"{customerName}: {ticketsToBuy} ta bilet sotib oldi. (Qoldi: {totalTickets})");
            }
            else
            {
                Console.WriteLine($"{customerName}: Xarid muvaffaqiyatsiz! {ticketsToBuy} ta bilet so'radi, lekin {totalTickets} ta qolgan.");
            }
        }
    }
}