using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MinhThanhManagement.Models;
using static MinhThanhManagement.ViewModel.HomeViewModel;

namespace MinhThanhManagement.ViewModel
{
    public class DetailStorageViewModel : BaseViewModel
    {
        #region Properties
        private string groupTxt;
		private string nameTxt;
		private int quantantyTxt;
		private double priceTxt;
        
        public ICommand AddItemCommand { get; private set; }
        public double PriceTxt
        {
			get { return priceTxt; }
			set { priceTxt = value; }
		}

		public int QuantantyTxt
        {
			get { return quantantyTxt; }
			set { quantantyTxt = value; }
		}

		public string NameTxt
        {
			get { return nameTxt; }
			set { nameTxt = value; }
		}

		public string GroupTxt
        {
			get { return groupTxt; }
			set { groupTxt = value; }
		}
        #endregion

        #region Constructor
        private static DetailStorageViewModel _instance;
        public static DetailStorageViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DetailStorageViewModel();
            }
            return _instance;
        }
        public DetailStorageViewModel()
		{
            
            AddItemCommand = new RelayCommand(AddItemDetailStorageCommand);

		}
        #endregion

        #region Button
        public void AddItemDetailStorageCommand()
		{
            for (int i = 0; i < GlobalDef.ListStorageModel.Count; i++)
            {
                if (GlobalDef.ListStorageModel[i].Id != i + 1)
                {
                    addItemToStorageList(i + 1);
                    return;
                }
            }
            addItemToStorageList(GlobalDef.ListStorageModel.Count+1);
            
        }
        #endregion
        #region Method
        private void addItemToStorageList(int id)
        {
            if(!string.IsNullOrEmpty(GroupTxt) && !string.IsNullOrEmpty(NameTxt) && !string.IsNullOrEmpty(PriceTxt.ToString()) && !string.IsNullOrEmpty(QuantantyTxt.ToString()))
            {
                StorageModel storageModel = new StorageModel()
                {
                    Id = id,
                    Group = GroupTxt,
                    Name = NameTxt,
                    Remain = QuantantyTxt.ToString(),
                    Price = PriceTxt,
                };
                GlobalDef.ListStorageModel.Add(storageModel);
                CommonMethod commonMethod = new CommonMethod();
                if(!commonMethod.WriteFileCsv(GlobalDef.ListStorageModel, GlobalDef.CsvPath))
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
        #endregion  
    }
}
