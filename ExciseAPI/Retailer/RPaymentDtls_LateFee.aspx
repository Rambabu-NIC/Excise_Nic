<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.master" CodeBehind="RPaymentDtls_LateFee.aspx.cs" Inherits="ExciseAPI.Retailer.RPaymentDtls_LateFee" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">cpe Payment latefee</div>
            <div class="content">
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtRetailercode" CssClass="form-control input-b-b" runat="server" placeholder="Retailer code" Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtRetailerName" CssClass="form-control input-b-b" runat="server"
                            placeholder="Retailer Name" Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtMobile" CssClass="form-control input-b-b" runat="server" placeholder="Mobile Number"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Licensee Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:HiddenField ID="hf" runat="server" />
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
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Total Excise Tax</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txt_Extax" CssClass="form-control input-b-b" runat="server" placeholder="Total Excise Tax"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type of Retailer</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txt_retailer" CssClass="form-control input-b-b" runat="server" placeholder="Type of Retailer"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type of Payment</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlSubH" runat="server" CssClass="form-control " AutoPostBack="True"
                            OnSelectedIndexChanged="ddlSubH_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">HOA Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtHOA" CssClass="form-control input-b-b" runat="server" placeholder="HOA Code"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Installment Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlInsNo" runat="server" CssClass="form-control" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlInsNo_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Start Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtStartDate" CssClass="form-control input-b-b" runat="server" placeholder="Start Date"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">End Date</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtEnddate" CssClass="form-control input-b-b" runat="server" placeholder="End Date"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Total Amount</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtAmount" CssClass="form-control input-b-b" runat="server" placeholder="Amount"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Balance to be paid</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtBalancepaid" CssClass="form-control input-b-b" runat="server"
                            placeholder="Balance to be paid" Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
               
                    <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field" id="divlatefee" runat="server" visible="false">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Late Fee</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtLateFee" CssClass="form-control input-b-b" runat="server"
                            placeholder="Late Fee" Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Installment Amount Pay</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:RadioButtonList ID="rbdstatus" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RbRemarks_SelectedIndexChanged"
                            AutoPostBack="true" Enabled="false">
                            <asp:ListItem Text="Full Pay" Value="1" Selected="True" Enabled="false"></asp:ListItem>
                            <%--<asp:ListItem Text="Partial Pay" Value="2"  Enabled="true"></asp:ListItem>--%>
                        </asp:RadioButtonList>
                    </div>
                </div>
               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Total Amount Paid</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtTotalAmountPaid" CssClass="form-control input-b-b" runat="server" placeholder="Paid Amount" Enabled="false"></asp:TextBox>
                        
                    </div>
                </div>
               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Amount</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtAmt" CssClass="form-control input-b-b" runat="server" placeholder="Amount"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAmt_FilteredTextBoxExtender1" runat="server"
                            BehaviorID="txtAmt_FilteredTextBoxExtender" FilterType="numbers"
                            TargetControlID="txtAmt"></ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                </div>
                <%--<div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                         <asp:Button ID="btn_Save" CssClass=" btn btn-info btn-out-dotted bt" runat="server"
                                Text="Proceed to pay" OnClick="btn_Save_Click" />
                        <asp:Button ID="btn_Update" CssClass=" btn btn-warning btn-out-dotted" runat="server"
                                Text="Update" Visible="false" />

                    </div>
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center"></asp:Label>
                </div>--%>
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
    <div class="w-100 fl container-fluid" id="divpayment" runat="server" visible="false">
        <div class="block black bg-white">
            <div class="head">View Installment Payments</div>
            <div class="content">
                <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                    <%--OnRowDataBound="gvdetails_RowDataBound" OnRowCommand="gvdetails_RowCommand"--%>
                    <Columns>
                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Supplier_Code" HeaderText="Retailer_Code" />
                        <asp:BoundField DataField="Supplier_Name" HeaderText="Retailer Name" />
                        <asp:BoundField DataField="DeptCode" HeaderText="Depot Code" />
                        <asp:BoundField DataField="DDOCode" HeaderText="DDO Code" />
                        <asp:BoundField DataField="DeptTransid" HeaderText="Dept Transaction" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                        <asp:BoundField DataField="BankStatus" HeaderText="Bank Status" />
                        <asp:BoundField DataField="ChallanNumber" HeaderText="Challan Number" />
                        <asp:BoundField DataField="TreasuryDate" HeaderText="Treasury Date" />
                        <asp:BoundField DataField="Installmet" HeaderText="Installment" />
                        <%--<asp:TemplateField HeaderText="View" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkview" runat="server" Text="Click..!" CommandName="View" CommandArgument='<%# Eval("DeptTransid").ToString()%>' ForeColor="Green"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>


            </div>
        </div>
    </div>
</asp:Content>

