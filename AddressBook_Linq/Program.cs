using System;
using System.Data;

namespace AddressBook_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Display Welcome Message
            Console.WriteLine("*****  Welcome To AddressBook Using LINQ  *****");
            Console.WriteLine("===============================================");

            //Object of AddressBookTable Class
            AddressBookTable addressBookTable = new AddressBookTable();

            DataTable dataTable = addressBookTable.AddAddressBookDataTable();
            //addressBookTable.EditContact(dataTable);
            //addressBookTable.DeleteContact(dataTable);
            //addressBookTable.DisplayContacts(dataTable);
            //addressBookTable.RetrieveContactByCityOrState(dataTable);
            addressBookTable.GetSizeByCityOrState(dataTable);
        }
    }
}