using PasswordKeeper.Core.Data;
using PasswordKeeper.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper.Core.Service
{
    /// <summary>
    /// Класс, осуществляющий доступ для работы с записями
    /// </summary>
    public class NoteService
    {
        private DataNote _dataSource;
        private List<Note> _notes = new List<Note>();
        public NoteService(DataNote dataSource)
        {
            _dataSource = dataSource;
            _notes = _dataSource.Get() ?? new List<Note>();
        }
        public List<Note> GetAll()
        {
            return _notes;
        }

        public Note Get(int id)
        {
            foreach (Note note in _notes)
                if (note.ItemId == id) return note;
            return null;
        }
        public void Create(Note note)
        {
            _notes.Add(note);
            _dataSource.Write(_notes);
        }

        public void Delete(int id)
        {
            foreach (Note note in _notes)
            {
                if (note.ItemId == id)
                {
                    _notes.Remove(note);
                    break;
                }
            }
            _dataSource.Write(_notes);
        }

        public void Update(Note note)
        {
            for (int i = 0; i < _notes.Count; i++)
            {
                if (note.ItemId != _notes[i].ItemId)
                    _notes[i] = note;
            }
            _dataSource.Write(_notes);
        }
    }
}
