using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AddressBook_LINQ
{
    class AddressBookTable
    {
        public void CreateAddressBookDataTable()
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
        }
    }
}