<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Depot_Mapping.aspx.cs" Inherits="ExciseAPI.Retailer.Depot_Mapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">DEPOT Mapping</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Depot Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:DropDownList ID="ddlDepot" runat="server" class="form-control input-b-b">
                        </asp:DropDownList>
                    </div>
                </div>

                 <asp:HiddenField ID="hf" runat="server" />

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="btn_Save" runat="server" Text="Get Details" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="btn_Save_Click" />
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="divgrid" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div class="content">

                <asp:GridView ID="GvDF" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered nowrap gvv" OnSelectedIndexChanged="GvDF_SelectedIndexChanged">

                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- AllowPaging="True" PageSize="5"
                                                                    <asp:TemplateField HeaderText="DepotName">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDepotName" runat="server" Text='<%# Bind("DepotName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="District">
                            <ItemTemplate>
                                <asp:Label ID="lblDistrict" runat="server" Text='<%# Bind("DistCode") %>' Visible="false"></asp:Label>
                                <br />
                                <asp:Label ID="lblDistName" runat="server" Text='<%# Bind("DistName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Select" ShowHeader="False">
                            <ItemTemplate>
                                <%-- <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edt" Text="Edit"></asp:LinkButton>--%>
                                <asp:CheckBox ID="ChkSelect" Checked='<%# Eval("Flag").ToString()!="0" ? true :  false %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
             <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="btn_Update" runat="server" Style="text-align: center" Text="Save Details" Visible="false" OnClick="btn_Update_Click"></asp:Label>
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

