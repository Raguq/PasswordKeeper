using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordKeeper.Core.Entity;
using PasswordKeeper.Core.Utility;

namespace PasswordKeeper.Core.Data
{
    public class DataTab
    {
        /// <summary>
        /// Класс для сохранения и записи вкладок в JSON 
        /// </summary>
        private readonly string path = ".\\tab_data.json";
        public List<Tab> Get()
        {
            if (File.Exists(path))
            {
                string data = File.ReadAllText(path);
                return DataSerializer.Deserialize<List<Tab>>(data);
            }
            return [];
        }
        public void Write(List<Tab> data)
        {
            File.WriteAllText(path, DataSerializer.Serialize(data));
        }
    }
}
