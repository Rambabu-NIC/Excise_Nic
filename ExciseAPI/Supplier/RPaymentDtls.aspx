<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RPaymentDtls.aspx.cs" Inherits="ExciseAPI.Supplier.RPaymentDtls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Payment</div>
            <div class="content">
                <div class="page-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card">
                                <div class="card-block">
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-2 col-form-label text-right" style="font-size: medium; font-weight: bold">
                                            &nbsp;Retailer Code
                                        </label>
                                        <div class="col-md-2">
                                            <asp:Label ID="lblTypeofmanyf" runat="server"></asp:Label>
                                            <asp:Label ID="lblmfcd" runat="server" Text="Label" Visible="False"></asp:Label>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right" style="font-size: medium; font-weight: bold">
                                            Retailer Name
                                        </label>
                                        <div class="col-md-2">
                                            <asp:Label ID="lblSuppNm" runat="server"></asp:Label>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right" style="font-size: medium; font-weight: bold">
                                            Mobile Number
                                        </label>
                                        <div class="col-md-2">
                                            <asp:Label ID="lblMob" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <asp:HiddenField ID="hf" runat="server" />
                                        <label class="col-md-2 col-form-label text-right">
                                            Licensee Number</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtLicNo" CssClass="form-control" runat="server" AutoComplete="off"
                                                Enabled="False"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtLicNo_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                targetcontrolid="txtLicNo" validchars="-">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            DDO Code</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtDDOCode" CssClass="form-control" runat="server" AutoComplete="off"
                                                MaxLength="3" Enabled="False"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtDDOCode_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="Numbers,Custom,UppercaseLetters,lowercaseLetters,Custom"
                                                targetcontrolid="txtDDOCode" validchars="">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            Total Excise Tax</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txt_Extax" CssClass="form-control" runat="server" AutoComplete="off"
                                                MaxLength="3" Enabled="False"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="FilteredTextBoxExtender1" runat="server" enabled="True"
                                                filtertype="Numbers,Custom,UppercaseLetters,lowercaseLetters,Custom" targetcontrolid="txt_Extax"
                                                validchars="">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-2 col-form-label text-right">
                                            Type of Retailer</label>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="ddlduty" runat="server" CssClass="form-control " AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlduty_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            Type of Payment</label>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="ddlSubH" runat="server" CssClass="form-control " AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlSubH_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            HOA Code</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtHOA" CssClass="form-control" runat="server" AutoComplete="off"
                                                MaxLength="2" Enabled="False"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtHOA_FilteredTextBoxExtender" runat="server"
                                                enabled="True" filtertype="UppercaseLetters,lowercaseLetters,Numbers,Custom"
                                                targetcontrolid="txtHOA" validchars="-">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                    </div>
                                    <div class="form-group row col-md-12">
                                        <label class="col-md-2 col-form-label text-right">
                                            Istallment Amount Pay</label>
                                        <div class="col-md-">
                                            <asp:RadioButtonList ID="rbdstatus" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RbRemarks_SelectedIndexChanged"
                                                AutoPostBack="true">
                                                <asp:ListItem Text="Full Pay" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Partial Pay" Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <label class="col-md-2 col-form-label text-right">
                                            Amount
                                        </label>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtAmt" CssClass="form-control" runat="server" AutoComplete="off"
                                                MaxLength="10"></asp:TextBox>
                                            <ajax:filteredtextboxextender id="txtAmt_FilteredTextBoxExtender1" runat="server"
                                                enabled="True" filtertype="Numbers,Custom,UppercaseLetters,lowercaseLetters,Custom"
                                                targetcontrolid="txtAmt" validchars=".">
                                                                </ajax:filteredtextboxextender>
                                        </div>
                                    </div>


                                    <div class="form-group row col-md-10 offset-5">
                                        <asp:Button ID="btn_Save" CssClass=" btn btn-info btn-out-dotted bt" runat="server"
                                            Text="Proceed to pay" OnClick="btn_Save_Click" />
                                        <asp:Button ID="btn_Update" CssClass=" btn btn-warning btn-out-dotted" runat="server"
                                            Text="Update" Visible="false" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
