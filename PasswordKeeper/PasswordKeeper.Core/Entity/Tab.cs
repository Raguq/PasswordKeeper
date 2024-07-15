﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper.Core.Entity
{
    /// <summary>
    /// Класс для создания вкладок
    /// </summary>
    public class Tab
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TabType Type { get; set; }
        public List<int> Ids { get; set; }
    }

    public enum TabType
    {
        Password,
        Note,
        Link
    }
}
