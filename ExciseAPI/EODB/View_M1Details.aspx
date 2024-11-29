<%@ Page Title="" Language="C#" MasterPageFile="~/EOB.Master" AutoEventWireup="true" CodeBehind="View_M1Details.aspx.cs" Inherits="ExciseAPI.EODB.View_M1Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">
            <h1>View Molasses_M1</h1>
        </div>
        <div class="row justify-content-center" runat="server">
            <div class="col-lg-12 col-md-12 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                            <div class="content">
                                <asp:GridView ID="gvM1DraftDetails" runat="server" AutoGenerateColumns="False" CssClass="table text-nowrap"
                                    OnRowDataBound="gvM1DraftDetails_RowDataBound"
                                        OnRowCommand="gvM1DraftDetails_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="NameofSugarFactory" HeaderText="NameofSugarFactory" />
                                        <asp:BoundField DataField="ApplicantName" HeaderText="ApplicantName" />
                                        <asp:BoundField DataField="DistrictName" HeaderText="District Name" />
                                        <asp:BoundField DataField="MandalName" HeaderText="Mandal Name" />
                                        <asp:BoundField DataField="VillageName" HeaderText="VillageName" />
                                        <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" DataFormatString="{0:d}" />
                                         <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbnViewM1Details" runat="server" Text="View" CommandName="lbnViewM1Details" CommandArgument='<%# Eval("UserName").ToString() %>'></asp:LinkButton>
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
