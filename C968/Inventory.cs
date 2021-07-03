using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace C968
{
    class Inventory
    {
        public static BindingList<Part> allParts = new BindingList<Part>();
        public static BindingList<Product> allProducts = new BindingList<Product>();

        private static int partIndex = 0;
        private static int productIndex = 0;

        public static int PartIndex
        {
            get { return partIndex; }
        }

        public static int ProductIndex
        {
            get { return productIndex; }
        }

        public static void addPart(Part newPart)
        {
            allParts.Add(newPart);
            newPart.ID = partIndex;
            partIndex++;
        }

        public static void addProduct(Product newProduct)
        {
            allProducts.Add(newProduct);
            newProduct.ID = productIndex;
            productIndex++;
        }

        public static void removeProduct(int thisProductID)
        {
            allProducts.RemoveAt(thisProductID);
        }

        public static bool lookupProduct(int thisProductID)
        {
            for(int i = 0; i < allProducts.Count; i++)
            {
                if(allProducts[i].ID == thisProductID)
                {
                    return true;
                }
            }
            return false;
        }

        public static void updateProduct(int thisProductIndex,
                                         string updatedName,
                                         string updatedQuantity,
                                         string updatedPrice,
                                         string updatedMin,
                                         string updatedMax)
        {
            allProducts[thisProductIndex].Name = updatedName;
            allProducts[thisProductIndex].Quantity = Int32.Parse(updatedQuantity);
            allProducts[thisProductIndex].SetPrice = double.Parse(updatedPrice);
            allProducts[thisProductIndex].Min = Int32.Parse(updatedMin);
            allProducts[thisProductIndex].Max = Int32.Parse(updatedMax);
            allProducts[thisProductIndex].PartsIndexOfProduct.Clear();
        }

        public static void deletePart(int thisPartID)
        {
            allParts.RemoveAt(thisPartID);
        }

        public static bool lookupPart(int thisPartID)
        {
            for (int i = 0; i < allParts.Count; i++)
            {
                if (allParts[i].ID == thisPartID)
                {
                    return true;
                }
            }
            return false;
        }

        public static void updatePart(int thisPartIndex,
                                      string updatedName,
                                      string updatedQuantity,
                                      string updatedPrice,
                                      string updatedMin,
                                      string updatedMax,
                                      bool updatedInHouse,
                                      string updatedSource)
        {
            allParts[thisPartIndex].Name = updatedName;
            allParts[thisPartIndex].Quantity = Int32.Parse(updatedQuantity);
            allParts[thisPartIndex].SetPrice = double.Parse(updatedPrice);
            allParts[thisPartIndex].Min = Int32.Parse(updatedMin);
            allParts[thisPartIndex].Max = Int32.Parse(updatedMax);
            allParts[thisPartIndex].InHouse = updatedInHouse;
            allParts[thisPartIndex].Source = updatedSource;
        }

    }
}
