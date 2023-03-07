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

        private List<string> itemNameTxt;

        public List<string> ItemNameTxt
        {
            get { return itemNameTxt; }
            set { itemNameTxt = value; }
        }
        //List<string> items = new List<string>();
        public BillViewModel() {
    
        }
        
    }
}
