using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C968
{
    public partial class addProduct : Form
    {
        int thisNewProductsIndex = Inventory.ProductIndex;
        BindingList<Part> thisProductsParts = new BindingList<Part>();//Create temp BindingList of parts for this product's associated parts
        public addProduct()
        {
            InitializeComponent();
            addProductIdField.Text = thisNewProductsIndex.ToString();//Grabs this new product's index
            partGrid.DataSource = Inventory.allParts;//tells the part grid that it will be looking at the inventory.allParts list for data
            partGrid.Columns["InHouse"].Visible = false;//the two values below do not need to be shown, just needed for the add/modify screens
            partGrid.Columns["Source"].Visible = false;
            addProductAssociatedPartGrid.DataSource = thisProductsParts;//Bind the temp list of parts to the modifyProductAssociatedPartGrid
            addProductAssociatedPartGrid.Columns["InHouse"].Visible = false;//the two values below do not need to be shown, just needed for the add/modify screens
            addProductAssociatedPartGrid.Columns["Source"].Visible = false;
        }

        private void addProductCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addProductSaveButton_Click(object sender, EventArgs e)
        {
            addProductErrorProvider.Clear();//clears the red x notification after a return

            if (thisProductsParts.Count == 0)//displays an error if the product doesnt have any associated parts
            {
                MessageBox.Show("Each product must contain at least one associated part. Please add a part.", "Product has no associated parts!");
            }

            if (string.IsNullOrEmpty(addProductNameField.Text))//if the Name field is blank
            {
                addProductErrorProvider.SetError(addProductNameField, "Please enter a valid part name.");//tooltip message displays the error
                return;
            }
            if (string.IsNullOrEmpty(addProductQuantityField.Text) ||//if the quantity field is blank or
                int.TryParse(addProductQuantityField.Text, out _) == false ||//the quantity field is not an integer or
                Int32.Parse(addProductQuantityField.Text) < 0)//the quantity field is less than 0
            {
                addProductErrorProvider.SetError(addProductQuantityField, "Please enter a valid quantity 0 or greater");//then the tooltip displays the error
                return;
            }//the next few if statements do the same just for different specific requirements
            if (string.IsNullOrEmpty(addProductPriceField.Text) ||
                double.TryParse(addProductPriceField.Text, out _) == false ||
                double.Parse(addProductPriceField.Text) < 0)
            {
                addProductErrorProvider.SetError(addProductPriceField, "Please enter a valid part price 0 or greater.");
                return;
            }
            if (string.IsNullOrEmpty(addProductMinField.Text) ||
                int.TryParse(addProductMinField.Text, out _) == false ||
                Int32.Parse(addProductMinField.Text) < 0)
            {
                addProductErrorProvider.SetError(addProductMinField, "Please enter a valid minimum quantity 0 or greater.");
                return;
            }
            if (string.IsNullOrEmpty(addProductMaxField.Text) ||
                int.TryParse(addProductMaxField.Text, out _) == false ||
                Int32.Parse(addProductMaxField.Text) < 0)
            {
                addProductErrorProvider.SetError(addProductMaxField, "Please enter a valid maximum quantity.");
                return;
            }
            if (Int32.Parse(addProductMaxField.Text) < int.Parse(addProductMinField.Text))
            {
                addProductErrorProvider.SetError(addProductMaxField, "Please enter a maximum quantity that is greater than the minimum.");
                return;
            }

            List<int> tempListOfPartsIndex = new List<int>();//creates a temp list of parts indexes to create new product
            for(int x = 0; x < thisProductsParts.Count; x++)//goes through all the associated parts added
            {
                tempListOfPartsIndex.Add(thisProductsParts[x].ID);//copies the associated parts indexes to the temp list
            }
            Inventory.addProduct(new Product(addProductNameField.Text, //grabs all the valid values from all the fields to create a new part object
                                        Int32.Parse(addProductQuantityField.Text),
                                        Convert.ToDouble(addProductPriceField.Text),
                                        Int32.Parse(addProductMinField.Text),
                                        Int32.Parse(addProductMaxField.Text),
                                        tempListOfPartsIndex
                                        ));
            this.Close();
        }

        private void addPartToProductButton_Click(object sender, EventArgs e)
        {
            bool okToAddPartToProduct = true;//If the product already has a part thats trying to be added this flag will be set to false
            for (int i = 0; i < thisProductsParts.Count; i++)//Goes through the parts already associated with this product
            {
                if (thisProductsParts[i].ID == Int32.Parse(partGrid.SelectedRows[0].Cells["ID"].Value.ToString()))//If the selected part is already found to be associated
                {
                    okToAddPartToProduct = false;//this flag is set to false and wont add the part 
                }
            }
            if (okToAddPartToProduct == true)//if the selected inventory part isn't found to be associated with this product
            {
                foreach (DataGridViewRow item in this.partGrid.SelectedRows)
                {
                    thisProductsParts.Add(Inventory.allParts[item.Index]);//add the inventory part as an associated part to this product
                }
            }
        }

        private void deletePartFromProductButton_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this part?";
            DialogResult result = MessageBox.Show(message, "Delete Part?", MessageBoxButtons.YesNo);//displays a message box that makes sure the user wants to delete the selected part
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.addProductAssociatedPartGrid.SelectedRows)//Selects the whole row of highlighted cells
                {
                    addProductAssociatedPartGrid.Rows.RemoveAt(item.Index);//Deletes the whole row of selected cells
                }
            }

        }

        private void productsSearchButton_Click(object sender, EventArgs e)
        {
            partGrid.ClearSelection();//unselects everything in the datagrid first
            if (int.TryParse(productsSearchTextBox.Text, out _) == false)//if the search is text(string)/NOT an integer
            {
                for (int i = 0; i < partGrid.RowCount; i++)//goes through the length of the parts found in the parts datagrid
                {
                    if (partGrid.Rows[i].Cells[1].Value.ToString().ToLower() == productsSearchTextBox.Text.ToLower())//compares the value typed in to the current part name
                    {
                        partGrid.Rows[i].Selected = true;//if the part is found in the datagrid the selection of that row is set to true
                    }
                    else if (partGrid.Rows[i].Cells[1].Value.ToString().ToLower().Contains(productsSearchTextBox.Text.ToLower()))//looks for substrings withing the part name
                    {
                        partGrid.Rows[i].Selected = true;//if the part is found in the datagrid the selection of that row is set to true
                    }
                }
            }
            else
            {
                if (Inventory.allProducts[thisNewProductsIndex - 1].lookupAssociatedPart(Int32.Parse(productsSearchTextBox.Text)) == Int32.Parse(productsSearchTextBox.Text))
                {
                    partGrid.Rows[Int32.Parse(productsSearchTextBox.Text)].Selected = true;
                }
                else
                {
                    MessageBox.Show("No product with that ID was found", "Error");
                }
            }
        }
    }
}
