<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Event/Event.master" CodeBehind="PaymentDtls.aspx.cs" Inherits="ExciseAPI.Event.PaymentDtls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .retailer-color {
            color: black;
            text-align: left;
            padding-left: 10%;
        }
    </style>
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
      <div class="head"> Event Permit Payment</div>
            <div class="container">
            
                <div class="row">
                  
                    <div class="col-md-12">
                        <div class="pcoded-inner-content">
                            <div class="main-body">
                                <div class="page-wrapper">
                                    <div class="page-header">
                                        
                                      
                                                <div class="row m-b-20">
                                                   <div class="col-md-12">
                                                        <%--<h4 class="text-center">
                                                           </h4>--%>
                                                    </div>
                                                </div>
                                            </div>
                                       
                                    <div class="page-body">
                                        <div class="row">
                                            <div class="col-sm-12">
                                            
                                                <div class="card" id="divPayment" runat="server" style="align-items:center;">
                                                
                                                    <div class="card-block">
                                                       <div class="form-group row col-md-12">
                                                            <asp:HiddenField ID="hf" runat="server" />
                                                            <label class="col-md-5 col-form-label text-right retailer-color">
                                                                Name:</label>
                                                            <div class="col-md-3">
                                                                <asp:Label ID="lblName" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row col-md-12">
                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                            <label class="col-md-5 col-form-label text-right retailer-color">
                                                                Registration:</label>
                                                            <div class="col-md-3">
                                                                <asp:Label ID="lblRegNo" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row col-md-12">
                                                            <label class="col-md-5 col-form-label text-right retailer-color">
                                                                DDO Code:</label>
                                                            <div class="col-md-3">
                                                                <asp:TextBox ID="txtDDOCode" CssClass="form-control" value="21012304002" runat="server"
                                                                    AutoComplete="off" MaxLength="3" Enabled="False"></asp:TextBox>
                                                                <%--<ajax:FilteredTextBoxExtender ID="txtDDOCode_FilteredTextBoxExtender" runat="server"
                                                                    Enabled="True" FilterType="Numbers,Custom,UppercaseLetters,lowercaseLetters,Custom"
                                                                    TargetControlID="txtDDOCode" ValidChars="">
                                                                </ajax:FilteredTextBoxExtender>--%>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row col-md-12">
                                                            <label class="col-md-5 col-form-label text-right retailer-color">
                                                                Fee:</label>
                                                            <div class="col-md-3">
                                                                <asp:Label ID="lblFee" runat="server" Text="1.00" ></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row col-md-12">
                                                            <label class="col-md-5 col-form-label text-right retailer-color">
                                                                HOA Code:</label>
                                                            <div class="col-md-3">
                                                                <asp:TextBox ID="txtHOA" CssClass="form-control" value="0039001050002000000NVN" runat="server"
                                                                    AutoComplete="off" MaxLength="2" Enabled="False"></asp:TextBox>
                                                                <%--<ajax:FilteredTextBoxExtender ID="txtHOA_FilteredTextBoxExtender" runat="server"
                                                                    Enabled="True" FilterType="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                                    TargetControlID="txtHOA" ValidChars="-">
                                                                </ajax:FilteredTextBoxExtender>--%>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <br />
                                                        <div class="container-fluid text-center">
                                                        <div class="form-group row" style="align-items:center; padding-top:10px;">
                                                            <div class="col-md-12 text-center">
                                                                 <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                                                                Text="Proceed to pay" OnClick="btn_Save_Click" />
                                                            <asp:Button ID="btn_Update" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                                                                Text="Update" Visible="false" />
                                                            </div>
                                                        </div>
                                                            </div>
                                                        <div class="form-group row col-md-10 offset-5">
                                                           
                                                        </div>
                                        
                                            </div>
                                        </div>
                                        <div class="card">
                                         <div class="form-group row ">
                                                                <div class="col-md-12">
                                                                    <center>
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
                                                                  <div class="col-sm-12">
                                                                <center>
                                                                    <asp:Button ID="btnSubmit" CssClass=" btn btn-secondary" runat="server"
                                                                        Text="Submit" OnClick="btnSubmit_Click" Visible="false" />
                                                                </center>
                                                            </div>
                                                            </div>
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
            </div>
        </div>
    </asp:Content>
