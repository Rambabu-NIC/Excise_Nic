<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="ExciseAPI.Admin.Supplier" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .scroll-gv
    {
        width:500px;
        max-width:300px;
        overflow-y:auto;
        border:1px solid #ccc;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Supplier Details</div>
            <div class="content">
                <%-- <div class="head">Manfactrer Details</div>--%>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Manufacturer</label>

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlTypeofmanu" runat="server" CssClass="form-control" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlTypeofmanu_SelectedIndexChanged">
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Manufacturing Type</label>

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:Label ID="lblTypeofmanyf" runat="server"></asp:Label>
                        <asp:Label ID="lblmfcd" runat="server" Text="Label" Visible="False"></asp:Label>


                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">TIN Number</label>

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtTinNo" CssClass="form-control input-b-b" runat="server" Enabled="false"></asp:TextBox>


                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">SGST Number</label>

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtSgstNo" CssClass="form-control input-b-b" runat="server" Enabled="false"></asp:TextBox>


                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">PAN Number</label>

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtPanNo" CssClass="form-control input-b-b" runat="server" Enabled="false"></asp:TextBox>


                    </div>
                </div>

                <div class="block black bg-white">
                    <div class="head">Supplier Details</div>
                    <div class="content">
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Supplier Code</label>

                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtSupCode" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                              <%--  <ajaxToolkit:FilteredTextBoxExtender ID="txtSupCode_FilteredTextBoxExtender1" runat="server"
                                    BehaviorID="txtSupCode_FilteredTextBoxExtender" FilterType="UppercaseLetters,LowercaseLetters,numbers"
                                    TargetControlID="txtSupCode"></ajaxToolkit:FilteredTextBoxExtender>--%>


                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Supplier Name</label>

                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtSupName" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                               <%-- <ajaxToolkit:FilteredTextBoxExtender ID="txtSupName_FilteredTextBoxExtender1" runat="server"
                                    BehaviorID="txtSupName_FilteredTextBoxExtender" FilterType="UppercaseLetters,LowercaseLetters"
                                    TargetControlID="txtSupName"></ajaxToolkit:FilteredTextBoxExtender>--%>


                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>

                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtMob" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled" MaxLength="10"></asp:TextBox>
                                <%--<ajaxToolkit:FilteredTextBoxExtender ID="txtMob_FilteredTextBoxExtender1" runat="server"
                                    BehaviorID="txtMob_FilteredTextBoxExtender" FilterType="numbers"
                                    TargetControlID="txtMob"></ajaxToolkit:FilteredTextBoxExtender>--%>



                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">DDO Code</label>

                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtDDOCode" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                <%--<ajaxToolkit:FilteredTextBoxExtender ID="txtDDOCode_FilteredTextBoxExtender1" runat="server"
                                    BehaviorID="txtDDOCode_FilteredTextBoxExtender" FilterType="UppercaseLetters,LowercaseLetters,numbers"
                                    TargetControlID="txtDDOCode"></ajaxToolkit:FilteredTextBoxExtender>--%>


                            </div>
                        </div>

                    </div>
                </div>

                <div class="block black bg-white">
                    <div class="head">Supplier Address </div>
                    <div class="content">
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">District</label>

                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:DropDownList ID="ddlDist" runat="server" CssClass="form-control" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mandal</label>

                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:DropDownList ID="ddlMand" runat="server" CssClass="form-control" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlMand_SelectedIndexChanged">
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Village</label>

                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:DropDownList ID="ddlVill" runat="server" CssClass="form-control">
                                </asp:DropDownList>

                            </div>
                        </div>


                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Address</label>

                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtAdd" CssClass="form-control input-b-b" TextMode="MultiLine" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                               <%-- <ajaxToolkit:FilteredTextBoxExtender ID="txtAdd_FilteredTextBoxExtender1" runat="server"
                                    BehaviorID="txtAdd_FilteredTextBoxExtender" FilterType="UppercaseLetters,LowercaseLetters,numbers"
                                    TargetControlID="txtAdd" ValidChars="/,"></ajaxToolkit:FilteredTextBoxExtender>--%>


                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">PinCode</label>

                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtPincode" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled" MaxLength="6"></asp:TextBox>
                               <%-- <ajaxToolkit:FilteredTextBoxExtender ID="txtPincode_FilteredTextBoxExtender1" runat="server"
                                    BehaviorID="txtPincode_FilteredTextBoxExtender" FilterType="numbers"
                                    TargetControlID="txtPincode"></ajaxToolkit:FilteredTextBoxExtender>--%>


                            </div>
                        </div>
                    </div>
                </div>


                <div class="block black bg-white">
                    <div class="head">Liciense Details</div>
                    <div class="content">
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">CPC Proceeding No</label>

                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtLicNo" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>


                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Date Valid From</label>

                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtDtFrom" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDtFrom" Format="yyyy-MM-dd"></cc1:CalendarExtender>


                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Date Valid To</label>

                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtDtTo" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDtTo" Format="yyyy-MM-dd"></cc1:CalendarExtender>


                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Permit Capacity</label>

                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtLicCapacity" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>


                            </div>
                        </div>

                        
                    </div>
                </div>



            </div>
            <div class="content text-center">
                            <div class="col-xs-12 col-sm-12 txt-cnt">
                                <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server" Width="80px"
                                    Text="Save" OnClick="btn_Save_Click" />
                            </div>
                            <div class="col-xs-12 col-sm-12 txt-cnt">
                                <asp:Button ID="btn_Update" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                                    Text="Update" OnClick="btn_Update_Click" Visible="false" />
                            </div>

                        </div>
            </div>
        </div>
            <div class="w-100 fl container-fluid" id="Div1" runat="server" visible="false" style="overflow-y:scroll; overflow-y:hidden;">
                <%--<div class="block black bg-white">--%>
               
                 <%-- <div class="head">Supplier Details</div>--%>

                    <asp:GridView ID="GvSupplier" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
                        CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvSupplier_PageIndexChanging"
                        OnRowCommand="GvSupplier_RowCommand" >
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
                            <asp:TemplateField HeaderText="Supplier Code/Supplier Name">
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
                            <asp:TemplateField HeaderText="Licensee No ">
                                <ItemTemplate>
                                    <asp:Label ID="lblLicNo" runat="server" Text='<%# Bind("License_No") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Licensee Address">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLicAdd" runat="server" Text='<%# Bind("Capacity") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Valid From">
                                <ItemTemplate>
                                    <asp:Label ID="lblDtValidFrom" runat="server" Text='<%# Bind("FRMDATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valid To">
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
                           <%-- <asp:TemplateField HeaderText="PAN No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPANNo" runat="server" Text='<%# Bind("PAN_No") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                           <%-- <asp:TemplateField HeaderText="TIN No">
                                <ItemTemplate>
                                    <asp:Label ID="lblTINNo" runat="server" Text='<%# Bind("TIN_No") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SGST No">
                                <ItemTemplate>
                                    <asp:Label ID="lblSGSTNo" runat="server" Text='<%# Bind("SGST_No") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
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
               
           <%-- </div>--%>
         
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>







