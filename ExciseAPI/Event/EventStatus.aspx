<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Event/Event.master" CodeBehind="EventStatus.aspx.cs" Inherits="ExciseAPI.Event.EventStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
            <div class="head">Apply For Event Permit</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Date Of Event</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtDate" CssClass="form-control input-b-b" runat="server" OnTextChanged="txtDate_TextChanged" AutoPostBack="true" Enabled="True" AutoCompleteType="Disabled"></asp:TextBox>
                        <cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDate" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtMobileNumber" CssClass="form-control input-b-b" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rgxMobileNumber" runat="server" ControlToValidate="txtMobileNumber"
                            ValidationExpression="(0|91)?[6-9][0-9]{9}" ErrorMessage="Invalid Mobile Number." ForeColor="Red" ValidationGroup="Status">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">E-Mail ID</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtEmail" CssClass="form-control input-b-b" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                            ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                            Display="Dynamic" ErrorMessage="Invalid email address" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                            ForeColor="Red" Display="Dynamic" ErrorMessage="Required" />
                    </div>
                </div>
                <div class="col-md-12 text-center">

                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        <asp:Image ID="Image2" runat="server" />
                        <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/Assets/images/RecaptchaLogo.png"
                            OnClick="btnImgRefresh_Click" CausesValidation="False" />
                        <span class="form-bar"></span>

                        <div class="container-fluid" align="center">
                        <asp:TextBox ID="captch" runat="server" class="form-control" placeholder="Enter Captcha" CssClass="Regcaptcha" AutoComplete="off" MaxLength="6"></asp:TextBox>
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
                        Text="Get Details" ValidationGroup="Status" />

                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
            <asp:HiddenField ID="hf" runat="server" />
        </div>


    </div>
    <div class="w-100 fl container-fluid" id="divStatus" runat="server" visible="false">
        <div class="block black bg-white">
            <div class="head">Event Status</div>
            <div class="content">
                <asp:GridView ID="gvStatus" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap gvv"
                    OnRowDataBound="gvStatus_RowDataBound" OnRowCommand="gvStatus_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AppReg_No" HeaderText="ApplicationNo" />
                        <asp:BoundField DataField="App_Name" HeaderText="Applicant Name" />
                        <asp:BoundField DataField="FName" HeaderText="FatherName" />
                        <asp:BoundField DataField="Res_Address" HeaderText="Address" />
                        <asp:BoundField DataField="DateOfEvent" HeaderText="DateOfEvent" />
                        <asp:BoundField DataField="StatusDes" HeaderText="StatusDescription" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                        <asp:TemplateField HeaderText="View" ItemStyle-CssClass="txt-cnt">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkview" runat="server" Text="Click..!" CommandName="View" CommandArgument='<%# Eval("AppReg_No").ToString() + "," + Eval("Status").ToString() %>' ForeColor="Green"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>


            </div>
        </div>
    </div>

</asp:Content>

