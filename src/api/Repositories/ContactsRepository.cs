using System.Collections.Generic;
using System.Linq;
using api.Models;

namespace api.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private static List<Contacts> ContactsList = new List<Contacts>();

        public IEnumerable<Contacts> GetAll()
        {
            return ContactsList;
        }

        public Contacts Find(string key)
        {
            return ContactsList
                .Where(e => e.MobilePhone.Equals(key))
                .SingleOrDefault();
        }

        public void Add(Contacts item)
        {
            ContactsList.Add(item);
        }

        public void Remove(string key)
        {
            var itemToRemove = ContactsList.SingleOrDefault(r => r.MobilePhone == key);
            if (itemToRemove != null)
                ContactsList.Remove(itemToRemove);
        }

        public void Update(Contacts item)
        {
            var itemToUpdate = ContactsList.SingleOrDefault(r => r.MobilePhone == item.MobilePhone);
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.LastName = item.LastName;
                itemToUpdate.IsFamilyMember = item.IsFamilyMember;
                itemToUpdate.Company = item.Company;
                itemToUpdate.JobTitle = item.JobTitle;
                itemToUpdate.Email = item.Email;
                itemToUpdate.MobilePhone = item.MobilePhone;
                itemToUpdate.DateOfBirth = item.DateOfBirth;
                itemToUpdate.AnniversaryDate = item.AnniversaryDate;
            }
        }
    }
}
