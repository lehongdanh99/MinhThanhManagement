using GalaSoft.MvvmLight.Command;
using MinhThanhManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using static MinhThanhManagement.CommonMethod;

namespace MinhThanhManagement.ViewModel
{
    public class NoteViewModel : INotifyPropertyChanged
    {
        public ICommand SaveNoteCommand { get; private set; }

        public ICommand DeleteNoteCommand { get; private set; }

        public ICommand ReloadNoteCommand { get; private set; }

        public ICommand AddNoteCommand { get; private set; }


        CommonMethod commonMethod = new CommonMethod();
        public NoteViewModel() {

            AddNoteCommand = new RelayCommand(AddNote);
            ReloadNoteCommand = new RelayCommand(ReloadNote);
            SaveNoteCommand = new RelayCommand(SaveNote);
            DeleteNoteCommand = new RelayCommand(DeleteNote);

            ListNotes = commonMethod.ReadNoteFileCsv();
            GlobalDef.ListNotesModel = commonMethod.ReadNoteFileCsv();
            ListDataNote = CollectionViewSource.GetDefaultView(ListNotes);
        }


        private static NoteViewModel _instance;
        public static NoteViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NoteViewModel();
            }
            return _instance;
        }


        private ObservableCollection<NotesModel> _listNotes = new ObservableCollection<NotesModel>();
        private int notificationCount;
        private DateTime dateStart;
        private DateTime dateEnd;

        public DateTime DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; }
        }

        public DateTime DateStart
        {
            get { return dateStart; }
            set { dateStart = value; }
        }

        public int NotificationCount
        {
            get { return notificationCount; }
            set { notificationCount = value; }
        }

        private string textToFilter = "";

        public string TextToFilter
        {
            get { return textToFilter.ToUpper(); }
            set { textToFilter = value; ListDataNote.Filter = FilterByName; }
        }
        private ICollectionView listDataNote;

        public ICollectionView ListDataNote
        {
            get { return listDataNote; }
            set { listDataNote = value; }
        }


        public ObservableCollection<NotesModel> ListNotes
        {
            get { return _listNotes; }
            set { _listNotes = value; }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string test;

        public string Test
        {
            get { return test; }
            set { test = value; }
        }

        private noteEnum statusNoteSelectedItem;

        public noteEnum StatusNoteSelectedItem
        {
            get { return statusNoteSelectedItem; }
            set { statusNoteSelectedItem = value; }
        }


        public void AddNote()
        {
            //if (!string.IsNullOrWhiteSpace(NewNote))
            //{
            //    Notes.Add(NewNote);
            //    NewNote = string.Empty;
            //    Status = "Note added.";
            //}
            if(NewNote != null)
            {
                ListNotes.Add(NewNote);
            }
            else
            {
                Status = "Please enter a note.";
            }
        }

        //Count the tasks need to be done to show on HomeViewModel notification
        public int NotificationCounting()
        {
            //Dummy Data
            string date = "03/21/2023";
            string dummyDate = "03/05/2023";

            ListNotes.Add(new NotesModel()
            {
                EndDate = Convert.ToDateTime(date),
            }); ;
            //
            List<DateTime> notificationCountList = new List<DateTime>();
            foreach (NotesModel notes in ListNotes)
            {
                if(notes.StatusNote == CommonMethod.NoteStatus.NotDone)
                {
                    notificationCountList.Add(notes.EndDate);
                }
            }

            NotificationCount = 0;
            foreach(DateTime note in notificationCountList)
            {
                int count = (DateTime.Now - note).Days;
                if (count < 2)
                {
                    NotificationCount++;
                }
            }
            return NotificationCount;
        }

        private bool FilterByName(object obj)
        {
            if (!string.IsNullOrEmpty(TextToFilter))
            {
                var noteDetail = obj as NotesModel;
                return noteDetail != null && noteDetail.DetailNote.Contains(TextToFilter);

            }
            return true;
        }

        private void DeleteNote()
        {
            foreach (var item in ListNotes.ToList())
            {
                if (item.IsCheck)
                {
                    //ListIDCheck.Add(item.Id);
                    ListNotes.Remove(item);
                }
            }

            if (GlobalDef.ListNotesModel.Count != ListNotes.Count)
            {
                MessageBox.Show("Xóa thành công!");
                GlobalDef.ListNotesModel = ListNotes;
            }
            ListDataNote = CollectionViewSource.GetDefaultView(ListNotes);

        }

        private void ReloadNote()
        {
            ListNotes = commonMethod.ReadNoteFileCsv();
            ListDataNote = CollectionViewSource.GetDefaultView(ListNotes);
        }

        private void SaveNote()
        {
            //ListStorage = GlobalDef.ListStorageModel;
            if (commonMethod.WriteNoteFileCsv(ListNotes, GlobalDef.CsvPath))
            {
                MessageBox.Show("Lưu thành công!");
            }
            else MessageBox.Show("Lưu thất bại lien hệ Danh :(");
        }

        private NotesModel _newNote;

        public event PropertyChangedEventHandler PropertyChanged;

        public NotesModel NewNote
        {
            get { return _newNote; }
            set { _newNote = value; }
        }
    }
}
