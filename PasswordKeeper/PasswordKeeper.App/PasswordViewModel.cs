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
    public class PasswordViewModel : ObservableObject
    {
        private PasswordService passwordService;

        private ObservableCollection<Password> _passwordlist;
        private Password _selectedPassword;
        public ObservableCollection<Password> PasswordList
        {
            get => _passwordlist;
            set
            {
                _passwordlist = value;
                OnPropertyChanged("PasswordList");
            }
        }
        public Password SelectedPassword
        {
            get => _selectedPassword;
            set
            {
                _selectedPassword = value;
                OnPropertyChanged("SelectedPassword");
            }
        }

        public PasswordViewModel(PasswordService password)
        {
            passwordService = password;
            PasswordList = new ObservableCollection<Password>(passwordService.GetAll());

        }

        private string _name = string.Empty;
        private string _login = string.Empty;
        private string _password = string.Empty;
        public string InputName
        {
            get => _name; set
            {
                _name = value;
                OnPropertyChanged("InputName");
            }
        }
        public string InputLogin
        {
            get => _login; set
            {
                _login = value;
                OnPropertyChanged("InputLogin");
            }
        }
        public string InputPassword
        {
            get => _password; set
            {
                _password = value;
                OnPropertyChanged("InputPassword");
            }
        }

        private string _output = string.Empty; public string Output
        {
            get => _output;
            set
            {
                _output = value; OnPropertyChanged("Output");
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
                      passwordService.Create(
                          new Password(InputName, InputLogin, InputPassword)
                          );
                      PasswordList = new ObservableCollection<Password>(passwordService.GetAll());
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
                        passwordService.Delete(
                            SelectedPassword.ItemId
                            );
                        PasswordList = new ObservableCollection<Password>(passwordService.GetAll());
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
                      SelectedPassword.NameOfSmth = InputName;
                      SelectedPassword.Login = InputLogin;
                      SelectedPassword.PasswordSecure = InputPassword;
                      passwordService.Update(
                          SelectedPassword
                          );
                      PasswordList = new ObservableCollection<Password>(passwordService.GetAll());
                  }));
            }
        }
    }
}
