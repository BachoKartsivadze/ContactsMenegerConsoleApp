using ContactsMenegerConsoleApp;



ManagerModel managerModel = new ManagerModel();
//Console.TreatControlCAsInput = true;
managerModel.LoadContacts();

// Subscribe to the event
Console.CancelKeyPress += Console_CancelKeyPress;

while (true)

{
    ShowMainMenu();

    ConsoleKeyInfo keyNumber = Console.ReadKey(true);
    Console.WriteLine();



    switch (keyNumber.KeyChar)
    {
        case '1':
            managerModel.AddContact();
            break;
        case '2':
            managerModel.ViewContacts();
            break;
        case '3':
            managerModel.RemoveContact();
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }

    managerModel.SaveContacts();
}


void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
{
    if (e.SpecialKey == ConsoleSpecialKey.ControlC)
    {
        Console.Clear();
        ShowMainMenu();
        e.Cancel = true; // Cancel the default behavior of terminating the process
    }
}

void ShowMainMenu() {
    Console.WriteLine();
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. View List of Contacts");
    Console.WriteLine("3. Remove Contact by email");
    Console.WriteLine("Press Ctrl+M to go back to the main screen.");
    Console.WriteLine(); ;
}



