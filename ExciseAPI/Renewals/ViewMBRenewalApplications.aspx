﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewMBRenewalApplications.aspx.cs" Inherits="ExciseAPI.Supplier.ViewMBRenewalApplications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Security Deposite </label>

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:RadioButtonList ID="IsBG_CD" runat="server" Readonly="true" Enabled="false">
                            <asp:ListItem Text="BG/FDR No" Value="1" />
                            <asp:ListItem Text="Cash Deposite" Value="2" />
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div runat="server" id="divFDR" visible="false">
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">BG/FDRNo</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txtbgFdrNo" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">BG/FDR Date</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txtbgFdrDate" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <div runat="server" id="divCD" visible="false">
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Challn No</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txtCdChallanno" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Challan Date</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txtcdChallndate" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Amount</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtsdAmount" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Bank Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtBankName" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Branch Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtbranchname" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">License Validity From</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtLicenseValidityFrom" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">License Validity To</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtLicenseValidityTo" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                    <div id="divendrosement" runat="server" visible="false">
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Cr.No</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txtCrNo" CssClass="form-control input-b-b" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Premises</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txtPremises" CssClass="form-control input-b-b" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">North</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txtNorth" CssClass="form-control input-b-b" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">South</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txtSouth" CssClass="form-control input-b-b" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">East</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txteast" CssClass="form-control input-b-b" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">West</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txtwest" CssClass="form-control input-b-b" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">From Year</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txtfromYear" CssClass="form-control input-b-b" runat="server" MaxLength="4" ></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">To Year</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txttoYear" CssClass="form-control input-b-b" runat="server"  MaxLength="4" ></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                        <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Remitted</label>
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                            <asp:TextBox ID="txtremitted" CssClass="form-control input-b-b" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>


        </div>

    </div>

    <div class="w-100 fl container-fluid" id="div2" runat="server">
        <div class="block black bg-white">
            <div class="head">Flow Details</div>
            <div class="content">
                <asp:GridView ID="gvFlowDetails" runat="server" AutoGenerateColumns="False" 
                    CssClass="table table-striped table-bordered nowrap gvv" OnRowCommand="gvFlowDetails_RowCommand"
                    OnRowDataBound="gvFlowDetails_RowDataBound"  >
                    <Columns>
                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ApplicationNo" HeaderText="Application No" />
                        <asp:BoundField DataField="Current_Level" HeaderText="Current_Level" />
                        <asp:BoundField DataField="Next_Level" HeaderText="Next_Level" />
                        <asp:BoundField DataField="FRemarks" HeaderText="Remarks" />
                        <%-- <asp:BoundField DataField="DocumentFile" HeaderText="DocumentFile" />--%>
                        <asp:TemplateField HeaderText="Document Copy" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtn_Documents" runat="server" Text="View" CommandName="lnkbtn_Documents" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ForeColor="Green"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="div3" runat="server">
        <div class="block black bg-white">
            <div class="head">Document Details</div>
            <div class="content">
                <asp:GridView ID="gvDocumentDetails" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered nowrap gvv" 
                    OnRowCommand="gvDocumentDetails_RowCommand" OnRowDataBound="gvDocumentDetails_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DocumentTypeID" HeaderText="DocumentTypeID" />
                        <asp:BoundField DataField="DocumentTypeName" HeaderText="DocumentTypeName" />
                        <%-- <asp:BoundField DataField="DocumentFile" HeaderText="DocumentFile" />--%>
                        <asp:TemplateField HeaderText="Document Copy" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtn_Documents" runat="server" Text="View" CommandName="lnkbtn_Documents" CommandArgument='<%# Eval("DocumentTypeID").ToString() %>' ForeColor="Green"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>