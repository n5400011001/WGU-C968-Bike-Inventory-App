using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C968
{
    public partial class ModifyProduct : Form
    {
        int productIndex;
        BindingList<Part> thisProductsParts = new BindingList<Part>();//Create temp BindingList of parts for this product's associated parts
        public ModifyProduct(int ID)
        {
            productIndex = ID;
            InitializeComponent();
            modifyProductIdField.Text = Inventory.ProductIndex.ToString();//Grabs this new product's index
            modifyProductNameField.Text = Inventory.allProducts[productIndex].Name.ToString();
            modifyProductQuantityField.Text = Inventory.allProducts[productIndex].Quantity.ToString();
            modifyProductPriceField.Text = Inventory.allProducts[productIndex].Price.ToString();
            modifyProductMaxField.Text = Inventory.allProducts[productIndex].Max.ToString();
            modifyProductMinField.Text = Inventory.allProducts[productIndex].Min.ToString();
            partGrid.DataSource = Inventory.allParts;//tells the part grid that it will be looking at the inventory.allParts list for data
            partGrid.Columns["InHouse"].Visible = false;//the two values below do not need to be shown, just needed for the add/modify screens
            partGrid.Columns["Source"].Visible = false;

            if (Inventory.allProducts[productIndex].PartsIndexOfProduct.Count > 0)//Checks to see if there are actually any associated parts to show
            {
                for (int x = 0; x < Inventory.allParts.Count; x++)//cycles through allParts
                {
                    for (int i = 0; i < Inventory.allProducts[productIndex].PartsIndexOfProduct.Count; i++)//cycles through all the accociated parts the product has
                    {
                        if (Inventory.allParts[x].ID == Inventory.allProducts[productIndex].PartsIndexOfProduct[i])//Copy product parts from inventory that match the indexes of parts listed in the product
                        {
                            thisProductsParts.Add(Inventory.allParts[x]);//adds the part from inventory to the temp List
                        }
                    }
                }
                modifyProductAssociatedPartGrid.DataSource = thisProductsParts;//Bind the temp list of parts to the modifyProductAssociatedPartGrid
                modifyProductAssociatedPartGrid.Columns["InHouse"].Visible = false;//the two values below do not need to be shown, just needed for the add/modify screens
                modifyProductAssociatedPartGrid.Columns["Source"].Visible = false;
            }
        }

        private void modifyProductCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modifyProductSaveButton_Click(object sender, EventArgs e)
        {
            modifyProductErrorProvider.Clear();//clears the red x notification after a return

            if (thisProductsParts.Count == 0)//displays an error if the product doesnt have any associated parts
            {
                MessageBox.Show("Each product must contain at least one associated part. Please add a part.", "Product has no associated parts!");
            }

            if (string.IsNullOrEmpty(modifyProductNameField.Text))//if the Name field is blank
            {
                modifyProductErrorProvider.SetError(modifyProductNameField, "Please enter a valid part name.");//tooltip message displays the error
                return;
            }
            if (string.IsNullOrEmpty(modifyProductQuantityField.Text) ||//if the quantity field is blank or
                int.TryParse(modifyProductQuantityField.Text, out _) == false ||//the quantity field is not an integer or
                Int32.Parse(modifyProductQuantityField.Text) < 0)//the quantity field is less than 0
            {
                modifyProductErrorProvider.SetError(modifyProductQuantityField, "Please enter a valid quantity 0 or greater");//then the tooltip displays the error
                return;
            }//the next few if statements do the same just for different specific requirements
            if (string.IsNullOrEmpty(modifyProductPriceField.Text) ||
                double.TryParse(modifyProductPriceField.Text, out _) == false ||
                double.Parse(modifyProductPriceField.Text) < 0)
            {
                modifyProductErrorProvider.SetError(modifyProductPriceField, "Please enter a valid part price 0 or greater.");
                return;
            }
            if (string.IsNullOrEmpty(modifyProductMinField.Text) ||
                int.TryParse(modifyProductMinField.Text, out _) == false ||
                Int32.Parse(modifyProductMinField.Text) < 0)
            {
                modifyProductErrorProvider.SetError(modifyProductMinField, "Please enter a valid minimum quantity 0 or greater.");
                return;
            }
            if (string.IsNullOrEmpty(modifyProductMaxField.Text) ||
                int.TryParse(modifyProductMaxField.Text, out _) == false ||
                Int32.Parse(modifyProductMaxField.Text) < 0)
            {
                modifyProductErrorProvider.SetError(modifyProductMaxField, "Please enter a valid maximum quantity.");
                return;
            }
            if (Int32.Parse(modifyProductMaxField.Text) < int.Parse(modifyProductMinField.Text))
            {
                modifyProductErrorProvider.SetError(modifyProductMaxField, "Please enter a maximum quantity that is greater than the minimum.");
                return;
            }
            Inventory.updateProduct(productIndex, 
                                    modifyProductNameField.Text, 
                                    modifyProductQuantityField.Text,
                                    modifyProductPriceField.Text,
                                    modifyProductMinField.Text, 
                                    modifyProductMaxField.Text);
            for (int a = 0; a < thisProductsParts.Count; a++)
            {
                Inventory.allProducts[productIndex].PartsIndexOfProduct.Add(thisProductsParts[a].ID);//adds the new list of associated parts to the product
            }

            this.Close();
        }

        private void addPartToProductButton_Click(object sender, EventArgs e)
        {
            bool okToAddPartToProduct = true;//If the product already has a part thats trying to be added this flag will be set to false
            for(int i = 0; i < thisProductsParts.Count; i++)//Goes through the parts already associated with this product
            {
                if (thisProductsParts[i].ID == Int32.Parse(partGrid.SelectedRows[0].Cells["ID"].Value.ToString()))//If the selected part is already found to be associated
                {
                    okToAddPartToProduct = false;//this flag is set to false and wont add the part 
                }
            }
            if(okToAddPartToProduct == true)//if the selected inventory part isn't found to be associated with this product
            {
                foreach (DataGridViewRow item in this.partGrid.SelectedRows)
                {
                    thisProductsParts.Add(Inventory.allParts[item.Index]);//add the inventory part as an associated part to this product
                    Inventory.allProducts[productIndex].AddAssociatedPart = item.Index;
                }
            }
        }
        
        private void deletePartFromProductButton_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this part?";
            DialogResult result = MessageBox.Show(message, "Delete Part?", MessageBoxButtons.YesNo);//displays a message box that makes sure the user wants to delete the selected part
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.modifyProductAssociatedPartGrid.SelectedRows)//Selects the whole row of highlighted cells
                {
                    modifyProductAssociatedPartGrid.Rows.RemoveAt(item.Index);//Deletes the whole row of selected cells
                    Inventory.allProducts[productIndex].RemoveAssociatedPart = item.Index;
                }
            }

        }

        private void productsSearchButton_Click(object sender, EventArgs e)
        {
            partGrid.ClearSelection();//unselects everything in the datagrid first
            if (int.TryParse(productsSearchTextBox.Text, out _) == false && productsSearchTextBox.Text.Length >= 0)//If this is a STRING it will search the product by name(string)/NOT by ID(integer)
            {
                if (productsSearchTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Please enter a part name or part ID");
                    if (partGrid.RowCount > 0)
                    {
                        partGrid.Rows[0].Selected = true;
                    }
                }
                else
                {
                    bool foundOne = false;
                    for (int i = 0; i < partGrid.RowCount; i++)//goes through each part in the part grid
                    {
                        if (partGrid.Rows[i].Cells[1].Value.ToString().ToLower().Contains(productsSearchTextBox.Text.ToLower()))//compares the value typed in to the current part name
                        {
                            partGrid.Rows[i].Selected = true;//if the part is found in the datagrid the selection of that row is set to true
                            foundOne = true;
                        }
                        if (i == partGrid.RowCount - 1 && !partGrid.Rows[i].Cells[1].Value.ToString().ToLower().Contains(productsSearchTextBox.Text.ToLower()) && foundOne == false)
                        {
                            MessageBox.Show("Part name not found", "Error");
                            if (partGrid.RowCount > 0)
                            {
                                partGrid.Rows[0].Selected = true;
                            }
                        }
                    }
                }
            }
            else//if the entered search is an INT(NOT a string), the search will be by part ID
            {
                for (int i = 0; i < partGrid.RowCount; i++)//goes through each part in the part grid
                {
                    if ((Inventory.lookupPart(Int32.Parse(productsSearchTextBox.Text)) == true))
                    {
                        partGrid.Rows[Int32.Parse(productsSearchTextBox.Text)].Selected = true;//if the part is found in the datagrid the selection of that row is set to true
                    }
                    if (i == partGrid.RowCount - 1 && Inventory.lookupPart(Int32.Parse(productsSearchTextBox.Text)) == false)
                    {
                        MessageBox.Show("Part ID not found", "Error");
                        if (partGrid.RowCount > 0)
                        {
                            partGrid.Rows[0].Selected = true;
                        }
                    }
                }
            }
        }
    }
}
