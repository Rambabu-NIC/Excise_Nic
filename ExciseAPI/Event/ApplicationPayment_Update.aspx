<%@ Page Title="" Language="C#" MasterPageFile="~/Event/Event.Master" AutoEventWireup="true" CodeBehind="ApplicationPayment_Update.aspx.cs" Inherits="ExciseAPI.Event.ApplicationPayment_Update" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Application Payment Update</div>
            <div class="content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="card">
                                    <asp:Panel ID="Panel1" runat="server" BorderColor="#b2beb5" BorderStyle="Solid">
                                        <asp:HiddenField ID="hf" runat="server" />
                                        <div class="card-block">
                                            <div class="row">
                                                <div class="col-md-4">
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-sm-5 col-form-label text-left">
                                                            Registration No</label>
                                                        <div class="col-sm-6 col-form-label text-left">
                                                            <asp:TextBox ID="txtRegistrationNo" MaxLength="10" CssClass="form-control " runat="server">
                                                            </asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="content" align="center">

                                                        <div class="col-xs-12 col-sm-12 txt-cnt">
                                                            <asp:Label ID="lblmsg" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                            <asp:Image ID="Image2" runat="server" />
                                                            <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/Assets/images/RecaptchaLogo.png"
                                                                OnClick="btnImgRefresh_Click" />
                                                            <span class="form-bar"></span>

                                                            <div class="container-fluid" align="center">
                                                                <asp:TextBox ID="captch" runat="server" class="form-control" placeholder="Enter Captcha" CssClass="Regcaptcha" MaxLength="6"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="captch_FilteredTextBoxExtender1" runat="server"
                                                                    BehaviorID="captch_FilteredTextBoxExtender" FilterType="numbers"
                                                                    TargetControlID="captch"></ajaxToolkit:FilteredTextBoxExtender>
                                                                <span class="form-bar"></span>
                                                            </div>
                                                        </div>


                                                    </div>
                                                    <%--<center><b>( OR )</b></center>--%>

                                                    <%-- <div class="form-group row">
                                                        <div class="col-sm-6 col-form-label text-left">
                                                            <center>
                                                                                <asp:Button ID="BtnUpdate" CssClass=" btn btn-info btn-out-dotted bt" runat="server"
                                                                                    Text="Update Payment Details" OnClick="BtnUpdate_Click" />
                                                                
                                                        </center>
                                                        </div>

                                                    </div>--%>
                                                    <div class="content" align="center">

                                                        <div class="col-xs-12 col-sm-12 txt-cnt">
                                                            <asp:Button ID="BtnUpdate" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                                                                Text="Update Payment Details" OnClick="BtnUpdate_Click" />
                                                        </div>
                                                        <div class="col-xs-12 col-sm-12 txt-cnt">
                                                            <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div style="visibility: hidden" class="table-responsive dt-responsive">
                                                <%--OnRowCommand="GvDF_RowCommand"--%>
                                                <asp:GridView ID="GvDF" runat="server" AutoGenerateColumns="False"
                                                    CssClass="table table-striped table-bordered nowrap gvv" OnRowCommand="GvDF_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="ChkSelectAll" Text="Check All" AutoPostBack="true" runat="server"
                                                                    OnCheckedChanged="ChkSelectAll_CheckedChanged" onclick="SelectAllCheckboxes(this);" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkSelect" runat="server" onclick="OnOneCheckboxSelected(this);" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SNo">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="App Reg NO">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("AppReg_No") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Dept Trans ID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDeptTransid" runat="server" Text='<%# Bind("DeptTransid") %>'></asp:Label>
                                                                <%-- <asp:LinkButton ID="lblDeptTransid" runat="server" Text='<%# Bind("DeptTransid") %>'  CommandArgument='<%# Eval("DeptTransid") %>'></asp:LinkButton>--%><%--CommandName="Dept"--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>


                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
