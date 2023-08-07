using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFC0re.Repositories.Interfaces
{
    public interface IDataRepository:IBaseRepository<Data>
    {
        Data Get(Guid id);
        IEnumerable<Data> GetAll();
    }
}