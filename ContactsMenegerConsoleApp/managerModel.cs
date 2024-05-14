using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsMenegerConsoleApp
{
    public class ManagerModel
    {
        static List<CMContact> contacts = new List<CMContact>();

        public void AddContact()
        {
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Phone:");
            string phone = Console.ReadLine();

            Console.WriteLine("Enter eMail:");
            string email = Console.ReadLine();

            CMContact newContact = new CMContact { Name = name, PhoneNumber = phone, Email = email };
            contacts.Add(newContact);

            Console.WriteLine("Contact added successfully.");
        }

        public void ViewContacts()
        {
            Console.WriteLine("List of Contacts:");
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            foreach (var contact in contacts)
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

            CMContact contactToRemove = contacts.Find(c => c.Email == emailToRemove);
            if (contactToRemove == null)
            {
                Console.WriteLine("No contact found with that email.");
                return;
            }

            contacts.Remove(contactToRemove);
            Console.WriteLine("Contact removed successfully.");
        }
    }
}
