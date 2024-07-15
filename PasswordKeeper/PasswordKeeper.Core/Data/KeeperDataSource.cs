using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordKeeper.Core.Entity;
using PasswordKeeper.Core.Utility;

namespace PasswordKeeper.Core.Data
{
    public class KeeperDataSource
    {
        /// <summary>
        /// Класс для сохранения и записи JSON запросов
        /// </summary>
        private readonly string path = ".\\data.json";
        public List<Note> Get()
        {
            if (File.Exists(path))
            {
                string data = File.ReadAllText(path);
                return DataSerializer.Deserialize<List<Note>>(data);
            }
            return null;
        }
        public void Write(List<Note> data)
        {
            File.WriteAllText(path, DataSerializer.Serialize(data));
        }
    }
}
