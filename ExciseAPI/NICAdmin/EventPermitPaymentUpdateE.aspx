<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EventPermitPaymentUpdateE.aspx.cs" Inherits="ExciseAPI.NICAdmin.EventPermitPaymentUpdateE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Event Permit Payment Update</div>
            <div class="content">
                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12">
                            
                                    <div class="form-group row col-md-12">
                                        <asp:HiddenField ID="hf" runat="server" />
                                        <label class="col-md-3 col-form-label text-right">
                                            Registration NO
                                        </label>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtRegistrationNO" runat="server" CssClass="form-control" MaxLength="10">
                                            </asp:TextBox>
                                        </div>

                                        <label class="col-md-3 col-form-label text-right">
                                            Department Transaction No
                                        </label>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtDeptTransidE" runat="server" CssClass="form-control" MaxLength="25">
                                            </asp:TextBox>
                                        </div>
                                        
                                    </div>
                            <div class="content text-center">
                                        <div class="col-md-12">
                                            <asp:Button ID="btnGet" CssClass=" btn btn-secondary" runat="server"
                                                Text="Get Data" OnClick="btn_Get_Click" Visible="true" />
                                        </div>
                                            </div>
                                
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="card" id="data" runat="server" visible="false">
                        <div class="card-block">
                            <div class="table-responsive dt-responsive">
                                <%--OnRowCommand="GvDF_RowCommand"--%>
                                <asp:GridView ID="GvDF" runat="server" AllowPaging="True" PageSize="10" AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvDF_PageIndexChanging">
                                    <Columns>
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
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="form-group row col-md-12">
                                <label class="col-md-2 col-form-label text-right">
                                    Challan Number
                                </label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtChallanNumber" runat="server" CssClass="form-control" MaxLength="10">
                                    </asp:TextBox>
                                </div>
                                <label class="col-md-2 col-form-label text-right">
                                    Treasury Date
                                </label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtTreasuryDate" runat="server" CssClass="form-control" MaxLength="10">
                                    </asp:TextBox>
                                </div>
                                <label class="col-md-2 col-form-label text-right">
                                    Bank Date
                                </label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtBankDate" runat="server" CssClass="form-control" MaxLength="10">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row col-md-12">
                                <label class="col-md-2 col-form-label text-right">
                                    Bank Code
                                </label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtBankCode" runat="server" CssClass="form-control" MaxLength="10">
                                    </asp:TextBox>
                                </div>
                                <label class="col-md-2 col-form-label text-right">
                                    Bank Transaction ID
                                </label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtBankTransid" runat="server" CssClass="form-control" MaxLength="20">
                                    </asp:TextBox>
                                </div>
                                <label class="col-md-2 col-form-label text-right">
                                    Dept Trans ID
                                </label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtDeptTransid" runat="server" CssClass="form-control" MaxLength="25">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row col-md-12">
                                <asp:Button ID="btn_Save" CssClass=" btn btn-info btn-out-dotted bt" runat="server"
                                    Text="Save" OnClick="btn_Save_Click" Visible="true" />
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
