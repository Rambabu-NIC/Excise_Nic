<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InstallementMaster.aspx.cs" Inherits="ExciseAPI.Admin.InstallementMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

    <script type="text/javascript">
        
    function pageLoad() {
       $(document).ready(function () {
            $("input[id*='txtStartDate']").datepicker({ maxDate: new Date(), dateFormat: 'yy-mm-dd' });
            $("input[id*='txtEndDate']").datepicker({ maxDate: new Date(), dateFormat: 'yy-mm-dd' });
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Installment</div>
            <div class="content">
                <asp:HiddenField ID="hf" runat="server" />
                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Installment</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlInstallement" runat="server" CssClass="form-control input-b-b" AutoPostBack="true" OnSelectedIndexChanged="ddlInstallement_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Start Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtStartDate" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">End Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtEndDate" CssClass="form-control input-b-b" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="content">
                <div class="text-center">
                    <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                        Text="Update" OnClick="btn_Save_Click" />

                </div>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
