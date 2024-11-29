<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExciseStationRpt.aspx.cs" Inherits="ExciseAPI.DPEO_Admin.ExciseStationRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Excise Stations</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" CssClass="form-control input-b-b"
                            OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:DropDownList ID="ddlExDistrict" AutoPostBack="true" runat="server" CssClass="form-control input-b-b"
                            OnSelectedIndexChanged="ddlExDistrict_SelectedIndexChanged">
                            <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                </div>

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
                                                <asp:Label ID="lblExDistName" runat="server" Text='<%# Bind("ExDistName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mandal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMandalName" runat="server" Text='<%# Bind("MandName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Excise Station">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExStation" runat="server" Text='<%# Bind("ExStation") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--    <asp:TemplateField HeaderText="Type of Payment">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltypeDuty" runat="server" Text='<%# Bind("DF_Descr") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Department Transaction ID">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDeptTid" runat="server" Text='<%# Bind("DeptTransid") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                </div>

            </div>
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
