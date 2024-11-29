<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BAREndorsement.aspx.cs" Inherits="ExciseAPI.Supplier.BAREndorsement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            float: left;
            width: 491px;
        }
    </style>
     <script type="text/javascript">
        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divfirstpanel" runat="server" visible="true">
        <div class="w-100 fl container-fluid">
            <div class="content">
                <div class="m-t-40" id="FullBlock" runat="server">
                    <div id="PrintForm">
                        <div style="font-weight: bold; text-align: center; width: 100%; margin:10px;">
                            <table style="margin: 0px auto;">
                                <tr>
                                    <td style="vertical-align: middle; padding-right: 7px;">
                                        <img id="Original" src="../Assets/images/tg.png" width="74" height="81" /><br />
                                        GOVERNMENT OF TELANGANA<br />
                                        RENEWAL ENDORSEMENT 2024-25
                                </tr>
                            </table>
                        </div>
                        <br />
                        <br />
                        <div style="clear: both;"></div>
                           <div class="row" style="margin-top: 2px; width: 100% !important;">
                            <div style="width: 49%; float: left; padding-left: 20px;">
                                <div style="float: left; text-align: center;">
                                    <label class=" text-left">
                                        Proceeding No:
                                        <asp:Label ID="lblProceeding" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>

                                    </label>
                                </div>
                            </div>
                            <div style="width: 49%; float: left; padding-right: 20px;">
                                <div style="float: right; text-align: center;">
                                    <label class=" text-left">
                                        Dated :
                                        <asp:Label ID="lblDate" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div style="padding: 0px 0px; width: 100%; float: left; text-align: justify;">
                            <div style="width: 100%; float: left; line-height: 24px;">
                                In pursuance of the orders issued in G.O.Ms.No.222, 
                                Revenue (Excise.II) Department, Dated: 27.09.2017, G.O.Ms.No.223, Revenue (Excise.II) Department, 
                                Date.27.09.2017 and GOMS No.46 Revenue (Excise.II) Department, 
                                Date.27.09.2017 and as per the instructions of the Commissioner of Prohibition and Excise,
                                T.S. Hyderabad, the Licence in Form-2B bearing No.<asp:Label ID="lblbearingNo" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                Dated:
                                <asp:Label ID="lblbearingdate" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                issued under the name and style of M/s.
                                <asp:Label ID="lblLicenseeName" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                at Premises bearing No.<asp:Label ID="lblPremisesbearingNo" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                in favour of Sri. 
                                <asp:Label ID="lblName" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                is renewed for the year 2024-2025 i.e., for the period from 01.10.2024 to 30.09.2025. The plinth area is (
                                <asp:Label ID="lblplintharea" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>)
                                Sq. Mts., the licence fee is fixed for Rs.<asp:Label ID="lblAmount" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                /-
                                (Rupees
                                <asp:Label ID="lblRupees" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                 )
                                 per Annum.
                            </div>
                            <br />
                        </div>
                          <div class="row" style=" width: 100% !important;">
                               <div style="width: 99%; float: left; padding-right: 20px;">
                                    <div style="float: right; text-align: center;">
                                        <div style="width: 100%; float: right; text-align: left; font-weight: bold; line-height: 18px;">
                                             <center><asp:Image ID="DPEOImageSign" runat="server" Height="50"  /></center>
                                            <br />
                                            District Prohibition & Excise Officer,
                                         <br />
                                            Hyderabad (I/C)
                                        <br />

                                        </div>
                                    </div>
                                </div>
                              </div>
                       
                    </div>
                     
                </div>
                <div class="row m-t-20">
                        <div class="col-xs-12 text-center">
                            <br />
                            <br />
                            <br />
                            <button type="button" class="btn btn-secondary btnn btn-sm text-uppercase" id="btnPrintFormL" onclick="printDiv('PrintForm');">Print</button>

                        </div>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>

