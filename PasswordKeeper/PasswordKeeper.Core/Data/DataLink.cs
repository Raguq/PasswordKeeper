﻿using System;
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
                string data = File.ReadAllText(path);
                return DataSerializer.Deserialize<List<Link>>(data);
            }
            return null;
        }
        public void Write(List<Link> data)
        {
            File.WriteAllText(path, DataSerializer.Serialize(data));
        }
    }
}
