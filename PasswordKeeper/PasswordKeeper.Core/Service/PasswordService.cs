using PasswordKeeper.Core.Data;
using PasswordKeeper.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper.Core.Service
{
    public class PasswordService
    {
        private DataPassword _dataSource;
        private List<Password> _passwords = new List<Password>();
        public PasswordService(DataPassword dataSource)
        {
            _dataSource = dataSource;
            _passwords = _dataSource.Get() ?? new List<Password>();
        }
        public List<Password> GetAll()
        {
            return _passwords;
        }

        public Password Get(int id)
        {
            foreach (Password password in _passwords)
                if (password.ItemId == id) return password;
            return null;
        }
        public void Create(Password password)
        {
            _passwords.Add(password);
            _dataSource.Write(_passwords);
        }

        public void Delete(int id)
        {
            foreach (Password password in _passwords)
            {
                if (password.ItemId == id)
                {
                    _passwords.Remove(password);
                    break;
                }
            }
            _dataSource.Write(_passwords);
        }

        public void Update(Password password)
        {
            for (int i = 0; i < _passwords.Count; i++)
            {
                if (password.ItemId != _passwords[i].ItemId)
                    _passwords[i] = password;
            }
            _dataSource.Write(_passwords);
        }
    }
}
