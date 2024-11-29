using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.NICAdmin
{
    public partial class Signature : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && (Session["Role"].ToString() == "1" || Session["Role"].ToString() == "50") && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                //lblUSer.Text = Session["UsrName"].ToString();
                // BindTypeofManf();
                // pannelOK.Visible = false;
                // Viewdata();
                //random();


            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            objBE.UserName = Session["UsrName"].ToString();
            objBE.CreatedBy= Session["UsrName"].ToString();
            try
            {
                if (FileUpload_docs.HasFile)
                {
                    Stream fs = FileUpload_docs.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string mime = MimeType.GetMimeType(bytes, FileUpload_docs.PostedFile.FileName);
                   
                   if (mime == "image/jpeg" || mime == "image/png" || mime == "image/jpg")
                   {

                    int len = FileUpload_docs.PostedFile.ContentLength;
                    if ((len / 1024) > 2048)
                    {

                        objCommon.ShowAlertMessage("File size is exceeded");
                        FileUpload_docs.Focus();
                        return;
                    }
                    string fileext = Path.GetExtension(FileUpload_docs.PostedFile.FileName);
                    string filname = Path.GetFileName(FileUpload_docs.PostedFile.FileName);
                    objBE.UploadFiletype = fileext;
                   
                    objBE.UploadFile = bytes;
                   
                    objDL.Signature_Upload(objBE, ConnKey);
                   
                    objCommon.ShowAlertMessage("Uploaded Successfully");
                    return;
                    // objRegBE.PhotoContent = bytes;
                }
                else
                {

                    objCommon.ShowAlertMessage("Invalid file");
                    return;

                }
            }
                    else
                    {
                objCommon.ShowAlertMessage("Please Upload the file");
                return;

            }

        }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}