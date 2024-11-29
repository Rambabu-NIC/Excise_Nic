<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DistrictExStationMapping.aspx.cs" Inherits="ExciseAPI.NICAdmin.DistrictExStationMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">District Excise Station Mapping</div>
            <div class="content">

                <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4" style="text-align: right">District</label>
                    <div class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control input-b-b"
                            OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4" style="text-align: right">Excise District</label>
                    <div class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                        <asp:DropDownList ID="ddlExDistrict" runat="server" CssClass="form-control input-b-b"
                            OnSelectedIndexChanged="ddlExDistrict_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4" style="text-align: right">Excise Station</label>
                    <div class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                        <asp:DropDownList ID="ddlExStation" runat="server" CssClass="form-control input-b-b"
                            OnSelectedIndexChanged="ddlExStation_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                
                 </div>

             </div>
       
                <asp:GridView ID="GvDF" runat="server" AllowPaging="True" PageSize="50" AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered nowrap gvv" OnPageIndexChanging="GvDF_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="SNo">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mandal">
                            <ItemTemplate>
                                <asp:Label ID="lblMandalName" runat="server" Text='<%# Bind("MandName") %>'></asp:Label>
                                <asp:Label ID="lblMandCode" runat="server" Visible="false" Text='<%# Bind("MandCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Excise Station">
                            <ItemTemplate>
                                <asp:Label ID="lblExStationName" runat="server" Text='<%# Bind("ExStationName") %>'></asp:Label>
                                <%-- <asp:Label ID="lblExStationCode" runat="server" Text='<%# Bind("ExStationCode") %>'></asp:Label>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--  <asp:TemplateField HeaderText="Excise District">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblExDistName" runat="server" Text='<%# Bind("ExDistName") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblExDistCode" runat="server" Text='<%# Bind("ExDistCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                        --%>
                        <asp:TemplateField HeaderText="Action" ShowHeader="False">
                            <ItemTemplate>
                                <%--<asp:ImageButton ID="btnEdit" runat="server" CommandName="edt" ImageUrl="~/Assets/images/edit.PNG" />&nbsp&nbsp  Enabled='<%# Eval("EFlag").ToString()!="0" ? false :  true %>'--%>
                                <asp:CheckBox ID="ChkSelect" Checked='<%# Eval("Flag").ToString()!="0" ? true :  false %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            
               
            </div>
             <div class="col-md-12 text-center">
                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" Visible="true"
                        CssClass=" btn btn-secondary" />
                </div>
       
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
