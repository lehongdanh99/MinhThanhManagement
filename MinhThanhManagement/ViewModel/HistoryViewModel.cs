using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Documents;
using static System.Net.WebRequestMethods;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace MinhThanhManagement.ViewModel
{
    public class HistoryViewModel : BaseViewModel
    {

        private static HistoryViewModel _instance;
        public static HistoryViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new HistoryViewModel();
            }
            return _instance;
        }

        private int billCount;

        public int BillCount
        {
            get { return billCount; }
            set 
            { 
                billCount = value;
                OnPropertyChanged(nameof(BillCount));
            }
        }

        private FileInfo selectedFile;

        public FileInfo SelectedFile
        {
            get { return selectedFile; }
            set { selectedFile = value; }
        }
        public ICommand OpenFileCommand { get; }

        private DateTime _selectedDate = DateTime.Today;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    ReadFileinFolder();
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        private ObservableCollection<FileInfo> listFile = new ObservableCollection<FileInfo>();

        public ObservableCollection<FileInfo> ListFile
        {
            get { return listFile; }
            set { listFile = value; OnPropertyChanged(nameof(ListFile)); }
        }

        public HistoryViewModel()
        {
            ReadFileinFolder();
            OpenFileCommand = new RelayCommand(OpenFile);
        }

        private void OpenFile()
        {
            string path = SelectedFile.DirectoryName;
            if (!string.IsNullOrEmpty(path))
            {
                // Mở tệp ở đây
                System.Diagnostics.Process.Start(SelectedFile.FullName);
            }
        }

        public void ReadFileinFolder()
        {
            ListFile.Clear();
            ObservableCollection<FileInfo> newlistReadFile = new ObservableCollection<FileInfo>();
            string folderPath = AppDomain.CurrentDomain.BaseDirectory + "HoaDon";
            if (!System.IO.Directory.Exists(folderPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Lỗi đọc file", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            string[] filePaths = Directory.GetFiles(folderPath);
            foreach (string filePath in filePaths)
            {
                //ListFile.Add(filePath.ToString());
                newlistReadFile.Add(new FileInfo(filePath));          
            }
            // Lọc các file theo ngày tạo file

            foreach (FileInfo item in newlistReadFile)
            {
                if(item.CreationTime.Date == SelectedDate.Date)
                {
                    ListFile.Add(item);
                }
            }
            OnPropertyChanged(nameof(ListFile));          
            BillCount = ListFile.Count();
            OnPropertyChanged(nameof(BillCount));
        }
    }
}
