<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DistrictWiseAbstract.aspx.cs" Inherits="ExciseAPI.DPEO_Admin.DistrictWiseAbstract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">District Wise Abstract</div>
            <div class="content">
                <asp:Label ID="lblDistrictName" runat="server" Visible="false"></asp:Label><br />
                <asp:Label ID="lblMandalName" runat="server" Visible="false"></asp:Label>

                <asp:Label ID="lblDCode" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblMCode" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblVCode" runat="server" Visible="false"></asp:Label>

                <asp:GridView ID="GvDistRpt" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                    <Columns>
                        <asp:TemplateField HeaderText="District">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDistName" runat="server" Text='<%# Bind("DistName") %>'
                                    OnClick="lnkDistName_Click"></asp:LinkButton>
                                <asp:Label ID="lblDistCode" runat="server" Text='<%# Bind("DistCode") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Received">
                            <ItemTemplate>
                                <asp:Label ID="lnkDRecieved" runat="server" Text='<%# Bind("AppRecieved") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="under process at SHO">
                            <ItemTemplate>
                                <asp:Label ID="lnkDPendingSHO" runat="server" Text='<%# Bind("PendingSHO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="under process at DPEO">
                            <ItemTemplate>
                                <asp:Label ID="lnkDPendingDPEO" runat="server" Text='<%# Bind("PendingDPEO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Permits issued">
                            <ItemTemplate>
                                <asp:Label ID="lnkDApproved" runat="server" Text='<%# Bind("Approved") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rejected">
                            <ItemTemplate>
                                <asp:Label ID="lnkDRejected" runat="server" Text='<%# Bind("Rejected") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GvMandalRpt" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                    Visible="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Mandal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkMandName" runat="server" Text='<%# Bind("MandName") %>'
                                    OnClick="lnkMandName_Click"></asp:LinkButton>
                                <asp:Label ID="lblDistCode" runat="server" Text='<%# Bind("DistCode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblMandCode" runat="server" Text='<%# Bind("MandCode") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Received">
                            <ItemTemplate>
                                <asp:Label ID="lnkMRecieved" runat="server" Text='<%# Bind("AppRecieved") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="under process at SHO">
                            <ItemTemplate>
                                <asp:Label ID="lnkMSHO" runat="server" Text='<%# Bind("PendingSHO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="under process at DPEO">
                            <ItemTemplate>
                                <asp:Label ID="lnkMDPEO" runat="server" Text='<%# Bind("PendingDPEO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Permits issued">
                            <ItemTemplate>
                                <asp:Label ID="lnkMApproved" runat="server" Text='<%# Bind("Approved") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rejected">
                            <ItemTemplate>
                                <asp:Label ID="lnkMRejected" runat="server" Text='<%# Bind("Rejected") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GvVillageRpt" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                    Visible="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Village">
                            <ItemTemplate>
                                <%-- <asp:Label ID="lblVillName" runat="server" Text='<%# Bind("VillName") %>'></asp:Label>--%>
                                <asp:LinkButton ID="lnkVillName" runat="server" Text='<%# Bind("VillName") %>'
                                    OnClick="lnkVillName_Click"></asp:LinkButton>
                                <asp:Label ID="lblDistCode" runat="server" Text='<%# Bind("DistCode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblMandCode" runat="server" Text='<%# Bind("MandCode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblVillCode" runat="server" Text='<%# Bind("VillCode") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Received">
                            <ItemTemplate>
                                <asp:Label ID="lnkApplicationRecieved" runat="server" Text='<%# Bind("AppRecieved") %>'></asp:Label>
                                <%--OnClick="lnkApplicationRecieved_Click"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="under process at SHO">
                            <ItemTemplate>
                                <asp:Label ID="lnkPendingSHO" runat="server" Text='<%# Bind("PendingSHO") %>'></asp:Label>
                                <%--OnClick="lnkPendingSHO_Click"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="under process at DPEO">
                            <ItemTemplate>
                                <asp:Label ID="lnkPendingDPEO" runat="server" Text='<%# Bind("PendingDPEO") %>'></asp:Label>
                                <%--OnClick="lnkPendingDPEO_Click"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Permits issued">
                            <ItemTemplate>
                                <asp:Label ID="lnkApplicationApproved" runat="server" Text='<%# Bind("Approved") %>'></asp:Label>
                                <%--OnClick="lnkApplicationApproved_Click"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rejected">
                            <ItemTemplate>
                                <asp:Label ID="lnkApplicationRejected" runat="server" Text='<%# Bind("Rejected") %>'></asp:Label>
                                <%--OnClick="lnkApplicationRejected_Click"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <div id="Div3" class="table-responsive dt-responsive" runat="server">
                    <asp:Label ID="appType" runat="server" Visible="false"></asp:Label>
                    <asp:GridView ID="GvRptDtls" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                        AllowPaging="True" PageSize="10" OnPageIndexChanging="GvRptDtls_PageIndexChanging"
                        EmptyDataText="No Data Found">
                        <Columns>
                            <asp:TemplateField HeaderText="SNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reg.NO">
                                <ItemTemplate>
                                    <asp:Label ID="lblAppRegNo" runat="server" Text='<%# Bind("AppReg_No") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Applicant Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplicantName" runat="server" Text='<%# Bind("ApplicantName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mobile Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblAppNo" runat="server" Text='<%# Bind("Mob_No") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date of Event">
                                <ItemTemplate>
                                    <asp:Label ID="lblDateofEvent" runat="server" Text='<%# Bind("DateofEvent") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Excise District">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplicationRecieved" runat="server" Text='<%# Bind("ExDistName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Excise Station">
                                <ItemTemplate>
                                    <asp:Label ID="lblExStationName" runat="server" Text='<%# Bind("ExStationName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Permit Fee Paid">
                                <ItemTemplate>
                                    <asp:Label ID="lblPayRemarks" runat="server" Text='<%# Bind("PayRemarks") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("AppStatus") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="License No">
                                <ItemTemplate>
                                    <asp:Label ID="lblLicenseNo" runat="server" Text='<%# Bind("LicenseNo") %>'></asp:Label>
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
