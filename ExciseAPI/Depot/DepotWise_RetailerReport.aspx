<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="DepotWise_RetailerReport.aspx.cs" Inherits="ExciseAPI.Depot.DepotWise_RetailerReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid" id="divRetailerIndividual" runat="server" visible="false"  style="overflow-y:scroll; overflow-y:hidden;"
>
        <div class="block black bg-white">
            <div class="head">Depot Wise Retailer Report</div>
           <div class="content">
                <div runat="server" id="DivGeneratedDate" visible="false">
                    <div class="w-100 fl m-b-2" id="divYearDiv" runat="server" visible="true">
                        <div class="w-100 fl m-b-2">
                            <div class="fr">
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnAvailableImageExportToPdf" ImageUrl="~/Assets/images/PDF.png" OnClick="btnAvailableImageExportToPdf_Click" />
                                </a>&nbsp;&nbsp;
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="btnAvailableImageExportToExcel" ImageUrl="~/Assets/images/excel.gif" OnClick="btnAvailableImageExportToExcel_Click" />
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content">
                    <div id="divheading" class="col-md-12 text-center" runat="server" visible="false">
                        <h2 style="text-align: center; font-weight: bold;">Government of Telangana Prohibition & Excise Department</h2>
                        <h2 style="text-align: center; font-weight: bold;">Statement showing the details of Retailers Installment Report 
                                   
                        </h2>

                    </div>
                    <div style="overflow-x:scroll;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv" >
                        <Columns>
                            <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Retailer_Code" HeaderText="Retailer Code" />
                            <asp:BoundField DataField="Retailer_Name" HeaderText="Retailer Name" />
                            <asp:BoundField DataField="License_Name" HeaderText="License Name" />
                            <asp:BoundField DataField="License_No" HeaderText="License No" />
                            <asp:BoundField DataField="Excise_tax" HeaderText="Excise tax" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                            <asp:BoundField DataField="Retailer_Type_Description" HeaderText="Retailer Type" />
                            <asp:BoundField DataField="Lic_Validupto" HeaderText="License Valid" />
                            <asp:BoundField DataField="DepotName" HeaderText="DepotName" />

                        </Columns>
                    </asp:GridView>
                </div>
          
            </div>
               </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
