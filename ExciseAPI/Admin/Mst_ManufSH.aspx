<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Mst_ManufSH.aspx.cs" Inherits="ExciseAPI.Admin.Mst_ManufSH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Sub Head Description</div>
            <div class="content">
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type of Manufacturing</label>

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddl_Manuf" runat="server" CssClass="form-control" AutoPostBack="true"
                            OnSelectedIndexChanged="ddl_ManufSelectedIndexChanged">
                        </asp:DropDownList>

                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Major Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlMinorHead" runat="server" CssClass="form-control" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlMinorHead_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Sub Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txt_SubHCd" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Sub Head Description</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txt_SubHNm" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                        <asp:Label ID="lblIDok" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
                </div>
            <div class="content" align="center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                            Text="Save" OnClick="btn_Save_Click" />
                    </div>
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="btn_Update" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                            Text="Update" OnClick="btn_Update_Click" Visible="false" />
                    </div>

                </div>
            </div>
        </div>


            <div class="w-100 fl container-fluid" id="Div3" runat="server" visible="false">

                <div class="block black bg-white">
                    <asp:GridView ID="GvDF" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
                        CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvDF_PageIndexChanging"
                        OnRowCommand="GvDF_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type of Manufacturing">
                                <ItemTemplate>
                                    <asp:Label ID="lblTypeCd" runat="server" Text='<%# Bind("Type_Man_Cd") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblMajHead" runat="server" Text='<%# Bind("Type_Man_Nm") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Major Head">
                                <ItemTemplate>
                                    <asp:Label ID="lblMHCd" runat="server" Text='<%# Bind("Minor_Head_Code") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblMHNM" runat="server" Text='<%# Bind("Minor_Head_Desc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub Head Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblSHCd" runat="server" Text='<%# Bind("Minor_Head_Code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub Head  Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblSHNM" runat="server" Text='<%# Bind("Sub_Head_Desc") %>'></asp:Label>
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
       
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
