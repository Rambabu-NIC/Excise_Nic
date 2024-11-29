<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.master" CodeBehind="SHO.aspx.cs" Inherits="ExciseAPI.SHO.SHO" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <style>
        .eventlinkbtn {
            padding: 5px 10px;
            font-size: 14px;
            line-height: 2;
            border-radius: 5px;
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Dashboard</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtfrm" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                          <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtfrm" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtto" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                          <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtto" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      

                    </div>
                </div>


            </div>
            <div class="content" align="center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnGet" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server" OnClick="btnGet_Click"
                        Text="Get Data" />

                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
            <asp:HiddenField ID="hf" runat="server" />
        </div>
        <div class="w-100 fl container-fluid" id="Div1" runat="server" visible="false">
            <div class="block black bg-white">

                <div class="content">
                    <asp:GridView ID="GvRpt" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                        <%--OnRowDataBound="gvdetails_RowDataBound" OnRowCommand="gvdetails_RowCommand"--%>
                        <Columns>


                            <asp:TemplateField HeaderText="Received">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkApplicationRecieved" runat="server" Text='<%# Bind("AppRecieved") %>'
                                        OnClick="lnkApplicationRecieved_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="For Approval">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPendingSHO" runat="server" Text='<%# Bind("PendingSHO") %>'
                                        OnClick="lnkPendingSHO_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Forwarded to DPEO">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPendingDPEO" runat="server" Text='<%# Bind("PendingDPEO") %>'
                                        OnClick="lnkPendingDPEO_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Permits issued">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkApplicationApproved" runat="server" Text='<%# Bind("Approved") %>'
                                        OnClick="lnkApplicationApproved_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rejected">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkApplicationRejected" runat="server" Text='<%# Bind("Rejected") %>'
                                        OnClick="lnkApplicationRejected_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>
                    </asp:GridView>


                </div>
            </div>
        </div>



        <div class="w-100 fl container-fluid" id="Div3" runat="server" visible="false">
            <div class="block black bg-white">

                <div class="content">
                    <asp:Label ID="appType" runat="server" Visible="false"></asp:Label>
                    <asp:GridView ID="GvRptDtls" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvRptDtls_PageIndexChanging" OnRowDataBound="GvRptDtls_RowDataBound" OnRowCommand="GvRptDtls_RowCommand">
                        <%--OnRowDataBound="gvdetails_RowDataBound" OnRowCommand="gvdetails_RowCommand"--%>


                        <Columns>
                            <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="AppReg_No" HeaderText="Reg.NO" />
                            <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                            <asp:BoundField DataField="Mob_No" HeaderText="Mobile Number" />
                            <asp:BoundField DataField="DateofEvent" HeaderText="Date of Event" />
                            <asp:BoundField DataField="ExDistName" HeaderText="Excise District" />
                            <asp:BoundField DataField="ExStationName" HeaderText="Excise Station" />
                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                            <asp:BoundField DataField="PayRemarks" HeaderText="Permit Fee Paid" />
                            <asp:BoundField DataField="AppStatus" HeaderText="Status" />
                            <asp:BoundField DataField="LicenseNo" HeaderText="License No" />
                            <asp:TemplateField HeaderText="View" ItemStyle-CssClass="txt-cnt">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkview" runat="server" Text="Click..!" CommandName="View" CommandArgument='<%# Eval("AppReg_No").ToString() + "," + Eval("Status").ToString() %>' ForeColor="Green"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>


                </div>
            </div>
        </div>



    </div>


</asp:Content>

