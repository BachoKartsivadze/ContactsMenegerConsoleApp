using ContactsMenegerConsoleApp;
using System;
using System.Collections.Generic;
using System.Text.Json;


ManagerModel managerModel = new ManagerModel();

managerModel.LoadContacts();

while (true)

{
    Console.WriteLine("Hi I am Contacts Manager");
    Console.WriteLine();
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. View List of Contacts");
    Console.WriteLine("3. Remove Contact by email");

    ConsoleKeyInfo keyNumber = Console.ReadKey();
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
}

managerModel.SaveContacts();

