using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC0re.Services.Interfaces
{
    public interface IDataService
    {
         Guid CreateInstanceAuto(bool auto);
         Data GetOneData(Guid id);
         IEnumerable<Data> GetRange(DateTime start, DateTime end);
         IEnumerable<Data> GetLasts(int count);
    }
}
