using EFC0re.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EFC0re.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly WebSiteContext _context;
        protected readonly DbSet<T> _set;
        WebSiteContext context;
        public BaseRepository(WebSiteContext context)//WebSiteCodeFirstContext context
        {
            _context = context;
            _set = _context.Set<T>();
        }
        public async Task Create(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(object id)
        {
            _set.Remove(await _set.FindAsync(id));
            await _context.SaveChangesAsync();
        }
        //get не ясно как сделать из-за разных параметров
    }
}