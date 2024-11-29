<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard_Event.aspx.cs" Inherits="ExciseAPI.NICAdmin.Dashboard_Event" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Dashboard</div>
            <div class="content">
                <div id="Div1" class="page-body" runat="server">

                    <center>  
                                         <asp:Button ID="BackClick" runat="server" Text="Back" Visible="false" 
                                             onclick="BackClick_Click" /> </center>





                    <div class="row" runat="server" id="DIVEXD">
                        <div class="col-md-12">
                            <center>
                                            <b style="color: Red; font-size: 25px;">ERCS REPORTS </b>
                                        </center>
                        </div>
                        <div class="col-md-12">
                            <div id="Div2" class="table-responsive dt-responsive" runat="server">
                                <asp:GridView ID="GvRpt" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv" EmptyDataText="No Data Found" OnRowCommand="GvRptDtls_RowCommand">
                                    <Columns>

                                        <asp:TemplateField HeaderText="ExciseDistrictCode">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDistrictID" runat="server" Text='<%# Bind("ExDist_Cd") %>'
                                                    CommandName="CmdDistrictID"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Excise District Name ">
                                            <ItemTemplate>
                                                <%-- <asp:Literal ID="ExDist" runat="server" Text='<%# Eval("ExDist") %>'></asp:Literal>--%>


                                                <asp:LinkButton ID="ExDist" runat="server" Text='<%# Bind("ExDist") %>'></asp:LinkButton>


                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EventReg_Count">
                                            <ItemTemplate>
                                                <%--<asp:Label ID="lblApplicationRecieved" runat="server" Text='<%# Bind("AppRecieved") %>'></asp:Label>--%>
                                                <asp:LinkButton ID="EventReg_Count" runat="server" Text='<%# Bind("EventReg_Count") %>'
                                                    OnClick="EventReg_Count_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>





                    <div class="row" runat="server" id="DIVEXS">
                        <div class="col-md-12">
                            <center>
                                            <b style="color: Red; font-size: 25px;">Events of District -<asp:Label ID="Sel_Distict" runat="server" Text=""></asp:Label> </b>
                                        </center>
                        </div>
                        <div class="col-md-12">
                            <div id="Div5" class="table-responsive dt-responsive" runat="server">
                                <asp:GridView ID="GvRptDistict" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv" OnRowCommand="GvRptDtls_RowCommand">
                                    <Columns>

                                        <asp:TemplateField HeaderText="ExciseDistrictCode" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDistrictID" runat="server" Text='<%# Bind("ExDist_Cd") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Excise District Name " Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="ExDist" runat="server" Font-Bold="true" Text='<%# Bind("ExDist") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ExciseStationCode">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkStationID" runat="server" Text='<%# Bind("ExStationCode") %>'
                                                    CommandName="CmdStationCode"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Excise Station Name ">
                                            <ItemTemplate>
                                                <asp:Label ID="ExStation" runat="server" Font-Bold="true" Text='<%# Bind("ExStation") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="EventReg_Count">
                                            <ItemTemplate>
                                                <%--<asp:Label ID="lblApplicationRecieved" runat="server" Text='<%# Bind("AppRecieved") %>'></asp:Label>--%>
                                                <asp:LinkButton ID="EventReg_Count" runat="server" Text='<%# Bind("EventReg_Count") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>



                            </div>
                            <div id="Div4" class="table-responsive dt-responsive" runat="server">


                                <asp:GridView ID="GvRptDtls" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                                    AllowPaging="True" PageSize="10" OnPageIndexChanging="GvRptDtls_PageIndexChanging"
                                    EmptyDataText="No Data Found" OnRowCommand="GvRptDtls_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SNo">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="SHO Mobile Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSHOMOB" runat="server" Text='<%# Bind("SHOMob") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="Excise Station Name ">
                                            <ItemTemplate>
                                                <asp:Label ID="ExStation" runat="server" Font-Bold="true" Text='<%# Bind("ExStation") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Reg.NO">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTypecode" runat="server" Text='<%# Bind("AppReg_NO") %>'></asp:Label>
                                                <%--<asp:LinkButton ID="lblAppRegNo" runat="server" Text='<%# Eval("AppReg_No") %>' CommandName="View"
                                                                        ForeColor="Blue" CausesValidation="false"></asp:LinkButton>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Applicant Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApplicantName" runat="server" Text='<%# Bind("App_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Adhar Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAppNo" runat="server" Text='<%# Bind("Aadhaar") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReceivedOn" runat="server" Text='<%# Bind("Res_Address") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date of Regitration">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateofRegistration" runat="server" Text='<%# Bind("RegisteredDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date of Event">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateofEvent" runat="server" Text='<%# Bind("DateofEvent") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Description of Event">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEventDesc" runat="server" Text='<%# Bind("EventDescription") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>




                                        <asp:TemplateField HeaderText="Fee">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Fee") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("AppStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="License No">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblLicenseNo" runat="server" Text='<%# Bind("PermitId") %>'
                                                    CommandName="PerDown" ForeColor="Blue" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>



                <div class="row">
                    <div class="col-md-12">
                        <div id="Div3" class="table-responsive dt-responsive" runat="server">
                            <asp:Label ID="appType" runat="server" Visible="false"></asp:Label>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
