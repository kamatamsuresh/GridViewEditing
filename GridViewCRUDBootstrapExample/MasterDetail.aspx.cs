using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridViewCRUDBootstrapExample
{
    public partial class MasterDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvCustomers.DataSource = GetData("select top 10 * from Customers");
                gvCustomers.DataBind();
            }
        }

        private static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add("CustomerID");
                dt.Columns.Add("ContactName");
                dt.Columns.Add("City");
                dt.Rows.Add(new object[] { 1, "Suresh", "Hyderabad" });
                dt.Rows.Add(new object[] { 2, "Kamatam", "Bangalore" });
                dt.Rows.Add(new object[] { 3, "Venkat", "Hyderabad" });
            }
            catch (Exception ex)
            {
                System.Console.Error.Write(ex.Message);

            }
            return dt;
        }

        private static DataTable GetOrdData(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add("OrderId");
                dt.Columns.Add("OrderDate");
                dt.Rows.Add(new object[] { "1", "Hyderabad" });
                dt.Rows.Add(new object[] { "2", "Bangalore" });
                dt.Rows.Add(new object[] { "3", "Hyderabad" });
            }
            catch (Exception ex)
            {
                System.Console.Error.Write(ex.Message);

            }
            return dt;
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerId = gvCustomers.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvOrders = e.Row.FindControl("gvOrders") as GridView;
                gvOrders.DataSource = GetOrdData(string.Format("select top 3 * from Orders where CustomerId='{0}'", customerId));
                gvOrders.DataBind();
            }
        }

    }
}