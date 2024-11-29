<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="SupplierPaymentDtls.aspx.cs" Inherits="ExciseAPI.Supplier.SupplierPaymentDtls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
 $(document).ready(function() {
    // Enable controls dynamically
    document.getElementById('<%= ddlduty.ClientID %>').disabled = false; 
    document.getElementById('<%= ddlSubH.ClientID %>').disabled = false;
    document.getElementById('<%= txtLicNo.ClientID %>').disabled = false;
    document.getElementById('<%= txtDDOCode.ClientID %>').disabled = false;
    
    // Initialize TinyMCE if needed
    tinymce.init({
      selector: 'textarea.tinymce-editor',
      height: 300,
      plugins: 'autosave',
      toolbar: 'bold italic underline'
    });
});

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Supplier Payments</div>
            <div class="content row">
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Supplier Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                         <asp:Label ID="lblTypeofmanyf" runat="server"></asp:Label>
                         <asp:Label ID="lblmfcd" runat="server" Text="Label" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Supplier Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                       <asp:Label ID="lblSuppNm" runat="server"></asp:Label>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                         <asp:Label ID="lblMob" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Licensee No</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:TextBox ID="txtLicNo" CssClass="form-control input-b-b" runat="server" placeholder="Licensee Number"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">DDO Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtDDOCode" CssClass="form-control input-b-b" runat="server" placeholder="DDO Code"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Minor Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlduty" runat="server" CssClass="form-control" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlduty_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Sub Head</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                         <asp:DropDownList ID="ddlSubH" runat="server" CssClass="form-control " AutoPostBack="True"
                            OnSelectedIndexChanged="ddlSubH_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type of Payment</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlTypeofpayment" runat="server" CssClass="form-control " AutoPostBack="True"
                            OnSelectedIndexChanged="ddlTypeofpayment_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                
                
                    <asp:HiddenField ID="hf" runat="server" />
                     <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">HOA Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtHOA" CssClass="form-control input-b-b" runat="server" placeholder="HOA Code"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Enter Excise Duty Amount</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtAmt" CssClass="form-control input-b-b" runat="server" placeholder="Amount"
                           ></asp:TextBox>
                    </div>
                </div>
                </div>
            <div class="content text-center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                        Text="Proceed to pay" OnClick="btn_Save_Click" />
                    <asp:Button ID="btn_Update" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                        Text="Update" Visible="false" />
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    

</asp:Content>




