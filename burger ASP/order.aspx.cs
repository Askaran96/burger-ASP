using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace burger_ASP
{
    public partial class order : System.Web.UI.Page
    {
        Entities1 obj_ent = new Entities1();
        shop burgers = new shop();
        protected void Page_Load(object sender, EventArgs e)
        {
            order_grid.DataSource = obj_ent.Burgers.ToList();
            order_grid.DataBind();//this puts the data into the data grid
            fries_grid.DataSource = obj_ent.Fries.ToList();
            fries_grid.DataBind();
            Burger.DataSource = obj_ent.mains.ToList();
            Burger.DataBind();
        }

        protected void Burger_SelectedIndexChanged(object sender, EventArgs e)
        {
            ordertxt .Text = Burger.SelectedRow.Cells[1].Text;
            nametxt.Text = Burger.SelectedRow.Cells[2].Text;//this puts the data from the data grid to text box
           burgeridtxt .Text = Burger.SelectedRow.Cells[3].Text;
            Friestxt.Text = Burger.SelectedRow.Cells[4].Text;
        }

        protected void order_grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            burgeridtxt .Text = order_grid .SelectedRow.Cells[1].Text;

        }

        protected void fries_grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Friestxt.Text = fries_grid .SelectedRow.Cells[1].Text;

        }

        

       

        
        protected void btnadd_Click(object sender, EventArgs e)
        {
            burgers.OrderAdd(nametxt.Text, Convert.ToInt32(burgeridtxt.Text), Convert.ToInt32(Friestxt.Text));
            Response.Redirect("order.aspx");//this add the order
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            burgers.OrderChange(Convert.ToInt32(ordertxt.Text), nametxt.Text, Convert.ToInt32(burgeridtxt.Text), Convert.ToInt32(Friestxt.Text));
            Response.Redirect("order.aspx");//this chnages the order
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            burgers.order_complete(Convert.ToInt32(ordertxt.Text));
            Response.Redirect("order.aspx");//this delets tthe order when its complete
        }
    }
}