﻿using System.Configuration;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace ContactsMenegerConsoleApp
{
    public class ManagerModel
    {
        // data
        List<CMContact> data = new List<CMContact>();
        string filePath = "Data2.json";
        
        // manager funqtionality
        public void AddContact()
        {
            var name = addName();
            if (name == "error") return;

            var number = addNumber();
            if (number == "error") return;

            var email = addEmail();
            if (email == "error") return;

            CMContact newContact = new CMContact { name = name, phoneNumber = number, email = email};
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
                Console.WriteLine($"Name: {contact.name}");
                Console.WriteLine($"Phone: {contact.phoneNumber}");
                Console.WriteLine($"Email: {contact.email}");
                Console.WriteLine($"..............");
                Console.WriteLine();
            }
        }

        public void RemoveContact()
        {
            Console.WriteLine("Enter the email of the contact to remove:");
            string emailToRemove = Console.ReadLine();

            CMContact contactToRemove = data.Find(c => c.email == emailToRemove);
            if (contactToRemove == null)
            {
                Console.WriteLine("No contact found with that email.");
                return;
            }

            data.Remove(contactToRemove);
            Console.WriteLine("Contact removed successfully.");
        }


        // working on storage
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


        // validations
        private string addName() {
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            while ((name != null) && (name.Length < 3))
            {
                Console.WriteLine("Invalid name. Name must be at least 3 characters long");
                Console.WriteLine("Enter valid name:");
                name = Console.ReadLine();
            }
            if (name == null) return "error";
            return name;
        }

        private string addNumber()
        {
            Console.WriteLine("Enter Number:");
            string number = Console.ReadLine();
            while (true)
            {
                if ((number == null) || (number.Length >= 9 && number.Length <= 13)) break;
                Console.WriteLine("Invalid number.");
                Console.WriteLine("Enter valid Number:");
                number = Console.ReadLine();
            }
            if (number == null) return "error";
            return number;
        }

        private string addEmail()
        {
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();
            while (true)
            {
               
                if ((email == null) || (email.Contains("@") && email.Contains(".") && email.Length > 8 && email.Length < 28)) break;
                Console.WriteLine("Invalid Email");
                Console.WriteLine("Enter valid Email:");
                email = Console.ReadLine();
            }
            if (email == null) return "error";
            return email;
        }
    }
}
