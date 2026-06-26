namespace Threads.Threads;

public static class Task3
{
    static int balance = 1000;
    static object key = new object();

    public static void RunBankWithLock()
    {
        Thread t1 = new Thread(WithdrawLock);
        Thread t2 = new Thread(WithdrawLock);
        Thread t3 = new Thread(WithdrawLock);
        Thread t4 = new Thread(WithdrawLock);
        Thread t5 = new Thread(WithdrawLock);

        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();
        t5.Start();

        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();
        t5.Join();

        Console.WriteLine(balance);
    }

    private static void Withdraw()
    {
        for (int i = 0; i<10; i++)
        {
            Thread.Sleep(10);
            balance -= 10;
        }
    }

    private static void WithdrawLock()
    {
        for (int i = 0; i<10; i++)
        {
            lock (key)
            {
                Thread.Sleep(10);
                balance -= 10;
            }
        }
    }
};
    