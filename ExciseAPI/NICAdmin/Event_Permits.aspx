<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Event_Permits.aspx.cs" Inherits="ExciseAPI.NICAdmin.Event_Permits" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Event Permits</div>
            <div class="content">
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtFrom" CssClass="form-control input-b-b" runat="server" placeholder="From Date" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFrom" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                        <%--<asp:Label ID="lblFromDate" runat="server"></asp:Label>--%>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtTo" CssClass="form-control input-b-b" runat="server" placeholder="To Date" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtTo" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                        <%--<asp:Label ID="lblToDate" runat="server"></asp:Label>--%>
                    </div>
                </div>
                <%--<div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">--%>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="BtnSubmit" runat="server" Text="Submit" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="BtnSubmit_Click" />
                </div>
                <%--</div>--%>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
                </div>
            </div>
        
                 <div class="block black bg-white">
                <asp:GridView ID="GvPermits" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
                    CssClass="datatable" OnPageIndexChanging="GvPermits_PageIndexChanging"> <%--
                    OnRowCommand="GvPermits_RowCommand"--%>
                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Applications Received">
                            <ItemTemplate>
                                <asp:Label ID="lblApplicationsReceived" runat="server" Font-Bold="true" Text='<%# Bind("AppRecieved") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Events Generated">
                            <ItemTemplate>
                                <asp:Label ID="lblEventsGenerated" runat="server" Font-Bold="true" Text='<%# Bind("EventsGenerated") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Payment Done">
                            <ItemTemplate>
                                <asp:Label ID="lblPayment" runat="server" Font-Bold="true" Text='<%# Bind("PaymentMade") %>'></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDetailedView" runat="server" ForeColor="Green" Text="Click..!"
                                    OnClick="lnkDetailedView_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
       
</div>
   <%-- <div class="w-100 fl container-fluid" >--%>
        <div class="block-liner block bg-white" id="Div3" runat="server" visible="false">
             <div class="head">Event Permits Detailed View</div>
            <asp:GridView ID="GvDetailedView" runat="server" AutoGenerateColumns="False" CssClass="datatable" OnPageIndexChanging="GvDetailedView_PageIndexChanging"
                AllowPaging="True" PageSize="10" 
                EmptyDataText="No Data Found" > <%--OnRowCommand="GvDetailedView_RowCommand" OnPageIndexChanging="GvDetailedView_PageIndexChanging">--%>
                <%--OnRowCommand="GvRptDtls_RowCommand"--%>
                <Columns>
                    <asp:TemplateField HeaderText="SNo">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="AppReg.NO">
                        <ItemTemplate>
                            <%-- <asp:Label ID="lblTypecode" runat="server" Text='<%# Bind("AppReg_NO") %>' Visible="false"></asp:Label>--%>
                            <asp:LinkButton ID="lblAppRegNo" runat="server" Text='<%# Eval("AppReg_No") %>' CommandArgument='<%# Eval("AppReg_No") %>' CommandName="View"
                                CausesValidation="false"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Applicant Name">
                        <ItemTemplate>
                            <asp:Label ID="lblApplicantName" runat="server" Text='<%# Bind("App_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="Date of Event">
                        <ItemTemplate>
                            <asp:Label ID="lblDateofEvent" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
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
    <%--</div>--%>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
