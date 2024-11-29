<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RetailerPaymentView.aspx.cs" Inherits="ExciseAPI.Retailer.RetailerPaymentView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table,
        th,
        td {
            border: 1px solid black;
        }

            table.center {
                margin-left: auto;
                margin-right: auto;
            }

            table.center1 {
                margin: auto;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Payment</div>
            <div class="content" id="PrintContent" runat="server">
                <table width="100%" align="center" id="t1" runat="server">
                    <tr>
                        <th colspan="2" class="txt-cnt">GOVERNMENT OF TELANGANA
                        <br />
                            E-PAYMENT TO GOTGCPE ACCOUNT<br />
                            E- RECEIPT
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <strong>NAME
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>SHOP NAME
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="lblshopName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>LICENCE/GAZETTE NUMBER
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="lbllicnumber" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>RETAILER CODE
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="lblretailercode" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>DEPOT NAME
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="lbldepotname" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>GOTGGDB ACCOUNT ID
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="lbldepttransid" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>PURPOSE
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="lblpurpose" runat="server">Towards Sale Proceeds</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>CHALLAN NUMBER
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="lblchno" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>BANK NAME
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblbankname" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>BANK TRANSACTION ID
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblbanktransid" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>AMOUNT
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblAmt" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>BANK DATE
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblbankdate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>TRANSACTION DATE
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lbltrydate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>HOA
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblhoa" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>DDO CODE
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblddocode" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <b>DEPT CODE
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server">2314</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>STATUS
                            </strong>
                        </td>
                        <td>
                            <asp:Label ID="lblbankStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
            <div class="col-xs-12 col-sm-12 txt-cnt">
                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btnn btn-sm text-uppercase m-t-10" Visible="true" OnClientClick="javascript:return PrintThisPage();" />
            </div>
        </div>
    </div>
      <script type="text/javascript">

        function PrintThisPage() {

            var sOption = "toolbar=no,location=no,directories=no,status=no,menubar=no,";
            sOption += "scrollbars=yes,height=2000,width=2000";
            var sWinHTML = document.getElementById('ContentPlaceHolder1_PrintContent').innerHTML;
            var sHeadingHTML = '';
            if (document.getElementById('ContentPlaceHolder1_headingContent') != null) {
                sHeadingHTML = document.getElementById('ContentPlaceHolder1_headingContent').innerHTML;
            }
            var winprint = window.open("", "", sOption);
            winprint.document.open();
            winprint.document.write(sWinHTML);
            winprint.document.close();
            winprint.focus();
            winprint.print();
            winprint.close();

            if (navigator.userAgent.toLowerCase().indexOf('chrome') > -1)
                if (navigator.userAgent.indexOf("Chrome") != -1) {
                    winprint.oncontextmenu = function () {
                        return false;
                    }

                    function disableselect(e) {
                        return false
                    }
                    winprint.document.onselectstart = new Function("return false")
                    if (winprint.sidebar) {
                        winprint.document.onmousedown = disableselect
                    }

                }
            if ((navigator.userAgent.indexOf("MSIE") != -1) || (!!document.documentMode == true)) {
                winprint.close();
            }
        }
    </script>
</asp:Content>
