<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard_ERCS_I.aspx.cs" Inherits="ExciseAPI.NICAdmin.Dashboard_ERCS_I" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <div class="w-100 fl container-fluid">

            <div class="block black bg-white">
                <div class="head">Supplier Manufacturer Wise Payment Details</div><%--ERCS Dashboard--%>
                <div class="content row">
                    <div class="row" runat="server" id="DIVEXD">
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Manufacturer Type</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        
                                <asp:DropDownList ID="ddl_Typeof_Md" runat="server" CssClass="form-control input-b-b"
                                    OnSelectedIndexChanged="ddl_Typeof_Md_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                         <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Manufacturer</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        
                                <asp:DropDownList ID="ddl_Typeof_P" runat="server" CssClass="form-control input-b-b"
                                    OnSelectedIndexChanged="ddl_Typeof_P_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                         <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                       
                                <asp:TextBox ID="txtfrm" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                 <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtfrm" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                            </div>
                        </div>
                         <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                       
                                <asp:TextBox ID="txtto" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                 <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtto" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                            </div>
                        </div>
                        <div class="content text-center">
                        <div class="col-xs-12 col-sm-12 txt-cnt">
                            <asp:Button ID="btn_GetDetails" runat="server" Text="GetDetails" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="btn_Details_Click" />
                            </div>
                        </div>
                        </div>
                        </div>

                        <asp:HiddenField ID="hfDate" runat="server" Visible="false" />
                        <asp:Label ID="dateGrid" runat="server" Visible="false" />
                        <asp:Label ID="gridData" runat="server" Visible="false" />
                        <div class="content">
                        
                        <div  runat="server" id="DIVEXS" style="max-height:600px;overflow-x:auto; overflow-y:hidden;" >
                             
                            <asp:GridView ID="GvRptDtls" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                                AllowPaging="True" PageSize="10" OnPageIndexChanging="GvRptDtls_PageIndexChanging"
                                EmptyDataText="No Data Found" OnRowCommand="GvRptDtls_RowCommand">
                                <Columns>

                                    <asp:TemplateField HeaderText="SNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Man_Code" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkTofM" runat="server" Text='<%# Bind("Type_Man_Cd") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type of Manufacture ">
                                        <ItemTemplate>
                                            <%-- <asp:Label ID="TofMdesc" runat="server" Font-Bold="true" Text='<%# Bind("Type_Man_Nm") %>'></asp:Label>--%>
                                            <asp:LinkButton ID="TofMdesc" runat="server" Text='<%# Bind("Type_Man_Nm") %>' CommandName="Man_Count" ForeColor="Blue" CausesValidation="false"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Supplier Code">
                                        <ItemTemplate>
                                            <asp:Label ID="Supplier_Code" runat="server"  Text='<%# Bind("Supplier_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Supplier Name">
                                        <ItemTemplate>
                                            <asp:Label ID="Supplier_Name" runat="server"  Text='<%# Bind("Supplier_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="PaymentCode" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDF_Code" runat="server" Text='<%# Bind("DF_Code") %>'
                                                CommandName="Man_Count" ForeColor="Blue" CausesValidation="false"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type of Payment ">
                                        <ItemTemplate>

                                            <asp:LinkButton ID="DF_Descr" runat="server" Text='<%# Bind("DF_Descr") %>'
                                                CommandName="Man_Count" ForeColor="Blue" CausesValidation="false"></asp:LinkButton>



                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--ChallanNumber,HOAccount as HeadOfAccount,BankDate,BankCode as BankName,BankTransid,DeptTransid,Amount--%>
                                    <asp:TemplateField HeaderText="Challan No">
                                        <ItemTemplate>
                                            <asp:Label ID="ChallanNumber" runat="server"  Text='<%# Bind("ChallanNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="Head Of Account">
                                        <ItemTemplate>
                                            <asp:Label ID="HeadOfAccount" runat="server"  Text='<%# Bind("HeadOfAccount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Bank Date">
                                        <ItemTemplate>
                                            <asp:Label ID="BankDate" runat="server"  Text='<%# Bind("BankDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Bank Name">
                                        <ItemTemplate>
                                            <asp:Label ID="BankName" runat="server"  Text='<%# Bind("BankName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Bank Transaction ID">
                                        <ItemTemplate>
                                            <asp:Label ID="BankTransid" runat="server"  Text='<%# Bind("BankTransid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--<asp:TemplateField HeaderText="Dept Transaction ID">
                                        <ItemTemplate>
                                            <asp:Label ID="DeptTransid" runat="server" Font-Bold="true" Text='<%# Bind("DeptTransid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>



                                    <asp:TemplateField HeaderText="Total Amount Paid">
                                        <ItemTemplate>
                                            <asp:Label ID="Amount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>
                            </asp:GridView>

                        </div>

                    </div>
                    <div id="Div3" class="table-responsive dt-responsive" runat="server">
                        <asp:Label ID="appType" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
       
    </asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
