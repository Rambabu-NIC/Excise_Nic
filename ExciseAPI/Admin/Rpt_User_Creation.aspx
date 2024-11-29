<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Rpt_User_Creation.aspx.cs" Inherits="ExciseAPI.Admin.Rpt_User_Creation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white" >
            <div class="head">Manufacturer Details</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Manufacturer Type</label>

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlTypeofmanu" runat="server" CssClass="form-control"  AutoPostBack="true"
                            OnSelectedIndexChanged="ddlTypeofmanu_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">Supplier</asp:ListItem>
                           <%-- <asp:ListItem Value="2">Manufacturer</asp:ListItem>--%>
                        </asp:DropDownList>

                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type Of Manufacturer</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlManf" runat="server" class="form-control input-b-b">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Status</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                       
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" >
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">Active</asp:ListItem>
                            <asp:ListItem Value="2">InActive</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="content text-center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="BtnGetData" runat="server" Text="Get Data" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="BtnGetData_Click" />
                </div>
                <%--</div>--%>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
                    </div>
            <div class="w-100 fl container-fluid" id="Div2" runat="server" visible="false">

                <div class="block black bg-white">
                     <div class="head">Manufacturer Details</div>
                    <asp:GridView ID="GvSupplier" runat="server"  AutoGenerateColumns="False"
                         CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvSupplier_PageIndexChanging" OnRowDataBound="GvSupplier_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supplier Code/Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSuppCode" runat="server" Text='<%# Bind("Supplier_Code") %>'></asp:Label><br />
                                    <asp:Label ID="lblSuppName" runat="server" Text='<%# Bind("Supplier_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Type Of Manufacturer">
                                <ItemTemplate>
                                    <asp:Label ID="lblManufacturer" runat="server" Text='<%# Bind("Type_Man_Nm") %>'></asp:Label>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mobile Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("Mobile") %>'></asp:Label>
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

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
