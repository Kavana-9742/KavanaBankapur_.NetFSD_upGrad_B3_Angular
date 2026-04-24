using System;
using System.Collections.Generic;
using System.Text;
using week_10_day1.Models;

namespace week_10_day1.Services
{
    internal interface IContactService
    {
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
        List<Contact> GetAllContacts();
    }
}
