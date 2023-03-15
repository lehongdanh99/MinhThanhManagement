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


    public class ItemInBill
    {

        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        private string unit;

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private double priceFinal;

        public double PriceFinal
        {
            get { return priceFinal; }
            set { priceFinal = value; }
        }

        public ItemInBill(string ItemName, string Unit, int Count, double Price, double PriceFinal)
        {
            this.ItemName = ItemName;
            this.Unit = Unit;
            this.Count = Count;
            this.Price = Price;
            this.PriceFinal = PriceFinal;
        }


    }

}
