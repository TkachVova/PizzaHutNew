using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaHutNew.Domain;

namespace PizzaHutNew.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void OrdersGridView1RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "CompletePending" && e.CommandName != "PendingComplete") return;
            int id = Convert.ToInt32(e.CommandArgument);

            var repo = new PizzaHutDbEntities();
            var order = repo.orders.FirstOrDefault(p => p.id == id);

            if (e.CommandName == "CompletePending")
            {
                if (order.processing == true)
                    {
                        order.processing = false;
                        repo.SaveChanges();
                        Response.Redirect(Request.RawUrl);
                    }
            }
            if (e.CommandName =="PendingComplete")
            {
                if (order.processing == false)
                {
                    order.processing = true;
                    repo.SaveChanges();
                    Response.Redirect(Request.RawUrl);
                }
            }
        }
    }
}