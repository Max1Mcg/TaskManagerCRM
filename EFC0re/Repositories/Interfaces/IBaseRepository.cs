using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC0re.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(object id);
    }
}
