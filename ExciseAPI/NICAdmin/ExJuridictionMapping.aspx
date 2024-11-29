<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExJuridictionMapping.aspx.cs" Inherits="ExciseAPI.NICAdmin.ExJuridictionMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Excise Jurisdiction Mapping</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control input-b-b"
                            OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlExDistrict" runat="server"
                            OnSelectedIndexChanged="ddlExDistrict_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control input-b-b">
                             <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise Station</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                         <asp:DropDownList ID="ddlExStation" runat="server"
                            OnSelectedIndexChanged="ddlExStation_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control input-b-b">
                             <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>


                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mandal</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlMandal" runat="server"
                            OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control input-b-b">
                             <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>


                    </div>
                </div>
                <div class="w-100 fl container-fluid" id="Jur" runat="server" visible="false">

        <div class="block black bg-white">
               <asp:GridView ID="GvDF" runat="server" AllowPaging="True" PageSize="100" AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvDF_PageIndexChanging"
                                    OnRowDataBound="GvDF_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SNo">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Village">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVillName" runat="server" Text='<%# Bind("VillName") %>'></asp:Label>
                                                <asp:Label ID="lblVillCode" runat="server" Visible="false" Text='<%# Bind("VillCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GHMC">
                                            <ItemTemplate>
                                                <asp:RadioButtonList ID="rblGHMC" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="Excise Station">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblExStationName" runat="server" Text='<%# Bind("ExStationName") %>'></asp:Label>
                                                                    <asp:Label ID="lblExStationCode" runat="server" Text='<%# Bind("ExStationCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                        <%--  <asp:TemplateField HeaderText="Excise District">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblExDistName" runat="server" Text='<%# Bind("ExDistName") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblExDistCode" runat="server" Text='<%# Bind("ExDistCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                        --%>
                                        <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                            <ItemTemplate>
                                                <%--<asp:ImageButton ID="btnEdit" runat="server" CommandName="edt" ImageUrl="~/Assets/images/edit.PNG" />&nbsp&nbsp  Enabled='<%# Eval("EFlag").ToString()!="0" ? false :  true %>'--%>
                                                <asp:CheckBox ID="ChkSelect" Checked='<%# Eval("Flag").ToString()!="0" ? true :  false %>'
                                                    runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

            </div>
                    </div>
                

            </div>
            <div class="content text-center">
                    <asp:Button ID="btn_Save" runat="server" Text="Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="btn_Save_Click" />
                </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
