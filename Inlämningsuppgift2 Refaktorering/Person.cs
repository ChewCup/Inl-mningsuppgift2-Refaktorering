using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift2_Refaktorering.People
{
    /* CLASS: Person
     * PURPOSE: Creates a class of a person with parameters name, address, phone and email of the person 
     */
    public class Person
    {
        public string name, address, phone, email;
        public Person(string Name, string Address, string Phone, string Email)
        {
            this.name = Name;
            this.address = Address;
            this.phone = Phone;
            this.email = Email;
        }
        /* Constructor: Person()
         * PURPOSE: Creates a person with input values by user
         * PARAMETERS: none
         * RETURN VALUE: Return value is void
         */
        public Person()
        {
            Console.WriteLine("Lägger till ny person");
            Console.Write("  1. ange namn:    ");
            string name = Console.ReadLine();
            Console.Write("  2. ange adress:  ");
            string address = Console.ReadLine();
            Console.Write("  3. ange telefon: ");
            string phone = Console.ReadLine();
            Console.Write("  4. ange email:   ");
            string email = Console.ReadLine();
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.email = email;
        }
        /* Method: Print()
         * PURPOSE: Printing out all details of person on list
         * PARAMETERS: none
         * RETURN VALUE: Return value is void but prints out a text of person info  
         */
        public void Print()
        {
            Console.WriteLine("{0} {1} {2} {3}", name, address, phone, email);
        }
        /* Method: EditContactInfo()
        * PURPOSE: Change Dict list person info to (string) value
        * PARAMETERS: (string) personInfo, (string) value
        * RETURN VALUE: Return value is void  
        */
        public void EditContactInfo(string personInfo, string value)
        {
            switch (personInfo)
            {
                case "namn": name = value; break;
                case "adress": address = value; break;
                case "telefon": phone = value; break;
                case "email": email = value; break;
                default: break;
            }
        }
    }
}
