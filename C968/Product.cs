using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace C968
{
    public class Product
    {
        private int productId;
        private string productName;
        private int productQuantity;
        private double productPrice;
        private int minProductQuantity;
        private int maxProductQuantity;
        public List<int> partsIndexOfProduct;

        public Product(string aProductName, 
                       int aProductQuantity,
                       double aProductPrice,
                       int aMinProductQuantity,
                       int aMaxProductQuantity,
                       List<int> aPartsIndexOfProduct)
        {
            productName = aProductName;
            productQuantity = aProductQuantity;
            productPrice = aProductPrice;
            minProductQuantity = aMinProductQuantity;
            maxProductQuantity = aMaxProductQuantity;
            partsIndexOfProduct = aPartsIndexOfProduct;
        }


        public int ID
        {
            get { return productId; }
            set { productId = value; }
        }

        public string Name
        {
            get { return productName; }
            set { productName = value; }
        }

        public int Quantity
        {
            get { return productQuantity; }
            set { productQuantity = value; }
        }

        public string Price
        {
            get { return productPrice.ToString("C"); }
        }
        public double SetPrice
        {
            set
            { productPrice = value; }
        }

        public int Min
        {
            get { return minProductQuantity; }
            set { minProductQuantity = value; }
        }

        public int Max
        {
            get { return maxProductQuantity; }
            set { maxProductQuantity = value; }
        }

        public List<int> PartsIndexOfProduct
        {
            get { return partsIndexOfProduct; }
            set { partsIndexOfProduct = value; }
        }

        public int AddAssociatedPart
        {
            set { partsIndexOfProduct.Add(value); }
        }

        public int RemoveAssociatedPart
        {
            set { 
                    foreach(int partIndex in partsIndexOfProduct)
                    {
                        if(partIndex == value)//----------------------------------------------
                          {
                             partsIndexOfProduct.Remove(partIndex);
                          }
                    }; 
                }
        }
       
        public int lookupAssociatedPart(int partID)
        {
            for(int i = 0; i < Inventory.allParts.Count; i++)
            {
                if(Inventory.allParts[i].ID == partID)
                {
                    return i;
                }
            }
            return -2;
        }
    }
}
