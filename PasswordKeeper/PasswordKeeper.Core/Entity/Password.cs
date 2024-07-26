using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper.Core.Entity
{
    /// <summary>
    /// Класс для сохранения паролей
    /// </summary>
    public class Password
    {
        public static int idCounter = 0;
        public Password(string nameOfSmth, string login, string passwordSecure)
        {
            ItemId = idCounter++;
            NameOfSmth = nameOfSmth;
            Login = login;
            PasswordSecure = passwordSecure;
        }
        [JsonProperty(PropertyName = "ItemId")]
        public int ItemId { get; set; }
        public string NameOfSmth { get; set; }
        public string Login { get; set; }
        public string PasswordSecure { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return NameOfSmth + " " + Login + " " + PasswordSecure;
        }
    }

}
