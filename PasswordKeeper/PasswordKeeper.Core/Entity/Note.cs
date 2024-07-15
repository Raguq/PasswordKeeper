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
    public class Note(string title, string description)
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = title;

        public string Description { get; set; } = description;

        public override string ToString()
        {
            return Title + " " + Description;
        }
    }
}
