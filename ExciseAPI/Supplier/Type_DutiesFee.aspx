<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Type_DutiesFee.aspx.cs" Inherits="ExciseAPI.Supplier.Type_DutiesFee" %>

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
                                        <asp:HiddenField ID="hf" runat="server" />
                                        <label class="col-md-2 col-form-label text-right">&nbsp;Type of Duties/Fee</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txt_TypeDuty" CssClass="form-control form-control-round" runat="server"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txt_TypeDuty_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                targetcontrolid="txt_TypeDuty" validchars="-">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        &nbsp;<div class="col-md-2">
                                        </div>
                                    </div>

                                    <div class="form-group row col-md-12">
                                        <asp:Button ID="btn_Save" CssClass=" btn btn-info btn-out-dotted bt"
                                            runat="server" Text="Save" OnClick="btn_Save_Click" />
                                        <asp:Button ID="btn_Update" CssClass=" btn btn-warning btn-out-dotted"
                                            runat="server" Text="Update" Visible="false" OnClick="btn_Update_Click" />
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
                                <asp:GridView ID="GvDF" runat="server" AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvDF_PageIndexChanging"
                                    OnRowCommand="GvDF_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SNo">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type Of Duties/Fee">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDF_Descr" runat="server" Text='<%# Bind("DF_Descr") %>'></asp:Label>
                                                <asp:Label ID="lblDF_Code" runat="server" Text='<%# Bind("DF_Code") %>' Visible="false"></asp:Label>
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
