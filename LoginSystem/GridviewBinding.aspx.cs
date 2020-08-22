using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Linq.Expressions;

namespace LoginSystem
{
    public partial class GridviewBinding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dtl = (DataTable)ViewState["Row"];
            if (dtl.Rows.Count > 0)
            {
                dtl.Rows[e.RowIndex].Delete();
                GridView1.DataSource = dtl;
                GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void CreateNewRow()
        {
            try {
                DataTable datatb = new DataTable();
                if (ViewState["Row"] != null)
                {
                    datatb = (DataTable)ViewState["Row"];
                    DataRow dr1 = datatb.NewRow();
                    if (datatb.Rows.Count > 0)
                    {
                        dr1["empid"] = txtId.Text;
                        dr1["name"] = txtName.Text;
                        dr1["contact"] = txtContact.Text;
                        dr1["email"] = txtEmail.Text;
                        datatb.Rows.Add(dr1);
                        ViewState["Row"] = datatb;
                        GridView1.DataSource = ViewState["Row"];
                        GridView1.DataBind();
                    }
                }
                else
                {
                    datatb.Columns.Add("empid", typeof(int));
                    datatb.Columns.Add(new DataColumn("name", typeof(string)));
                    datatb.Columns.Add("contact", typeof(string));
                    datatb.Columns.Add("email", typeof(string));

                    DataRow dr1 = datatb.NewRow();
                    dr1 = datatb.NewRow();
                    dr1["empid"] = txtId.Text;
                    dr1["name"] = txtName.Text;
                    dr1["contact"] = txtContact.Text;
                    dr1["email"] = txtEmail.Text;
                    datatb.Rows.Add(dr1);
                    ViewState["Row"] = datatb;
                    GridView1.DataSource = ViewState["Row"];
                    GridView1.DataBind();
                }
            } catch (Exception ex) {

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CreateNewRow();
        }

        protected void btnResponse_Click(object sender, EventArgs e)
        {
            if (sender == btnResponse)
            {
                Response.Write("<h1>" + DateTime.Now.ToString() + "</h1>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "ID";
            dc.DataType = typeof(int);
            dt.Columns.Add(dc);

            
            DataColumn dc2 = new DataColumn();
            dc2.ColumnName = "ProductName";
            dc2.DataType = typeof(string);
            dt.Columns.Add(dc2);

           
            DataColumn dc3 = new DataColumn();
            dc3.ColumnName = "ProductPrice";
            dc3.DataType = typeof(int);
            dt.Columns.Add(dc3);

            dt.Rows.Add(new object[] { "1","Mobile","2123" });
            dt.Rows.Add(new object[] { "2","Pc","7723" });

            GridView3.DataSource = dt;
            GridView3.DataBind();
        }
    }
}