<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Manufacture.aspx.cs" Inherits="ExciseAPI.Admin.Manufacture" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Manufacturer Details</div>
            <div class="content">
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type Of Manufacturing</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:DropDownList ID="ddlTypeofmanu" runat="server" class="form-control input-b-b" AutoPostBack="true">
                        </asp:DropDownList>

                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Manufacturer Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtManufName" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Contact Person Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtPersonNm" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtMob" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="head">Address Details</div>
            <div class="content">

               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">State</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddl_Stae" runat="server" class="form-control input-b-b" AutoPostBack="true" OnSelectedIndexChanged="ddl_Stae_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlDist" runat="server" class="form-control input-b-b" AutoPostBack="true" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mandal</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlMand" runat="server" class="form-control input-b-b" AutoPostBack="true" OnSelectedIndexChanged="ddlMand_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Village</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlVill" runat="server" class="form-control input-b-b">
                        </asp:DropDownList>
                    </div>
                </div>


                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Address</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtAdd" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Pincode</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtPincode" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="head">License Details</div>
            <div class="content">
               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Licensee Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtLicNo" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>


               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Date Valid From</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtDtFrom" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                         <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDtFrom" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                    </div>
                </div>

               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Date Valid To</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtDtTo" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                              <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDtTo" Format="yyyy-MM-dd"> </cc1:CalendarExtender>
                    </div>
                </div>

               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">TIN Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtTinNo" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>

               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">SGST Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtSgstNo" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">PAN Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtPanNo" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Annual Licensee Capacity</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtLicCapacity" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="content text-center ">
        <div class="col-xs-12 col-sm-12 txt-cnt">
            <asp:Button ID="btn_Save" runat="server" Text="Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="btn_Save_Click" />
            <asp:Button ID="btn_Update" runat="server" Text="Update" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" Visible="false" OnClick="btn_Update_Click" />
        </div>
        <div class="col-xs-12 col-sm-12 txt-cnt">
            <asp:Label ID="lblError" runat="server" Style="text-align: center"></asp:Label>
        </div>
            </div>
    </div>
    <div class="w-100 fl container-fluid" id="divgrid" runat="server" visible="false" style="max-height: 400px; overflow-x: auto; overflow-y:hidden; width: 100%;">
      <%--  <div class="block-liner block bg-white">--%>
            <div class="content">
                <div id="divgridwithdate1" runat="server" visible="true">
                    <%--<div runat="server" id="DivGeneratedDate" visible="false">
                        <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">
                            <div class="w-100 fl m-b-2">
                                <div class="fr">
                                    <a href="#">
                                        <asp:ImageButton runat="server" ID="btnAvailableImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnAvailableImageExportToPdf_Click"
                                            Visible="false" />
                                    </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnAvailableImageExportToExcel" ImageUrl="~/Assets/images/excel.gif"  OnClick="btnAvailableImageExportToExcel_Click" 
                                        Visible="false" />
                                </div>
                            </div>
                        </div>
                    </div>--%>
                  <%--  <asp:Label ID="lblUSer" runat="server" Class="badge badge-lg bg-info"></asp:Label>--%>
                    <asp:Label ID="lblManufCode" runat="server" Visible="false"></asp:Label>
                    <asp:HiddenField ID="hf" runat="server" />
                    <%--   <asp:UpdatePanel ID="UpdatePartialRenderToGrid" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>--%>
                    <%--<div class="w-100 fl container-fluid"  id="divgriddetails" runat="server" visible="true"   >
                        <div class="block-liner block black bg-white">--%>

                            <div class="content">
                                <asp:GridView ID="GvSupplier" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvSupplier_PageIndexChanging"
                                    OnRowCommand="GvSupplier_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SNo">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type Of Manufacturing">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTypecode" runat="server" Text='<%# Bind("Type_of_Manufacturing") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblTypeName" runat="server" Text='<%# Bind("Type_Man_Nm") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Manufacturer Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Manuf_Code") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblManufName" runat="server" Text='<%# Bind("Manuf_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="District">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDistcode" runat="server" Text='<%# Bind("Dist") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblStateCode" runat="server" Text='<%# Bind("State") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblDistName" runat="server" Text='<%# Bind("DistName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mandal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMandcode" runat="server" Text='<%# Bind("Mandal") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblPeNm" runat="server" Text='<%# Bind("Contact_Person") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblMandName" runat="server" Text='<%# Bind("MandName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Village">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVillcode" runat="server" Text='<%# Bind("Village") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblVillName" runat="server" Text='<%# Bind("VillName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      <%--  <asp:TemplateField HeaderText="Address">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAdd" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Licensee Number ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLicNo" runat="server" Text='<%# Bind("License_No") %>'></asp:Label>
                                                <asp:Label ID="lblLicCap" runat="server" Text='<%# Bind("Annual_Lic_Cap") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" Valid From">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDtValidFrom" runat="server" Text='<%# Bind("FRMDATE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" Valid To">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDtValidTo" runat="server" Text='<%# Bind("TODATE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="Licensee Address">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLicAdd" runat="server" Text='<%# Bind("Capacity") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                       <%-- <asp:TemplateField HeaderText="PAN No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPANNo" runat="server" Text='<%# Bind("PAN_No") %>'></asp:Label>
                                                <%--  <asp:Label ID="lblMob" runat="server" Text='<%# Bind("Mobile") %>' Visible="false"></asp:Label>--%>
                                          <%--  </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TIN No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTINNo" runat="server" Text='<%# Bind("TIN_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SGST No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSGSTNo" runat="server" Text='<%# Bind("SGST_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <%--<asp:TemplateField HeaderText="Mobile Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMob" runat="server" Text='<%# Bind("Mobile") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pincode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPincode" runat="server" Text='<%# Bind("Pincode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                            
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEdit" runat="server" CommandName="edt" ImageUrl="~/Assets/images/edit.PNG" />&nbsp&nbsp
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        <%--</div>
                    </div>--%>
                    <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
            </div>
       <%-- </div>--%>
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

   
</asp:Content>
