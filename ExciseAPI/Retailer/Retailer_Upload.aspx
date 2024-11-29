<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site1.master" CodeBehind="Retailer_Upload.aspx.cs" Inherits="ExciseAPI.Retailer.Retailer_Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Retailer Upload</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">File Upload</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:FileUpload ID="FileUpload" runat="server" class="form-control input-b-b" />
                        
                    </div>
                </div>

                
                <div class="content text-center">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="BtnSubmit" runat="server" Text="Submit" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="BtnSubmit_Click" />
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center"></asp:Label>
                </div>
                    </div>
            </div>
        </div>
    </div>
   
</asp:Content>

