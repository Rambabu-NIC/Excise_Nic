<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="ExciseAPI.Supplier.Supplier" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Supplier Details</div>
            <div class="content">
                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card">
                                <div class="card-block">
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-2 col-form-label text-right">
                                            Type Of Manufacturing</label>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="ddlTypeofmanu" runat="server" CssClass="form-control" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                        <asp:HiddenField ID="hf" runat="server" />
                                        <label class="col-md-2 col-form-label text-right">
                                            Supplier Code</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtSupCode" CssClass="form-control " runat="server"></asp:TextBox>
                                             <ajaxToolkit:FilteredTextBoxExtender ID="txtSupCode_FilteredTextBoxExtender1" runat="server"
                                                            BehaviorID="txtSupCode_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters"
                                                            TargetControlID="txtSupCode">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            Supplier/Licensee Name</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtSupName" CssClass="form-control " runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="FilteredTextBoxExtender1" runat="server" enabled="True"
                                                filtertype="UppercaseLetters,lowercaseLetters,Numbers,Custom" targetcontrolid="txtSupName"
                                                validchars="-">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-2 col-form-label text-right">
                                            District</label>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="ddlDist" runat="server" CssClass="form-control " AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                        <label class="col-md-2 col-form-label text-right">
                                            Mandal</label>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="ddlMand" runat="server" CssClass="form-control " AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlMand_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            Village</label>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="ddlVill" runat="server" CssClass="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-2 col-form-label text-right">
                                            Address</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtAdd" TextMode="MultiLine" CssClass="form-control " runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtAdd_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="Numbers,Custom,UppercaseLetters,lowercaseLetters"
                                                targetcontrolid="txtAdd" validchars=" .-,">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            Pincode
                                        </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtPincode" CssClass="form-control " runat="server" AutoComplete="off"
                                                MaxLength="6"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtPincode_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="Numbers,Custom" targetcontrolid="txtPincode" validchars="">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            Mobile Number
                                        </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtMob" CssClass="form-control " runat="server" AutoComplete="off"
                                                MaxLength="10"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtMob_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="Numbers,Custom" targetcontrolid="txtMob" validchars=" .">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-2 col-form-label text-right">
                                            Licensee Number
                                        </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtLicNo" CssClass="form-control " runat="server" AutoComplete="off"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtLicNo_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="Numbers,Custom,UppercaseLetters,lowercaseLetters,Custom"
                                                targetcontrolid="txtLicNo" validchars="">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            Date Valid From
                                        </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtDtFrom" CssClass="form-control " runat="server"></asp:TextBox>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            Date Valid To
                                        </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtDtTo" CssClass="form-control " runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-2 col-form-label text-right">
                                            Annual Licensee Capacity
                                        </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtLicCapacity" CssClass="form-control " runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtLicCapacity_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="Numbers,Custom,UppercaseLetters,lowercaseLetters,Custom"
                                                targetcontrolid="txtLicCapacity" validchars=" .">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            DDO Code
                                        </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtDDOCode" CssClass="form-control " runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtDDOCode_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="Numbers,Custom,UppercaseLetters,lowercaseLetters,Custom"
                                                targetcontrolid="txtDDOCode" validchars=" ">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            PAN Number
                                        </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtPanNo" CssClass="form-control " runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtPanNo_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                targetcontrolid="txtPanNo" validchars="-">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-2 col-form-label text-right">
                                            TIN Number
                                        </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtTinNo" CssClass="form-control " runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtTinNo_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="Numbers,Custom,UppercaseLetters,lowercaseLetters,Custom"
                                                targetcontrolid="txtTinNo" validchars=" .-">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            SGST Number
                                        </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtSgstNo" CssClass="form-control " runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtSgstNo_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="Numbers,Custom,UppercaseLetters,lowercaseLetters"
                                                targetcontrolid="txtSgstNo" validchars=" .">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                        </label>
                                        <div class="col-md-2">
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-2 col-form-label text-right">
                                        </label>
                                        <div class="col-md-2">
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                        </label>
                                        <div class="col-md-2">
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-10">
                                        <asp:Button ID="btn_Save" CssClass=" btn btn-info btn-out-dotted bt" runat="server"
                                            Text="Save" OnClick="btn_Save_Click" />
                                        <asp:Button ID="btn_Update" CssClass=" btn btn-warning btn-out-dotted" runat="server"
                                            Text="Update" Visible="false" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="card">
                        <div class="card-block">
                            <div class="table-responsive dt-responsive">
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
                                                <asp:Label ID="lblTypeName" runat="server" Text='<%# Bind("DistName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Supplier Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSuppCode" runat="server" Text='<%# Bind("Supplier_Code") %>'></asp:Label>
                                                <asp:Label ID="lblSuppName" runat="server" Text='<%# Bind("Supplier_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="District">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDistcode" runat="server" Text='<%# Bind("Dist") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblDistName" runat="server" Text='<%# Bind("DistName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mandal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMandcode" runat="server" Text='<%# Bind("Mandal") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblMandName" runat="server" Text='<%# Bind("MandName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Village">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVillcode" runat="server" Text='<%# Bind("Village") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblVillName" runat="server" Text='<%# Bind("VillName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAdd" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Licensee Number ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLicNo" runat="server" Text='<%# Bind("License_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="Licensee Address">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLicAdd" runat="server" Text='<%# Bind("Capacity") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Date Valid From">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDtValidFrom" runat="server" Text='<%# Bind("FRMDATE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date Valid To">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDtValidTo" runat="server" Text='<%# Bind("TODATE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Annual Licensee Capacity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLicCap" runat="server" Text='<%# Bind("Annual_Lic_Cap") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DDO Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDDOCode" runat="server" Text='<%# Bind("DDOCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PAN No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPANNo" runat="server" Text='<%# Bind("PAN_No") %>'></asp:Label>
                                            </ItemTemplate>
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
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMob" runat="server" Text='<%# Bind("Mobile") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pincode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPincode" runat="server" Text='<%# Bind("Pincode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                            <%--<EditItemTemplate>
                                                                            <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                                                            <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                                                        </EditItemTemplate>--%>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEdit" runat="server" CommandName="edt" ImageUrl="~/Assets/images/edit.PNG" />&nbsp&nbsp
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
