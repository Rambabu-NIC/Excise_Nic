<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.master" CodeBehind="RetailerSpecialPayments.aspx.cs" Inherits="ExciseAPI.Retailer.RetailerSpecialPayments" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Retailer Payment</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtRetailercode" CssClass="form-control input-b-b" runat="server" placeholder="Retailer code" Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtRetailerName" CssClass="form-control input-b-b" runat="server"
                            placeholder="Retailer Name" Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtMobile" CssClass="form-control input-b-b" runat="server" placeholder="Mobile Number"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Licensee No</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:HiddenField ID="hf" runat="server" />
                        <asp:TextBox ID="txtLicNo" CssClass="form-control input-b-b" runat="server" placeholder="Licensee Number"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">DDO Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtDDOCode" CssClass="form-control input-b-b" runat="server" placeholder="DDO Code"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Total Excise Tax</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txt_Extax" CssClass="form-control input-b-b" runat="server" placeholder="Total Excise Tax"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type of Retailer</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txt_retailer" CssClass="form-control input-b-b" runat="server" placeholder="Type of Retailer"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type of Payment</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlSubH" runat="server" CssClass="form-control " AutoPostBack="True"
                            OnSelectedIndexChanged="ddlSubH_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">HOA Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtHOA" CssClass="form-control input-b-b" runat="server" placeholder="HOA Code"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>    
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Amount</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtAmt" CssClass="form-control input-b-b" runat="server" Enabled="false" placeholder="Amount"></asp:TextBox>
                         
                    </div>
                </div>
            </div>
            <div class="content text-center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                        Text="Proceed to pay" Enabled="false" OnClick="btn_Save_Click"  />
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
