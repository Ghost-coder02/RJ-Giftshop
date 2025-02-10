using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AirplaneTracking.Admin.Repository;
using System.Data;
using System.Xml.Linq;

namespace AirplaneTracking.Admin.Layout
{
    public partial class jjj : System.Web.UI.Page
    {
        // The Page_Load method is executed every time the page is requested. It handles the page's initialization.
        protected void Page_Load(object sender, EventArgs e)
        {
            // IsPostBack --> This condition checks if the page is being loaded for the first time 
            if (!IsPostBack)
            {
                // Purpose: The BindGrid method fetches product data from the database and binds it to the GridView.
                BindGrid();
            }
        }

        private void BindGrid()
        {
            // Assuming you have a method GetProducts() in your repository
            CatRepo repo = new CatRepo(); // carete an object to use the method
            GridView1.DataSource = repo.GetCategories(); // Method to fetch data from database
            GridView1.DataBind(); // Binds the data to the GridView, causing it to render the rows based on the data.
        }

        

        // the event handeler of editing a row
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the GridView to edit mode
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid(); // Method to re-bind the GridView with updated data

        }









        // the event handeler for deleting a row
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Retrieves the Cat_id of the row being deleted and converts it to an integer.
            int CategID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            CatRepo repo = new CatRepo();
            repo.DeleteCat(CategID);
            BindGrid(); // Refresh the grid after deletion
        }




        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int CategID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            // Get the updated values
            TextBox txtName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
            string name = txtName.Text;
            if (!string.IsNullOrEmpty(name))
            {
                // Perform the update operation
                CatRepo repo = new CatRepo();
                repo.UpdateCat(CategID, name);

                // Set the GridView back to read-only mode
                GridView1.EditIndex = -1;
                BindGrid(); // Method to re-bind the GridView with updated data

            }
            else
            {
                // Handle case where the TextBox is null or empty
                System.Diagnostics.Debug.WriteLine("Are you stupid! style=color: red");
            }

        }



        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Set the GridView back to read-only mode
            GridView1.EditIndex = -1;
            BindGrid(); // Method to re-bind the GridView with updated data
        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {

                // find the text box in the footer template
                TextBox txtNewName = (TextBox)GridView1.FooterRow.FindControl("txtAddName");

                // get the value that was entered by the user
                string NewName = txtNewName.Text;

                if (!string.IsNullOrEmpty(NewName))
                {

                    CatRepo repo = new CatRepo();
                    repo.AddCat( NewName);

                    // Set the GridView back to read-only mode
                    GridView1.EditIndex = -1;
                    BindGrid(); // Method to re-bind the GridView with updated data
                }

                else
                {
                    // Handle case where the TextBox is null or empty
                    System.Diagnostics.Debug.WriteLine("Are you stupid! style=color: red");
                }


            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            /*Checking if a row is a data row in the RowDataBound event is important because it ensures that your code only
             processes rows that contain actual data, not header, footer, or other special rows.*/
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find the label for line number
                Label lblLineNumber = (Label)e.Row.FindControl("lblLineNumber");

                // Set the text to the row index (starting from 1 for user-friendly display)
                //ToString() is a method in .NET that is used to convert an object to its string representation
                lblLineNumber.Text = (e.Row.RowIndex + 1).ToString();
            }
        }
    }
}
