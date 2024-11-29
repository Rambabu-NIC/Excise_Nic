<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site1.master" CodeBehind="PaymentView.aspx.cs" Inherits="ExciseAPI.Retailer.PaymentView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Payment</div>
            <div class="content">
                <div class="form-group row col-md-12">
                    <asp:HiddenField ID="hf" runat="server" />
                </div>
                <table width="100%" align="center" id="t1" runat="server">
                    <tr>
                        <td>
                            <strong>Bank Status
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="lblbankStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Challan Number
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="lblchno" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Dept Trans Id
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lbldepttransid" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Bank Trans Id
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblbanktransid" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Bank Name
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblbankname" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Bank Date
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblbankdate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Treasury Date
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lbltrydate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Head Of the Accoount
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblhoa" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <b>DDO Code
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblddocode" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Amount
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblAmt" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

