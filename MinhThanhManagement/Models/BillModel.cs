using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhThanhManagement.Models
{
    internal class BillModel
    {
		private string itemName;

		public string ItemNameTxt
        {
			get { return itemName; }
			set { itemName = value;}
		}

	}


    public class Item
    {

        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }

        private string group;

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

    }

}
