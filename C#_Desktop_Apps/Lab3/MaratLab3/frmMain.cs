using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MaratLab3.Models;


/*
 * This app is created for doing CRUD operations with the 'Products' table of the 'TechSupport' database.
 * This is the main form of the application where contents of the 'Products' table are displayed and buttons
 * for adding a new row, updating or deleting a selected row are placed.
 * Author: Marat Nikitin
 * SAIT, OOSD course
 * When: January 2022
 */

namespace MaratLab3
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent(); // initializing the form's content
        }

        private TechSupportContext context = new TechSupportContext(); // creating an object of TechSupportContext class object
        private Products selectedProduct; // represents a selected Products class instance (which represents a row in the DB table)

        // when the main form loads
        private void frmMain_Load(object sender, EventArgs e)
        {
            using (TechSupportContext db = new TechSupportContext()) // creating a DBContext instance
            {
                listBox.DataSource = db.Products.ToList(); // displaying data from the 'Products' table of the DB in the listbox
                // products are displayed beautifully in the listbox due to overridden ToString() method in the 'Products' class (it's inside the 'Models' folder)
                // connection string is placed in the 'App.config' file inside this project 
            }
        }

        // when the "Add" button is clicked
        private void buttonAdd_Click(object sender, EventArgs e)
        {           
            var addUpdateForm = new frmSecond // an instance of the second form is created
            {
                AddProduct = true // This is a public parameter from the second form, true means that the "Add" button was pressed
            };
            DialogResult result = addUpdateForm.ShowDialog(); // the second form opens as modal form
            if (result == DialogResult.OK)
            {
                selectedProduct = addUpdateForm.Product; // information about the added product (entered in the second form) is saved as a Product class instance
                try
                {
                    context.Products.Add(selectedProduct); // a new row is added
                    context.SaveChanges(); // the new row is saved in the DB
                    MessageBox.Show("1 row was successfuly added to the 'Products' table of the TechSupport database.", "Success!"); // feedback to a user
                    RefreshListBox(); // using a custom-created method to refresh the listbox's contents
                }
                catch (DbUpdateException ex) // if saving data in the DB fails
                {
                    HandleDataError(ex); // this method is described below
                }
                catch (Exception ex) // if some other exception happens
                {
                    HandleGeneralError(ex); // this method is described below
                }                
            }
        }

        // when the "Modify" button is clicked
        private void buttonModify_Click(object sender, EventArgs e)
        {
            selectedProduct = (Products)listBox.SelectedItem; // picking the selected line from the listbox
            var addUpdateForm = new frmSecond // creating a new instance of the second form
            {
                AddProduct = false, // it means that the "Modify" button was pressed 
                Product = selectedProduct // it's a public parameter of the second form
            };
            DialogResult result = addUpdateForm.ShowDialog(); // the second form opens as modal form
            if (result == DialogResult.OK)
            {
                selectedProduct = addUpdateForm.Product; // saving a selected product as a parameter for further manupulations
                try
                {
                    context.Products.Update(selectedProduct); // updating the selected row
                    context.SaveChanges(); // the updated row is saved in the DB
                    MessageBox.Show("1 selected row was successfuly updated in the 'Products' table of the TechSupport database.", "Success!"); // feedback to a user
                    RefreshListBox(); // using a custom-created method to refresh the listbox's contents
                }
                catch (DbUpdateException ex) // if saving data in the DB fails
                {
                    HandleDataError(ex); // this custom-made method is described below
                }
                catch (Exception ex) // if some other exception hapens
                {
                    HandleGeneralError(ex); // this custom-made method is described below
                }
            }
        }

        // when the "Remove" button is clicked
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            selectedProduct = (Products)listBox.SelectedItem; // picking the selected row from the listbox for deleting it later
            DialogResult result =
                MessageBox.Show(
                $"Delete {selectedProduct.Name}?", "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question); // making sure that user wants to delete the selected row
            if (result == DialogResult.Yes) // it means that the Delete operation was manually confirmed by a user
            {
                try
                {
                    context.Products.Remove(selectedProduct); // deleting the row
                    context.SaveChanges(); // the new row is deleted from the DB, the change is saved
                    MessageBox.Show("1 selected row was successfuly deleted from the 'Products' table of the TechSupport database", "Success!"); // feedback to a user
                    RefreshListBox(); // using a custom-created method to refresh the listbox's contents
                }
                catch (DbUpdateException ex) // if saving data in the DB fails
                {
                    HandleDataError(ex); // this custom-made method is described below
                }
                catch (Exception ex) // if some other exception hapens
                {
                    HandleGeneralError(ex); // this custom-made method is described below
                }
            }
        }

        // when the "Exit" button is clicked
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close(); // closing the main WinForm leads to closing the app
        }

        /// <summary>
        /// Handling DB Update Exception error by displaying appropriate information about the error to a user
        /// </summary>
        /// <param name="ex"> Instance of an exception </param>
        private void HandleDataError(DbUpdateException ex)
        {
            string errorMessage = "";
            var sqlException = (SqlException)ex.InnerException;
            foreach (SqlError error in sqlException.Errors)
            {
                errorMessage += "ERROR CODE: " + error.Number + " " +
                error.Message + "\n";
            }
            MessageBox.Show(errorMessage); // displaying error code, number and message to a user in a message box
        }

        /// <summary>
        /// Handling al other unforeseen errors by displaying appropriate information about it in a message box
        /// </summary>
        /// <param name="ex"> Instance of an exception </param>
        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString()); // displaying appropriate information about an error in a message box
        }

        /// <summary>
        /// Custom-made method allowing refreshing the listbox's data after changes made in the database
        /// </summary>
        private void RefreshListBox() 
        {
            listBox.DataSource = null; // setting DataSource as null helps to clear the listbox in the next line
            listBox.Items.Clear(); // clearing the listbox
            using (TechSupportContext db = new TechSupportContext()) // creating a new DBContext instance
            {
                listBox.DataSource = db.Products.ToList();   // displaying the refreshed 'Products' table's contents of the database
            }
        }
    }
}
