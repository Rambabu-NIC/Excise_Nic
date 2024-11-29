<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentDtls.aspx.cs" Inherits="ExciseAPI.NICAdmin.PaymentDtls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Event Permit Payment</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Name:</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Registration:</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:Label ID="lblRegNo" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">DDO Code:</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtDDOCode" CssClass="form-control input-b-b" value="21012304002" runat="server" AutoCompleteType="Disabled"
                            MaxLength="3" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Fee:</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:Label ID="lblFee" runat="server" Text="1.00"></asp:Label>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">HOA Code:</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtHOA" CssClass="form-control input-b-b" value="0039001050002000000NVN" runat="server" AutoCompleteType="Disabled"
                            MaxLength="2" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Save" runat="server" Text="Proceed to pay" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="btn_Save_Click" />
                    <asp:Button ID="btn_Update" runat="server" Text="Update" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="btn_Save_Click" Visible="false" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
