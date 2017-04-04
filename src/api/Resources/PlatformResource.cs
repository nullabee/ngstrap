using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using api.Data;

namespace api.Resources
{
    public class PlatformResource : IResource<Platform>
    {
        private readonly WorkContext context;

        public PlatformResource(WorkContext context)
        {
            this.context = context;
        }

        public IEnumerable<Platform> GetAll()
        {
            return context.Platforms;
        }

        public Platform Find(int key)
        {
            return context.Platforms
                .Where(r => r.PlatformID.Equals(key))
                .SingleOrDefault();
        }

        public void Add(Platform item)
        {
            context.Platforms.Add(item);
            context.SaveChanges();
        }

        public bool Remove(int key)
        {
            var res = Find(key);
            if (res != null)
            {
                context.Platforms.Remove(res);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Platform item)
        {
            var res = Find(item.PlatformID);
            if (res != null)
            {
                res.PlatformName = item.PlatformName;
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
