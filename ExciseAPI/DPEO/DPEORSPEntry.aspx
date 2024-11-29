<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DPEORSPEntry.aspx.cs" Inherits="ExciseAPI.DPEO.DPEORSPEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">Retailer Special Payment</div>
            <div class="content">
               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtRetailerCode" runat="server" CssClass="form-control input-b-b"></asp:TextBox>
                    </div>
                </div>
                
            </div>
              <div class="content text-center ">
            <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnGetDetails" runat="server" Text="GetDetails"
                        CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10"
                        OnClick="btnGetDetails_Click" />
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblretailererror" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
                  </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="secondpanel" runat="server" visible="false">
        <div class="block black bg-white">
            
            <div class="head">Retailer Special Payment</div>
             <div class="content">
            <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Lisence Name</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                    <asp:TextBox ID="txtlincesename" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Shop Name</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                    <asp:TextBox ID="txtshopName" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Gazette Code</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                    <asp:TextBox ID="txtGazette_Code" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Address</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                    <asp:TextBox ID="txtretaileraddress" runat="server" CssClass="form-control input-b-b" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type of Payment</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                    <asp:DropDownList ID="ddlSubH" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSubH_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group col-xs-12 col-sm-6 col-md-8 col-lg-9">
                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Amounts(In Rupees)</label>
                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                    <asp:TextBox ID="txtamount" runat="server" CssClass="form-control input-b-b" Enabled="false"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="txtamount_FilteredTextBoxExtender1" runat="server"
                        BehaviorID="txtamount_FilteredTextBoxExtender" FilterType="numbers"
                        TargetControlID="txtamount"></ajaxToolkit:FilteredTextBoxExtender>
                </div>
            </div>
            </div>
            <div class="content text-center">
            <div class="col-xs-12 col-sm-12 txt-cnt">
                <asp:Button ID="btnsubmit" runat="server" Text="Submit"
                    CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" Enabled="false" OnClick="btnsubmit_Click" />
            </div>
            <div class="col-xs-12 col-sm-12 txt-cnt">
                <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
            </div>
                </div>
        </div>
    </div>
</asp:Content>
