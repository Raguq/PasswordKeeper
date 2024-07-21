using PasswordKeeper.Core.Data;
using PasswordKeeper.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper.Core.Service
{
    public class TabService
    {
        private DataTab _dataSource;
        private List<Tab> _tabs = new List<Tab>();
        public TabService(DataTab dataSource)
        {
            _dataSource = dataSource;
            _tabs = _dataSource.Get() ?? new List<Tab>();
        }
        public List<Tab> GetAll()
        {
            return _tabs;
        }

        public Tab Get(int id)
        {
            foreach (Tab tab in _tabs)
                if (tab.Id == id) return tab;
            return null;
        }
        public void Create(Tab tab)
        {
            _tabs.Add(tab);
            _dataSource.Write(_tabs);
        }

        public void Delete(int id)
        {
            foreach (Tab tab in _tabs)
            {
                if (tab.Id == id)
                {
                    _tabs.Remove(tab);
                    break;
                }
            }
            _dataSource.Write(_tabs);
        }

        public void Update(Tab tab)
        {
            for (int i = 0; i < _tabs.Count; i++)
            {
                if (tab.Id != _tabs[i].Id)
                    _tabs[i] = tab;
            }
            _dataSource.Write(_tabs);
        }
    }
}
