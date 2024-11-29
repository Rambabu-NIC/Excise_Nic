
using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace ExciseAPI.NICAdmin
{
    public class SupplierDataHandler
    {
        SupplierDAL objDL = new SupplierDAL();
       
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        public StringBuilder GetSupplierdataList(string MFType)
        {
            DataTable dt = objDL.SupplierdataList(ConnKey, MFType);
            StringBuilder html = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + row["DistName"].ToString() + "</td>");
                    html.Append("<td>" + row["Supplier_Name"].ToString() + "</td>");
                    html.Append("<td>" + row["Address"].ToString() + "</td>");
                    html.Append("<td>" + row["Mobile"].ToString() + "</td>");
                    html.Append("<td>" + row["License_No"].ToString() + "</td>");
                    html.Append("</tr>");
                }
            }
            return html;
        }

        //public string GetSupplierdataList(string MFType)
        //{
        //    DataTable dt = objDL.SupplierdataList(ConnKey, MFType); // Get all data
        //    StringBuilder html = new StringBuilder();

        //    // Calculate the start index for the records to be displayed
        //    int startIndex = (pageNumber - 1) * recordsPerPage;
        //    int endIndex = startIndex + recordsPerPage;

        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        // Get the subset of records for the current page
        //        DataTable paginatedData = dt.AsEnumerable()
        //                                     .Skip(startIndex)
        //                                     .Take(recordsPerPage)
        //                                     .CopyToDataTable();

        //        // Generate HTML for table rows
        //        foreach (DataRow row in paginatedData.Rows)
        //        {
        //            html.Append("<tr>");
        //            html.Append("<td>" + row["DistName"].ToString() + "</td>");
        //            html.Append("<td>" + row["Supplier_Name"].ToString() + "</td>");
        //            html.Append("<td>" + row["Address"].ToString() + "</td>");
        //            html.Append("<td>" + row["Mobile"].ToString() + "</td>");
        //            html.Append("<td>" + row["License_No"].ToString() + "</td>");
        //            html.Append("</tr>");
        //        }

        //        // Add pagination controls (Previous, Next, and Page Numbers)
        //        int totalRecords = dt.Rows.Count;
        //        int totalPages = (int)Math.Ceiling((double)totalRecords / recordsPerPage);

        //        html.Append("<tr><td colspan='5' style='text-align:center;'>");

        //        // Previous Button
        //        if (pageNumber > 1)
        //        {
        //            html.Append("<a href='#' data-page-number='" + (pageNumber - 1) + "' class='page-btn'>&laquo; Previous</a> ");
        //        }

        //        // Page Number Buttons
        //        for (int i = 1; i <= totalPages; i++)
        //        {
        //            html.Append("<a href='#' data-page-number='" + i + "' class='page-btn'>" + i + "</a> ");
        //        }

        //        // Next Button
        //        if (pageNumber < totalPages)
        //        {
        //            html.Append("<a href='#' data-page-number='" + (pageNumber + 1) + "' class='page-btn'>Next &raquo;</a>");
        //        }

        //        html.Append("</td></tr>");
        //    }

        //    return html.ToString();
        //}

    }

}