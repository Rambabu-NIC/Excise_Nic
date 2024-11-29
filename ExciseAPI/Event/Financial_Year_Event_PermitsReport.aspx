<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Financial_Year_Event_PermitsReport.aspx.cs" Inherits="ExciseAPI.Event.Financial_Year_Event_PermitsReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Bank Wise Report</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Year</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlFyid" runat="server" class="form-control input-b-b">
                            <asp:ListItem Value="0">Select Year</asp:ListItem>
                            <asp:ListItem Value="1">2021-2022</asp:ListItem>
                            <asp:ListItem Value="2">2022-2023</asp:ListItem>
                            <asp:ListItem Value="3">2023-2024</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                </div>
               
               
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="BtnGet" runat="server" Text="Get Details" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="BtnGet_Click" />
                </div>
                <%--</div>--%>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="divgrid" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div class="content">
                <div id="divgridwithdate1" runat="server" visible="true">
                    <div runat="server" id="DivGeneratedDate" visible="false">
                        <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">
                            <div class="w-100 fl m-b-2">
                                <div class="fr">
                                    <a href="#">
                                        <asp:ImageButton runat="server" ID="btnEventPermitExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnEventPermitExportToPdf_Click"
                                            Visible="false" />
                                    </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnEventPermitExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnEventPermitExportToExcel_Click"
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
                                <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Event Permit Financial Year Wise Report 
<%--                                   <br />
                                    Between :
                                    <asp:Label ID="lblFromDate" runat="server"></asp:Label>
                                    AND
                                    <asp:Label ID="lblToDate" runat="server"></asp:Label>--%>

                                </h2>

                               
                            </div>

                            <div class="content">
                                <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="MonthName" HeaderText="Month"/>
                                        <asp:BoundField DataField="Year" HeaderText="Year"/>
                                        <asp:BoundField DataField="EventCount" HeaderText="No.Of Events For The Year"/>
                                        <asp:BoundField DataField="Amount" HeaderText="Amount"/>
                                        
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
