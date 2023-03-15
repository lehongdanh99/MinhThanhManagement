using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhThanhManagement.Models
{

    public class StorageModel
    {
        private int id;
        private string group;
        private string name;
        private string remain;
        private double price;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }



        public string Name
        {
            get { return name; }
            set { name = value; }
        }



        public string Remain
        {
            get { return remain; }
            set { remain = value; }
        }


        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private bool isCheck = false;

        public bool IsCheck
        {
            get { return isCheck; }
            set { isCheck  = value; }
        }


    }

}
