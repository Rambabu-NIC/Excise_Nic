<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GoList.aspx.cs" Inherits="ExciseAPI.GoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="card">
            <div class="card-body">
                <div class="col-md-12" align="center">
                    <h3 class="form-signin-heading">
                        <%-- <asp:Image ID="Image1" ImageUrl="~/Assests/images/Logged_Out.jpg" CssClass="img-fluid"
                            runat="server" />--%></h3>
                    <div class="row">
                        <div class="col-md-12">
                            <div>
                                <center>
                                    <font color="#203354" size="4px"><u><b>Allotment of A4 Shop Liquor Licenses for the year 2023-25</b></u></font></center>
                            </div>
                            <br />
                            <div>
                                <center>
                                    <font color="green" size="4px"><b>Required Documents for Allotment of A4 Shop Licenses</b></font></center>
                            </div>
                            <table class="table-n">

                                <%-- <tr>
                                        <td>
                                            1. <a href="RDLCReports/G.O.Ms.No.86-01.08.2023-Notification.pdf"
                                                target="_blank"><font color="blue">GO Ms No. 86</font></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            2. 
                                            
                                            <a href="RDLCReports/Guidelines_for_Allotment_of_Shops.pdf" target="_blank"><font
                                                color="blue">Guidelines for A4 Shop Application </font></a>
                                        </td>
                                    </tr>
                                    
                                     <tr>
                                        <td>
                                            3. <a href="RDLCReports/How to Apply.pdf" target="_blank"><font color="blue">How to Apply</font></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            4. <a href="RDLCReports/Application form and Receipt_Entry pass.pdf" target="_blank"><font color="blue">Application
                                                Form</font></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            5. <a href="RDLCReports/Schedule of Allotment Process.pdf" target="_blank"><font
                                                color="blue">Schedule of Allotment Process</font></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           6. <a href="DistGazette.aspx" target="_blank"><font color="blue">District wise A4 Shop Details
                                            </font></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            7. <a href="RDLCReports/DPEO's addresses and Venue for applications , Drawl of Lottery.pdf" target="_blank" ><font
                                                color="blue">DPEO's addresses , Venue for Receipt of Applications and  Drawl of Lots</font></a>
                                        </td>
                                    </tr>--%>

                                <tr>
                                    <td>1. <a href="SupGazette.aspx" target="_blank"><font color="blue">District wise Supplementary notification of Gazettes</font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>2. <a href="RDLCReports/DPEOaddressesandVenuefoapplicationsDrawlofLotteryN.pdf" target="_blank"><font color="blue">Venue for the Receipt of Applications , Drawl of Lots .</font></a>
                                    </td>
                                </tr>

                                <%-- <tr>
                                        <td>
                                            10. <a href="RDLCReports/DocScanner Aug 4, 2023 6-44 PM.pdf" target="_blank"><font color="blue">Point  Correction of venue for Shamshabad and Saroornagar</font></a>
                                        </td>
                                    </tr>--%>

                                <%--	<tr>
                                                <td>
                                                    1.  <a href="DistGazetteNew.aspx" target="_blank"><font color="blue">45 Re-Notified Shops- District Gazettes</font></a>
                                                </td>
                                            </tr>
											<tr>
                                                <td>
												
												 2. <a href="RDLCReports/Re-Notification Schedule for Allotment of A4 shops_2021-23.pdf"
                                                        target="_blank"><font color="blue">Re-Notification Schedule for Allotment of A4 shops_2021-23</font></a>
												</td>
                                            </tr>
											<tr>
                                                <td>
                                                    3. <a href="RDLCReports/Venues for Receipt of Applications for Re-Notified Shops_1.pdf"
                                                        target="_blank"><font color="blue">Venues for Receipt of Applications for Re-Notified Shops</font></a>
                                                </td>
                                            </tr>
											<tr>
                                                <td>
                                                    4. <a href="RDLCReports/Venues for Drawl of Lots for Re-Notified Shops.pdf"
                                                        target="_blank"><font color="blue">Venues for Drawl of Lots for Re-Notified Shops</font></a>
                                                </td>
                                            </tr>
											<tr>
                                                <td>
                                                    5. <a href="RDLCReports/G.O.Ms.No.86-01.08.2023-Notification.pdf"
                                                        target="_blank"><font color="blue">GO Ms No. 98</font></a>
                                                </td>
                                            </tr>
											<tr>
                                                <td>
													6. <a href="RDLCReports/Guidelines for Allotment of Shops.pdf" target="_blank"><font
                                                        color="blue">Guidlines for Allotment Shops</font></a>
                                                </td>
                                            </tr>
											<tr>
                                                <td>
                                                    7. <a href="RDLCReports/Application Form.pdf" target="_blank"><font color="blue">Application
                                                        Form</font></a>
                                                </td>
                                            </tr>
											<tr>
                                                <td>
                                                    8. <a href="SalesGazette.aspx"  target="_blank" ><font color="blue">District Wise and A4 Shop Wise Sales Data for 2019-2021</font></a>
                                                </td>
                                            </tr>--%>
                                <%--
                                <tr>
                                    <td>
                                        1. <a href="RDLCReports/GO No. 98 - Allotment of Retail Liquor A4 Shops 2021-23 - Notification.pdf"
                                            target="_blank"><font color="blue">GO Ms No. 98</font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        2. <a href="RDLCReports/Guidelines for Allotment of Shops.pdf" target="_blank"><font
                                            color="blue">Guidlines for Allotment Shops</font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        3. <a href="RDLCReports/Application Form.pdf" target="_blank"><font color="blue">Application
                                            Form</font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        4. <a href="RDLCReports/Schedule of Allotment Process.pdf" target="_blank"><font
                                            color="blue">Schedule of Allotment Process</font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        5. <a href="DistGazette.aspx"><font color="blue">District Wise Gazettes </font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        6. <a href="RDLCReports/Venues for Receipt of Applications.pdf"><font color="blue">Venue
                                            for Receipt of Applications</font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        7. <a href="RDLCReports/Venues for Drawl of Lots.pdf"><font color="blue">Venue for Drawl
                                            of Lots</font></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        8. <a href="SalesGazette.aspx" target="_blank"><font color="blue">District Wise and
                                            A4 Shop Wise Sales Data for 2019-2021</font></a>
                                    </td>
                                </tr>
                                --%>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
