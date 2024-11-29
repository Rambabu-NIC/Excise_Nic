<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dtls_Retailers.aspx.cs" Inherits="ExciseAPI.Supplier.Dtls_Retailers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Retailers -Master</div>
            <div class="content">



                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Primary Depot Code</label>

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlPrimary" runat="server" CssClass="form-control">
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txt_RetailCd" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtRetailerName" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">RetailerType</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlRetailerType" runat="server" OnSelectedIndexChanged="ddlRetailerType_SelectedIndexChanged" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">License Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtLicenseName" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">License Gazette number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtLicenseGazettenumber" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">District</label>

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlDist" AutoPostBack="true" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged1" runat="server" CssClass="form-control">
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mandal</label>

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlMandal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" CssClass="form-control">
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Village</label>

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlVillage" AutoPostBack="true" runat="server" CssClass="form-control">
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Address</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtAddress" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Email ID</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtEmailID" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">MobileNumber</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtMobileNumber" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="content" align="center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="btn_Save" CssClass="btn btnn btn-sm text-uppercase m-t-10" runat="server"
                            Text="Save" OnClick="btn_Save_Click" />
                    </div>
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="btn_Update" CssClass="btn btnn btn-sm text-uppercase m-t-10" runat="server"
                            Text="Update" Visible="false" OnClick="btn_Update_Click" />
                    </div>
                </div>
                </div>

                <div class="w-100 fl container-fluid" id="divS" runat="server" visible="false">

                    <div class="block black bg-white">
                        <asp:GridView ID="GvDF" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
                            CssClass="table table-striped table-bordered nowrap gvv" OnRowCommand="GvDF_RowCommand"
                            OnPageIndexChanging="GvDF_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Retailer Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRetailerCode" runat="server" Text='<%# Bind("RetailerCode") %>'></asp:Label>
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
                                <%-- <asp:TemplateField HeaderText="SecondaryDepotCode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSecondary_Depot_Code" runat="server" Text='<%# Bind("Secondary_Depot_Code") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SecondaryDepotActive">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSecondary_Depot_Active_YN" runat="server" Text='<%# Bind("Secondary_Depot_Active_YN") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
