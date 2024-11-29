<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExistingRetailerReport.aspx.cs" Inherits="ExciseAPI.NICAdmin.ExistingRetailerReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">District Wise Existing Retailers Report</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field" id="divdist" runat="server" visible="true">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlExDistrict" CssClass="form-control input-b-b" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Type</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlRType" CssClass="form-control input-b-b" runat="server" placeholder="Retailer Type"></asp:DropDownList>
                    </div>
                </div>
                 <div class="content text-center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="BtnGet" runat="server" Text="Get Data" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="BtnGet_Click" />
                    </div>
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
                 </div>
               
           
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="divRetailerIndividual" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div runat="server" id="DivGeneratedDate" visible="false">
                <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">
                    <div class="w-100 fl m-b-2">
                        <div class="fr">
                            <a href="#">
                                <asp:ImageButton runat="server" ID="btnAvailableImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnAvailableImageExportToPdf_Click" />
                            </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnAvailableImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnAvailableImageExportToExcel_Click" />
                                </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="content">
                <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                    <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                    <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Retailers Installment Report 
                                   
                    </h2>

                </div >
                <div id="div" runat="server" style="overflow-x:auto; overflow-y:hidden;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Retailer_Code" HeaderText="Retailer Code" />
                        <asp:BoundField DataField="Retailer_Name" HeaderText="Retailer Name" />
                         <asp:BoundField DataField="Type_Man_Nm" HeaderText="Retailer Type" />
                         <asp:BoundField DataField="ExDist" HeaderText="District" />
                        <asp:BoundField DataField="License_Name" HeaderText="License Name" />
                        <asp:BoundField DataField="License_No" HeaderText="License No" />
                        <asp:BoundField DataField="Excise_tax" HeaderText="Excise tax" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                        <asp:BoundField DataField="Lic_Validupto" HeaderText="License Valid" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
