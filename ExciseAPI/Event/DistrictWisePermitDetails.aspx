<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Event/Event.master" CodeBehind="DistrictWisePermitDetails.aspx.cs" Inherits="ExciseAPI.Event.DistrictWisePermitDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script type="text/javascript">

        function pageLoad() {
            $(document).ready(function () {
                $("input[id*='txtDate']").datepicker({ maxDate: new Date(), dateFormat: 'yy-mm-dd' });
                //$("input[id*='txtTo']").datepicker({ maxDate: new Date(), dateFormat: 'yy-mm-dd' });
            });
        }
    </script>
    <style>
        .eventlinkbtn {
            padding: 5px 10px;
            font-size: 14px;
            line-height: 2;
            border-radius: 5px;
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100 fl container-fluid">
        <div class="block black bg-white">
            <div class="head">District Wise amount paid but Permit not generated</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">

                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control " AutoPostBack="True">
                        </asp:DropDownList>

                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Year</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control " AutoPostBack="True">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="2022">2022</asp:ListItem>
                            <asp:ListItem Value="2023">2023</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="content" align="center">

                    <div class="col-md-12 txt-cnt">
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        <asp:Image ID="Image2" runat="server" />
                        <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/Assets/images/RecaptchaLogo.png"
                            OnClick="btnImgRefresh_Click" />
                        <span class="form-bar"></span>

                        <div class="container-fluid" align="center">
                            <asp:TextBox ID="captch" runat="server" class="form-control" placeholder="Enter Captcha" CssClass="Regcaptcha" AutoCompleteType="Disabled" MaxLength="6"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="captch_FilteredTextBoxExtender1" runat="server"
                                BehaviorID="captch_FilteredTextBoxExtender" FilterType="numbers"
                                TargetControlID="captch"></ajaxToolkit:FilteredTextBoxExtender>
                            <span class="form-bar"></span>
                        </div>
                    </div>


                </div>

            </div>
            <div class="content" align="center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btnSave" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server" OnClick="btnSave_Click"
                        Text="Get Details" />

                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
            <asp:HiddenField ID="hf" runat="server" />
        </div>


    </div>
    <div class="w-100 fl container-fluid" id="divDisEvent" runat="server" visible="false">
        <div class="block black bg-white">
            <div class="head">District Wise amount paid but Permit not generated</div>
            <div class="content">
                <asp:GridView ID="gvDisEvent" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv">
                    <%--OnRowDataBound="gvdetails_RowDataBound" OnRowCommand="gvdetails_RowCommand"--%>
                    <Columns>
                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AppReg_No" HeaderText="AppReg_No" />
                        <asp:BoundField DataField="DistName" HeaderText="District Name" />
                        <asp:BoundField DataField="App_Name" HeaderText="Applicant Name" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                        <asp:BoundField DataField="DateOfEvent" HeaderText="Date Of Event" />
                        <asp:BoundField DataField="Eventtime" HeaderText="Event Time" />
                        <asp:BoundField DataField="Event" HeaderText="Event " />
                        <asp:BoundField DataField="EntryDt" HeaderText="Date Of Application " />
                        <asp:BoundField DataField="StatusDes" HeaderText="Status" />
                    </Columns>
                </asp:GridView>


            </div>
        </div>
    </div>

</asp:Content>

