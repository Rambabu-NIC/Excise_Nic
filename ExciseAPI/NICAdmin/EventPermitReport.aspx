<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventPermitReport.aspx.cs" Inherits="ExciseAPI.NICAdmin.EventPermitReport" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Event Permit Report</div>
            <div class="content">

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtfrm" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtfrm" Format="yyyy-MM-dd"></cc1:CalendarExtender>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date (yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtto" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtto" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnGet" runat="server" Text="Get Data" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="btnGet_Click" />

                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center"></asp:Label>
                </div>
                <div class="w-100 fl container-fluid" id="Div2" runat="server" visible="false">
                    <div class="block black bg-white">

                        <asp:GridView ID="GvRpt" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                            <Columns>

                                <asp:TemplateField HeaderText="Registered">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkApplicationsFilled" runat="server" Text='<%# Bind("AppFilled") %>'
                                            OnClick="lnkApplicationsFilled_Click"></asp:LinkButton>
                                        <%----%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Permit Fee Paid">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFeePaid" runat="server" Font-Bold="true" Text='<%# Bind("PaymentAmount") %>'></asp:Label>(
                                        <asp:LinkButton ID="lnkApplicationsPaymentMade" runat="server" Text='<%# Bind("PaymentMade") %>'
                                            OnClick="lnkApplicationsPaymentMade_Click"></asp:LinkButton>)<%----%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submitted">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblApplicationRecieved" runat="server" Text='<%# Bind("AppRecieved") %>'></asp:Label>--%>
                                        <asp:LinkButton ID="lnkApplicationRecieved" runat="server" Text='<%# Bind("AppRecieved") %>'
                                            OnClick="lnkApplicationRecieved_Click"></asp:LinkButton><%----%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Process at SHO">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblPendingSHO" runat="server" Text='<%# Bind("PendingSHO") %>'></asp:Label>--%>
                                        <asp:LinkButton ID="lnkPendingSHO" runat="server" Text='<%# Bind("PendingSHO") %>'
                                            OnClick="lnkPendingSHO_Click"></asp:LinkButton>
                                        <%----%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Differential Amount">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblPendingSHO" runat="server" Text='<%# Bind("PendingSHO") %>'></asp:Label>--%>
                                        <asp:LinkButton ID="lnkReturnSHO" runat="server" Text='<%# Bind("DifferentialAmount") %>'
                                            OnClick="lnkReturnSHO_Click"></asp:LinkButton><%----%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Process at DPEO">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblPendingDPEO" runat="server" Text='<%# Bind("PendingDPEO") %>'></asp:Label>--%>
                                        <asp:LinkButton ID="lnkPendingDPEO" runat="server" Text='<%# Bind("PendingDPEO") %>'
                                            OnClick="lnkPendingDPEO_Click"></asp:LinkButton><%----%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Permits issued">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblApplicationApproved" runat="server" Text='<%# Bind("Approved") %>'></asp:Label>--%>
                                        <asp:LinkButton ID="lnkApplicationApproved" runat="server" Text='<%# Bind("Approved") %>'
                                            OnClick="lnkApplicationApproved_Click"></asp:LinkButton><%----%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rejected">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblApplicationRejected" runat="server" Text='<%# Bind("Rejected") %>'></asp:Label>--%>
                                        <asp:LinkButton ID="lnkApplicationRejected" runat="server" Text='<%# Bind("Rejected") %>'
                                            OnClick="lnkApplicationRejected_Click"></asp:LinkButton><%----%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>


                    </div>
                </div>

                <div class="w-100 fl container-fluid" id="Div3" runat="server" visible="false">
                    <div class="block black bg-white">

                        <div id="divgridwithdate1" runat="server" visible="true">
                            <div runat="server" id="DivGeneratedDate" visible="false">
                                <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">
                                    <div class="w-100 fl m-b-2">
                                        <div class="fr">
                                            <%-- <a href="#">
                                        <asp:ImageButton runat="server" ID="btnEventImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnEventImageExportToPdf_Click"
                                            Visible="false" />
                                    </a>&nbsp;&nbsp;--%>
                                            <a href="#">
                                                <asp:ImageButton runat="server" ID="btnEventImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnEventImageExportToExcel_Click"
                                                    Visible="false" />
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--   <asp:UpdatePanel ID="UpdatePartialRenderToGrid" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>--%>
                            <div class="w-100 fl container-fluid" id="divgriddetails" runat="server" visible="true">
                                <div class="block-liner block black bg-white">
                                    <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                                        <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                                        <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Event Permits Report 
                                   
                                 <br />
                                            Between :
                                            <asp:Label ID="lblFromDate" runat="server"></asp:Label>
                                            AND
                                            <asp:Label ID="lblToDate" runat="server"></asp:Label>
                                        </h2>

                                    </div>

                                    <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
                                    <asp:GridView ID="GvRptDtls" runat="server" AutoGenerateColumns="False" CssClass="datatable"
                                        AllowPaging="True" PageSize="20" OnPageIndexChanging="GvRptDtls_PageIndexChanging"
                                        EmptyDataText="No Data Found">
                                        <%--OnRowCommand="GvRptDtls_RowCommand"--%>
                                        <Columns>
                                            <asp:TemplateField HeaderText="SNo">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reg.NO">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAppRegNo" runat="server" Text='<%# Bind("AppReg_NO") %>'></asp:Label>
                                                    <%--<asp:LinkButton ID="lblAppRegNo" runat="server" Text='<%# Eval("AppReg_No") %>' CommandArgument='<%# Eval("AppReg_No") %>' CommandName="View"
                                        ForeColor="Blue" CausesValidation="false"></asp:LinkButton>--%>
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
                                            <%-- <asp:TemplateField HeaderText="Registered Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblReceivedOn" runat="server" Text='<%# Bind("ReceivedOn") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Res_Address") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date of Event">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDateofEvent" runat="server" Text='<%# Bind("DateofEvent") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Event Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEventDes" runat="server" Text='<%# Bind("Event_Occasion") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fee">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("StatusDes") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>

                            <asp:HiddenField ID="hfDate" runat="server" Visible="false" />
                            <asp:Label ID="dateGrid" runat="server" Visible="false" />
                            <asp:Label ID="gridData" runat="server" Visible="false" />

                            <asp:Label ID="appType" runat="server" Visible="false"></asp:Label>








                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
