﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Supplier_Payments_StateWise.aspx.cs" Inherits="ExciseAPI.NICAdmin.Supplier_Payments_StateWise" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

    <div class="block black bg-white" runat="server">
            <div class="head">Supplier's Payment Report</div>
            <div class="content">
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Manufacturer</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlManf" runat="server" class="form-control input-b-b">
                         </asp:DropDownList>
                    </div>
                </div>
                  <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:DropDownList ID="ddlExDist" runat="server" CssClass="form-control input-b-b"
                           >
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="content text-center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="BtnGet" runat="server" Text="GetDetails" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="BtnGet_Click" />
                </div>
                <%--</div>--%>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
                </div>
                <div class="w-100 fl container-fluid" id="divgrid" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div class="content">
                
                   
                       
                            <div class="w-100 fl m-b-2">
                                <div class="fr">
                                    <a href="#">
                                        <asp:ImageButton runat="server" ID="btnManufacturerWiseImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnManufacturerWiseImageExportToPdf_Click"
                                            Visible="false" />
                                    </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnManufacturerWiseImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnManufacturerWiseImageExportToExcel_Click"
                                        Visible="false" /></a>
                                </div>
                            </div>
                        
                   
                    <div class="w-100 fl container-fluid" id="divgriddetails" runat="server" visible="true">
                        <div class="block-liner block black bg-white">
                            <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                                <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                                <br />
                                <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Supplier Manufacturer Wise Report 
                                  

                                </h2>

                                <%--<h2 style="text-align: center; font-weight: bold;">Bank Wise Report Between</h2>
                               <h3 ID="lblFromDate" runat="server"></h3>
                                <h3 ID="lblToDate" runat="server"></h3>--%>
                                <%--<h3 id="lblDatetime" runat="server" style="text-align: center; font-weight: bold;"></h3>--%>
                            </div>

                            <div class="content" style="overflow-x:scroll; overflow-y:hidden;">
                                <asp:GridView ID="gvManf" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Supplier_Code" HeaderText="Supplier Code" />
                                        <asp:BoundField DataField="Supplier_Name" HeaderText="Supplier Name" />
                                        <asp:BoundField DataField="License_No" HeaderText="License No" />
                                        <asp:BoundField DataField="DistrictName" HeaderText="Excise District" />
                                       <%-- <asp:BoundField DataField="DeptTransid" HeaderText="DeptTransid" />--%>
                                        <asp:BoundField DataField="BankDate" HeaderText="Bank Date" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                        <asp:BoundField DataField="ChallanNumber" HeaderText="Challan No" />
                                        <asp:BoundField DataField="BankCode" HeaderText="Bank Code" />
                                       <%-- <asp:BoundField DataField="BankStatus" HeaderText="Bank Status" />--%>
                                       
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
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
