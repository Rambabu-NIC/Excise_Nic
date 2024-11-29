<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePasswordS.aspx.cs" Inherits="ExciseAPI.ChangePasswordS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="pcoded" class="pcoded">
        <div class="pcoded-container navbar-wrapper">

            <div class="pcoded-main-container">
                <div class="pcoded-wrapper">
                       <asp:HiddenField ID="hf" runat="server" />
                    <div class="pcoded-content">
                        <div class="pcoded-inner-content">
                            <div class="main-body">
                                <div class="page-wrapper">

                                    <div id="Div1" class="page-body" runat="server">
                                        <div class="card">
                                            <div class="card-block">
                                                <div class="form-group row col-md-12">
                                                    <label class="col-md-3 col-form-label text-right">
                                                        New Password<span style="color: Red"> *</span></label>
                                                    <div class="col-md-3">
                                                        <asp:TextBox ID="txtNpwd" runat="server" AutoCompleteType="Disabled" TextMode="Password"
                                                            CssClass="form-control"></asp:TextBox>
                                                        <asp:HiddenField ID="txtNewPwdHash" runat="server" />
                                                        <%-- <asp:CustomValidator ID="CustomValidator1" runat="server" Display="None" ErrorMessage="Your Password Should Contain minimum 8 Characters with atleast 1 uppercase,1 lowercase, 1 numeric and 1 Special character"
                                        ControlToValidate="txtNpwd" ClientValidationFunction="validateCustomReg"></asp:CustomValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                        TargetControlID="CustomValidator1">
                                    </asp:ValidatorCalloutExtender>--%>
                                                    </div>
                                                    <label class="col-md-3 col-form-label text-right">
                                                        Confirm Password<span style="color: Red"> *</span></label>
                                                    <div class="col-md-3">
                                                        <asp:TextBox ID="txtCpwd" runat="server" AutoCompleteType="Disabled" TextMode="Password"
                                                            CssClass="form-control"></asp:TextBox>
                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtCpwd"
                                        runat="server" ErrorMessage="Please Enter Password" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True"
                                        TargetControlID="RequiredFieldValidator9">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password and Confirm Password doesnot Match"
                                        Display="None" ControlToValidate="txtCpwd" ControlToCompare="txtNpwd"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                        TargetControlID="CompareValidator1">
                                    </asp:ValidatorCalloutExtender>--%>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 text-center">
                                                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click"
                                                        CssClass=" btn btn-info btn-out-dotted bt" OnClientClick="return validateReg();" />
                                                </div>
                                            </div>
                                        </div>
                                        <div id="Div2" class="card" runat="server">
                                            <div id="Div3" class="card-block" runat="server">
                                                <div id="Div4" class="table-responsive dt-responsive" runat="server">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
