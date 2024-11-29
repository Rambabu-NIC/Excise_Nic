<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HOA.aspx.cs" Inherits="ExciseAPI.Admin.HOA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">HOA</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type of Manufactory</label>

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlManFac" runat="server" CssClass="form-control"  onselectedindexchanged="ddlManFac_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Major Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtMajor" CssClass="form-control input-b-b" runat="server" Text="0039" MaxLength="4" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                  <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Sub Major Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtSMajor" CssClass="form-control input-b-b" runat="server" Text="00" MaxLength="2" AutoCompleteType="Disabled"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Minor Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlMinorHead" runat="server" CssClass="form-control" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlMinorHead_SelectedIndexChanged">
                        </asp:DropDownList>

                    </div>
                </div>


                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Group Sub Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txt_GPHead" CssClass="form-control input-b-b" runat="server" MaxLength="2" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Sub Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlSubHead" runat="server" CssClass="form-control">
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Detailed Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txt_DetHead" CssClass="form-control input-b-b" runat="server" MaxLength="3" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">SubDetailed Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txt_SubDtHead" CssClass="form-control input-b-b" runat="server" Text="000" MaxLength="3" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <asp:Label ID="lblIDok" runat="server" Visible="false"></asp:Label>
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
            <div class="w-100 fl container-fluid" id="divH" runat="server" visible="false">

                <div class="block black bg-white">
                    <asp:GridView ID="GvHOA" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
                        CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvHOA_PageIndexChanging"
                        OnRowCommand="GvHOA_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type of MAnufactory">
                                <ItemTemplate>
                                    <asp:Label ID="lblTypeManNm" runat="server" Text='<%# Bind("Type_Man_Nm") %>'></asp:Label>
                                    <asp:Label ID="lblTypeMan" runat="server" Text='<%# Bind("Type_of_Manu") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Major Head">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblMajHead" runat="server" Text='<%# Bind("Major_Head") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Sub Major Head">
                                <ItemTemplate>
                                    <asp:Label ID="lblSMajHead" runat="server" Text='<%# Bind("SubMajor_Head") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Minor Head">
                                <ItemTemplate>
                                    <asp:Label ID="lblMinHead" runat="server" Text='<%# Bind("Minor_Head")%>'></asp:Label>
                                    <asp:Label ID="lblMinname" runat="server" Text='<%# Bind("Minor_Head_Desc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Group Sub Head">
                                <ItemTemplate>
                                    <asp:Label ID="lblGPHead" runat="server" Text='<%# Bind("Group_Head") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub Head">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubHead" runat="server" Text='<%# Bind("Sub_Head") %>'></asp:Label>
                                    <asp:Label ID="lblSubHNm" runat="server" Text='<%# Bind("Sub_Head_Desc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Details Head">
                                <ItemTemplate>
                                    <asp:Label ID="lblDtHead" runat="server" Text='<%# Bind("Detailed_Head") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SubDetails Head">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubDtHead" runat="server" Text='<%# Bind("subDetailed_Head") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Name of Treasury">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNameOfTrasury" runat="server" Text='<%# Bind("Name_Of_Treasury") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="NPN">
                                <ItemTemplate>
                                    <asp:Label ID="lblnpn" runat="server" Text='<%# Bind("Npn") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VC">
                                <ItemTemplate>
                                    <asp:Label ID="lblvc" runat="server" Text='<%# Bind("VC") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NC">
                                <ItemTemplate>
                                    <asp:Label ID="lblnc" runat="server" Text='<%# Bind("NC") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HOA CODE">
                                <ItemTemplate>
                                    <asp:Label ID="lblHoaCode" runat="server" Text='<%# Bind("HOA_Code") %>'></asp:Label>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
