using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MinhThanhManagement.CommonMethod;

namespace MinhThanhManagement.Models
{
    public class NotesModel
    {
		private int idNote;
		private DateTime noteDate;
		private DateTime endDate;
		private string placeNote;
		private NoteName nameNote;
		private string detailNote;
		private bool statusNote;
		private bool isCheck;
		private bool warning;


        public bool StatusNote
        {
			get { return statusNote; }
			set { statusNote = value; }
		}

		public string DetailNote
		{
			get { return detailNote; }
			set { detailNote = value; }
		}

		public NoteName NameNote
		{
			get { return nameNote; }
			set { nameNote = value; }
		}

		public string PlaceNote
        {
			get { return placeNote; }
			set { placeNote = value; }
		}

		public DateTime EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}

		public DateTime NoteDate
		{
			get { return noteDate; }
			set { noteDate = value; }
		}

		public int IdNote
		{
			get { return idNote; }
			set { idNote = value; }
		}

        public bool IsCheck
        {
            get { return isCheck; }
            set { isCheck = value; }
        }

		public bool Warning
		{
			get {
				if (EndDate != null && (EndDate - DateTime.Now).Days < 2 
					&& (EndDate - DateTime.Now).Days >= 0)
				{
					return true;

				}
				else
				{
					return false;
				}
			}
			set { warning = value;
				if (EndDate != null && (EndDate - DateTime.Now).Days < 2
					&& (EndDate - DateTime.Now).Days >= 0)
				{
					warning = true;

				}
				else
				{
					warning = false;
				}
			}
		}


		public ObservableCollection<NoteStatus> MyComboBoxItems = new ObservableCollection<NoteStatus> { NoteStatus.NotDone,NoteStatus.Done };
        //public enum NoteStatuses
        //{
        //    NotDone, // Show to GUI "Chưa hoàn thành"
        //    Done // Show to GUI "Chưa xong"
        //}
    }
}
