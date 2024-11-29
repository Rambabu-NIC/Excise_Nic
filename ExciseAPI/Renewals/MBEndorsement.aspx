<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MBEndorsement.aspx.cs" Inherits="ExciseAPI.Supplier.MBEndorsement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 588%;
            float: left;
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
                                        OFFICE OF THE COMMISSIONER OF PROHIBITION & EXCISE TELANGANA, HYDERABAD                                      
                                </tr>
                            </table>
                        </div>
                        <br />
                        <div style="clear: both;"></div>
                        <div class="row" style="margin-top: 2px; width: 100% !important;">
                            <div style="width: 49%; float: left; padding-left: 20px;">
                                <div style="float: left; text-align: center;">
                                    <label class=" text-left">
                                        Cr. No :
                                        <asp:Label ID="lblcrNo" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>

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
                                FORM – 2MB
                                <br />
                                (Licence for the manufacture and sale of draught beer by
                                microbrewery/Standalone Microbrewery to be consumed on the premises)
                                <br />
                                for the year 
                                <asp:Label ID="lbllicenceYear" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                            </div>
                            <div style="width: 100%; float: left; line-height: 18px;">

                                <br />
                                I, E. Sridhar, I.A.S, Commissioner, Prohibition & Excise, Telangana in consideration of the payment of Micro Brewery Excise Tax of ₹
                                <asp:Label ID="lblmbtaxamount" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                /- vide Challan No.<asp:Label ID="lblmbchallanNo" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                dt:<asp:Label ID="lblmbchallanDate" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                for the year
                                <asp:Label ID="lblmbyear" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>,remitted at 
                                <asp:Label ID="lblremitted" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                renew the Licence of M/s
                                <asp:Label ID="lblApplicantName" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                premises at
                                <asp:Label ID="lblpremises" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                manufacture and sale of draught beer by microbrewery/Standalone Microbrewery / on the premises at 
                                <asp:Label ID="lblpremises1" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                under rule 9A(a) of Telangana Micro brewery Rules 2015 the details of which area as follows:-

                            </div>
                            <div style="width: 100%; float: left; line-height: 18px;">
                                <asp:Label ID="Label2" runat="server" CssClass="" Font-Underline="true" Font-Bold="true" Text="BOUNDARIES"></asp:Label>
                                <br />
                                <p>NORTH :
                                    <asp:Label ID="lblNorth" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                </p>
                                <p>SOUTH :
                                    <asp:Label ID="lblsouth" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                </p>
                                <p>EAST :
                                    <asp:Label ID="lbleast" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                </p>
                                <p>WEST :
                                    <asp:Label ID="lblwest" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                </p>

                            </div>

                            <div style="width: 100%; float: left; line-height: 20px;">
                                Locality village/ town within the marginally noted boundaries During the licence period commencing from the 01-October,
                                <asp:Label ID="lblfromyear" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>
                                and ending with the 30th September-
                                <asp:Label ID="lbltoyear" runat="server" CssClass="" Font-Underline="true" Font-Bold="true"></asp:Label>,
                                subject to the Following conditions and stipulations to be observed by you the said viz.,

                            </div>
                            <br />
                            <div style="width: 100%; float: left; line-height: 20px;">
                                <ul style="list-style-type:disc;">
                                    <li>1)	The license shall be bound by the provisions of the Telangana Excise Act., 1968, Rules, notifications and orders made or issued there under and the Telangana Microbrewery Rules 2015.
                                    </li>
                                    <li>2)	The license shall observe such rules as may be prescribed by the Government or such instructions and orders as may be issued by the Commissioner from time to time in regard to the control of the manufacture possession and serving.
                                    </li>
                                    <li>3)	The licensee shall be bound by such orders as may be passed by the Government or the Commissioner concerning the process of manufacture to be adopted and the standards and quality of beer to be produced and served.
                                    </li>
                                    <li>4)	The licensee shall provide a saccharometer and a thermometer of a kind to be approved by the Commissioner for testing the gravity of wort in the Brewery. A Hydrometer shall also be provided for testing the strength of the draught Beer.
                                    </li>
                                    <li>5)	The alcohol content of the beers produced supplied to the customers shall not exceed 8% V/V.
                                    </li>
                                    <li>6)	The pH, temperature and gravities of the brews up to maturation stage should be recorded and the same is subject to inspection as and when called for by a competent authority.
                                    </li>
                                    <li>7)	The premises to be maintained neat and clean with proper ventilation, lighting and to meet all safety and emergency standards and the beer dispensing system including glasses, serving tables etc to be maintained hygienically at all times.
                                    </li>
                                    <li>8)	Periodic fumigation by certified persons of the storage facility as well as the premises to be done on a routine basis and records maintained.
                                    </li>
                                    <li>9)	Under no circumstances is beer to be served to persons under (21) years.
                                    </li>
                                    <li>10)	The licensee shall strictly maintain timing of beer serving to the customer between 10.00 AM and 11.00 PM.
                                    </li>
                                    <li>11)	The licensee is prohibited from manufacturing any of the Beers, save the ones specially instructed.
                                    </li>
                                    <li>12)	The account of the transactions in the Microbrewery relating to issue shall be maintained in such manner as may be required by the Commissioner.
                                    </li>
                                    <li>13)	No draught beer shall be sold for removal from the licensed premises.
                                    </li>
                                    <li>14)	The Licensee is prohibited from bottling draught beer and its transportation.
                                    </li>
                                    <li>15)	The licensee shall maintain and furnish statistics showing the consumption of all kinds of draught beer separately to the Prohibition and Excise Superintendent.
                                    </li>
                                    <li>16)	The licence shall be subject to cancellation or suspension at will by the Commissioner of Prohibition and Excise.
                                    </li>
                                    <li>17)	The Licensee shall not act in any manner prejudicial to the interest of the revenues of the Government.
                                    </li>
                                    <li>18) An advisory to prevent drunk and driving by making available breath analysers at the premises voluntarily.
                                    </li>
                                    <li>19)	Subject to outcome of the Government orders in respect of obtaining of NOC from TSPCB under rule 6(1)(vii) of Telangana Micro Brewery Rules, 2015.
                                    </li>
                                    <li>20)	Arrears, if any due to Govt.  as any duty revised from time to time.
                                    </li>
                                </ul>
                            </div>
                            <br />
                            <br />
                            <div class="row" style="width: 100% !important;">
                                <div style="width: 49%; float: left; padding-left: 20px;">
                                    <div style="float: left; text-align: center;">
                                        <div style="text-align: left;  line-height: 18px;" class="auto-style2">
                                            <b>TO</b>
                                         <br />
                                            <b>M/s.</b>&nbsp; &nbsp;<asp:Label ID="lblName2" runat="server"></asp:Label>
                                            <br />
                                            <b>Copy to </b>
                                            <br />
                                            <b>The M.D.TSBCL, Hyderabad <br />
                                             The Deputy Commissioner of Prohibition & Excise</b>&nbsp; &nbsp;
                                            <asp:Label ID="lbldycommi" runat="server"></asp:Label>
                                            <br />
                                            <b>The District Prohibition & Excise Officer</b> &nbsp; &nbsp; <asp:Label ID="lbldistoffice" runat="server"></asp:Label>
                                            <br />
                                            <b>The Director of Enforcement, T.S. Hyd
                                             <br />
                                            The Stock File.</b>
                                        </div>
                                    </div>
                                </div>
                                <div style="width: 49%; float: left; padding-right: 20px;">
                                    <div style="float: right; text-align: center;">
                                        <div style="width: 100%; float: right; text-align: left; font-weight: bold; line-height: 18px;">
                                            <center><asp:Image ID="DPEOImageSign" runat="server" Height="50"  /></center>
                                            <br />
                                            Commissioner, Prohibition & Excise
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="row m-t-20" id="divbtnprint" runat="server" visible="true">
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
