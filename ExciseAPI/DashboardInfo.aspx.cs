using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;
using System.Configuration;
using System.Net;
using System.Text;

namespace ExciseAPI
{
    public partial class DashboardInfo : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            //gvDashboardInfo.DataSource = "";
            //gvDashboardInfo.DataBind();

            //gvdashboard_distilers.DataSource = "";
            //gvdashboard_distilers.DataBind();
        }

        public void BindData()
        {
            //gvmanufacturers.DataSource = null;
            //gvmanufacturers.DataBind();
            //gvretailers.DataSource = null;
            //gvretailers.DataBind();
            DataSet dsDashboard = objDL.GetEODBDashboardInfo(objBE, ConnKey);
            if (dsDashboard.Tables.Count > 0)
            {
                if (dsDashboard.Tables[0].Rows.Count > 0)
                {
                    divDashboardDetails.Visible = true;
                    gvDashboardInfo.DataSource = dsDashboard.Tables[0];
                    gvDashboardInfo.DataBind();
                }
                else
                {
                    gvDashboardInfo.DataSource = "";
                    gvDashboardInfo.DataBind();
                }
                if (dsDashboard.Tables[1].Rows.Count > 0)
                {
                    divDashboardDetails.Visible = true;
                    gvdashboard_distilers.DataSource = dsDashboard.Tables[1];
                    gvdashboard_distilers.DataBind();
                }
                else
                {
                    gvdashboard_distilers.DataSource = "";
                    gvdashboard_distilers.DataBind();
                }
            }
        }


        protected void gvDashboardInfo_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = " ";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "A4 SHOPS";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "2B BARS";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "ELITE BARS";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "CLUBS";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "TD1";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "CS-3";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "CS-2";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);
                


                HeaderGridRow.Cells.Add(HeaderCell);
                gvDashboardInfo.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }

        protected void gvdashboard_distilers_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = " ";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);
                
                HeaderCell = new TableCell();
                HeaderCell.Text = "PRIMARY DISTILLERIES";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SECONDARY DISTILLERIES";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "BREWERIES";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "MICRO BREWERIES";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "MOLLASSES";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "WINERY";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "RECTIFIED SPIRIT";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "DENATURED SPIRIT";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = System.Drawing.Color.White;
                HeaderGridRow.Cells.Add(HeaderCell);


                HeaderGridRow.Cells.Add(HeaderCell);
                gvdashboard_distilers.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }

        protected void GetDetails_Click(object sender, EventArgs e)
        {
            divDashboardDetails.Visible = false;
            if (!string.IsNullOrEmpty(txtFrom.Text.ToString()) && !string.IsNullOrEmpty(txtTo.Text.ToString()))
            {
                divDashboardDetails.Visible = true;
            }
            else
            {
                lblError.Text = "Please select From And To Date..";
                return;
            }
        }
    }
}