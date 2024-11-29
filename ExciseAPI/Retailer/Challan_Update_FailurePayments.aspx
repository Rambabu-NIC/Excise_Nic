<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Challan_Update_FailurePayments.aspx.cs" Inherits="ExciseAPI.Retailer.Challan_Update_FailurePayments" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Retailer Failure Payment update</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Payment Type</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                      <asp:DropDownList ID="ddlPaymenttype" runat="server" CssClass="form-control">
                          <asp:ListItem Value="2314">TSBCL Sales Proceeds Payments</asp:ListItem>
                          <asp:ListItem Value="2304">CPE Payments</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtFrom" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFrom" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtTo" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtTo" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>

            </div>
            <div class="content" align="center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Get" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server" Text="Get Details" OnClick="btn_Get_Click" />

                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    
        <div class="w-100 fl container-fluid" id="divretailer" runat="server" visible="false">
            <div class="block black bg-white">

                <div class="content">
                    <asp:GridView ID="gvRetailerdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv" Visible="false">
                        <%--OnRowDataBound="gvdetails_RowDataBound" OnRowCommand="gvdetails_RowCommand"--%>
                        <Columns>
                            <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Retailer_Code" HeaderText="Retailer_Code" />
                            <asp:BoundField DataField="NAME" HeaderText="Retailer Name" />
                            <asp:BoundField DataField="DeptTransid" HeaderText="Dept Transaction" />
                            <asp:BoundField DataField="deptID" HeaderText="deptID" Visible="false" />
                        </Columns>
                    </asp:GridView>


                </div>
            </div>
        </div>
    
    <div class="content" align="center">
        <div class="col-xs-12 col-sm-12 txt-cnt">
            <asp:Button ID="btnUpdate" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click" />

        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
