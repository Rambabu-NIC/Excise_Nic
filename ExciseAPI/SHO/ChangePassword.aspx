<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ExciseAPI.SHO.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <script type="text/javascript">
        function validateReg() {

            var newpwd = document.getElementById('<%= txtNpwd.ClientID %>').value
            var cpwd = document.getElementById('<%= txtCpwd.ClientID %>').value;
            if (newpwd != '' && cpwd != '') {

                document.getElementById('<%= txtNewPwdHash.ClientID %>').value = '';

                var myval2 = sha256(newpwd);
                document.getElementById('<%= txtNewPwdHash.ClientID %>').value = myval2;
                return true;
            }
            else {
                alert("Please Enter New Password and Confirm Password");
                return false;
            }


        }
        function validateCustomReg(oSrc, args) {
            var psw = document.getElementById('txtNpwd').value;
            var encpsw = document.getElementById('txtNewPwdHash').value;
            if (psw == '') {
                args.IsValid = false;
            }
            else {
                if (encpsw == '') {
                    var pattern = new RegExp("^.*(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&amp;+=]).*$");
                    args.IsValid = pattern.test(psw);
                }
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Change Password</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">New Password</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtNpwd" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="Password must be at least 8 characters long and include a combination of uppercase and lowercase letters, numbers, and special characters."
                                ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" ControlToValidate="txtNpwd" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:HiddenField ID="txtNewPwdHash" runat="server" />
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Confirm Password</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtCpwd" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                            ControlToValidate="txtCpwd"
                            CssClass="ValidationError"
                            ControlToCompare="txtNpwd"
                            ErrorMessage="New and Confirm Password must be matched"
                            ToolTip="Password must be the same" ForeColor="Red" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Password must be at least 8 characters long and include a combination of uppercase and lowercase letters, numbers, and special characters."
                            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" ControlToValidate="txtCpwd" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="content text-center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="btn_Submit_Click"
                        OnClientClick="return validateReg();" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
