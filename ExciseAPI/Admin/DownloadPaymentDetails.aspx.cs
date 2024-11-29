using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Excise_BE;
using Excise_DAL;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using DocumentFormat.OpenXml.ExtendedProperties;

namespace ExciseAPI.Admin
{
    public partial class DownloadPaymentDetails : System.Web.UI.Page
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

        }

        protected void btnPaymentDetails_Click(object sender, EventArgs e)
        {
            // Connect to your SQL database
            objBE = new Supplier_BE();
            DataTable dt1 = new DataTable();


            dt1 = objDL.GetPaymentDetails(objBE, ConnKey);
            if (dt1.Rows.Count > 0)
            {
                // Create a new Word document

                MemoryStream ms = new MemoryStream();
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(ms, WordprocessingDocumentType.Document))
                {
                    //ExtendedFilePropertiesPart extendedFilePropertiesPart = wordDocument.AddNewPart<ExtendedFilePropertiesPart>();
                    //Properties properties = new Properties();


                    //propertySet(extendedFilePropertiesPart, properties);

                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                    // Create the document structure and add data from SQL
                    mainPart.Document = new Document();
                    Body body = new Body();
                    mainPart.Document.Append(body);

                    Paragraph para = new Paragraph();
                    Run run = new Run();

                    // Add SQL data to the document
                    foreach (DataRow row in dt1.Rows)
                    {
                        run.Append(new Text(string.Join(", ", row.ItemArray)));
                        run.Append(new Break());
                    }
                    para.Append(run);
                    body.Append(para);

                    DocumentSettingsPart documentSettingsPart = mainPart.AddNewPart<DocumentSettingsPart>();
                    Settings settings = new Settings(
                        new DocumentProtection() { Edit = DocumentProtectionValues.ReadOnly });

                    documentSettingsPart.Settings = settings;
                }

                // Save the Word document to a memory stream
                ms.Position = 0;
                byte[] content = ms.ToArray();

                // Send the file to the browser for download
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now + ".docx");
                Response.BinaryWrite(content);
                Response.End();
            }
        }

        //private void propertySet(ExtendedFilePropertiesPart extendedFilePropertiesPart, Properties properties)
        //{
        //    propertySet(extendedFilePropertiesPart, properties, "true");
        //}

        //private void propertySet(ExtendedFilePropertiesPart extendedFilePropertiesPart, Properties properties, string propertyValue)
        //{
        //    properties.AppendChild(new ReadWriteRecommended() { Val = OnOffValue.FromBoolean(true) });
        //    extendedFilePropertiesPart.Properties = properties;
        //}
    }
}