<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BARRenewalProceedings.aspx.cs" Inherits="ExciseAPI.Supplier.BARRenewalProceedings" %>

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
                        <div style="font-weight: bold; text-align: center; width: 100%; margin: 10px;">
                            <table style="margin: 0px auto;">
                                <tr>
                                    <td style="vertical-align: middle; padding-right: 7px;">
                                        <img id="Original" src="../Assets/images/tg.png" width="74" height="81" /><br />
                                        GOVERNMENT OF TELANGANA<br />
                                        PROCEEDINGS OF THE DISTRICT PROH. & EXCISE OFFICE :: 
                                        <asp:Label ID="lblofficeName" runat="server"></asp:Label>
                                </tr>
                            </table>
                        </div>
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
                        <div style="padding: 0px 0px; width: 100%; float: left; text-align: justify;">
                            <div style="width: 100%; text-align: center; line-height: 20px;">
                                <asp:Label ID="lblExciseOfficerName" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                <br />
                                District Prohibition & Excise Officer,
                                <br />
                                <span style="font-weight: bold;">****************</span>
                            </div>
                            <div style="width: 100%; float: left; line-height: 18px;">
                                <asp:Label ID="Label1" runat="server" CssClass="" Font-Underline="true" Font-Bold="true" Text="Sub:-"></asp:Label>
                                <br />
                                Prohibition & Excise Department – Hyderabad Excise Unit – Telangana Excise (Grant of licence of selling by bar and conditions of licence) Rules 2005, 
                                Proposal for Renewal of Bar license in the name and style of
                                <asp:Label ID="lblApplicantName" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>&nbsp; for the year 2024-25  - Proposal Submitted – Orders issued.
                            </div>
                            <div style="width: 100%; float: left; line-height: 18px;">
                                <asp:Label ID="Label2" runat="server" CssClass="" Font-Underline="true" Font-Bold="true" Text="Ref:-"></asp:Label>
                                <br />
                                <p>1)G.O.Ms.No. 222, Revenue (Ex.II) Department, Dated: 27.09.2017.</p>
                                <p>2)G.O.Ms.No.223, Revenue (Ex.II) Department, Dated: 27.09.2017.</p>
                                <p>3)G.O.Ms.No.46, Revenue (Ex.II) Department, Dated: 10.05.2023</p>
                                <p>4)G.O.Ms.No.46, Revenue (Ex.II) Department, Dated: 10.05.2023</p>
                                <p>
                                    5)Application of the Licensee/licensees
                                    <asp:Label ID="lblLicensee" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>, 
                                    Dated
                                    <asp:Label ID="lblLicenseeDate" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>.
                                </p>
                                <p>
                                    Report of SHO
                                    <asp:Label ID="lblShoName" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>, 
                                    Dated:<asp:Label ID="lblShodate" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                </p>
                            </div>
                            <div style="width: 100%; text-align: center; line-height: 18px;">
                                <span style="font-weight: bold; text-align: center; text-decoration-line: underline;">****************</span>
                            </div>
                            <div style="width: 100%; float: left; line-height: 18px;">
                                <span style="font-weight: bold; text-decoration-line: underline; font-size: 18px;">ORDER:</span>
                                <br />
                            </div>
                            <div style="width: 100%; float: left; line-height: 20px;">
                                Where as, the 2B Bar licensee of M/s.<asp:Label ID="lblApplicantName1" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                (having plinth area of
                                <asp:Label ID="lblsqmeters" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                Sq. Meters, within the Slab of Rs.
                                <asp:Label ID="lblslabAmount" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                - Lakhs) has remitted an amount of Rs.1,00,000/- vide Challan No.<asp:Label ID="lblchallanno" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>, Dt.
                                <asp:Label ID="lblchallanDate" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                towards Bar Registration Tax and also remitted Rs.<asp:Label ID="lblremittedAmount" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                vide Challan No.<asp:Label ID="lblvidechallanno" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>, Dt.
                                <asp:Label ID="lblvidechallandate" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                towards 1/4th / Half / Full Bar Excise Tax  for the year 2024-25, and also submitted Bank Guarantee/FDR,  Affidavit in Form 4B,
                                Proof of Payment / Renewal of Trade Licence & Sale/Lease Deed  as prescribed under Rule 9A & 10 of Telangana Excise (Grant of licence of selling by bar and conditions of licence), 
                                Rules 2005 and requested for renewal of 2B Bar Licence for the year 2024-25.
                            </div>
                            <br />
                            <div style="width: 100%; float: left; line-height: 20px;">
                                And whereas in the references 1st to 3rd cited, the Government has issued instructions towards renewal of 2B Bar Licence,
                                on fulfilling all the requirements laid down in the Bar Rules, 2005. The SHO
                                <asp:Label ID="lblshoreported" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                reported that 2B Licensee has completed all the required formalities under the rules for renewal of 2B Bar licence.
                            </div>
                            <br />
                            <div style="width: 100%; float: left; line-height: 20px;">
                                In view of the above, the 2B Licence Bearing No.<asp:Label ID="lblLicenceBearingNo" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>, Dt.
                                <asp:Label ID="lblLicenceDate" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                issued in favour of Sri.
                                <asp:Label ID="lblLicenceName" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                under the name and style of M/s.<asp:Label ID="lblLicenceName1" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                at Premises Bearing No.<asp:Label ID="lblPremisesbearingNo" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                is hereby renewed under Rule 9A(2) of Telangana Excise (Grant of licence of Selling by Bar and Conditions of licence) Rules 2005 commencing from 01.10.2024 to 30.09.2025 for the year 2024-25.
                            </div>
                            <br />
                            <div class="row" style=" width: 100% !important;">
                                <div style="width: 49%; float: left; padding-left: 20px;">
                                    <div style="float: left; text-align: center;">
                                         <div style="width: 100%; float: left; text-align: left; font-weight: bold; line-height: 18px;">
                                            TO
                                         <br />
                                            The licensee of M/s. 
                                        <asp:Label ID="lblName1" runat="server" Font-Bold="true"></asp:Label>
                                            <br />
                                            M/s.<asp:Label ID="lblName2" runat="server" Font-Bold="true"></asp:Label>
                                            <br />
                                            Copy to the S.H.O.
                                        <asp:Label ID="lblSHO" runat="server" Font-Bold="true"></asp:Label><strong></strong>
                                            <br />
                                            Copy to the Depot Manager, IML Depot, Concerned.
                                        Copy Submitted to the Deputy Commissioner of Proh.& Excise, Hyderabad
                                        Copy Submitted to the Commissioner of Prohibition and Excise, T.S., Hyderabad.

                                        </div>
                                    </div>
                                </div>
                                <div style="width: 49%; float: left; padding-right: 20px;">
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
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
