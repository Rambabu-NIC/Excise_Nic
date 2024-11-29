<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SupplierUpdate.aspx.cs" Inherits="ExciseAPI.NICAdmin.SupplierUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
       <div class="block black bg-white">                                                                              
            <div class="head">Supplier Update</div>
            <div class="content">
                  <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Supplier Code</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                       <asp:TextBox ID="txtSupplier" CssClass="form-control input-b-b" runat="server" placeholder="Supplier Code" AutoCompleteType="Disabled"></asp:TextBox>

                    </div>
                </div>
                <div class="content text-center">
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="BtnGet" runat="server" Text="Get Data" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="BtnGet_Click" />
                    </div>
                    <asp:Label ID="lblSuppliererror" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
                </div>
           </div>
        </div>
    <div class="w-100 fl container-fluid" id="divRetailer" runat="server" visible="false">
       <div class="block black bg-white">                                                                              
            <div class="head">Supplier Update</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Supplier Code<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">

                        <asp:TextBox ID="txtSupplierCode" CssClass="form-control input-b-b" runat="server" MaxLength="15" ReadOnly="true"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Supplier Name<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtSupplierName" CssClass="form-control input-b-b" runat="server" MaxLength="200"></asp:TextBox>
                    </div>
                </div>
                  <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Manufacturer Type<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlManufactureType" runat="server" class="form-control input-b-b" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                 
               
                   <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">District<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlDist" runat="server" class="form-control input-b-b" AutoPostBack="true" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mandal<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control input-b-b" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </div>
                </div>
               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Village<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlVillage" runat="server" class="form-control input-b-b" >
                        </asp:DropDownList>
                    </div>
                </div>
                 
                  <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">License No<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtLicenseNo" CssClass="form-control input-b-b" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                  
                <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Address<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtAddress" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                    </div>
                </div>
               
                  <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtMobile" CssClass="form-control input-b-b" runat="server" MaxLength="10"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="rgxMobileNumber" runat="server" ControlToValidate="txtMobile"
                            ValidationExpression="(0|91)?[6-9][0-9]{9}" ErrorMessage="Invalid Mobile Number." ForeColor="Red" ValidationGroup="Status">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
                
                  <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">PinCode<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtPincode" CssClass="form-control input-b-b" runat="server" MaxLength="6"></asp:TextBox>
                    </div>
                </div>
                
               <div class="form-group col-xs-12 col-sm-6 col-md-6 col-lg-6 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Active<span style="color: Red">*</span></label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="ddlActive" runat="server" class="form-control input-b-b" >
                             
                            <asp:ListItem Value="1">Active</asp:ListItem>
                            <asp:ListItem Value="0">InActive</asp:ListItem>
                           
                        </asp:DropDownList>
                    </div>
                </div>
                
            </div>
           
            
           </div>
        </div>
    <div class="content text-center">
        <div class="col-xs-12 col-sm-12 txt-cnt">
            <asp:Button ID="btn_Update" runat="server" Text="Update" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" OnClick="btn_Update_Click" />


        </div>
        <div class="col-xs-12 col-sm-12 txt-cnt">
            <asp:Label ID="lblError" runat="server" Style="text-align: center"></asp:Label>
        </div>
   </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
