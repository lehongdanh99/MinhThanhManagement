using MinhThanhManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MinhThanhManagement
{
    public class CommonMethod
    {
        public ObservableCollection<StorageModel> ReadFileCsv()
        {
            ObservableCollection<StorageModel> ListStorageModel = new ObservableCollection<StorageModel>();
            string path = GlobalDef.CsvPath + "MinhThanhManagement.csv";
            
            string[] lines = System.IO.File.ReadAllLines(path);
            try
            {
                foreach (string line in lines)
                {
                    StorageModel storeModel = new StorageModel();
                    string[] models = line.Split(',');
                    storeModel.Id = (Convert.ToInt32(models[0].ToString()));
                    storeModel.Group = (models[1]);
                    storeModel.Name = (models[2]);
                    storeModel.Remain = (models[3]);
                    storeModel.Price = (Convert.ToDouble(models[4].ToString()));
                    ListStorageModel.Add(storeModel);
                }
            }          
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return ListStorageModel;
        }
        public ObservableCollection<NotesModel> ReadNoteFileCsv()
        {
            ObservableCollection<NotesModel> ListStorageModel = new ObservableCollection<NotesModel>();
            string path = GlobalDef.CsvPath + "MinhThanhNotes.csv";

            string[] lines = System.IO.File.ReadAllLines(path);
            try
            {
                foreach (string line in lines)
                {
                    NotesModel storeModel = new NotesModel();
                    string[] models = line.Split(',');
                    storeModel.IdNote = (Convert.ToInt32(models[0].ToString()));
                    storeModel.NoteDate = (Convert.ToDateTime(models[1]));
                    if(!string.IsNullOrEmpty(models[2].ToString()))
                    {
                        storeModel.EndDate = (Convert.ToDateTime(models[2]));
                    }
                    else
                    {
                        storeModel.EndDate = DateTime.MinValue;
                    }
                    
                    storeModel.PlaceNote = (models[3].ToString());
                    storeModel.NameNote = (NoteName)Enum.Parse(typeof(NoteName), models[4].ToString()) ;
                    storeModel.DetailNote= (models[5].ToString());                   
                    storeModel.StatusNote= (NoteStatus)Enum.Parse(typeof(NoteStatus), models[6].ToString());
                    ListStorageModel.Add(storeModel);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return ListStorageModel;
        }

        public void ConvertToModel()
        {

        }
        public bool WriteNoteFileCsv(ObservableCollection<NotesModel> listItem, string filePath)
        {
            List<NotesModel> newList = listItem.ToList();
            StringBuilder stringBuilder= new StringBuilder();
            foreach(NotesModel item in newList)
            {
                stringBuilder.Append(item.IdNote + ",");
                stringBuilder.Append(item.NoteDate + ",");
                stringBuilder.Append(item.EndDate + ",");
                stringBuilder.Append(item.PlaceNote.ToString() + ",");
                stringBuilder.Append(item.NameNote + "\n" );
                stringBuilder.Append(item.DetailNote.ToString() + "\n" );
                stringBuilder.Append(item.StatusNote + "\n" );
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
        public bool WriteFileCsv(ObservableCollection<StorageModel> listItem, string filePath)
        {
            List<StorageModel> newList = listItem.ToList();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (StorageModel item in newList)
            {
                stringBuilder.Append(item.Id.ToString() + ",");
                stringBuilder.Append(item.Group.ToString() + ",");
                stringBuilder.Append(item.Name.ToString() + ",");
                stringBuilder.Append(item.Remain.ToString() + ",");
                stringBuilder.Append(item.Price.ToString() + "\n");
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

        public enum NoteStatus
        {
            NotDone, // Show to GUI "Chưa hoàn thành"
            Done // Show to GUI "Chưa xong"
        }
        public enum NoteName
        {
            ToDo = 1, // Show to GUI "Làm hàng"
            Debt, // Show to GUI "Thiếu tiền"
            Collect // Show to GUI "Thu tiền hóa đơn"
        }
    }
    
}
