using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;

namespace ExciseAPI.Retailer
{
    public partial class Challan_Update_FailurePayments : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
        protected void Page_Load(object sender, EventArgs e)
        {
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "50" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
            }
        }

        public DataTable Retailerdt
        {
            get
            {
                return ViewState["Retailerdt"] as DataTable;
            }
            set
            {
                ViewState["Retailerdt"] = value;
            }
        }

        protected void Viewdata()
        {
            try
            {

                objBE.from = txtFrom.Text;
                objBE.To = txtTo.Text;

                Retailerdt = objDL.Get_Retailer_SalesProceeds_AC_Fail(objBE, ConnKey);
                if (Retailerdt.Columns.Count == 1)
                {
                    objCommon.ShowAlertMessage(Retailerdt.Rows[0][0].ToString());
                    return;
                }
                else
                {
                    DataRow[] dr = Retailerdt.Select("deptID=" + ddlPaymenttype.SelectedValue.ToString());
                    DataTable data = new DataTable();
                    data.Columns.Add("Retailer_Code", typeof(string));
                    data.Columns.Add("NAME", typeof(string));
                    data.Columns.Add("DeptTransid", typeof(string));
                    data.Columns.Add("BankStatus", typeof(string));
                    data.Columns.Add("deptID", typeof(string));
                    foreach (var innerList in dr)
                    {
                        DataRow row1 = data.NewRow();

                        row1["Retailer_Code"] = innerList["Retailer_Code"];
                        row1["NAME"] = innerList["NAME"];
                        row1["DeptTransid"] = innerList["DeptTransid"];
                        row1["BankStatus"] = innerList["BankStatus"];
                        row1["deptID"] = innerList["deptID"];

                        data.Rows.Add(row1);

                    }

                    if (data.Rows.Count > 0)
                    {
                        divretailer.Visible = true;
                        gvRetailerdetails.Visible = true;
                        gvRetailerdetails.DataSource = data;
                        gvRetailerdetails.DataBind();
                        btnUpdate.Visible = true;
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("No Data Found");
                        gvRetailerdetails.Visible = false;
                        divretailer.Visible = false;
                    }
                }


            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btn_Get_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlPaymenttype.SelectedValue) == 0)
            {
                lblError.Text = "Please Select Payment Type..";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(txtFrom.Text))
            {
                lblError.Text = "Please Enter From Date";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(txtTo.Text))
            {
                lblError.Text = "Please Enter To Date";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            Viewdata();
        }


        public class Depttrans
        {
            public int deptcode { get; set; }
            public string depttransid { get; set; }
        }
        public DataSet GetIfmsDetails(Depttrans c)
        {
            DataSet result = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("challanno", typeof(string));
            dt.Columns.Add("depttransid", typeof(string));
            dt.Columns.Add("hoa", typeof(string));
            dt.Columns.Add("bankamount", typeof(string));
            dt.Columns.Add("banktransid", typeof(string));
            dt.Columns.Add("ddocode", typeof(string));
            dt.Columns.Add("deptcode", typeof(string));
            dt.Columns.Add("remittersname", typeof(string));
            dt.Columns.Add("scrolldate", typeof(string));
            dt.Columns.Add("bankstatus", typeof(string));
            dt.Columns.Add("bankcode", typeof(string));
            DataTable dterror = new DataTable();

            dterror.Columns.Add("ErrorMessage", typeof(string));
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
                HttpClient client = new HttpClient();
                // client.BaseAddress = new Uri("https://ifmis.telangana.gov.in/payment/");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.17 (KHTML, like Gecko) Chrome/24.0.1312.57 Safari/537.17");
                var json = JsonConvert.SerializeObject(c);
                var data = new StringContent(json, Encoding.UTF8, "application/text");
                HttpResponseMessage response = client.GetAsync("https://ifmis.telangana.gov.in/payment/get_cyber_challan_details?deptcode=" + c.deptcode + "&depttransid=" + c.depttransid).Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    //ds = JsonConvert.DeserializeObject<ApiDetails.EncResponse>(apiResponse);
                    dynamic jsonObject = JsonConvert.DeserializeObject(apiResponse);
                    if (jsonObject != null)
                    {
                        foreach (var innerList in jsonObject.challandetails)
                        {
                            DataRow dr = dt.NewRow();
                            dr["challanno"] = innerList["challanno"];
                            dr["depttransid"] = innerList["depttransid"];
                            dr["hoa"] = innerList["hoa"];
                            dr["bankamount"] = innerList["bankamount"];
                            dr["banktransid"] = innerList["banktransid"];
                            dr["ddocode"] = innerList["ddocode"];
                            dr["remittersname"] = innerList["remittersname"];
                            dr["scrolldate"] = innerList["scrolldate"];
                            dr["bankstatus"] = innerList["bankstatus"];
                            dr["bankcode"] = innerList["bankcode"];
                            if (string.IsNullOrEmpty(dr["bankamount"].ToString()))
                            {
                                dr["bankamount"] = "0";
                            }
                            if (!string.IsNullOrEmpty(dr["bankstatus"].ToString().ToUpper()))// == "Success".ToUpper())
                            {
                                if (!string.IsNullOrEmpty(dr["scrolldate"].ToString()))
                                    dt.Rows.Add(dr);
                            }
                        }
                        //DataRow[] FilterData = dt.Select("bankstatus = " + "Success".ToString());
                        //DataTable DataFilter = null;

                        result.Tables.Add(dt);
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("No Data Found");
                    }
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                    result.Tables.Add(dt);
                    DataRow drerror = dterror.NewRow();
                    drerror["ErrorMessage"] = "Unable to fetch data from IFMS server..";
                    dterror.Rows.Add(drerror);
                    result.Tables.Add(dterror);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        private DataTable challandetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Supplier_Code", typeof(string));
            dt.Columns.Add("DeptTransid", typeof(string));
            dt.Columns.Add("ChallanNumber", typeof(string));
            dt.Columns.Add("HOAccount", typeof(string));
            dt.Columns.Add("BankAmount", typeof(string));
            dt.Columns.Add("BankTransid", typeof(string));
            dt.Columns.Add("DDOCode", typeof(string));
            dt.Columns.Add("RemitterName", typeof(string));
            dt.Columns.Add("BankDate", typeof(string));
            dt.Columns.Add("BankStatus", typeof(string));
            dt.Columns.Add("BankCode", typeof(string));
            return dt;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (gvRetailerdetails.Rows.Count > 0)
                {
                    string Transactionchek = null;

                    for (int i = 0; i < Retailerdt.Rows.Count; i++)
                    {
                        Transactionchek += Retailerdt.Rows[i]["DeptTransid"] + ",";
                    }

                    if (!string.IsNullOrEmpty(Transactionchek))
                    {
                        Depttrans detr = new Depttrans();
                        detr.deptcode = Convert.ToInt32(ddlPaymenttype.SelectedValue);
                        detr.depttransid = Transactionchek.ToString();
                        DataSet ds = GetIfmsDetails(detr);
                        if (ds.Tables.Count > 0)
                        {
                            DataTable dt = challandetails();
                            DataTable ChallanUpdate = ds.Tables[0];
                            foreach (DataRow innerList in ChallanUpdate.Rows)
                            {
                                DataRow dr = dt.NewRow();
                                dr["Supplier_Code"] = Session["UsrName"].ToString();
                                dr["DeptTransid"] = innerList["depttransid"];
                                dr["ChallanNumber"] = innerList["challanno"];
                                dr["HOAccount"] = innerList["hoa"];
                                dr["BankAmount"] = innerList["bankamount"];
                                dr["BankTransid"] = innerList["banktransid"];
                                dr["DDOCode"] = innerList["ddocode"];
                                dr["RemitterName"] = innerList["remittersname"];
                                dr["BankDate"] = innerList["scrolldate"];
                                dr["BankStatus"] = innerList["bankstatus"];
                                dr["BankCode"] = innerList["bankcode"];
                                dt.Rows.Add(dr);
                            }




                            objBE.Action = "ChallanUpdate";

                            dt = objDL.Retailer_CyberChallanUpdate(dt, objBE, ConnKey);
                            if (dt.Rows.Count > 0)
                            {
                                objCommon.ShowAlertMessage("Application Submitted Sucessfully");
                                gvRetailerdetails.Visible = false;

                                btnUpdate.Visible = false;
                                txtFrom.Text = "";
                                txtTo.Text = "";
                                divretailer.Visible = false;
                            }
                            else
                            {
                                objCommon.ShowAlertMessage("No Details Found");
                            }

                        }
                        else
                        {
                            btnUpdate.Visible = false;
                            txtFrom.Text = "";
                            txtTo.Text = "";
                            divretailer.Visible = false;
                            objCommon.ShowAlertMessage("No Details Found");
                            return;
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }


        }
    }
}