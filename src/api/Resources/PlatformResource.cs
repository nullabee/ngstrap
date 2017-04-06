using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Resources
{
    public class PlatformResource : IResource<Platform>
    {
        private readonly DataContext context;

        public PlatformResource(DataContext context)
        {
            this.context = context;
        }

        //public IEnumerable<Platform> List()
        //{
        //    return context.Platforms.AsNoTracking().ToList();
        //}

        public async Task<List<Platform>> ListAsync()
        {
            return await context.Platforms.AsNoTracking().ToListAsync();
        }

        //public async Task<Platform> FindAsync(int key)
        //{
        //    return await context.Platforms
        //        .Where(r => r.PlatformID.Equals(key))
        //        .SingleOrDefaultAsync();
        //}

        //public async Task<int> AddAsync(Platform item)
        //{
        //    await context.Platforms.AddAsync(item);
        //    return await context.SaveChangesAsync();
        //}

        //public async Task<int> RemoveAsync(int key)
        //{
        //    var res = await FindAsync(key);
        //    if (res != null)
        //    {
        //        context.Platforms.Remove(res);
        //        return await context.SaveChangesAsync();

        //    }
        //    return await Task.FromResult(0);
        //}

        //public async Task<int> UpdateAsync(Platform item)
        //{
        //    var res = await FindAsync(item.PlatformID);
        //    if (res != null)
        //    {
        //        res.PlatformName = item.PlatformName;
        //        return await context.SaveChangesAsync();
        //    }

        //    return await Task.FromResult(0);
        //}
    }
}
