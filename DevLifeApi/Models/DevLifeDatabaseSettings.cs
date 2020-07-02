using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevLifeApi.Models
{
    public class DevLifeDatabaseSettings : IDevLifeDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDevLifeDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
