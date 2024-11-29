<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminReport.aspx.cs" Inherits="ExciseAPI.EODB.AdminReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">
            <h1>Report</h1>
        </div>
        <div class="row" runat="server">
            <div class="col-lg-12 col-md-12">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                            <div class="wrapper" runat="server" id="divgridDetails" visible="true">
                                <div class="col-md-12">
                                    <div class="content">
                                        <asp:GridView ID="gvreportdetails" runat="server" AutoGenerateColumns="False" CssClass="table text-nowrap">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="APPlicationName" HeaderText="Application" />
                                                <asp:BoundField DataField="ApplicationNo" HeaderText="Application No" />
                                                <asp:BoundField DataField="ApplicantName" HeaderText="ApplicantName" />
                                                <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                                                <asp:BoundField DataField="DistrictName" HeaderText="District Name" />
                                                <asp:BoundField DataField="MandalName" HeaderText="Mandal Name" />
                                                <asp:BoundField DataField="VillageName" HeaderText="VillageName" />
                                                <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" DataFormatString="{0:d}" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
