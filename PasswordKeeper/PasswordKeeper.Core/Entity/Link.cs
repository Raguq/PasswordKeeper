using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper.Core.Entity
{
    /// <summary>
    /// Класс для сохранения ссылок
    /// </summary>
    public class Link
    {
        public static int idCounter = 0;
        public Link(string name = "", string description = "")
        {
            ItemId = idCounter++;
            Name = name;
            Description = description;
        }
        [JsonProperty(PropertyName = "ItemId")]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public override string ToString()
        {
            return Name + " " + Description;
        }
    }
}
