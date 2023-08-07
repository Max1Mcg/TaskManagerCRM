using EFC0re.Repositories.Interfaces;
using EFC0re.RPCCounter;
using EFC0re.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EFC0re.Services
{
    public class DataService:IDataService
    {
        const int milisecInSecond = 1000;
        IDataRepository _dataRepository;
        ISettingsService _settingsService;
        //Классы-измерители
        public DataService(IDataRepository dataRepository,
            ISettingsService settingsService)
        {
            _settingsService = settingsService;
            _dataRepository = dataRepository;
        }
        public int CPULoading()
        {
            //PerformanceCounter cpuCounter = new PerformanceCounter();
            /*cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";*/
            // will always start at 0
            //float firstValue = cpuCounter.NextValue();
            //System.Threading.Thread.Sleep(1000);
            //теперь значение есть
            float secondValue = RPCCpunter.cpuCounter.NextValue();
            return (int)secondValue;
        }
        public int RAMLoading()
        {
            PerformanceCounter memoryCounter = new PerformanceCounter("Memory", "Available Bytes");
            PerformanceCounter totalMemoryCounter = new PerformanceCounter("Memory", "Committed Bytes");
            float availableMemory = memoryCounter.NextValue();
            float totalMemory = totalMemoryCounter.NextValue();
            float freeMemoryPercentage = (availableMemory / totalMemory) * 100;
            return (int)freeMemoryPercentage;
            //Task.Delay();
        }
        public Guid CreateInstanceAuto(bool auto = true)
        {
            var newData = new Data
            {
                Iddata = Guid.NewGuid(),
                Period = auto == true ? _settingsService.GetPeriod() : 0,
                CreatedAt = DateTime.Now,
                CpuLoading = CPULoading(),
                RamLoading = RAMLoading(),
                Rpc = RPCCpunter.count
            };
            _dataRepository.Create(newData);
            return newData.Iddata;
        }
        public Data GetOneData(Guid id)
        {
            return _dataRepository.Get(id);
        }
        public  IEnumerable<Data> GetRange(DateTime start, DateTime end)
        {
            return _dataRepository.GetAll().Where(d => d.CreatedAt >= start && d.CreatedAt <= end);
        }
        public IEnumerable<Data> GetLasts(int count)
        {
            return _dataRepository.GetAll().OrderByDescending(i => i.CreatedAt).Take(count);
        }
    }
}