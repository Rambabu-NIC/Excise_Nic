<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MST_Retailers.aspx.cs" Inherits="ExciseAPI.Supplier.MST_Retailers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Retailers -Master</div>
            <div class="content">
                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card">
                                <div class="card-block">
                                    <div class="form-group row col-md-12">
                                        <asp:HiddenField ID="hf" runat="server" />


                                        <label class="col-md-3 col-form-label text-right">
                                            Retailer Name</label>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtRetailerName" CssClass="form-control" runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtType_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                targetcontrolid="txtRetailerName" validchars="- .">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        <label class="col-md-3 col-form-label text-right">
                                            Retailer Type</label>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ddlRetailerType" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlRetailerType_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-3 col-form-label text-right">
                                            License Name</label>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtLicenseName" CssClass="form-control" runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="FilteredTextBoxExtender2" runat="server"
                                                enabled="True" filtertype="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                targetcontrolid="txtLicenseName" validchars="- .">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        <label class="col-md-3 col-form-label text-right">
                                            License Gazette number</label>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtLicenseGazettenumber" CssClass="form-control" runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="FilteredTextBoxExtender3" runat="server"
                                                enabled="True" filtertype="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                targetcontrolid="txtLicenseGazettenumber" validchars="- .">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-3 col-form-label text-right">
                                            District</label>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ddlDist" AutoPostBack="true" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged1" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <label class="col-md-3 col-form-label text-right">
                                            Mandal</label>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ddlMandal" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-3 col-form-label text-right">
                                            Village</label>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ddlVillage" AutoPostBack="true" runat="server" CssClass="form-control ">
                                            </asp:DropDownList>
                                        </div>
                                        <label class="col-md-3 col-form-label text-right">
                                            Address</label>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="FilteredTextBoxExtender7" runat="server"
                                                enabled="True" filtertype="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                targetcontrolid="txtAddress" validchars="- .">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-3 col-form-label text-right">
                                            Primary Depot Code</label>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ddlPrimary" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <label class="col-md-3 col-form-label text-right">
                                            Primary Depot Active
                                        </label>
                                        <div class="col-md-3">
                                            <asp:RadioButtonList ID="rblPrimary" runat="server">
                                                <asp:ListItem Value="0">Yes</asp:ListItem>
                                                <asp:ListItem Value="1">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-3 col-form-label text-right">
                                            Secondary Depot Code</label>
                                        <div class="col-md-3">
                                            <asp:DropDownList ID="ddlSecondary" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <label class="col-md-3 col-form-label text-right">
                                            Secondary Depot Active
                                        </label>
                                        <div class="col-md-3">
                                            <asp:RadioButtonList ID="rblSecondary" runat="server">
                                                <asp:ListItem Value="0">Yes</asp:ListItem>
                                                <asp:ListItem Value="1">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-3 col-form-label text-right">
                                            Email ID</label>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtEmailID" CssClass="form-control" runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="FilteredTextBoxExtender12" runat="server"
                                                enabled="True" filtertype="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                targetcontrolid="txtEmailID" validchars="- @ .">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        <label class="col-md-3 col-form-label text-right">
                                            MobileNumber</label>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtMobileNumber" CssClass="form-control" runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="FilteredTextBoxExtender13" runat="server"
                                                enabled="True" filtertype="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                targetcontrolid="txtMobileNumber" validchars="- .">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <asp:Button ID="btn_Save" CssClass=" btn btn-info btn-out-dotted bt" runat="server"
                                            Text="Save" OnClick="btn_Save_Click" />
                                        <asp:Button ID="btn_Update" CssClass=" btn btn-warning btn-out-dotted" runat="server"
                                            Text="Update" Visible="false" OnClick="btn_Update_Click" />
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
                                <asp:GridView ID="GvDF" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered nowrap gvv" OnRowCommand="GvDF_RowCommand" OnPageIndexChanging="GvDF_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SNo">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Retailer Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRetailerCode" runat="server" Text='<%# Bind("RetailerCode") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Retailer Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRetailerName" runat="server" Text='<%# Bind("RetailerName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Retailer Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRetailer_Type" runat="server" Text='<%# Bind("Retailer_Type") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="License Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLicense_Name" runat="server" Text='<%# Bind("License_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="License Gazettenumber">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLicense_Gazette_number" runat="server" Text='<%# Bind("License_Gazette_number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="District">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDistrict" runat="server" Text='<%# Bind("District") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mandal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMandal" runat="server" Text='<%# Bind("Mandal") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Village">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVillage" runat="server" Text='<%# Bind("Village") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address">
                                            <ItemTemplate>
                                                <asp:Label ID="lbllAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PrimaryDepotCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrimary_Depot_Code" runat="server" Text='<%# Bind("Primary_Depot_Code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PrimaryDepotActive">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrimary_Depot_Active_YN" runat="server" Text='<%# Bind("Primary_Depot_Active_YN") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SecondaryDepotCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSecondary_Depot_Code" runat="server" Text='<%# Bind("Secondary_Depot_Code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SecondaryDepotActive">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSecondary_Depot_Active_YN" runat="server" Text='<%# Bind("Secondary_Depot_Active_YN") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EmailID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmailID" runat="server" Text='<%# Bind("EmailID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobileNumber" runat="server" Text='<%# Bind("MobileNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" ShowHeader="False">
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
