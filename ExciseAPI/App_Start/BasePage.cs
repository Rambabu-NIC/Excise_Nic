using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.Xml;
using iTextSharp.tool.xml;
using System.IO;
using System.Configuration;
using Excise_DAL;
using Excise_BE;
using ExciseAPI.App_Start;
/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
	public BasePage()
	{
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    }
        
      public void ExportGridToExcelWithLabel(string GenerateFileName, System.Web.UI.HtmlControls.HtmlGenericControl gridviewid)
      {

          Response.Clear();
          Response.Buffer = true;
          Response.AddHeader("content-disposition", "attachment;filename=" + GenerateFileName);
          Response.Charset = "";
          Response.ContentType = "application/vnd.ms-excel";

          StringWriter sw = new StringWriter();
          HtmlTextWriter htw = new HtmlTextWriter(sw);
          gridviewid.RenderControl(htw);
          Response.Output.Write(sw.ToString());

          Response.Flush();
          Response.End();

      }



      public void ExportGridToPDFWithGeneratedDate(string GenerateFileName, System.Web.UI.HtmlControls.HtmlGenericControl gridviewid)
      {
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                gridviewid.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + GenerateFileName);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }

        //using (StringWriter sw = new StringWriter())
        //{
        //    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //    {
        //        gridviewid.RenderControl(hw);
        //        StringReader sr = new StringReader(sw.ToString());
        //        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //        pdfDoc.Open();

        //        // Use XMLWorker to parse HTML
        //        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);

        //        pdfDoc.Close();
        //    }
        //}

        //// Sending response
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=" + GenerateFileName);
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }
    public SessionData SessionInfo
    {
        get
        {
            if (Session["SessionData"] == null)
            {
                SessionData sessionData = new SessionData();
                Session.Add("SessionData", sessionData);
                return sessionData;
            }
            else
            {
                return Session["SessionData"] as SessionData;
            }
        }
    }
    

    public CacheData CacheInfo
    {
        get
        {
            if (HttpContext.Current.Cache["Excise"] == null)
            {
                CacheData cacheData = new CacheData();
                HttpContext.Current.Cache.Insert("Excise", cacheData, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero);
                return cacheData;
            }
            else
            {
                return HttpContext.Current.Cache["Excise"] as CacheData;
            }
        }
    }
    protected override void OnInit(EventArgs e)
    {
        if (!IsPostBack)
        {
            CacheData objCache = CacheInfo;
        }
    }

    public void Page_Error(object sender, EventArgs e)
    {
        //Exception exception = Server.GetLastError();
        //Response.Clear();
        //HttpException httpException = exception as HttpException;
        ////Pass Param to below methods
        //new AppSetupLogin().InsertErrorLog(SessionInfo.UserName, exception.Source + exception.Message + exception.StackTrace);

        ////some code for logging
        //Response.Redirect("~/ErrorPage.aspx?id=" + exception.Message.ToString(), false);
        //Server.ClearError();
    }



    public string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }

   


    public string Encrypt(string source)
    {
        TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();
        string key = Session["EncryptDecryptKey"].ToString();
        byte[] byteHash;
        byte[] byteBuff;

        byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
        desCryptoProvider.Key = byteHash;
        desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
        byteBuff = Encoding.UTF8.GetBytes(source);

        string encoded =
        Convert.ToBase64String(desCryptoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));

        encoded = encoded.Replace("+", " ");
        return encoded;
    }
    public string Decrypt(string encodedText)
    {
        TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();
        string key = Session["EncryptDecryptKey"].ToString();
        byte[] byteHash;
        byte[] byteBuff;
        encodedText = encodedText.Replace(" ", "+");
        byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
        desCryptoProvider.Key = byteHash;
        desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
        byteBuff = Convert.FromBase64String(encodedText);

        string plaintext = Encoding.UTF8.GetString(desCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
        return plaintext;
    }
}