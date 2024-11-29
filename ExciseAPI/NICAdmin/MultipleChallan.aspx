<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultipleChallan.aspx.cs" Inherits="ExciseAPI.NICAdmin.MultipleChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function OnOneCheckboxSelected(chkB) {
            debugger;
            var IsChecked = chkB.checked;
            var Parent = document.getElementById('GvDF');
            var cbxAll;
            var items = Parent.getElementsByTagName('input');
            var bAllChecked = true;
            for (i = 0; i < items.length; i++) {
                if (items[i].id.indexOf('ChkSelectAll') != -1) {
                    cbxAll = items[i];
                    continue;
                }
                if (items[i].type == "checkbox" && items[i].checked == false) {
                    bAllChecked = false;
                    break;
                }
            }
            cbxAll.checked = bAllChecked;
        }

        function SelectAllCheckboxes(spanChk) {
            var IsChecked = spanChk.checked;
            var cbxAll = spanChk;
            var Parent = document.getElementById('GvDF');
            var items = Parent.getElementsByTagName('input');
            for (i = 0; i < items.length; i++) {
                if (items[i].id != cbxAll.id && items[i].type == "checkbox") {
                    items[i].checked = IsChecked;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Event Payment Update</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Registration NO</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:TextBox ID="txtRegistrationNO" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled" MaxLength="10"></asp:TextBox>
                        <asp:HiddenField ID="txtNewPwdHash" runat="server" />
                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnGet" runat="server" Text="Submit" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="btn_Get_Click" />


                </div>

            </div>
        </div>
        <div class="w-100 fl container-fluid" id="data" visible="false" runat="server">

            <div class="block black bg-white">
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
            <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="BtnUpdate" Visible="false" runat="server" Text="Update" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="BtnUpdate_Click" />


                </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
