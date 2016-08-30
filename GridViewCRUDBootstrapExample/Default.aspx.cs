using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridViewCRUDBootstrapExample
{
    public partial class Default : System.Web.UI.Page
    {
        List<Section> sections = new List<Section>();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        public void BindGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                sections.Add(new Section()
                {
                    SectionNbr = 1,
                    IsDeletable = false,
                    SectionName = "IDF"
                });
                sections.Add(new Section()
                {
                    SectionNbr = 2,
                    IsDeletable = false,
                    SectionName = "IDV"
                });
                sections.Add(new Section()
                {
                    SectionNbr = 3,
                    IsDeletable = true,
                    SectionName = "BIL"
                });
                sections.Add(new Section()
                {
                    SectionNbr = 4,
                    IsDeletable = true,
                    SectionName = "DIR"
                });
                gvSections.DataSource = sections;
                gvSections.DataBind();

            }
            catch (Exception ex)
            {
                System.Console.Error.Write(ex.Message);

            }

        }

        protected void gvSections_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            /*
            if (e.CommandName.Equals("detail"))
            {
                string code = gvSections.DataKeys[index].Value.ToString();
                IEnumerable<DataRow> query = from i in dt.AsEnumerable()
                                             where i.Field<String>("Branch").Equals(code)
                                             select i;
                DataTable detailTable = query.CopyToDataTable<DataRow>();
                DetailsView1.DataSource = detailTable;
                DetailsView1.DataBind();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#detailModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
            }
            else if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = gvSections.Rows[index];
                lblCountryCode.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text).ToString();
                txtPopulation.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
                txtName.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
                lblResult.Visible = false;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);

            }
            else 
             */
            if (e.CommandName.Equals("deleteRecord"))
            {
                string code = gvSections.DataKeys[index].Value.ToString();
                hfCode.Value = code;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#deleteModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
            }

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string sectionName = gvSections.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvOrders = e.Row.FindControl("gvOrders") as GridView;
                gvOrders.DataSource = GetSectionData(sectionName);
                gvOrders.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string code = lblCountryCode.Text;
            int population = Convert.ToInt32(txtPopulation.Text);
            string countryname = txtName.Text;
            executeUpdate(code, population, countryname, "");
            BindGrid();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Records Updated Successfully');");
            sb.Append("$('#editModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);

        }

        private void executeUpdate(string code, int population, string countryname, string continent)
        {
            string connString = ConfigurationManager.ConnectionStrings["MySqlConnString"].ConnectionString;
            //try
            //{
            //    MySqlConnection conn = new MySqlConnection(connString);
            //    conn.Open();
            //    string updatecmd = "update tblCountry set Population=@population, Name=@countryname,Continent=@continent where Code=@code";
            //    MySqlCommand updateCmd = new MySqlCommand(updatecmd, conn);
            //    updateCmd.Parameters.AddWithValue("@population", population);
            //    updateCmd.Parameters.AddWithValue("@countryname", countryname);
            //    updateCmd.Parameters.AddWithValue("@continent", continent);
            //    updateCmd.Parameters.AddWithValue("@code", code);
            //    updateCmd.ExecuteNonQuery();
            //    conn.Close();

            //}
            //catch (MySqlException me)
            //{
            //    System.Console.Error.Write(me.InnerException.Data);
            //}
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

        }

        protected void btnAddRecord_Click(object sender, EventArgs e)
        {
            //string code = txtCode.Text;
            //string name = txtCountryName.Text;
            //string region = txtRegion.Text;
            //string continent = txtContinent.Text;
            //int population = Convert.ToInt32(txtTotalPopulation.Text);
            //int indyear = Convert.ToInt32(txtIndYear.Text);
            //executeAdd(code, name, continent, region, population, indyear);
            //BindGrid();
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append(@"<script type='text/javascript'>");
            //sb.Append("alert('Record Added Successfully');");
            //sb.Append("$('#addModal').modal('hide');");
            //sb.Append(@"</script>");
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);


        }

        private void executeAdd(string code, string name, string continent, string region, int population, int indyear)
        {
            string connString = ConfigurationManager.ConnectionStrings["MySqlConnString"].ConnectionString;
            //try
            //{
            //    MySqlConnection conn = new MySqlConnection(connString);
            //    conn.Open();
            //    string updatecmd = "insert into tblCountry (Code,Name,Continent,Region,Population,IndepYear) values (@code,@name,@continent,@region,@population,@indyear)";
            //    MySqlCommand addCmd = new MySqlCommand(updatecmd, conn);
            //    addCmd.Parameters.AddWithValue("@code", code);
            //    addCmd.Parameters.AddWithValue("@name", name);
            //    addCmd.Parameters.AddWithValue("@continent", continent);
            //    addCmd.Parameters.AddWithValue("@region", region);
            //    addCmd.Parameters.AddWithValue("@population", population);
            //    addCmd.Parameters.AddWithValue("@indyear", indyear);
            //    addCmd.ExecuteNonQuery();
            //    conn.Close();

            //}
            //catch (MySqlException me)
            //{
            //    System.Console.Write(me.Message);
            //}
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string code = hfCode.Value;
            executeDelete(code);
            BindGrid();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Record deleted Successfully');");
            sb.Append("$('#deleteModal').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
        }

        private void executeDelete(string code)
        {
            string connString = ConfigurationManager.ConnectionStrings["MySqlConnString"].ConnectionString;
            //try
            //{
            //    MySqlConnection conn = new MySqlConnection(connString);
            //    conn.Open();
            //    string updatecmd = "delete from tblCountry where Code=@code";
            //    MySqlCommand addCmd = new MySqlCommand(updatecmd, conn);
            //    addCmd.Parameters.AddWithValue("@code", code);
            //    addCmd.ExecuteNonQuery();
            //    conn.Close();

            //}
            //catch (MySqlException me)
            //{
            //    System.Console.Write(me.Message);
            //}

        }

        private static List<SectionData> GetSectionData(string sectionName)
        {
            List<SectionData> data = new List<SectionData>();
            try
            {
                data.Add(new SectionData()
                {
                    SectionName = "IDF",
                    Name = "OrderNumber",
                    Value = "N7IO8999"
                });
                data.Add(new SectionData()
                {
                    SectionName = "IDF",
                    Name = "APPDATE",
                    Value = "20/09/2016"
                });
            }
            catch (Exception ex)
            {
                System.Console.Error.Write(ex.Message);
            }
            return data;
        }

        protected void GetSelectedRecords(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Name"), new DataColumn("Country") });
            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
            //        if (chkRow.Checked)
            //        {
            //            string name = row.Cells[1].Text;
            //            string country = (row.Cells[2].FindControl("lblCountry") as Label).Text;
            //            dt.Rows.Add(name, country);
            //        }
            //    }
            //}
            //gvSelected.DataSource = dt;
            //gvSelected.DataBind();
        }

    }

    public class Section
    {
        public Section()
        {
        }
        public int SectionNbr { get; set; }
        public string SectionName { get; set; }
        public bool IsDeletable { get; set; }
        public List<SectionData> sectionData { get; set; }
    }

    public class SectionData
    {
        public SectionData()
        {
        }
        public string SectionName { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}