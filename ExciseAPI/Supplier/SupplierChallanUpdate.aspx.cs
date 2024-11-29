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
using Newtonsoft.Json;
using System.Net.Http;

namespace ExciseAPI.Supplier
{
    public partial class SupplierChallanUpdate : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                //random();
               // Viewdata();
                data.Visible = false;
            }

        }

        public DataTable Supplierdt
        {
            get
            {
                return ViewState["Supplierdt"] as DataTable;
            }
            set
            {
                ViewState["Supplierdt"] = value;
            }
        }
        protected void Viewdata()
        {
            try
            {

                objBE.SupplierCode = Session["UsrName"].ToString();
                objBE.from = txtFrom.Text;
                objBE.To = txtTo.Text;

                Supplierdt = objDL.Get_Supplier(objBE, ConnKey);
                if (Supplierdt.Columns.Count == 1)
                {
                    objCommon.ShowAlertMessage(Supplierdt.Rows[0][0].ToString());
                    return;
                }
                else
                {
                    if (Supplierdt.Rows.Count > 0)
                    {
                        data.Visible = true;
                        GvDF.Visible = true;
                        GvDF.DataSource = Supplierdt;
                        GvDF.DataBind();
                        BtnUpdate.Visible = true;
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("No Data Found");
                        GvDF.Visible = false;
                        data.Visible = false;
                    }
                }


            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        //public void random()
        //{
        //    try
        //    {
        //        string strString = "abcdefghijklmnpqrstuvwxyzABCDQEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //        string num = "";
        //        Random rm = new Random();
        //        for (int i = 0; i < 16; i++)
        //        {
        //            int randomcharindex = rm.Next(0, strString.Length);
        //            char randomchar = strString[randomcharindex];
        //            num += Convert.ToString(randomchar);
        //        }
        //        hf.Value = num;
        //        Session["ASPFIXATION2"] = num;
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}
        //public void check()
        //{
        //    try
        //    {
        //        string cookie_value = null;
        //        string session_value = null;

        //        cookie_value = hf.Value;
        //        session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
        //        if (cookie_value != session_value)
        //        {
        //            System.Web.HttpContext.Current.Session.Abandon();
        //            HttpContext.Current.Response.Buffer = false;
        //            HttpContext.Current.Response.Redirect("~/Error.aspx");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Redirect("~/Error.aspx", false);
        //    }
        //}








        protected void GvDF_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                //if (e.CommandName == "Dept")
                //{
                //    string DeptTransId = e.CommandArgument.ToString();

                //    Depttrans detr = new Depttrans();
                //    detr.deptcode = 2304;
                //    //detr.depttransid = Convert.ToInt64(DeptTransId.Substring(5));
                //    detr.depttransid = DeptTransId.ToString();
                //    DataSet ds = GetIfmsDetails(detr);

                //    if (ds.Tables.Count > 0)
                //    {
                //        var item = ds.Tables[0].Rows[0];
                //        DataTable dt = new DataTable();
                //        objBE.Reg_Code = txtRegistrationNO.Text.ToString();
                //        objBE.ChallanNumber= item["challanno"].ToString();
                //        objBE.DeptTransid = item["depttransid"].ToString();
                //        objBE.HOA = item["hoa"].ToString();
                //        objBE.Amount = Convert.ToDecimal(item["bankamount"].ToString());
                //        objBE.BankTransid = item["banktransid"].ToString();
                //        objBE.DDoCode = item["ddocode"].ToString();
                //        objBE.DeptCode = item["deptcode"].ToString();
                //        objBE.RemitterName = item["remittersname"].ToString();
                //        objBE.BankDate = Convert.ToDateTime(item["scrolldate"].ToString());
                //        objBE.BankStatus = item["bankstatus"].ToString();
                //        objBE.BankCode = item["bankcode"].ToString();
                //        objBE.Action = "ChallanUpdate";

                //        dt = objDL.CyberChallanUpdate(objBE, ConnKey);
                //        if (dt.Rows.Count > 0)
                //        {
                //            objCommon.ShowAlertMessage("Application Submitted Sucessfully");

                //        }
                //        else
                //        {
                //            objCommon.ShowAlertMessage("No Details Found");
                //        }

                //    }

                //}
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

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
                            dt.Rows.Add(dr);
                        }
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

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (GvDF.Rows.Count > 0)
                {
                    string Transactionchek = null;

                    for (int i = 0; i < Supplierdt.Rows.Count; i++)
                    {
                        Transactionchek += Supplierdt.Rows[i]["DeptTransid"] + ",";
                    }

                    if (!string.IsNullOrEmpty(Transactionchek))
                    {
                        Depttrans detr = new Depttrans();
                        detr.deptcode = 2304;
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

                            dt = objDL.Supplier_CyberChallanUpdate(dt, objBE, ConnKey);
                            if (dt.Rows.Count > 0)
                            {
                                objCommon.ShowAlertMessage("Application Submitted Sucessfully");
                                GvDF.Visible = false;

                                BtnUpdate.Visible = false;
                                txtFrom.Text = "";
                                txtTo.Text = "";
                            }
                            else
                            {
                                objCommon.ShowAlertMessage("No Details Found");
                            }

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


        protected void btnGet_Click(object sender, EventArgs e)
        {
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
            if (!string.IsNullOrEmpty(txtFrom.Text) && !string.IsNullOrEmpty(txtTo.Text))
            {
                Viewdata();
            }
        }

    }
}