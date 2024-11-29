<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.master" CodeBehind="Event_MandalTransfer.aspx.cs" Inherits="ExciseAPI.SHO.Event_MandalTransfer" %>
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
            <div class="head">Event Permits Mandal Update</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Registration No</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtAppRegNO" CssClass="form-control input-b-b" runat="server" PlaceHolder="Registration No"></asp:TextBox>
                        
                    </div>
                </div>
                <div class="content text-center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="btnGet" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server" OnClick="btnGet_Click"
                            Text="Get Data" />

                    </div>
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Label ID="lblErrorMessage" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="w-100 fl container-fluid" id="diveventMandal" runat="server" visible="false">
        <div class="block black bg-white">
            <div class="head">Event Mandal Transfer</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Registration No</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:TextBox ID="txtAppReg_NO" CssClass="form-control input-b-b" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:TextBox ID="txtName" CssClass="form-control input-b-b" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>

                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtMobileNumber" CssClass="form-control input-b-b" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">E-Mail ID</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtEmail" CssClass="form-control input-b-b" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <%--<div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Name_Premises</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtName_Premises" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Street</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtStreet" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">East</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtEast" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">West</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtWest" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">North</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtNorth" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">South</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtSouth" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">GHMC</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlGHMC" runat="server" CssClass="form-control ">
                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                            <asp:ListItem Text="No" Value="N"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Date Of Event</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtDate" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Time/Solt Event</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlEvntTm" runat="server" CssClass="form-control ">
                            <%--<asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Slot1(11AM-4PM)" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Slot1(4PM-11PM)" Value="2"></asp:ListItem>--%>
                <%-- </asp:DropDownList>

                    </div>
                </div>--%>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Revenue District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlRevDistrict" runat="server" CssClass="form-control " AutoPostBack="True"
                            OnSelectedIndexChanged="ddlRevDistrict_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mandal</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlMandal" runat="server" CssClass="form-control " AutoPostBack="True"
                            OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label ID="lblbmandal" runat="server" Text="Mandal" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Village/Ward</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlLocality" runat="server" CssClass="form-control " AutoPostBack="True"
                            OnSelectedIndexChanged="ddlLocality_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="lblExDist" ReadOnly="true" CssClass="form-control input-b-b" runat="server" placeholder="Excise District"></asp:TextBox>
                        <asp:Label ID="lblExDistCode" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise Station</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="lblExStation" ReadOnly="true" CssClass="form-control input-b-b" runat="server" placeholder="Excise Station"></asp:TextBox>
                        <asp:Label ID="lblGHMC" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblExStationCd" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>

            </div>
            <div class="content text-center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnUpdate" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server" OnClick="btnUpdate_Click"
                        Text="update" />

                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
            <asp:HiddenField ID="hf" runat="server" />
        </div>
    </div>


</asp:Content>

