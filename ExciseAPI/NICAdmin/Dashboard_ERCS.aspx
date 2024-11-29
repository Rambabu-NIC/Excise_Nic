<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard_ERCS.aspx.cs" Inherits="ExciseAPI.NICAdmin.Dashboard_ERCS" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">ERCS Dashboard</div>
            <div class="content">
                <div class="row" runat="server" id="DIVEXD">
                    <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4" style="text-align: right">Type Of manufacturer</label>
                        <div class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                            <asp:DropDownList ID="ddl_Typeof_Md" runat="server" CssClass="form-control input-b-b"
                                OnSelectedIndexChanged="ddl_Typeof_Md_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4" style="text-align: right">Type Of manufacturer</label>
                        <div class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                            <asp:DropDownList ID="ddl_Typeof_P" runat="server" CssClass="form-control input-b-b"
                                OnSelectedIndexChanged="ddl_Typeof_P_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4" style="text-align: right">From Date</label>
                        <div class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                            <asp:TextBox ID="txtfrm" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                            <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtfrm" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                        </div>
                    </div>
                    <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4" style="text-align: right">To Date</label>
                        <div class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                            <asp:TextBox ID="txtto" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtto" Format="yyyy-MM-dd"> </cc1:CalendarExtender>      
                        </div>
                    </div>


                    <asp:HiddenField ID="hfDate" runat="server" Visible="false" />
                    <asp:Label ID="dateGrid" runat="server" Visible="false" />
                    <asp:Label ID="gridData" runat="server" Visible="false" />

                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="btn_GetDetails" runat="server" Text="GetDetails" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="btn_Details_Click" />

                    </div>
                    <div class="row" runat="server" id="DIVEXS">

                        <asp:GridView ID="GvRptDtls" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv" OnRowCommand="GvRptDtls_RowCommand">
                            <Columns>

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



                                <asp:TemplateField HeaderText="Manufacturewise_Count">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblApplicationRecieved" runat="server" Text='<%# Bind("AppRecieved") %>'></asp:Label>--%>
                                        <asp:LinkButton ID="Manufacturewise_count" runat="server" Text='<%# Bind("Manufacturewise_count") %>' CommandName="Man_Count" ForeColor="Blue" CausesValidation="false"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total Amount Paid">
                                    <ItemTemplate>
                                        <asp:Label ID="AMountPaid" runat="server" Text='<%# Bind("AMountPaid") %>'></asp:Label>

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
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
