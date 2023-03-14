﻿using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using MinhThanhManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MinhThanhManagement.ViewModel 
{
    public class BillViewModel : BaseViewModel
    {

        public ICommand AddItemtoBill { get; private set; }


        private List<string> itemNameTxt;

        public List<string> ItemNameTxt
        {
            get { return itemNameTxt; }
            set { itemNameTxt = value; }
        }

        private ObservableCollection<ItemInBill> listItemsBill = new ObservableCollection<ItemInBill>();

        public ObservableCollection<ItemInBill> ListItemsBill
        {
            get { return listItemsBill; }
            set { listItemsBill = value; OnPropertyChanged(nameof(ListItemsBill)); }
        }


        private double priceAutoCount;

        public double PriceAutoCount
        {
            get { return priceAutoCount; }
            set { priceAutoCount = value; }
        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; 
                PriceAutoCount = Count * PriceAuto;
                OnPropertyChanged(nameof(PriceAutoCount));
                
            }
        }

        private string txtUnit;

        public string TxtUnit
        {
            get { return txtUnit; }
            set { txtUnit = value; }
        }

        private double total = 0;

        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        private double preOrder;

        public double PreOrder
        {
            get { return preOrder; }
            set { preOrder = value; TotalFinal = Total - PreOrder;
                OnPropertyChanged(nameof(TotalFinal));
            }
        }

        private double totalFinal;

        public double TotalFinal
        {
            get { return totalFinal; }
            set { totalFinal = value; TotalFinal = Total - PreOrder; }
        }



        private List<string> listAutoComplete = new List<string>();

        public List<string> ListAutoComplete
        {
            get { return listAutoComplete; }
            set { listAutoComplete = value; }
        }

        private string selectedItemAutoComplete;

        public string SelectedItemAutoComplete
        {
            get => selectedItemAutoComplete;
            set
            {
                selectedItemAutoComplete = value;
                OnPropertyChanged(nameof(SelectedItemAutoComplete));
                if(!string.IsNullOrEmpty(SelectedItemAutoComplete))
                {
                    PriceAuto = priceItem(SelectedItemAutoComplete);
                    if(Count > 0)
                    {
                        PriceAutoCount = Count * PriceAuto;
                    }
                }
            }
        }

        private double priceAuto = 0;

        public double PriceAuto
        {
            get { return priceAuto; }
            set { priceAuto = value;
                OnPropertyChanged(nameof(PriceAuto));
            }
        }



        //List<string> items = new List<string>();
        public BillViewModel() {
            foreach (var item in GlobalDef.ListStorageModel)
            {
                ListAutoComplete.Add(item.Group + " " + item.Name);
            }


            //add item to list bill
            AddItemtoBill = new RelayCommand(AddBillCommand);
        }

        private void AddBillCommand()
        {
            if(!string.IsNullOrEmpty(SelectedItemAutoComplete) 
               && Count != 0 
               && PriceAuto != 0
               && PriceAutoCount != 0)
            {
                ItemInBill item = new ItemInBill
                    (
                    SelectedItemAutoComplete,
                    TxtUnit,
                    Count,
                    PriceAuto,
                    PriceAutoCount
                    );

                ListItemsBill.Add(item);
                SelectedItemAutoComplete = "";
                TxtUnit = "";
                Count = 0;
                PriceAuto = 0;
                PriceAutoCount = 0;
            }
            


            GetTotal(ListItemsBill);
        }

        private void GetTotal(ObservableCollection<ItemInBill> listBill)
        {
            Total = 0;
            foreach(var item in listBill)
            {
                Total += item.Price;
            }

            OnPropertyChanged(nameof(Total));
            OnPropertyChanged(nameof(TotalFinal));
        }


        private double priceItem(string groupname)
        {
            if(!string.IsNullOrEmpty(groupname))
            {
                string[] s = groupname.Split(' ');
                string name = s[1].ToString();

                foreach (var item in GlobalDef.ListStorageModel)
                {
                    if (item.Name.Equals(name.ToString()))
                    {
                        return item.Price;
                    }
                }
            }
           
            return 0 ;
        }
        
    }
}
