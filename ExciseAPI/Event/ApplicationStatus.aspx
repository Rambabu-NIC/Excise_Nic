<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Event/Event.master" CodeBehind="ApplicationStatus.aspx.cs" Inherits="ExciseAPI.Event.ApplicationStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script type="text/javascript">

        function pageLoad() {
            $(document).ready(function () {
                $("input[id*='txtEvnDate']").datepicker({ maxDate: new Date(), dateFormat: 'yy-mm-dd' });
                //$("input[id*='txtTo']").datepicker({ maxDate: new Date(), dateFormat: 'yy-mm-dd' });
            });
        }
    </script>
    <style>
        .eventlinkbtn {
            padding: 5px 10px;
            font-size: 14px;
            line-height: 2;
            border-radius: 5px;
            height: 40px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <asp:HiddenField ID="hf" runat="server" />
            <div class="head">Permit DEtails</div>
            <div class="content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Registration Number</label>
                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtRegistrationNo" MaxLength="10" CssClass="form-control input-b-b" runat="server" placeholder="Registration No"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>
                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtMobileNumber" MaxLength="10" CssClass="form-control input-b-b" runat="server" placeholder="Mobile No"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rgxMobileNumber" runat="server" ControlToValidate="txtMobileNumber"
                                    ValidationExpression="(0|91)?[6-9][0-9]{9}" ErrorMessage="Invalid Mobile Number." ForeColor="Red">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-md-12 text-center">

                            <div class="col-xs-12 col-sm-12 txt-cnt">
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                <asp:Image ID="Image2" runat="server" />
                                <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/Assets/images/RecaptchaLogo.png"
                                    OnClick="btnImgRefresh_Click" />
                                <span class="form-bar"></span>

                                <div class="container-fluid" align="center">
                                    <asp:TextBox ID="captch" runat="server" class="form-control" placeholder="Enter Captcha" CssClass="Regcaptcha" MaxLength="6" AutoCompleteType="Disabled"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="captch_FilteredTextBoxExtender1" runat="server"
                                        BehaviorID="captch_FilteredTextBoxExtender" FilterType="numbers"
                                        TargetControlID="captch"></ajaxToolkit:FilteredTextBoxExtender>
                                    <span class="form-bar"></span>
                                </div>
                            </div>


                        </div>
                        <div class="col-md-12 text-center">
                            <div class="col-xs-12 col-sm-12 txt-cnt">
                                <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                                    Text="Get Details" OnClick="btn_Save_Click" />
                            </div>
                            <div class="col-xs-12 col-sm-12 txt-cnt">
                                <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                            </div>
                        </div>

                        <div class="content" runat="server" id="datadiv" visible="false">
                            <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                                <label class="col-xs-2 col-sm-2 col-md-2 col-lg-2">Applicant Name</label>
                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                                    <asp:TextBox ID="lblApplicantName" ReadOnly="true" CssClass="form-control input-b-b" runat="server" placeholder="Applicant Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                               <label class="col-xs-2 col-sm-2 col-md-2 col-lg-2">Status</label>
                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                                    <asp:TextBox ID="lblApplicationStatus" ReadOnly="true" CssClass="form-control input-b-b" runat="server" placeholder="Status"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $("#txtEvnDate").datepicker({
                    dateFormat: 'dd-mm-yy',
                    changeMonth: true,
                    changeYear: true,
                    minDate: 0
                });
            });
        });
    </script>
</asp:Content>

