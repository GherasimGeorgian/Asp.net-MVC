using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using LoginSystem.Models;

namespace LoginSystem.Controllers
{
    public class ProductController : Controller
    {
        string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\MvcCrudDB.mdf; Integrated Security = True; Connect Timeout = 30";

        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                sqlCon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM Product",sqlCon);
                sqlda.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View(new ProductModel());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel prodModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Product VALUES(@ProductName,@Price,@Count)";
                SqlCommand sqlcmd = new SqlCommand(query,sqlCon);
                sqlcmd.Parameters.AddWithValue("@ProductName",prodModel.ProductName);
                sqlcmd.Parameters.AddWithValue("@Price",prodModel.Price);
                sqlcmd.Parameters.AddWithValue("@Count",prodModel.Count);
                sqlcmd.ExecuteNonQuery();
            }
                return RedirectToAction("Index");
           
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductModel prodModel = new ProductModel();
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                sqlCon.Open();
                string query = "SELECT * FROM Product WHERE ProductID = @ProductID";
                SqlDataAdapter sqlda = new SqlDataAdapter(query,sqlCon);
                sqlda.SelectCommand.Parameters.AddWithValue("@ProductID",id);
                sqlda.Fill(dtblProduct);
            }
            if (dtblProduct.Rows.Count == 1)
            {
                prodModel.ProductID = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
                prodModel.ProductName = dtblProduct.Rows[0][1].ToString();
                prodModel.Price = Convert.ToDecimal(dtblProduct.Rows[0][2].ToString());
                prodModel.Count = Convert.ToInt32(dtblProduct.Rows[0][3].ToString());
                return View(prodModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductModel prodModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Product SET ProductName=@ProductName, Price=@Price, Count=@Count WHERE ProductID=@ProductID";
                SqlCommand sqlcmd = new SqlCommand(query,sqlCon);
                sqlcmd.Parameters.AddWithValue("@ProductID",prodModel.ProductID);
                sqlcmd.Parameters.AddWithValue("@ProductName",prodModel.ProductName);
                sqlcmd.Parameters.AddWithValue("@Price",prodModel.Price);
                sqlcmd.Parameters.AddWithValue("@Count",prodModel.Count);
                sqlcmd.ExecuteNonQuery();
            }
            
            
                return RedirectToAction("Index");
            
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Product WHERE ProductID=@ProductID";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlcmd.Parameters.AddWithValue("@ProductID", id);

                sqlcmd.ExecuteNonQuery();
            }


            return RedirectToAction("Index");
        }

        
    }
}
