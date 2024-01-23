using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicNestWebApi.DataSettings
{
    public class DataBaseSettings
    {
        public string ConnectionString { get; set; } = null;
        public string DataBaseName { get; set; } = null;

        public string CollectionName { get; set; } = null;
        public DataBaseSettings() { }
    }
}
