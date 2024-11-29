<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ExciseAPI.NICAdmin.Dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .wrap-text {
        white-space: normal;
        word-wrap: break-word;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Dashboard</div>
            <div class="content">
                <div id="Div1" class="page-body" runat="server">
                    <center>
                                            <b style="color: Red; font-size: 25px;">Excise Revenue Collecting System</b></center>
                    <center>
                                            <b style="color: Red; font-size: 25px;">Suppliers</b></center>
                      <div class="block black bg-white">
                                <div class="head">Supplier Payments</div>
                                
                    <div class="container-fluid row text-center">
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
                                                    Total Transactions
                                                </p>
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
                                                    Total Amount
                                                </p>
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
                                                    Total Transactions
                                                </p>
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

                          </div>
                    <center>
                                            <b style="color: Red; font-size: 25px;">Retailers</b></center>
                    <div class="block black bg-white">
                                <div class="head">Sales proceedings</div>
                    <div class="container-fluid row text-center">
                        <div class="col-md-6 col-sm-6 col-lg-6">
                            <div class="card">
                                <center>
                                                        <h2 style="color: #de5b5b; font-family: calibri; font-weight: 600;">
                                                            Today</h2>
                                                    </center>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="card user-widget-card bg-c-pink">
                                            <div class="card-block" <%--style="background-color:blue;"--%>>
                                                <i class="feather icon-user bg-simple-c-pink card1-icon"></i>
                                                <h4>
                                                    <asp:Label ID="lblSalesProceedTodayCount" runat="server" Font-Bold="true"></asp:Label></h4>
                                                <p style="font-weight: bold;">
                                                    Total Transactions
                                                </p>
                                                <%--  <a href="#!" class="more-info">More Info</a>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card user-widget-card bg-c-yellow">
                                            <div class="card-block">
                                                <i class="feather icon-life-buoy bg-simple-c-yellow card1-icon"></i>
                                                <h4>
                                                    <asp:Label ID="lblSalesProceedTodayAmount" runat="server" Font-Bold="true"></asp:Label></h4>
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
                                                    <asp:Label ID="lblSalesProceedTotalCount" runat="server" Font-Bold="true"></asp:Label></h4>
                                                 <p style="font-weight: bold;">
                                                Total Transactions
                                                </p>
                                                <%--  <a href="#!" class="more-info">More Info</a>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card user-widget-card bg-c-green">
                                            <div class="card-block">
                                                <i class="feather icon-home bg-simple-c-green card1-icon"></i>
                                               <h4>
                                                    <asp:Label ID="lblSalesProceedTotalAmount" runat="server" Font-Bold="true"></asp:Label></h4>
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
                        </div>
























                    
                    <center>
                                            <b style="color: Red; font-size: 25px;">Event Permits </b>
                                        </center>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:HiddenField ID="hfDate" runat="server" Visible="false" />
                            <asp:Label ID="dateGrid" runat="server" Visible="false" />
                            <asp:Label ID="gridData" runat="server" Visible="false" />
                            <div class="form-group row ">
                                <label class="col-md-3 col-form-label text-right">
                                    From Date<span style="color: Red"> *</span></label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtfrm" runat="server" AutoCompleteType="Disabled" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtfrm" Format="dd-MM-yyyy"></cc1:CalendarExtender>
                                </div>
                                <label class="col-md-3 col-form-label text-right">
                                    To Date<span style="color: Red"> *</span></label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtto" runat="server" AutoCompleteType="Disabled" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtto" Format="dd-MM-yyyy"></cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 text-center">
                            <asp:Button ID="btn_GetDetails" runat="server" Text="GetDetails" OnClick="btn_Details_Click"
                                CssClass=" btn btn-secondary" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 col-sm-12">
                            <center><strong>(OR)</strong></center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-9">

                            <asp:Label ID="regGrid" runat="server" Visible="false" />
                            <%--<asp:Label ID="Label7" runat="server" Visible="false" />--%>
                            <div class="form-group row ">
                                <label class="col-md-3 col-form-label text-right">
                                    From Reg. No<span style="color: Red"> *</span></label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtRegNoFrom" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                                <label class="col-md-3 col-form-label text-right">
                                    To Reg. No<span style="color: Red"> *</span></label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtRegNoTo" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 text-center">
                            <asp:Button ID="btnGetDetails" runat="server" Text="GetDetails" OnClick="btnDetails_Click"
                                CssClass=" btn btn-secondary" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="w-100 fl container-fluid">

                        <div class="block black bg-white">
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
                                                <asp:Label ID="lblFeePaid" runat="server" Font-Bold="true" Text='<%# Bind("PaymentAmount") %>'></asp:Label>(
                                                                    <asp:LinkButton ID="lnkApplicationsPaymentMade" runat="server" Text='<%# Bind("PaymentMade") %>'
                                                                        OnClick="lnkApplicationsPaymentMade_Click"></asp:LinkButton>)
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
                                        <asp:TemplateField HeaderText="Differential Amount">
                                            <ItemTemplate>
                                                <%--<asp:Label ID="lblPendingSHO" runat="server" Text='<%# Bind("PendingSHO") %>'></asp:Label>--%>
                                                <asp:LinkButton ID="lnkReturnSHO" runat="server" Text='<%# Bind("DifferentialAmount") %>'
                                                    OnClick="lnkReturnSHO_Click"></asp:LinkButton>
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
                    <center>
                                            <b style="color: Red; font-size: 25px;">Registered for Future Date Event's </b>
                                        </center>
                    <div class="w-100 fl container-fluid">

                        <div class="block black bg-white">
                            <div id="Div5" class="table-responsive dt-responsive" runat="server">
                                <asp:GridView ID="GvRptFuture" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Registered">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkApplicationsFilledF" runat="server" Text='<%# Bind("AppFilled") %>'
                                                    OnClick="lnkApplicationsFilledF_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Permit Fee Paid">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFeePaid" runat="server" Font-Bold="true" Text='<%# Bind("PaymentAmount") %>'></asp:Label>(
                                                                    <asp:LinkButton ID="lnkApplicationsPaymentMadeF" runat="server" Text='<%# Bind("PaymentMade") %>'
                                                                        OnClick="lnkApplicationsPaymentMadeF_Click"></asp:LinkButton>)
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Incomplete Payment">
                                            <ItemTemplate>

                                                <asp:LinkButton ID="lnkPaymentNotMadeF" runat="server" Text='<%# Bind("PaymentNotDone") %>'
                                                    OnClick="lnkPaymentNotMadeF_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Submitted">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkApplicationRecievedF" runat="server" Text='<%# Bind("AppRecieved") %>'
                                                    OnClick="lnkApplicationRecievedF_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Process at SHO">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPendingSHOF" runat="server" Text='<%# Bind("PendingSHO") %>'
                                                    OnClick="lnkPendingSHOF_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Differential Amount">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkReturnSHOF" runat="server" Text='<%# Bind("DifferentialAmount") %>'
                                                    OnClick="lnkReturnSHOF_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Process at DPEO">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPendingDPEOF" runat="server" Text='<%# Bind("PendingDPEO") %>'
                                                    OnClick="lnkPendingDPEOF_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Permits issued">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkApplicationApprovedF" runat="server" Text='<%# Bind("Approved") %>'
                                                    OnClick="lnkApplicationApprovedF_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rejected">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkApplicationRejectedF" runat="server" Text='<%# Bind("Rejected") %>'
                                                    OnClick="lnkApplicationRejectedF_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <%--<div class="w-100 fl container-fluid" id="Divv" runat="server" visible="false">

                        <div class="block black bg-white">--%>
                            <div id="Div3" class="content" runat="server"  style="max-height: 400px; overflow-x: auto; overflow-y:hidden; width: 100%;">
                    
                                <asp:Label ID="appType" runat="server" Visible="false"></asp:Label>
                                <asp:GridView ID="GvRptDtls" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                                    AllowPaging="True" PageSize="10" OnPageIndexChanging="GvRptDtls_PageIndexChanging"
                                    EmptyDataText="No Data Found" OnRowCommand="GvRptDtls_RowCommand"  style="width: 100%;" >
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
                                                <asp:LinkButton ID="lblAppRegNo" runat="server" Text='<%# Eval("AppReg_No") %>' CommandName="View"
                                                    ForeColor="Blue" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Applicant Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplicantName" runat="server" Text='<%# Bind("ApplicantName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      <%--  <asp:TemplateField HeaderText="Mobile Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAppNo" runat="server" Text='<%# Bind("Mob_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Received On">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReceivedOn" runat="server" Text='<%# Bind("ReceivedOn") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Place of Event">
                                            <ItemTemplate>
                                                <asp:Label ID="lblplaceofEvent" runat="server" Text='<%# Bind("Name_Premises") %>'></asp:Label>
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
                                        <%--<asp:TemplateField HeaderText="License No">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblLicenseNo" runat="server" Text='<%# Bind("LicenseNo") %>'
                                                    CommandName="PerDown" ForeColor="Blue" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                       
                            </div>
                        <%--</div>
                    </div>--%>

                    <div class="container-fluid" runat="server" id="pannelOK" visible="false">

                        <div class="col-md-12">
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
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Name of Applicant:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                                                <asp:DropDownList Enabled="false" ID="DropDownList2" runat="server" CssClass="form-control input-b-b">
                                                    <asp:ListItem Text="Mr" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Miss" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Smt" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="txtAppliName" Enabled="false" MaxLength="150" runat="server" CssClass="form-control input-b-b">
                                                </asp:Label>
                                            </div>
                                        </div>
                                        <asp:Label ID="lblReg" Visible="false" runat="server" Text="Label"></asp:Label>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Aadhaar Number:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtAdharNum" Enabled="false" MaxLength="12" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Mobile Number:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtMobile" Enabled="false" MaxLength="10" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Email:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtEmail" Enabled="false" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Age:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtAge" Enabled="false" MaxLength="3" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Father's Name:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtFatherName" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Residential<br /> Address:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtAdd" Enabled="false" TextMode="MultiLine" MaxLength="200" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="HiddenField1" runat="server" />



                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>House No<br />/Door No:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtHsNum" Enabled="false" runat="server" MaxLength="10"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Name Of <br />the Premises:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtNmePrem" Enabled="false" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Street:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
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
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>East:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtEast" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>West:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtWest" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>North:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtNorth" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>South:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtSouth" Enabled="false" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Revenue District:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="Label6" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblRDist" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Mandal:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="lblbRMand" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Village/Locality:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="lblbRVill" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Excise District:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="lblExDistCode" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblExDist" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Excise Station:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblExStationCd" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblExStation" runat="server"></asp:Label>
                                                <asp:Label ID="lblGHMC" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                                                <b>Whether the <br />Permises<br />
                                                    is in Conformity with the<br />
                                                    Rule 7 of Telangana Excise<br />
                                                    (Grant
                                                                    of Licence <br />of Selling<br />
                                                    by In-House&amp;<br />Conditions of licence<br />
                                                    Rules 2005):</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="lblRule7" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Date And <br />Time of Event:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="ddlEvntTm" Enabled="false" runat="server"></asp:Label>
                                                <asp:Label ID="txtEvnDate" Enabled="false" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Type Of Event:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="Label5" Enabled="false" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Event On <br />Occasion Of:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtEvent" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                                <asp:Label ID="lbleventid" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblevent" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Licence Fee:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                                                <asp:Label ID="lblFee" Enabled="false" runat="server" Text=""></asp:Label>


                                            </div>
                                        </div>



                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Differential Fee:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="lblDFee" runat="server" Text="0.00"></asp:Label>
                                            </div>
                                        </div>



                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Premises Category:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="lbleventtypee" runat="server" Text="Label"></asp:Label>
                                            </div>
                                        </div>


                                        <%--  <div class="container-fluid">
                                                                <div class="col-md-12   text-left">
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                                                        Text="Payment Details">
                                                                    </asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-right">
                                                                    Payment Details:</label>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblPaymentDetails" runat="server"></asp:Label>
                                                                </div>
                                                            </div>--%>


                                        <div class="container-fluid">
                                            <div class="col-md-12   text-left">
                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                                    Text="Date and Remarks Entry For SHO">
                                                </asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Date of <br />the Inspection:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtDtInsp" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>SHO Remarks:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txtRemarks" MaxLength="250" runat="server" TextMode="MultiLine"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"><b>Differential <br />Amount:</b></label>
                                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                <asp:Label ID="txt_DAmount" MaxLength="150" runat="server"></asp:Label>
                                            </div>
                                        </div>

                                    </div>
                                </asp:Panel>
                                    
                            </div>
                        </div>


                        <div class="col-md-6">
                            <asp:Panel ID="Panel2" runat="server" BorderColor="#b2beb5" BorderStyle="Solid">
                                <div class="col-md-12 text-left">
                                    <asp:Label ID="lblPaymentDetailsL" runat="server" Font-Bold="True" Font-Size="18px"
                                        ForeColor="#0066CC" Text="Payment Details">
                                    </asp:Label>
                                </div>
                                <div class="card-block">
                                    <div class="form-group row ">
                                        <div class="col-md-12">

                                            <%--<asp:Label ID="lblPaymentDetailsT" runat="server"></asp:Label>--%>
                                            <asp:Repeater ID="dltPaymentDetails" runat="server" Visible="false">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblPaymentDetailsT" Text="<%#Eval("PaymentDetails")%>"></asp:Label><br />--%>
                                                    <p>
                                                        <%#Eval("PaymentDetails")%>
                                                    </p>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <asp:Label ID="lblPaymentDetailsNo" runat="server" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
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
                    <div class="col-md-12 text-right">
                        <asp:Button ID="imgbtnExcel" Text="Download Excel" Visible="false"
                            runat="server" OnClick="imgbtnExcel_Click1" />
                    </div>
                    <div class="row" id="PerGen" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="card">
                                            <asp:Panel ID="Panel1" runat="server" BorderColor="#b2beb5" BorderStyle="Solid" Visible="false">
                                                <asp:HiddenField ID="HiddenField3" runat="server" />
                                                <div class="card-block">
                                                    <div class="row" id="printableArea">
                                                        <div class="col-md-12">
                                                            <center>
                                                                                    <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="~/Excise-Logo.png"
                                                                                        Width="100px" />
                                                                                    <label style="font-size: large">
                                                                                        <b>TELANGANA STATE PROHIBITION &amp; EXCISE DEPARTMENT </b>
                                                                                    </label>
                                                                                </center>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <center>
                                                                                    <b>FORM EP-1<br />
                                                                                        [See Rule 4 (viii)]</b>
                                                                                </center>
                                                            <label class="col-sm-4 col-form-label text-left">
                                                                Licence No.
                                                                                    <asp:Label ID="lblPerLic" runat="server" Style="font-weight: 700"></asp:Label>
                                                            </label>
                                                            <%--&nbsp;<label class="col-sm-4 col-form-label text-right">Date<strong>
                                                                   <asp:Label ID="lblPerDt" runat="server" ></asp:Label></strong></Label>--%>
                                                            <p class="style3" style="text-decoration: underline">
                                                                <b>Event Permit for Retail Sale or Serve of all kinds of Indian Made Foreign Liquor
                                                                                        And Foreign Liquor to be consumed on the premises</b>
                                                            </p>
                                                            <p>
                                                                I,
                                                                                    <asp:Label ID="lblExDepoNm" runat="server" Text=""></asp:Label>, District prohibition
                                                                                    &amp; Excise officer of
                                                                                    <asp:Label ID="lblExd" runat="server" Text=""></asp:Label>
                                                                District in consideration of the payment of fee of Rs
                                                                                    <asp:Label ID="lblLicFee" runat="server" Text=""></asp:Label>
                                                                &nbsp; (Rupees
                                                                <asp:Label ID="lblLicFeeDesc" runat="server" Text=""></asp:Label>
                                                                only) receipt of which is hereby acknowledged, hereby
                                                                                    licence you to sell/serve all kinds of Indian Made Foreign Liquor and Foreign Liquor
                                                                                    as per the following details:
                                                            </p>
                                                            <center>
                                                                                    <table style="border: thin solid #000000">
                                                                                        <tr>
                                                                                            <td>
                                                                                                Applicant Name:
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblAppNAme" runat="server" Style="font-weight: 700; text-align: left"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                Date and Time:
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblDttime" runat="server" Style="font-weight: 700"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                Premises:
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblAddress" runat="server" Style="font-weight: 700"></asp:Label><asp:Label
                                                                                                    ID="lblRAddress" runat="server" Style="font-weight: 700"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                Occasion:
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblOccasion" runat="server" Style="font-weight: 700"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </center>
                                                            <center>
                                                                                    <b>Boundaries</b></center>
                                                            <center>
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td style="border: thin solid #000000">
                                                                                                East:
                                                                                            </td>
                                                                                            <td style="border: thin solid #000000">
                                                                                                <asp:Label ID="lblBEast" runat="server" Text="" CssClass="ui-priority-primary"></asp:Label>
                                                                                            </td>
                                                                                            <td style="border: thin solid #000000">
                                                                                                West:
                                                                                            </td>
                                                                                            <td style="border: thin solid #000000">
                                                                                                <asp:Label ID="lblBWest" runat="server" Text="" CssClass="ui-priority-primary"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="border: thin solid #000000">
                                                                                                North:
                                                                                            </td>
                                                                                            <td style="border: thin solid #000000">
                                                                                                <asp:Label ID="lblBNorth" runat="server" Text="" CssClass="ui-priority-primary"></asp:Label>
                                                                                            </td>
                                                                                            <td style="border: thin solid #000000">
                                                                                                South:
                                                                                            </td>
                                                                                            <td style="border: thin solid #000000">
                                                                                                <asp:Label ID="lblSouth" runat="server" Text="" CssClass="ui-priority-primary"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </center>
                                                            <p>
                                                                Subject to the following conditions and stipulations to be observed by you
                                                            </p>
                                                            <ol type="1">
                                                                <%--the said
                                                                        viz..,--%>
                                                                <li>The privilege extends to the sale or serve of all kinds of Indian Made Foreign Liquor
                                                                                        and Foreign Liquor at refreshment halls in connection with races/meetings and public
                                                                                        entertainments for consumption on the premises.</li>
                                                                <li>The licensee is prohibited from bottling the liquor.</li>
                                                                <li>The licensee is prohibited from purifying, colouring and flavouring the Indian Made
                                                                                        Foreign Liquor or mixing any materials therewith and from blending another kind
                                                                                        of Indian Made Foreign Liquor with it or keep in his possession other than Indian
                                                                                        Made Foreign Liquor authorised by this licence.</li>
                                                                <li>All Indian Made Foreign Liquor and Foreign Liquor sold/served under this licence
                                                                                        shall be obtained from the Telangana State Beverages Corporation Limited or A4 License.
                                                                                        <br />
                                                                </li>
                                                                <li>The licensee shall sell only duty paid Indian Made Foreign Liquor.</li>
                                                                <li>Any prohibition and excise officer not less than the rank of Prohibition & Excise
                                                                                        Sub-Inspector shall be empowered to check and verify the balance and receipts and
                                                                                        issue of the Indian Made Foreign Liquor.</li>
                                                                <li>The licence shall be subject to cancellation or suspension at will by the Commissioner
                                                                                        of Prohibition and Excise.</li>
                                                                <li>The licensee shall not act in any manner prejudicial to the interests of the revenues.</li>
                                                                <li>The licensee shall submit the particulars of IMFL and FL purchased, utilised and
                                                                                        balance to the District Prohibition and Excise Officer.</li>
                                                                <li>The Applicant Shall follow SOP of COVID-19.</li>
                                                            </ol>
                                                            <div class="row">
                                                                <%-- <div style="float: left; text-align: left; margin-left: auto;">
                                                                           
                                                                                Dated:
                                                                            
                                                                        </div>--%>
                                                                <label class="col-sm-4 col-form-label text-left">
                                                                    Dated:<strong>
                                                                        <asp:Label ID="lblPerDt" runat="server"></asp:Label></strong></label>
                                                            </div>
                                                            <div class="row">
                                                                <div style="float: right; text-align: right; margin-left: auto; margin-right: 20px;">
                                                                    <center>
                                                                                            District Prohibition &amp; Excise Officer</center>
                                                                    <center>
                                                                                            <asp:Label ID="lblDPEODistrict" runat="server"></asp:Label>
                                                                                            <%--Hyderabad--%></center>
                                                                </div>
                                                            </div>
                                                            <%-- <p>
                                                                        [Form EP-1 substituted by G.O. Ms. No. 597, Revenue (Ex.II) dated 26.05.2006]
                                                                        </p>--%>
                                                        </div>
                                                    </div>
                                                    <%--    <input type="button" onclick="printDiv('printableArea')" value="Download"  />--%>
                                                    <%-- <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-sm-4 col-form-label text-left">
                                                                            Registration Number</label>
                                                                        <div class="col-sm-6 col-form-label text-left">
                                                                            <asp:TextBox ID="txtRegistrationNo" MaxLength="10" CssClass="form-control " runat="server">
                                                                            </asp:TextBox>
                                                                            <ajax:FilteredTextBoxExtender ID="txtRegistrationNo_FilteredTextBoxExtender" runat="server"
                                                                                Enabled="True" FilterType="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                                                TargetControlID="txtRegistrationNo" ValidChars="-. ">
                                                                            </ajax:FilteredTextBoxExtender>
                                                                        </div>
                                                                    </div>
                                                                    
                                                                    <div class="form-group row">
                                                                        <label class="col-sm-4 col-form-label text-left">
                                                                            Mobile Number</label>
                                                                        <div class="col-sm-6 col-form-label text-left">
                                                                            <asp:TextBox ID="txtMobileNumber" MaxLength="10" CssClass="form-control " runat="server">
                                                                            </asp:TextBox>
                                                                            <ajax:FilteredTextBoxExtender ID="txtMobileNumber_FilteredTextBoxExtender" runat="server"
                                                                                Enabled="True" FilterType="Numbers" TargetControlID="txtMobileNumber" ValidChars="">
                                                                            </ajax:FilteredTextBoxExtender>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group row">
                                                                        <div class="col-sm-6 col-form-label text-left">
                                                                            <center>
                                                                                <asp:Button ID="btn_Save" CssClass=" btn btn-info btn-out-dotted bt" runat="server"
                                                                                    Text="Get Details"/> 
                                                                        </div>
                                                                        </center>
                                                                    </div>
                                                                </div>--%><%--OnClick="btn_Save_Click" --%>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>



