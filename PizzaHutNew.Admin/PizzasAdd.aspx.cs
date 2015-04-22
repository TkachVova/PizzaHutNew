using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaHutNew.Domain;
using System.IO;

namespace PizzaHutNew.Admin
{
    public partial class PizzasAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //after insert from detailsview dawnload image to ..\\PizzaHut\\img\\pizzas with a name of inserted pizza id
        protected void PizzasDetailsView_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            Boolean fileOK = false;
            string path = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/")).Parent.FullName;

            path += "\\PizzaHutNew\\img\\pizzas\\";
            if (ProductImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(ProductImage.FileName).ToLower();
                String[] allowedExtensions = { ".png" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                var repo = new PizzaHutDbEntities();
                int LastPizzaId = repo.pizzas.Max(p => p.id);
                string newPizzaImageName = LastPizzaId.ToString() + ".png";
                // Save to pizzaHut\\img\pizzas folder.
                ProductImage.PostedFile.SaveAs(path + newPizzaImageName);
            }
        }
    }
}