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
        public BaseRepository(WebSiteContext context)
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
            //ужасная затычка на удаление дублирующего элемента, который выкидывает исключение, исправить
            _set.Remove(_set.FirstOrDefault());
            _context.Update(entity);
            _set.Add(entity);
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