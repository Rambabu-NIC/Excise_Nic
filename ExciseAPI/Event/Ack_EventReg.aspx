<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Event/Event.master" CodeBehind="Ack_EventReg.aspx.cs" Inherits="ExciseAPI.Event.Ack_EventReg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
            <div class="head">Acknowledgement</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Registration Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:TextBox ID="txtRegistrationNo" CssClass="form-control input-b-b" runat="server"></asp:TextBox>

                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtMobileNumber" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rgxMobileNumber" runat="server" ControlToValidate="txtMobileNumber"
                            ValidationExpression="(0|91)?[6-9][0-9]{9}" ErrorMessage="Invalid Mobile Number." ForeColor="Red">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
            <div class="content" align="center">

                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblmsg" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
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
            <div class="content" align="center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                        Text="Get Details" OnClick="btn_Save_Click" />

                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
           
            <asp:HiddenField ID="hf" runat="server" />
        </div>
        </div>
        <div class="w-100 fl container-fluid" runat="server" id="datadiv" visible="false">

        <div class="block black bg-white">
        <div class="content" >
            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Application No</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                    <asp:Label ID="lblAppNo" runat="server"></asp:Label>

                </div>
            </div>
            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Applicant Name</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                    <asp:Label ID="lblApplicantName" runat="server"></asp:Label>

                </div>
            </div>
            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Challan Number</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                    <asp:Label ID="lblchno" runat="server"></asp:Label>

                </div>
            </div>
            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Date of Payment</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                    <asp:Label ID="lblbankdate" runat="server"></asp:Label>

                </div>
            </div>

            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Amount</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                    <asp:Label ID="lblPay" runat="server"></asp:Label>

                </div>
            </div>
            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Status</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                    <asp:Label ID="lblbankStatus" runat="server"></asp:Label>

                </div>
            </div>
        </div>
        <div class="row" runat="server" id="div1" visible="false">
            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Applicantion No</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                </div>
            </div>
            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Payment</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                </div>
            </div>
            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Applicant Name</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                </div>
            </div>
            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Status</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                </div>
            </div>
            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Applicant Name</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </div>
            </div>
            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Status</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </div>
            </div>
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
