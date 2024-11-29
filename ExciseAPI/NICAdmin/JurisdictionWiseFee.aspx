<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="JurisdictionWiseFee.aspx.cs" Inherits="ExciseAPI.NICAdmin.JurisdictionWiseFee" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Event Permits Jurisdiction Wise Fee Details</div>
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
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="DivJ" runat="server" visible="false">

        <div class="block black bg-white">
            <div class="content">
                <div runat="server" id="DivGeneratedDate" visible="false">
                    <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">
                        <div class="w-100 fl m-b-2">
                            <div class="fr">
                                <%--<a href="#">--%>
                                   <%-- <asp:ImageButton runat="server" ID="btnBankWiseImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnBankWiseImageExportToPdf_Click"
                                        Visible="false" />
                                </a>&nbsp;&nbsp;--%>
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btneventImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btneventImageExportToExcel_Click"
                                        Visible="false" /></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="w-100 fl container-fluid" id="divgriddetails" runat="server" visible="true">
                    <div class="block-liner block black bg-white">
                        <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                            <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                            <br />
                            <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Jurisdiction Wise Event Permits Report 
                                  

                            </h2>

                            
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
                                <%--<asp:TemplateField HeaderText="District">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDistName" runat="server" Text='<%# Bind("DistName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Excise District">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExDistName" runat="server" Text='<%# Bind("ExDist") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Excise Station">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExStation" runat="server" Text='<%# Bind("ExStation") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mandal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMandalName" runat="server" Text='<%# Bind("MandName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Village">
                                    <ItemTemplate>
                                        <asp:Label ID="lblJurisdiction" runat="server" Text='<%# Bind("Jurisdiction") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPAYMENT" runat="server" Text='<%# Bind("PAYMENT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GHMC">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGHMC" runat="server" Text='<%# Bind("GHMC") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEvent" runat="server" Text='<%# Bind("Event") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Event Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEVENTDESC" runat="server" Text='<%# Bind("EVENTDESC") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                    </div>
                </div>
            </div>
        
                </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
