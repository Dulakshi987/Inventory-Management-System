using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.View.Admin
{
    public partial class View_Inventory : System.Web.UI.Page
    {
        Inventory.InventorySoapClient obj = new Inventory.InventorySoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                Inventory.InventorySoapClient obj = new Inventory.InventorySoapClient();
                DataTable inventoryTable = obj.ViewAllInventories();

                GridViewinventory.DataSource = inventoryTable;
                GridViewinventory.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Error retrieving inventories: " + ex.Message + "');</script>");
            }
        }

    }
}
