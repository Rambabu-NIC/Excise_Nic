<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/EOB.Master" CodeBehind="A3A.aspx.cs" Inherits="ExciseAPI.EODB.A3A" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= txtdateofbirth.ClientID %>").datepicker({
                dateFormat: 'yy-mm-dd',  // You can customize the format as per your need
                changeMonth: true,
                changeYear: true
            });
            

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">
            <h1>Liquor Retail Shop License Application Form</h1>
            <h2>Annexure to G.O.Ms. No. 86 Revenue (Excise-II) Department, dated 01.08.2023</h2>
            <h3>Department of Prohibition & Excise: Government of Telangana State</h3>
            <h4>Grant of Liquor Retail (A4) Shop License for Excise Year 2023-2025</h4>
        </div>
        <div class="row justify-content-center" runat="server">
            <div class="col-lg-12 col-md-12 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                            <div class="content">
                                <ul class="nav nav-tabs" id="tabMenu">
                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Personal Details" ID="btnA4tab1" OnClick="btnA4tab1_Click" Enabled="true" />
                                    </li>
                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Documents" ID="btnA4tab2" OnClick="btnA4tab2_Click" Enabled="true" />
                                    </li>
                                </ul>
                                <asp:Panel ID="tabContainer" runat="server">
                                    <div id="tabs">
                                        <div id="A4tab1" class="tab-content" runat="server" visible="true">
                                            <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Personal Details</h1>
                                                </div>
                                                <div class="wrapper" runat="server" id="divgridDetails" visible="false">
                                                    <div class="content">
                                                        <asp:GridView ID="gvpersonaldetails" runat="server" AutoGenerateColumns="False" CssClass="table text-nowrap">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="SI.No" ItemStyle-CssClass="txt-cnt">
                                                                    <ItemTemplate>
                                                                        <%#Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                                                <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                                                                <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                                                                <asp:BoundField DataField="PanNo" HeaderText="Pan No" />
                                                                <asp:BoundField DataField="GstNo" HeaderText="Gst No" />
                                                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                                                <asp:BoundField DataField="HouseNo" HeaderText="HouseNo" />
                                                                <asp:BoundField DataField="Street" HeaderText="Street" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="pagetitle">
                                                    <h1>A4 Shop Details</h1>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4">
                                                        <label for="name">A4 Shop Application Serial No.</label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:TextBox CssClass="form-control input-b-b" ID="txtSerialNo" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSerialNo" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <h5>Details of A4 Shop Applied for:</h5>
                                                    <table class="table table-bordered">
                                                        <tbody>
                                                            <tr>
                                                                <th scope="row">1.</th>
                                                                <td>Gazette Serial No of A4 shop</td>
                                                                <td>
                                                                    <asp:TextBox CssClass="form-control input-b-b" ID="txtGazetteNo" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGazetteNo" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th scope="row">2.</th>
                                                                <td>Shop allotted to</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblshopallotted" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="1">SC</asp:ListItem>
                                                                        <asp:ListItem Value="2">ST</asp:ListItem>
                                                                        <asp:ListItem Value="3">Goud</asp:ListItem>
                                                                        <asp:ListItem Value="4">Open</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rblshopallotted" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th scope="row">3.</th>
                                                                <td>Location</td>
                                                                <td>
                                                                    <asp:TextBox CssClass="form-control input-b-b" ID="txtLocation" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLocation" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th scope="row">4.</th>
                                                                <td>Excise District</td>
                                                                <td>
                                                                    <asp:DropDownList class="form-control" ID="ddlExciseDistrict" runat="server" OnSelectedIndexChanged="ddlExciseDistrict_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlExciseDistrict" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th scope="row">5.</th>
                                                                <td>Excise Station</td>
                                                                <td>
                                                                    <asp:DropDownList class="form-control" ID="ddlExciseStation" runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlExciseStation" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th scope="row">6.</th>
                                                                <td>Retail Excise Tax Slab per year (Rs. in Lakhs)</td>
                                                                <td>
                                                                    <asp:TextBox CssClass="form-control input-b-b" ID="txtRetailExTax" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRetailExTax" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="container">
                                                <div class="form-section">
                                                    <h5>APPLICANT'S DETAILS:</h5>
                                                    <div class="col-md-12 row">
                                                        <div class="col-md-6">
                                                            <label for="fname" class="col-form-label">Name:</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtName" runat="server" placeholder="Name"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtName" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <label for="lname" class="col-form-label">Father/Husband Name:</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtFName" runat="server" placeholder="Father/Husband Name"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtFName" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row">
                                                        <div class="col-md-6">
                                                            <label for="birthday" class="col-form-label">Date of Birth:</label>
                                                            <asp:TextBox  class="form-control ui-datepicker" ID="txtdateofbirth" runat="server" placeholder="Birthday"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtdateofbirth" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                             <cc1:CalendarExtender ID="CalendarExtender2" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtdateofbirth" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                                            <%--<asp:RegularExpressionValidator runat="server" ControlToValidate="txtdateofbirth" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                                                ErrorMessage="Invalid date format." ForeColor="Red" />--%>

                                                        </div>
                                                        <div class="col-md-6">
                                                            <label for="age" class="col-form-label">Age on 01/08/2023:</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtAge" runat="server" placeholder="Age"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ControlToValidate="txtAge" ErrorMessage="Please Enter Numbers Details"
                                                                ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" runat="server" ForeColor="Red">
                                                            </asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAge" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row">
                                                        <div class="col-md-6">
                                                            <label for="caste" class="col-form-label">Caste:</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtCaste" runat="server" placeholder="Caste"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtCaste" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-md-6"></div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-section">
                                                <h5>IDENTIFICATION DETAILS:</h5>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="panNo">PAN No.</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtPan" runat="server"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ControlToValidate="txtPan" ErrorMessage="Invalid PAN Number"
                                                                ValidationExpression="([A-Z]){5}([0-9]){4}([A-Z]){1}$" runat="server" ForeColor="Red">
                                                            </asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPan" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="aadharNo">Identity Proofs.</label>
                                                            <asp:DropDownList class="form-control" ID="ddlIdentity" runat="server">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">VoterID Card</asp:ListItem>
                                                                <asp:ListItem Value="2">IncomeTax Pancard</asp:ListItem>
                                                                <asp:ListItem Value="3">Driving Licence</asp:ListItem>
                                                                <asp:ListItem Value="4">Aadhar Card</asp:ListItem>
                                                                <asp:ListItem Value="5">Ration Card</asp:ListItem>
                                                                <asp:ListItem Value="6">Passport</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlIdentity" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="aadharNo">Identity Proof No.</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtIdentityprrofNo" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtIdentityprrofNo" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-section">
                                                <h5>ONLY FOR PARTNERSHIP FIRMS / PRIVATE LIMITED COMPANIES /PUBLIC LIMITED COMPANIES:</h5>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label for="firmName">Name of the firm/company</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtFirm" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtFirm" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label for="registrationNo">Registration No.</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtRegNo" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtRegNo" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label for="registrationDate">Registration Date</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtRegDate" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtRegDate" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                             <cc1:CalendarExtender ID="CalendarExtender3" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtRegDate" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label for="gstin">GSTIN of firm/company (if any)</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtGstIn" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtGstIn" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row col-md-12">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label for="firmPanNo">PAN of firm/company</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtFirmPan" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtFirmPan" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-section">
                                                <h5>DETAILS OF PERSON ATTENDING DRAWL OF LOTS:</h5>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-12 form-group">
                                                        <label>Whether Applicant will attend drawl of lots in person</label>
                                                        <asp:RadioButtonList ID="rblDrawl" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="0">Yes</asp:ListItem>
                                                            <asp:ListItem Value="1">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="rblDrawl" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-section">
                                                <h5>IF NO, DETAILS OF AUTHORIZED REPRESENTATIVE:</h5>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="representativeName">Name:</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtRepresentativeName" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtRepresentativeName" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="repFatherName">Father/Husband Name:</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtRFName" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtRFName" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="repDob">Date of Birth:</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtRDOB" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtRDOB" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtRDOB" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="repMobile">Mobile No:</label>
                                                            <asp:TextBox CssClass="form-control input-b-b" ID="txtRMobile" runat="server"></asp:TextBox>
                                                             <asp:RegularExpressionValidator ID="rgxMobileNumber" runat="server" ControlToValidate="txtRMobile"
                                                            ValidationExpression="(0|91)?[6-9][0-9]{9}" ErrorMessage="Invalid Mobile Number." ForeColor="Red" ValidationGroup="Status">
                                                        </asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtRMobile" ErrorMessage="This field cannot be blank." ValidationGroup="A4Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="A4tab2" class="tab-content" runat="server" visible="true">
                                            <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Documents :</h1>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Document Name :</label>
                                                        <asp:DropDownList class="form-control" ID="ddlFileUpload" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name"></label>
                                                        <asp:FileUpload ID="fileloiuploaddoctype" runat="server" CssClass="form-control input-b-b" />
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name"></label>
                                                        <br />
                                                        <asp:Button runat="server" Text="Add" ID="btnfileAdd" OnClick="btnfileAdd_Click" class="btn btn-info m-2" />
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <asp:Label ID="lblFileUploaderror" runat="server" ForeColor="Red"></asp:Label>
                                                </div>
                                                <div id="divuploadedDocuments" runat="server" visible="false">
                                                    <div class="content table-container">
                                                        <div style="width: 100%; overflow: auto;">
                                                            <asp:GridView ID="gvaddrecordsofLOI" CssClass="custom-table text-nowrap"
                                                                runat="server" AutoGenerateColumns="false" ShowFooter="false" AutoGenerateDeleteButton="false" EmptyDataText="No Documents are available to show" EmptyDataRowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="True"
                                                                OnRowCommand="gvaddrecordsofLOI_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="SNo" ItemStyle-Width="5%">
                                                                        <ItemTemplate>
                                                                            <%#Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="DocumentName" ItemStyle-Width="35%" HeaderText="Document Type" />
                                                                    <asp:TemplateField HeaderText="Documet Copy" ItemStyle-CssClass="txt-cnt">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtn_Documents" runat="server" Text="View" CommandName="lnkbtn_Documents" CommandArgument='<%# Eval("DocumentSerialNumber").ToString() %>' ForeColor="Green"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="25%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lknbtndocDelete" runat="server" Text="Delete" OnClick="lknbtndocDelete_Click"><img src="../assets/img/Del-Icon.png" onclick="" /></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="content col-lg-12 text-center" align="center">
                                                    <asp:Button ID="btnA4" Text="Submit" runat="server" class="btn btn-info m-2" OnClick="btnA4_Click" />
                                                    <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="content col-lg-12 text-center">
                                        <asp:Button ID="btnPrevious" runat="server" class="btn btn-info m-2" Text="Previous" OnClick="btnPrevious_Click" />
                                        <asp:Button ID="btnNext" runat="server" class="btn btn-info m-2" Text="Next" OnClick="btnNext_Click" ValidationGroup="A4Submit"/>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
