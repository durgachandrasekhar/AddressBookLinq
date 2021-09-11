using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBook_LINQ
{
    class AddressBookTable
    {
        public DataTable AddAddressBookDataTable()
        {
            //DataTable 
            DataTable table = new DataTable();

            //Add Columns
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(int));
            table.Columns.Add("PhoneNumber", typeof(long));
            table.Columns.Add("Email", typeof(string));

            //Values Assign to Rows
            table.Rows.Add("Rahul", "Sharma", "DL", "DL", "DL", 100001, 997325546, "rahul@gmail.com");
            table.Rows.Add("Dhawan", "Shikhar", "PUN", "PUN", "PUN", 200002, 999000880, "dhawan@gmail.com");
            table.Rows.Add("Virat", "Kohli", "Panji", "Panaji", "Goa", 300003, 7777743210, "virat@gmail.com");
            table.Rows.Add("Ravi", "Jadeja", "GUJ", "GUJ", "GUJ", 400004, 7877743990, "ravi@gmail.com");
            table.Rows.Add("Jasprit", "Bumrah", "HAR", "HAR", "HAR", 500005, 7888743210, "bumbum@gmail.com");

            return table;
        }
        //Display Contacts
        public void DisplayContacts(DataTable addresstable)
        {
            var contacts = addresstable.Rows.Cast<DataRow>();

            foreach (var contact in contacts)
            {
                Console.WriteLine("First Name : " + contact.Field<string>("FirstName") + " | " + "Last Name : " + contact.Field<string>("LastName") + " | " + "Address : " + contact.Field<string>("Address") + " | " + "City : " + contact.Field<string>("City") + " | " + "State : " + contact.Field<string>("State")
                    + " | " + "Zip : " + contact.Field<int>("Zip") + " | " + "Phone Number : " + contact.Field<long>("PhoneNumber") + " | " + "Email : " + contact.Field<string>("Email") + " ");
                Console.WriteLine();
            }
        }
    }
}