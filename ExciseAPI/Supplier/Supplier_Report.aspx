<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Supplier_Report.aspx.cs" Inherits="ExciseAPI.Supplier.Supplier_Report" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">


        <div class="block black bg-white" runat="server">
            <div class="head">Supplier's Report</div>
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
                <div class="content text-center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnGet" runat="server" Text="Get Data" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="btnGet_Click" />

                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center"></asp:Label>
                </div>
                    </div>
                <div class="w-100 fl container-fluid" id="Div2" runat="server" visible="false">


                    <div id="divgridwithdate1" runat="server" visible="true">
                        <div runat="server" id="DivGeneratedDate" visible="false">
                            <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true" align="right">
                                <div class="w-100 fl m-b-2">
                                    <div class="fr">
                                        <%-- <a href="#">
                                        <asp:ImageButton runat="server" ID="btnEventImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnEventImageExportToPdf_Click"
                                            Visible="false" />
                                    </a>&nbsp;&nbsp;--%>
                                        <a href="#">
                                            <asp:ImageButton runat="server" ID="btnEventImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnEventImageExportToExcel_Click"
                                                Visible="false" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--   <asp:UpdatePanel ID="UpdatePartialRenderToGrid" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>--%>

                        <div class="block-liner block black bg-white" id="divgriddetails" runat="server" visible="true">
                            <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                                <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                                <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Event Permits Report 
                                   
                                 <br />
                                    Between :
                                    <asp:Label ID="lblFromDate" runat="server"></asp:Label>
                                    AND
                                    <asp:Label ID="lblToDate" runat="server"></asp:Label>
                                </h2>

                            </div>
                            <div id="Div5" class="table-responsive dt-responsive text-center" runat="server">
                                <asp:GridView ID="GvRptDtls" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                                    OnPageIndexChanging="GvRptDtls_PageIndexChanging"
                                    EmptyDataText="No Data Found">
                                    <%--OnRowCommand="GvRptDtls_RowCommand"--%>
                                    <Columns>

                                        <asp:TemplateField HeaderText="SNo">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--  <asp:TemplateField HeaderText="Man_Code" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblManf" runat="server" Font-Bold="true" Text='<%# Bind("Type_Man_Cd") %>'></asp:Label>
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Type of Manufacture ">
                                            <ItemTemplate>
                                                <%--<asp:Label ID="TofMdesc" runat="server" Font-Bold="true" Text='<%# Bind("Type_Man_Nm") %>'></asp:Label>--%>
                                                <asp:LinkButton ID="TofMdesc" runat="server" Text='<%# Bind("Type_Man_Nm") %>' CommandName="Man_Count" ForeColor="Blue" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Supplier Code">
                                            <ItemTemplate>
                                                <asp:Label ID="Supplier_Code" runat="server" Font-Bold="true" Text='<%# Bind("Supplier_Code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Supplier Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Supplier_Name" runat="server" Font-Bold="true" Text='<%# Bind("Supplier_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <%--<asp:TemplateField HeaderText="PaymentCode" Visible="false">
                                            <ItemTemplate>
                                                <%--<asp:Label ID="lblDF_Code" runat="server" Font-Bold="true" Text='<%# Bind("DF_Code") %>'></asp:Label>     --%>
                                        <%--                    <asp:LinkButton ID="lnkDF_Code" runat="server" Text='<%# Bind("DF_Code") %>'
                                                    CommandName="Man_Count" ForeColor="Blue" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type of Payment ">
                                            <ItemTemplate>
                                                <%--<asp:Label ID="DF_Descr" runat="server" Font-Bold="true" Text='<%# Bind("DF_Descr") %>'></asp:Label>  --%>

                                        <%--<asp:LinkButton ID="DF_Descr" runat="server" Text='<%# Bind("DF_Descr") %>'
                                                    CommandName="Man_Count" ForeColor="Blue" CausesValidation="false"></asp:LinkButton>



                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <%--ChallanNumber,HOAccount as HeadOfAccount,BankDate,BankCode as BankName,BankTransid,DeptTransid,Amount--%>
                                        <asp:TemplateField HeaderText="Challan Number">
                                            <ItemTemplate>
                                                <asp:Label ID="ChallanNumber" runat="server" Font-Bold="true" Text='<%# Bind("ChallanNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <%--<asp:TemplateField HeaderText="Head Of Account">
                                            <ItemTemplate>
                                                <asp:Label ID="HeadOfAccount" runat="server" Font-Bold="true" Text='<%# Bind("HeadOfAccount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="Bank Date">
                                            <ItemTemplate>
                                                <asp:Label ID="BankDate" runat="server" Font-Bold="true" Text='<%# Bind("BankDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Bank Name">
                                            <ItemTemplate>
                                                <asp:Label ID="BankName" runat="server" Font-Bold="true" Text='<%# Bind("BankCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Dept Transaction ID">
                                            <ItemTemplate>
                                                <asp:Label ID="DeptTransid" runat="server" Font-Bold="true" Text='<%# Bind("DeptTransid") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Total Amount Paid">
                                            <ItemTemplate>
                                                <asp:Label ID="Amount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>


                                    </Columns>
                                </asp:GridView>



                            </div>
                        </div>






                        <div class="row">
                            <div class="col-md-12">
                                <div id="Div3" class="table-responsive dt-responsive" runat="server">
                                    <asp:Label ID="appType" runat="server" Visible="false"></asp:Label>

                                </div>
                            </div>
                        </div>





                        <%-- <div class="row" runat="server" id="pannelOK">
                                            <div class="col-md-12 text-center">
                                                <div class="col-sm-12 text-center">
                                                    <rsweb:ReportViewer ID="ReptReg" Width="100%" Height="100%" runat="server" SizeToReportContent="true">
                                                    </rsweb:ReportViewer>
                                                </div>
                                            </div>
                                        </div>--%>
                        <%--   <div class="col-md-12 text-right">
                                         <asp:Button ID="imgbtnExcel"  Text="Download Excel"
                                                 
                                                    runat="server" onclick="imgbtnExcel_Click1" />
                                        </div>--%>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

