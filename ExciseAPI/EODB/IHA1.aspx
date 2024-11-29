<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/EOB.Master" CodeBehind="IHA1.aspx.cs" Inherits="ExciseAPI.EODB.IHA1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= txtDatebussiness.ClientID %>").datepicker({
                dateFormat: 'yy-mm-dd',  // You can customize the format as per your need
                changeMonth: true,
                changeYear: true
            });
            $("#<%= txtEventDate.ClientID %>").datepicker({
                dateFormat: 'yy-mm-dd',  // You can customize the format as per your need
                changeMonth: true,
                changeYear: true,

            });
        });
    </script>
    <%--<script type="text/javascript">
        function pageLoad() {
            jQueryUI("input[id*='txtDatebussiness']").datepicker({ maxDate: new Date(), dateFormat: 'yy-mm-dd' });
        }
        </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">
            <h1>IHA1</h1>
        </div>
        <div class="row justify-content-center" runat="server">
            <div class="col-lg-12 col-md-12 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                            <div class="content">
                                <ul class="nav nav-tabs" id="tabMenu">
                                    <li class="nav-item">

                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Personal Details" ID="btnIHA1tab1" OnClick="btnIHA1tab1_Click" Enabled="true" />
                                    </li>

                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Documents" ID="btnIHA1tab2" OnClick="btnIHA1tab2_Click" Enabled="true" />
                                    </li>
                                </ul>
                                <asp:Panel ID="tabContainer" runat="server">
                                    <div id="tabs">
                                        <div id="IHA1tab1" class="tab-content" runat="server" visible="true">
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
                                            <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Details of Company or Partnership frim with Registration Particulars</h1>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Licence Type:</label>
                                                    <asp:DropDownList class="form-control" ID="ddlLicenceType" runat="server">
                                                        <asp:ListItem Value="0">--Select --</asp:ListItem>
                                                        <asp:ListItem Value="1">TD-1</asp:ListItem>
                                                        <asp:ListItem Value="2">TD-2</asp:ListItem>
                                                        <asp:ListItem Value="3">CS-1</asp:ListItem>
                                                        <asp:ListItem Value="4">CS-2</asp:ListItem>
                                                        <asp:ListItem Value="5">CS-3</asp:ListItem>
                                                        <asp:ListItem Value="6">AL-1</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLicenceType" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Company Name :</label>
                                                    <asp:TextBox ID="txtcompanyname" class="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcompanyname" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="col-md-4 form-group">
                                                </div>
                                            </div>
                                            <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Company Address</h1>
                                                </div>
                                                <div class="col-md-12 row">

                                                    <div class="col-md-4 form-group">
                                                        <label for="name">ROC Number(If company):</label>

                                                        <asp:TextBox class="form-control" ID="txtRocNumber" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRocNumber" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group"></div>
                                                    <div class="col-md-4 form-group">
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">House No.</label>

                                                        <asp:TextBox class="form-control" ID="txtHouseNo_C" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtHouseNo_C" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Street and Landmark:</label>

                                                        <asp:TextBox class="form-control" ID="txtStreet_C" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtStreet_C" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">District</label>

                                                        <asp:DropDownList class="form-control" ID="ddlDistrict_C" runat="server" OnSelectedIndexChanged="ddlDistrict_C_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDistrict_C" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>


                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Mandal</label>

                                                        <asp:DropDownList class="form-control" ID="ddlMandal_C" runat="server" OnSelectedIndexChanged="ddlMandal_C_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMandal_C" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Village</label>

                                                        <asp:DropDownList class="form-control" ID="ddlVillage_C" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlVillage_C" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">PIN Code</label>

                                                        <asp:TextBox class="form-control" ID="txtPincode_C" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPincode_C" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Details of Premises</h1>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Name</label>
                                                        <asp:TextBox class="form-control" ID="txtName" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtName" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Trade Licence</label>
                                                        <asp:TextBox class="form-control" ID="txttradeLicence" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txttradeLicence" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Pilinth Area of premises to be licenced in Sq.Mtr</label>
                                                        <asp:TextBox class="form-control" ID="txtpilintharea" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtpilintharea" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">House No.</label>

                                                        <asp:TextBox class="form-control" ID="txtHHouseNo" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtHHouseNo" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Street and Landmark:</label>

                                                        <asp:TextBox class="form-control" ID="txtHStreet" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtHStreet" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">District</label>

                                                        <asp:DropDownList class="form-control" ID="ddlHDistrict" runat="server" OnSelectedIndexChanged="ddlHDistrict_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlHDistrict" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Mandal</label>

                                                        <asp:DropDownList class="form-control" ID="ddlHMandal" runat="server" OnSelectedIndexChanged="ddlHMandal_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlHMandal" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Village</label>

                                                        <asp:DropDownList class="form-control" ID="ddlHVillage" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlHVillage" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">PIN Code</label>

                                                        <asp:TextBox class="form-control" ID="txtHPincode" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtHPincode" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row">

                                                <div class="col-md-4 form-group">
                                                    <label for="name">Details of Any other Licence held by him:</label>
                                                    <asp:TextBox ID="txtlicenceheld" class="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtlicenceheld" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Date on which likely to commence bussiness:</label>
                                                    <asp:TextBox ID="txtDatebussiness" class="form-control ui-datepicker" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtDatebussiness" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <cc1:CalendarExtender ID="CalendarExtender3" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDatebussiness" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Incase of EP-1 the approximate quantity of IMFL required:</label>
                                                    <asp:TextBox ID="txtIncaseofEvent" class="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtIncaseofEvent" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row">

                                                <div class="col-md-4 form-group">
                                                    <label for="name">Event Registration Number :</label>
                                                    <asp:TextBox ID="txtEventRegNo" class="form-control" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtEventRegNo" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Event Date:</label>
                                                    <asp:TextBox ID="txtEventDate" class="form-control ui-datepicker" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtEventDate" ErrorMessage="This field cannot be blank." ValidationGroup="IHA1Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" Enabled="True" PopupButtonID="imgPopup" runat="server" TargetControlID="txtEventDate" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                </div>
                                            </div>
                                        </div>
                                        <div id="IHA1tab2" class="tab-content" runat="server" visible="true">
                                            <div class="col-md-12 row">
                                                <div class="pagetitle">
                                                    <h1>Documents :</h1>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name">Document Name :</label>
                                                    <asp:DropDownList class="form-control" ID="ddlFileUpload" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <label for="name"></label>
                                                    <%-- <asp:FileUpload ID="FileUpload2" runat="server" class="form-control-file border" />--%>
                                                    <asp:FileUpload ID="fileloiuploaddoctype" runat="server" CssClass="form-control input-b-b" />
                                                </div>
                                                <div class="col-md-4 form-group">
                                                    <asp:Button runat="server" Text="Add" ID="btnfileAdd" OnClick="btnfileAdd_Click" class="btn btn-info m-2" />
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
                                                    <asp:Button ID="btnIha1" Text="Submit" runat="server" class="btn btn-info m-2" OnClick="btnIha1_Click" />
                                                    <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="content col-lg-12 text-center">
                                        <asp:Button ID="btnPrevious" runat="server" class="btn btn-info m-2" Text="Previous" OnClick="btnPrevious_Click" />
                                        <asp:Button ID="btnNext" runat="server" class="btn btn-info m-2" Text="Next" OnClick="btnNext_Click" ValidationGroup="IHA1Submit"/>
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


