using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

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

        private ObservableCollection<FileInfo> listFile = new ObservableCollection<FileInfo>();

        public ObservableCollection<FileInfo> ListFile
        {
            get { return listFile; }
            set { listFile = value; }
        }

        public HistoryViewModel()
        {
            ReadFileinFolder();
        }

        public void ReadFileinFolder()
        {
            string folderPath = "New folder";
            string[] filePaths = Directory.GetFiles(folderPath);
            foreach (string filePath in filePaths)
            {
                ListFile.Add(new FileInfo(filePath));
            }
        }


    }
}
