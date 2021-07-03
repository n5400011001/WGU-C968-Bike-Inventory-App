using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace C968
{
    public partial class mainScreen : Form
    {
        public mainScreen()
        {
            InitializeComponent();
            partGridData();
            productGridData();
        }
        private void partGridData()//creates the startup part data
        {
            partGrid.DataSource = Inventory.allParts;//tells the part grid that it will be looking at the inventory.allParts list for data
            partGrid.Columns["InHouse"].Visible = false;//the two values below do not need to be shown, just needed for the add/modify screens
            partGrid.Columns["Source"].Visible = false;
        
            Inventory.addPart(new Part("Wheels", 4, 149.50, 2, 200, false, "Wheel Co"));
            Inventory.addPart(new Part("Chain", 8, 49.90, 1, 100, true, "1062327"));
            Inventory.addPart(new Part("Seat", 25, 57.30, 1, 60, false, "Seat Co"));
            Inventory.addPart(new Part("Carbon chassis", 4, 2050.49, 2, 12, false, "Body Frame Co"));
            Inventory.addPart(new Part("Chassis", 10, 500.00, 6, 40, true, "0003487"));
            Inventory.addPart(new Part("Bolt", 500, 0.05, 50, 2000, false, "Bolt Co"));
        }

        private void productGridData()//creates the startup product data
        {
            productGrid.DataSource = Inventory.allProducts;//tells the product grid to look at the inventory.allProducts list for data
            List<int> p1 = new List<int>() {0,1};
            List<int> p2 = new List<int>() {1, 3, 4};
            Inventory.addProduct(new Product("Red carbon", 1, 3200.00, 0, 5, p1));
            Inventory.addProduct(new Product("Silver standard", 5, 450.99, 5, 25, p2));
        }
        private void addPartButton_Click(object sender, EventArgs e)
        {
            var addPart = new addPart();
            addPart.Show(this);
        }


        private void editPartButton_Click(object sender, EventArgs e)
        {
            if (Inventory.allParts.Count > 0)//checks to see if there is actually data to edit before opening the edit part window
            {
                var modifyPart = new modifyPart(partGrid.CurrentCell.RowIndex);
                modifyPart.Show(this);
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            var addProduct = new addProduct();
            addProduct.Show(this);
        }

        private void exitButton_Click(object sender, EventArgs e)//Ends the entire program
        {
            this.Close();
        }

        private void editProductButton_Click(object sender, EventArgs e)
        {
            if(Inventory.allProducts.Count > 0)//checks to see if there is actually data to edit before opening the edit product window
            {
                var modifyProduct = new ModifyProduct(productGrid.CurrentCell.RowIndex);
                modifyProduct.Show(this);
            }
        }

        private void deletePartButton_Click(object sender, EventArgs e)//deletes the selected row of partGrid
        {
            string message = "Are you sure you want to delete this part?";
            DialogResult result = MessageBox.Show(message, "Delete Part?", MessageBoxButtons.YesNo);//displays a message box that makes sure the user wants to delete the selected part
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.partGrid.SelectedRows)
                {
                    Inventory.deletePart(item.Index);
                }
            }
        }

        private void deleteProductButton_Click(object sender, EventArgs e)//deletes the selected row of productGrid
        {
            if (partGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a part", "No part to delete.");
            }
            else
            {
                string message = "Are you sure you want to delete this product?";
                DialogResult result = MessageBox.Show(message, "Delete Product?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.productGrid.SelectedRows)
                    {
                        Inventory.removeProduct(item.Index);
                    }
                }
            }
        }

        private void partsSearchButton_Click(object sender, EventArgs e)
        {
            partGrid.ClearSelection();//unselects everything in the datagrid first
            if (int.TryParse(partsSearchTextBox.Text, out _) == false && partsSearchTextBox.Text.Length >= 0)//If this is a STRING it will search the product by name(string)/NOT by ID(integer)
            {
                if (partsSearchTextBox.Text.Length == 0)
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
                        if (partGrid.Rows[i].Cells[1].Value.ToString().ToLower().Contains(partsSearchTextBox.Text.ToLower()))//compares the value typed in to the current part name
                        {
                            partGrid.Rows[i].Selected = true;//if the part is found in the datagrid the selection of that row is set to true
                            foundOne = true;
                        }
                        if (i == partGrid.RowCount - 1 && !partGrid.Rows[i].Cells[1].Value.ToString().ToLower().Contains(partsSearchTextBox.Text.ToLower()) && foundOne == false)
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
                    if ((Inventory.lookupPart(Int32.Parse(partsSearchTextBox.Text)) == true))
                    {
                        partGrid.Rows[Int32.Parse(partsSearchTextBox.Text)].Selected = true;//if the part is found in the datagrid the selection of that row is set to true
                    }
                    if(i == partGrid.RowCount - 1 && Inventory.lookupPart(Int32.Parse(partsSearchTextBox.Text)) == false)
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

        private void productsSearchButton_Click(object sender, EventArgs e)
        {
            productGrid.ClearSelection();//unselects everything in the datagrid first
            if (int.TryParse(productsSearchTextBox.Text, out _) == false && productsSearchTextBox.Text.Length >= 0)//If this is a STRING it will search the product by name(string)/NOT by ID(integer)
            {
                if (productsSearchTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Please enter a product name or product ID");
                    if (productGrid.RowCount > 0)
                    {
                        productGrid.Rows[0].Selected = true;
                    }
                }
                else
                {
                    bool foundOne = false;
                    for (int i = 0; i < productGrid.RowCount; i++)//goes through each part in the part grid
                    {
                        if (productGrid.Rows[i].Cells[1].Value.ToString().ToLower().Contains(productsSearchTextBox.Text.ToLower()))//compares the value typed in to the current part name
                        {
                            productGrid.Rows[i].Selected = true;//if the part is found in the datagrid the selection of that row is set to true
                            foundOne = true;
                        }
                        if (i == productGrid.RowCount - 1 && !productGrid.Rows[i].Cells[1].Value.ToString().ToLower().Contains(productsSearchTextBox.Text.ToLower()) && foundOne == false)
                        {
                            MessageBox.Show("Product name not found", "Error");
                            if (productGrid.RowCount > 0)
                            {
                                productGrid.Rows[0].Selected = true;
                            }
                        }
                    }
                }
            }
            else//if the entered search is an INT(NOT a string), the search will be by product ID
            {
                for (int i = 0; i < productGrid.RowCount; i++)//goes through each product in the product grid
                {
                    if ((Inventory.lookupPart(Int32.Parse(productsSearchTextBox.Text)) == true))
                    {
                        productGrid.Rows[Int32.Parse(productsSearchTextBox.Text)].Selected = true;//if the product is found in the datagrid the selection of that row is set to true
                    }
                    if (i == productGrid.RowCount - 1 && Inventory.lookupProduct(Int32.Parse(productsSearchTextBox.Text)) == false)
                    {
                        MessageBox.Show("Product ID not found", "Error");
                        if (productGrid.RowCount > 0)
                        {
                            productGrid.Rows[0].Selected = true;
                        }
                    }
                }
            }
        }
    }
}
