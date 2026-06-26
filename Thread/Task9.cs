namespace Threads.Threads;

public static class Task9
{
    private static List<Thread> allFiles = new List<Thread>();

    public static void DownloadManager()
    {
        Thread thread1 = new Thread(() => DownloadFile("Fayl 1"));
        Thread thread2 = new Thread(() => DownloadFile("Fayl 2"));
        Thread thread3 = new Thread(() => DownloadFile("Fayl 3"));
        Thread thread4 = new Thread(() => DownloadFile("Fayl 4"));
        Thread thread5 = new Thread(() => DownloadFile("Fayl 5"));

        allFiles.Add(thread1);
        allFiles.Add(thread2);
        allFiles.Add(thread3);
        allFiles.Add(thread4);
        allFiles.Add(thread5);

        foreach (Thread file in allFiles)
        {
            file.Start();
        }

        foreach (Thread file in allFiles)
        {
            file.Join();
        }

        Console.WriteLine("\nAll files has succesfully downloaded!");
    }


    private static void DownloadFile(string fileName)
    {
        Random random = new Random();

        Console.WriteLine($"{fileName} yuklanishni boshladi...");

        for (int i = 0; i <= 100; i += 20)
        {
            int delay = random.Next(500, 1500); 
            Thread.Sleep(delay);

            Console.WriteLine($"{fileName}: {i}% yuklandi.");
        }

        Console.WriteLine($"\n{fileName} has succesfully downloaded!\n");
    }
}