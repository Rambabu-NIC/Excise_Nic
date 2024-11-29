<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Signature.aspx.cs" Inherits="ExciseAPI.Signature" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Signature</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-12 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Signature Upload</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                         <asp:FileUpload ID="FileUpload_docs" runat="server" CssClass="form-control input-b-b" />
                    </div>
                </div>
               
            </div>
            <div class="content text-center" >
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                        Text="Save" OnClick="btn_Save_Click" />
                  </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
