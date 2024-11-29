<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EventPermitSearch.aspx.cs" Inherits="ExciseAPI.DPEO_Admin.EventPermitSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Search Details</div>
            <div class="content">
                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card">
                                <div class="card-block">
                                    <div class="form-group row col-md-12">
                                        <asp:HiddenField ID="hf" runat="server" />
                                        <label class="col-md-2 col-form-label text-right">
                                            Registration No
                                        </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtRegistrationNO" runat="server" CssClass="form-control" MaxLength="10">
                                            </asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <center>
                                                                    <strong>(OR)</strong></center>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            Mobile No
                                        </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" MaxLength="10">
                                            </asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:Button ID="btnGet" CssClass=" btn btn-info btn-out-dotted bt" runat="server"
                                                Text="Get" OnClick="btn_Get_Click" Visible="true" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <%--<div class="card" id ="data" runat="server" visible="false">
                                            <div class="card-block">
                                                <div class="table-responsive dt-responsive">
                                                </div>
                                            </div>
                                        </div>--%>
                    <div class="row">
                        <div class="col-md-12">
                            <div id="Div3" class="table-responsive dt-responsive" runat="server">
                                <asp:Label ID="appType" runat="server" Visible="false"></asp:Label>
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
                                        <asp:TemplateField HeaderText="Reg.NO">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTypecode" runat="server" Text='<%# Bind("AppReg_NO") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblAppRegNo" runat="server" Text='<%# Bind("AppReg_NO") %>' Visible="true"></asp:Label>
                                                <%-- <asp:LinkButton ID="lblAppRegNo" runat="server" Text='<%# Eval("AppReg_No") %>' CommandName="View"
                                                                        ForeColor="Blue" CausesValidation="false"></asp:LinkButton>--%>
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
                                        <asp:TemplateField HeaderText="Received On">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReceivedOn" runat="server" Text='<%# Bind("ReceivedOn") %>'></asp:Label>
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
                                                <%-- <asp:LinkButton ID="lblLicenseNo" runat="server" Text='<%# Bind("LicenseNo") %>'
                                                                        CommandName="PerDown" ForeColor="Blue" CausesValidation="false"></asp:LinkButton>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="row" runat="server" id="pannelOK" visible="false">
                        <div class="col-md-8">
                            <div class="col-sm-12">
                                <div class="card">
                                    <asp:Panel ID="pnldynamic" runat="server" BorderColor="#b2beb5" BorderStyle="Solid">
                                        <div class="col-md-12 text-left">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                                Text="Details of Premises to be Licensed">
                                            </asp:Label>
                                        </div>
                                        <div class="card-block">
                                            <div class="row">
                                            </div>
                                            <div class="form-group row col-md-12">
                                                <label class="col-md-3 col-form-label text-right">
                                                    Name of Applicant:</label>
                                                <div class="col-md-3">
                                                    <asp:DropDownList Enabled="false" ID="DropDownList2" runat="server">
                                                        <asp:ListItem Text="Mr" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Miss" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Smt" Value="3"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:Label ID="txtAppliName" Enabled="false" MaxLength="150" runat="server">
                                                    </asp:Label>
                                                </div>
                                                <label class="col-md-3 col-form-label text-right">
                                                    Aadhaar Number:</label>
                                                <div class="col-md-3">
                                                    <asp:Label ID="txtAdharNum" Enabled="false" MaxLength="12" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group row col-md-12">
                                                <label class="col-md-3 col-form-label text-right">
                                                    Mobile Number:</label>
                                                <div class="col-md-3">
                                                    <asp:Label ID="txtMobile" Enabled="false" MaxLength="10" runat="server"></asp:Label>
                                                </div>
                                                <label class="col-md-3 col-form-label text-right">
                                                    Email:</label>
                                                <div class="col-md-3">
                                                    <asp:Label ID="txtEmail" Enabled="false" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group row col-md-12">
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                                <asp:Label ID="lblReg" Visible="false" runat="server" Text="Label"></asp:Label>
                                                <label class="col-md-3 col-form-label text-right">
                                                    Age:</label>
                                                <div class="col-md-3">
                                                    <asp:Label ID="txtAge" Enabled="false" MaxLength="3" runat="server"></asp:Label>
                                                </div>
                                                <label class="col-md-3 col-form-label text-right">
                                                    Father's Name:</label>
                                                <div class="col-md-3">
                                                    <asp:Label ID="txtFatherName" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group row col-md-12">
                                                <label class="col-md-3 col-form-label text-right">
                                                    Residential Address:</label>
                                                <div class="col-md-3">
                                                    <asp:Label ID="txtAdd" Enabled="false" TextMode="MultiLine" MaxLength="200" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                House Number/Door Number:
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtHsNum" Enabled="false" runat="server" MaxLength="10"></asp:Label>
                                            </div>
                                            <label class="col-md-3 col-form-label text-right">
                                                Name Of the Premises:
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtNmePrem" Enabled="false" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Street:
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtStreet" Enabled="false" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="container-fluid">
                                            <div class="col-md-12   text-left">
                                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                                    Text="Boundries">
                                                </asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                East:
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtEast" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                            </div>
                                            <label class="col-md-3 col-form-label text-right">
                                                West:
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtWest" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                North
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtNorth" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                            </div>
                                            <label class="col-md-3 col-form-label text-right">
                                                South:
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtSouth" Enabled="false" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Revenue District:</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label6" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblRDist" runat="server"></asp:Label>
                                            </div>
                                            <asp:HiddenField ID="HiddenField2" runat="server" />
                                            <label class="col-md-3 col-form-label text-right">
                                                Mandal:</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblbRMand" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Village/Locality:</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblbRVill" runat="server"></asp:Label>
                                            </div>
                                            <label class="col-md-3 col-form-label text-right">
                                                Excise District:</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblExDistCode" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblExDist" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Excise Station:</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblExStationCd" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblExStation" runat="server"></asp:Label>
                                                <asp:Label ID="lblGHMC" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Whether the Permises is in Conformity with the Rule 7 of Telangana Excise(Grant
                                                                    of Licence of Selling by In-House&amp;Conditions of licence Rules 2005)</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblRule7" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Date And Time of Event:</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="ddlEvntTm" Enabled="false" runat="server"></asp:Label>
                                                <asp:Label ID="txtEvnDate" Enabled="false" runat="server"></asp:Label>
                                            </div>
                                            <label class="col-md-3 col-form-label text-right">
                                                Type Of Event:</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label5" Enabled="false" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Event On Occasion Of:</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtEvent" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                                <asp:Label ID="lbleventid" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblevent" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <label class="col-md-3 col-form-label text-right">
                                                Licence Fee:
                                                                    <asp:Label ID="lblFee" Enabled="false" runat="server" Text=""></asp:Label>
                                                <br />
                                                Differential Fee:
                                                                    <asp:Label ID="lblDFee" runat="server" Text="0.00"></asp:Label>
                                            </label>
                                            <div class="col-md-3">
                                                &nbsp;
                                            </div>
                                        </div>
                                        <div id="Div4" runat="server" class="form-group row col-md-12">
                                            <div class="col-md-6">
                                                Premises Category :
                                                                    <asp:Label ID="lbleventtypee" runat="server" Text="Label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="container-fluid">
                                            <div class="col-md-12   text-left">
                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                                    Text="Date and Remarks Entry For SHO">
                                                </asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Date of the Inspection:</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtDtInsp" runat="server"></asp:Label>
                                            </div>
                                            <label class="col-md-3 col-form-label text-right">
                                                SHO Remarks:</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtRemarks" MaxLength="250" runat="server" TextMode="MultiLine"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Differential Amount:
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txt_DAmount" MaxLength="150" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <asp:Panel ID="Panel2" runat="server" BorderColor="#b2beb5" BorderStyle="Solid">
                                <div class="col-md-12 text-left">
                                    <asp:Label ID="lblPaymentDetailsL" runat="server" Font-Bold="True" Font-Size="18px"
                                        ForeColor="#0066CC" Text="Payment Details">
                                    </asp:Label>
                                </div>
                                <div class="card-block">
                                    <div class="form-group row ">
                                        <div class="col-md-12">
                                            <%--<asp:Label ID="lblPaymentDetailsT" runat="server"></asp:Label>--%>
                                            <asp:Repeater ID="dltPaymentDetails" runat="server" Visible="false">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblPaymentDetailsT" Text="<%#Eval("PaymentDetails")%>"></asp:Label><br />--%>
                                                    <p>
                                                        <%#Eval("PaymentDetails")%>
                                                    </p>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <asp:Label ID="lblPaymentDetailsNo" runat="server" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="row" id="PerGen" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="card">
                                            <asp:Panel ID="Panel1" runat="server" BorderColor="#b2beb5" BorderStyle="Solid" Visible="false">
                                                <asp:HiddenField ID="HiddenField3" runat="server" />
                                                <div class="card-block">
                                                    <div class="row" id="printableArea">
                                                        <div class="col-md-12">
                                                            <center>
                                                                                    <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="~/Excise-Logo.png"
                                                                                        Width="100px" />
                                                                                    <label style="font-size: large">
                                                                                        <b>TELANGANA STATE PROHIBITION &amp; EXCISE DEPARTMENT </b>
                                                                                    </label>
                                                                                </center>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <center>
                                                                                    <b>FORM EP-1<br />
                                                                                        [See Rule 4 (viii)]</b>
                                                                                </center>
                                                            <label class="col-sm-4 col-form-label text-left">
                                                                Licence No.
                                                                                    <asp:Label ID="lblPerLic" runat="server" Style="font-weight: 700"></asp:Label>
                                                            </label>
                                                            <p class="style3" style="text-decoration: underline">
                                                                <b>Event Permit for Retail Sale or Serve of all kinds of Indian Made Foreign Liquor
                                                                                        And Foreign Liquor to be consumed on the premises</b>
                                                            </p>
                                                            <p>
                                                                I,
                                                                                    <asp:Label ID="lblExDepoNm" runat="server" Text=""></asp:Label>, District prohibition
                                                                                    &amp; Excise officer of
                                                                                    <asp:Label ID="lblExd" runat="server" Text=""></asp:Label>
                                                                District in consideration of the payment of fee of Rs
                                                                                    <asp:Label ID="lblLicFee" runat="server" Text=""></asp:Label>
                                                                &nbsp; (Rupees twelve thousand Only) receipt of which is hereby acknowledged, hereby
                                                                                    licence you to sell/serve all kinds of Indian Made Foreign Liquor and Foreign Liquor
                                                                                    as per the following details:
                                                            </p>
                                                            <center>
                                                                                    <table style="border: thin solid #000000">
                                                                                        <tr>
                                                                                            <td>
                                                                                                Applicant Name:
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblAppNAme" runat="server" Style="font-weight: 700; text-align: left"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                Date and Time:
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblDttime" runat="server" Style="font-weight: 700"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                Premises:
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblAddress" runat="server" Style="font-weight: 700"></asp:Label><asp:Label
                                                                                                    ID="lblRAddress" runat="server" Style="font-weight: 700"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                Occasion:
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="lblOccasion" runat="server" Style="font-weight: 700"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </center>
                                                            <center>
                                                                                    <b>Boundaries</b></center>
                                                            <center>
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td style="border: thin solid #000000">
                                                                                                East:
                                                                                            </td>
                                                                                            <td style="border: thin solid #000000">
                                                                                                <asp:Label ID="lblBEast" runat="server" Text="" CssClass="ui-priority-primary"></asp:Label>
                                                                                            </td>
                                                                                            <td style="border: thin solid #000000">
                                                                                                West:
                                                                                            </td>
                                                                                            <td style="border: thin solid #000000">
                                                                                                <asp:Label ID="lblBWest" runat="server" Text="" CssClass="ui-priority-primary"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="border: thin solid #000000">
                                                                                                North:
                                                                                            </td>
                                                                                            <td style="border: thin solid #000000">
                                                                                                <asp:Label ID="lblBNorth" runat="server" Text="" CssClass="ui-priority-primary"></asp:Label>
                                                                                            </td>
                                                                                            <td style="border: thin solid #000000">
                                                                                                South:
                                                                                            </td>
                                                                                            <td style="border: thin solid #000000">
                                                                                                <asp:Label ID="lblSouth" runat="server" Text="" CssClass="ui-priority-primary"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </center>
                                                            <p>
                                                                Subject to the following conditions and stipulations to be observed by you
                                                            </p>
                                                            <ol type="1">
                                                                <li>The privilege extends to the sale or serve of all kinds of Indian Made Foreign Liquor
                                                                                        and Foreign Liquor at refreshment halls in connection with races/meetings and public
                                                                                        entertainments for consumption on the premises.</li>
                                                                <li>The licensee is prohibited from bottling the liquor.</li>
                                                                <li>The licensee is prohibited from purifying, colouring and flavouring the Indian Made
                                                                                        Foreign Liquor or mixing any materials therewith and from blending another kind
                                                                                        of Indian Made Foreign Liquor with it or keep in his possession other than Indian
                                                                                        Made Foreign Liquor authorised by this licence.</li>
                                                                <li>All Indian Made Foreign Liquor and Foreign Liquor sold/served under this licence
                                                                                        shall be obtained from the Telangana State Beverages Corporation Limited or A4 License.
                                                                                        <br />
                                                                </li>
                                                                <li>The licensee shall sell only duty paid Indian Made Foreign Liquor.</li>
                                                                <li>Any prohibition and excise officer not less than the rank of Prohibition & Excise
                                                                                        Sub-Inspector shall be empowered to check and verify the balance and receipts and
                                                                                        issue of the Indian Made Foreign Liquor.</li>
                                                                <li>The licence shall be subject to cancellation or suspension at will by the Commissioner
                                                                                        of Prohibition and Excise.</li>
                                                                <li>The licensee shall not act in any manner prejudicial to the interests of the revenues.</li>
                                                                <li>The licensee shall submit the particulars of IMFL and FL purchased, utilised and
                                                                                        balance to the District Prohibition and Excise Officer.</li>
                                                                <li>The Applicant Shall follow SOP of COVID-19.</li>
                                                            </ol>
                                                            <div class="row">
                                                                <label class="col-sm-4 col-form-label text-left">
                                                                    Dated:<strong>
                                                                        <asp:Label ID="lblPerDt" runat="server"></asp:Label></strong></label>
                                                            </div>
                                                            <div class="row">
                                                                <div style="float: right; text-align: right; margin-left: auto; margin-right: 35px;">
                                                                    <center>
                                                                                            District Prohibition &amp; Excise Officer</center>
                                                                    <center>
                                                                                            <%--Hyderabad--%>
                                                                                            <asp:Label ID="dpeoDistrictName" runat="server"></asp:Label></center>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
