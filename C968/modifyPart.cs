using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C968
{
    public partial class modifyPart : Form
    {
        public int index;
        public modifyPart(int ID)
        {
            index = ID;
            InitializeComponent();
            modifyPartIdField.Text = Inventory.allParts[index].ID.ToString();
            if(Inventory.allParts[index].InHouse == true)
            {
                modifyPartInHouseRadio.Checked = true;
            }
            else
            {
                modifyPartOutsourcedRadio.Checked = true;
            }

            modifyPartNameField.Text = Inventory.allParts[index].Name.ToString();
            modifyPartQuantityField.Text = Inventory.allParts[index].Quantity.ToString();
            modifyPartPriceField.Text = Inventory.allParts[index].Price.ToString();
            modifyPartMaxField.Text = Inventory.allParts[index].Max.ToString();
            modifyPartMinField.Text = Inventory.allParts[index].Min.ToString();
            modifyPartSourceField.Text = Inventory.allParts[index].Source.ToString();
            
        }

        private void modifyPartCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modifyPartSaveButton_Click(object sender, EventArgs e)
        {
            modifyPartErrorProvider.Clear();//clears the red x notification after a return

            if (string.IsNullOrEmpty(modifyPartNameField.Text))//if the Name field is blank
            {
                modifyPartErrorProvider.SetError(modifyPartNameField, "Please enter a valid part name.");//tooltip message displays the error
                return;
            }
            if (string.IsNullOrEmpty(modifyPartQuantityField.Text) ||//if the quantity field is blank or
                int.TryParse(modifyPartQuantityField.Text, out _) == false ||//the quantity field is not an integer or
                Int32.Parse(modifyPartQuantityField.Text) < 0)//the quantity field is less than 0
            {
                modifyPartErrorProvider.SetError(modifyPartQuantityField, "Please enter a valid quantity 0 or greater");//then the tooltip displays the error
                return;
            }//the next few if statements do the same just for different specific requirements
            if (string.IsNullOrEmpty(modifyPartPriceField.Text) ||
                double.TryParse(modifyPartPriceField.Text, out _) == false ||
                double.Parse(modifyPartPriceField.Text) < 0)
            {
                modifyPartErrorProvider.SetError(modifyPartPriceField, "Please enter a valid part price 0 or greater.");
                return;
            }
            if (string.IsNullOrEmpty(modifyPartMinField.Text) ||
                int.TryParse(modifyPartMinField.Text, out _) == false ||
                Int32.Parse(modifyPartMinField.Text) < 0)
            {
                modifyPartErrorProvider.SetError(modifyPartMinField, "Please enter a valid minimum quantity 0 or greater.");
                return;
            }
            if (string.IsNullOrEmpty(modifyPartMaxField.Text) ||
                int.TryParse(modifyPartMaxField.Text, out _) == false ||
                Int32.Parse(modifyPartMaxField.Text) < 0)
            {
                modifyPartErrorProvider.SetError(modifyPartMaxField, "Please enter a valid maximum quantity.");
                return;
            }
            if (Int32.Parse(modifyPartMaxField.Text) < int.Parse(modifyPartMinField.Text))
            {
                modifyPartErrorProvider.SetError(modifyPartMaxField, "Please enter a maximum quantity that is greater than the minimum.");
                return;
            }
            if (string.IsNullOrEmpty(modifyPartSourceField.Text) && modifyPartInHouseRadio.Checked == true)
            {
                modifyPartErrorProvider.SetError(modifyPartSourceField, "Please enter a valid Machine ID.");
                return;
            }
            if (modifyPartInHouseRadio.Checked == true && int.TryParse(modifyPartSourceField.Text, out _) == false)//will give error if the inhouse is checked and the field isnt a number
            {
                modifyPartErrorProvider.SetError(modifyPartSourceField, "Machine ID requires a number.");
                return;
            }
            if (string.IsNullOrEmpty(modifyPartSourceField.Text) && modifyPartOutsourcedRadio.Checked == true)
            {
                modifyPartErrorProvider.SetError(modifyPartSourceField, "Please enter a valid company source name.");
                return;
            };

            Inventory.updatePart(index, 
                                 modifyPartNameField.Text,
                                 modifyPartQuantityField.Text,
                                 modifyPartPriceField.Text,
                                 modifyPartMinField.Text,
                                 modifyPartMaxField.Text,
                                 modifyPartInHouseRadio.Checked,
                                 modifyPartSourceField.Text);
            this.Close();
        }

        private void modifyPartInHouseRadio_CheckedChanged_1(object sender, EventArgs e)
        {
            modifyPartSourceLabel.Text = "Machine ID";
        }

        private void modifyPartOutsourcedRadio_CheckedChanged(object sender, EventArgs e)
        {
            modifyPartSourceLabel.Text = "Company Name";
        }
    }
}
