using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordKeeper.Core.Entity;
using PasswordKeeper.Core.Utility;

namespace PasswordKeeper.Core.Data
{
    public class DataNote
    {
        /// <summary>
        /// Класс для сохранения и записи заметок в JSON
        /// </summary>
        private readonly string path = ".\\note_data.json";
        public List<Note> Get()
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string data = reader.ReadToEnd();
                    var tmp = DataSerializer.Deserialize<List<Note>>(data) ?? [];
                    Note.idCounter = tmp.Count > 0 ? tmp.Select(x => x.ItemId).Max() + 1 : 0;
                    return tmp;
                }
            }
            return [];
        }
        public void Write(List<Note> data)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(DataSerializer.Serialize(data));
            }
        }
    }
}
