using MinhThanhManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhThanhManagement
{
    public class CommonMethod
    {
        public ObservableCollection<StorageModel> ReadFileCsv()
        {
            ObservableCollection<StorageModel> ListStorageModel = new ObservableCollection<StorageModel>();
            string path = GlobalDef.CsvPath + "MinhThanhManagement.csv";
            
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                StorageModel storeModel = new StorageModel();
                string[] models = line.Split(',');
                storeModel.Id = (Convert.ToInt16(models[0].ToString()));
                storeModel.Group = (models[1]);
                storeModel.Name = (models[2]);
                storeModel.Remain = (models[3]);
                storeModel.Price =(Convert.ToDouble(models[4].ToString()));
                ListStorageModel.Add(storeModel);
            }
            return ListStorageModel;
        }
        public void ConvertToModel()
        {

        }
    }
}
