<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventUpdate.aspx.cs" Inherits="ExciseAPI.NICAdmin.EventUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Event Payment Update</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Registration NO</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtRegistrationNO" CssClass="form-control input-b-b" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                </div>



            </div>
            <div class="col-xs-12 col-sm-12 txt-cnt">
                <asp:Button ID="btnGet" runat="server" Text="Get" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="btn_Get_Click" Visible="true"  />
            </div>

        </div>
        <asp:Label ID="lblReg" runat="server" Visible="false"></asp:Label>
        <div class="w-100 fl container-fluid" runat="server" id="data" visible="false">

        <div class="block black bg-white">
        <asp:GridView ID="GvDF" runat="server" AllowPaging="True" PageSize="10" AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvDF_PageIndexChanging" OnRowCommand="GvDF_RowCommand">
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
                                        <asp:TemplateField HeaderText="Challan Number" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChallan" runat="server" Text='<%# Bind("ChallanNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Treasury Date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTreasury" runat="server" Text='<%# Bind("TreasuryDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank Date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBank" runat="server" Text='<%# Bind("BankDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank Code" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBankCode" runat="server" Text='<%# Bind("BankCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank Transaction Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBankTransaction" runat="server" Text='<%# Bind("BankTransid") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" Visible="true" CommandName="Edt" Text="Edit" ForeColor="Blue" CommandArgument='<%# Eval("AppReg_No") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
            </div>
            </div>
            

             <div class="w-100 fl container-fluid" runat="server" id="DivUpdate" visible="false">

        <div class="block black bg-white">
        
             <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"> Challan Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtChallanNumber" CssClass="form-control input-b-b" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                </div>
              <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"> Treasury Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtTreasuryDate" CssClass="form-control input-b-b" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                </div>
             <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4"> Bank Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtBankDate" CssClass="form-control input-b-b" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                </div>
             <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Bank Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtBankCode" CssClass="form-control input-b-b" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                </div>

             <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Bank Transaction ID</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtBankTransid" CssClass="form-control input-b-b" runat="server" MaxLength="20"></asp:TextBox>
                    </div>
                </div>
             <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Bank Transaction ID</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtDeptTransid" CssClass="form-control input-b-b" runat="server" MaxLength="25"></asp:TextBox>
                    </div>
                </div>

             <div class="col-xs-12 col-sm-12 txt-cnt">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="btnUpdate_Click" />
            </div>
             </div>
                 </div>

   
        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
