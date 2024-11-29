<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ApplicationsReport.aspx.cs" Inherits="ExciseAPI.EODB.ApplicationsReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">
            <h1>Applications View</h1>
        </div>
        <div class="row justify-content-center" runat="server">
            <div class="col-lg-12 col-md-12 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                            <div class="content">
                                <asp:GridView ID="gvApplicationReportDetails" runat="server" AutoGenerateColumns="False" CssClass="table text-nowrap"
                                    OnRowDataBound="gvApplicationReportDetails_RowDataBound"
                                        OnRowCommand="gvApplicationReportDetails_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="APPlicationName" HeaderText="Application Type" />
                                        <asp:BoundField DataField="ApplicationNo" HeaderText="ApplicationNo" />
                                        <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                                        <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                                        <asp:BoundField DataField="DistrictName" HeaderText="District Name" />
                                        <asp:BoundField DataField="MandalName" HeaderText="Mandal Name" />
                                        <asp:BoundField DataField="VillageName" HeaderText="Village Name" />
                                        <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" DataFormatString="{0:d}" />
                                         <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbnViewM1Details" runat="server" Text="View" CommandName="lbnViewM1Details" CommandArgument='<%# Eval("ApplicationNo").ToString() %>'></asp:LinkButton>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
