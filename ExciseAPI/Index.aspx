<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ExciseAPI.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
       <marquee behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();">
<%--           <a href="GoList.aspx" target="_blank"><font size="5px" color="#203354"><img src="Assets/images/new.gif" style="height:35px; width:40px;" /><b> Supplementary Gazette Notification for Undisposed Liquor Shops for the License Period  2023-25</b></font></a>--%>
           <a href="#" target="_blank"><font size="5px" color="#203354"><img src="Assets/images/new.gif" style="height:35px; width:40px;" /><b>Use Retailer Code as User Name For Retailer Payments  </b></font></a>

       </marquee>
        <section class="page-section" id="home" >
            <div class="pcoded-content">
                <div class="pcoded-inner-content">
                    <div class="main-body">
                        <div class="page-wrapper">
                            <div class="wrapper">
                                <div class="row col-xl-12 col-md-12">
                                    <div class="row col-md-12">
                                        <div class="col-md-3">
                                            <asp:LinkButton ID="btnReg" runat="server" CssClass="btn btn-small btn-primary" Width="275px"
                                                Style="border-radius: 10px; height: 40px; background-color: #37a961; padding: 5px 5px;"
                                                OnClick="Default"><i class="fa fa-credit-card"></i>&nbsp;ERCS</asp:LinkButton>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:LinkButton ID="btnRuser" runat="server" CssClass="btn btn-small btn-primary"
                                                Style="border-radius: 10px; height: 40px; background-color: #9a840a; padding: 10px 10px;"
                                                Width="275px" OnClick="EventDefault"><i class="fa fa-inbox"></i>&nbsp;EVENT PERMIT</asp:LinkButton>
                                        </div>
                                        <div class="col-md-3 ">
                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-small btn-primary"
                                                Style="border-radius: 10px; height: 40px; background-color: #FF33F0; padding: 10px 10px;"
                                                Width="275px" OnClick="RLogin"><i class="fa fa-home"></i>&nbsp;Retailer Payments</asp:LinkButton>
                                        </div>
                                        <div class="col-md-3 ">
                                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-small btn-primary"
                                                Style="border-radius: 10px; height: 40px; background-color:#337ab7; padding: 10px 10px;"
                                                Width="275px" OnClick="LinkButton2_Click"><i class="fa fa-home"></i>&nbsp;EODB</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                                <br />
                                <br />
                                <div class="row col-md-12 ">
                                    <div class="col-md-8">
                                        <div id="hit" style="text-align: center" runat="server">
                                            <img src="../Assets/images/download.jpg" style="width: 600px;" />
                                        </div>
                                    </div>
                                  
                                    <div class="col-md-4">
                                        <div>
                                            <center>
                                        <font color="green" size="4px"><b>Important Documents</b></font>

                                    </center>
                                        </div>
                                   <table class="table-n">

                                
                                <tr>
                                        <td>
                                            1. <a href="GoList.aspx"
                                                target="_blank"><font color="blue">Supplementary Gazette Notification <br /> for Undisposed Liquor Shops for the License Period  2023-25</font></a>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            2. <a href="RDLCReports/G.O.Ms.No.86-01.08.2023-Notification.pdf"
                                                target="_blank"><font color="blue">GO Ms No. 86</font></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            3. 
                                            
                                            <a href="RDLCReports/Guidelines_for_Allotment_of_Shops.pdf" target="_blank"><font
                                                color="blue">Guidelines for A4 Shop Application </font></a>
                                        </td>
                                    </tr>
                                    
                                     <tr>
                                        <td>
                                            4. <a href="RDLCReports/How to Apply.pdf" target="_blank"><font color="blue">How to Apply</font></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            5. <a href="RDLCReports/Application form and Receipt_Entry pass.pdf" target="_blank"><font color="blue">Application
                                                Form</font></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            6. <a href="RDLCReports/Schedule of Allotment Process.pdf" target="_blank"><font
                                                color="blue">Schedule of Allotment Process</font></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           7. <a href="DistGazette.aspx" target="_blank"><font color="blue">District wise A4 Shop Details
                                            </font></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            8. <a href="RDLCReports/DPEO's addresses and Venue for applications , Drawl of Lottery.pdf" target="_blank" ><font
                                                color="blue">DPEO's addresses , Venue for Receipt of Applications and  Drawl of Lots</font></a>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            9. <a href="SalesGazette.aspx" target="_blank"><font color="blue">District wise A4 Shop turnover in the year 2021-23</font></a>
                                        </td>
                                    </tr>

                                     <tr>
                                        <td>
                                            10. <a href="RDLCReports/Application Fee Payment Details.pdf" target="_blank"><font color="blue">Application Fee Payment Details</font></a>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            11. <a href="RDLCReports/DocScanner Aug 4, 2023 6-44 PM.pdf" target="_blank"><font color="blue">Point  Correction of venue for Shamshabad and Saroornagar</font></a>
                                        </td>
                                    </tr>
                                  <%-- DistGazette.aspx RDLCReports/Venues for Receipt of Applications.pdf<tr>
                                        <td>
                                            7. <a href="RDLCReports/Venues for Drawl of Lots.pdf" target="_blank"><font color="blue">
                                                Venue for Drawl of Lots</font></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            8. <a href="SalesGazette.aspx" target="_blank"><font color="blue">District Wise and
                                                A4 Shop Wise Sales Data for 2019-2021</font></a>
                                        </td>
                                    </tr>--%>

                                  
                                </table>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                    </div>
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <div class="col-sm-4 col-form-label text-left">
                                            </div>
                                            <asp:Label ID="lblApPStatus" runat="server" Visible="false"></asp:Label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <%-- <div class="col-sm-6 col-form-label text-left">
                                                                            <asp:LinkButton ID="btnRuser" runat="server" CssClass="btn btn-small btn-primary"
                                                                                Width="275px" OnClick="btnRuser_Click"><i class="fa fa-inbox"></i>&nbsp;Registered Permit</asp:LinkButton>
                                                                        </div>--%>
                                            <div class="col-sm-4 col-form-label text-left">
                                            </div>
                                            <div class="col-sm-4 col-form-label text-left">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
