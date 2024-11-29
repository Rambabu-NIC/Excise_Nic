<%@ Page Title="" Language="C#" MasterPageFile="~/EOB.Master" AutoEventWireup="true" CodeBehind="ApplicantRegistration.aspx.cs" Inherits="ExciseAPI.ApplicantRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validateReg() {

            var newpwd = document.getElementById('<%= txtPassword.ClientID %>').value
            var cpwd = document.getElementById('<%= txtconfirmpassword.ClientID %>').value;
            if (newpwd != '' && cpwd != '') {

                document.getElementById('<%= txtNewPwdHash.ClientID %>').value = '';

                var myval2 = sha256(newpwd);
                document.getElementById('<%= txtNewPwdHash.ClientID %>').value = myval2;


                document.getElementById('ContentPlaceHolder1_txtPassword').value = myval2;
                document.getElementById('ContentPlaceHolder1_txtconfirmpassword').value = myval2;

                return true;
            }
            else {
                alert("Please Enter New Password and Confirm Password");
                return false;
            }


        }
        function validateCustomReg(oSrc, args) {
            var psw = document.getElementById('txtPassword').value;
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
    <section class="section">
        <div class="row justify-content-center" runat="server" id="divfirstpanel" visible="true">
            <div class="col-lg-6 col-md-8 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title text-center">Registration Form</h5>
                        <br />
                        <div class="wrapper ">
                            <div class="col-md-12">
                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group">
                                        <label for="name">Applicant Name:</label>

                                        <asp:TextBox ID="txtApplicantName" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtApplicantName" ErrorMessage="This field can not be blank." ValidationGroup="AR_Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ControlToValidate="txtApplicantName" ErrorMessage="This field can not be blank." ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    </div>


                                    <div class="col-md-6 form-group">
                                        <label for="name">Mobile No:</label>

                                        <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server" OnTextChanged="txtMobileNo_TextChanged" AutoPostBack="true" MaxLength="10"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgxMobileNumber" runat="server" ControlToValidate="txtMobileNo"
                                            ValidationExpression="(0|91)?[6-9][0-9]{9}" ErrorMessage="Invalid Mobile Number." ForeColor="Red">
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="This field can not be blank." ValidationGroup="AR_Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group">
                                        <label for="name">Pan No:</label>

                                        <asp:TextBox ID="txtPanNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ControlToValidate="txtPanNo" ErrorMessage="Invalid PAN Number"
                                            ValidationExpression="([A-Z]){5}([0-9]){4}([A-Z]){1}$" runat="server" ForeColor="Red">
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPanNo" ErrorMessage="This field can not be blank." ValidationGroup="AR_Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="name">Aadhar No:</label>

                                        <asp:TextBox ID="txtAadhar" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgxAadhaar" runat="server" ControlToValidate="txtAadhar"
                                            ValidationExpression="[0-9]{12}"
                                            ErrorMessage="Invalid Aadhaar Number" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAadhar" ErrorMessage="This field can not be blank." ValidationGroup="AR_Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group">
                                        <label for="name">Gst No:</label>

                                        <asp:TextBox ID="txtGstNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtGstNo" ErrorMessage="This field can not be blank." ValidationGroup="AR_Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="name">Email:</label>

                                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                            ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                            Display="Dynamic" ErrorMessage="Invalid email address" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                                            ForeColor="Red" Display="Dynamic" ErrorMessage="Required" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail" ErrorMessage="This field can not be blank." ValidationGroup="AR_Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group">
                                        <label for="name">District:</label>

                                        <asp:DropDownList ID="ddlDistrict" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="name">Mandal:</label>

                                        <asp:DropDownList ID="ddlMandal" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group">
                                        <label for="name">Village:</label>

                                        <asp:DropDownList ID="ddlVillage" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>
                                    </div>

                                    <div class="col-md-6 form-group">
                                        <label for="name">House No:</label>

                                        <asp:TextBox ID="txtHouseNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtHouseNo" ErrorMessage="This field can not be blank." ValidationGroup="AR_Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group">
                                        <label for="name">Street Road:</label>

                                        <asp:TextBox ID="txtStreet" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtApplicantName" ErrorMessage="This field can not be blank." ValidationGroup="AR_Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-md-6 form-group">
                                        <label for="name">UserName:</label>

                                        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtStreet" ErrorMessage="This field can not be blank." ValidationGroup="AR_Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-12 row">
                                    <div class="col-md-6 form-group">
                                        <label for="name">Password:</label>

                                        <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="Password must be at least 8 characters long and include a combination of uppercase and lowercase letters, numbers, and special characters."
                                            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" ControlToValidate="txtPassword" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:HiddenField ID="txtNewPwdHash" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPassword" ErrorMessage="This field can not be blank." ValidationGroup="AR_Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-md-6 form-group">
                                        <label for="name">Confirm Password:</label>

                                        <asp:TextBox ID="txtconfirmpassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                                            ControlToValidate="txtPassword"
                                            CssClass="ValidationError"
                                            ControlToCompare="txtconfirmpassword"
                                            ErrorMessage="New and Confirm Password must be matched"
                                            ToolTip="Password must be the same" ForeColor="Red" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Password must be at least 8 characters long and include a combination of uppercase and lowercase letters, numbers, and special characters."
                                            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" ControlToValidate="txtconfirmpassword" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtconfirmpassword" ErrorMessage="This field can not be blank." ValidationGroup="AR_Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="HDPassword" runat="server" />
                                    </div>
                                    <div class="content" align="center">

                                        <div class="col-xs-12 col-sm-12 txt-cnt">
                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            <asp:Image ID="Image2" runat="server" />
                                            <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/Assets/images/RecaptchaLogo.png"
                                                OnClick="btnImgRefresh_Click" />
                                            <span class="form-bar"></span>

                                            <div class="container-fluid" align="center">
                                                <asp:TextBox ID="captch" runat="server" class="form-control" placeholder="Enter Captcha" CssClass="Regcaptcha" AutoCompleteType="Disabled" MaxLength="6"></asp:TextBox>
                                               <ajaxToolkit:FilteredTextBoxExtender ID="captch_FilteredTextBoxExtender1" runat="server"
                                                    BehaviorID="captch_FilteredTextBoxExtender" FilterType="numbers"
                                                    TargetControlID="captch"></ajaxToolkit:FilteredTextBoxExtender>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="captch" ErrorMessage="This field can not be blank." ValidationGroup="AR_Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <span class="form-bar"></span>
                                            </div>
                                        </div>


                                    </div>
                                     <asp:HiddenField ID="hf" runat="server" />
                                    <div class="content col-md-12 text-center" align="center">
                                        <asp:Button ID="btnregsubmit" Text="Submit" runat="server" class="btn btn-secondary" OnClientClick="return validateReg();" OnClick="btnregsubmit_Click" ValidationGroup="AR_Submit" />
                                        <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                                        <div class="col-xs-12 col-sm-12 txt-cnt">
                                            <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                            </div>



                        </div>


                    </div>
                </div>

            </div>
        </div>

        <div class="row" runat="server" id="divsecondpanel" visible="false">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <div class="content col-lg-12 text-center" align="center">
                            <asp:Label ID="lblRegisterd" runat="server" ForeColor="Red" Font-Size="Large"></asp:Label>
                            <span><a href="../Login1.aspx">Click here to login </a></span>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
