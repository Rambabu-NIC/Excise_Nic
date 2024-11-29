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
using System.IO;
using System.Globalization;

namespace ExciseAPI.Retailer
{
    public partial class Retailer_Upload_Update : System.Web.UI.Page
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
                //if (Session != null && !string.IsNullOrEmpty(Session["UsrName"].ToString()))
                {
                    //lblUSer.Text = Session["UsrName"].ToString();
                }


            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (FileUpload_docs.HasFile)
            {
                //string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                //string filePath = Server.MapPath("~/Uploads/") + fileName;
                //fileUpload.PostedFile.SaveAs(filePath);

                DataTable dataTable = new DataTable();

                using (StreamReader reader = new StreamReader(FileUpload_docs.PostedFile.InputStream))
                {
                    string[] headers = reader.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header);
                    }

                    while (!reader.EndOfStream)
                    {
                        //reader.ReadLine().StartsWith("\"");
                        //reader.ReadLine().EndsWith("\"");
                        string[] data = ParseCSVLine(reader.ReadLine());
                        DataRow row = dataTable.NewRow();

                        for (int i = 0; i < headers.Length; i++)
                        {
                            row[i] = data[i];
                        }

                        // CreateResponse();
                        dataTable.Rows.Add(row);
                    }
                    DataTable dt = CreateResponse();
                    if (dataTable.Rows.Count > 0)
                    {
                        var duplicates = dataTable.AsEnumerable().GroupBy(r => r[4]).Where(g => g.Count() > 1).ToList();

                        if (duplicates.Count == 0)
                        {
                            foreach (DataRow dr in dataTable.Rows)
                            {
                                DataRow row = dt.NewRow();
                                row["Type_Retailer"] = dr["License_type"].ToString();
                                row["Retailer_Code"] = dr["Retailer Code"].ToString();
                                row["Retailer_Name"] = dr["Retailer_Name"].ToString();
                                row["DEPOTCODE"] = dr["Depot Name"].ToString();
                                row["State"] = "36";
                                if (string.IsNullOrEmpty(dr["Revenue_Distict_Name"].ToString()))
                                {
                                    row["RDist"] = null;
                                }
                                else
                                {
                                    row["RDist"] = dr["Revenue_Distict_Name"].ToString();
                                }

                                row["ExDist"] = null;
                                row["ExSation"] = null;
                                row["MandalCode"] = null;
                                row["License_Name"] = dr["License_Name"].ToString();
                                row["License_No"] = dr["License_No"].ToString();
                                row["Excise_tax"] = decimal.Parse(dr["Excise_tax"].ToString());

                                row["Address"] = dr["Address"].ToString();
                                row["Email_Id"] = dr["Email_Id"].ToString();
                                row["Mobile"] = dr["Mobile"].ToString();
                                row["Gazette_Code"] = dr["Gazette_Code"].ToString();
                                row["Pincode"] = dr["Pincode"].ToString();
                                row["Pan_Number"] = dr["Pan_Number"].ToString();
                                int status = 0;
                                if (dr["Status"].ToString() == "ACTIVE")
                                {
                                    status = 1;

                                    row["Status"] = status.ToString();
                                }
                                else
                                {
                                    row["Status"] = status.ToString();
                                }
                                row["LATITUDE"] = dr["LATITUDE"].ToString();
                                row["LONGITUDE"] = dr["LONGITUDE"].ToString();
                                row["DDOCode"] = dr["DDOCode"].ToString();
                                //row["Retailer_Type"] = null;

                                row["CreatedBy"] = Session["UsrName"].ToString();
                                //row["CreatedDate"] = "CreatedDate";
                                row["IsActive"] = "1";
                                dt.Rows.Add(row);


                            }
                            dt = objDL.Retailer_Update(dt, objBE, ConnKey);
                            if (dt.Rows.Count > 0)
                            {
                                objCommon.ShowAlertMessage("Updated Successfully");
                            }
                            else
                            {
                                objCommon.ShowAlertMessage("No Data Found");
                            }

                        }
                        else
                        {
                            objCommon.ShowAlertMessage("Please Check Uploaded File Contains  Duplicate Records or Empty Records...");
                            return;
                        }
                    }
                }

            }
            else
            {
                objCommon.ShowAlertMessage("Please Upload CSV File");
                return;
            }

        }
        public DataTable CreateResponse()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Type_Retailer", typeof(string));
            dt.Columns.Add("Retailer_Code", typeof(int));
            dt.Columns.Add("Retailer_Name", typeof(string));
            dt.Columns.Add("DEPOTCODE", typeof(string));
            dt.Columns.Add("State", typeof(int));
            dt.Columns.Add("RDist", typeof(string));
            dt.Columns.Add("ExDist", typeof(string));
            dt.Columns.Add("ExSation", typeof(string));
            dt.Columns.Add("MandalCode", typeof(string));
            dt.Columns.Add("License_Name", typeof(string));
            dt.Columns.Add("License_No", typeof(string));
            dt.Columns.Add("Excise_tax", typeof(decimal));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Email_Id", typeof(string));
            dt.Columns.Add("Mobile", typeof(string));
            dt.Columns.Add("Gazette_Code", typeof(string));
            dt.Columns.Add("Pincode", typeof(string));
            dt.Columns.Add("Pan_Number", typeof(string));
            dt.Columns.Add("Status", typeof(int));
            dt.Columns.Add("LATITUDE", typeof(string));
            dt.Columns.Add("LONGITUDE", typeof(string));
            dt.Columns.Add("DDOCode", typeof(string));
            //dt.Columns.Add("Retailer_Type",typeof(string));

            dt.Columns.Add("CreatedBy", typeof(string));
            //dt.Columns.Add("CreatedDate", typeof(string));
            dt.Columns.Add("IsActive", typeof(int));
            return dt;

        }

        private string[] ParseCSVLine(string line)
        {
            List<string> columns = new List<string>();
            bool withinQuotes = false;
            StringBuilder currentColumn = new StringBuilder();

            foreach (char c in line)
            {
                if (c == '\"')
                {
                    withinQuotes = !withinQuotes;
                }
                else if (c == ',' && !withinQuotes)
                {
                    columns.Add(currentColumn.ToString());
                    currentColumn.Clear();
                }
                else
                {
                    currentColumn.Append(c);
                }
            }

            columns.Add(currentColumn.ToString());
            return columns.ToArray();
        }
    }
}