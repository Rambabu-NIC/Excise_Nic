<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Event/Event.master" CodeBehind="EventRegistration.aspx.cs" Inherits="ExciseAPI.Event.EventRegistration" %>

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
            <div class="head">Event Permit Registration Form</div>
            <div class="content">
                <asp:UpdatePanel ID="UpdatePanel1_Event" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="content">
                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Name of Applicant</label>

                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Mr" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Miss" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Smt" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtAppliName" CssClass="form-control input-b-b" runat="server" placeholder="Applicant Name"></asp:TextBox>
                                    <%--<ajaxToolkit:FilteredTextBoxExtender ID="txtAppliName_FilteredTextBoxExtender1" runat="server"
                                        BehaviorID="txtAppliName_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters"
                                        TargetControlID="txtAppliName"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                </div>
                            </div>
                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Father's Name</label>
                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                    <asp:TextBox ID="txtFatherName" CssClass="form-control input-b-b" runat="server" placeholder="Father Name"></asp:TextBox>
                                    <%--<ajaxToolkit:FilteredTextBoxExtender ID="txtFatherName_FilteredTextBoxExtender1" runat="server"
                                        BehaviorID="txtFatherName_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters"
                                        TargetControlID="txtFatherName"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                </div>
                            </div>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Age</label>
                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                    <asp:TextBox ID="txtAge" CssClass="form-control input-b-b" runat="server" placeholder="Age" MaxLength="3"></asp:TextBox>
                                    <asp:RegularExpressionValidator ControlToValidate="txtAge" ErrorMessage="Please Enter Numbers Details"
                                        ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" runat="server">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Aadhaar Number</label>
                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                    <asp:TextBox ID="txtAdharNum" CssClass="form-control input-b-b" runat="server" placeholder="Aadhaar No" MaxLength="12" OnTextChanged="txtAdharNum_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="rgxAadhaar" runat="server" ControlToValidate="txtAdharNum"
                                        ValidationExpression="[0-9]{12}"
                                        ErrorMessage="Invalid Aadhaar Number" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>
                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                    <asp:TextBox ID="txtMobile" CssClass="form-control input-b-b" runat="server" placeholder="Mobile Number" MaxLength="10" Enabled="false"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="rgxMobileNumber" runat="server" ControlToValidate="txtMobile"
                                        ValidationExpression="(0|91)?[6-9][0-9]{9}" ErrorMessage="Invalid Mobile Number." ForeColor="Red">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Email</label>
                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                    <asp:TextBox ID="txtEmail" CssClass="form-control input-b-b" runat="server" placeholder="Email" Enabled="false"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail"
                                        ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                        Display="Dynamic" ErrorMessage="Invalid email address" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                                        ForeColor="Red" Display="Dynamic" ErrorMessage="Required" />
                                </div>
                            </div>
                            </div>
                             <div class="content col-md-12">
                            <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Residential Address</label>
                                <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                    <asp:TextBox ID="txtAdd" CssClass="form-control input-b-b" runat="server" placeholder="Residential Address"></asp:TextBox>
                                   <%-- <ajaxToolkit:FilteredTextBoxExtender ID="txtAdd_FilteredTextBoxExtender1" runat="server"
                                        BehaviorID="txtAdd_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters,custom,numbers"
                                        TargetControlID="txtAdd" ValidChars="/,"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                </div>
                                </div>
                            </div>
                        
                        <div class="block black bg-white">
                            <div class="head">Details of Premises to be Licensed</div>
                            <div class="content">
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">House/Door No</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtHsNum" CssClass="form-control input-b-b" runat="server" placeholder="House/Door Number"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="txtHsNum_FilteredTextBoxExtender1" runat="server"
                                            BehaviorID="txtHsNum_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters,numbers,custom"
                                            TargetControlID="txtHsNum" ValidChars="/,-"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Name Of Premises</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtNmePrem" CssClass="form-control input-b-b" runat="server" placeholder="Premises"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="txtNmePrem_FilteredTextBoxExtender1" runat="server"
                                            BehaviorID="txtNmePrem_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters,numbers,custom"
                                            TargetControlID="txtNmePrem" ValidChars="/,"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Street</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtStreet" CssClass="form-control input-b-b" runat="server" placeholder="Street"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="txtStreet_FilteredTextBoxExtender1" runat="server"
                                            BehaviorID="txtStreet_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters"
                                            TargetControlID="txtStreet"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="block black bg-white">
                            <div class="head">Boundaries</div>
                            <div class="content">
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">East</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtEast" CssClass="form-control input-b-b" runat="server" placeholder="East"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="txtEast_FilteredTextBoxExtender1" runat="server"
                                            BehaviorID="txtEast_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters"
                                            TargetControlID="txtEast"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">West</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtWest" CssClass="form-control input-b-b" runat="server" placeholder="West"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="txtWest_FilteredTextBoxExtender1" runat="server"
                                            BehaviorID="txtWest_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters"
                                            TargetControlID="txtWest"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">North</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtNorth" CssClass="form-control input-b-b" runat="server" placeholder="North"></asp:TextBox>
                                       <%-- <ajaxToolkit:FilteredTextBoxExtender ID="txtNorth_FilteredTextBoxExtender2" runat="server"
                                            BehaviorID="txtNorth_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters"
                                            TargetControlID="txtNorth"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">South</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtSouth" CssClass="form-control input-b-b" runat="server" placeholder="South"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="txtSouth_FilteredTextBoxExtender3" runat="server"
                                            BehaviorID="txtSouth_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters"
                                            TargetControlID="txtSouth"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Revenue District</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:DropDownList ID="ddlRevDistrict" runat="server" CssClass="form-control " AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlRevDistrict_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mandal</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:DropDownList ID="ddlMandal" runat="server" CssClass="form-control " AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblbmandal" runat="server" Text="Mandal" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Village/Ward</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:DropDownList ID="ddlLocality" runat="server" CssClass="form-control " AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlLocality_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise District</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="lblExDist" ReadOnly="true" CssClass="form-control input-b-b" runat="server" placeholder="Excise District" Enabled="false"></asp:TextBox>
                                        <asp:Label ID="lblExDistCode" runat="server" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise Station</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="lblExStation" ReadOnly="true" CssClass="form-control input-b-b" runat="server" placeholder="Excise Station" Enabled="false"></asp:TextBox>
                                        <asp:Label ID="lblGHMC" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblExStationCd" runat="server" Visible="false"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">SHO Mobile No</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="lblSHOMob" ReadOnly="true" CssClass="form-control input-b-b" runat="server"
                                            placeholder="SHO Mobile Number" Enabled="false"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="lblSHOMob"
                                            ValidationExpression="(0|91)?[6-9][0-9]{9}" ErrorMessage="Invalid Mobile Number." ForeColor="Red">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                                        Whether the <br />Permises is in <br />Conformity with the <br />Rule 7 of<br /> T.S.Excise(Grant<br /> of Licence
                                                                    of Selling<br /> by In-House&amp<br />;Conditions of <br />licence Rules 2005)</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:DropDownList ID="ddlWhether" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Date of Event</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtEvnDate" CssClass="form-control input-b-b" runat="server" Enabled="false"
                                            placeholder="Date of Event" AutoPostBack="true" OnTextChanged="txtEvnDate_TextChanged" AutoCompleteType="Disabled"></asp:TextBox>
                                        <%--<cc1:CalendarExtender ID="Calendar1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtEvnDate" Format="yyyy-MM-dd"> </cc1:CalendarExtender>--%>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Time/Solt Event</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:DropDownList ID="ddlEvntTm" runat="server" CssClass="form-control ">
                                            <%--              <asp:ListItem Text="Slot-1 (11AM-4PM)" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Slot-2 (7PM-11PM)" Value="2"></asp:ListItem> --%>
                                            <%-- <asp:ListItem Text="Full Day (10AM-11PM)" Value="3"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <asp:HiddenField ID="hf" runat="server" />
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type Of Event</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:DropDownList ID="ddlEvntType" runat="server" CssClass="form-control " AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlEvntType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Event On <br />Occasion Of</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="txtEvent" CssClass="form-control input-b-b" runat="server" placeholder=" Event On Occasion Of"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="txtEvent_FilteredTextBoxExtender" runat="server"
                                            BehaviorID="txtEvent_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters"
                                            TargetControlID="txtEvent"></ajaxToolkit:FilteredTextBoxExtender>--%>
                                    </div>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <asp:RadioButtonList ID="RbTypeP" runat="server" AutoPostBack="True" RepeatDirection="Vertical"
                                        Visible="false" OnSelectedIndexChanged="RbTypeP_SelectedIndexChanged">
                                        <asp:ListItem Text="4 Star And Above Hotels" Value="1" Selected="True">
                                        </asp:ListItem>
                                        <asp:ListItem Text="Other" Value="2">
                                        </asp:ListItem>
                                        <%-- <asp:ListItem Text="Clubs" Value="3">
                                                </asp:ListItem>--%>
                                    </asp:RadioButtonList>
                                    <asp:RadioButtonList ID="Rbtype" runat="server" AutoPostBack="True" RepeatDirection="Vertical"
                                        OnSelectedIndexChanged="RbTypeT_SelectedIndexChanged" Visible="false">
                                        <asp:ListItem Text="Upto 1000" Value="1">
                                        </asp:ListItem>
                                        <asp:ListItem Text="1000 and above Upto 5000" Value="2">
                                        </asp:ListItem>
                                        <asp:ListItem Text="Above 5000" Value="3">
                                        </asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Licence Fee</label>
                                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                                        <asp:TextBox ID="lblFee" CssClass="form-control input-b-b" runat="server" placeholder="Licence Fee" ReadOnly="true" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                    <Triggers>
                        <%--<asp:PostBackTrigger ControlID="ddlRevDistrict" runat="server" />
                        <asp:PostBackTrigger ControlID="ddlMandal" runat="server" />
                        <asp:PostBackTrigger ControlID="ddlLocality" runat="server" />
                        <asp:PostBackTrigger ControlID="ddlEvntType" runat="server" />
                        <asp:PostBackTrigger ControlID="RbTypeP" runat="server" />--%>
                        <asp:AsyncPostBackTrigger ControlID="ddlRevDistrict" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlMandal" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlLocality" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlEvntType" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtAdharNum" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="RbTypeP" />
                    </Triggers>
                </asp:UpdatePanel>
                <div class="content" align="center">

                    <div class="col-xs-12 col-sm-12 txt-cnt">
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
                <%--<div class="content" align="center">
                
                        <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                           
                        </div>
                    </div>--%>
                <%-- <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">

                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-8">
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                </div>--%>

                <%--<div class="container py-5 h-100 justify-content: center;  align-items: center; divlogin">
                        <div class="d-flex justify-content-center align-items-center h-100">
                            <div class="col-6 col-md-6 col-lg-6 col-xl-5">
                                <div class="card " style="border-radius: 1rem;">
                                    <div class="card-body p-5 text-center">

                                        <div class="mb-md-2 mt-md-2 pb-5">
                                            <div class="form-outline form-white mb-4">
                                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                <asp:Image ID="Image2" runat="server" />
                                                <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/Assets/images/RecaptchaLogo.png"
                                                   OnClick="btnImgRefresh_Click" /> 
                                                <span class="form-bar"></span>
                                            </div>
                                            <br />
                                            <div class="form-outline form-white mb-4">
                                                <asp:TextBox ID="captch" runat="server" class="form-control" placeholder="Enter Captcha"></asp:TextBox>
                                                <span class="form-bar"></span>
                                            </div>

                                           


                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                <div class="content" align="center">

                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                            Text="Next" OnClick="btn_Save_Click" />
                    </div>
                    <div class="col-xs-12 col-sm-12 txt-cnt">
                        <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $("#txtEvnDate").datepicker({
                    dateFormat: 'dd-mm-yy',
                    changeMonth: true,
                    changeYear: true,
                    minDate: 0
                });
            });
        });
    </script>
</asp:Content>

