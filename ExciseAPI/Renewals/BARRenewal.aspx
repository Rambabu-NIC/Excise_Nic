<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BARRenewal.aspx.cs" Inherits="ExciseAPI.Supplier.BARRenewal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divfirstpanel" runat="server" visible="true">
        <div class="w-100 fl container-fluid" id="divpayment" runat="server">
            <div class="block black bg-white">
                <div class="head">Retailer Details</div>
                <div class="content">
                    <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                        <Columns>
                            <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Retailer_Code" HeaderText="Retailer_Code" />
                            <asp:BoundField DataField="Retailer_Name" HeaderText="Supplier_Name" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="w-100 fl container-fluid" id="div1" runat="server">
            <div class="block black bg-white">
                <div class="head">Payment Details</div>
                <div class="content">
                    <asp:GridView ID="gvPaymentDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                        <Columns>
                            <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Payment_Desc" HeaderText="Payment Type" />
                            <asp:BoundField DataField="InstallmentType" HeaderText="Installment Type" />
                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                            <asp:BoundField DataField="ChallanNumber" HeaderText="Challan" />
                            <asp:BoundField DataField="TreasuryDate" HeaderText="Date" />
                            <asp:BoundField DataField="BankCode" HeaderText="Bank" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="w-100 fl container-fluid">
            <div class="block black bg-white">
                <div class="head">Renewal Details</div>
                <div class="content" id="divbgDetails" runat="server" visible="true">
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Security Deposit </label>

                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                            <%--<asp:RadioButton Style="margin-left: 10px;" ID="rbBGFDR" runat="server" Text="BG/FDR No" OnCheckedChanged="rbBGFDR_CheckedChanged" AutoPostBack="true" />
                        <asp:RadioButton Style="margin-left: 10px;" ID="rbCD" runat="server" Text="Cash Deposite" OnCheckedChanged="rbCD_CheckedChanged" AutoPostBack="true" />--%>
                            <asp:RadioButtonList ID="IsBG_CD" runat="server" OnSelectedIndexChanged="IsBG_CD_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="BG/FDR No" Value="1" />
                                <asp:ListItem Text="Cash Deposit" Value="2" />
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IsBG_CD" ErrorMessage="This field cannot be blank." ValidationGroup="MBRenewal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div runat="server" id="divFDR" visible="false">
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">BG/FDRNo</label>
                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtbgFdrNo" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbgFdrNo" ErrorMessage="This field cannot be blank." ValidationGroup="MBRenewal" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">BG/FDR Date</label>
                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtbgFdrDate" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtbgFdrDate" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbgFdrDate" ErrorMessage="This field cannot be blank." ValidationGroup="MBRenewal" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                    <div runat="server" id="divCD" visible="false">
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Challn No</label>
                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtCdChallanno" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCdChallanno" ErrorMessage="This field cannot be blank." ValidationGroup="MBRenewal" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                            <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Challan Date</label>
                            <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                <asp:TextBox ID="txtcdChallndate" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtcdChallndate" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtcdChallndate" ErrorMessage="This field cannot be blank." ValidationGroup="MBRenewal" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>

                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Amount</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                            <asp:TextBox ID="txtsdAmount" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtsdAmount" ErrorMessage="This field cannot be blank." ValidationGroup="MBRenewal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Bank Name</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                            <asp:TextBox ID="txtBankName" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtBankName" ErrorMessage="This field cannot be blank." ValidationGroup="MBRenewal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Branch Name</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                            <asp:TextBox ID="txtbranchname" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtbranchname" ErrorMessage="This field cannot be blank." ValidationGroup="MBRenewal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                   <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">License Validity From</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                            <asp:TextBox ID="txtLicenseValidityFrom" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtLicenseValidityFrom" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtLicenseValidityFrom" ErrorMessage="This field cannot be blank." ValidationGroup="MBRenewal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">License Validity To</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                            <asp:TextBox ID="txtLicenseValidityTo" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender3" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtLicenseValidityTo" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtLicenseValidityTo" ErrorMessage="This field cannot be blank." ValidationGroup="MBRenewal" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="content">
                     
                </div>
                <div class="content" align="center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="btnNext" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                            Text="Next" OnClick="btnNext_Click" ValidationGroup="MBRenewal" />
                        <asp:Label ID="lblNextError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <div class="w-100 fl container-fluid" id="divsecondBlock" runat="server" visible="false">
        <div class="block black bg-white">
            <div class="head">Document Details</div>
            <div class="content">
                <div class="w-100 fl container-fluid">
                    <div class="block black bg-white">
                        <div class="head">
                            <div class="col-xs-12 col-sm-8 col-md-8 col-lg-9 txt-left">Upload Documents</div>
                            <div class="col-xs-12 col-sm-4 col-md-4 col-lg-3 txt-right">
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <label class="lableinput lableinput2" style="color: red; font-weight: bold;">Points to Remember: -</label>
                        </div>
                        <div class="col-xs-12">
                            <p style="color: red; font-weight: bold;">
                                1. Upload all documents in PDF Format only.                                    
                                    <br />
                                2. All PDF documents must be less then 5MB Size.
                            </p>
                        </div>
                        <div class="content">

                            <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Document Type</label>
                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                    <asp:DropDownList ID="ddldocumenttype" runat="server" CssClass="form-control input-b-b">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Upload Documents</label>
                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                    <asp:FileUpload ID="fileuploaddoctype" runat="server" CssClass="form-control input-b-b" />
                                </div>
                            </div>
                            <div class="content text-center">
                            <div class="col-xs-12 col-sm-12 txt-cnt">
                                <asp:Button ID="btnAddUpload" runat="server" Text="ADD ROW" CssClass="btn btn-secondary btnn btn-sm text-uppercase" OnClick="btnAddUpload_Click" />
                            </div>
                                </div>
                        </div>
                    </div>
                </div>

                <div class="w-100 fl container-fluid" id="divuploaddocumentsdetails" runat="server" visible="false">
                    <div class="block block-liner black bg-white">
                        <div class="content">

                            <div style="width: 100%; overflow: auto;">
                                <asp:GridView ID="gvaddrecords" CssClass="table table-striped table-bordered nowrap gvv"
                                    runat="server" AutoGenerateColumns="false" ShowFooter="false" AutoGenerateDeleteButton="false" EmptyDataText="No Documents are available to show" EmptyDataRowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="True"
                                    OnRowCommand="gvaddrecords_RowCommand">
                                    <Columns>

                                        <asp:TemplateField HeaderText="SNo" ItemStyle-CssClass="p-5" HeaderStyle-CssClass="p-5">

                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DocumentTypeName" HeaderText="Document Type" />
                                        <asp:TemplateField HeaderText="Documet Copy" ItemStyle-CssClass="txt-cnt">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn_Documents" runat="server" Text="View" CommandName="lnkbtn_Documents" CommandArgument='<%# Eval("DocumentTypeID").ToString() %>' ForeColor="Green"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-CssClass="p-5" HeaderStyle-CssClass="p-5">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lknbtndocDelete" runat="server" Text="Delete" OnClick="lknbtndocDelete_Click"><img src="../Assets/images/delete.PNG" onclick="" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="content" align="center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                        Text="Save" OnClick="btn_Save_Click" Visible="false" />
                    <asp:Label ID="lblmsg" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
