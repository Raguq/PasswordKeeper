using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordKeeper.Core.Entity;
using PasswordKeeper.Core.Utility;

namespace PasswordKeeper.Core.Data
{
    public class DataPassword
    {
        /// <summary>
        /// Класс для сохранения и записи пароля в JSON
        /// </summary>
        private readonly string path = ".\\password_data.json";
        public List<Password> Get()
        {
            if (File.Exists(path))
            {
                string data = File.ReadAllText(path);
                return DataSerializer.Deserialize<List<Password>>(data);
            }
            return null;
        }
        public void Write(List<Password> data)
        {
            File.WriteAllText(path, DataSerializer.Serialize(data));
        }
    }
}
