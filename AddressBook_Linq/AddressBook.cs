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
            table.Columns.Add("AddressBookName", typeof(string));
            table.Columns.Add("AddressBookType", typeof(string));

            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(int));
            table.Columns.Add("PhoneNumber", typeof(long));
            table.Columns.Add("Email", typeof(string));

            //Values Assign to Rows
            table.Rows.Add("AB1", "Friend", "Rahul", "Sharma", "DL", "DL", "DL", 100001, 997325546, "rahul@gmail.com");
            table.Rows.Add("AB2", "Friend", "Dhawan", "Shikhar", "PUN", "PUN", "PUN", 200002, 999000880, "dhawan@gmail.com");
            table.Rows.Add("AB3", "Family", "Virat", "Kohli", "Panji", "Panaji", "Goa", 300003, 7777743210, "virat@gmail.com");
            table.Rows.Add("AB4", "Family", "Ravi", "Jadeja", "GUJ", "GUJ", "GUJ", 400004, 7877743990, "ravi@gmail.com");
            table.Rows.Add("AB5", "Profession", "Jasprit", "Bumrah", "HAR", "HAR", "HAR", 500005, 7888743210, "bumbum@gmail.com");

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
        //Edit Contact using Name
        public void EditContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Rahul");
            int count = contacts.Count();
            if (count > 0)
            {
                foreach (var contact in contacts)
                {
                    contact.SetField("LastName", "Lokesh");
                    contact.SetField("City", "Mumbai");
                    contact.SetField("State", "Maharashtra");
                }
                Console.WriteLine("The Contact is updated succesfully\n");
            }
            else
                Console.WriteLine("Contact is Not in the List");
            DisplayContacts(contacts.CopyToDataTable());
        }
        //Delete Contact Using Name
        public void DeleteContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Jasprit");
            int count = contacts.Count();
            if (count > 0)
            {
                foreach (var row in contacts.ToList())
                {
                    row.Delete();
                    Console.WriteLine("The Contact is deleted succesfully. Now the list contains following records \n");
                }
            }
            else
                Console.WriteLine("Contact is Not in the List");
            DisplayContacts(table);
        }
        //Retriving Contact By City or State
        public void RetrieveContactByCityOrState(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("State") == "GUJ");
            int count = contacts.Count();
            if (count > 0)
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine("First Name : " + contact.Field<string>("FirstName") + " | " + "Last Name : " + contact.Field<string>("LastName") + " | " + "Address : " + contact.Field<string>("Address") + " | " + "City : " + contact.Field<string>("City") + " | " + "State : " + contact.Field<string>("State")
                        + " | " + "Zip : " + contact.Field<int>("Zip") + " | " + "Phone Number : " + contact.Field<long>("PhoneNumber") + " | " + "Email : " + contact.Field<string>("Email") + " ");
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("City or State is Not in the List");
        }
        //Get count By City or State
        public void GetSizeByCityOrState(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>().GroupBy(x => x["State"].Equals("GUJ")
            || x["City"].Equals("Maharashtra")).Count();

            Console.WriteLine("Size : {0} ", contacts);
        }

        //Sort Alphabetically
        public void SortContacts(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                           .OrderBy(x => x.Field<string>("FirstName"));
            DisplayContacts(contacts.CopyToDataTable());
        }
        //Get Number of Contact Person, COunt By Type
        public void GetCountByType(DataTable table)
        {
            var friendsContacts = table.Rows.Cast<DataRow>()
                                         .Where(x => x["AddressBookType"].Equals("Friend")).Count();
            Console.WriteLine("'Friend' : {0} ", friendsContacts);
            var familyContact = table.Rows.Cast<DataRow>()
                             .Where(x => x["AddressBookType"].Equals("Family")).Count();
            Console.WriteLine("'Family' : {0} ", familyContact);
            var ProfessionalContact = table.Rows.Cast<DataRow>()
                             .Where(x => x["AddressBookType"].Equals("Profession")).Count();
            Console.WriteLine("'Profession' : {0} ", ProfessionalContact);
        }
        //Add Contact
        public void AddPersonToFriendsAndFamily(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                            .Where(x => x["FirstName"].Equals("Rahul"));

            Console.WriteLine("\nAdded New Contact in Both Family And Friends");
            DisplayContacts(contacts.CopyToDataTable());
        }
    }
}