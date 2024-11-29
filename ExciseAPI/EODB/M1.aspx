<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/EOB.Master" CodeBehind="M1.aspx.cs" Inherits="ExciseAPI.EODB.M1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="section">
        <div class="pagetitle text-center">

            <h1>Molasses_M1</h1>

        </div>
        <div class="row justify-content-center" runat="server">
            <div class="col-lg-12 col-md-12 d-flex flex-column align-items-center justify-content-center">
                <div class="card">
                    <div class="card-body">
                        <div class="wrapper ">
                            <div class="content">
                                <ul class="nav nav-tabs" id="tabMenu">
                                    <li class="nav-item">

                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Personal Details" ID="btntab1" OnClick="btntab1_Click" Enabled="true" />
                                    </li>

                                    <li class="nav-item">
                                        <asp:Button CssClass="btn btn-light tab-button-click" runat="server" Text="Documents" ID="btntab2" OnClick="btntab2_Click" Enabled="true" />
                                    </li>
                                </ul>
                                <asp:Panel ID="tabContainer" runat="server">
                                    <div id="tabs">
                                        <div id="tab1" class="tab-content" runat="server" visible="true">
                                            <div class="col-md-12">
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

                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Name of the Sugar/Gur factory:</label>

                                                        <asp:TextBox class="form-control" ID="txtSugarFactory" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="txtSugarFactory" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>

                                                <div class="pagetitle">
                                                    <h1>Location of the factory:</h1>
                                                </div>
                                                <br />
                                                <div class="col-md-12 row">

                                                    <div class="col-md-4 form-group">
                                                        <label for="name">District:</label>

                                                        <asp:DropDownList class="form-control" ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDistrict" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Mandal:</label>

                                                        <asp:DropDownList class="form-control" ID="ddlMandal" runat="server" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlMandal" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Village:</label>

                                                        <asp:DropDownList class="form-control" ID="ddlVillage" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlVillage" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>

                                                </div>
                                                <div class="col-md-12 row">

                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Survey No:</label>

                                                        <asp:TextBox class="form-control" ID="txtSurveyNo" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSurveyNo" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Extent No:</label>

                                                        <asp:TextBox class="form-control" ID="txtExtent" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtExtent" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>
                                                <div class="col-md-12 row">
                                                    <div class="col-md-12 form-group d-flex align-items-center">
                                                        <label for="name" class="mb-0 me-2">
                                                            Whether the applicant is owner or a person in charge of the factory:
       
                                                        </label>
                                                        <asp:RadioButtonList ID="rblOwnLand" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="0">Owner</asp:ListItem>
                                                            <asp:ListItem Value="1">In-Charge</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rblOwnLand" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="pagetitle">
                                                    <h3>If Owner, Details thereof:</h3>
                                                </div>
                                                <br />
                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Mobile Number:</label>

                                                        <asp:TextBox class="form-control" ID="txtOMobile" runat="server"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="rgxMobileNumber" runat="server" ControlToValidate="txtOMobile"
                                                            ValidationExpression="(0|91)?[6-9][0-9]{9}" ErrorMessage="Invalid Mobile Number." ForeColor="Red" ValidationGroup="Status">
                                                        </asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtOMobile" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Pan Number:</label>

                                                        <asp:TextBox class="form-control" ID="txtOPan" runat="server"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ControlToValidate="txtOPan" ErrorMessage="Invalid PAN Number"
                                                            ValidationExpression="([A-Z]){5}([0-9]){4}([A-Z]){1}$" runat="server" ForeColor="Red">
                                                        </asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtOPan" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Aadhar Number:</label>

                                                        <asp:TextBox class="form-control" ID="txtOAadhar" runat="server"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="rgxAadhaar" runat="server" ControlToValidate="txtOAadhar"
                                                            ValidationExpression="[0-9]{12}"
                                                            ErrorMessage="Invalid Aadhaar Number" ForeColor="Red"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtOAadhar" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>

                                                <div class="col-md-12 row">
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">GST-IN:</label>

                                                        <asp:TextBox class="form-control" ID="txtOGst" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtOGst" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                    <div class="col-md-4 form-group">
                                                        <label for="name">Email:</label>

                                                        <asp:TextBox class="form-control" ID="txtOEmail" runat="server"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtOEmail"
                                                            ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                            Display="Dynamic" ErrorMessage="Invalid email address" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOEmail"
                                                            ForeColor="Red" Display="Dynamic" ErrorMessage="Required" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtOEmail" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>

                                                </div>



                                                <div class="col-md-12 row">

                                                    <div class="col-md-6 form-group">
                                                        <label for="name">Details of the use or uses which molasses will be put to:</label>

                                                        <asp:TextBox class="form-control" ID="txtMolasse" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtMolasse" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                    <div class="col-md-6 form-group">
                                                        <label for="name">Quantity required annually for such use case:</label>
                                                        <asp:TextBox class="form-control" ID="txtAnualQty" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtAnualQty" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                   <%-- <div class="col-md-4 form-group">--%>
                                                        <%--  <label for="name">Stock details:</label>

                                    <asp:TextBox class="form-control" ID="txtStockDetails" runat="server"></asp:TextBox>--%>
                                                    <%--</div>--%>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row">
                                                <div class="col-md-12 form-group">
                                                    <label for="name">Details of arrangements for the storage of molasses whether pucca built tanks or steel tanks are provided for the storage:</label>

                                                    <asp:RadioButtonList ID="rblstoragetank" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="0">pucca built tanks</asp:ListItem>
                                                        <asp:ListItem Value="1">steel tanks</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="rblstoragetank" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>


                                            </div>
                                            <div class="col-md-12 row">
                                                <div class="col-md-6 form-group">
                                                    <label for="name">Period for which the licence is required:</label>

                                                    <asp:TextBox class="form-control" ID="txtPeriodLicense" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtPeriodLicense" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>
                                                <div class="col-md-6 form-group">
                                                    <label for="name">Total quantity of molasses expected to be produced during the year:</label>

                                                    <asp:TextBox class="form-control" ID="txtMProduced" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtMProduced" ErrorMessage="This field cannot be blank." ValidationGroup="M1Submit" ForeColor="Red"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>
                                        <div id="tab2" class="tab-content" runat="server" visible="true">
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
                                                        <%-- <asp:FileUpload ID="FileUpload2" runat="server" class="form-control-file border" />--%>
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
                                                <div class="content col-lg-12 text-center">
                                                    <asp:Button ID="btnM1" Text="Submit" runat="server" class="btn btn-info m-2" OnClick="btnM1_Click" />
                                                    <asp:Button ID="btnM1Draft" Text="Save & Preview" runat="server" class="btn btn-info m-2" OnClick="btnM1Draft_Click" Visible="false" />
                                                    <asp:Label ID="lblActionerror" runat="server" ForeColor="Red"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="content col-lg-12 text-center">
                                        <asp:Button ID="btnPrevious" runat="server" class="btn btn-info m-2" Text="Previous" OnClick="btnPrevious_Click" />
                                        <asp:Button ID="btnNext" runat="server" class="btn btn-info m-2" Text="Next" OnClick="btnNext_Click" ValidationGroup="M1Submit" />
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


