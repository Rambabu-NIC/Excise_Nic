using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Excise_BE;
using Excise_DAL;

namespace ExciseAPI.Retailer
{
    public partial class Depot_Mapping : System.Web.UI.Page
    {
        //Supplier_BE objSupBE = new Supplier_BE();
        Master_BE objBE = new Master_BE();
        Master_DAL objDL = new Master_DAL();
        //Retailer_BE objBE = new Retailer_BE();
        //Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //lblUSer.Text = Session["UsrName"].ToString();
                //BindData();
                BindDepots();
                //   Viewdata();
                random();
            }
        }
        public void BindDepots()
        {

            DataTable dt = new DataTable();
            objBE = new Master_BE();
            objBE.Statecode = "36";
            objBE.Action = "DR";
            dt = objDL.Depots(objBE, Session["ConnKey"].ToString());

            //ddlDistrict.Items.Clear();
            //ddlDistrict.DataSource = dt;
            //ddlDistrict.DataTextField = "DistName";
            //ddlDistrict.DataValueField = "DistCode";
            //ddlDistrict.DataBind();
            //ddlDistrict.Items.Insert(0, new ListItem("--Select--", ""));


            objCommon.BindDropDownLists(ddlDepot, dt, "DEPOTNAME", "DEPOTCODE", "");

        }


        protected void Viewdata()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.DEPOTCODE = ddlDepot.SelectedValue;
                objBE.Action = "MPR";
                dt = objDL.Depots(objBE, Session["ConnKey"].ToString());
                if (dt.Rows.Count > 0)
                {
                    btn_Update.Visible = true;
                    GvDF.Visible = true;
                    GvDF.DataSource = dt;
                    GvDF.DataBind();
                    dt.Dispose();



                }
                else
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    //objCommon.ShowAlertMessage("No Data Found For This ");
                    GvDF.Visible = false;

                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        public void random()
        {
            try
            {
                string strString = "abcdefghijklmnpqrstuvwxyzABCDQEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                string num = "";
                Random rm = new Random();
                for (int i = 0; i < 16; i++)
                {
                    int randomcharindex = rm.Next(0, strString.Length);
                    char randomchar = strString[randomcharindex];
                    num += Convert.ToString(randomchar);
                }
                hf.Value = num;
                Session["ASPFIXATION2"] = num;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        public void check()
        {
            try
            {
                string cookie_value = null;
                string session_value = null;

                cookie_value = hf.Value;
                session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
                if (cookie_value != session_value)
                {
                    System.Web.HttpContext.Current.Session.Abandon();
                    HttpContext.Current.Response.Buffer = false;
                    HttpContext.Current.Response.Redirect("~/Error.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Viewdata();
                //if (Validate())
                //{
                //    objBE.DepotName = txtDepotName.Text;  
                //   // objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                //    objBE.Action = "I";
                //    DataTable dt = new DataTable();
                //    dt = objDL.Depots(objBE, Session["ConnKey"].ToString());
                //    if (dt.Rows.Count > 0)
                //    {
                //        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                //    }
                //}

            }
            catch (Exception ex)
            {


            }
        }
        protected DataTable CreateDt()
        {
            DataTable ddt = new DataTable();
            ddt.Columns.Add("DistCode", typeof(string));
            ddt.Columns.Add("ExDistCode", typeof(string));
            ddt.Columns.Add("ExStationCode", typeof(string));
            ddt.Columns.Add("MandCode", typeof(string));
            ddt.Columns.Add("VillCode", typeof(string));
            ddt.Columns.Add("VillName", typeof(string));
            ddt.Columns.Add("GHMC", typeof(string));
            //ddt.Columns.Add("Temp5", typeof(string));
            return ddt;
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlDepot.SelectedIndex == 0)
                {
                    objCommon.ShowAlertMessage("Please Select DepotName");
                    ddlDepot.Focus();
                    return;
                }
                else
                {


                    DataTable dt = new DataTable();



                    DataTable ddt = new DataTable();
                    ddt = CreateDt();
                    int i = 0;
                    foreach (GridViewRow gr in GvDF.Rows)
                    {
                        if (((CheckBox)gr.FindControl("ChkSelect")).Checked == true)
                        {
                            ddt.Rows.Add();
                            ddt.Rows[i]["DistCode"] = ((Label)gr.FindControl("lblDistrict")).Text.Trim();
                            ddt.Rows[i]["ExDistCode"] = ddlDepot.SelectedValue.ToString();
                            ddt.Rows[i]["ExStationCode"] = "";
                            ddt.Rows[i]["MandCode"] = "";
                            ddt.Rows[i]["VillCode"] = "";
                            ddt.Rows[i]["VillName"] = "";
                            ddt.Rows[i]["GHMC"] = "";
                            //ddt.Rows[i]["Temp5"] = "";
                            i++;
                        }
                    }
                    if (ddt.Rows.Count <= 0)
                    {
                        objCommon.ShowAlertMessage("Please Select At Least One District");
                        return;
                    }

                    // objBE.Constring = ConnKey;
                    objBE.DEPOTCODE = ddlDepot.SelectedValue.ToString();
                    objBE.TVP = ddt;
                    objBE.Ip_Address = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.UserID = Session["UserID"].ToString();//UsrName
                    objBE.Action = "MPI";
                    dt = objDL.Depots(objBE, Session["ConnKey"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        Viewdata();
                        //ClearData();
                        return;
                    }
                    else
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        //Viewdata();
                        ClearData();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {


            }
        }
        public void ClearData()
        {
            ddlDepot.ClearSelection();
            GvDF.Visible = false;
            btn_Update.Visible = false;
        }


        protected void GvDF_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                //  GvDF.PageIndex = e.NewPageIndex;
                Viewdata();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }

        }
    }
}