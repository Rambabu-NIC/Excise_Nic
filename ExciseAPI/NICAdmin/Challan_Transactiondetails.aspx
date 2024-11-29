<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Challan_Transactiondetails.aspx.cs" Inherits="ExciseAPI.NICAdmin.Challan_Transactiondetails" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">TGBCL Retailer Challan Or Transaction Details Report</div>
            <div class="content">
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Challan No</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtChallan" CssClass="form-control input-b-b" runat="server" placeholder="Challan No" AutoCompleteType="Disabled"></asp:TextBox>
                       
                    </div>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
                </div>
                <br />

                <h4>Or</h4>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Transaction No</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtTransaction" CssClass="form-control input-b-b" runat="server" placeholder="Transaction No" AutoCompleteType="Disabled"></asp:TextBox>
                        
                    </div>
                </div>
                 </div>
             <div class="content text-center">
                <div class="col-xs-6 col-sm-6 txt-cnt">
                    <asp:Button ID="BtnGet" runat="server" Text="Get Details" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="BtnGet_Click" />
                </div>
                <%--</div>--%>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
                 </div>
                <div class="w-100 fl container-fluid" id="divgrid" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div class="content">
               
                    
                      
                            <div class="w-100 fl m-b-2">
                                <div class="fr">
                                    <a href="#">
                                        <asp:ImageButton runat="server" ID="btnChallanExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnChallanExportToPdf_Click"
                                            Visible="false" />
                                    </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnChallanImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnChallanImageExportToExcel_Click"
                                        Visible="false" /></a>
                                </div>
                            </div>
                      
                    
                    <div class="w-100 fl container-fluid" id="divgriddetails" runat="server" visible="true">
                        <div class="block-liner block black bg-white">
                            <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                                <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                                <br />
                                <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Bank Wise Report 
                                   

                                </h2>

                                
                            </div>

                            <div class="content">
                                <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="retl_code" HeaderText="RetailerCode" />
                                        <asp:BoundField DataField="retlname" HeaderText="Retailer Name" />
                                        <asp:BoundField DataField="bclid" HeaderText="TransactionId" />
                                        <asp:BoundField DataField="bank_name" HeaderText="Bank Name" />
                                        <asp:BoundField DataField="banktrans_id" HeaderText="Bank TransactionId" />
                                        <asp:BoundField DataField="amount" HeaderText="Amount" />
                                        <asp:BoundField DataField="bank_status" HeaderText="Bank Status" />
                                    </Columns>
                                </asp:GridView>
                            </div>
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
