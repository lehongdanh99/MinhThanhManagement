using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhThanhManagement.Models
{
    public class NotesModel
    {
		private int idNote;
		private DateTime noteDate;
		private DateTime endDate;
		private string placeNote;
		private string nameNote;
		private string detailNote;
		private string statusNote;

		public string StatusNote
        {
			get { return statusNote; }
			set { statusNote = value; }
		}

		public string DetailNote
		{
			get { return detailNote; }
			set { detailNote = value; }
		}

		public string NameNote
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

	}
}
