namespace Threads.Threads;

public static class Task8
{
    public static void Simulation()
    {
        Console.WriteLine("Simulation started\n");

        Thread simulation = new Thread(SaveData);

        simulation.IsBackground = true;

        simulation.Start();

        for (int i = 1; i<=17; i++)
        {
            Console.WriteLine($"User is working on text ({i}-seconds)");
            Thread.Sleep(1000);
        }

        Console.WriteLine("\nUser has finished");
    }

    private static void SaveData()
    {
        while (true)
        {
            Thread.Sleep(5000); 
            Console.WriteLine("\nData has succesfully saved! \n");
        }
    }
}