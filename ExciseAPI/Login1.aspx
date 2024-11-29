<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster1.Master" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="ExciseAPI.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validateReg() {
            var pwd = document.getElementById('<%= txtPwd.ClientID %>').value;
            //debugger;
            if (pwd != "") {
                var keyGenrate = '<%=ViewState["KeyGenerator"]%>';
                var myval = sha256(keyGenrate);
               //document.getElementById('<%= txtPwd.ClientID %>').value = '';
                var myval1 = sha256(document.getElementById('<%= txtPwd.ClientID %>').value.toString());
                document.getElementById('<%= txtPwd.ClientID %>').value = '******';
                document.getElementById('<%= txtPwdHash.ClientID %>').value = sha256(myval1 + myval);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="col-md-12 p-sm-5">
            <div class="row justify-content-center">
                <div class="col-lg-6 col-md-8 d-flex flex-column align-items-center justify-content-center">

                    <div class="card mt-2">

                        <div class="card-body mt-2">
                            <div class="col-md-12">
                                <div class="pt-4 pb-2">
                                    <h5 class="card-title text-center pb-0 fs-4">Login</h5>
                                    <p class="text-center small"><b>Enter your username & password to login</b></p>
                                </div>
                                <div class="form-group">
                                    <label for="name" class="form-label">Username</label>

                                    <asp:TextBox ID="txtUname" CssClass="form-control" runat="server"></asp:TextBox>
                                    <div class="invalid-feedback">Please enter your username.</div>
                                </div>


                                <div class="form-group">
                                    <label for="yourPassword" class="form-label">Password</label>
                                    <asp:TextBox ID="txtPwd" CssClass="form-control" runat="server"  TextMode="Password"></asp:TextBox>
                                    <asp:HiddenField ID="txtPwdHash" runat="server" />
                                    <asp:HiddenField ID="hf" runat="server" />
                                    <span class="form-bar"></span>
                                    <div class="invalid-feedback">Please enter your password!</div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-outline form-white mb-4">

                                    <asp:Image ID="Image2" runat="server" />
                                    <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/Assets/images/RecaptchaLogo.png"
                                        OnClick="btnImgRefresh_Click" CausesValidation="False" />
                                    <span class="form-bar"></span>
                                </div>
                                <br />
                                <div class="form-outline form-white mb-4">
                                    <asp:TextBox ID="captch" runat="server" class="form-control" placeholder="Enter Captcha" AutoCompleteType="Disabled" MaxLength="6"></asp:TextBox>   
                                    <span class="form-bar"></span>
                                </div>
                            </div>

                            <div class="col-12" align="center">
                                <asp:Button ID="btnLogin" Text="Login" runat="server" Class="btn btn-info m-2"  OnClientClick="return validateReg();" OnClick="btnLogin_Click" />
                                <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="col-12">
                                <p class="small mb-0"><b>Don't have Login?</b> <a href="ApplicantRegistration.aspx">Register</a></p>
                            </div>
                        </div>


                    </div>
                </div>


            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
