<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EventPermission.aspx.cs" Inherits="ExciseAPI.SHO.EventPermission" EnableEventValidation="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            
            <div class="head">Event Permits Pending For Approval</div>
            <div class="content">
                <div id="div" style="max-height:600px;overflow-x:auto;overflow-y:hidden;" >
                <asp:GridView ID="GvSupplier" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvSupplier_PageIndexChanging"
                    OnRowCommand="GvSupplier_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Application No">
                            <ItemTemplate>
                                <asp:Label ID="lblTypecode" runat="server" Text='<%# Bind("AppReg_NO") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="btnUpdate" runat="server" Visible="true" CommandName="View" ForeColor="Blue"
                                    CausesValidation="false" Text='<%#Eval("AppReg_NO")%>'></asp:LinkButton>
                                <asp:Label ID="LblAppID" runat="server" Text='<%# Bind("Reg_No") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Applicant Name">
                            <ItemTemplate>
                                <asp:Label ID="lblSuppCode" runat="server" Text='<%# Bind("App_Name") %>'></asp:Label>
                                
                                <%--<asp:Label ID="lblMandcode" runat="server" Text='<%# Bind("Res_Address") %>'></asp:Label>&nbsp;--%>
                                <%--<asp:Label ID="lblLicNo" runat="server" Text='<%# Bind("Name_Premises") %>'></asp:Label>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Res_Address") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Venue">
                            <ItemTemplate>
                                <asp:Label ID="lblVenue" runat="server" Text='<%# Bind("Name_Premises") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Event/Occasion">
                            <ItemTemplate>
                                <asp:Label ID="lblOccasion" runat="server" Text='<%# Bind("Event_Occasion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Of Event">
                            <ItemTemplate>
                                <asp:Label ID="lblVillName" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Event Slot">
                            <ItemTemplate>
                                <asp:Label ID="lblSlot" runat="server" Text='<%# Bind("Eventtime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Permit fee paid">
                            <ItemTemplate>
                                <asp:Label ID="lblAdd" runat="server" Text='<%# Bind("License_Fee") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--       <asp:TemplateField HeaderText="Event Permission">
                                                                <ItemTemplate>
                                                                    <asp:RadioButtonList ID="rbdstatus" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Documents">
                            <ItemTemplate>
                                <asp:LinkButton ID="lblLock" runat="server" CommandName="ViewDoc" Visible="true"
                                    Text="View" ForeColor="Blue"></asp:LinkButton>
                                <%-- <asp:LinkButton ID="btnShoUpdate" runat="server"  Text="Forward" CssClass="btn btn-primary" OnClick="btn_DpeoUpdate" ></asp:LinkButton>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="Additional Payment">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lblPay" runat="server" CommandName="ViewPay" Visible="true" Text="Additional"
                                                                        ForeColor="Blue" CausesValidation="false"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </div>
                </div>
        </div>
            </div>
  

    <div class="w-100 fl container-fluid" runat="server" id="pannelOK">
        <div class="block black bg-white">
            <div class="col-md-12">
                <div class="card">
                    <asp:UpdatePanel ID="UpdatePanel1_Event" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="content">
                                <asp:Panel ID="pnldynamic" runat="server" BorderColor="#b2beb5" BorderStyle="Solid">

                                    <div class="block black bg-white">
                                        <div class="head">Details of Premises to be Licensed</div>
                                        <%-- <div class="col-md-12 text-left">
                                          
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                            Text="Details of Premises to be Licensed">
                                        </asp:Label>
                                    </div>--%>
                                        <div class="card-block">
                                            <div class="row">
                                            </div>
                                            <div class="form-group row col-md-12">
                                                <label class="col-md-3 col-form-label text-right">
                                                    Name of Applicant</label>
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
                                                    Aadhaar Number</label>
                                                <div class="col-md-3">
                                                    <asp:Label ID="txtAdharNum" Enabled="false" MaxLength="12" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group row col-md-12">
                                                <label class="col-md-3 col-form-label text-right">
                                                    Mobile Number</label>
                                                <div class="col-md-3">
                                                    <asp:Label ID="txtMobile" Enabled="false" MaxLength="10" runat="server"></asp:Label>
                                                </div>
                                                <label class="col-md-3 col-form-label text-right">
                                                    Email</label>
                                                <div class="col-md-3">
                                                    <asp:Label ID="txtEmail" Enabled="false" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group row col-md-12">
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                                <asp:Label ID="lblReg" Visible="false" runat="server" Text="Label"></asp:Label>
                                                <label class="col-md-3 col-form-label text-right">
                                                    Age</label>
                                                <div class="col-md-3">
                                                    <asp:Label ID="txtAge" Enabled="false" MaxLength="3" runat="server"></asp:Label>
                                                </div>
                                                <label class="col-md-3 col-form-label text-right">
                                                    Father's Name</label>
                                                <div class="col-md-3">
                                                    <asp:Label ID="txtFatherName" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group row col-md-12">
                                                <label class="col-md-3 col-form-label text-right">
                                                    Residential Address</label>
                                                <div class="col-md-3">
                                                    <asp:Label ID="txtAdd" Enabled="false" TextMode="MultiLine" MaxLength="200" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="row">--%>
                                        <%--<div class="col-sm-12">--%>
                                        <%--<div class="card">--%>
                                        <%--<div class="col-sm-12">
                                                                        </div>--%>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                House Number/Door Number
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtHsNum" Enabled="false" runat="server" MaxLength="10"></asp:Label>
                                            </div>

                                        </div>
                                    </div>



                                    <div class="block black bg-white">
                                        <div class="head">Boundaries</div>

                                        <%--<div class="container-fluid">
                                        <div class="col-md-12   text-left">
                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                                Text="Boundaries">
                                            </asp:Label>
                                        </div>
                                    </div>--%>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Street
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtStreet" Enabled="false" runat="server"></asp:Label>
                                            </div>
                                            <label class="col-md-3 col-form-label text-right">
                                                Name Of the Premises
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtNmePrem" Enabled="false" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">

                                            <label class="col-md-3 col-form-label text-right">
                                                East
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtEast" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                            </div>
                                            <label class="col-md-3 col-form-label text-right">
                                                West
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
                                                South
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtSouth" Enabled="false" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Revenue District</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="Label6" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblRDist" runat="server"></asp:Label>
                                                <%-- <asp:DropDownList ID="ddlRevDistrict" Enabled="false" AutoPostBack="true" runat="server"
                                                                                     OnSelectedIndexChanged="ddlRevDistrict_SelectedIndexChanged">
                                                                                </asp:DropDownList>--%>
                                            </div>
                                            <asp:HiddenField ID="HiddenField2" runat="server" />
                                            <label class="col-md-3 col-form-label text-right">
                                                Mandal</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblbRMand" runat="server"></asp:Label>
                                                <%--  <asp:DropDownList ID="ddlMandal" Enabled="false" AutoPostBack="true" runat="server"
                                                                                     OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                                </asp:DropDownList>--%>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Village/Locality</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblbRVill" runat="server"></asp:Label>
                                                <%-- <asp:DropDownList ID="ddlLocality" Enabled="false" runat="server" >
                                                                                </asp:DropDownList>--%>
                                            </div>
                                            <label class="col-md-3 col-form-label text-right">
                                                Excise District</label>
                                            <div class="col-md-3">
                                                <%-- <asp:DropDownList ID="ddlExciseDistrict" Enabled="false" runat="server" 
                                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlExciseDistrict_SelectedIndexChanged" Visible="false">
                                                                                </asp:DropDownList>--%>
                                                <asp:Label ID="lblExDistCode" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblExDist" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Excise Station</label>
                                            <div class="col-md-3">
                                                <%-- <asp:DropDownList ID="ddlExciseStation" Enabled="false" runat="server" >
                                                                                </asp:DropDownList>--%>
                                                <asp:Label ID="lblExStationCd" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblExStation" runat="server"></asp:Label>
                                                <asp:Label ID="lblGHMC" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Whether the Permises is in<br /> Conformity with the Rule 7<br /> of Telangana Excise(Grant<br /> of Licence
                                                                    of Selling by In-House;<br />Conditions of licence<br /> Rules 2005)</label>
                                            <div class="col-md-3">
                                                <%-- <asp:DropDownList ID="ddlExciseStation" Enabled="false" runat="server" >
                                                                                </asp:DropDownList>--%>
                                                <asp:Label ID="lblRule7" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Date And Time of Event</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="ddlEvntTm" Enabled="false" runat="server"></asp:Label>
                                                <%--<asp:DropDownList ID="ddlEvntTm" Enabled="false" runat="server">
                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Slot1(11AM-4PM)" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Slot1(4PM-11PM)" Value="2"></asp:ListItem>
                                                                                </asp:DropDownList>--%>
                                                <asp:Label ID="txtEvnDate" Enabled="false" runat="server"></asp:Label>
                                            </div>
                                            <label class="col-md-3 col-form-label text-right">
                                                Type Of Event</label>
                                            <div class="col-md-3">
                                                <%-- <asp:DropDownList ID="ddlEvntType" Enabled="false" AutoPostBack="true" runat="server"
                                                                                    >
                                                                                </asp:DropDownList>--%>
                                                <asp:Label ID="Label5" Enabled="false" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Event On Occasion Of</label>
                                            <div class="col-md-3">
                                                <asp:Label ID="txtEvent" Enabled="false" MaxLength="150" runat="server"></asp:Label>
                                                <asp:Label ID="lbleventid" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblevent" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <label class="col-md-3 col-form-label text-right">
                                                Licence Fee :
                                    <asp:Label ID="lblFee" Enabled="false" runat="server" Text=""></asp:Label>
                                                <br />
                                                Differential Fee :<asp:Label ID="lblDFee" runat="server" Enabled="false" Text="0.00"></asp:Label>
                                            </label>
                                            <div class="col-md-3">
                                                &nbsp;
                                            </div>

                                            <%--<div runat="server" class="form-group row col-md-12">
                                        <div class="col-md-3">
                                            Premises Address    
                                   
                                        </div>
                                    </div>--%>
                                        </div>
                                        <div class="form-group row col-md-12">
                                            <label class="col-md-3 col-form-label text-right">
                                                Premises Address 
                                            </label>
                                            <div class="col-md-3">
                                                <asp:Label ID="lbleventtypee" runat="server" Text="Label"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                            </div>

                            <%-- <div class="container-fluid">
                                        <div class="col-md-12   text-left">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                                Text="Date and Remarks Entry For SHO">
                                            </asp:Label>
                                        </div>
                                    </div>--%>
                            <div class="block black bg-white">
                                <div class="head">Date and Remarks Entry For SHO</div>
                                <div class="form-group row col-md-12">
                                    <div class="col-md-6   text-left">
                                        <asp:RadioButtonList ID="RbTypeP" runat="server" AutoPostBack="True" RepeatDirection="Vertical"
                                            OnSelectedIndexChanged="RbTypeP_SelectedIndexChanged">
                                            <asp:ListItem Text="Forwarded For Approval" Value="1" Selected="True">
                                            </asp:ListItem>
                                            <asp:ListItem Text="Return for Additional Amount" Value="2">
                                            </asp:ListItem>
                                            <%-- <asp:ListItem Text="Clubs" Value="3">
                                                </asp:ListItem>--%>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="form-group row col-md-12">
                                    <label class="col-md-3 col-form-label text-right">
                                        Date of the Inspection</label>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtDtInsp" runat="server" CssClass="form-control"></asp:TextBox>
                                        <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDtInsp" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                    </div>
                                    <label class="col-md-3 col-form-label text-right">
                                        SHO Remarks</label>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtRemarks" MaxLength="250" runat="server" CssClass="form-control"
                                            TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row col-md-12">
                                    <label class="col-md-3 col-form-label text-right">
                                        Differential Amount
                                    </label>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txt_DAmount" MaxLength="150" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                
                                 <div class="content text-center">
                                    <asp:Button ID="btn_Update" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server" Text="Submit"
                                        OnClick="btn_Update_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                      
                                </div>
                            </div>
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="RbTypeP" />
                        </Triggers>
                    </asp:UpdatePanel>
                   
                </div>
                 
            </div>
           <div class="col-md-12">
                <asp:Panel ID="Panel2" runat="server" BorderColor="#b2beb5" BorderStyle="Solid">
                    <div class="block black bg-white">
                        <div class="head">Payment Details</div>
                        <%-- <div class="col-md-12 text-left">
                        <asp:Label ID="lblPaymentDetailsL" runat="server" Font-Bold="True" Font-Size="18px"
                            ForeColor="#0066CC" Text="Payment Details">
                        </asp:Label>
                    </div>--%>
                        <div class="form-group row col-md-12">
                            <div class="col-md-12   text-left">
                                <%--<asp:Label ID="lblPaymentDetailsT" runat="server"></asp:Label>--%>
                                <asp:Repeater ID="dltPaymentDetails" runat="server" Visible="false">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblPaymentDetailsT" Text="<%#Eval("PaymentDetails")%>"></asp:Label><br />--%>
                                        <p><%#Eval("PaymentDetails")%></p>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Label ID="lblPaymentDetailsNo" runat="server" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>


                </asp:Panel>
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" visible="false" id="RegDoc" runat="server">
        <div class="block black bg-white">
            <div class="col-md-12">
                <div class="card">
                    <div class="col-md-12">
                        <asp:Label ID="lblDocReg" runat="server" Text="Label"></asp:Label>
                        <asp:GridView ID="grddocs" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                            BorderWidth="1px" CellPadding="3" CellSpacing="2" CssClass="table table-striped table-bordered nowrap gvv" OnRowCommand="grddocs_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Sno" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Uploaded Documents" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldoccd" runat="server" Text='<%# Bind("UploadDco_Code") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbldocname" runat="server" Text='<%# Bind("UploadDco_Name") %>'></asp:Label>
                                        <asp:Label ID="lbldocsno" runat="server" Text='<%# Bind("UploadDocs_Sno") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Documents View" ItemStyle-VerticalAlign="Top">
                                    <ItemTemplate>
                                        <%-- <iframe id="iframedoc" runat="server" height="200px" src='<%# GetImage(Eval("UploadDco_File")) %>'
                                        width="200px"></iframe>--%>
                                        <asp:LinkButton ID="btnView" runat="server" CommandName="View" Text="View"></asp:LinkButton>
                                        <asp:Label ID="lbl_Apptype" runat="server" Text='<%#Eval("Application_Type")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblAppid" runat="server" Text='<%# Bind("Reg_No") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#378686" Font-Bold="True" ForeColor="White" />
                            <EmptyDataRowStyle HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                No Records
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" runat="server" visible="false" id="Payment">
        <div class="block black bg-white">
            <div class="col-md-12">
                <div class="card">
                    <div class="col-sm-12">
                    </div>
                    <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">
                            Reg Number
                        </label>
                        <div class="col-md-3">
                            <asp:Label ID="lblAppReg" runat="server" Text="Label"></asp:Label>
                        </div>
                        <%-- <label class="col-md-3 col-form-label text-right">
                                                        Diffential Amount
                                                    </label>
                                                    <div class="col-md-3">
                                                        <asp:TextBox ID="txt_DAmount" MaxLength="150" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <ajax:FilteredTextBoxExtender ID="txtDocRemarks_FilteredTextBoxExtender" runat="server"
                                                            Enabled="True" FilterType="Numbers" TargetControlID="txt_DAmount" ValidChars=".">
                                                        </ajax:FilteredTextBoxExtender>
                                                    </div>--%>
                    </div>
                    <div class="form-group row col-md-12">
                        <label class="col-md-3 col-form-label text-right">
                            Remarks
                        </label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDocRemarks" TextMode="MultiLine" MaxLength="150" runat="server"
                                CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="text-center">
                        <%-- <asp:Button ID="btnSave" CssClass=" btn btn-warning btn-out-dotted" runat="server"
                                                        Text="Submit" OnClick="btnSave_Click" />--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hf" runat="server" />
</asp:Content>
