<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExciseSHORpt.aspx.cs" Inherits="ExciseAPI.DPEO_Admin.ExciseSHORpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">SHO Details</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:DropDownList ID="ddlRevDistrict" AutoPostBack="true" runat="server" CssClass="form-control input-b-b"
                            OnSelectedIndexChanged="ddlRevDistrict_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:DropDownList ID="ddlExDist" AutoPostBack="true" runat="server" CssClass="form-control input-b-b"
                            OnSelectedIndexChanged="ddlExDist_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                </div>
                 <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
                <asp:GridView ID="GvRpt" runat="server" AllowPaging="True" PageSize="50" AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvRpt_PageIndexChanging"
                    ShowFooter="true">
                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="District">
                            <ItemTemplate>
                                <asp:Label ID="lblDistName" runat="server" Text='<%# Bind("DistName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Excise District">
                            <ItemTemplate>
                                <asp:Label ID="lblExDistName" runat="server" Text='<%# Bind("ExDist") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SHO">
                            <ItemTemplate>
                                <asp:Label ID="lblSHOName" runat="server" Text='<%# Bind("SHO_ST_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile Number">
                            <ItemTemplate>
                                <asp:Label ID="lblSHOMobileno" runat="server" Text='<%# Bind("SHOMob") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User ID">
                            <ItemTemplate>
                                <asp:Label ID="lblSHOUserID" runat="server" Text='<%# Bind("SHOUsername") %>'></asp:Label>
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
