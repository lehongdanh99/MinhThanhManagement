using MaterialDesignThemes.Wpf;
using MinhThanhManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhThanhManagement.ViewModel 
{
    public class BillViewModel : BaseViewModel
    {
        private string imageSource = "logo.JPG";

        public string ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; }
        }

        private List<string> itemNameTxt;

        public List<string> ItemNameTxt
        {
            get { return itemNameTxt; }
            set { itemNameTxt = value; }
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
