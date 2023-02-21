using MinhThanhManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
                storeModel.Id = (Convert.ToInt32(models[0].ToString()));
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
        public bool WriteFileCsv(ObservableCollection<StorageModel> listItem, string filePath)
        {
            List<StorageModel> newList = listItem.ToList();
            StringBuilder stringBuilder= new StringBuilder();
            foreach(StorageModel item in newList)
            {
                stringBuilder.Append(item.Id.ToString() + ",");
                stringBuilder.Append(item.Group.ToString() + ",");
                stringBuilder.Append(item.Name.ToString() + ",");
                stringBuilder.Append(item.Remain.ToString() + ",");
                stringBuilder.Append(item.Price.ToString() + "\n" );
            }           
            if (!File.Exists(filePath))
            {
                try
                {
                    File.Create(filePath);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            if (!filePath.Contains(".csv"))
            {
                filePath += ".csv";
            }
            File.WriteAllText(filePath, stringBuilder.ToString());

            return true;
        }
    }
}
