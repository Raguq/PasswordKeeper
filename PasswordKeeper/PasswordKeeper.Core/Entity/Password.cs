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
        public int Id { get; set; }
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
