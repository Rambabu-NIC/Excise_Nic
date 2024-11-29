<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.master" CodeBehind="Retailerss.aspx.cs" Inherits="ExciseAPI.Retailer.Retailerss" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Retailer Wise Report</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Depot</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                       
                            <asp:DropDownList ID="ddlDepot" runat="server" class="form-control input-b-b"
                            OnSelectedIndexChanged="ddlDepot_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                         <asp:DropDownList ID="ddlRetailer" runat="server" class="form-control input-b-b">
                        </asp:DropDownList>
                    </div>
                </div>
               
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"> From Date(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtFrom" CssClass="form-control input-b-b" runat="server" placeholder="From Date"></asp:TextBox>
                        <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFrom" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtTo" CssClass="form-control input-b-b" runat="server" placeholder="To Date"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtTo" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="BtnSubmit" runat="server" Text="Submit" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="BtnSubmit_Click" />
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="divgrid" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div class="content">
                <div id="divgridwithdate1" runat="server" visible="true">
                    <div runat="server" id="DivGeneratedDate" visible="false">
                        <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">
                            <div class="w-100 fl m-b-2">
                                <div class="fr">
                                    <a href="#">
                                        <asp:ImageButton runat="server" ID="btnRetailerImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnRetailerImageExportToPdf_Click"
                                            Visible="false" />
                                    </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnRetailerImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnRetailerImageExportToExcel_Click"
                                        Visible="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--   <asp:UpdatePanel ID="UpdatePartialRenderToGrid" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>--%>
                    <div class="w-100 fl container-fluid" id="divgriddetails" runat="server" visible="true">
                        <div class="block-liner block black bg-white">
                            <div class="col-md-12 text-center">
                                <h4 style="text-align: center; font-weight: bold;">Retailer Wise Report</h4>
                            </div>
                            <div class="content">
                                <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="unit_name" HeaderText=" UnitName" />
                                                    <asp:BoundField DataField="retl_code" HeaderText="RetailerCode" />
                                                    <asp:BoundField DataField="retlname" HeaderText="RetailerName" />
                                                    <asp:BoundField DataField="challan_num" HeaderText="Challan No" />
                                                    <asp:BoundField DataField="trans_date" HeaderText="TransactionDate" />
                                                    <asp:BoundField DataField="banktrans_id" HeaderText="TransactionId" />
                                                    <asp:BoundField DataField="bank_name" HeaderText="BankName" />
                                                     <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                                    <asp:BoundField DataField="bclid" HeaderText="TGBCL ID" />
                                                </Columns>
                                            </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $(document).on('click', '#txtFrom', function () {
                document.getElementById('txtRegNoFrom').value = "";
                document.getElementById('txtRegNoTo').value = "";
            });
            $(document).on('click', '#txtTo', function () {
                document.getElementById('txtRegNoFrom').value = "";
                document.getElementById('txtRegNoTo').value = "";
                //                if (document.getElementById('txtfrm').value == "") {
                //                    alert("Please Select From Date");
                //                }
            });


            //$('#txtRegNoFrom').on('input', function (e) {
            $(document).on('click', '#txtRegNoFrom', function () {
                document.getElementById('txtFrom').value = "";
                document.getElementById('txtTo').value = "";
            });
            //$('#txtRegNoTo').on('input', function (e) {
            $(document).on('click', '#txtRegNoTo', function () {
                document.getElementById('txtFrom').value = "";
                document.getElementById('txtTo').value = "";
            });
            //$("#txtfrm").attr('readonly', 'readonly');
            //$("#txtto").attr('readonly', 'readonly');
            $("#txtFrom").datepicker({
                // defaultDate: "+1",
                onSelect: function (date) {
                    //alert(date);
                    $("#txtTo").val(date);
                },
                minDate: '01-01-2011',
                //maxDate: 0,
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true
            }); //.attr('readonly', 'readonly'); ;
            $("#txtTo").datepicker({
                // defaultDate: "+1",
                minDate: '01-01-2011',
                //maxDate: 0,
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true

            }); //.attr('readonly', 'readonly'); ;
        });
    </script>
    <%-- <script  type="text/javascript">
        function pageLoad() {
            //jQueryUI("input[id*='txtFrom']").datepicker({ minDate: new Date(), dateFormat: 'yy-mm-dd' });
            //jQueryUI("input[id*='txtTo']").datepicker({ minDate: new Date(), dateFormat: 'yy-mm-dd' });
        }
    </script>--%>
</asp:Content>

