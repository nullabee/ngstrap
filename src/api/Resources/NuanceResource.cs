using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Resources
{
    public class NuanceResource : IResource<Nuance>
    {
        private readonly DataContext context;

        public NuanceResource(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Nuance>> ListAsync()
        {
            return await context.Nuances.AsNoTracking()
                .Include(n => n.Waypoints)
                .ToListAsync();
        }

        public async Task<Nuance> FindAsync(int key)
        {
            return await context.Nuances
                .Where(r => r.NuanceID.Equals(key))
                .SingleOrDefaultAsync();
        }

        public async Task<int> AddAsync(Nuance item)
        {
            await context.Nuances.AddAsync(item);
            return await context.SaveChangesAsync();
        }

        public async Task<int> AddRangeAsync(Nuance[] items)
        {
            await context.Nuances.AddRangeAsync(items);
            return await context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(int key)
        {
            var res = await FindAsync(key);
            if (res != null)
            {
                context.Nuances.Remove(res);
                return await context.SaveChangesAsync();
            }
            return await Task.FromResult(0);
        }

        public async Task<int> UpdateAsync(Nuance item)
        {
            var res = await FindAsync(item.NuanceID);
            if (res != null)
            {
                res.Title = item.Title;
                res.Description = item.Description;
                return await context.SaveChangesAsync();
            }
            return await Task.FromResult(0);
        }
    }
}
