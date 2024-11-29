using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Globalization;
using System.Web.UI.DataVisualization.Charting;

namespace ExciseAPI.NICAdmin
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
                Response.Redirect("~/Error.aspx");
            }
            else
            {
                string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
                string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
                int len = http_hos.Length;
                if (http_ref.IndexOf(http_hos, 0) < 0)
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "9" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Error.aspx");
            }

            if (!IsPostBack)
            {
                BindChart();
            }

        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            objBE.from = txtFrom.Text.ToString();
            objBE.To =txtTo.Text.ToString();
            objBE.Action = "SalesProceeding";

            DataSet dataSet = objDL.Get_AdminDashboard_Details(objBE, ConnKey);

            GenerateBarChart(dataSet);
            //GeneratePieChart(dataSet);
        }

       

        private void GenerateBarChart(DataSet dataSet)
        {
            //barChart.Series.Clear();
            //barChart.ChartAreas.Clear();

            //ChartArea chartArea = new ChartArea();
            //barChart.ChartAreas.Add(chartArea);

            //Series series = new Series("Data");
            //series.ChartType = SeriesChartType.Bar;
            //barChart.Series.Add(series);

            //foreach (DataRow row in dataSet.Tables[0].Rows)
            //{
            //    series.Points.AddXY(row["Category"].ToString(), Convert.ToDouble(row["Value"]));

            //    //series.Points.AddXY("AAA", Convert.ToDouble(row["Value"]));
            //    barChart.Visible = true;
            //}

            // Clear any existing series and chart areas
            barChart.Series.Clear();
            barChart.ChartAreas.Clear();

            // Create and add a new chart area
            ChartArea chartArea = new ChartArea();
            barChart.ChartAreas.Add(chartArea);

            // Create and configure a new series
            Series series = new Series("Data");
            series.ChartType = SeriesChartType.Bar;
            barChart.Series.Add(series);

            // Ensure the dataset and its table are not null and contain data
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    if (row["Category"] != DBNull.Value && row["Value"] != DBNull.Value)
                    {
                        series.Points.AddXY(row["Category"].ToString(), Convert.ToDouble(row["Value"]));
                    }
                }
            }

            // Set chart properties to ensure visibility
            barChart.Visible = true;
            barChart.DataBind();
            //barChart.ImageStorageMode = ImageStorageMode.UseImageLocation;
            //barChart.ImageLocation = "~/temporary/ChartPic_#SEQ(300,3)";
            //barChart.ImageType = ChartImageType.Png;

            //barChart.Dock = DockStyle.Fill; // Optional, if you want the chart to fill its parent container

            // Optionally, refresh the chart to ensure it updates its display
            //barChart.Update();
            //barChart.Invalidate();

        }
        //private DataSet GetDataSet()
        //{
        //    // Your logic to retrieve the dataset
        //    DataSet dataSet = new DataSet();
        //    // Fill dataset with data
        //    return dataSet;
        //}
        //private void GeneratePieChart(DataSet dataSet)
        //{
        //    pieChart.Series.Clear();
        //    pieChart.ChartAreas.Clear();

        //    ChartArea chartArea = new ChartArea();
        //    pieChart.ChartAreas.Add(chartArea);

        //    Series series = new Series("Data");
        //    series.ChartType = SeriesChartType.Pie;
        //    pieChart.Series.Add(series);

        //    foreach (DataRow row in dataSet.Tables[0].Rows)
        //    {
        //        series.Points.AddXY(row["Category"].ToString(), Convert.ToDouble(row["Value"]));
        //    }
        //}
        private void BindChart()
        {
            Chart1.Series["Series1"].Points.AddXY("Category1", 10);
            Chart1.Series["Series1"].Points.AddXY("Category2", 20);
            Chart1.Series["Series1"].Points.AddXY("Category3", 30);
        }
    }
}