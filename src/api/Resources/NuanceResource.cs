using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using api.Models;
using api.Data;

namespace api.Resources
{
    public class NuanceResource : IResource<Nuance>
    {
        private readonly DataContext context;
        
        public NuanceResource(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Nuance>> GetAll()
        {
            return await context.Nuances.ToListAsync();
        }

        public Task<Nuance> Find(int key)
        {
            return context.Nuances
                .Where(r => r.NuanceID.Equals(key))
                .SingleOrDefaultAsync();
        }

        public async Task Add(Nuance item)
        {
            context.Nuances.Add(item);
            context.SaveChanges();
            return new Task();
        }

        public async Task<bool> Remove(int key)
        {
            var res = await Find(key);
            if (res != null)
            {
                context.Nuances.Remove(res);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> Update(Nuance item)
        {
            var res = await Find(item.NuanceID);
            if (res != null)
            {
                res.Title = item.Title;
                res.Description = item.Description;
                res.UserID = item.UserID;
                context.SaveChanges();
                return true;
            }

            return false;           
        }
    }
}
