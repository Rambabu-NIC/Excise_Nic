using System;
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

namespace ExciseAPI.NICAdmin
{
    public partial class PaymentUpdate : System.Web.UI.Page
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


                //lblUSer.Text = Session["UsrName"].ToString();
                //BindTypeofManf();           

                //random();
                //btn_Save.Visible = false;
                //data.Visible = false;
            }

        }
        //protected bool Validate()
        //{
        //    if (txtRegistrationNO.Text == "")
        //    {
        //        objCommon.ShowAlertMessage("Please Enter Registration No");
        //        txtRegistrationNO.Focus();
        //        return false;
        //    }

        //    return true;
        //}


        //protected void btn_Get_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Validate())
        //        {
        //            Viewdata();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        objCommon.ShowAlertMessage(ex.ToString());
        //    }
        //}

        // public void Clear()
        //{
        //    txtRegistrationNO.Text = "";
        //}
        //protected void Viewdata()
        //{
        //    DataTable dt = new DataTable();
        //    dt = new DataTable();
        //    try
        //    {
        //        objBE.Reg_Code = txtRegistrationNO.Text;
        //        objBE.Action = "PGR";
        //        dt = objDL.EventReg_IUR(objBE, Session["ConnKey"].ToString());
        //        if (dt.Columns.Count == 1)
        //        {
        //            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
        //            return;
        //        }
        //        else
        //        {
        //            if (dt.Rows.Count > 0)
        //            {

        //                data.Visible = true;
        //                GvDF.Visible = true;
        //                GvDF.DataSource = dt;
        //                GvDF.DataBind();
        //                dt.Dispose();
        //                BtnUpdate.Visible = true;
        //            }
        //            else
        //            {
        //                objCommon.ShowAlertMessage("No Data Found");
        //                GvDF.Visible = false;
        //                data.Visible = false;
        //            }
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}
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





        //protected void lblDeptTransid_Click(object sender, EventArgs e)
        //{
        //    //string DeptTransId = null;

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

        public DataTable BankRequest
        {
            get
            {
                //    if (ViewState["BankRequest"] == null)
                //    {
                //        DataTable dts = bankrequestdetails();
                //        ViewState["BankRequest"] = dts;
                //    }
                return ViewState["BankRequest"] as DataTable;
            }
            set
            {
                ViewState["BankRequest"] = value;
            }
        }
        private DataTable bankrequestdetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AppReg_No", typeof(string));
            dt.Columns.Add("DeptTransid", typeof(string));
            dt.Columns.Add("BankAmount", typeof(string));
            dt.Columns.Add("BankTransid", typeof(string));
            dt.Columns.Add("BankStatus", typeof(string));
            return dt;
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
            dt.Columns.Add("TreasuryDate", typeof(string));
            DataTable dterror = new DataTable();

            dterror.Columns.Add("ErrorMessage", typeof(string));
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
                HttpClient client = new HttpClient();

                // client.BaseAddress = new Uri("https://ifmis.telangana.gov.in/payment/");
                var json = JsonConvert.SerializeObject(c);
                //foreach()
                //{

                //}
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
                            dr["TreasuryDate"] = innerList["treasurydate"];
                            dt.Rows.Add(dr);
                        }
                        result.Tables.Add(dt);
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("No Data Found");
                        // GvDF.Visible = false;
                        //txtRegistrationNO.Text = "";
                        //BtnUpdate.Visible = false;
                        //Clear();
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
            dt.Columns.Add("AppReg_No", typeof(string));
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
            dt.Columns.Add("TreasuryDate", typeof(string));
            return dt;
        }
        private DataTable AppRegdetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AppReg_No", typeof(string));
            dt.Columns.Add("DeptTransid", typeof(string));
            return dt;
        }

        //protected void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    CheckBox ChkSelectAll = (CheckBox)sender;
        //    GridViewRow gRow = (GridViewRow)ChkSelectAll.NamingContainer;

        //    if (ChkSelectAll.Checked == true)
        //    {
        //        foreach (GridViewRow gr in GvDF.Rows)
        //        {
        //            ((CheckBox)gr.FindControl("ChkSelect")).Checked = true;
        //        }
        //    }
        //    else
        //    {
        //        foreach (GridViewRow gr in GvDF.Rows)
        //        {
        //            ((CheckBox)gr.FindControl("ChkSelect")).Checked = false;
        //        }
        //    }
        //}
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                objBE.dtfrom = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                objBE.dtTo = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                objBE.Action = "ChallanGet";
                dt = objDL.CyberChallanUpdate(null, objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    BankRequest = dt;
                    DataTable dtAppReg = null;
                    dtAppReg = AppRegdetails();
                    string Transactionchek = null;
                    foreach (DataRow innerList in dt.Rows)
                    {
                        DataRow dr = dtAppReg.NewRow();
                        dr["AppReg_No"] = innerList["AppReg_No"].ToString();
                        dr["DeptTransid"] = innerList["DeptTransid"].ToString();
                        dtAppReg.Rows.Add(dr);
                        //Transactionchek += innerList["DeptTransid"].ToString() + ",";
                        Transactionchek = innerList["DeptTransid"].ToString();

                        Depttrans detr = new Depttrans();
                        detr.deptcode = 2304;
                        //detr.depttransid = Convert.ToInt64(DeptTransId.Substring(5));
                        detr.depttransid = Transactionchek.ToString();
                        DataSet ds = GetIfmsDetails(detr);
                        if (ds.Tables.Count > 0)
                        {
                            DataTable dt1 = null;
                            dt1 = challandetails();
                            DataTable ChallanUpdate = ds.Tables[0];
                            foreach (DataRow innerList1 in ChallanUpdate.Rows)
                            {
                                DataRow dr1 = dt1.NewRow();

                                DataRow[] Appregdata = dtAppReg.Select("DeptTransid = '" + innerList["depttransid"] + "'");

                                dr1["AppReg_No"] = Appregdata[0][0];
                                dr1["DeptTransid"] = innerList1["depttransid"];
                                dr1["ChallanNumber"] = innerList1["challanno"];
                                dr1["HOAccount"] = innerList1["hoa"];
                                dr1["BankAmount"] = innerList1["bankamount"];
                                dr1["BankTransid"] = innerList1["banktransid"];
                                dr1["DDOCode"] = innerList1["ddocode"];
                                dr1["RemitterName"] = innerList1["remittersname"];
                                dr1["BankDate"] = innerList1["scrolldate"];
                                dr1["BankStatus"] = innerList1["bankstatus"];
                                dr1["BankCode"] = innerList1["bankcode"];
                                dr1["TreasuryDate"] = innerList1["TreasuryDate"];
                                dt1.Rows.Add(dr1);

                                divgriddetails.Visible = false;
                                if (BankRequest.Rows.Count > 0)
                                {
                                    divgriddetails.Visible = true;
                                    foreach (DataRow requestRow in BankRequest.Rows)
                                    {
                                        //var req = BankRequest.AsEnumerable().Where(r => r.Field<String>("DeptTransid") == innerList1["depttransid"].ToString());//.Where(r => r["DeptTransid"].ToString() == innerList1["depttransid"].ToString());
                                        string transaction = innerList1["depttransid"].ToString().Trim();
                                        string reqtransaction = requestRow["DeptTransid"].ToString().Trim();
                                        if (reqtransaction == transaction)
                                        {
                                            requestRow["BankStatus"] = innerList1["bankstatus"];
                                            requestRow["BankTransid"] = innerList1["banktransid"];
                                            requestRow["BankAmount"] = innerList1["bankamount"];
                                        }

                                    }
                                    gvdetails.DataSource = BankRequest;
                                    gvdetails.DataBind();
                                }


                                objBE.Action = "ChallanUpdate";
                                dt1 = objDL.CyberChallanUpdate(dt1, objBE, ConnKey);

                                if (dt1.Rows.Count > 0)
                                {
                                    //objCommon.ShowAlertMessage("Application Submitted Sucessfully");
                                    //Response.Write(dt1);
                                    //GvDF.Visible = false;
                                    //txtRegistrationNO.Text = "";
                                    //BtnUpdate.Visible = false;
                                    //Clear();
                                    // return;
                                }
                                else
                                {
                                    //objCommon.ShowAlertMessage("No Details Found");
                                    //GvDF.Visible = false;
                                    //txtRegistrationNO.Text = "";
                                    //BtnUpdate.Visible = false;
                                    //Clear();
                                    // return;
                                }

                            }

                        }
                        else
                        {
                            divgriddetails.Visible = false;
                            if (BankRequest.Rows.Count > 0)
                            {
                                divgriddetails.Visible = true;
                                foreach (DataRow requestRow in BankRequest.Rows)
                                {
                                    if (string.IsNullOrEmpty(requestRow["BankStatus"].ToString()))
                                    {
                                        requestRow["BankStatus"] = "Fail";
                                    }

                                }

                                gvdetails.DataSource = BankRequest;
                                gvdetails.DataBind();
                            }

                        }

                        //var item = ds.Tables[0].Rows[0];

                        //objBE.Reg_Code = txtRegistrationNO.Text.ToString();
                        //objBE.ChallanNumber= item["challanno"].ToString();
                        //objBE.DeptTransid = item["depttransid"].ToString();
                        //objBE.HOA = item["hoa"].ToString();
                        //objBE.Amount = Convert.ToDecimal(item["bankamount"].ToString());
                        //objBE.BankTransid = item["banktransid"].ToString();
                        //objBE.DDoCode = item["ddocode"].ToString();
                        //objBE.DeptCode = item["deptcode"].ToString();
                        //objBE.RemitterName = item["remittersname"].ToString();
                        //objBE.BankDate = Convert.ToDateTime(item["scrolldate"].ToString());
                        //objBE.BankStatus = item["bankstatus"].ToString();
                        //objBE.BankCode = item["bankcode"].ToString();

                    }



                }
                else
                {
                    lblError.Text = "No Data Found";
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }

        protected void txtto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtto.Text))
            {
                DataTable dt = new DataTable();
                objBE.dtfrom = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                objBE.dtTo = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                objBE.Action = "ChallanGet";
                dt = objDL.CyberChallanUpdate(null, objBE, ConnKey);
                if (dt.Rows.Count > 20)
                {
                    lblError.Text = "Selected Date Payment Count is more than 20 Please Select Another Date to Update";
                    return;
                }

            }

        }
    }


}