<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.master" CodeBehind="SupplierPaymentView.aspx.cs" Inherits="ExciseAPI.Supplier.SupplierPaymentView" %>

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
            <div class="head">Supplier Payment View</div>
            <div class="content" id="PrintContent" runat="server">
                <div class="form-group row col-md-12">
                    <asp:HiddenField ID="hf" runat="server" />
                </div>

                <table width="50%" align="center" id="t1" runat="server" class="txt-cnt">
                    <tr>
                        <th colspan="2" class="txt-cnt">GOVERNMENT OF TELANGANA
                        <br />
                            SUPPLIER PAYMENT<br />
                            E- RECEIPT
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <b>Name
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>ID
                            </b>
                        </td>
                        <td>
                            <asp:Label ID="lblID" runat="server"></asp:Label>
                        </td>
                    </tr>
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
