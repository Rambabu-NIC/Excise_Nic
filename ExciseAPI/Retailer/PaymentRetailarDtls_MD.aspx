<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentRetailarDtls_MD.aspx.cs" Inherits="ExciseAPI.Retailer.PaymentRetailarDtls_MD" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Retailer sales proceedings Payment</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Depot Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtdeptName" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtRetailerCode" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Lisence Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtlincesename" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Shop Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtshopName" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Gazette Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtGazette_Code" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Address</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtretaileraddress" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise License No</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtexciselicenseno" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Head of GOTGDDB Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txthead" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>


                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">DDO Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtddocode" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Purpose</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtpurpose" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>


                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Amounts(In Rupees)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtamount" runat="server" CssClass="form-control input-b-b" ></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtamount_FilteredTextBoxExtender1" runat="server"
                            BehaviorID="txtamount_FilteredTextBoxExtender" FilterType="numbers"
                            TargetControlID="txtamount"></ajaxToolkit:FilteredTextBoxExtender>
                        <%--onkeydown="return (!(event.keyCode>=31) && event.keyCode < 48 || event.keyCode > 57 );"--%>
                        <%--<asp:RegularExpressionValidator ID="regexValidator" runat="server"
                            ControlToValidate="txtamount"
                            ValidationExpression="^\d+$"
                            ErrorMessage="Only integers are allowed."
                            Display="Dynamic"
                            ForeColor="Red"
                            EnableClientScript="true" />--%>
                    </div>
                </div>

                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnpaymentSubmit" runat="server" Text="Submit" CssClass="btn btnn btn-sm text-uppercase m-t-10"
                        OnClick="btnpaymentSubmit_Click" />
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
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

