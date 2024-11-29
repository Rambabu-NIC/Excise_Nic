<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="Menu" TagName="menu" Src="~/NICAdmin/Menu.ascx" %>
<%@ Register TagPrefix="Header" TagName="header" Src="~/Header.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ERCS</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui" />
    <link href="../Assets/CSS/Fontcss.css" rel="stylesheet" />
    <link href="../Assets/CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/Fonts/css/iconfont.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/CSS/dataTables.bootstrap4.min.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/CSS/buttons.dataTables.min.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/CSS/responsive.bootstrap4.min.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/CSS/style.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/CSS/jquery.mCustomScrollbar.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/CSS/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Assets/Scripts/jquery.min.js"></script>
    <script src="../Assets/Scripts/jquery-ui.js" type="text/javascript"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="../Assets/Scripts/jquery.min.js"></script>
    <script type="f1fb9abf53ce300d75205352-text/javascript" src="../Assets/Scripts/modernizr.js"></script>
    <script src="../Assets/Scripts/jquery.dataTables.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
    <script type="text/javascript">
        history.pushState(null, null, 'Dashboard.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'Dashboard.aspx');
        });
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
        window.history.forward(1);
        function noBack() {
            window.history.forward();
        }
        $(function () {
            $("#txtfrm").datepicker({
                defaultDate: "+1w",
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true
            });
            $("#txtto").datepicker({
                defaultDate: "+1w",
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true

            });
        });   
    </script>
    <style type="text/css">
        .table-bordered th
        {
            text-align: center;
        }
        .table-bordered td
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="theme-loader">
        <div class="ball-scale">
            <asp:HiddenField ID="hf" runat="server" />
            <div class='contain'>
                <div class="">
                    <div class="frame">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="pcoded" class="pcoded">
        <div class="pcoded-container navbar-wrapper">
            <nav class="navbar header-navbar pcoded-header">
            <div class="navbar-wrapper">
                <div class="navbar-logo">
                    <a class="mobile-menu" id="mobile-collapse" href="#!"><i class="feather icon-menu"></i>
                    </a><a href="#">
                        Admin
                    </a>
                </div>
                <div class="navbar-container container-fluid ">
                    <ul class="nav-left ">
                        <li><span>Logged in As ::
                            <asp:Label ID="lblUSer" runat="server"  Class="badge badge-lg bg-info"></asp:Label>
                        </span></li>
                    </ul>
                    <ul class="nav-right ">
                        <li><a href="../Logout.aspx"><i class="feather icon-log-out"></i>Logout </a>
                        </li>
                    </ul>
                </div>
            </div>
            </nav>
            <div class="pcoded-main-container">
                <div class="pcoded-wrapper">
                    <Menu:menu ID="menu" runat="server" />
                    <div class="pcoded-content">
                        <div class="pcoded-inner-content">
                            <div class="main-body">
                                <div class="page-wrapper">
                                    <div class="page-header">
                                        <Header:header ID="header" runat="server" />
                                        <div class="row align-items-end">
                                            <div class="col-lg-8">
                                                <div class="page-header-title">
                                                    <div class="breadcrumb-header">
                                                        <h4>
                                                            Dashboard</h4>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="Div1" class="page-body" runat="server">
                                        <div class="row">
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="card">
                                                    <center>
                                                        <h2 style="color: #de5b5b; font-family: calibri; font-weight: 600;">
                                                            Today</h2>
                                                    </center>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="card user-widget-card bg-c-pink">
                                                                <div class="card-block">
                                                                    <i class="feather icon-user bg-simple-c-pink card1-icon"></i>
                                                                    <h4>
                                                                        <asp:Label ID="TotTodaytrns" runat="server" Font-Bold="true"></asp:Label></h4>
                                                                    <p style="font-weight: bold;">
                                                                        Total Transations</p>
                                                                    <%--  <a href="#!" class="more-info">More Info</a>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="card user-widget-card bg-c-yellow">
                                                                <div class="card-block">
                                                                    <i class="feather icon-life-buoy bg-simple-c-yellow card1-icon"></i>
                                                                    <h4>
                                                                        <asp:Label ID="TotTamt" runat="server" Font-Bold="true"></asp:Label></h4>
                                                                    <p style="font-weight: bold;">
                                                                        Total Amount</p>
                                                                    <%-- <a href="#!" class="more-info">More Info</a>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-lg-6">
                                                <div class="card">
                                                    <center>
                                                        <h2 style="color: #de5b5b; font-family: calibri; font-weight: 600;">
                                                            Total cumulative amount</h2>
                                                    </center>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="card user-widget-card bg-c-blue">
                                                                <div class="card-block">
                                                                    <i class="feather icon-user bg-simple-c-blue card1-icon"></i>
                                                                    <h4>
                                                                        <asp:Label ID="TotTrns" runat="server" Font-Bold="true"></asp:Label></h4>
                                                                    <p style="font-weight: bold;">
                                                                        Total Transations</p>
                                                                    <%--  <a href="#!" class="more-info">More Info</a>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="card user-widget-card bg-c-green">
                                                                <div class="card-block">
                                                                    <i class="feather icon-home bg-simple-c-green card1-icon"></i>
                                                                    <h4>
                                                                        <asp:Label ID="TotAmt" runat="server" Font-Bold="true"></asp:Label></h4>
                                                                    <p style="font-weight: bold;">
                                                                        Total Amount
                                                                    </p>
                                                                    <%-- <a href="#!" class="more-info">More Info</a>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <center><b style="color: Red; font-size: 25px;">Event Permit Dashboard</b></center>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div id="Div2" class="table-responsive dt-responsive" runat="server">
                                                    <asp:GridView ID="GvRpt" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                                                        <Columns>
                                                            <%--  <asp:TemplateField HeaderText="SNo">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>  (Not Submitted List) --%>
                                                             <asp:TemplateField HeaderText="Registered">
                                                                <ItemTemplate>
                                                                <asp:LinkButton ID="lnkApplicationsFilled" runat="server" Text='<%# Bind("AppFilled") %>'
                                                                        OnClick="lnkApplicationsFilled_Click"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Permit Fee Paid">
                                                                <ItemTemplate>
                                                                <asp:LinkButton ID="lnkApplicationsPaymentMade" runat="server" Text='<%# Bind("PaymentMade") %>'
                                                                        OnClick="lnkApplicationsPaymentMade_Click"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Submitted">
                                                                <ItemTemplate>
                                                                    <%--<asp:Label ID="lblApplicationRecieved" runat="server" Text='<%# Bind("AppRecieved") %>'></asp:Label>--%>
                                                                    <asp:LinkButton ID="lnkApplicationRecieved" runat="server" Text='<%# Bind("AppRecieved") %>'
                                                                        OnClick="lnkApplicationRecieved_Click"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Process at SHO">
                                                                <ItemTemplate>
                                                                    <%--<asp:Label ID="lblPendingSHO" runat="server" Text='<%# Bind("PendingSHO") %>'></asp:Label>--%>
                                                                    <asp:LinkButton ID="lnkPendingSHO" runat="server" Text='<%# Bind("PendingSHO") %>'
                                                                        OnClick="lnkPendingSHO_Click"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Process at DPEO">
                                                                <ItemTemplate>
                                                                    <%--<asp:Label ID="lblPendingDPEO" runat="server" Text='<%# Bind("PendingDPEO") %>'></asp:Label>--%>
                                                                    <asp:LinkButton ID="lnkPendingDPEO" runat="server" Text='<%# Bind("PendingDPEO") %>'
                                                                        OnClick="lnkPendingDPEO_Click"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Permits issued">
                                                                <ItemTemplate>
                                                                    <%--<asp:Label ID="lblApplicationApproved" runat="server" Text='<%# Bind("Approved") %>'></asp:Label>--%>
                                                                    <asp:LinkButton ID="lnkApplicationApproved" runat="server" Text='<%# Bind("Approved") %>'
                                                                        OnClick="lnkApplicationApproved_Click"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Rejected">
                                                                <ItemTemplate>
                                                                    <%--<asp:Label ID="lblApplicationRejected" runat="server" Text='<%# Bind("Rejected") %>'></asp:Label>--%>
                                                                    <asp:LinkButton ID="lnkApplicationRejected" runat="server" Text='<%# Bind("Rejected") %>'
                                                                        OnClick="lnkApplicationRejected_Click"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div id="Div3" class="table-responsive dt-responsive" runat="server">
                                                    <asp:Label ID="appType" runat="server" Visible="false"></asp:Label>
                                                    <asp:GridView ID="GvRptDtls" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                                                        AllowPaging="True" PageSize="10" OnPageIndexChanging="GvRptDtls_PageIndexChanging" EmptyDataText="No Data Found" OnRowCommand="GvRptDtls_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SNo">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                             <%-- <asp:TemplateField HeaderText="SHO Mobile Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSHOMOB" runat="server" Text='<%# Bind("SHOMob") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="Reg.NO">
                                                                <ItemTemplate>
                                                                   <asp:Label ID="lblTypecode" runat="server" Text='<%# Bind("AppReg_NO") %>' Visible="false"></asp:Label>
                                                                     <asp:LinkButton ID="lblAppRegNo" runat="server" Text='<%# Eval("AppReg_No") %>' CommandName="View" ForeColor="Blue"
                                                                        CausesValidation="false"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Applicant Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplicantName" runat="server" Text='<%# Bind("ApplicantName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="Mobile Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAppNo" runat="server" Text='<%# Bind("Mob_No") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date of Event">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDateofEvent" runat="server" Text='<%# Bind("DateofEvent") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Excise District">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApplicationRecieved" runat="server" Text='<%# Bind("ExDistName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Excise Station">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblExStationName" runat="server" Text='<%# Bind("ExStationName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Permit Fee Paid">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPayRemarks" runat="server" Text='<%# Bind("PayRemarks") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("AppStatus") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="License No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLicenseNo" runat="server" Text='<%# Bind("LicenseNo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="row" runat="server" id="pannelOK" visible="false">
                                            <div class="col-md-12">
                                                <div class="col-sm-4">
                                                </div>
                                                <div class="col-sm-8">
                                                    <div class="card">
                                                        <asp:Panel ID="pnldynamic" runat="server" BorderColor="#b2beb5" BorderStyle="Solid">
                                                            <div class="col-md-12 text-left">
                                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                                                    Text="Details of Premises to be Licensed">
                                                                </asp:Label>
                                                            </div>
                                                            <div class="card-block">
                                                                <div class="row">
                                                                </div>
                                                                <div class="form-group row col-md-12">
                                                                    <label class="col-md-3 col-form-label text-right">
                                                                        Name of Applicant:</label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList Enabled="false" ID="DropDownList2" runat="server">
                                                                            <asp:ListItem Text="Mr" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Miss" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Smt" Value="3"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:Label ID="txtAppliName" Enabled="false" MaxLength="150" runat="server">
                                                                        </asp:Label>
                                                                    </div>
                                                                    <label class="col-md-3 col-form-label text-right">
                                                                        Aadhaar Number:</label>
                                                                    <div class="col-md-3">
                                                                        <asp:Label ID="txtAdharNum" Enabled="false" MaxLength="12" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row col-md-12">
                                                                    <label class="col-md-3 col-form-label text-right">
                                                                        Mobile Number:</label>
                                                                    <div class="col-md-3">
                                                                        <asp:Label ID="txtMobile" Enabled="false" MaxLength="10" runat="server"></asp:Label>
                                                                    </div>
                                                                    <label class="col-md-3 col-form-label text-right">
                                                                        Email:</label>
                                                                    <div class="col-md-3">
                                                                        <asp:Label ID="txtEmail" Enabled="false" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row col-md-12">
                                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                    <asp:Label ID="lblReg" Visible="false" runat="server" Text="Label"></asp:Label>
                                                                    <label class="col-md-3 col-form-label text-right">
                                                                        Age:</label>
                                                                    <div class="col-md-3">
                                                                        <asp:Label ID="txtAge" Enabled="false" MaxLength="3" runat="server"></asp:Label>
                                                                    </div>
                                                                    <label class="col-md-3 col-form-label text-right">
                                                                        Father's Name:</label>
                                                                    <div class="col-md-3">
                                                                        <asp:Label ID="txtFatherName" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row col-md-12">
                                                                    <label class="col-md-3 col-form-label text-right">
                                                                        Residential Address:</label>
                                                                    <div class="col-md-3">
                                                                        <asp:Label ID="txtAdd" Enabled="false" TextMode="MultiLine" MaxLength="200" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <%--<div class="row">--%>
                                                            <%--<div class="col-sm-12">--%>
                                                            <%--<div class="card">--%>
                                                            <%--<div class="col-sm-12">
                                                                        </div>--%>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    House Number/Door Number:
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="txtHsNum" Enabled="false" runat="server" MaxLength="10"></asp:Label>
                                                                </div>
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Name Of the Premises:
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="txtNmePrem" Enabled="false" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Street:
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="txtStreet" Enabled="false" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="container-fluid">
                                                                <div class="col-md-12   text-left">
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                                                        Text="Boundries">
                                                                    </asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    East:
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="txtEast" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                                                </div>
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    West:
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="txtWest" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    North
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="txtNorth" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                                                </div>
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    South:
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="txtSouth" Enabled="false" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Revenue District:</label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="Label6" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblRDist" runat="server"></asp:Label>
                                                                    <%-- <asp:DropDownList ID="ddlRevDistrict" Enabled="false" AutoPostBack="true" runat="server"
                                                                                     OnSelectedIndexChanged="ddlRevDistrict_SelectedIndexChanged">
                                                                                </asp:DropDownList>--%>
                                                                </div>
                                                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Mandal:</label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="lblbRMand" runat="server"></asp:Label>
                                                                    <%--  <asp:DropDownList ID="ddlMandal" Enabled="false" AutoPostBack="true" runat="server"
                                                                                     OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                                </asp:DropDownList>--%>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Village/Locality:</label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="lblbRVill" runat="server"></asp:Label>
                                                                    <%-- <asp:DropDownList ID="ddlLocality" Enabled="false" runat="server" >
                                                                                </asp:DropDownList>--%>
                                                                </div>
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Excise District:</label>
                                                                <div class="col-md-3">
                                                                    <%-- <asp:DropDownList ID="ddlExciseDistrict" Enabled="false" runat="server" 
                                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlExciseDistrict_SelectedIndexChanged" Visible="false">
                                                                                </asp:DropDownList>--%>
                                                                    <asp:Label ID="lblExDistCode" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblExDist" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Excise Station:</label>
                                                                <div class="col-md-3">
                                                                    <%-- <asp:DropDownList ID="ddlExciseStation" Enabled="false" runat="server" >
                                                                                </asp:DropDownList>--%>
                                                                    <asp:Label ID="lblExStationCd" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblExStation" runat="server"></asp:Label>
                                                                    <asp:Label ID="lblGHMC" runat="server" Visible="false"></asp:Label>
                                                                </div>
                                                                <div class="col-md-3">
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Whether the Permises is in Conformity with the Rule 7 of A.P.Excise(Grant of Licence
                                                                    of Selling by In-House&amp;Conditions of licence Rules 2005)</label>
                                                                <div class="col-md-3">
                                                                    <%-- <asp:DropDownList ID="ddlExciseStation" Enabled="false" runat="server" >
                                                                                </asp:DropDownList>--%>
                                                                    <asp:Label ID="lblRule7" runat="server"></asp:Label>
                                                                </div>
                                                                <div class="col-md-3">
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Date And Time of Event:</label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="ddlEvntTm" Enabled="false" runat="server"></asp:Label>
                                                                    <%--<asp:DropDownList ID="ddlEvntTm" Enabled="false" runat="server">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Slot1(11AM-4PM)" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Slot1(4PM-11PM)" Value="2"></asp:ListItem>
                                                                                </asp:DropDownList>--%>
                                                                    <asp:Label ID="txtEvnDate" Enabled="false" runat="server"></asp:Label>
                                                                </div>
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Type Of Event:</label>
                                                                <div class="col-md-3">
                                                                    <%-- <asp:DropDownList ID="ddlEvntType" Enabled="false" AutoPostBack="true" runat="server"
                                                                                    >
                                                                                </asp:DropDownList>--%>
                                                                    <asp:Label ID="Label5" Enabled="false" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Event On Occasion Of:</label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="txtEvent" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                                                    <asp:Label ID="lbleventid" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblevent" runat="server" Visible="false"></asp:Label>
                                                                </div>
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Licence Fee: <br />
                                                                    Differential Fee:
                                                                    </label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="lblFee" Enabled="false" runat="server" Text=""></asp:Label>
                                                                    &nbsp;<asp:Label ID="lblDFee" runat="server"  Text="0.00"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div id="Div4" runat="server" class="form-group row col-md-12">
                                                                <div class="col-md-3">
                                                               Premises Address :    <asp:Label ID="lbleventtypee" runat="server" Text="Label"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="container-fluid">
                                                                <div class="col-md-12   text-left">
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                                                        Text="Date and Remarks Entry For SHO">
                                                                    </asp:Label>
                                                                </div>
                                                            </div>
                                                            
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Date of the Inspection:</label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="txtDtInsp" runat="server" ></asp:Label>
                                                                </div>
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    SHO Remarks:</label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="txtRemarks" MaxLength="250" runat="server"
                                                                        TextMode="MultiLine"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Differential Amount:
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:Label ID="txt_DAmount" MaxLength="150" runat="server"></asp:Label>
                                                                   
                                                                </div>
                                                            </div>
                                                           
                                                            <%--  </div>--%>
                                                            <%--</div>--%>
                                                            <%-- </div>--%>
                                                        </asp:Panel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                       <%-- <div class="row" runat="server" id="pannelOK">
                                            <div class="col-md-12 text-center">
                                                <div class="col-sm-12 text-center">
                                                    <rsweb:ReportViewer ID="ReptReg" Width="100%" Height="100%" runat="server" SizeToReportContent="true">
                                                    </rsweb:ReportViewer>
                                                </div>
                                            </div>
                                        </div>--%>
                                        <%--   <div class="col-md-12 text-right">
                                         <asp:Button ID="imgbtnExcel"  Text="Download Excel"
                                                 
                                                    runat="server" onclick="imgbtnExcel_Click1" />
                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="f1fb9abf53ce300d75205352-text/javascript" src="../Assets/Scripts/jquery-ui.min.js"></script>
        <script type="f1fb9abf53ce300d75205352-text/javascript" src="../Assets/Scripts/popper.min.js"></script>
        <script type="f1fb9abf53ce300d75205352-text/javascript" src="../Assets/Scripts/bootstrap.min.js"></script>
        <script type="f1fb9abf53ce300d75205352-text/javascript" src="../Assets/Scripts/jquery.slimscroll.js"></script>
        <!-- data-table js -->
        <script src="../Assets/Scripts/jquery.dataTables.min.js" type="9b4f5222b3507669ee2c1f74-text/javascript"></script>
        <script src="../Assets/Scripts/dataTables.buttons.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
        <script src="../Assets/Scripts/dataTables.responsive.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
        <script src="../Assets/Scripts/dataTables.bootstrap4.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
        <script src="../Assets/Scripts/jszip.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
        <script src="../Assets/Scripts/pdfmake.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
        <script src="../Assets/Scripts/vfs_fonts.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
        <script src="../Assets/Scripts/buttons.print.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
        <script src="../Assets/Scripts/buttons.html5.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
        <script src="../Assets/Scripts/responsive.bootstrap4.min.js" type="1b68f0ad7eef7177e7c82893-text/javascript"></script>
        <script src="../Assets/Scripts/data-table-custom.js" type="cfcdfdafe9b0c09b20e4039c-text/javascript"></script>
        <!-- data-table js -->
        <script src="../Assets/Scripts/jquery.mCustomScrollbar.concat.min.js" type="f1fb9abf53ce300d75205352-text/javascript"></script>
        <script type="f1fb9abf53ce300d75205352-text/javascript" src="../Assets/Scripts/SmoothScroll.js"></script>
        <script src="../Assets/Scripts/pcoded.min.js" type="f1fb9abf53ce300d75205352-text/javascript"></script>
        <!-- custom js -->
        <script src="../Assets/Scripts/vartical-layout.min.js" type="f1fb9abf53ce300d75205352-text/javascript"></script>
        <script type="f1fb9abf53ce300d75205352-text/javascript" src="../Assets/Scripts/custom-dashboard.js"></script>
        <script type="f1fb9abf53ce300d75205352-text/javascript" src="../Assets/Scripts/script.min.js"></script>
        <script src="https://ajax.cloudflare.com/cdn-cgi/scripts/a2bd7673/cloudflare-static/rocket-loader.min.js"
            data-cf-settings="f1fb9abf53ce300d75205352-|49" defer=""></script>
    </form>
</body>
</html>
