using Threads.Threads;

string choice;

do
{
    Console.Clear();
    
    Console.WriteLine("================ MENU ================");
    Console.WriteLine("1. Parallel counter");
    Console.WriteLine("2. Sum numbers with multiple threads");
    Console.WriteLine("3. Shared bank account");
    Console.WriteLine("4. Producer-consumer");
    Console.WriteLine("5. Thread-Safe Logger");
    Console.WriteLine("6. Sequential Execution with Join");
    Console.WriteLine("7. Prime number finder");
    Console.WriteLine("8. Backround autosafe simulation");
    Console.WriteLine("9. Download manager simulation");
    Console.WriteLine("10. Ticket booking system");
    Console.WriteLine("0. Exit");
    Console.Write("Please enter your selection: ");
    
    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            {
                Task1.Run();
                WaitAndContinue();
                break;
            }
        case "2":
            {
                Task2.RunSum();
                WaitAndContinue();
                break;
            }
        case "3":
            {
                Task3.RunBankWithLock();
                WaitAndContinue();
                break;
            }
        case "4":
            {
                Task4.Start();
                WaitAndContinue();
                break;
            }
        case "5":
            {
                Task5.Run();
                WaitAndContinue();
                break;
            }
        case "6":
            {
                Task6.RunWithJoin();
                WaitAndContinue();
                break;
            }
        case "7":
            {
                Task7.RunPrimeNumbers();
                WaitAndContinue();
                break;
            }
        case "8":
            {
                Task8.Simulation();
                WaitAndContinue();
                break;
            }
        case "9":
            {
                Task9.DownloadManager();
                WaitAndContinue();
                break;
            }
        case "10":
            {
                Task10.BookingManager();
                WaitAndContinue();
                break;
            }
        case "0":
            {
                Console.WriteLine("The program has ended!");
                break;
            }
        default:
            Error();
            break;
    }

    void WaitAndContinue()
    {
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }

    void Error()
    {
        Console.WriteLine("Invalid choice. Press any key to continue...");
        Console.ReadKey();
    }

} while (choice != "0");