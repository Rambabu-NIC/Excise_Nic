<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminChallanUpdate.aspx.cs" Inherits="ExciseAPI.Admin.AdminChallanUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
        <div class="head">Event Permits Challan Update</div>
        <asp:HiddenField ID="hf" runat="server" />
        <div class="content">
             <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Registration No</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                    <asp:TextBox ID="txtRegistrationNO" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="content text-center">
            <div class="col-xs-12 col-sm-12 txt-cnt">
                <asp:Button ID="btn_Get" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                    Text="GetDetails" OnClick="btn_Get_Click" />

            </div>
            <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            
        </div>
        </div>
        
    </div>
   </div>
    <div class="w-100 fl container-fluid" id="divgrid" runat="server">
        <div class="block-liner block black bg-white">
            <div class="col-md-12 text-center">
                <h4 style="text-align: center; font-weight: bold;"></h4>
            </div>
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
    <div class="content">
        <div class="text-center" id="divupdate" runat="server" visible="false">
            <asp:Button ID="BtnUpdate" CssClass="btn btnn btn-sm text-uppercase m-t-10" runat="server"
                Text="Update" OnClick="BtnUpdate_Click" />

        </div>

    </div>
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
