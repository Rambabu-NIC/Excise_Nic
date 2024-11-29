<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Supplier_AvailableReport.aspx.cs" Inherits="ExciseAPI.Supplier.Supplier_AvailableReport" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">


        <div class="block black bg-white" runat="server">
            <div class="head">Supplier's Manufacturer Wise Payment Report</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Manufacturer</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlManf" runat="server" class="form-control input-b-b" AutoPostBack="true" OnSelectedIndexChanged="ddlManf_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Minor Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlMinor" runat="server" class="form-control input-b-b" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlMinor_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <asp:Label ID="lblmfcd" runat="server" Text="Label" Visible="False"></asp:Label>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Sub Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlSubHead" runat="server" class="form-control input-b-b" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlSubHead_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type Of Payment</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlPayment" runat="server" class="form-control input-b-b" >
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="content text-center">
                    <div class="col-md-12">
                        <asp:Button ID="BtnGet" runat="server" Text="GetDetails" CssClass="btn btn-secondary" OnClick="BtnGet_Click" />
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

                                    <div id="div" runat="server" class="content" style="max-height: 400px; overflow-x:scroll; overflow-y:hidden; width: 100%;">
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
                                                <asp:BoundField DataField="Type_Man_Nm" HeaderText="Manufacturer" />
                                                <asp:BoundField DataField="BankDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" HeaderText="Bank Date" />
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
