using GalaSoft.MvvmLight.Command;
using MinhThanhManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static MinhThanhManagement.CommonMethod;

namespace MinhThanhManagement.ViewModel
{
    public class DetailNoteViewModel
    {
		private string placeNoteText;
		private string detailNoteText;
		private NoteName typeNoteText;
		private DateTime noteDatePicker;
		private DateTime endNoteDatePicker;
        public ICommand AddNoteCommand { get; private set; }
        public DateTime EndNoteDatePicker
		{
			get { return endNoteDatePicker; }
			set { endNoteDatePicker = value; }
		}

		public DateTime NoteDatePicker
        {
			get { return noteDatePicker; }
			set { noteDatePicker = value; }
		}

		public NoteName TypeNoteText
        {
			get { return typeNoteText; }
			set { typeNoteText = value; }
		}

		public string DetailNoteText
        {
			get { return detailNoteText; }
			set { detailNoteText = value; }
		}

		public string PlaceNoteText
        {
			get { return placeNoteText; }
			set { placeNoteText = value; }
		}
		public DetailNoteViewModel	()
		{
			AddNoteCommand = new RelayCommand(AddNoteButton);

        }
		 
		public void AddNoteButton()
		{
            for (int i = 0; i < GlobalDef.ListNotesModel.Count; i++)
            {
                if (GlobalDef.ListNotesModel[i].IdNote != i + 1)
                {
                    addItemToNote(i + 1);
                    return;
                }
            }
            addItemToNote(GlobalDef.ListNotesModel.Count + 1);
            

        }
		private void addItemToNote(int id)
		{
            if (!string.IsNullOrEmpty(DetailNoteText) && !string.IsNullOrEmpty(PlaceNoteText) && !string.IsNullOrEmpty(TypeNoteText.ToString()) && !string.IsNullOrEmpty(NoteDatePicker.ToString()) && !string.IsNullOrEmpty(EndNoteDatePicker.ToString()))
            {
                NotesModel notesModel = new NotesModel()
                {
                    IdNote = Convert.ToInt32(id),
                    NameNote = (NoteName)TypeNoteText,
                    DetailNote = DetailNoteText.ToString(),
                    PlaceNote = PlaceNoteText.ToString(),
                    NoteDate = NoteDatePicker,
                    EndDate = EndNoteDatePicker,
                    StatusNote = NoteStatus.NotDone,
                };
                GlobalDef.ListNotesModel.Add(notesModel);
                CommonMethod commonMethod = new CommonMethod();
                if (!commonMethod.WriteNoteFileCsv(GlobalDef.ListNotesModel, GlobalDef.CsvPath))
                {
                    MessageBox.Show("Ghi file thất bại", "Lỗi hệ thống", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Không được để trống thông tin", "Cảnh Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
	}
}
