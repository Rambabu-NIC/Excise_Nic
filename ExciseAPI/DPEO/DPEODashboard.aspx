<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DPEODashboard.aspx.cs" Inherits="ExciseAPI.DPEO.DPEODashboard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Dashboard</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtfrm" CssClass="form-control input-b-b" runat="server" placeholder="From Date" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtfrm" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtto" CssClass="form-control input-b-b" runat="server" placeholder="From Date" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtto" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnGet" runat="server" Text="Get Details" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="btnGet_Click" />
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid">
        <div class="content">
            <div class="row">
                <div class="col-md-12">
                    <div id="Div1" class="table-responsive dt-responsive" runat="server" visible="false">
                        <asp:GridView ID="GvRpt" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                            <Columns>
                                <asp:TemplateField HeaderText="Received">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkApplicationRecieved" runat="server" Text='<%# Bind("AppRecieved") %>'
                                            OnClick="lnkApplicationRecieved_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pending at SHO">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkPendingSHO" runat="server" Text='<%# Bind("PendingSHO") %>'
                                            OnClick="lnkPendingSHO_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="For Approval">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkPendingDPEO" runat="server" Text='<%# Bind("PendingDPEO") %>'
                                            OnClick="lnkPendingDPEO_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Permits issued">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkApplicationApproved" runat="server" Text='<%# Bind("Approved") %>'
                                            OnClick="lnkApplicationApproved_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rejected">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkApplicationRejected" runat="server" Text='<%# Bind("Rejected") %>'
                                            OnClick="lnkApplicationRejected_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div id="Div3" class="table-responsive dt-responsive" runat="server">
                        <asp:Label ID="appType" runat="server" Visible="false"></asp:Label>
                        <asp:GridView ID="GvRptDtls" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                            AllowPaging="True" PageSize="10" OnPageIndexChanging="GvRptDtls_PageIndexChanging"
                            EmptyDataText="No Data Found">
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reg.NO">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAppRegNo" runat="server" Text='<%# Bind("AppReg_No") %>'></asp:Label>
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
        </div>
    </div>
</asp:Content>
