using PasswordKeeper.Core.Data;
using PasswordKeeper.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper.Core.Service
{
    public class LinkService
    {
        private DataLink _dataSource;
        private List<Link> _links = new List<Link>();
        public LinkService(DataLink dataSource)
        {
            _dataSource = dataSource;
            _links = _dataSource.Get() ?? new List<Link>();
        }
        public List<Link> GetAll()
        {
            return _links;
        }

        public Link Get(int id)
        {
            foreach (Link link in _links)
                if (link.Id == id) return link;
            return null;
        }
        public void Create(Link link)
        {
            _links.Add(link);
            _dataSource.Write(_links);
        }

        public void Delete(int id)
        {
            foreach (Link link in _links)
            {
                if (link.Id == id)
                {
                    _links.Remove(link);
                    break;
                }
            }
            _dataSource.Write(_links);
        }

        public void Update(Link link)
        {
            for (int i = 0; i < _links.Count; i++)
            {
                if (link.Id != _links[i].Id)
                    _links[i] = link;
            }
            _dataSource.Write(_links);
        }
    }
}
