<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RetailersReport.aspx.cs" Inherits="ExciseAPI.NICAdmin.RetailersReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Retailer Wise CPE Payments Report</div>
            <div class="content">
                <%--<div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtFrom" CssClass="form-control input-b-b" runat="server" placeholder="From Date" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFrom" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date(yyyy-mm-dd)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtTo" CssClass="form-control input-b-b" runat="server" placeholder="To Date" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtTo" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                    </div>
                </div>--%>



                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Type</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlRType" CssClass="form-control input-b-b" runat="server" placeholder="Retailer Type" OnSelectedIndexChanged="ddlRType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Special Tax  </label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:CheckBox ID="RSP" Text="Check for Special Tax" AutoPostBack="true" runat="server" OnCheckedChanged="RSP_CheckedChanged" />
                    </div>
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
    <div class="w-100 fl container-fluid" id="divgrid" runat="server" visible="false">
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

                </div>
                <div class="content">
                    <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                        OnRowCommand="gvdetails_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>

                                <ItemStyle CssClass="txt-cnt"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="District Name">
                                <ItemTemplate>
                                    <asp:Label ID="Exdist" runat="server" Text='<%# Bind("Exdist") %>'></asp:Label>
                                    <asp:Label ID="DDOCode" runat="server" Text='<%# Bind("DDOCode") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="SlabNo" runat="server" Text='<%# Bind("SlabNo") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="Installment_No" runat="server" Text='<%# Bind("Installment_No") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="Sub_Head" runat="server" Text='<%# Bind("Sub_Head") %>' Visible="false"></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="R_Type" HeaderText="Retailer Type" />
                            <asp:BoundField DataField="Typeofpayment" HeaderText="Typeofpayment" />
                            <asp:BoundField DataField="Installment_No" HeaderText="Installmen Type" />
                            <asp:BoundField DataField="SlabNo" HeaderText="SlabNo" />
                            <asp:BoundField DataField="Slab_Amount" HeaderText="SlabAmount" />
                            <asp:BoundField DataField="Retailerscount" HeaderText="No of Retailers Paid" />

                            <asp:BoundField DataField="Amount_Recieved" HeaderText="RecievedAmount" />
                            <asp:BoundField DataField="PenalityAmount" HeaderText="Penality Amount " />
                            <asp:BoundField DataField="IsLateFee" HeaderText="Is LateFee" />
                            <asp:TemplateField HeaderText="View" ItemStyle-CssClass="txt-cnt" Visible="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkview" runat="server" Text="Click..!" CommandName="View" ForeColor="Green"></asp:LinkButton>
                                </ItemTemplate>

                                <ItemStyle CssClass="txt-cnt"></ItemStyle>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

    </div>


    <div class="w-100 fl container-fluid" id="divgridSpec" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div runat="server" id="DivGenerated2" visible="false">
                <div class="w-100 fl m-b-2" id="div3" runat="server" visible="true">
                    <div class="w-100 fl m-b-2">
                        <div class="fr">
                            <a href="#">
                                <asp:ImageButton runat="server" ID="ImageSpecialPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="ImageSpecialPdf_Click" />
                            </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="ImagespecialExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="ImagespecialExcel_Click" />
                                </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="content">
                <div id="divheading1" class="col-md-12 text-center" runat="server" visible="false">
                    <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                    <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Retailers Installment Report 
                                   
                    </h2>

                </div>
                <asp:GridView ID="gvdetails_spec" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                    OnRowCommand="gvdetails_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>

                            <ItemStyle CssClass="txt-cnt"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="District Name">
                            <ItemTemplate>
                                <asp:Label ID="Exdist" runat="server" Text='<%# Bind("Exdist") %>'></asp:Label>
                                <asp:Label ID="DDOCode" runat="server" Text='<%# Bind("DDOCode") %>' Visible="false"></asp:Label>

                                <asp:Label ID="Installment_No" runat="server" Text='<%# Bind("Installment_No") %>' Visible="false"></asp:Label>
                                <asp:Label ID="Sub_Head" runat="server" Text='<%# Bind("Sub_Head") %>' Visible="false"></asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="R_Type" HeaderText="Retailer Type" />
                        <asp:BoundField DataField="Typeofpayment" HeaderText="Typeofpayment" />
                        <asp:BoundField DataField="Installment_No" HeaderText="Installmen Type" />

                        <asp:BoundField DataField="Retailerscount" HeaderText="No of Retailers Paid" />

                        <asp:BoundField DataField="Amount_Recieved" HeaderText="RecievedAmount" />
                        <asp:BoundField DataField="PenalityAmount" HeaderText="Penality Amount " />
                        <asp:BoundField DataField="IsLateFee" HeaderText="Is LateFee" />
                        <asp:TemplateField HeaderText="View" ItemStyle-CssClass="txt-cnt" Visible="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkview" runat="server" Text="Click..!" CommandName="View" ForeColor="Green"></asp:LinkButton>
                            </ItemTemplate>

                            <ItemStyle CssClass="txt-cnt"></ItemStyle>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>


    </div>



    <div class="w-100 fl container-fluid" id="div1" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div class="content">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                    OnRowCommand="gvdetails_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Exdist" HeaderText="District Name" />
                        <asp:BoundField DataField="Retailer_Code" HeaderText="Retailer Code" />
                        <asp:BoundField DataField="Retailer_Name" HeaderText="Retailer Name" />
                        <asp:BoundField DataField="R_Type" HeaderText="Retailer Type" />
                        <asp:BoundField DataField="Installment_No" HeaderText="Installmen Type" />
                        <asp:BoundField DataField="Amount_Recieved" HeaderText="Amount" />
                        <asp:BoundField DataField="PenalityAmount" HeaderText="Penality Amount " />
                        <asp:BoundField DataField="IsLateFee" HeaderText="Is LateFee" />


                    </Columns>
                </asp:GridView>
            </div>
        </div>


    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
