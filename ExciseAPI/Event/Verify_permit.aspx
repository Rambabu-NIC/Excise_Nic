<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Event/Event.master" CodeBehind="Verify_permit.aspx.cs" Inherits="ExciseAPI.Event.Verify_permit" %>

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
    <script type="text/javascript">
        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
    <style type="text/css">
        .row {
            margin-left: 0px;
            margin-right: 0px;
        }

        .style3 {
            font-size: large;
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Download</div>
            <div class="content">
                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card">
                                <asp:Panel ID="Panel2" runat="server" BorderColor="#b2beb5" BorderStyle="Solid">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <div class="card-block">
                                        <div class="row">
                                            <div class="col-md-4">
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-sm-4 col-form-label text-left">
                                                        Permit Number</label>
                                                    <div class="col-sm-6 col-form-label text-left">
                                                        <asp:TextBox ID="txtRegistrationNo" MaxLength="16" CssClass="form-control " runat="server">
                                                        </asp:TextBox>
                                                        <%--<ajax:FilteredTextBoxExtender ID="txtRegistrationNo_FilteredTextBoxExtender" runat="server"
                                                                        Enabled="True" FilterType="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                                        TargetControlID="txtRegistrationNo" ValidChars="-/|">
                                                                    </ajax:FilteredTextBoxExtender>--%>
                                                    </div>
                                                </div>
                                                <%--<center><b>( OR )</b></center>--%>
                                                <%--<div class="form-group row">
                                                                <label class="col-sm-4 col-form-label text-left">
                                                                    Mobile Number</label>
                                                                <div class="col-sm-6 col-form-label text-left">
                                                                    <asp:TextBox ID="txtMobileNumber" MaxLength="10" CssClass="form-control " runat="server">
                                                                    </asp:TextBox>
                                                                    <ajax:FilteredTextBoxExtender ID="txtMobileNumber_FilteredTextBoxExtender" runat="server"
                                                                        Enabled="True" FilterType="Numbers" TargetControlID="txtMobileNumber" ValidChars="">
                                                                    </ajax:FilteredTextBoxExtender>
                                                                </div>
                                                            </div>--%>
                                                <div class="content" align="center">

                                                    <div class="col-xs-12 col-sm-12 txt-cnt">
                                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                        <asp:Image ID="Image2" runat="server" />
                                                        <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/Assets/images/RecaptchaLogo.png"
                                                            OnClick="btnImgRefresh_Click" />
                                                        <span class="form-bar"></span>
                                                    </div>
                                                    <div class="container-fluid" align="center">
                                                        <asp:TextBox ID="captch" runat="server" class="form-control" placeholder="Enter Captcha" CssClass="Regcaptcha"></asp:TextBox>
                                                        <span class="form-bar"></span>
                                                    </div>

                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-sm-12 col-form-label text-left">
                                                        <center>
                                                                        <asp:Button ID="btn_Save" CssClass=" btn btn-info btn-out-dotted bt" runat="server"
                                                                            Text="Verify Permit" OnClick="btn_Save_Click" />
                                                                         </center>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="card">
                                        <asp:Panel ID="Panel1" runat="server" BorderColor="#b2beb5" BorderStyle="Solid" Visible="false">
                                            <asp:HiddenField ID="hf" runat="server" />
                                            <div class="card-block">
                                                <div class="row" id="printableArea">
                                                    <div class="col-md-12">
                                                        <center>
                                                                        <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="~/Excise-Logo.png"
                                                                            Width="100px" />
                                                                        <label style="font-size: large">
                                                                            <b>TELANGANA STATE PROHIBITION &amp; EXCISE DEPARTMENT </b>
                                                                        </label>
                                                                        &nbsp;&nbsp;
                                                                        <asp:Image ID="ImgQR" runat="server" Height="100" Visible="false" Width="100" />
                                                                    </center>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <center>
                                                                        <b>FORM EP-1<br />
                                                                            [See Rule 4 (viii)]</b>
                                                                    </center>
                                                        <label class="col-sm-4 col-form-label text-left">
                                                            Licence No.
                                                                        <asp:Label ID="lblPerLic" runat="server" Style="font-weight: 700"></asp:Label>
                                                        </label>
                                                        <%--&nbsp;<label class="col-sm-4 col-form-label text-right">Date<strong>
                                                                   <asp:Label ID="lblPerDt" runat="server" ></asp:Label></strong></Label>--%>
                                                        <p class="style3" style="text-decoration: underline">
                                                            <b>Event Permit for Retail Sale or Serve of all kinds of Indian Made Foreign Liquor
                                                                            And Foreign Liquor to be consumed on the premises</b>
                                                        </p>
                                                        <p>
                                                            I,
                                                                        <asp:Label ID="lblExDepoNm" runat="server" Text=""></asp:Label>, District prohibition
                                                                        &amp; Excise officer of
                                                                        <asp:Label ID="lblExdist" runat="server" Text=""></asp:Label>
                                                            District in consideration of the payment of fee of Rs
                                                                        <asp:Label ID="lblLicFee" runat="server" Text=""></asp:Label>
                                                            &nbsp; (Rupees twelve thousand Only) receipt of which is hereby acknowledged, hereby
                                                                        licence you to sell/serve all kinds of Indian Made Foreign Liquor and Foreign Liquor
                                                                        as per the following details:
                                                        </p>
                                                        <center>
                                                                        <table style="border: thin solid #000000">
                                                                            <tr>
                                                                                <td>
                                                                                    Applicant Name:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblAppNAme" runat="server" Style="font-weight: 700; text-align: left"></asp:Label>
                                                                                </td>
                                                                                <td >
                                                                                    Date and Time:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDttime" runat="server" Style="font-weight: 700"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td >
                                                                                    Premises:
                                                                                </td>
                                                                                <td >
                                                                                    <asp:Label ID="lblAddress" runat="server" Style="font-weight: 700"></asp:Label><asp:Label
                                                                                        ID="lblRAddress" runat="server" Style="font-weight: 700"></asp:Label>
                                                                                </td>
                                                                                <td >
                                                                                    Occasion:
                                                                                </td>
                                                                                <td >
                                                                                    <asp:Label ID="lblOccasion" runat="server" Style="font-weight: 700"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </center>
                                                        <center>
                                                                        <b>Boundaries</b></center>
                                                        <center>
                                                                        <table>
                                                                            <tr>
                                                                                <td style="border: thin solid #000000">
                                                                                    East:
                                                                                </td>
                                                                                <td style="border: thin solid #000000">
                                                                                    <asp:Label ID="lblBEast" runat="server" Text="" CssClass="ui-priority-primary"></asp:Label>
                                                                                </td>
                                                                                <td style="border: thin solid #000000">
                                                                                    West:
                                                                                </td>
                                                                                <td style="border: thin solid #000000">
                                                                                    <asp:Label ID="lblBWest" runat="server" Text="" CssClass="ui-priority-primary"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="border: thin solid #000000">
                                                                                    North:
                                                                                </td>
                                                                                <td style="border: thin solid #000000">
                                                                                    <asp:Label ID="lblBNorth" runat="server" Text="" CssClass="ui-priority-primary"></asp:Label>
                                                                                </td>
                                                                                <td style="border: thin solid #000000">
                                                                                    South:
                                                                                </td>
                                                                                <td style="border: thin solid #000000">
                                                                                    <asp:Label ID="lblSouth" runat="server" Text="" CssClass="ui-priority-primary"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </center>
                                                        <p>
                                                            Subject to the following conditions and stipulations to be observed by you
                                                        </p>
                                                        <ol type="1">
                                                            <%--the said
                                                                        viz..,--%>
                                                            <li>The privilege extends to the sale or serve of all kinds of Indian Made Foreign Liquor
                                                                            and Foreign Liquor at refreshment halls in connection with races/meetings and public
                                                                            entertainments for consumption on the premises.</li>
                                                            <li>The licensee is prohibited from bottling the liquor.</li>
                                                            <li>The licensee is prohibited from purifying, colouring and flavouring the Indian Made
                                                                            Foreign Liquor or mixing any materials therewith and from blending another kind
                                                                            of Indian Made Foreign Liquor with it or keep in his possession other than Indian
                                                                            Made Foreign Liquor authorised by this licence.</li>
                                                            <li>All Indian Made Foreign Liquor and Foreign Liquor sold/served under this licence 
                                                                            shall be obtained from the Telangana State Beverages Corporation Limited or A4 
                                                                            License.
                                                                            <br />
                                                            </li>
                                                            <li>The licensee shall sell only duty paid Indian Made Foreign Liquor.</li>
                                                            <li>Any prohibition and excise officer not less than the rank of Prohibition & Excise
                                                                            Sub-Inspector shall be empowered to check and verify the balance and receipts and
                                                                            issue of the Indian Made Foreign Liquor.</li>
                                                            <li>The licence shall be subject to cancellation or suspension at will by the Commissioner
                                                                            of Prohibition and Excise.</li>
                                                            <li>The licensee shall not act in any manner prejudicial to the interests of the revenues.</li>
                                                            <li>The licensee shall submit the particulars of IMFL and FL purchased, utilised and 
                                                                            balance to the District Prohibition and Excise Officer.</li>
                                                            <li>The Applicant Shall follow SOP of COVID-19.</li>
                                                        </ol>
                                                        <div class="row">
                                                            <%-- <div style="float: left; text-align: left; margin-left: auto;">
                                                                           
                                                                                Dated:
                                                                            
                                                                        </div>--%>
                                                            <label class="col-sm-4 col-form-label text-left">
                                                                Dated:<strong>
                                                                    <asp:Label ID="lblPerDt" runat="server"></asp:Label></strong></label>
                                                        </div>
                                                        <div class="row">

                                                            <div style="float: right; text-align: right; margin-left: auto;">
                                                                <center>
                                                                                District Prohibition &amp; Excise Officer</center>
                                                                <center>
                                                                                Hyderabad</center>
                                                            </div>
                                                        </div>
                                                        <%-- <p>
                                                                        [Form EP-1 substituted by G.O. Ms. No. 597, Revenue (Ex.II) dated 26.05.2006]
                                                                        </p>--%>
                                                    </div>
                                                </div>
                                                <input type="button" style="visibility: hidden" onclick="printDiv('printableArea')" value="Download" />
                                                <%-- <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-sm-4 col-form-label text-left">
                                                                            Registration Number</label>
                                                                        <div class="col-sm-6 col-form-label text-left">
                                                                            <asp:TextBox ID="txtRegistrationNo" MaxLength="10" CssClass="form-control " runat="server">
                                                                            </asp:TextBox>
                                                                            <ajax:FilteredTextBoxExtender ID="txtRegistrationNo_FilteredTextBoxExtender" runat="server"
                                                                                Enabled="True" FilterType="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                                                TargetControlID="txtRegistrationNo" ValidChars="-. ">
                                                                            </ajax:FilteredTextBoxExtender>
                                                                        </div>
                                                                    </div>
                                                                    
                                                                    <div class="form-group row">
                                                                        <label class="col-sm-4 col-form-label text-left">
                                                                            Mobile Number</label>
                                                                        <div class="col-sm-6 col-form-label text-left">
                                                                            <asp:TextBox ID="txtMobileNumber" MaxLength="10" CssClass="form-control " runat="server">
                                                                            </asp:TextBox>
                                                                            <ajax:FilteredTextBoxExtender ID="txtMobileNumber_FilteredTextBoxExtender" runat="server"
                                                                                Enabled="True" FilterType="Numbers" TargetControlID="txtMobileNumber" ValidChars="">
                                                                            </ajax:FilteredTextBoxExtender>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group row">
                                                                        <div class="col-sm-6 col-form-label text-left">
                                                                            <center>
                                                                                <asp:Button ID="btn_Save" CssClass=" btn btn-info btn-out-dotted bt" runat="server"
                                                                                    Text="Get Details"/> 
                                                                        </div>
                                                                        </center>
                                                                    </div>
                                                                </div>--%><%--OnClick="btn_Save_Click" --%>
                                            </div>
                                    </div>
                                    </asp:Panel>
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



