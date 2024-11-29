<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExciseStationWiseAbstractN.aspx.cs" Inherits="ExciseAPI.NICAdmin.ExciseStationWiseAbstractN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">

        <div class="block black bg-white">
            <div class="head">Excise District Wise Abstract</div>
              <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:Label ID="lblExciseDistrict" runat="server" Text="Excise District"></asp:Label>
                        <asp:DropDownList ID="ddlExDist" runat="server"
                            OnSelectedIndexChanged="ddlExDist_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control input-b-b">
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise Station</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:Label ID="ExciseStation" runat="server" Text="Excise Station"></asp:Label>
                        <asp:DropDownList ID="ddlExStation" runat="server"
                            OnSelectedIndexChanged="ddlExStation_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control input-b-b">
                        </asp:DropDownList>
                    </div>
                </div>
                
               
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnGet" runat="server" Text="Get Data" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="btnGet_Click" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
