<%@ Page Language="C#" MasterPageFile="~/LoginMaster1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ExciseAPI.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <asp:HiddenField ID="hf" runat="server" />
            <div class="head">Error</div>
            <div class="content">
                <div class="error-container">
                    <h1>404</h1>
                    <h2>Internal Error Occured.</h2>
                    <div class="error-details">
                        Sorry, an error has occured! Why not try going back to the <a href="Login.aspx">home
                                page</a> or perhaps try following!
                    </div>
                    <div class="error-actions">
                        <a href="Login.aspx" class="btn btn-large btn-primary"><i class="icon-chevron-left"></i>&nbsp; Back to Login Page </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<div class="content">
        <div class="container-fluid">
            <div class="card">
                <div class="card-body">

                    <div class="row offset-4">
                        <div class="error-container">
                            <h1>404</h1>
                            <h2>Internal Error Occured.</h2>
                            <div class="error-details">
                                Sorry, an error has occured! Why not try going back to the <a href="Login.aspx">home
                                page</a> or perhaps try following!
                            </div>
                            <div class="error-actions">
                                <a href="Login.aspx" class="btn btn-large btn-primary"><i class="icon-chevron-left"></i>&nbsp; Back to Login Page </a>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>--%>
</asp:Content>


