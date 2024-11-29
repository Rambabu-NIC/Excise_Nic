<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PaymentGDtls.aspx.cs" Inherits="ExciseAPI.Supplier.PaymentGDtls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Payment</div>
            <div class="content">
                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card">
                                <div class="card-block">
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-2 col-form-label text-right" style="font-size: medium; font-weight: bold">
                                            Supplier Code
                                        </label>
                                        <div class="col-md-2">
                                            <asp:Label ID="lblTypeofmanyf" runat="server" Font-Bold="True" Font-Size="Medium">161708</asp:Label>
                                            <asp:Label ID="lblmfcd" runat="server" Text="Label" Visible="False"></asp:Label>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right" style="font-size: medium; font-weight: bold">
                                            Supplier Name
                                        </label>
                                        <div class="col-md-2">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium">Sowjanya</asp:Label>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right" style="font-size: medium; font-weight: bold">
                                            Mobile Number
                                        </label>
                                        <div class="col-md-2">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium">9059275647</asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <asp:HiddenField ID="hf" runat="server" />
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-5 col-form-label text-right">
                                            Type of payment</label>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ddlTypeofpayment" runat="server" CssClass="form-control " AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlTypeofpayment_SelectedIndexChanged">
                                                <asp:ListItem>Select</asp:ListItem>
                                                <asp:ListItem>SBI</asp:ListItem>
                                                <asp:ListItem>SBH</asp:ListItem>
                                                <asp:ListItem>Canara</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-5 col-form-label text-right">
                                                User ID</label>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-5 col-form-label text-right">
                                                Password</label>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <div class="form-group row col-md-12">
                                    </div>
                                    <div class="form-group row col-md-10 offset-5">
                                        <asp:Button ID="btn_Save" CssClass=" btn btn-info btn-out-dotted bt" runat="server"
                                            Text="Pay" OnClick="btn_Save_Click" />
                                        <asp:Button ID="btn_Update" CssClass=" btn btn-warning btn-out-dotted" runat="server"
                                            Text="Update" Visible="false" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
