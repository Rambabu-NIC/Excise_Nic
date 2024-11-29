<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site1.master" CodeBehind="Retailer_ViewPaymet.aspx.cs" Inherits="ExciseAPI.Retailer.Retailer_ViewPaymet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePartialRenderToGrid" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="w-100 fl container-fluid">
                <div class="block black bg-white">
                    <div class="head">CPE View Payment</div>
                     	<div class="col-md-12 p-5 table-responsive">
                        <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                            OnRowDataBound="gvdetails_RowDataBound" OnRowCommand="gvdetails_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Supplier_Code" HeaderText="Retailer_Code" />
                                <asp:BoundField DataField="Supplier_Name" HeaderText="Retailer Name" />
                                <asp:BoundField DataField="DeptCode" HeaderText="Depot Code" />
                                <asp:BoundField DataField="DDOCode" HeaderText="DDO Code" />
                                <%--<asp:BoundField DataField="DeptTransid" HeaderText="Dept Transaction" />--%>
                                <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                <asp:BoundField DataField="BankStatus" HeaderText="Bank Status" />
                                <asp:BoundField DataField="ChallanNumber" HeaderText="Challan Number" />
                                <asp:BoundField DataField="TreasuryDate" HeaderText="Treasury Date" />
                                <asp:TemplateField HeaderText="View" ItemStyle-CssClass="txt-cnt">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkview" runat="server" Text="Click..!" CommandName="View" CommandArgument='<%# Eval("DeptTransid").ToString()%>' ForeColor="Green" OnClientClick="javascript:return Print('PrintDiv');"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>


                    </div>
                </div>
            </div>

            

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="Receipt" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
    <div class="modal fade  bs-example-modal-sm" id="ModelRecieptPopupConfirm" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-md" style="width: 75%;">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Payment Receipt</h4>
                        </div>

                        <div class="modal-body w-100 fl">
                            <div class="w-100 fl container-fluid text-center" id="PrintDiv">
                                <div class="row m-t-20">
                                    <div class="col-xs-12 text-center">
                                        <table class="highlight-box m-b-20" style="text-align: center;">
                                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                                <tr>
                                                    <td align="center" valign="middle" style="padding-left: 10px; width: 25%; text-align: center !important;"></td>
                                                    <td align="center" valign="middle" style="width: 50%; font-family: 'Times New Roman', Times, serif; font-weight: bold; font-size: 20px; line-height: 20px;">
                                                        <img id="Original1" src="../Assets/images/tg.png" width="74" height="81" /><br />
                                                        Government Of Telangana<br />
                                                        &nbsp;&nbsp;  Prohibition & Excise Department<br />
                                                        &nbsp;&nbsp;  Payment Receipt
                                                    </td>
                                                    <td align="center" valign="middle" style="padding-left: 10px; width: 25%;">&nbsp;</td>
                                                </tr>
                                            </table>
                                            <table cellpadding="0" cellspacing="0" width="100%" border="0" style="border-right: 1px  #aaaaaa solid; margin-top: 25px; border-bottom: 1px  #aaaaaa solid;">
                                                <tr>
                                                     <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                        <div class="col-xs-7 col-sm-6 col-md-6 f-14 col-lg-6 f-b font txt-left p-0">Retailer Code</div>
                                                        <div class="col-xs-5 col-sm-6 col-md-6 col-lg-6 f-14 txt-left p-0">
                                                            <asp:Label runat="server" ID="lblRetailerCode"></asp:Label>
                                                        </div>
                                                    </td>
                                                     <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                        <div class="col-xs-7 col-sm-6 col-md-6 f-14 col-lg-6 f-b font txt-left p-0">Retailer Name</div>
                                                        <div class="col-xs-5 col-sm-6 col-md-6 col-lg-6 f-14 txt-left p-0">
                                                            <asp:Label runat="server" ID="lblRetailerName"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    
                                                    <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                        <div class="col-xs-7 col-sm-6 col-md-6 f-14 col-lg-6 f-b font txt-left p-0">Bank Status </div>
                                                        <div class="col-xs-5 col-sm-6 col-md-6 col-lg-6 f-14 txt-left p-0">
                                                            <asp:Label runat="server" ID="lblbankStatus"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                        <div class="col-xs-7 col-sm-6 col-md-6 f-14 col-lg-6 f-b font txt-left p-0">Challan Number </div>
                                                        <div class="col-xs-5 col-sm-6 col-md-6 col-lg-6 f-14 txt-left p-0">
                                                            <asp:Label runat="server" ID="lblchno"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                        <div class="col-xs-7 col-sm-6 col-md-6 f-14 col-lg-6 f-b font txt-left p-0">Dept Trans ID </div>
                                                        <div class="col-xs-5 col-sm-6 col-md-6 col-lg-6 f-14 txt-left p-0">
                                                            <asp:Label runat="server" ID="lbldepttransid"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                        <div class="col-xs-7 col-sm-6 col-md-6 f-14 col-lg-6 f-b font txt-left p-0">Bank Trans ID</div>
                                                        <div class="col-xs-5 col-sm-6 col-md-6 col-lg-6 f-14 txt-left p-0">
                                                            <asp:Label runat="server" ID="lblbanktransid"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                        <div class="col-xs-7 col-sm-6 col-md-6 f-14 col-lg-6 f-b font txt-left p-0">Bank Name</div>
                                                        <div class="col-xs-5 col-sm-6 col-md-6 col-lg-6 f-14 txt-left p-0">
                                                            <asp:Label runat="server" ID="lblbankname"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                        <div class="col-xs-7 col-sm-6 col-md-6 f-14 col-lg-6 f-b font txt-left p-0">Bank Date</div>
                                                        <div class="col-xs-5 col-sm-6 col-md-6 col-lg-6 f-14 txt-left p-0">
                                                            <asp:Label runat="server" ID="lblbankdate"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                        <div class="col-xs-7 col-sm-6 col-md-6 f-14 col-lg-6 f-b font txt-left p-0">Treasury Date </div>
                                                        <div class="col-xs-5 col-sm-6 col-md-6 col-lg-6 f-14 txt-left p-0">
                                                            <asp:Label runat="server" ID="lbltrydate"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                        <div class="col-xs-7 col-sm-6 col-md-6 f-14 col-lg-6 f-b font txt-left p-0">Head Of the Accoount </div>
                                                        <div class="col-xs-5 col-sm-6 col-md-6 col-lg-6 f-14 txt-left p-0">
                                                            <asp:Label runat="server" ID="lblhoa"></asp:Label>
                                                        </div>
                                                    </td>
                                                    
                                                </tr>

                                                <tr>
                                                    <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                        <div class="col-xs-7 col-sm-6 col-md-6 f-14 col-lg-6 f-b font txt-left p-0">DDO Code </div>
                                                        <div class="col-xs-5 col-sm-6 col-md-6 col-lg-6 f-14 txt-left p-0">
                                                            <asp:Label runat="server" ID="lblddocode"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                        <div class="col-xs-7 col-sm-6 col-md-6 f-14 col-lg-6 f-b font txt-left p-0">Amount  </div>
                                                        <div class="col-xs-5 col-sm-6 col-md-6 col-lg-6 f-14 txt-left p-0">
                                                            <asp:Label runat="server" ID="lblAmt"></asp:Label>
                                                        </div>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                        <div class="col-xs-7 col-sm-6 col-md-6 f-14 col-lg-6 f-b font txt-left p-0">Installment</div>
                                                        <div class="col-xs-5 col-sm-6 col-md-6 col-lg-6 f-14 txt-left p-0">
                                                            <asp:Label runat="server" ID="lblInstallment"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td align="left" style="padding: 7px; width: 50%; border-left: 1px #aaaaaa solid; border-top: 1px #aaaaaa solid;">
                                                </tr>
                                            </table>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="row m-t-20">
                                <div class="col-xs-12 text-center">
                                    <asp:Button ID="btnPrint" runat="server" CssClass="btn btnn btn-sm text-uppercase " Text="Print" OnClientClick="javascript:return Print('PrintDiv');" />
                                    <asp:Button ID="btnClose" runat="server" CssClass="btn btnn btn-sm text-uppercase " Text="Close" OnClick="btnClose_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer text-center">&nbsp;</div>
                    </div>
                </div>
            </div>
      </ContentTemplate>
        </asp:UpdatePanel>
    <script type="text/javascript">
        function ReciptConfirm() {
            jQueryUI('#ModelRecieptPopupConfirm').modal('show');
            return true;
        };
        function ReceiptHide() {
            jQueryUI('#ModelRecieptPopupConfirm').modal('hide');
            jQueryUI('body').removeClass('modal-open');
            jQueryUI('.modal-backdrop').remove();
            return true;
        };  
    </script>
     <script type="text/javascript">
        //function Print(printDivid) {
        //    var printcontent = document.getElementById(printDivid).innerHTML;
        //    var OrginalContent = document.body.innerHTML;
        //    document.body.innerHTML = printcontent;
        //    window.print();
        //    document.body.innerHTML = OrginalContent;

        //}
         function printDiv(divId) {
            var content = document.getElementById(divId);
            var printWindow = window.open('', '_blank');
            printWindow.document.open();
            printWindow.document.write('<html><head><title>Print</title></head><body>');
            printWindow.document.write(content.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.print();
            printWindow.close();
        }
    </script>
</asp:Content>

