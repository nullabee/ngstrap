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

        public bool Remove(string key)
        {
            var res = Find(key);
            if (res != null)
            {
                contacts.Remove(res);
                return true;
            }
            return false;
        }

        public bool Update(Contact item)
        {
            var res = Find(item.MobilePhone);
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
                return true;
            }
            return false;
        }
    }
}
