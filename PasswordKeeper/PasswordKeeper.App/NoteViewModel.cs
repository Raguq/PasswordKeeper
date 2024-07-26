using PasswordKeeper.App;
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
    public class NoteViewModel : ObservableObject
    {
        private ObservableCollection<Note> _noteList = new ObservableCollection<Note>();
        public ObservableCollection<Note> NoteList { get => _noteList; set { _noteList = value; OnPropertyChanged("NoteList"); } }
        private NoteService noteService;
        private Note _notelist;
        private Note _selectedNote;
        public Note SelectedNote
        {
            get => _selectedNote;
            set
            {
                _selectedNote = value;
                OnPropertyChanged("SelectedNote");
            }
        }

        public NoteViewModel(NoteService note)
        {
            noteService = note;
            NoteList = new ObservableCollection<Note>(noteService.GetAll());

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
                      noteService.Create(
                          new Note (InputTitle, InputDescription)
                          );
                      NoteList = new ObservableCollection<Note> (noteService.GetAll());
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
                    noteService.Delete(
                        SelectedNote.ItemId
                        );
                    NoteList = new ObservableCollection<Note> (noteService.GetAll());
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
                      SelectedNote.Title = InputTitle;
                      SelectedNote.Description = InputDescription;
                      noteService.Update(
                          SelectedNote
                          );
                      NoteList = new ObservableCollection<Note>(noteService.GetAll());
                  }));
            }
        }
    }
}
