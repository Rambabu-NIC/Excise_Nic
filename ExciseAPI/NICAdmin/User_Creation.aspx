<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="User_Creation.aspx.cs" Inherits="ExciseAPI.NICAdmin.User_Creation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">User Creation</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Role Type</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlRoleType" runat="server" class="form-control input-b-b" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlRoleType_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">Admin</asp:ListItem>
                            <asp:ListItem Value="9">NicAdmin</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:Label ID="Label1" runat="server" Text="Default Password App$123" Font-Bold="True"
                            Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
                    </div>
                </div>
            </div>



            <div class="w-100 fl container-fluid" id="nform" runat="server" visible="false">

                <div class="block black bg-white">
                    <div class="content">
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">User Name</label>
                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                                <asp:TextBox ID="txtUserName" CssClass="form-control input-b-b" runat="server" MaxLength="10" AutoCompleteType="Disabled"></asp:TextBox>


                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile No</label>
                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                                <asp:TextBox ID="txtMobileNo" CssClass="form-control input-b-b" runat="server" MaxLength="10" AutoCompleteType="Disabled"></asp:TextBox>


                            </div>
                        </div>

                       

                    </div>
                     <div class="content text-center">
                     <div class="col-xs-12 col-sm-12 txt-cnt">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="btnUpdate_Click" />
                        </div>
                         </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
