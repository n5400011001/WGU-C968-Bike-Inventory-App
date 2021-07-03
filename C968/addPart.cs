using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C968
{
    public partial class addPart : Form
    {
        public addPart()
        {
            InitializeComponent();
            addPartIdField.Text = Inventory.PartIndex.ToString();//grabs this new part's index
        }

        private void addPartCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addPartInHouseRadio_CheckedChanged(object sender, EventArgs e)
        {
            addPartSourceLabel.Text = "Machine ID";
        }

        private void addPartOutsourcedRadio_CheckedChanged(object sender, EventArgs e)
        {
            addPartSourceLabel.Text = "Company Name"; 
        }

        //Clicking the save button validates all of the fields and lets the user know or any errors
        public void addPartSaveButton_Click(object sender, EventArgs e)
        {
            addPartErrorProvider.Clear();//clears the red x notification after a return

            if (string.IsNullOrEmpty(addPartNameField.Text))//if the Name field is blank
            {
                addPartErrorProvider.SetError(addPartNameField, "Please enter a valid part name.");//tooltip message displays the error
                return;
            }
            if (string.IsNullOrEmpty(addPartQuantityField.Text) ||//if the quantity field is blank or
                int.TryParse(addPartQuantityField.Text, out _) == false ||//the quantity field is not an integer or
                Int32.Parse(addPartQuantityField.Text) < 0)//the quantity field is less than 0
            {
                addPartErrorProvider.SetError(addPartQuantityField, "Please enter a valid quantity 0 or greater");//then the tooltip displays the error
                return;
            }//the next few if statements do the same just for different specific requirements
            if (string.IsNullOrEmpty(addPartPriceField.Text) ||
                double.TryParse(addPartPriceField.Text, out _) == false ||
                double.Parse(addPartPriceField.Text) < 0)
            {
                addPartErrorProvider.SetError(addPartPriceField, "Please enter a valid part price 0 or greater.");
                return;
            }
            if (string.IsNullOrEmpty(addPartMinField.Text) ||
                int.TryParse(addPartMinField.Text, out _) == false ||
                Int32.Parse(addPartMinField.Text) < 0)
            {
                addPartErrorProvider.SetError(addPartMinField, "Please enter a valid minimum quantity 0 or greater.");
                return;
            }
            if (string.IsNullOrEmpty(addPartMaxField.Text) ||
                int.TryParse(addPartMaxField.Text, out _) == false ||
                Int32.Parse(addPartMaxField.Text) < 0)
            {
                addPartErrorProvider.SetError(addPartMaxField, "Please enter a valid maximum quantity.");
                return;
            }
            if (Int32.Parse(addPartMaxField.Text) < int.Parse(addPartMinField.Text))
            {
                addPartErrorProvider.SetError(addPartMaxField, "Please enter a maximum quantity that is greater than the minimum.");
                return;
            }
            if (string.IsNullOrEmpty(addPartSourceField.Text) && addPartInHouseRadio.Checked == true)
            {
                addPartErrorProvider.SetError(addPartSourceField, "Please enter a valid Machine ID.");
                return;
            }
            if(addPartInHouseRadio.Checked == true && int.TryParse(addPartSourceField.Text, out _) == false)
            {
                addPartErrorProvider.SetError(addPartSourceField, "Machine ID requires a number.");
                return;
            }
            if (string.IsNullOrEmpty(addPartSourceField.Text))
            {
                addPartErrorProvider.SetError(addPartSourceField, "Please enter a valid company source name.");
                return;
            };

            Inventory.addPart(new Part(addPartNameField.Text, //grabs all the valid values from all the fields to create a new part object
                                        Int32.Parse(addPartQuantityField.Text), 
                                        Convert.ToDouble(addPartPriceField.Text), 
                                        Int32.Parse(addPartMinField.Text), 
                                        Int32.Parse(addPartMaxField.Text), 
                                        addPartInHouseRadio.Checked, 
                                        addPartSourceField.Text));
            this.Close();
        }
    }
}
