<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="Service_Chart.aspx.cs" Inherits="ExciseAPI.Service_Chart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="card w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Manufacturers</div>
              <div class="content" >
                  <asp:GridView ID="gvmanufacturers" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv" >
                        <Columns>
                            <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Type_Man_Nm" HeaderText="Manufacture Type" />
                            <asp:BoundField DataField="Item_Description" HeaderText="Service Description" />
                            <asp:BoundField DataField="Fee_in_Rs" HeaderText="Fees" />
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />

                        </Columns>
                    </asp:GridView>
                  </div>
            </div>
       <div class="block black bg-white">
            <div class="head">Retailers</div>
              <div class="content" style="overflow-x:scroll;" >
                  <asp:GridView ID="gvretailers"  runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv" >
                        <Columns>
                            <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Retailer_Type_Description" HeaderText="Retailer Type" />
                            <asp:BoundField DataField="Item_Description" HeaderText="Service Description" />
                            <asp:BoundField DataField="Fee_in_Rs" HeaderText="Fees" />
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />

                        </Columns>
                    </asp:GridView>
                  </div>
            </div>
       </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
