using AirplaneTracking.Admin.Repository;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace AirplaneTracking.Admin.Layout
{
    public partial class Products : System.Web.UI.Page
    {

        ProdRepo repo = new ProdRepo();


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
            ProdRepo repo = new ProdRepo(); // carete an object to use the method
            GridViewProducts.DataSource = repo.GetProducts(); // Method to fetch data from database
            GridViewProducts.DataBind(); // Binds the data to the GridView, causing it to render the rows based on the data.



            /****************************************************/

            // adding the categories and the size drop downs
            GridViewRow footerRow = GridViewProducts.FooterRow;
            if (footerRow != null)
            {
                DropDownList ddlFooterCategory = (DropDownList)footerRow.FindControl("NewddlCategory");
                DropDownList ddlFooterSize = (DropDownList)footerRow.FindControl("NewddlSize");
                if (ddlFooterCategory != null)
                {
                    Repository.CatRepo repo2 = new Repository.CatRepo();
                    DataTable categories = repo2.GetCategories();
                    if (categories != null && categories.Rows.Count > 0)
                    {
                        ddlFooterCategory.DataSource = categories;
                        ddlFooterCategory.DataValueField = "Cat_id";
                        ddlFooterCategory.DataTextField = "Name";
                        ddlFooterCategory.DataBind();
                        ddlFooterCategory.Items.Insert(0, new ListItem("Select Category", ""));
                    }
                }


                if (ddlFooterSize != null)
                {
                    DataTable sizes = repo.GetSizes();
                    if (sizes != null && sizes.Rows.Count > 0)
                    {
                        ddlFooterSize.DataSource = sizes;
                        ddlFooterSize.DataValueField = "Size_id";
                        ddlFooterSize.DataTextField = "Name";
                        ddlFooterSize.DataBind();
                        ddlFooterSize.Items.Insert(0, new ListItem("Select Size", ""));
                    }
                }
            }
        }








        protected void GridViewProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            /*Checking if a row is a data row in the RowDataBound event is important because it ensures that your code only
             processes rows that contain actual data, not header, footer, or other special rows.*/
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find the label for line number
                Label lblLineNumber = (Label)e.Row.FindControl("lblLineNumber");

                // Set the text to the row index (starting from 1 for user-friendly display)
                //ToString() is a method in .NET that is used to convert an object to its string representation
                lblLineNumber.Text = (e.Row.RowIndex + 1).ToString();
            }


            // Categories drop down
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddlCategory = (DropDownList)e.Row.FindControl("ddlCategory");

                if (ddlCategory != null)
                {
                    CatRepo repo2 = new CatRepo();

                    DataTable categories = repo2.GetCategories();
                    if (categories != null && categories.Rows.Count > 0)
                    {
                        ddlCategory.DataSource = categories;
                        ddlCategory.DataValueField = "Cat_id";
                        ddlCategory.DataTextField = "Name";
                        ddlCategory.DataBind();
                        ddlCategory.Items.Insert(0, new ListItem("Select Category", ""));
                    }
                }
            }


            // Sizes drop down
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddlSize = (DropDownList)e.Row.FindControl("ddlSize");

                if (ddlSize != null)
                {

                    DataTable Sizes = repo.GetSizes();
                    if (Sizes != null && Sizes.Rows.Count > 0)
                    {
                        ddlSize.DataSource = Sizes;
                        ddlSize.DataValueField = "Size_id";
                        ddlSize.DataTextField = "Name";
                        ddlSize.DataBind();
                        ddlSize.Items.Insert(0, new ListItem("Select Size", ""));
                    }
                }

            }



        }







        protected void GridViewProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewProducts.EditIndex = e.NewEditIndex;
            BindGrid();

        }



        protected void GridViewProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {


                int prodId = Convert.ToInt32(GridViewProducts.DataKeys[e.RowIndex].Value);
                GridViewRow row = GridViewProducts.Rows[e.RowIndex];



                TextBox txtProdName = (TextBox)row.FindControl("txtProdName");
                if (!repo.Validate(txtProdName.Text))
                {
                    Label Error = (Label)row.FindControl("lblProdNameError");
                    Error.Visible = true;

                    throw new Exception("Name is required.");
                }
                string ProdName = txtProdName.Text;




                DropDownList ddlCategory = (DropDownList)row.FindControl("ddlCategory");
                if (!repo.Validate(ddlCategory.SelectedValue.ToString()))
                {

                    Label Error = (Label)row.FindControl("lblCatError");
                    Error.Visible = true;

                    throw new Exception("Category is required.");
                }    
                int Category = Convert.ToInt32(ddlCategory.SelectedValue);




                    DropDownList ddlSize = (DropDownList)row.FindControl("ddlSize");
                    if (!repo.Validate(ddlSize.SelectedValue.ToString()))
                    {
                        Label Error = (Label)row.FindControl("Size_id");
                        Error.Visible = true;

                        throw new Exception("Size is required ");
                    }
                    int Size = Convert.ToInt32(ddlSize.SelectedValue);





                    TextBox txtColor = (TextBox)row.FindControl("txtColor");
                    if (!repo.Validate(txtColor.Text))
                    {
                        Label Error = (Label)row.FindControl("Col_id");
                        Error.Visible = true;

                        throw new Exception("Color is reuired");
                    }
                    string Color = txtColor.Text;




                    TextBox txtMaterial = (TextBox)row.FindControl("txtMaterial");
                    if (!repo.Validate(txtMaterial.Text))
                    {
                        Label Error = (Label)row.FindControl("Material");
                        Error.Visible = true;

                        throw new Exception("Material is reuired");
                    }
                    string Material = txtMaterial.Text;




                    TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");
                    if (!repo.Validate(txtQuantity.Text))
                    {
                        Label Error = (Label)row.FindControl("Quantity");
                        Error.Visible = true;

                        throw new Exception("Quantity is required");
                    }
                    int Quantity = Convert.ToInt32(txtQuantity.Text);





                    TextBox txtOldPrice = (TextBox)row.FindControl("txtOldPrice");
                    if (!repo.Validate(txtOldPrice.Text))
                    {
                        Label Error = (Label)row.FindControl("OldPrice");
                        Error.Visible = true;

                        throw new Exception("The original price is required");
                    }
                    decimal OldPrice = Convert.ToDecimal(txtOldPrice.Text);





                    TextBox txtDiscount = (TextBox)row.FindControl("txtDiscount");
                    decimal Discount;
                    if (!repo.Validate(txtDiscount.Text))
                    {
                        Discount = 0;
                    }
                    Discount = Convert.ToDecimal(txtDiscount.Text);






                    TextBox txtDescription = (TextBox)row.FindControl("txtDescription");
                    string Description;
                    if (!repo.Validate(txtDescription.Text))
                    {
                        Description = null;
                    }
                    Description = txtDescription.Text;



                    CheckBox chkAvailable = (CheckBox)row.FindControl("chkAvailable");
                    bool Available = chkAvailable.Checked;




                    // dic
                    repo.UpdateProd(prodId, ProdName, Category, Size, Color, Material, Quantity, OldPrice, Discount, Description, Available);


                    GridViewProducts.EditIndex = -1;
                    BindGrid();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Validation Error: " + ex.Message);
            }
            
        }





        protected void GridViewProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewProducts.EditIndex = -1;
            BindGrid();
        }




        // change error labels names


        protected void GridViewProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

            if (e.CommandName == "Add")
            {
                try
                {
                   
                    TextBox txtProdName = (TextBox)GridViewProducts.FooterRow.FindControl("NewtxtProdName");
                    if (!repo.Validate(txtProdName.Text))
                    {
                        Label Error = (Label)GridViewProducts.FooterRow.FindControl("NewlblProdNameError");
                        Error.Visible = true;

                        throw new Exception("Name is required.");
                    }
                    string ProdName = txtProdName.Text;



                    DropDownList ddlCategory = (DropDownList)GridViewProducts.FooterRow.FindControl("NewddlCategory");

                    if (!repo.Validate(ddlCategory.SelectedValue.ToString()))
                    {
                        Label Error = (Label)GridViewProducts.FooterRow.FindControl("NewlblCatError");
                        Error.Visible = true;


                        throw new Exception("Category is required.");

                    }
                    int Category = Convert.ToInt32(ddlCategory.SelectedValue.ToString());





                    DropDownList ddlSize = (DropDownList)GridViewProducts.FooterRow.FindControl("NewddlSize");
                    if (!repo.Validate(ddlSize.SelectedValue.ToString()))
                    {
                        Label Error = (Label)GridViewProducts.FooterRow.FindControl("NewlblSizeError");
                        Error.Visible = true;


                        throw new Exception("Size is required.");

                    }
                    int Size = Convert.ToInt32(ddlSize.SelectedValue.ToString());
                    
                    



                    TextBox txtColor = (TextBox)GridViewProducts.FooterRow.FindControl("NewtxtColor");
                    if (!repo.Validate(txtColor.Text))
                    {
                        Label Error = (Label)GridViewProducts.FooterRow.FindControl("NewlblColError");
                        Error.Visible = true;

                        throw new Exception("Color is required.");
                    }
                    string Color = txtColor.Text;





                    TextBox txtMaterial = (TextBox)GridViewProducts.FooterRow.FindControl("NewtxtMaterial");
                    if (!repo.Validate(txtMaterial.Text))
                    {
                        Label Error = (Label)GridViewProducts.FooterRow.FindControl("NewlblMatError");
                        Error.Visible = true;

                        throw new Exception("Material is required.");
                    }
                    string Material = txtMaterial.Text;




                    TextBox txtQuantity = (TextBox)GridViewProducts.FooterRow.FindControl("NewtxtQuantity");
                    if (!repo.Validate(txtQuantity.Text))
                    {
                        Label Error = (Label)GridViewProducts.FooterRow.FindControl("NewlblQuanError");
                        Error.Visible = true;

                        throw new Exception("Quantity is required.");
                    }
                    int Quantity = Convert.ToInt32(txtQuantity.Text);




                    TextBox txtOldPrice = (TextBox)GridViewProducts.FooterRow.FindControl("NewtxtOldPrice");
                    if (!repo.Validate(txtOldPrice.Text))
                    {
                        Label Error = (Label)GridViewProducts.FooterRow.FindControl("NewlblOldPriceError");
                        Error.Visible = true;

                        throw new Exception("OldPrice is required.");
                    }
                    decimal OldPrice = Convert.ToDecimal(txtOldPrice.Text);




                    TextBox txtDiscount = (TextBox)GridViewProducts.FooterRow.FindControl("NewtxtDiscount");
                    decimal Discount;
                    if (!repo.Validate(txtDiscount.Text))
                    {
                        Discount = 0;
                    }
                    Discount = Convert.ToDecimal(txtDiscount.Text);



                    TextBox txtDescription = (TextBox)GridViewProducts.FooterRow.FindControl("NewtxtDescription");
                    string Description;
                    if (!repo.Validate(txtDescription.Text))
                    {
                        Description= null;
                    }
                    Description = txtDescription.Text;



                    CheckBox chkAvailable = (CheckBox)GridViewProducts.FooterRow.FindControl("NewchkAvailable");
                    bool Available = chkAvailable.Checked;


                    //if (repo.Validate(Convert.ToString(Category.ToString()), Convert.ToString(Size.ToString()), Color, Material, Convert.ToString(Quantity.ToString()), Convert.ToString(OldPrice.ToString()), Convert.ToString(Discount.ToString()), Description, Convert.ToString(Available.ToString())))
                    //{
                        repo.AddProd(ProdName, Category, Size, Color, Material, Quantity, OldPrice, Discount, Description, Available);

                        // Set the GridView back to read-only mode
                        GridViewProducts.EditIndex = -1;
                        BindGrid(); // Method to re-bind the GridView with updated data
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Validation Error: " + ex.Message);
                }



            }



            
            


            if (e.CommandName == "Disable")
            {

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                var row = GridViewProducts.Rows[rowIndex];

                int prodId = Convert.ToInt32(GridViewProducts.DataKeys[rowIndex].Value);
               

               
                repo.Disable(prodId);

                var btnDisable = (Button)row.FindControl("btnDisable");
                var btnEdit = (Button)row.FindControl("btnEdit");
                var btnEnable = (Button)row.FindControl("btnEnable");


                if (btnDisable != null && btnEdit != null && btnEnable != null)
                {
                    


                    btnDisable.Visible = false;
                    btnEdit.Visible = false;
                    btnEnable.Visible = true;
                }



                //to skip the last cell (actions) and not disable the buttons
                int cellCount = row.Cells.Count;
                for (int i = 0; i < cellCount-1; i++)
                {
                    TableCell cell = row.Cells[i];
                    foreach (Control control in cell.Controls)
                    {
                        if (control is WebControl webControl)
                        {
                            row.BackColor = Color.LightGray;
                            row.ForeColor = Color.Gray;
                            webControl.Enabled = false;
                        }
                    }
                }



            }




            if (e.CommandName == "Enable")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                var row = GridViewProducts.Rows[rowIndex];

                
                // rowIndex here is the same as the product id
                repo.Enable(rowIndex);


                var btnDisable = (Button)row.FindControl("btnDisable");
                var btnEdit = (Button)row.FindControl("btnEdit");
                var btnEnable = (Button)row.FindControl("btnEnable");

                
                
                    row.BackColor = Color.White;
                    row.ForeColor = Color.Black;


                    btnDisable.Visible = true;
                    btnEdit.Visible = true;
                    btnEnable.Visible = false;
                


                foreach (TableCell cell in row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        if (control is WebControl webControl)
                        {
                            webControl.Enabled = true;
                        }
                    }
                }
            }




        }



        

       

    }
}