using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordKeeper.Core.Entity;
using PasswordKeeper.Core.Utility;

namespace PasswordKeeper.Core.Data
{
    public class DataLink
    {
        /// <summary>
        /// Класс для сохранения и записи ссылок в JSON 
        /// </summary>
        private readonly string path = ".\\link_data.json";
        public List<Link> Get()
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string data = reader.ReadToEnd();
                    var tmp = DataSerializer.Deserialize<List<Link>>(data) ?? [];
                    Link.idCounter = tmp.Count > 0 ? tmp.Select(x => x.ItemId).Max() + 1 : 0;
                    return tmp;
                }
            }
            return [];
        }
        public void Write(List<Link> data)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(DataSerializer.Serialize(data));
            }
        }
    }
}
