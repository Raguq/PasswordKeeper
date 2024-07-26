using PasswordKeeper.Core.Entity;
using PasswordKeeper.Core.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper.App
{
    public class LinkViewModel : ObservableObject
    {
        private LinkService linkService;

        private ObservableCollection<Link> _linklist;
        private Link _selectedLink;
        public ObservableCollection<Link> LinkList {
            get => _linklist;
            set
            {
                _linklist = value;
                OnPropertyChanged("LinkList");
            }
        }
        public Link SelectedLink
        {
            get => _selectedLink;
            set
            {
                _selectedLink = value;
                OnPropertyChanged("SelectedLink");
            }
        }

        public LinkViewModel(LinkService link)
        {
            linkService = link;
            LinkList = new ObservableCollection<Link>(linkService.GetAll());

        }

        private string _input = string.Empty;
        private string _input2 = string.Empty;
        public string InputTitle
        {
            get => _input; set
            {
                _input = value;
                OnPropertyChanged("InputTitle");
            }
        }
        public string InputDescription
        {
            get => _input2; set
            {
                _input2 = value;
                OnPropertyChanged("InputDescription");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      linkService.Create(
                          new Link(InputTitle, InputDescription)
                          );
                      LinkList = new ObservableCollection<Link>(linkService.GetAll());
                  }));
            }
        }
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(obj =>
                    {
                        linkService.Delete(
                            SelectedLink.ItemId
                            );
                        LinkList = new ObservableCollection<Link>(linkService.GetAll());
                    }));
            }
        }
        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand(obj =>
                  {
                      SelectedLink.Name = InputTitle;
                      SelectedLink.Description = InputDescription;
                      linkService.Update(
                          SelectedLink
                          );
                      LinkList = new ObservableCollection<Link>(linkService.GetAll());
                  }));
            }
        }
    }
}
