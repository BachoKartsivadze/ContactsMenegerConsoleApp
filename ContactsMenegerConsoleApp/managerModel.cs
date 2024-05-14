using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactsMenegerConsoleApp
{
    public class ManagerModel
    {
        List<CMContact> data = new List<CMContact>();
        const string filePath = "Data.json";

        public void AddContact()
        {
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Phone:");
            string phone = Console.ReadLine();

            Console.WriteLine("Enter eMail:");
            string email = Console.ReadLine();

            CMContact newContact = new CMContact { Name = name, PhoneNumber = phone, Email = email };
            data.Add(newContact);

            Console.WriteLine("Contact added successfully.");
        }

        public void ViewContacts()
        {
            Console.WriteLine("List of Contacts:");
            if (data.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            foreach (var contact in data)
            {
                Console.WriteLine($"Name: {contact.Name}");
                Console.WriteLine($"Phone: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"..............");
                Console.WriteLine();
            }
        }

        public void RemoveContact()
        {
            Console.WriteLine("Enter the email of the contact to remove:");
            string emailToRemove = Console.ReadLine();

            CMContact contactToRemove = data.Find(c => c.Email == emailToRemove);
            if (contactToRemove == null)
            {
                Console.WriteLine("No contact found with that email.");
                return;
            }

            data.Remove(contactToRemove);
            Console.WriteLine("Contact removed successfully.");
        }


        public void LoadContacts()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                data = JsonSerializer.Deserialize<List<CMContact>>(json);
            }
        }

        public void SaveContacts()
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, json);
        }
    }
}
