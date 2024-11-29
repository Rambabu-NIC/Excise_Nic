<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Event/Event.master" CodeBehind="AdditionalPayment.aspx.cs" Inherits="ExciseAPI.Event.AdditionalPayment" %>

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
            <div class="head">Permit Details</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Registration Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtRegistrationNo" MaxLength="10" CssClass="form-control input-b-b" runat="server" placeholder="Registration No"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtMobileNumber" MaxLength="10" CssClass="form-control input-b-b" runat="server" placeholder="Mobile No"></asp:TextBox>
                    </div>
                </div>


            </div>
            <div class="content" align="center">

                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblmsg" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                    <asp:Image ID="Image2" runat="server" />
                    <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/Assets/images/RecaptchaLogo.png"
                        OnClick="btnImgRefresh_Click" />
                    <span class="form-bar"></span>

                    <div class="container-fluid" align="center">
                        <asp:TextBox ID="captch" runat="server" class="form-control" placeholder="Enter Captcha" CssClass="Regcaptcha" MaxLength="6"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="captch_FilteredTextBoxExtender1" runat="server"
                            BehaviorID="captch_FilteredTextBoxExtender" FilterType="numbers"
                            TargetControlID="captch"></ajaxToolkit:FilteredTextBoxExtender>
                        <span class="form-bar"></span>
                    </div>
                </div>


            </div>
            <div class="content" align="center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Save" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                        Text="Submit" OnClick="btn_Save_Click" />
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="lblError" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="w-100 fl container-fluid" id="pannelOK" runat="server" visible="false">
        <div class="block black bg-white">
            <div class="head">Details of Premises to be Licensed</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Name of Applicant</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Mr" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Miss" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Smt" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtAppliName" CssClass="form-control input-b-b" runat="server" ReadOnly="true" placeholder="Name of Applicant"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Aadhaar Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtAdharNum" CssClass="form-control input-b-b" runat="server" ReadOnly="true" placeholder="Aadhaar Number"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mobile Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtMobile" CssClass="form-control input-b-b" runat="server" ReadOnly="true" placeholder="Mobile Number"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Email</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtEmail" CssClass="form-control input-b-b" runat="server" ReadOnly="true" placeholder="Email"></asp:TextBox>
                    </div>
                </div>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Label ID="lblReg" Visible="false" runat="server" Text="Label"></asp:Label>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Age</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtAge" CssClass="form-control input-b-b" runat="server" ReadOnly="true" placeholder="Age"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Father's Name</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtFatherName" CssClass="form-control input-b-b" runat="server" ReadOnly="true" placeholder="Father's Name"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Residential Address</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtAdd" CssClass="form-control input-b-b" runat="server" ReadOnly="true" placeholder="Residential Address"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">House/Door Number</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtHsNum" CssClass="form-control input-b-b" runat="server" ReadOnly="true" placeholder=" House/Door Number"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Name Of the Premises</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtNmePrem" CssClass="form-control input-b-b" runat="server" ReadOnly="true" placeholder=" Name Of the Premises"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Street</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtStreet" CssClass="form-control input-b-b" runat="server" ReadOnly="true" placeholder=" Name Of the Premises"></asp:TextBox>
                    </div>
                </div>

            </div>
        </div>
        <div class="block black bg-white">
            <div class="head">Boundries</div>
            <div class="content">
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">East</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtEast" CssClass="form-control input-b-b" runat="server" placeholder="East"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">West</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtWest" CssClass="form-control input-b-b" runat="server" placeholder="West"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">North</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtNorth" CssClass="form-control input-b-b" runat="server" placeholder="North"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">South</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtSouth" CssClass="form-control input-b-b" runat="server" placeholder="South"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Revenue District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:Label ID="Label6" runat="server" Visible="false"></asp:Label>
                        <asp:TextBox ID="lblRDist" CssClass="form-control input-b-b" runat="server" placeholder="Revenue District"></asp:TextBox>
                    </div>
                </div>
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Mandal</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="lblbRMand" CssClass="form-control input-b-b" runat="server" placeholder="Mandal"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Village/Locality</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="lblbRVill" CssClass="form-control input-b-b" runat="server" placeholder="Village/Locality"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise District</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:Label ID="lblExDistCode" runat="server" Visible="false"></asp:Label>
                        <asp:TextBox ID="lblExDist" CssClass="form-control input-b-b" runat="server" placeholder="Excise District"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Excise Station</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:Label ID="lblExStationCd" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblGHMC" runat="server" Visible="false"></asp:Label>
                        <asp:TextBox ID="lblExStation" CssClass="form-control input-b-b" runat="server" placeholder="Excise Station"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">
                        Whether the Permises is<br /> in Conformity with the Rule 7<br /> of A.P.Excise(Grant<br /> of 
                                                                             Licence of Selling by In-House;<br />Conditions of<br /> licence Rules 2005)</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="lblRule7" CssClass="form-control input-b-b" runat="server" placeholder="Rule 7"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Date And Time of Event</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:Label ID="ddlEvntTm" runat="server" Visible="false"></asp:Label>
                        <asp:TextBox ID="txtEvnDate" CssClass="form-control input-b-b" runat="server" placeholder="Date And Time of Event"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtEvnDate" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Type Of Event</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="Label5" CssClass="form-control input-b-b" runat="server" placeholder="Type Of Event"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Event On Occasion Of</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtEvent" CssClass="form-control input-b-b" runat="server" placeholder="Event On Occasion Of"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Licence Fee</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="lblFee" CssClass="form-control input-b-b" runat="server" placeholder="Licence Fee"></asp:TextBox>
                    </div>
                </div>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">SHO Remarks</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtRemarks" CssClass="form-control input-b-b" runat="server" placeholder="Remarks"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-xs-12 col-sm-6 col-md-4 col-lg-4 p-0 xs-field">
                    <label class="col-xs-4 col-sm-5 col-md-5 col-lg-4">Additional Amount to be paid</label>
                    <div class="col-xs-8 col-sm-7 col-md-7 col-lg-5">
                        <asp:TextBox ID="txtDtInsp" CssClass="form-control input-b-b" runat="server" placeholder="Additional Amount to be paid"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="content" align="center">
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Button ID="btn_Update" CssClass="btn btn-secondary btnn btn-sm text-uppercase m-t-10" runat="server"
                        Text="Proceed to pay" OnClick="btn_Update_Click" />
                </div>
                <div class="col-xs-12 col-sm-12 txt-cnt">
                    <asp:Label ID="Label1" runat="server" Style="text-align: center" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div runat="server" visible="false" id="RegDoc" class="row">
        <div class="col-sm-12">
            <div class="card">
                <div class="col-sm-12">

                    <asp:Label ID="lblDocReg" runat="server" Text="Label"></asp:Label>
                    <asp:GridView ID="grddocs" runat="server" AllowPaging="False"
                        AutoGenerateColumns="False" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                        CssClass="Grid" OnRowCommand="grddocs_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Sno" ItemStyle-VerticalAlign="Top">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uploaded Documents"
                                ItemStyle-VerticalAlign="Top">
                                <ItemTemplate>
                                    <asp:Label ID="lbldoccd" runat="server" Text='<%# Bind("UploadDco_Code") %>'
                                        Visible="false"></asp:Label>
                                    <asp:Label ID="lbldocname" runat="server" Text='<%# Bind("UploadDco_Name") %>'></asp:Label>
                                    <asp:Label ID="lbldocsno" runat="server" Text='<%# Bind("UploadDocs_Sno") %>'
                                        Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Documents View" ItemStyle-VerticalAlign="Top">
                                <ItemTemplate>
                                    <%-- <iframe id="iframedoc" runat="server" height="200px" src='<%# GetImage(Eval("UploadDco_File")) %>'
                                        width="200px"></iframe>--%>
                                    <asp:LinkButton ID="btnView" runat="server" CommandName="View" Text="View"></asp:LinkButton>
                                    <asp:Label ID="lbl_Apptype" runat="server" Text='<%#Eval("Application_Type")%>'
                                        Visible="false"></asp:Label>

                                    <asp:Label ID="lblAppid" runat="server" Text='<%# Bind("Reg_No") %>'
                                        Visible="false"></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <HeaderStyle BackColor="#378686" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            No Records
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hf" runat="server" />
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

