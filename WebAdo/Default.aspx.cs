using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;

namespace WebAdo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Write("<center><h1>Read data from a database </ h1 ></ center >< hr /> ");
                Response.Write("<br/>");
                string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                SqlConnection con = new SqlConnection(s);
                string sqlString = "select * from customers";
                SqlCommand cmd = new SqlCommand(sqlString, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
                string sqlStringDropDownList = "select Country from customers";
                SqlCommand cmd2 = new SqlCommand(sqlStringDropDownList, con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read() == true
                )
                {
                    DropDownList1.Items.Add(new ListItem(dr2["Country"].ToString(),
                    dr2["Country"].ToString()));
                }
                dr2.Close();
                con.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<center><h1>Read data from a database</h1></center><hr/>");
            Response.Write("<br/>");
            String txtValue = TextBox1.Text;
            //read connection string
            string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            //create sql connection
            SqlConnection con = new SqlConnection(s);
            //query string
            string query = "select * from customers where Country=@Country";
            //sql command setup
            SqlCommand cmd = new SqlCommand(query, con);
            //to prevent sql injection
            cmd.Parameters.AddWithValue("@Country", txtValue);
            //open connection
            con.Open();
            //execute command
            //use cmd.ExecuteReader() for SELECT
            //use cmd.ExecuteScalar() for count or single numbers return
            SqlDataReader dr = cmd.ExecuteReader();
            //use cmd.ExecuteNonQuery() for INSERT, UPDATE, DELETE
            //data source for gridview
            GridView1.DataSource = dr;
            GridView1.DataBind();
            //close datareader and connection
            dr.Close();
            con.Close();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Response.Write("<br/>");
                String txtValue = DropDownList1.SelectedValue.ToString();
                string s =
                ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                SqlConnection con = new SqlConnection(s);
                string sqlString = "select * from customers where Country=@Country";
                SqlCommand cmd = new SqlCommand(sqlString, con);
                cmd.Parameters.AddWithValue("@Country", txtValue);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
                con.Close();
            }
        }
    }
}