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
    public partial class Service_Chart : System.Web.UI.Page
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
        }
        
        public void BindData()
        {
            //gvmanufacturers.DataSource = null;
            //gvmanufacturers.DataBind();
            //gvretailers.DataSource = null;
            //gvretailers.DataBind();
            DataSet dsservicechart = objDL.GetServicechartDetails(objBE, ConnKey);
            if (dsservicechart.Tables.Count > 0)
            {
                if (dsservicechart.Tables[0].Rows.Count > 0)
                {
                    gvmanufacturers.DataSource = dsservicechart.Tables[0];
                    gvmanufacturers.DataBind();
                }
                else
                {
                    gvmanufacturers.DataSource = "";
                    gvmanufacturers.DataBind();
                }
                if (dsservicechart.Tables[1].Rows.Count > 0)
                {
                    gvretailers.DataSource = dsservicechart.Tables[1];
                    gvretailers.DataBind();
                }
                else
                {
                    gvretailers.DataSource = "";
                    gvretailers.DataBind();
                }
            }
        }
    }
}