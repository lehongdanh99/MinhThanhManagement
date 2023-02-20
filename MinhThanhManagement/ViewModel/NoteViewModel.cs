using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhThanhManagement.ViewModel
{
    internal class NoteViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _notes = new ObservableCollection<string>();
        public ObservableCollection<string> Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public void AddNote()
        {
            if (!string.IsNullOrWhiteSpace(NewNote))
            {
                Notes.Add(NewNote);
                NewNote = string.Empty;
                Status = "Note added.";
            }
            else
            {
                Status = "Please enter a note.";
            }
        }

        private string _newNote;

        public event PropertyChangedEventHandler PropertyChanged;

        public string NewNote
        {
            get { return _newNote; }
            set { _newNote = value; }
        }
    }
}
