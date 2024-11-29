<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EventPermit_Issued_Rejected_Report.aspx.cs" Inherits="ExciseAPI.Event.EventPermit_Issued_Rejected_Report" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Excise District Wise Event Permit Approved And Rejected Report</div>
            <div class="content">
              <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date<br />(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                    <asp:TextBox ID="txtfrm" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtfrm" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                      </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date<br />(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtto" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtto" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:DropDownList ID="ddlExDistrict" AutoPostBack="true" runat="server" CssClass="form-control input-b-b">
                            <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
               
                    </div>
             <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Status</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:DropDownList ID="ddlStatus" AutoPostBack="true" runat="server" CssClass="form-control input-b-b">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="4">Approved</asp:ListItem>
                            <asp:ListItem Value="5">Rejected</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                 </div>
             <div class="content" align="center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnGet" runat="server" Text="Get Data" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="btnGet_Click" />

                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center"></asp:Label>
                </div>
           </div>
            <div class="w-100 fl container-fluid" id="divgrid" runat="server" visible="false">
                <div class="block-liner block bg-white">
                    <div class="content">
                        <div class="w-100 fl m-b-2">
                            <div class="fr">
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnEventImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnEventImageExportToPdf_Click"
                                        Visible="false" />
                                </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnEventWiseImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnEventWiseImageExportToExcel_Click"
                                        Visible="false" /></a>
                            </div>
                        </div>


                        <div class="w-100 fl container-fluid" id="divgriddetails" runat="server" visible="true">
                            <div class="block-liner block black bg-white">
                                <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                                    <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                                    <br />
                                    <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Event Permit Report 
                                   <br />
                                        Between :
                                    <asp:Label ID="lblFromDate" runat="server"></asp:Label>
                                        AND
                                    <asp:Label ID="lblToDate" runat="server"></asp:Label>

                                    </h2>


                                </div>

                                <div class="content">
                                    <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DistName" HeaderText="Excise District" />
                                            <asp:BoundField DataField="AppReg_No" HeaderText="Event Permits" />
                                            <asp:BoundField DataField="StatusDes" HeaderText="Status" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
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
