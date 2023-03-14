using GalaSoft.MvvmLight.Command;
using MinhThanhManagement.Models;
using MinhThanhManagement.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MinhThanhManagement.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {

        CommonMethod commonMethod = new CommonMethod();

        public ICommand SaveCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public ICommand ReloadCommand { get; private set; }

        public ICommand NavigateNoteCommand { get; private set; }
        public ICommand NavigateBillCommand { get; private set; }

        public ICommand NavigateHistoryCommand { get; private set; }
        public ICommand AddCommand { get; private set; }


        private ObservableCollection<StorageModel> listStorage = new ObservableCollection<StorageModel>();

        private List<string> typeStorage;

        private int selectedItemStorage;

        private StorageModel storageSelected = new StorageModel();

        private string textToFilter = "";

        public string TextToFilter
        {
            get 
            {
                return textToFilter.ToUpper();
            }
            set { textToFilter = value; ListDataStorage.Filter = FilterByName; }
        }

        private ICollectionView listDataStorage;

        public ICollectionView ListDataStorage
        {
            get { return listDataStorage; }
            set { listDataStorage = value; }
        }


        private List<Item> groupStorage = new List<Item>();

        public List<Item> GroupStorage
        {
            get { return groupStorage; }
            set { groupStorage = value; }
        }

        private List<string> listGroup = new List<string>();

        private string txtNameInput;

        public string TxtNameInput
        {
            get { return txtNameInput; }
            set { txtNameInput = value; }
        }

        private string txtTypeInput;

        public string TxtTypeInput
        {
            get { return txtTypeInput; }
            set { txtTypeInput = value; }
        }

        private double txtPriceInput;

        public double TxtPriceInput
        {
            get { return txtPriceInput; }
            set { txtPriceInput = value; }
        }

        private string txtNumInput;

        public string TxtNumInput
        {
            get { return txtNumInput; }
            set { txtNumInput = value; }
        }

        public StorageModel StorageSelected
        {
            get { return storageSelected; }
            set { storageSelected = value;
            }
        }


        public int SelectedItemStorage
        {
            get
            {
                return selectedItemStorage;
            }
            set
            {
                selectedItemStorage = value;
                if (SelectedItemStorage >= 0)
                {
                    StorageSelected = ListStorage[SelectedItemStorage];
                }

            }
        }


        public List<string> TypeStorage
        {
            get { return typeStorage; }
            set { typeStorage = value; }
        }

        private bool isEnableEditBtn = false;

        public bool IsEnableEditBtn
        {
            get { return isEnableEditBtn = false; }
            set { isEnableEditBtn = value; }
        }

        public ObservableCollection<StorageModel> ListStorage
        {
            get { return listStorage; }
            set { listStorage = value; OnPropertyChanged(nameof(ListStorage)); }
        }
        public HomeViewModel()
        {
            NoteViewModel.GetInstance().NotificationCounting();
            Initialize();
        }
        public void Initialize()
        {
            ListStorage = commonMethod.ReadFileCsv();
            ListDataStorage = CollectionViewSource.GetDefaultView(ListStorage);

            GetGroupStorage(ListStorage);
            //gonext to other screen
            AddCommand = new RelayCommand(AddStorageCommand);
            ReloadCommand = new RelayCommand(ReloadStorageCommand);
            SaveCommand = new RelayCommand(SaveStorageCommand);
            DeleteCommand = new RelayCommand(DeleteStorageCommand);
            NavigateNoteCommand = new RelayCommand(NavigateHometoNoteCommand);
            NavigateBillCommand = new RelayCommand(NavigateHometoBillCommand);
            NavigateHistoryCommand = new RelayCommand(NavigateHometoHistoryCommand);
            
            GlobalDef.ListStorageModel = commonMethod.ReadFileCsv();
            
        }

        private void GetGroupStorage(ObservableCollection<StorageModel> list)
        {

            var tempList= list.GroupBy(x => x.Group).Select(x => x.FirstOrDefault()).ToList();
            List<string> listgroup = new List<string>();
            foreach (var item in tempList)
            {
                if (item != null)
                {
                    listgroup.Add(item.Group);
                }
            }
            //var listStorage = listgroup.Distinct();

            foreach (var sto in listgroup)
            {
                if (sto != null)
                {
                    Item itemnew = new Item { IsChecked = false, Group = sto };
                    GroupStorage.Add(itemnew);
                }
            }
        }

        private bool FilterByName(object obj)
        {
            if(!string.IsNullOrEmpty(TextToFilter))
            {
                var stoDetail = obj as StorageModel;
                return stoDetail != null && stoDetail.Group.Contains(TextToFilter);

            }
            return true;
        }

        private void ReloadStorageCommand()
        {

            GlobalDef.ListStorageModel[0].Name.ToString();
            ListStorage = commonMethod.ReadFileCsv();
        }

        private void AddStorageCommand()
        {
            DetailStorageView.GetInstance().ShowDialog();
        }

        private void NavigateHometoNoteCommand()
        {
            NoteView.GetInstance().Show();                
        }
        private void NavigateHometoBillCommand()
        {
            BillView.GetInstance().Show();
        }

        private void NavigateHometoHistoryCommand()
        {
            HistoryView.GetInstance().Show();
        }
        private void SaveStorageCommand()
        {
            ListStorage = GlobalDef.ListStorageModel;
            if (commonMethod.WriteFileCsv(ListStorage, GlobalDef.CsvPath + "MinhThanhManagement.csv"))
            {
                MessageBox.Show("Lưu thành công!");
            }
            else MessageBox.Show("Lưu thất bại lien hệ Danh :(");
        }
        private void DeleteStorageCommand()
        {
            foreach (var item in ListStorage)
            {
                if (item.Id - 1 == SelectedItemStorage)
                {
                    GlobalDef.ListStorageModel.RemoveAt(SelectedItemStorage);
                }
            }
            ListStorage = GlobalDef.ListStorageModel;
        }

        //private bool CanDelete
        //{
        //    get { return ListStorage[SelectedItemStorage] != null; }
        //}

        //private ICommand m_deleteCommand;
        //public ICommand DeleteCommand
        //{
        //    get
        //    {
        //        if (m_deleteCommand == null)
        //        {
        //            m_deleteCommand = new RelayCommand(param => Delete((Result)param), param => CanDelete);
        //        }
        //        return m_deleteCommand;
        //    }
        //}

        //private void Delete(StorageModel result)
        //{
        //    ListStorage.Remove(result);
        //}
    }



}
