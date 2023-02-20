using MinhThanhManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhThanhManagement
{
    public class GlobalDef
    {
        public static string CsvPath = AppDomain.CurrentDomain.BaseDirectory;
        public static ObservableCollection<StorageModel> ListStorageModel = new ObservableCollection<StorageModel>();

    }
}
