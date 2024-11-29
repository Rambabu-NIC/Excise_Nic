<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="User_Creation.aspx.cs" Inherits="ExciseAPI.Supplier.User_Creation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Supplier</div>
            <div class="content">
                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card">
                                <div class="card-block">
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-2 col-form-label text-right">
                                            User Type</label>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="ddlTypeofmanu" runat="server" CssClass="form-control form-control-round"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                        <asp:HiddenField ID="hf" runat="server" />
                                        <label class="col-md-2 col-form-label text-right">
                                            User Name</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtMajor" CssClass="form-control form-control-round" runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtMajor_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                targetcontrolid="txtMajor" validchars="-">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">&nbsp;Password</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txt_Minor" CssClass="form-control form-control-round" runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="FilteredTextBoxExtender1" runat="server"
                                                enabled="True" filtertype="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                targetcontrolid="txt_Minor" validchars="-">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                    </div>


                                    <div class="form-group row col-md-10">
                                        <asp:Button ID="btn_Save" CssClass=" btn btn-info btn-out-dotted bt"
                                            runat="server" Text="Save" OnClick="btn_Save_Click" />
                                        <asp:Button ID="btn_Update" CssClass=" btn btn-warning btn-out-dotted"
                                            runat="server" Text="Update" Visible="false" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="card">
                        <div class="card-block">
                            <div class="table-responsive dt-responsive">
                                <asp:GridView ID="GvHOA" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvHOA_PageIndexChanging"
                                    OnRowCommand="GvHOA_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SNo">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Treasury Account Head">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDFDescr" runat="server" Text='<%# Bind("DF_Descr") %>'></asp:Label>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Major Head">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMajHead" runat="server" Text='<%# Bind("Major_Head") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Miner Head">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMinHead" runat="server" Text='<%# Bind("Minor_Head") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Group Head">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGPHead" runat="server" Text='<%# Bind("Group_Head") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sub Head">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubHead" runat="server" Text='<%# Bind("Sub_Head") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Details Head">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDtHead" runat="server" Text='<%# Bind("Detailed_Head") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SubDetails Head">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubDtHead" runat="server" Text='<%# Bind("subDetailed_Head") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                            <%--<EditItemTemplate>
                                                                            <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                                                            <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                                                        </EditItemTemplate>--%>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEdit" runat="server" CommandName="edt" ImageUrl="~/Assets/images/edit.PNG" />&nbsp&nbsp
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
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
