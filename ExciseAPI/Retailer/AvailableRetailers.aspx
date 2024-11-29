<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.master" CodeBehind="AvailableRetailers.aspx.cs" Inherits="ExciseAPI.Retailer.AvailableRetailers" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .radioButtonListAvailable label {
            font-size: 15px;
            margin-left: 10px;
            height: 10px;
            width: 30%;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="w-100 fl container-fluid">
    <div class="block black bg-white">
        <div class="head">Available Retailers Report</div>
        <div class="content">
            <div class="form-group row">
                <label class="col-xs-4 col-sm-4 col-md-2 col-lg-2">Retailers</label>
                <div class="col-xs-8 col-sm-8 col-md-4 col-lg-4">
                    <asp:RadioButtonList ID="RblRetailers" runat="server" RepeatDirection="Horizontal" CssClass="radioButtonListAvailable">
                        <asp:ListItem Value="E">Activated Retailers</asp:ListItem>
                        <asp:ListItem Value="C">DeActivated Retailers</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-xs-4 col-sm-4 col-md-2 col-lg-2">Depot Name</label>
                <div class="col-xs-8 col-sm-8 col-md-4 col-lg-4">
                    <asp:DropDownList ID="ddlDepot" runat="server" CssClass="form-control input-b-b"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-xs-4 col-sm-4 col-md-2 col-lg-2">Status</label>
                <div class="col-xs-8 col-sm-8 col-md-4 col-lg-4">
                    <asp:DropDownList ID="ddlStatus" runat="server" class="form-control input-b-b">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="1">Active</asp:ListItem>
                         <asp:ListItem Value="2">Inactive</asp:ListItem>
                        </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6 text-center">
                    <asp:Button ID="BtnSubmit" runat="server" Text="Get Data" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="BtnSubmit_Click" />
                </div>
            </div>
            <div class="form-group row">
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6 text-center">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center"></asp:Label>
                </div>
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
                                        <asp:ImageButton runat="server" ID="btnAvailableImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnAvailableImageExportToPdf_Click"
                                            Visible="false" />
                                    </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnAvailableImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnAvailableImageExportToExcel_Click"
                                        Visible="false" />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--   <asp:UpdatePanel ID="UpdatePartialRenderToGrid" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>--%>
                    <div class="w-100 fl container-fluid" id="divgriddetails" runat="server" visible="true">
                        <div class="block-liner block black bg-white">
                            <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                                <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                                <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Available Retailers Report 
                                   
                                <asp:Label ID="lblHeaderDate" runat="server"></asp:Label>
                                </h2>

                            </div>

                            <div class="content">
                                <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="unit_name" HeaderText="Unit Name" />
                                        <asp:BoundField DataField="ptcode" HeaderText="PTCode" />
                                        <asp:BoundField DataField="ptname" HeaderText="PTName" />
                                        <asp:BoundField DataField="contact" HeaderText="Name" />
                                        <asp:BoundField DataField="pttype" HeaderText="PTType" />
                                        <asp:BoundField DataField="retl_type" HeaderText="RetailerType" />
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
    <%--<script type="text/javascript">
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
    --%>
    <%-- <script  type="text/javascript">
        function pageLoad() {
            //jQueryUI("input[id*='txtFrom']").datepicker({ minDate: new Date(), dateFormat: 'yy-mm-dd' });
            //jQueryUI("input[id*='txtTo']").datepicker({ minDate: new Date(), dateFormat: 'yy-mm-dd' });
        }
    </script>--%>
</asp:Content>
