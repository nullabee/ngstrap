using System.Collections.Generic;
using System.Linq;
using api.Models;

namespace api.Resources
{
    public class ContactResource : IResource<Contact>
    {
        private static List<Contact> contacts = new List<Contact>();

        public IEnumerable<Contact> GetAll()
        {
            return contacts;
        }

        public Contact Find(string key)
        {
            return contacts
                .Where(r => r.MobilePhone.Equals(key))
                .SingleOrDefault();
        }

        public void Add(Contact item)
        {
            contacts.Add(item);
        }

        public void Remove(string key)
        {
            var res = contacts.SingleOrDefault(r => r.MobilePhone == key);
            if (res != null)
                contacts.Remove(res);
        }

        public void Update(Contact item)
        {
            var res = contacts.SingleOrDefault(r => r.MobilePhone == item.MobilePhone);
            if (res != null)
            {
                res.FirstName = item.FirstName;
                res.LastName = item.LastName;
                res.IsFamilyMember = item.IsFamilyMember;
                res.Company = item.Company;
                res.JobTitle = item.JobTitle;
                res.Email = item.Email;
                res.MobilePhone = item.MobilePhone;
                res.DateOfBirth = item.DateOfBirth;
                res.AnniversaryDate = item.AnniversaryDate;
            }
        }
    }
}
