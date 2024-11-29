<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.master" CodeBehind="RetailerProfile_Confirm.aspx.cs" Inherits="ExciseAPI.Retailer.RetailerProfile_Confirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
     .retailer-color{
         color:black;
     }
 </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
         <asp:HiddenField ID="hf" runat="server" />
         <marquee behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();">
             <a href="#" target="_blank"><font size="5px" color="#203354"><img src="../Assets/images/new.gif" style="height:35px; width:40px;" /><b style="color:red">Please confirm profile and ddocode for payments..</b></font></a> </marquee>
        <div class="block black bg-white">
            <div class="head">Profile Confirm</div>
            <div class="content">
               <div class="col-xs-12 col-sm-12 col-md-5 col-lg-5">
                    <div class="highlight-box m-b-20">
                        <h2>Personal Details</h2>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="margin-top: 15px;">
                            <div class="label col-xs-12 col-sm-12 col-md-12" style="width: 96%">
                                <div class="col-xs-12 col-sm-5 col-md-5 f-14 col-lg-4 f-b font txt-left retailer-color">Retailer Code</div>
                                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8 f-14 txt-left retailer-color">
                                    <asp:Label ID="lblRetailercode" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="label col-xs-12 col-sm-12 col-md-12" style="width: 96%">
                                <div class="col-xs-12 col-sm-5 col-md-5 f-14 col-lg-4 f-b font txt-left retailer-color">Retailer Name</div>
                                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8 f-14 txt-left font-label retailer-color">
                                    <asp:Label ID="lblRetailerName" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="label col-xs-12 col-sm-12 col-md-12" style="width: 96%">
                                <div class="col-xs-12 col-sm-5 col-md-5 f-14 col-lg-4 f-b font txt-left retailer-color">Retailer Type</div>
                                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8 f-14 txt-left font-label retailer-color">
                                    <asp:Label ID="lblRetailer_Type" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="label col-xs-12 col-sm-12 col-md-12" style="width: 96%">
                                <div class="col-xs-12 col-sm-5 col-md-5 f-14 col-lg-4 f-b font txt-left retailer-color">Depot Name</div>
                                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8 f-14 txt-left font-label retailer-color">
                                    <asp:Label ID="lbldepotName" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="clearfix"></div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="label col-xs-12 col-sm-12 col-md-12" style="width: 96%">
                                <div class="col-xs-12 col-sm-5 col-md-5 f-14 col-lg-4 f-b font txt-left retailer-color">License Name</div>
                                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8  f-14 txt-left font-label retailer-color">
                                    <asp:Label ID="lbllicensename" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="label col-xs-12 col-sm-12 col-md-12" style="width: 96%">
                                <div class="col-xs-12 col-sm-5 col-md-5 f-14 col-lg-4 f-b font txt-left retailer-color">License Number</div>
                                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8 f-14 txt-left font-label retailer-color">
                                    <asp:Label ID="lbllicenseno" runat="server"></asp:Label>
                                </div>
                            </div>

                        </div>
                        <div class="clearfix"></div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="label col-xs-12 col-sm-12 col-md-12" style="width: 96%">
                                <div class="col-xs-12 col-sm-5 col-md-5 f-14 col-lg-4 f-b font txt-left retailer-color">Mobile </div>
                                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8 f-14 txt-left font-label retailer-color">
                                    <asp:Label ID="lblmobile" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="label col-xs-12 col-sm-12 col-md-12" style="width: 96%">
                                <div class="col-xs-12 col-sm-5 col-md-5 f-14 col-lg-4 f-b font txt-left retailer-color">Email</div>
                                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8  f-14 txt-left font-label retailer-color">
                                    <asp:Label ID="lblemail" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                         <div class="clearfix"></div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="label col-xs-12 col-sm-12 col-md-12" style="width: 96%">
                                <div class="col-xs-12 col-sm-5 col-md-5 f-14 col-lg-4 f-b font txt-left retailer-color">Status</div>
                                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8  f-14 txt-left font-label retailer-color">
                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="label col-xs-12 col-sm-12 col-md-12" style="width: 96%">
                                <div class="col-xs-12 col-sm-5 col-md-5 f-14 col-lg-4 f-b font txt-left retailer-color">License Validity</div>
                                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8  f-14 txt-left font-label retailer-color">
                                    <asp:Label ID="lblLicenseValidity" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="label col-xs-12 col-sm-12 col-md-12" style="width: 96%">
                                <div class="col-xs-12 col-sm-5 col-md-5 f-14 col-lg-4 f-b font txt-left retailer-color">DDO Code</div>
                                <div class="col-xs-12 col-sm-7 col-md-7 col-lg-8  f-14 txt-left font-label retailer-color">
                                    <asp:Label ID="lblDDOCode" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-12 txt-cnt" align="center" >
                            <asp:CheckBox Text="I have verified the details shown above and found correct" ID="Pcheck" runat="server" Style="color:red" OnCheckedChanged="Pcheck_CheckedChanged" AutoPostBack="true" />
                        </div>
                        <div class="col-xs-12 col-sm-12 txt-cnt" align="center"  >
                            <asp:Button ID="btnConfirm" runat="server" Enabled="false" Text="Confirm" CssClass="btn btnn btn-sm text-uppercase m-t-10" OnClick="btnConfirm_Click" />
                        </div>

                    </div>

                </div>
            </div>
            </div>
        </div>
    
</asp:Content>

