using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper.Core.Entity
{
    /// <summary>
    /// Класс для сохранения простых записей
    /// </summary>
    public class Note
    {
        public static int idCounter = 0;
        public Note (string title, string description)
        {
            ItemId = idCounter++;
            Title = title;
            Description = description;
        }
        [JsonProperty(PropertyName = "ItemId")]
        public int ItemId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return Title + " " + Description;
        }
    }
}
