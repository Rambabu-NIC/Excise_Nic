<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EODB_Info.aspx.cs" Inherits="ExciseAPI.NICAdmin.EODB_Info" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">EODB Info</div>
            <div class="content">
                <div class="page-body" runat="server">
                    <div class="card">
                        <div class="card-block">
                            <div class="form-group row col-md-12">
                            </div>
                            <div class="form-group row col-md-12">
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Form Type</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                                        <asp:DropDownList ID="ddlFormType" CssClass="form-control input-b-b" runat="server">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date<span style="color: Red"> *</span></label>
                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                                    <asp:TextBox ID="txtfrm" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtfrm" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                </div>
                                    </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date<span style="color: Red"> *</span></label>
                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                                    <asp:TextBox ID="txtto" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtto" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                </div>
                                    </div>
                            </div>

                            <div class="form-group row col-md-12">
                                <label class="col-md-3 col-form-label text-right">
                                    Licence Registration/Renewal Granted Dashboard<span style="color: Red"> *</span></label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtLicenceNew" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtLicenceRenewal" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                            <div class="form-group row col-md-12">
                                <label class="col-md-3 col-form-label text-right">
                                    TOTAL NUMBER OF APPLICATIUONS RECEIVED<span style="color: Red"> *</span></label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtApplicationsNew" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtApplicationsRenewal" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row col-md-12">
                                <label class="col-md-3 col-form-label text-right">
                                    TOTAL NUMBER OF APPLICATIONS APPROVED<span style="color: Red"> *</span></label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtApprovedApplicationsNew" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtApprovedApplicationsRenewal" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row col-md-12">
                                <label class="col-md-3 col-form-label text-right">
                                    AVERAGE TIME TAKEN<span style="color: Red"> *</span></label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAvgTimeTakenNew" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAvgTimeTakenRenewal" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row col-md-12">
                                <label class="col-md-3 col-form-label text-right">
                                    MEDIAN TIME TAKEN<span style="color: Red"> *</span></label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtMedianNew" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtMedianRenewal" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row col-md-12">
                                <label class="col-md-3 col-form-label text-right">
                                    MINIMUM TIME TAKEN<span style="color: Red"> *</span></label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtMinTimeTakenNew" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtMinTimeTakenRenewal" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row col-md-12">
                                <label class="col-md-3 col-form-label text-right">
                                    MAXIMUM TIME TAKEN<span style="color: Red"> *</span></label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtMaxTimeTakenNew" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtMaxTimeTakenRenewal" runat="server" AutoCompleteType="Disabled" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-12 txt-cnt" >
                                <div class="col-xs-12 col-sm-12 txt-cnt">
                                    <asp:Button ID="BtnSubmit" runat="server" Text="Submit" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="BtnSubmit_Click" />
                                </div>
                                <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                           
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
