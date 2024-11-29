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
    public partial class Dashboard_StateAdmin : System.Web.UI.Page
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
                //int[,] horas = new int[,] { { 0, 1 }, { 1, 1 }, { 2, 0 }, { 3, 1 }, { 4, 0 }, { 5, 1 }, { 6, 0 }, { 7, 0 }, { 8, 1 }, { 9, 1 } };

                //var series1 = new Series
                //{
                //    Color = System.Drawing.Color.Green,
                //    IsVisibleInLegend = false,
                //    IsXValueIndexed = true,
                //    ChartType = SeriesChartType.RangeColumn,
                //    CustomProperties = "PointWidth=0.8"
                //};

                //for (int i = 0; i < horas.GetLength(0); i++)
                //{
                //    series1.Points.AddXY(horas[i, 0], horas[i, 1]);
                //}

                //Chart1.Series.Add(series1);

                //Chart1.ChartAreas[0].AxisX.Interval = 1;

                //Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 0, ToPosition = 1, Text = "0", GridTicks = GridTickTypes.All });
                //Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 1, ToPosition = 2, Text = "1", GridTicks = GridTickTypes.All });
                //Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 2, ToPosition = 3, Text = "2", GridTicks = GridTickTypes.All });
                //Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 3, ToPosition = 4, Text = "3", GridTicks = GridTickTypes.All });
                //Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 4, ToPosition = 5, Text = "4", GridTicks = GridTickTypes.All });
                //Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 5, ToPosition = 6, Text = "5", GridTicks = GridTickTypes.All });
                //Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 6, ToPosition = 7, Text = "6", GridTicks = GridTickTypes.All });
                //Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 7, ToPosition = 8, Text = "7", GridTicks = GridTickTypes.All });
                //Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 8, ToPosition = 9, Text = "8", GridTicks = GridTickTypes.All });
                //Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 9, ToPosition = 10, Text = "9", GridTicks = GridTickTypes.All });
                //Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel { FromPosition = 10, ToPosition = 11, Text = "10", GridTicks = GridTickTypes.All });
            }

        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            objBE.from = txtFrom.Text.ToString();
            objBE.To = txtTo.Text.ToString();
            objBE.Action = "SalesProceeding";

            DataSet dataSet = objDL.Get_AdminDashboard_Details(objBE, ConnKey);

            GenerateBarChart(dataSet);
            //GeneratePieChart(dataSet);
        }

        private void GenerateBarChart(DataSet dataSet)
        {
            Chart1.ImageStorageMode = ImageStorageMode.UseHttpHandler;
            //Series series = new Series("Series1");
            //series.ChartType = SeriesChartType.Bar;
            //Chart1.Series.Add(series);
            Chart1.DataSource = dataSet.Tables[0];
            Chart1.DataBind();
            //foreach (DataRow row in dataSet.Tables[0].Rows)
            //{
            //    series.Points.AddXY(row["Category"].ToString(), Convert.ToDouble(row["Value"]));

            //    //series.Points.AddXY("AAA", Convert.ToDouble(row["Value"]));
            //    Chart1.Visible = true;
            //}

        }
        //private void GenerateBarChart1(DataSet dataSet)
        //{
        //    barChart.ImageStorageMode = ImageStorageMode.UseHttpHandler;

        //    //barChart.Series.Clear();
        //    //barChart.ChartAreas.Clear();

        //    //ChartArea chartArea = new ChartArea();
        //    //barChart.ChartAreas.Add(chartArea);

        //    //Series series = new Series("Data");
        //    //series.ChartType = SeriesChartType.Bar;
        //    //barChart.Series.Add(series);

        //    //foreach (DataRow row in dataSet.Tables[0].Rows)
        //    //{
        //    //    series.Points.AddXY(row["Category"].ToString(), Convert.ToDouble(row["Value"]));

        //    //    //series.Points.AddXY("AAA", Convert.ToDouble(row["Value"]));
        //    //    barChart.Visible = true;
        //    //}

        //    // Clear any existing series and chart areas
        //    barChart.Series.Clear();
        //    barChart.ChartAreas.Clear();

        //    // Create and add a new chart area
        //    ChartArea chartArea = new ChartArea();
        //    barChart.ChartAreas.Add(chartArea);

        //    // Create and configure a new series
        //    Series series = new Series("Series1");
        //    series.ChartType = SeriesChartType.Bar;
        //    barChart.Series.Add(series);

        //    // Ensure the dataset and its table are not null and contain data
        //    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dataSet.Tables[0].Rows)
        //        {
        //            if (row["Category"] != DBNull.Value && row["Value"] != DBNull.Value)
        //            {
        //                //barChart.Series["Category"].Points.AddXY(row["Category"], row["Value"]);
        //                series.Points.AddXY(row["Category"].ToString(), Convert.ToDouble(row["Value"]));

        //            }
        //        }
        //    }



        //    // Set chart properties to ensure visibility
        //    barChart.Visible = true;
        //    barChart.DataBind();

        //    //barChart.Dock = DockStyle.Fill; // Optional, if you want the chart to fill its parent container

        //    // Optionally, refresh the chart to ensure it updates its display
        //    //barChart.Update();
        //    //barChart.Invalidate();


        //    ////DataTable ChartData = dataSet.Tables[0];
        //    //////storing total rows count to loop on each Record    
        //    ////string[] XPointMember = new string[ChartData.Rows.Count];
        //    ////int[] YPointMember = new int[ChartData.Rows.Count];
        //    ////for (int count = 0; count < ChartData.Rows.Count; count++)
        //    ////{
        //    ////    //storing Values for X axis    
        //    ////    XPointMember[count] = ChartData.Rows[count]["Category"].ToString();
        //    ////    //storing values for Y Axis    
        //    ////    YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["Value"]);
        //    ////}
        //    //////binding chart control    
        //    ////Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);

        //    //////Setting width of line    
        //    ////Chart1.Series[0].BorderWidth = 10;
        //    //////setting Chart type     
        //    ////Chart1.Series[0].ChartType = SeriesChartType.Bar;

        //    ////Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

        //    DataTable ChartData = dataSet.Tables[0];
        //    string[] XPointMember = new string[ChartData.Rows.Count];
        //    int[] YPointMember = new int[ChartData.Rows.Count];
        //    for (int count = 0; count < ChartData.Rows.Count; count++)
        //    {
        //        XPointMember[count] = ChartData.Rows[count]["Category"].ToString();
        //        YPointMember[count] = Convert.ToInt32(ChartData.Rows[count]["Value"]);
        //    }
        //    Chart1.Series[0].Points.DataBindXY(XPointMember, YPointMember);
        //    Chart1.Series[0].BorderWidth = 10;
        //    Chart1.Series[0].ChartType = SeriesChartType.Bar;
        //    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        //    Chart1.ImageStorageMode = ImageStorageMode.UseHttpHandler;


        //}
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

    }
}