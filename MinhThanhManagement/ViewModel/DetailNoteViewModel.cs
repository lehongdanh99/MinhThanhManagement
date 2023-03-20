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
    public class DetailNoteViewModel : BaseViewModel
    {
		private string placeNoteText;
		private string detailNoteText;
		private NoteName typeNoteText;
		private DateTime noteDatePicker = DateTime.Now;
		private DateTime endNoteDatePicker = DateTime.Now;
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

        private List<string> listNoteNames = new List<string>();

        public List<string> ListNoteNames
        {
            get { return listNoteNames; }
            set { listNoteNames = value; }
        }

        private string selectedItemAutoCompleteNoteName;

        public string SelectedItemAutoCompleteNoteName
        {
            get => selectedItemAutoCompleteNoteName;
            set
            {
                selectedItemAutoCompleteNoteName = value;
                OnPropertyChanged(nameof(SelectedItemAutoCompleteNoteName));
                
            }
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


            ListNoteNames = new List<string>() { "Cần làm", "Còn Thiếu", "Thu Hóa Đơn"};
                

        }
		private NoteName convertCbbToEnum(string notename)
        {
            if(notename.Equals("Cần Làm"))
            {
                return NoteName.ToDo;
            }
            if (notename.Equals("Thu Hóa Đơn"))
            {
                return NoteName.Collect;
            }
            if (notename.Equals("Còn Thiếu"))
            {
                return NoteName.Debt;
            }
            return NoteName.ToDo;
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
            if (!string.IsNullOrEmpty(DetailNoteText) && !string.IsNullOrEmpty(PlaceNoteText) && !string.IsNullOrEmpty(SelectedItemAutoCompleteNoteName.ToString()) && !string.IsNullOrEmpty(NoteDatePicker.ToString()) && !string.IsNullOrEmpty(EndNoteDatePicker.ToString()))
            {
                NotesModel notesModel = new NotesModel()
                {
                    IdNote = Convert.ToInt32(id),
                    NameNote = convertCbbToEnum(selectedItemAutoCompleteNoteName),
                    DetailNote = DetailNoteText.ToString(),
                    PlaceNote = PlaceNoteText.ToString(),
                    NoteDate = NoteDatePicker,
                    EndDate = EndNoteDatePicker,
                    StatusNote = false,
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
