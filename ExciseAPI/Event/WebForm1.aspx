<%@ Page Title="" Language="C#" MasterPageFile="~/Event/Event.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ExciseAPI.Event.WebForm1" %>
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
            <div class="head">Event Permit Registration Form</div>
            <div class="content">
               
                <asp:UpdatePanel ID="UpdatePanel1_Event" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="card">
                             <div class="row">
                            <asp:Panel ID="Panel1" runat="server" BorderColor="#b2beb5"
                                BorderStyle="Solid">
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Name of Applicant</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        
                                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="Mr" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Miss" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Smt" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtAppliName" CssClass="form-control input-b-b" runat="server"></asp:TextBox>

                                        </div>
                                    
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Aadhaar Number</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtAdharNum" CssClass="form-control input-b-b" runat="server" MaxLength="12"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtMobile" CssClass="form-control input-b-b" runat="server" MaxLength="10"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Email</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtEmail" CssClass="form-control input-b-b" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Age</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtAge" CssClass="form-control input-b-b" runat="server" MaxLength="3"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Father's Name</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtFatherName" CssClass="form-control input-b-b" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Residential Address</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtAdd" TextMode="MultiLine" CssClass="form-control input-b-b" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="container-fluid row">
                                    <div class="card">
                                        <asp:Panel ID="pnldynamic" runat="server" BorderColor="#b2beb5"
                                            BorderStyle="Solid">

                                            <div class="col-md-12 text-left">
                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                                    Text="Details of Premises to be Licensed">
                                                </asp:Label>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">House Number/Door Number</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:TextBox ID="txtHsNum" CssClass="form-control input-b-b" MaxLength="50" runat="server"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Name Of the Premises</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:TextBox ID="txtNmePrem" CssClass="form-control input-b-b" MaxLength="150" runat="server"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Street</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:TextBox ID="txtStreet" CssClass="form-control input-b-b" MaxLength="50" runat="server"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="container-fluid">
                                                <div class="col-md-12   text-left">
                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#0066CC"
                                                        Text="Boundries">
                                                    </asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">East</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:TextBox ID="txtEast" CssClass="form-control input-b-b" MaxLength="10" runat="server"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">West</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:TextBox ID="txtWest" CssClass="form-control input-b-b" MaxLength="10" runat="server"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">North</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:TextBox ID="txtNorth" CssClass="form-control input-b-b" MaxLength="10" runat="server"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">South</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:TextBox ID="txtSouth" CssClass="form-control input-b-b" MaxLength="10" runat="server"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Revenue District</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:DropDownList ID="ddlRevDistrict" AutoPostBack="true" runat="server" CssClass="form-control "
                                                        OnSelectedIndexChanged="ddlRevDistrict_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mandal</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:DropDownList ID="ddlMandal" AutoPostBack="true" runat="server" CssClass="form-control "
                                                        OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Village/Ward</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:DropDownList ID="ddlLocality" runat="server" CssClass="form-control "
                                                        OnSelectedIndexChanged="ddlLocality_SelectedIndexChanged"
                                                        AutoPostBack="True">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise District</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:Label ID="lblExDistCode" runat="server" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblExDist" runat="server"></asp:Label>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise Station</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:Label ID="lblExStationCd" runat="server" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblExStation" runat="server"></asp:Label>
                                                    <asp:Label ID="lblGHMC" runat="server" Visible="false"></asp:Label>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                                                    Whether the Permises
                                                    <br />
                                                    is in Conformity with
                                                    <br />
                                                    the Rule 7 of Telangana<br />
                                                    Excise(Grand of 
                                                                   Licence<br />
                                                    of Selling by In-House<br />
                                                    &amp;Conditions of licence<br />
                                                    Rules 2005)</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:DropDownList ID="ddlWhether" runat="server" CssClass="form-control ">
                                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="2"></asp:ListItem>

                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Date  And Time of Event</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:TextBox ID="txtEvnDate" AutoComplete="off" CssClass="form-control"
                                                        runat="server" OnTextChanged="txtEvnDate_TextChanged" AutoPostBack="true"></asp:TextBox><span style="color: Red">(yyyy-MM-dd)</span>
                                                    <cc1:calendarextender id="Calendar1" enabled="True" popupbuttonid="imgPopup" runat="server" targetcontrolid="txtEvnDate" format="yyyy-MM-dd"> </cc1:calendarextender>
                                                    <br />
                                                    <asp:DropDownList ID="ddlEvntTm" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hf" runat="server" />


                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type Of Event</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:DropDownList ID="ddlEvntType" AutoPostBack="true" runat="server"
                                                        CssClass="form-control "
                                                        OnSelectedIndexChanged="ddlEvntType_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Event On Occasion Of</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:TextBox ID="txtEvent" CssClass="form-control input-b-b" MaxLength="150" runat="server"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"></label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
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
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"></label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

                                                </div>
                                            </div>
                                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">License Fee</label>
                                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                                    <asp:Label ID="lblFee" runat="server" Text=""></asp:Label>

                                                </div>
                                            </div>
                                            <div class="content" align="center">

                                                <div class="col-xs-12 col-sm-12 txt-cnt">
                                                    <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                                                        Text="Next" OnClick="btn_Update_Click" />
                                                </div>
                                                <div class="col-xs-12 col-sm-12 txt-cnt">
                                                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </asp:Panel>
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
