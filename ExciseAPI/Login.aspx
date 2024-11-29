<%@ Page Language="C#" MasterPageFile="~/LoginMaster1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExciseAPI.Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .gradient-custom {
            /* fallback for old browsers */
            background: #6a11cb;
            /* Chrome 10-25, Safari 5.1-6 */
            background: -webkit-linear-gradient(to right, rgba(106, 17, 203, 1), rgba(37, 117, 252, 1));
            /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
            background: linear-gradient(to right, rgba(106, 17, 203, 1), rgba(37, 117, 252, 1))
        }

        .divlogin {
            padding-left: 10% !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function validateReg() {
            var pwd = document.getElementById('<%= txtPwd.ClientID %>').value;
            debugger;

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
    <section class="vh-100 d-flex justify-content-center align-items-center; divlogin">
        <div class="row col-md-12">
            <div class="col-md-10">
                <div class="container py-5">
                    <div class="row justify-content-center">
                        <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                            <div class="card" style="border-radius: 1rem;">
                                <div class="card-body p-5 text-center">

                                    <div class="mb-md-5 mt-md-4 pb-5">
                                        <h2 class="fw-bold mb-2 text-uppercase">Login</h2>

                                        <div class="form-outline form-white mb-4">
                                           <%-- <asp:TextBox ID="txtUname" class="form-control" runat="server" name="username" placeholder="Username"
                                                required="true" autofocus="true"></asp:TextBox>--%>
                                             <asp:TextBox ID="txtUname" CssClass="form-control input-b-b" runat="server" placeholder="UserName"></asp:TextBox>
                                            <span class="form-bar"></span>
                                        </div>
                                        <br />
                                        <div class="form-outline form-white mb-4">
                                            <%--<asp:TextBox ID="txtPwd" CssClass="form-control input-b-b" runat="server" placeholder="Password"></asp:TextBox>--%>
                                            <asp:TextBox ID="txtPwd" TextMode="Password" runat="server" class="form-control"
                                                placeholder="Password"></asp:TextBox>
                                            <asp:HiddenField ID="txtPwdHash" runat="server" />
                                            <asp:HiddenField ID="hf" runat="server" />
                                            <span class="form-bar"></span>
                                        </div>
                                        <br />
                                        <div class="form-outline form-white mb-4">

                                            <asp:Image ID="Image2" runat="server" />
                                            <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/Assets/images/RecaptchaLogo.png"
                                                OnClick="btnImgRefresh_Click" CausesValidation="False" />
                                            <span class="form-bar"></span>
                                        </div>
                                        <br />
                                        <div class="form-outline form-white mb-4">
                                            <asp:TextBox ID="captch" runat="server" class="form-control" placeholder="Enter Captcha" AutoCompleteType="Disabled" MaxLength="6"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="captch_FilteredTextBoxExtender1" runat="server"
                                                BehaviorID="captch_FilteredTextBoxExtender" FilterType="numbers"
                                                TargetControlID="captch"></ajaxToolkit:FilteredTextBoxExtender>
                                            <span class="form-bar"></span>
                                        </div>
                                        <br />
                                        <asp:Button ID="Button1" runat="server" Text=" Sign in" OnClientClick="return validateReg();"
                                            OnClick="btnLogin_Click" class="btn btn-secondary btnn btn-sm text-uppercase m-t-10"></asp:Button>
                                    </div>
                                    <div class="content" align="center">

                                        <div class="col-xs-12 col-sm-12 txt-cnt">
                                            <asp:Label ID="lblmsg" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
    </section>
    <%--<section class="vh-100">
        <div class="container py-5 h-100 justify-content: center;  align-items: center; divlogin" >
            <div class="d-flex justify-content-center align-items-center h-100">
                <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                    <div class="card " style="border-radius: 1rem;">
                        <div class="card-body p-5 text-center">

                            <div class="mb-md-5 mt-md-4 pb-5">

                                <h2 class="fw-bold mb-2 text-uppercase">Login</h2>

                                <div class="form-outline form-white mb-4">
                                    <asp:TextBox ID="txtUname" class="form-control" runat="server" name="username" placeholder="Username"
                                        required="true" autofocus="true"></asp:TextBox>
                                    <span class="form-bar"></span>
                                </div>
                                <br />
                                <div class="form-outline form-white mb-4">
                                    <asp:TextBox ID="txtPwd" TextMode="Password" runat="server" class="form-control"
                                        placeholder="Password" required="true"></asp:TextBox>
                                    <asp:HiddenField ID="txtPwdHash" runat="server" />
                                    <asp:HiddenField ID="hf" runat="server" />
                                    <span class="form-bar"></span>
                                </div>
                                <br />
                                <div class="form-outline form-white mb-4">
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    <asp:Image ID="Image2" runat="server" />
                                    <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/Assets/images/RecaptchaLogo.png"
                                        OnClick="btnImgRefresh_Click" CausesValidation="False" />
                                    <span class="form-bar"></span>
                                </div>
                                <br />
                                <div class="form-outline form-white mb-4">
                                    <asp:TextBox ID="captch" runat="server" class="form-control" placeholder="Enter Captcha" AutoCompleteType="Disabled"></asp:TextBox>
                                    <span class="form-bar"></span>
                                </div>

                                <asp:Button ID="Button1" runat="server" Text=" Sign in" OnClientClick="return validateReg();"
                                    OnClick="btnLogin_Click" class="btn btnn btn-sm text-uppercase m-t-10"></asp:Button>


                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>--%>
</asp:Content>


