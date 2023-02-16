using MinhThanhManagement.Models;
using MinhThanhManagement.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ICommand AddCommand { get; private set; }


        private List<StorageModel> listStorage = new List<StorageModel>();

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
                StorageSelected = ListStorage[SelectedItemStorage];
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

        public List<StorageModel> ListStorage
        {
            get { return listStorage; }
            set { listStorage = value; }
        }
        public HomeViewModel()
        {
            Initialize();
        }
        public void Initialize()
        {
            ListStorage = GlobalDef.ListStorageModel;
            //GetTypeStorage(ListStorage);
            //SelectedItemStorage = 0;
            commonMethod.ReadFileCsv();

        }



        private void AddStorageCommand()
        {
            throw new NotImplementedException();
        }


    }
}
