using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inlämningsuppgift2_Refaktorering.People;

namespace Inlamning_2_ra_kod
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            List<Person> Dict = new List<Person>();
            Contacts(Dict);
            Console.Write("Laddar adresslistan ... ");
            Console.WriteLine("klart!");
            Console.WriteLine("Hej och välkommen till adresslistan");
            Console.WriteLine("Skriv 'sluta' för att sluta!");
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                if (command == "sluta")
                {
                    Console.WriteLine("Hej då!");
                }
                else if (command == "ny")
                {
                    AddNewContact(Dict);
                }
                else if (command == "ta bort")
                {
                    DeleteContactFromList(Dict);
                }
                else if (command == "visa")
                {
                    ShowListContacts(Dict);

                }
                else if (command == "ändra")
                {
                    ChangeContactInfo(Dict);
                }
                else
                {
                    Console.WriteLine("Okänt kommando: {0}", command);
                }
            } while (command != "sluta");
        }
        /* Method: ChangeContactInfo() (static)
         * PURPOSE: Changes a certain value of person in Dict list
         * PARAMETERS: List<Person> Dict - lists of person classes
         * RETURN VALUE: Return value is void but Dict[found].Print(); - Prints out the new name and info
         */
        static void ChangeContactInfo(List<Person> Dict)
        {
            Console.Write("Vem vill du ändra (ange namn): ");
            string WantToChange = Console.ReadLine();
            int found = -1;
            for (int i = 0; i < Dict.Count(); i++)
            {
                if (Dict[i].name == WantToChange)
                {
                    found = i;
                    Console.Write("Vad vill du ändra (namn, adress, telefon eller email): ");
                    string personInfo = Console.ReadLine();
                    Console.Write("Vad vill du ändra {0} på {1} till: ", personInfo, WantToChange);
                    string value = Console.ReadLine();
                    Dict[i].EditContactInfo(personInfo, value);
                    Dict[found].Print();
                }
            }
            if (found == -1)
            {
                Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", WantToChange);
            }
        }
        /* Method: ShowListContacts() (static)
         * PURPOSE: Printing out all persons on Dict list
         * PARAMETERS: List<Person> Dict - lists of person classes
         * RETURN VALUE: Return vale is void but Dict[i].Print(); - Prints out the name and info
         */
        static void ShowListContacts(List<Person> Dict)
        {
            for (int i = 0; i < Dict.Count(); i++)
            {
                Person P = Dict[i];
                Dict[i].Print();
            }
        }
        /* Method: DeleteContactFromList() (static)
         * PURPOSE: Delete person from Dict list
         * PARAMETERS: List<Person> Dict - lists of person classes
         * RETURN VALUE: Return value is void
         */
        static void DeleteContactFromList(List<Person> Dict)
        {
            Console.Write("Vem vill du ta bort (ange namn): ");
            string inputToRemove = Console.ReadLine();
            int found = -1;
            for (int i = 0; i < Dict.Count(); i++)
            {
                if (Dict[i].name == inputToRemove) found = i;
            }
            if (found == -1)
            {
                Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", inputToRemove);
            }
            else
            {
                Dict[found].Print();
                Dict.RemoveAt(found);
            }
        }
        /* Method: AddNewContact() (static)
         * PURPOSE: Add new person to Dict list
         * PARAMETERS: List<Person> Dict - lists of person classes
         * RETURN VALUE: Return value is void but Dict[Dict.Count() - 1].Print(); - prints out the recently added person
         */
        static void AddNewContact(List<Person> Dict)
        {
            Dict.Add(new Person());
            Dict[Dict.Count() - 1].Print();
        }
        /* Method: Contacts() (static)
         * PURPOSE: Store textfile lines as new person to Dict list
         * PARAMETERS: List<Person> Dict - lists of person classes
         * RETURN VALUE: Return value is void
         */
        static void Contacts(List<Person> Dict)
        {
            StreamReader fileStream = new StreamReader(@"C:\Users\vikke\Desktop\AdressLista2.lis");
            while (fileStream.Peek() >= 0)
            {
                string line = fileStream.ReadLine();
                string[] word = line.Split('#');
                Person P = new Person(word[0], word[1], word[2], word[3]);
                Dict.Add(P);
            }
        }
    }
}