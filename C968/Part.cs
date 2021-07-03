using System;
using System.Collections.Generic;
using System.Text;

namespace C968
{
    public class Part
    {
        private int partId;
        private string partName;
        private int partQuantity;
        private double partPrice;
        private int minPartQuantity;
        private int maxPartQuantity;
        private bool inHouse;
        private string source;

        public Part(string aPartName, int aQuantity, double aPrice, int aMin, int aMax, bool aInHouse, string aSource)
        {
            partName = aPartName;
            partQuantity = aQuantity;
            partPrice = aPrice;
            minPartQuantity = aMin;
            maxPartQuantity = aMax;
            inHouse = aInHouse;
            source = aSource;

        }
       
        public int ID
        {
            get { return partId; }
            set { partId = value; }
        }
        public string Name
        {
            get { return partName; }
            set { partName = value; 
            }
        }

        public string Price//Converts the double partPrice to currency
        {
            get { return partPrice.ToString("C"); }
        }
        public double SetPrice
        {
            set { partPrice = value; }
        }

        public int Min
        {
            get { return minPartQuantity; }
            set { minPartQuantity = value; }
        }
        public int Max
        {
            get { return maxPartQuantity; }
            set { maxPartQuantity = value; }
        }

        public int Quantity
        {
            get { return partQuantity; }
            set { partQuantity = value; }
        }

        public bool InHouse
        {
            get { return inHouse; }
            set { inHouse = value; }
        }

        public string Source
        {
            get { return source; }
            set { source = value; }
        }
    }
}
