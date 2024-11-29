<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reset_Password.aspx.cs" Inherits="ExciseAPI.Supplier.Reset_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="section">
        <div class="row">
            <div class="col-lg-12">
                <div class="w-100 fl container-fluid">
    <div class="block black bg-white">                                                                              
            <div class="head">Reset Password</div>
            <div class="content">


                 <div class="row mb-2">
                                <label class="col-sm-2 col-form-label" style="color:red;"><b>Default Password is:1234</b></label>
                                
                                <label class="col-sm-2 col-form-label"><b>Supplier Code</b></label>
                                <div class="col-sm-4">
                                     <asp:TextBox ID="txtsupplier" CssClass="form-control input-b-b" runat="server" placeholder="Supplier Code" AutoCompleteType="Disabled"></asp:TextBox>
                                </div>
                            </div>

                 <div class="row mb-2">
                                
                                <div class="col-sm-12 text-center">
                                    <asp:Button ID="BtnGet" CssClass="btn btn-secondary" runat="server"
                                        Text="Get Data" OnClick="BtnGet_Click" />
                                    <asp:Label ID="lblSupplierererror" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                                    
                                </div>
                                <div class="col-sm-12 text-center" id="divreset" runat="server" visible="false" >
                                    
                                     <asp:Button ID="btnResetPassword" Text="Reset Password" CssClass="btn btn-secondary" runat="server"
                                         OnClick="btnResetPassword_Click" />
                                </div>
                            </div>
                
                <%--<div class="col-xs-12 col-sm-12 txt-cnt">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="" runat="server" Text="" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="" />
                    </div>
                    
                </div>
                 <div class="col-xs-12 col-sm-12 txt-cnt" id="divreset" runat="server" visible="false">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="" runat="server"  CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="" />
                    </div>
                    
                </div>--%>
                </div>
           </div>
                    </div>
                </div>
            </div>
         </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
