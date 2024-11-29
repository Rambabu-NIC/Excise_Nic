<%@ Page Title="" Language="C#" MasterPageFile="~/Event/Event.Master" AutoEventWireup="true" CodeBehind="DiffPaymentDtls.aspx.cs" Inherits="ExciseAPI.Event.DiffPaymentDtls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">

            <div class="head">Event Permit Payment</div>
            <div class="content">



                <div class="col-md-12" id="divPayment" runat="server">

                    <div class="card-block">
                        <div class="form-group row col-md-12">
                            <label class="col-md-5 col-form-label text-right">
                                Name:</label>
                            <div class="col-md-3">
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row col-md-12">
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <label class="col-md-5 col-form-label text-right">
                                Registration:</label>
                            <div class="col-md-3">
                                <asp:Label ID="lblRegNo" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row col-md-12">
                            <label class="col-md-5 col-form-label text-right">
                                DDO Code:</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtDDOCode" CssClass="form-control" value="21012304002" runat="server"
                                    AutoComplete="off" MaxLength="3" Enabled="False"></asp:TextBox>

                            </div>
                        </div>
                        <div class="form-group row col-md-12">
                            <label class="col-md-5 col-form-label text-right">
                                Fee:</label>
                            <div class="col-md-3">
                                <asp:Label ID="lblFee" runat="server" Text="1.00"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row col-md-12">
                            <label class="col-md-5 col-form-label text-right">
                                HOA Code:</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtHOA" CssClass="form-control" value="0039001050002000000NVN" runat="server"
                                    AutoComplete="off" MaxLength="2" Enabled="False"></asp:TextBox>

                            </div>
                        </div>
                        <div class="form-group row col-md-12">
                            <div class="col-md-3">
                            </div>
                        </div>

                    </div>
                </div>

            </div>
            <div class="col-md-12 text-center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                        Text="Proceed to pay" OnClick="btn_Save_Click" />
                    <asp:Button ID="btn_Update" CssClass=" btn btn-warning btn-out-dotted" runat="server"
                        Text="Update" Visible="false" />
                </div>
            </div>
        </div>
    </div>
    <div class="form-group row ">
        <div class="col-md-12">
            <center>
<%-- <th colspan="2" style="font-weight:bold; font-size:medium; color:Red" v>Payment Paid for this Registration Number Click Submit</th>--%>
    <table width="50%" align="center" id="t1" runat="server">
        <tr>
            <td>
                <strong>Application No </strong>
            </td>
            <td>
                <asp:Label ID="lblReGNoP" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Applicant Name </strong>
            </td>
            <td>
                <asp:Label ID="lblApplicantName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Challan Number </b>
            </td>
            <td>
                <asp:Label ID="lbldepttransid" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblchno" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Date of Payment</b>
            </td>
            <td>
                <asp:Label ID="lblbankdate" runat="server"></asp:Label>
                <asp:Label ID="lblbanktransid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Amount </b>
            </td>
            <td>
                <asp:Label ID="lblbankname" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblAmt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <b>Status </b>
            </td>
            <td>
                <asp:Label ID="lblbankStatus" runat="server"></asp:Label>
                <asp:Label ID="lblddocode" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbltrydate" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblhoa" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblrnm" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <%--    <tr>
<td>
    <b>Treasury Date </b>
</td>
<td>
                                                                       
</td>
</tr>
<tr>
<td>
    <b>Head Of the Accoount </b>
</td>
<td>
                                                                        
</td>
</tr>--%>
        <%--<tr>
<td>
Remitter's Name
</td>
<td>
<asp:Label ID="lblrnm" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td>
    <b>DDO Code </b>
</td>
<td>
                                                                       
</td>
</tr>
<tr>
<td>
    <b>Amount </b>
</td>
<td>
    &nbsp;</td>
</tr>--%>
    </table>
</center>
        </div>
        <div class="col-sm-6 col-form-label text-left">
            <center>
<asp:Button ID="btnSubmit" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
    Text="Submit" OnClick="btnSubmit_Click" Visible="false"/>
</center>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
