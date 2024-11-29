<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RetailersIsActive_Report.aspx.cs" Inherits="ExciseAPI.Retailer.RetailersIsActive_Report" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Retailers Active InActive Report</div>
            <div class="content">
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlRetailer" runat="server" CssClass="form-control input-b-b">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">Active</asp:ListItem>
                            <asp:ListItem Value="2">InActive</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="content text-center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="BtnGet" runat="server" Text="Get Details" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="BtnGet_Click" />
                    </div>
                
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center"></asp:Label>
                </div>
                    </div>
                </div>


            <div class="w-100 fl container-fluid" id="divgrid" runat="server" visible="false">
        <div class="block-liner block bg-white">
            <div class="content">
                
                   
                       
                            <div class="w-100 fl m-b-2">
                                <div class="fr">
                                    <a href="#">
                                        <asp:ImageButton runat="server" ID="btnRetailerActiveInActiveImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnRetailerActiveInActiveImageExportToPdf_Click"
                                            Visible="false" />
                                    </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnRetailerActiveInActiveImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnRetailerActiveInActiveImageExportToExcel_Click"
                                        Visible="false" /></a>
                                </div>
                            </div>
                        
                   
                    <div class="w-100 fl container-fluid" id="divgriddetails" runat="server" visible="true">
                        <div class="block-liner block black bg-white">
                            <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                                <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                                <br />
                                <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Retailer Active InActive Wise Report 
                                  

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
                                        <asp:BoundField DataField="Retailer_Type_Short_Name" HeaderText=" Retailer Type" />
                                        <asp:BoundField DataField="Retailer_Code" HeaderText="Retailer Code" />
                                        <asp:BoundField DataField="Retailer_Name" HeaderText="Retailer Name" />
                                        <asp:BoundField DataField="DepotName" HeaderText="Depot Name" />
                                        <asp:BoundField DataField="License_No" HeaderText="License No" />
                                        <asp:BoundField DataField="Excise_tax" HeaderText="Excise tax" />
                                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                        <asp:BoundField DataField="ExDist" HeaderText="Excise District" />
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
