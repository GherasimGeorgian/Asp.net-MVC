using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginSystem
{
    public partial class ImageSlide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                string[] cars = new string[] {  "Opel", "Dacia", "Fiat" };
                for (int i = 0; i < cars.Length; i++)
                {
                    DropDownList1.Items.Add(cars[i]);
                }
                Image2.ImageUrl = "~/Image/" + cars[0] + ".jpg";
                slide();
               
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            slide();  
        }
        void slide()
        {
            Random rnd = new Random();
            int select = rnd.Next(1, 3);
            Image1.ImageUrl = "~/Image/" + select.ToString() + ".jpg";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = DropDownList1.SelectedValue;
            Image2.ImageUrl = "~/Image/" + str + ".jpg";
            
        }
    }
}