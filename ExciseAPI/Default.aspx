<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="HDefault" %>

<%@ Register TagPrefix="Menu" TagName="menu" Src="~/HMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Excise </title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui" />
    <link href="Assets/CSS/Fontcss.css" rel="stylesheet" />
    <link href="Assets/CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Assets/Fonts/css/iconfont.css" rel="stylesheet" type="text/css" />
    <link href="Assets/CSS/style.css" rel="stylesheet" type="text/css" />
    <link href="Assets/CSS/jquery.mCustomScrollbar.css" rel="stylesheet" type="text/css" />
    <link href="Assets/CSS/TopMenu.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css"
        integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/"
        crossorigin="anonymous">
    <style type="text/css">
        .hit
        {
            display: inline-block;
            font-weight: bold;
            font-size: large;
            padding: 6px 6px 4px;
            border-radius: 3px;
            background: #212f3d;
            color: White;
            text-align: center;
            margin: 20px auto;
        }
    </style>
    <style>
        .table-n
        {
            border: 1px solid black; /*height: 463px;*/
            width: 441px;
        }
        .table-n tbody > tr
        {
            height: 40px;
        }
    </style>
    <style>
        table, th, td
        {
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="theme-loader">
        <div class="ball-scale">
            <div class='contain'>
                <div class="loader">
                    <div class="frame">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="pcoded" class="pcoded load-height">
        <div class="pcoded-inner-content" style="background-color: #01444e; margin-top: 2px;
            padding-left: 25px;">
            <div class="row align-items-end">
                <div class="col-lg-1">
                    <div class="page-header-title">
                        <div class="d-inline">
                            <img src="Assets/images/tg.png" alt="Telangana-Logo" />
                        </div>
                    </div>
                </div>
                <div class="col-lg-1">
                    <div class="page-header-title">
                        <div class="d-inline">
                            <img src="Assets/images/deptlogo.png" alt="digitalindia-Logo" />
                        </div>
                    </div>
                </div>
                <div class="col-lg-7" style="padding-top: -2px; color: White;">
                    <h1 style="margin-top: -10px">
                        <font size="6px">Government of Telangana</font></h1>
                    <h1>
                        <font size="6px">Prohibition & Excise Department</font>
                    </h1>
                    <%--<h1>
                        <font size="3px">Excise Revenue Collection System</font>
                    </h1>--%>
                </div>
                <div class="col-lg-2">
                    <div class="page-header-title">
                        <div class="d-inline">
                          <%--   <img src="Assets/images/header_logo.png" style="height: 160px; width: 320px;" /> --%>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <Menu:menu ID="menu" runat="server" />
    <marquee behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();"><a href="GoList.aspx" target="_blank"><font size="5px" color="#203354"><img src="Assets/images/new.gif" style="height:35px; width:40px;" /><b> Supplementary Gazette Notification for Undisposed Liquor Shops for the License Period  2023-25</b></font></a></marquee>
    <!-- <div>
        <center>
            <a href="RDLCReports/Application Form.pdf" target="_blank"><font size="5px" color="red"
                align="center"><u>Download Application Form</u></font></a></center>
    </div>-->
    <div class="pcoded-content">
        <div class="pcoded-inner-content">
            <div class="main-body">
                <div class="page-wrapper">
                    <div class="container-fluid">
                        <div class="col-xl-12 col-md-12">
                            <div class="row">
                                <div class="col-md-3">
                                    <asp:LinkButton ID="btnReg" runat="server" CssClass="btn btn-small btn-primary" Width="275px"
                                        Style="border-radius: 20px; height: 50px; background-color: #37a961; padding: 15px 15px;
                                        margin-left: 60px;" OnClick="Default"><i class="fa fa-credit-card"></i>&nbsp;ERCS</asp:LinkButton>
                                </div>
                                <div class="col-md-3">
                                    <asp:LinkButton ID="btnRuser" runat="server" CssClass="btn btn-small btn-primary"
                                        Style="border-radius: 20px; height: 50px; background-color: #9a840a; padding: 15px 15px;
                                        margin-left: 80px;" Width="275px" OnClick="EventDefault"><i class="fa fa-inbox"></i>&nbsp;EVENT PERMIT</asp:LinkButton>
                                </div>
                                <div class="col-md-3 ">
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-small btn-primary"
                                        Style="border-radius: 20px; height: 50px; background-color:#FF33F0; padding: 15px 15px;
                                        margin-left: 80px;" Width="275px" OnClick="RLogin"><i class="fa fa-home"></i>&nbsp;Retailer Payments</asp:LinkButton>
                                </div>
                                <div class="col-md-3">
                                    <asp:LinkButton ID="btnGeetaBima" runat="server" CssClass="btn btn-small btn-primary" Width="275px"
                                        Style="border-radius: 20px; height: 50px; background-color: #37a961; padding: 15px 15px;
                                        margin-left: 60px;" OnClick="btnGeetaBima_OnClick"><i class="fa fa-credit-card"></i>&nbsp;Geeta Bima</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="row">
                            <div class="col-md-8">
                                 <div id="hit" style="text-align: center" runat="server">
                                            <img src="Assets/images/download.jpg" style="width: 700px;" />
                                        </div>
                            </div>
                            <div class="col-md-4">
                                <div>
                                    <center>
                                        <font color="green" size="3px"><b>Required Documents for Allotment of A4 Shop Licenses</b></font></center>
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
                            <%--  </div>
                            </div>--%>
                        </div>

                       
                        <br />
                        <div style=" text-align:right">
                       <font size="10px"  color="#203354"  > <a href="https://twitter.com/CPE_Telangana" target="_blank">              <img src="Assets/images/twiit.png" />  <b> Prohibition and Excise Dept, Govt of Telangana (@CPE_Telangana) / Twitter </b>   </a>  </font>
                       </div>
                        <br />
                        <div class="row">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-8">
                                <div class="form-group row">
                                    <div class="col-sm-4 col-form-label text-left">
                                    </div>


                                    <marquee behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();"><font size="5px" color="#203354"><img src="Assets/images/new.gif" style="height:35px; width:40px;" /><b>Help line numbers : 04024733048;04024733047;18004252523</b></font>   </marquee>
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
    <div class="footer bg-inverse">
        <p class="text-center">
            Site designed , developed and hosted by National Informatics Centre,Telangana ,Hyderabad.
            Content Owned and updated by Prohibition and Excise Department Govt of Telangana
            Hyderabad.
        </p>
    </div>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/jquery.min.js"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/jquery-ui.min.js"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/popper.min.js"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/bootstrap.min.js"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/jquery.slimscroll.js"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/modernizr.js"></script>
    <script src="Assets/Scripts/pcoded.min.js" type="f1fb9abf53ce300d75205352-text/javascript"></script>
    <script src="../Assets/Scripts/vartical-layout.min.js" type="f1fb9abf53ce300d75205352-text/javascript"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="Assets/Scripts/script.min.js"></script>
    <script type="text/javascript" src="Assets/Scripts/rocket-loader.min.js" data-cf-settings="f1fb9abf53ce300d75205352-|49"
        defer=""></script>
    </form>
</body>
</html>
