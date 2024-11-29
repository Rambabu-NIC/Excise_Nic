<%@ Page Language="C#" MasterPageFile="~/LoginMaster1.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="ExciseAPI.Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="vh-100">
        <div class="container py-5 h-100 justify-content: center;  align-items: center; divlogin">
            <div class="d-flex justify-content-center align-items-center h-100">
                <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                    <div class="card " style="border-radius: 1rem;">
                        <div class="card-body p-5 text-center">

                            <div class="mb-md-5 mt-md-4 pb-5">

                                <h2 class="fw-bold mb-2 text-uppercase" style="color:red;">LogOut</h2>
                                <div class="col-md-12 h6">
                                    Click Here to <a href="Login.aspx" class="h4" style="color:forestgreen;font-weight:bold;">&nbsp;  Login</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


