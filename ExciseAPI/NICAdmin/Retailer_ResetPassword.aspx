<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Retailer_ResetPassword.aspx.cs" Inherits="ExciseAPI.NICAdmin.Retailer_ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="w-100 fl container-fluid">
       <div class="block black bg-white">                                                                              
            <div class="head">Password Reset For Retailers</div>
            <div class="content">
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                      <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                    <span style="color: Red">Default Password is:Excise@1234</span>
                </label>
                     </div>
                  <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                       <asp:TextBox ID="txtretailer" CssClass="form-control input-b-b" runat="server" placeholder="Retailer Code" AutoCompleteType="Disabled"></asp:TextBox>

                    </div>
                </div>
                 </div>
                <div class="content text-center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="BtnGet" runat="server" Text="Get Data" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="BtnGet_Click" />
                    </div>
                    <asp:Label ID="lblRetailererror" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
               
                
                     </div>
            <div class="content text-center">
            <div class="col-xs-12 col-sm-12 txt-cnt" id="divreset" runat="server" visible="false">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="btnResetPassword_Click" />
                    </div>
                    
                </div>
                </div>
               
           </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
