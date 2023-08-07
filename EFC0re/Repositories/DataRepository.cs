using EFC0re.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFC0re.Repositories
{
    public class DataRepository:BaseRepository<Data>, IDataRepository
    {
        public DataRepository(WebSiteContext context):base(context) { }
        public Data Get(Guid id)
        {
            return _set.FirstOrDefault(i => i.Iddata == id);
        }
        public IEnumerable<Data> GetAll()
        {
            return _set.ToList();
        }
    }
}