using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
namespace ExciseAPI.Admin
{
    public partial class Treasury_Service : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        DataTable dt;
        DataTable dt1 = new DataTable();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            //{
            //    Response.Redirect("~/Error.aspx");
            //}
            //else
            //{
            //    string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            //    string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            //    int len = http_hos.Length;
            //    if (http_ref.IndexOf(http_hos, 0) < 0)
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }
            //}
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            //if (Session["Role"] != null && Session["Role"].ToString() == "1" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            //{
            //    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }
            //}
            //else
            //{
            //    Response.Redirect("~/Error.aspx");
            //}

            if (!IsPostBack)
            {

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                //  lblUSer.Text = Session["UsrName"].ToString();

                // Viewdata();
                //random();


            }
        }


        protected void btn_Save_Click(object sender, EventArgs e)
        {

            dt = new DataTable();

            dt = objDL.GetBankdetailssendtotreasuryDAL("R", dt1, ConnKey);
            if (dt.Rows.Count > 0)
            {
                string strpara = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (strpara == "")
                    {
                        strpara = dt.Rows[i]["DeptTransid"].ToString();
                    }
                    else
                    {
                        strpara += "," + dt.Rows[i]["DeptTransid"].ToString();
                    }
                }
                var url = "https://treasury.telangana.gov.in/extras/webservice_drugschallan_details.php?deptcode=2304&depttransid=" + strpara.Trim() + "";



                DataTable dttreasury = Getdate(url);
                if (dttreasury.Rows.Count > 0)
                {
                    //dttreasury.Columns.Remove("remittersname");
                    // dttreasury.Columns.Remove("bankamount");
                    //   dttreasury.Columns.Remove("bankamount");
                    dt = new DataTable();
                    dt = objDL.GetBankdetailssendtotreasuryDAL("U", dttreasury, ConnKey);
                }
            }

        }


        public static DataTable Getdate(string Url)
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 |
         (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
                myRequest.MaximumAutomaticRedirections = 4;
                myRequest.MaximumResponseHeadersLength = 4;
                myRequest.Credentials = CredentialCache.DefaultCredentials;

                myRequest.Method = "GET";

                WebResponse myResponse = myRequest.GetResponse();


                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                string result = sr.ReadToEnd();
                sr.Close();

                DataSet dtDrugindent = (DataSet)JsonConvert.DeserializeObject("" + result + "", (typeof(DataSet)));
                myResponse.Close();

                return dtDrugindent.Tables[0];
            }
            catch
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }








      




    }
}