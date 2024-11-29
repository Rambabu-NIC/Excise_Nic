<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.master" CodeBehind="DashboardRetailer.aspx.cs" Inherits="ExciseAPI.Retailer.DashboardRetailer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .retailer-color {
            color: black;
            text-align: left;
            padding-left: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <asp:HiddenField ID="hf" runat="server" />

        <%--<div class="theme-loader">
            <div class="ball-scale">
               
                <div class='contain'>
                    <div class="">
                        <div class="frame">
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>

        <marquee behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();">
           <font size="5px" color="#203354">
               <img src="../Assets/images/new.gif" style="height:35px; width:40px;" />
               <label class="f-b font txt-left" id="lblduedate" style="font-size:16px" runat="server"></label>
               <br />
               <span class="f-b font txt-left" style="font-size:16px"><b>If Transaction status is pending please <a href="../Retailer/ChallanUpdate.aspx">click</a> here to update your transaction status. </b>
                   </span>

           </font>
       </marquee>

        <div class="block black bg-white">
            <div class="head">Retailer Dashboard</div>
            <div class="content">
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                    <div class="highlight-box m-b-20">
                        <h2>Personal Details</h2>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="margin-top: 15px;">
                            <div class="label col-xs-12 col-sm-12 col-md-12" style="width: 98%">
                                <div class="col-xs-12 col-sm-5 col-md-5 f-14 col-lg-4  retailer-color">Retailer Code</div>
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
                                <div class="col-xs-12 col-sm-5 col-md-5 f-14 col-lg-4 f-b font txt-left retailer-color">License/GSL Number</div>
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
                    </div>

                </div>
                <div class="col-xs-12 col-sm-12 col-md-5 col-lg-5">
                    <div class="highlight-box m-b-20">
                        <h2>2020-2023</h2>
                        <br />
                        <div class="col-md-12">
                            <div class="info-box hover-zoom-effect" style="background-color: #1e88e5;">
                                <div class="dashcontent">
                                    <div class="col-md-4">
                                        <div class="f-b font txt-left text" style="color: #fff; font-size: 18px;" id="Master_lbl_first_db" runat="server">CPE Payments</div>
                                        <%--            <label class="f-b font txt-left" id="Master_lbl_first_db" style="font-size:16px">CPE Payments</label>--%>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="number digital dashboard-value" style="color: #fff;">
                                            <span class="dashboard-value digital" id="spnpermits_db" runat="server" style="color: #fff;"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="dashicon">
                                    <i class="bi bi-card-list"></i>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="info-box hover-zoom-effect" style="background-color: #ffb22b;">
                                <div class="dashcontent">
                                    <div class="col-md-4">
                                        <div class="f-b font txt-left text" style="color: #fff; font-size: 18px;" id="Master_lbl_second_db" runat="server">Sale Proceedings</div>
                                        <%-- <label class=" f-b font txt-left" id="Master_lbl_first_db" style="font-size:16px">Sale Proceedings</label>--%>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="number digital dashboard-value" style="color: #fff;">
                                            <span class="dashboard-value digital" id="spntransitforms_db" runat="server" style="color: #fff;"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="dashicon">
                                    <i class="bi bi-card-list"></i>
                                </div>
                            </div>
                        </div>
                        <%--          <div class="col-md-12">
                            <div class="info-box hover-zoom-effect" style="background-color: #26c6da;">
                                <div class="dashcontent">
                                    <div class="col-md-4">
                                        <div class="text" style="color: #fff;" id="Master_lbl_third_db" runat="server"></div>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="number digital dashboard-value" style="color: #fff;">
                                            <span class="dashboard-value digital" id="spnstationery_db" runat="server"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="dashicon">
                                    <i class="fa fa-pencil"></i>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="info-box hover-zoom-effect" style="background-color: #fc4b6c;">
                                <div class="dashcontent">
                                    <div class="col-md-4">
                                        <div class="text" style="color: #fff;" id="Master_lbl_fourth_db" runat="server"></div>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="number digital dashboard-value" style="color: #fff;">
                                            <span class="dashboard-value digital" id="spnapplication_db" runat="server"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="dashicon">
                                    <i class="fa fa-tasks"></i>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

