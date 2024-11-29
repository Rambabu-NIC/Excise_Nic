<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Create_Retailer.aspx.cs" Inherits="ExciseAPI.NICAdmin.Create_Retailer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
       <div class="block black bg-white">                                                                              
            <div class="head">Create retailer</div>
            <div class="content">
                   <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                       <asp:TextBox ID="txtretailer" CssClass="form-control input-b-b" runat="server" placeholder="Retailer Code" AutoCompleteType="Disabled" TextMode="Number" MaxLength="7"></asp:TextBox>

                    </div>
                </div>
                
                 <div class="content text-center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="BtnGet" runat="server" Text="Get Data" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="BtnGet_Click" />
                    </div>
                    <asp:Label ID="lblRetailererror" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
                </div>
           </div>
        </div>
    <div class="w-100 fl container-fluid" id="divRetailer" runat="server" visible="false">
       <div class="block black bg-white">                                                                              
            <div class="head">Create retailer</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Code<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:TextBox ID="txtRetailerCode" CssClass="form-control input-b-b" runat="server" MaxLength="7" TextMode="Number" ReadOnly="true" Enabled="false"></asp:TextBox>

                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Name<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtRetailerName" CssClass="form-control input-b-b" runat="server" MaxLength="200"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Retailer Type<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlRType" runat="server" class="form-control input-b-b" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Depot Code<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlDepot" runat="server" class="form-control input-b-b" >
                        </asp:DropDownList>
                    </div>
                </div>
                  <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">District<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlDist" runat="server" class="form-control input-b-b" AutoPostBack="true" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise District<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlExDist" runat="server" class="form-control input-b-b" >
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">License Name<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtLicenseName" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">License No<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtLicenseNo" CssClass="form-control input-b-b" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                  <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise Tax<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtExTax" CssClass="form-control input-b-b" runat="server" OnTextChanged="txtExTax_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Slab No</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtSlabNo" CssClass="form-control input-b-b" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <%-- <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Installment Amount</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtInstallment" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>--%>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Address<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtAddress" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Email<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtEmail" CssClass="form-control input-b-b" runat="server" MaxLength="75"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                            ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                            Display="Dynamic" ErrorMessage="Invalid email address" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                            ForeColor="Red" Display="Dynamic" ErrorMessage="Required" />

                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtMobile" CssClass="form-control input-b-b" runat="server" MaxLength="10"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="rgxMobileNumber" runat="server" ControlToValidate="txtMobile"
                            ValidationExpression="(0|91)?[6-9][0-9]{9}" ErrorMessage="Invalid Mobile Number." ForeColor="Red" ValidationGroup="Status">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Gazette Code<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtGazette" CssClass="form-control input-b-b" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">PinCode<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtPincode" CssClass="form-control input-b-b" runat="server" MaxLength="6"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Pan No<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtPan" CssClass="form-control input-b-b" runat="server" MaxLength="12"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Status <span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-control input-b-b" >
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Active</asp:ListItem>
                            <asp:ListItem Value="0">In-Active</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
               <%-- <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">DDO Code<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlDDO_Code" runat="server" class="form-control input-b-b" AutoPostBack="true" >
                        </asp:DropDownList>
                    </div>
                </div>--%>
                 <%--<div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">License Valid From</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtValidFrom" CssClass="form-control input-b-b" runat="server" ></asp:TextBox>
                         <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtValidFrom" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">License Valid To</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:TextBox ID="txtValidTo" CssClass="form-control input-b-b" runat="server" ></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtValidTo" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                    </div>
                </div>--%>
                
            </div>
           <div class="content text-center">
            <div class="col-xs-12 col-sm-12 txt-cnt">
            <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="btn_Submit_Click" />


        </div>
        <div class="col-xs-12 col-sm-12 txt-cnt">
            <asp:Label ID="lblError" runat="server" Style="text-align: center"></asp:Label>
        </div>

        </div>
           </div>
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
