<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Event/Event.master" CodeBehind="EventSelection.aspx.cs" Inherits="ExciseAPI.Event.EventSelection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style >
        .eventlinkbtn {
            padding: 5px 10px;
    font-size: 14px;
    line-height: 2;
    border-radius: 5px;
    height:40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Apply For Event Registration</div>
            <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="pcoded-inner-content">
                            <div class="main-body">
                                <div class="page-wrapper">
                                    <div class="page-body">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <asp:Panel ID="Panel1" runat="server">
                                                            <asp:HiddenField ID="hf" runat="server" />
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group row">
                                                                        <div class="col-md-1"></div>
                                                                        <div class="col-md-2 col-form-label">
                                                                            <a class="eventlinkbtn btn btnn btn-sm text-uppercase m-t-10" href="Procedure-EventPermit.pdf" target="_blank"><i class="fa fa-file"></i>&nbsp; Procedure for Event Permit </a>
                                                                        </div>
                                                                        <div class="col-md-2 col-form-label">
                                                                            <asp:LinkButton ID="btnReg" runat="server" CssClass="eventlinkbtn btn btnn btn-sm text-uppercase m-t-10" Width="250px"
                                                                                OnClick="btnReg_Click"><i class="fa fa-plus-circle"></i>&nbsp;Application</asp:LinkButton>
                                                                        </div>
                                                                        <asp:Label ID="lblApPStatus" runat="server" Visible="false"></asp:Label>

                                                                        <div class="col-md-2 col-form-label">
                                                                            <asp:LinkButton ID="btnUploadDoc" runat="server" CssClass="eventlinkbtn btn btnn btn-sm text-uppercase m-t-10"
                                                                                Width="250px" OnClick="btnUploadDoc_Click"><i class="fa fa-folder"></i>&nbsp;Upload Documents</asp:LinkButton>
                                                                        </div>
                                                                        <div class="col-md-2 col-form-label">
                                                                            <asp:LinkButton ID="btnPaymentD" runat="server" CssClass="eventlinkbtn btn btnn btn-sm text-uppercase m-t-10"
                                                                                Width="250px" OnClick="btnPaymentD_Click"><i class="fa fa-credit-card"></i>&nbsp; Payment</asp:LinkButton>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </asp:Panel>
                                                        <asp:Panel ID="Panel3" runat="server" Visible="false">

                                                            <div class="col-md-6 offset-2" align="center">
                                                                <asp:RadioButtonList ID="RbTypeP" runat="server" AutoPostBack="True" CssClass="form-control1 rbApplication" Style="font-size: 16px;" Height="150px"
                                                                    OnSelectedIndexChanged="RbTypeP_SelectedIndexChanged" RepeatDirection="Horizontal"
                                                                    Font-Bold="True">
                                                                    <asp:ListItem Text="New" Value="1">
                                                                    </asp:ListItem>
                                                                    <asp:ListItem Text="Edit" Value="2">
                                                                    </asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </asp:Panel>

                                                        <asp:Panel ID="Panel2" runat="server" Visible="false">

                                                            <div class="row">

                                                                <div class="col-md-4">
                                                                </div>

                                                                <div class="col-md-4">
                                                                    <div id="getparameter" runat="server">
                                                                        <div class="form-group row">
                                                                            <label class="col-sm-4 col-form-label text-left">
                                                                                Registration Number</label>
                                                                            <div class="col-sm-6 col-form-label text-left">
                                                                                <asp:TextBox ID="txtRegistrationNo" MaxLength="20" CssClass="form-control " runat="server">
                                                                                </asp:TextBox>
                                                                                <%-- <ajax:FilteredTextBoxExtender ID="txtRegistrationNo_FilteredTextBoxExtender" runat="server"
                                                                                    Enabled="True" FilterType="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                                                    TargetControlID="txtRegistrationNo" ValidChars="-/">
                                                                                </ajax:FilteredTextBoxExtender>--%>
                                                                            </div>
                                                                        </div>
                                                                        <%--<center><b>( OR )</b></center>--%>
                                                                        <div class="form-group row">
                                                                            <label class="col-sm-4 col-form-label text-left">
                                                                                Mobile Number</label>
                                                                            <div class="col-sm-6 col-form-label text-left">
                                                                                <asp:TextBox ID="txtMobileNumber" MaxLength="10" CssClass="form-control " runat="server">
                                                                                </asp:TextBox>
                                                                                <%-- <ajax:FilteredTextBoxExtender ID="txtMobileNumber_FilteredTextBoxExtender" runat="server"
                                                                                    Enabled="True" FilterType="Numbers" TargetControlID="txtMobileNumber" ValidChars="">
                                                                                </ajax:FilteredTextBoxExtender>--%>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group row">
                                                                            <div class="col-sm-12 col-form-label text-left">
                                                                                <center>
                                                                                    <asp:Button ID="btn_Save" CssClass="btn btnn btn-sm text-uppercase m-t-10" runat="server"
                                                                                        Text="Get Details" OnClick="btn_Save_Click" />
                                                                            </div>
                                                                            </center>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            </asp:Panel>
                                                     </div>
                                                    <div class="form-group row" id="divEdit" runat="server" visible="false">
                                                    </div>
                                                    
                                                </div>
                                        </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                    <br />
                                    <br />
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                </div>
        </div>
    </div>
    <script>
        function isNumberKey(event) {
            // Regular expression to allow only numbers (0-9)
            const regex = /^[0-9]$/;

            // Get the input key code
            const keyCode = event.keyCode;

            if (!regex.test(String.fromCharCode(keyCode))) {
                document.getElementById('error-message').textContent = "Invalid input. Please enter a number.";
                return false;
            } else {
                document.getElementById('error-message').textContent = "";
                return true;
            }
        }
    </script>
</asp:Content>
