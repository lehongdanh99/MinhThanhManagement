using GalaSoft.MvvmLight.Command;
using MinhThanhManagement.Models;
using MinhThanhManagement.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public ICommand AddCommand { get; private set; }


        private ObservableCollection<StorageModel> listStorage = new ObservableCollection<StorageModel>();

        private List<string> typeStorage;

        private int selectedItemStorage;

        private StorageModel storageSelected = new StorageModel();

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
            Initialize();
        }
        public void Initialize()
        {
            //ListStorage = GlobalDef.ListStorageModel;
            ReloadCommand = new RelayCommand(ReloadStorageCommand);
            SaveCommand = new RelayCommand(SaveStorageCommand);
            DeleteCommand = new RelayCommand(DeleteStorageCommand);
            NavigateNoteCommand = new RelayCommand(NavigateHometoNoteCommand);
            ListStorage = commonMethod.ReadFileCsv();
            GlobalDef.ListStorageModel = commonMethod.ReadFileCsv();

        }

        private void ReloadStorageCommand()
        {

            GlobalDef.ListStorageModel[0].Name.ToString();
            ListStorage = commonMethod.ReadFileCsv();
        }

        private void NavigateHometoNoteCommand()
        {
            NoteView noteView = new NoteView();
            noteView.Show();
        }

        private void SaveStorageCommand()
        {
            ListStorage = GlobalDef.ListStorageModel;
            if (commonMethod.WriteFileCsv(ListStorage, GlobalDef.CsvPath + "MinhThanhManagement.csv"))
            {
                MessageBox.Show("ok");
            }
            else MessageBox.Show("Not Ok");
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
