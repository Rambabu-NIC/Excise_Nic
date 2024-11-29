<%@ Page Title="" Language="C#" MasterPageFile="~/Event/Event.Master" AutoEventWireup="true" CodeBehind="EditEventRegistration.aspx.cs" Inherits="ExciseAPI.Event.EditEventRegistration" %>

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
         .event-color {
            color: black;
            text-align: left;
            padding-left: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Event Permit Registration Form</div>
            <div class="content">
                <asp:UpdatePanel ID="UpdatePanel1_Event" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="content">
                            <div class="page-body">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="card">
                                            <asp:Panel ID="Panel1" runat="server" BorderColor="#b2beb5"
                                                BorderStyle="Solid">
                                                <div class="card-block">
                                                    <div class="row">
                                                    </div>
                                                    <br />
                                                    <div class="form-group row col-md-12">
                                                        <label class="col-md-3 col-form-label text-left event-color">
                                                            Name of Applicant</label>

                                                        <div class="col-md-3">

                                                            <asp:DropDownList ID="DropDownList2" runat="server">
                                                                <asp:ListItem Text="Mr" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Miss" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Smt" Value="3"></asp:ListItem>
                                                            </asp:DropDownList>

                                                            <asp:TextBox ID="txtAppliName" MaxLength="150" CssClass="form-control " runat="server">
                                                            </asp:TextBox>

                                                        </div>

                                                        <label class="col-md-3 col-form-label text-left event-color">
                                                            Aadhaar Number</label>
                                                        <div class="col-md-3">
                                                            <asp:TextBox ID="txtAdharNum" MaxLength="12" CssClass="form-control" runat="server"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="form-group row col-md-12">
                                                        <label class="col-md-3 col-form-label text-left event-color">
                                                            Mobile Number</label>
                                                        <div class="col-md-3">
                                                            <asp:TextBox ID="txtMobile" CssClass="form-control" MaxLength="10" runat="server"></asp:TextBox>

                                                        </div>


                                                        <label class="col-md-3 col-form-label text-left event-color">
                                                            Email</label>
                                                        <div class="col-md-3">
                                                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="form-group row col-md-12">
                                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                                        <label class="col-md-3 col-form-label text-left event-color">
                                                            Age</label>
                                                        <div class="col-md-3">
                                                            <asp:TextBox ID="txtAge" CssClass="form-control" MaxLength="3" runat="server"></asp:TextBox>

                                                        </div>
                                                        <label class="col-md-3 col-form-label text-left event-color">
                                                            Father's Name</label>

                                                        <div class="col-md-3">
                                                            <asp:TextBox ID="txtFatherName" CssClass="form-control" runat="server"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="form-group row col-md-12">
                                                        <label class="col-md-3 col-form-label text-left event-color">
                                                            Residential Address</label>
                                                        <div class="col-md-3">
                                                            <asp:TextBox ID="txtAdd" TextMode="MultiLine" CssClass="form-control " runat="server" MaxLength="150"></asp:TextBox>

                                                        </div>
                                                    </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="card">
                                            <asp:Panel ID="pnldynamic" runat="server" BorderColor="#b2beb5"
                                                BorderStyle="Solid">

                                                <div class="col-md-12 text-left">
                                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                                        Text="Details of Premises to be Licensed">
                                                    </asp:Label>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <div class="card">
                                                            <div class="col-sm-12">
                                                            </div>
                                                            <br />
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    House Number/Door Number
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtHsNum" CssClass="form-control" runat="server"
                                                                        MaxLength="50"></asp:TextBox>

                                                                </div>
                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    Name Of the Premises
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtNmePrem" CssClass="form-control" runat="server" MaxLength="150"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    Street
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtStreet" CssClass="form-control " runat="server" MaxLength="50"></asp:TextBox>

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
                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    East
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtEast" CssClass="form-control " runat="server" MaxLength="10"></asp:TextBox>


                                                                </div>
                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    West
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtWest" CssClass="form-control " runat="server" MaxLength="10"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    North
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtNorth" CssClass="form-control " runat="server" MaxLength="10"></asp:TextBox>

                                                                </div>
                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    South
                                                                </label>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtSouth" CssClass="form-control " runat="server" MaxLength="10"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    Revenue District</label>
                                                                <div class="col-md-3">
                                                                    <asp:DropDownList ID="ddlRevDistrict" AutoPostBack="true" runat="server" CssClass="form-control "
                                                                        OnSelectedIndexChanged="ddlRevDistrict_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    Mandal</label>
                                                                <div class="col-md-3">
                                                                    <asp:DropDownList ID="ddlMandal" AutoPostBack="true" runat="server" CssClass="form-control "
                                                                        OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    Village/Ward</label>
                                                                <div class="col-md-3">
                                                                    <asp:DropDownList ID="ddlLocality" runat="server" CssClass="form-control "
                                                                        OnSelectedIndexChanged="ddlLocality_SelectedIndexChanged"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </div>


                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    Excise District</label>
                                                                <div class="col-md-3">
                                                                    <%-- <asp:DropDownList ID="ddlExciseDistrict"  runat="server" 
                                                                    CssClass="form-control "  AutoPostBack="true"
                                                                    onselectedindexchanged="ddlExciseDistrict_SelectedIndexChanged">
                                                                </asp:DropDownList>--%><asp:Label ID="lblExDistCode" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblExDist" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    Excise Station</label>
                                                                <div class="col-md-3">
                                                                    <%-- <asp:DropDownList ID="ddlExciseStation"  runat="server" CssClass="form-control ">
                                                                </asp:DropDownList>--%><asp:Label ID="lblExStationCd" runat="server" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblExStation" runat="server"></asp:Label>
                                                                    <asp:Label ID="lblGHMC" runat="server" Visible="false"></asp:Label>
                                                                </div>

                                                                <div class="col-md-3">
                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    Whether the Permises <br />is in Conformity with<br /> the Rule 7 of Telangana<br /> Excise(Grand of 
                                                                   Licence<br /> of Selling by In-House&amp;<br />Conditions of licence<br /> Rules 2005)</label>
                                                                <div class="col-md-3">
                                                                    <asp:DropDownList ID="ddlWhether" runat="server" CssClass="form-control ">
                                                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="2"></asp:ListItem>

                                                                    </asp:DropDownList>

                                                                </div>
                                                            </div>
                                                            <div class="form-group row col-md-12">
                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    Date  And Time of Event</label>
                                                                <div class="col-md-3">


                                                                    <asp:TextBox ID="txtEvnDate" AutoComplete="off" CssClass="form-control"
                                                                        runat="server" OnTextChanged="txtEvnDate_TextChanged" AutoPostBack="true"></asp:TextBox><span style="color: Red">(yyyy-MM-dd)</span>
                                                                    <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtEvnDate" Format="yyyy-MM-dd"> </cc1:CalendarExtender> 
                                                                    <br />
                                                                    <asp:DropDownList ID="ddlEvntTm" runat="server">
                                                                       
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <asp:HiddenField ID="hf" runat="server" />

                                                                <label class="col-md-3 col-form-label text-left event-color">
                                                                    Type Of Event</label>
                                                                <div class="col-md-3">


                                                                    <asp:DropDownList ID="ddlEvntType" AutoPostBack="true" runat="server"
                                                                        CssClass="form-control "
                                                                        OnSelectedIndexChanged="ddlEvntType_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="form-group row col-md-12">
                                                                    <label class="col-md-3 col-form-label text-left event-color">
                                                                        Event On Occasion Of</label>
                                                                    <div class="col-md-3">
                                                                        <asp:TextBox ID="txtEvent" CssClass="form-control" MaxLength="150" runat="server"></asp:TextBox>

                                                                    </div>
                                                                    <label class="col-md-3 col-form-label text-left event-color">
                                                                    </label>
                                                                    <div class="col-md-3">
                                                                        <asp:RadioButtonList ID="RbTypeP" runat="server" AutoPostBack="True"
                                                                            RepeatDirection="Vertical" Visible="false"
                                                                            OnSelectedIndexChanged="RbTypeP_SelectedIndexChanged">
                                                                            <asp:ListItem Text="4 Star And Above Hotels" Value="1">
                                                                            </asp:ListItem>
                                                                            <asp:ListItem Text="Other" Value="2">
                                                                            </asp:ListItem>
                                                                            
                                                                        </asp:RadioButtonList>
                                                                        <asp:RadioButtonList ID="Rbtype" runat="server" AutoPostBack="True" RepeatDirection="Vertical"
                                                                            OnSelectedIndexChanged="RbTypeT_SelectedIndexChanged" Visible="false">
                                                                            <asp:ListItem Text="Upto 1000" Value="1">
                                                                            </asp:ListItem>
                                                                            <asp:ListItem Text="1000 and above Upto 5000" Value="2">
                                                                            </asp:ListItem>
                                                                            <asp:ListItem Text="Above 5000" Value="3">
                                                                            </asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                                <div runat="server" class="form-group row col-md-12">
                                                                    <label class="col-md-3 col-form-label text-right">
                                                                    </label>
                                                                    <div class="col-md-3">
                                                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                                                    </div>
                                                                    <label class="col-md-3 col-form-label text-left event-color">
                                                                        License Fee</label>
                                                                    <div class="col-md-3">
                                                                        <asp:Label ID="lblFee" runat="server" Text=""></asp:Label>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                    <div class="text-center">
                                        <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                                            Text="Next" OnClick="btn_Update_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlRevDistrict" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlMandal" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlLocality" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlEvntType" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtAdharNum" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="RbTypeP" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
